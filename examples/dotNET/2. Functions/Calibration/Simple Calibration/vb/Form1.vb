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

' Simple Calibration Example
'
' This example demonstrates how to build a local coordinate system based on the information
' returned by an X-Y-Theta positioning system using the Algorithms.SetSimpleCalibration() method.
' It then finds the template location in the image and transforms the coordinates from the image
' coordinate system to the local system using the Algorithms.ConvertPixelToRealWorldCoordinates() method.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private template As New VisionImage()
    Private stageMotionInformation As New Collection(Of CoordinateSystem)()
    Private Const maxImageNumber As Integer = 11
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Get the image path
        imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Roundcard\")

        ' Load the pattern matching template.
        template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"))

        ' Initialize the coordinate system data.
        InitializeStageMotionInformation()

        ' Enable the timer.
        timer1.Enabled = True
        timer1.Start()
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the current coordinate system.
        Dim coordinateSystem As CoordinateSystem = stageMotionInformation(imageNumber)

        ' Display the current coordinate system.
        calibrationOriginPixelX.Text = [String].Format("{0:0.0}", coordinateSystem.Origin.X)
        calibrationOriginPixelY.Text = [String].Format("{0:0.0}", coordinateSystem.Origin.Y)
        calibrationAngle.Text = [String].Format("{0:0.0}", coordinateSystem.Angle)
        calibrationAxisReference.Text = IIf((coordinateSystem.AxisOrientation = AxisOrientation.Direct), "Direct", "Indirect")

        ' Get the next image in the sequence.
        Dim image As VisionImage = GetNextImage()

        ' Set the local coordinate system information using simple calibration.
        Algorithms.SetSimpleCalibration(image, coordinateSystem, New GridDescriptor())

        ' Find the location of the fiducial in the image.
        Dim matchOptions As New MatchPatternOptions(MatchMode.RotationInvariant)
        matchOptions.MinimumMatchScore = 600
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchPattern(image, template, matchOptions)

        ' Convert the match position to real-world coordinates.
        Dim realWorldPoint As PointContour = Algorithms.ConvertPixelToRealWorldCoordinates(image, matches(0).Position).Points(0)

        ' Display the coordinates of the pattern.
        measurementsPixelX.Text = [String].Format("{0:0.0}", matches(0).Position.X)
        measurementsPixelY.Text = [String].Format("{0:0.0}", matches(0).Position.Y)
        measurementsCalibratedX.Text = [String].Format("{0:0.0}", realWorldPoint.X)
        measurementsCalibratedY.Text = [String].Format("{0:0.0}", realWorldPoint.Y)

        ' Overlay the position of the pattern match.
        ' First draw the bounding box.
        image.Overlays.[Default].AddPolygon(New PolygonContour(matches(0).Corners), Rgb32Value.RedColor)
        ' Now draw the center point.
        image.Overlays.[Default].AddOval(New OvalContour(matches(0).Position.X - 5, matches(0).Position.Y - 5, 11, 11), Rgb32Value.RedColor)
        ' Finally draw the crosshair.
        image.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X - 10, matches(0).Position.Y), New PointContour(matches(0).Position.X + 10, matches(0).Position.Y)), Rgb32Value.RedColor)
        image.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X, matches(0).Position.Y - 10), New PointContour(matches(0).Position.X, matches(0).Position.Y + 10)), Rgb32Value.RedColor)

        ' Overlay the coordinate system on the image.
        OverlayCoordinateSystem(image.Overlays.[Default], coordinateSystem)

        ' Display the image.
        imageViewer1.Attach(image)
    End Sub

    Private Sub OverlayCoordinateSystem(ByVal overlay As Overlay, ByVal system As CoordinateSystem)
        Const axisLength As Integer = 150

        ' Overlay the origin point.
        overlay.AddRectangle(New RectangleContour(system.Origin.X - 2, system.Origin.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)

        ' Draw the main axis line.
        Dim theta As Double = system.Angle * Math.PI / 180.0R
        Dim axisEnd As New PointContour(system.Origin.X + axisLength * Math.Cos(theta), system.Origin.Y - axisLength * Math.Sin(theta))
        Dim axisLine As New LineContour(system.Origin, axisEnd)
        overlay.AddLine(axisLine, Rgb32Value.RedColor)
        ' Draw an arrow on the end of the line.
        DrawArrow(overlay, axisLine, Rgb32Value.RedColor)

        ' Overlay the main axis legend.
        overlay.AddText("X", New PointContour(axisLine.[End].X - 10, axisLine.[End].Y - 10), Rgb32Value.RedColor, New OverlayTextOptions("Arial", 16))

        ' Overlay the secondary axis line.
        If system.AxisOrientation = AxisOrientation.Indirect Then
            theta += Math.PI
        End If
        axisLine.[End].Initialize(system.Origin.X - axisLength * Math.Sin(theta), system.Origin.Y - axisLength * Math.Cos(theta))
        overlay.AddLine(axisLine, Rgb32Value.RedColor)
        ' Draw an arrow on the end of the line.
        DrawArrow(overlay, axisLine, Rgb32Value.RedColor)

        ' Overlay the secondary axis legend.
        overlay.AddText("Y", New PointContour(axisLine.[End].X - 10, axisLine.[End].Y - 10), Rgb32Value.RedColor, New OverlayTextOptions("Arial", 16))
    End Sub

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
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Roundcard " & [String].Format("{0:00}", imageNumber + 1) & ".tif"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any calibration information or overlays.
            toReturn.RemoveVisionInfo(InfoTypes.Calibration Or InfoTypes.Overlay)
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber >= maxImageNumber Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub InitializeStageMotionInformation()
        ' Load information about how the rotate.  This information is used to calculate
        ' the real-world position of the fiducial.
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(341, 246), 180))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(342, 279), 174))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(343, 312), 186))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(344, 344), 200))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(394, 244), 190))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(395, 278), 170))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(396, 310), 185))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(450, 343), 170))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(448, 242), 179))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(449, 275), 220))
        stageMotionInformation.Add(New CoordinateSystem(New PointContour(450, 310), 179.5))
    End Sub

    Private Sub DelaySlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlide.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlide.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

End Class