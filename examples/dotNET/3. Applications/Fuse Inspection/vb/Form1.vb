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
Imports NationalInstruments.Vision.WindowsForms

' Fuse Inspection Example
'
' This example loads a reference image used to define the coordinate system for the
' inspection task.  It then loads two templates containing the defining features of the
' object.  The example loads a new image, finds the new coordinate system by locating the
' edges of the fuse, matches the region of inspection against the template images,
' and returns the results.

Partial Public Class Form1
    Inherits Form
    ' Global variables
    Private imagePath As String
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private primaryAxisRectangle As RotatedRectangleContour
    Private secondaryAxisRectangle As RotatedRectangleContour
    Private findTransformRectsOptions As FindTransformRectsOptions
    Private transform As CoordinateTransform
    Private matchPatternRoi As Roi
    Private matchPatternOptions As MatchPatternOptions
    Private overlayTextOptions As OverlayTextOptions
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Fuse\")
        imageViewer1.Attach(GetNextImage())
    End Sub

    Private Sub defineCoordinateSystemButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles defineCoordinateSystemButton.Click
        ' Initialize search rectangles.
        primaryAxisRectangle = New RotatedRectangleContour(New PointContour(191, 275), 378, 150, 0)
        secondaryAxisRectangle = New RotatedRectangleContour(New PointContour(170, 205), 300, 250, 0)

        ' Initialize the options used for the coordinate transformation detection.
        findTransformRectsOptions = New FindTransformRectsOptions(FindReferenceDirection.BottomToTopIndirect, True, False, False, True)
        findTransformRectsOptions.PrimaryStraightEdgeOptions.SearchMode = StraightEdgeSearchMode.FirstRakeEdges
        findTransformRectsOptions.PrimaryStraightEdgeOptions.AngleRange = 45
        findTransformRectsOptions.PrimaryStraightEdgeOptions.StepSize = 5
        findTransformRectsOptions.SecondaryStraightEdgeOptions.SearchMode = StraightEdgeSearchMode.FirstRakeEdges
        findTransformRectsOptions.SecondaryStraightEdgeOptions.AngleRange = 45
        findTransformRectsOptions.SecondaryStraightEdgeOptions.StepSize = 5

        ' Locate the coordinate system in the reference image.
        Dim transformReport As FindTransformReport = Algorithms.FindTransformRectangles(imageViewer1.Image, New Roi(New Shape() {primaryAxisRectangle}), New Roi(New Shape() {secondaryAxisRectangle}), FindTransformMode.FindReference, New CoordinateTransform(), findTransformRectsOptions)
        transform = transformReport.Transform

        ' Turn on search lines and edges found overlays.
        findTransformRectsOptions.ShowSearchLines = True
        findTransformRectsOptions.ShowEdgesFound = True

        ' Update buttons
        defineCoordinateSystemButton.Enabled = False
        defineTemplatesButton.Enabled = True
    End Sub

    Private Sub defineTemplatesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles defineTemplatesButton.Click
        ' Load templates that represent a good part.  Because the part is not symmetric,
        ' two templates are necessary for representing the two possible aspects of a valid (intact) fuse.
        imageViewer2.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template 1.png"))
        imageViewer3.Image.ReadVisionFile(System.IO.Path.Combine(imagePath, "template 2.png"))

        ' Update buttons
        defineTemplatesButton.Enabled = False
        runButton.Enabled = True
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim curImage As VisionImage = GetNextImage()
        imageNumberLabel.Text = imageNumber.ToString()

        ' Locate the coordinate system in the reference image.
        Dim transformReport As FindTransformReport = Algorithms.FindTransformRectangles(curImage, New Roi(New Shape() {primaryAxisRectangle}), New Roi(New Shape() {secondaryAxisRectangle}), FindTransformMode.UpdateTransform, transform, findTransformRectsOptions)
        ' Transform the Roi with the found transform.
        Dim tempRoi As New Roi(matchPatternRoi)
        Algorithms.TransformRoi(tempRoi, transformReport.Transform)
        Dim searchArea As RectangleContour = DirectCast(tempRoi(0).Shape, RotatedRectangleContour).GetBoundingRectangle()
        ' Overlay the search area.
        curImage.Overlays.[Default].AddRoi(tempRoi)
        ' Try to match the first template.
        Dim found As Boolean = False
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchPattern(curImage, imageViewer2.Image, matchPatternOptions, searchArea)
        If matches.Count > 0 Then
            found = True
            ' Overlay the results.
            ' First draw the bounding box.
            curImage.Overlays.[Default].AddPolygon(New PolygonContour(matches(0).Corners), Rgb32Value.RedColor)
            ' Now draw the center point.
            curImage.Overlays.[Default].AddOval(New OvalContour(matches(0).Position.X - 5, matches(0).Position.Y - 5, 11, 11), Rgb32Value.RedColor, DrawingMode.DrawValue)
            ' Finally draw the crosshair.
            curImage.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X - 10, matches(0).Position.Y), New PointContour(matches(0).Position.X + 10, matches(0).Position.Y)), Rgb32Value.RedColor)
            curImage.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X, matches(0).Position.Y - 10), New PointContour(matches(0).Position.X, matches(0).Position.Y + 10)), Rgb32Value.RedColor)
        Else
            ' Try to match the second template.
            matches = Algorithms.MatchPattern(curImage, imageViewer3.Image, matchPatternOptions, searchArea)
            If matches.Count > 0 Then
                found = True
                ' Overlay the results.
                ' First draw the bounding box.
                curImage.Overlays.[Default].AddPolygon(New PolygonContour(matches(0).Corners), Rgb32Value.RedColor)
                ' Now draw the center point.
                curImage.Overlays.[Default].AddOval(New OvalContour(matches(0).Position.X - 5, matches(0).Position.Y - 5, 11, 11), Rgb32Value.RedColor, DrawingMode.DrawValue)
                ' Finally draw the crosshair.
                curImage.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X - 10, matches(0).Position.Y), New PointContour(matches(0).Position.X + 10, matches(0).Position.Y)), Rgb32Value.RedColor)
                curImage.Overlays.[Default].AddLine(New LineContour(New PointContour(matches(0).Position.X, matches(0).Position.Y - 10), New PointContour(matches(0).Position.X, matches(0).Position.Y + 10)), Rgb32Value.RedColor)
            End If
        End If
        passOrFail.Value = found
        Dim overlayText As String
        Dim overlayColor As Rgb32Value
        If found Then
            overlayColor = Rgb32Value.GreenColor
            overlayText = "PASS"
        Else
            overlayColor = Rgb32Value.RedColor
            overlayText = "FAIL"
        End If
        curImage.Overlays.[Default].AddText(overlayText, New PointContour(380, 395), overlayColor, overlayTextOptions)

        ' Display the resulting image.
        imageViewer1.Attach(curImage)
    End Sub

    Private Sub runButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles runButton.Click
        ' Initialize the pattern matching options.
        matchPatternRoi = New Roi(New Shape() {New RotatedRectangleContour(New PointContour(210, 220), 130, 110, 0)})
        matchPatternOptions = New MatchPatternOptions(MatchMode.RotationInvariant, 1)
        matchPatternOptions.MinimumMatchScore = 650
        matchPatternOptions.RotationAngleRanges.Add(New Range(-40, 40))
        matchPatternOptions.SubpixelAccuracy = True

        ' Initialize text options.
        overlayTextOptions = New OverlayTextOptions("Arial Black", 36)

        ' Update buttons.
        runButton.Enabled = False

        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim nextImage As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            nextImage = New VisionImage()
            nextImage.ReadFile(System.IO.Path.Combine(imagePath, "Fuse " & [String].Format("{0:00}", imageNumber) & ".tif"))
            images.Add(nextImage)
        Else
            nextImage = images(imageNumber)
            ' Clear any overlays
            nextImage.Overlays.[Default].Clear()
        End If

        ' Advance the number number to the next image
        imageNumber += 1
        If imageNumber > 21 Then
            imageNumber = 0
        End If
        Return nextImage
    End Function

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newInterval As Integer = CInt(DelaySlider1.Value)
        timer1.Interval = IIf((newInterval > 0), newInterval, 1)
    End Sub
End Class