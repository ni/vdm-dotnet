Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Battery Clamp Inspection Example
'
' This example loads a template image and defines a coordinate system in the image.  The example
' uses the template image and matches it on the new images.  Measurement areas are repositioned
' in the image according to the location of the defined coordinate system.  The example uses a
' clamp to perform a distance measurement between two edges of the part inspected and a circular
' edge finder to perform a diameter measurement.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Battery\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private transform As New CoordinateTransform()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Display the first image.
        imageViewer1.Attach(GetNextImage())
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Find the new coordinate transformation.
        Dim matchOptions As New MatchPatternOptions(MatchMode.RotationInvariant)
        matchOptions.MinimumMatchScore = 700
        matchOptions.SubpixelAccuracy = True
        Dim drawOptions As New DrawOptions()
        drawOptions.ShowResult = True
        FindTransformWithPattern(image, imageViewer2.Image, FindTransformMode.UpdateTransform, matchOptions, drawOptions, transform)

        ' Initialize search rectangle and search annulus.
        Dim searchRectangle As New RectangleContour(470, 110, 30, 190)
        Dim searchAnnulus As New AnnulusContour(New PointContour(366, 201), 33, 121, 42.71, 314.13)

        ' Overlay the search area for the distance measurement.
        drawOptions.ShowEdgesFound = True
        drawOptions.ShowSearchArea = True
        drawOptions.ShowSearchLines = True
        drawOptions.ShowResult = True
        Dim distance As Double = MeasureMaximumDistance(image, searchRectangle, RakeDirection.TopToBottom, drawOptions, transform)

        ' Overlay the search area for the circle measurement.
        Dim circleReport As FitCircleReport = FindCircularEdge(image, searchAnnulus, SpokeDirection.InsideToOutside, drawOptions, transform)

        ' Display results.
        distanceBox.Text = [String].Format("{0:0.00}", distance)
        centerXBox.Text = [String].Format("{0:0.00}", circleReport.Center.X)
        centerYBox.Text = [String].Format("{0:0.00}", circleReport.Center.Y)
        radiusBox.Text = [String].Format("{0:0.00}", circleReport.Radius)

        ' Display the image.
        imageViewer1.Attach(image)
    End Sub

    Private Sub defineCoordinateSystemButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles defineCoordinateSystemButton.Click
        ' Read a template file representing a characteristic portion of the object
        ' used as a reference coordinate system.
        imageViewer2.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"))

        Dim matchOptions As New MatchPatternOptions(MatchMode.RotationInvariant)
        matchOptions.MinimumMatchScore = 700
        matchOptions.SubpixelAccuracy = True
        Dim drawOptions As New DrawOptions()
        drawOptions.ShowResult = True
        FindTransformWithPattern(imageViewer1.Image, imageViewer2.Image, FindTransformMode.FindReference, matchOptions, drawOptions, transform)

        ' Update buttons.
        defineCoordinateSystemButton.Enabled = False
        defineMeasurementsButton.Enabled = True
    End Sub

    Private Sub defineMeasurementsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles defineMeasurementsButton.Click
        ' Initialize search rectangle and search annulus.
        Dim searchRectangle As New RectangleContour(470, 110, 30, 190)
        Dim searchAnnulus As New AnnulusContour(New PointContour(366, 201), 33, 121, 42.71, 314.13)

        ' Overlay the search area for the distance measurement.
        Dim drawOptions As New DrawOptions()
        drawOptions.ShowEdgesFound = True
        drawOptions.ShowSearchArea = True
        drawOptions.ShowSearchLines = True
        MeasureMaximumDistance(imageViewer1.Image, searchRectangle, RakeDirection.TopToBottom, drawOptions, New CoordinateTransform())

        ' Overlay the search area for the circle measurement.
        FindCircularEdge(imageViewer1.Image, searchAnnulus, SpokeDirection.InsideToOutside, drawOptions, New CoordinateTransform())

        ' Update buttons.
        defineMeasurementsButton.Enabled = False
        runButton.Enabled = True
    End Sub

    Private Sub runButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles runButton.Click
        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)

        ' Update buttons.
        runButton.Enabled = False
    End Sub

    Private Sub FindTransformWithPattern(ByVal image As VisionImage, ByVal template As VisionImage, ByVal mode As FindTransformMode, ByVal matchOptions As MatchPatternOptions, ByVal drawOptions As DrawOptions, ByVal transform As CoordinateTransform)
        ' Find the pattern in the image.
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchPattern(image, template, matchOptions)

        ' If the pattern was found:
        If matches.Count > 0 Then
            ' The points in the Corners collection are returned like this:
            '
            '   0 — 1
            '   |   |
            '   3 — 2
            '
            ' Our main axis will be along the line from point 3 to point 2 and
            ' our secondary axis will be from point 3 to point 0. The origin will
            ' be at point 3.
            Dim mainAxis As New LineContour(matches(0).Corners(3), matches(0).Corners(2))
            Dim secondaryAxis As New LineContour(matches(0).Corners(3), matches(0).Corners(0))

            ' Fill in the coordinate transform with the data obtained by the pattern matching.
            transform.MeasurementSystem.Origin = matches(0).Corners(3)
            transform.MeasurementSystem.Angle = matches(0).Rotation
            transform.MeasurementSystem.AxisOrientation = AxisOrientation.Direct

            ' If this is the first run, fill in the reference system too.
            If mode = FindTransformMode.FindReference Then
                transform.ReferenceSystem.Origin = matches(0).Corners(3)
                transform.ReferenceSystem.Angle = matches(0).Rotation
                transform.ReferenceSystem.AxisOrientation = AxisOrientation.Direct
            End If

            ' Draw the results on the image.
            If drawOptions.ShowResult Then
                ' Draw the origin.
                image.Overlays.[Default].AddRectangle(New RectangleContour(mainAxis.Start.X - 2, mainAxis.Start.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.DrawValue)

                ' Draw each axis.
                image.Overlays.[Default].AddLine(mainAxis, Rgb32Value.RedColor)
                DrawArrow(image.Overlays.[Default], mainAxis, Rgb32Value.RedColor)
                image.Overlays.[Default].AddLine(secondaryAxis, Rgb32Value.RedColor)
                DrawArrow(image.Overlays.[Default], secondaryAxis, Rgb32Value.RedColor)
            End If
        End If
    End Sub

    Private Function FindCircularEdge(ByVal image As VisionImage, ByVal searchAnnulus As AnnulusContour, ByVal spokeDirection As SpokeDirection, ByVal drawOptions As DrawOptions, ByVal transform As CoordinateTransform) As FitCircleReport
        ' Add the search rectangle to an Roi.
        Dim roi As New Roi(New Shape() {searchAnnulus})

        ' Transform the Roi.
        Algorithms.TransformRoi(roi, transform)

        ' Perform a spoke operation.
        Dim report As SpokeReport = Algorithms.Spoke(image, roi, spokeDirection, EdgeProcess.FirstAndLast, 8)

        Dim circlePoints As New Collection(Of PointContour)()
        For Each edgeInfo As EdgeInfo In report.FirstEdges
            circlePoints.Add(edgeInfo.Position)
        Next
        ' Fit a circle to the points found.
        Dim circleReport As FitCircleReport = Algorithms.FitCircle(circlePoints)

        ' Draw the results.
        If drawOptions.ShowSearchLines Then
            For Each lineInfo As SearchLineInfo In report.SearchLines
                image.Overlays.[Default].AddLine(lineInfo.Line, Rgb32Value.BlueColor)
                DrawArrow(image.Overlays.[Default], lineInfo.Line, Rgb32Value.BlueColor)
            Next
        End If
        If drawOptions.ShowSearchArea Then
            image.Overlays.[Default].AddRoi(roi)
        End If
        If drawOptions.ShowEdgesFound Then
            For Each edgeInfo As EdgeInfo In report.FirstEdges
                image.Overlays.[Default].AddRectangle(New RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue)
            Next
        End If
        If drawOptions.ShowResult Then
            ' Overlay the center point.
            image.Overlays.[Default].AddOval(New OvalContour(circleReport.Center.X - 2, circleReport.Center.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)

            ' Overlay the circle.
            image.Overlays.[Default].AddOval(New OvalContour(circleReport.Center.X - circleReport.Radius, circleReport.Center.Y - circleReport.Radius, 2 * circleReport.Radius, 2 * circleReport.Radius), Rgb32Value.RedColor, DrawingMode.DrawValue)
        End If
        Return circleReport
    End Function

    Private Function MeasureMaximumDistance(ByVal image As VisionImage, ByVal searchRectangle As RectangleContour, ByVal rakeDirection As RakeDirection, ByVal drawOptions As DrawOptions, ByVal transform As CoordinateTransform) As Double
        ' Convert the search rectangle to an Roi.
        Dim roi As Roi = searchRectangle.ConvertToRoi()

        ' Transform the Roi.
        Algorithms.TransformRoi(roi, transform)

        ' Perform a rake operation.
        Dim report As RakeReport = Algorithms.Rake(image, roi, rakeDirection, EdgeProcess.FirstAndLast)

        ' Find the maximum edge positions and compute the distance.
        Dim perpendicularLines As New Collection(Of LineContour)
        Dim closestFirstEdge As New PointContour, closestLastEdge As New PointContour
        Dim distance As Double = FindMinMaxPosition(report, perpendicularLines, closestFirstEdge, closestLastEdge)

        ' Draw the results.
        If drawOptions.ShowSearchLines Then
            For Each lineInfo As SearchLineInfo In report.SearchLines
                image.Overlays.[Default].AddLine(lineInfo.Line, Rgb32Value.BlueColor)
            Next
        End If
        If drawOptions.ShowSearchArea Then
            image.Overlays.[Default].AddRoi(roi)
        End If
        If drawOptions.ShowEdgesFound Then
            For Each edgeInfo As EdgeInfo In report.FirstEdges
                image.Overlays.[Default].AddRectangle(New RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue)
            Next
            For Each edgeInfo As EdgeInfo In report.LastEdges
                image.Overlays.[Default].AddRectangle(New RectangleContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor)
            Next
        End If
        If drawOptions.ShowResult Then
            ' Overlay the measurement edge points.
            image.Overlays.[Default].AddOval(New OvalContour(closestFirstEdge.X - 2, closestFirstEdge.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)
            image.Overlays.[Default].AddOval(New OvalContour(closestLastEdge.X - 2, closestLastEdge.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)
            ' Overlay the two lines that point inward from the search area to the clamp position.
            Dim line1 As New LineContour(FindMidpoint(report.SearchLines(0).Line.Start, report.SearchLines(report.SearchLines.Count - 1).Line.Start), FindMidpoint(perpendicularLines(0)))
            image.Overlays.[Default].AddLine(line1, Rgb32Value.RedColor)
            DrawArrow(image.Overlays.[Default], line1, Rgb32Value.RedColor)

            Dim line2 As New LineContour(FindMidpoint(report.SearchLines(0).Line.[End], report.SearchLines(report.SearchLines.Count - 1).Line.[End]), FindMidpoint(perpendicularLines(1)))
            image.Overlays.[Default].AddLine(line2, Rgb32Value.RedColor)
            DrawArrow(image.Overlays.[Default], line2, Rgb32Value.RedColor)

            ' Overlay the two lines perpendicular to the search lines that correspond to the clamp position.
            image.Overlays.[Default].AddLine(perpendicularLines(0), Rgb32Value.RedColor)
            image.Overlays.[Default].AddLine(perpendicularLines(1), Rgb32Value.RedColor)
        End If
        Return distance
    End Function

    Private Function FindMidpoint(ByVal pt1 As PointContour, ByVal pt2 As PointContour) As PointContour
        Return New PointContour((pt1.X + pt2.X) / 2, (pt1.Y + pt2.Y) / 2)
    End Function

    Private Function FindMidpoint(ByVal line As LineContour) As PointContour
        Return FindMidpoint(line.Start, line.[End])
    End Function

    Private Function FindMinMaxPosition(ByVal report As RakeReport, ByRef perpendicularLines As Collection(Of LineContour), ByRef closestFirstEdge As PointContour, ByRef closestLastEdge As PointContour) As Double
        Dim closestFirstEdgeDistance As Double = Double.PositiveInfinity
        Dim closestLastEdgeDistance As Double = Double.PositiveInfinity
        closestFirstEdge = New PointContour()
        closestLastEdge = New PointContour()
        For Each lineInfo As SearchLineInfo In report.SearchLines
            ' If we found an edge on this line, calculate the distances.
            If lineInfo.EdgeReport.Edges.Count > 0 Then
                Dim firstEdgeDistance As Double = DistanceSquared(lineInfo.Line.Start, lineInfo.EdgeReport.Edges(0).Position)
                If firstEdgeDistance < closestFirstEdgeDistance Then
                    closestFirstEdgeDistance = firstEdgeDistance
                    closestFirstEdge = lineInfo.EdgeReport.Edges(0).Position
                End If
                Dim lastEdgeDistance As Double = DistanceSquared(lineInfo.Line.[End], lineInfo.EdgeReport.Edges(lineInfo.EdgeReport.Edges.Count - 1).Position)
                If lastEdgeDistance < closestLastEdgeDistance Then
                    closestLastEdgeDistance = lastEdgeDistance
                    closestLastEdge = lineInfo.EdgeReport.Edges(lineInfo.EdgeReport.Edges.Count - 1).Position
                End If
            End If
        Next
        perpendicularLines = New Collection(Of LineContour)()
        perpendicularLines.Add(New LineContour())
        perpendicularLines.Add(New LineContour())
        ' Find the two edge lines.
        Dim tempLine As LineContour = Algorithms.FindPerpendicularLine(report.SearchLines(0).Line, closestFirstEdge)
        perpendicularLines(0).Start = DirectCast((tempLine.[End].Clone()), PointContour)
        tempLine = Algorithms.FindPerpendicularLine(report.SearchLines(0).Line, closestLastEdge)
        perpendicularLines(1).Start = DirectCast((tempLine.[End].Clone()), PointContour)
        tempLine = Algorithms.FindPerpendicularLine(report.SearchLines(report.SearchLines.Count - 1).Line, closestFirstEdge)
        perpendicularLines(0).[End] = DirectCast((tempLine.[End].Clone()), PointContour)
        tempLine = Algorithms.FindPerpendicularLine(report.SearchLines(report.SearchLines.Count - 1).Line, closestLastEdge)
        perpendicularLines(1).[End] = DirectCast((tempLine.[End].Clone()), PointContour)

        ' Compute the distance between them.
        Dim distance As Double = Algorithms.FindPointDistances(New Collection(Of PointContour)(New PointContour() {perpendicularLines(0).Start, perpendicularLines(1).Start}))(0)
        Return distance
    End Function

    Private Function DistanceSquared(ByVal pt1 As PointContour, ByVal pt2 As PointContour) As Double
        Return (pt1.X - pt2.X) * (pt1.X - pt2.X) + (pt1.Y - pt2.Y) * (pt1.Y - pt2.Y)
    End Function

    ' Overlay an arrowhead at the end of a line segment.
    Private Sub DrawArrow(ByVal overlay As Overlay, ByVal line As LineContour, ByVal color As Rgb32Value)
        ' This code computes the position of the arrow.
        Dim dX As Double = line.[End].X - line.Start.X
        Dim dY As Double = line.[End].Y - line.Start.Y

        Dim lineAngle As Double = Math.Atan2(dY, dX)

        ' The arrow has 3 points.
        Dim arrowPoints As New Collection(Of PointContour)()
        arrowPoints.Add(line.[End])
        arrowPoints.Add(New PointContour(line.[End].X - 6 * Math.Cos(lineAngle - 0.35), line.[End].Y - 6 * Math.Sin(lineAngle - 0.35)))
        arrowPoints.Add(New PointContour(line.[End].X - 6 * Math.Cos(lineAngle + 0.35), line.[End].Y - 6 * Math.Sin(lineAngle + 0.35)))
        overlay.AddPolygon(New PolygonContour(arrowPoints), color, DrawingMode.PaintValue)
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage()
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Image" & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 16 Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

End Class


Public Structure DrawOptions
    Private _showEdgesFound As Boolean
    Private _showSearchArea As Boolean
    Private _showSearchLines As Boolean
    Private _showResult As Boolean

    Public Property ShowResult() As Boolean
        Get
            Return _showResult
        End Get
        Set(ByVal value As Boolean)
            _showResult = value
        End Set
    End Property

    Public Property ShowSearchLines() As Boolean
        Get
            Return _showSearchLines
        End Get
        Set(ByVal value As Boolean)
            _showSearchLines = value
        End Set
    End Property

    Public Property ShowSearchArea() As Boolean
        Get
            Return _showSearchArea
        End Get
        Set(ByVal value As Boolean)
            _showSearchArea = value
        End Set
    End Property

    Public Property ShowEdgesFound() As Boolean
        Get
            Return _showEdgesFound
        End Get
        Set(ByVal value As Boolean)
            _showEdgesFound = value
        End Set
    End Property
End Structure