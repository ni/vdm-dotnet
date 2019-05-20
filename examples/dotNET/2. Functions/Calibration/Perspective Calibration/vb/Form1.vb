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

' Perspective Calibration Example
'
' This example illustrates how to use a calibration grid to calibrate an image for perspective
' distortion.  The example converts the locations of features found in the image into real-world
' locations.  It uses these locations to perform accurate measurements in real-world units.
'
' The example loads a template image of a grid that is used to calibrate a system, learns the
' calibration from that grid, and measures distances in a distorted image with the learned
' calibration information.

Partial Public Class Form1
    Inherits Form
    Private calibrationTemplate As New VisionImage()
    Private testImage As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub loadCalibrationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadCalibrationButton.Click
        ' Load the calibration grid image.
        calibrationTemplate.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Calibration grid.tif"))
        imageViewer1.Attach(calibrationTemplate)

        ' Update command buttons.
        learnCalibrationButton.Enabled = True
        measureDistancesButton.Enabled = False
    End Sub

    Private Sub learnCalibrationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles learnCalibrationButton.Click
        ' Set up the grid options.
        Dim gridOptions As New CalibrationGridOptions(New GridDescriptor(0.5, 0.5), New Range(0, 128))

        ' Setup the learn calibration options.
        Dim learnOptions As New LearnCalibrationOptions(New CoordinateSystem(), CalibrationMethod.Perspective, ScalingMethod.ScaleToFit, CalibrationCorrectionMode.FullImage)
        learnOptions.LearnCorrectionTable = False
        learnOptions.LearnErrorMap = False

        ' Learn the calibration from the grid image.
        Algorithms.LearnCalibrationGrid(imageViewer1.Image, gridOptions, learnOptions)

        ' Update command buttons.
        learnCalibrationButton.Enabled = False
        measureDistancesButton.Enabled = True
    End Sub

    Private Enum Direction
        Horizontal
        Vertical
    End Enum

    Private Sub measureDistancesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles measureDistancesButton.Click
        ' In a point-based measurement, it is not necessary to correct the image.  The
        ' coordinates of the fiducial points can be found and transformed to real-world
        ' coordinates.  All point measurements can then be performed on these
        ' coordinates.

        ' Load the Distortion Target image.
        testImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Distortion target.tif"))

        ' Copy the calibration information from the calibrated image to the test image.
        Algorithms.CopyCalibrationInformation(calibrationTemplate, testImage)

        ' Initialize the two search lines.
        Dim searchLines As New Collection(Of LineContour)()
        searchLines.Add(New LineContour(New PointContour(150, 250), New PointContour(490, 248.57)))
        searchLines.Add(New LineContour(New PointContour(318, 165), New PointContour(319.62, 340)))

        For Each d As Direction In New Direction() {Direction.Horizontal, Direction.Vertical}
            ' Detect the edges along a line and convert the coordinates of the edge points
            ' to real-world coordinates.
            Dim report As EdgeReport = Algorithms.EdgeTool(testImage, New Roi(New Shape() {searchLines(IIf(d = Direction.Horizontal, 0, 1))}), EdgeProcess.All)
            Dim pixelPoints As New Collection(Of PointContour)()
            Dim realWorldPoints As New Collection(Of PointContour)()
            For Each info As EdgeInfo In report.Edges
                pixelPoints.Add(info.Position)
                realWorldPoints.Add(info.CalibratedPosition)
            Next
            Dim realWorldPoints2 As Collection(Of PointContour) = Algorithms.ConvertPixelToRealWorldCoordinates(testImage, pixelPoints).Points
            MeasureDistortionTarget(testImage, pixelPoints, realWorldPoints, d)
        Next

        imageViewer1.Attach(testImage)
    End Sub

    Private Sub MeasureDistortionTarget(ByVal image As VisionImage, ByVal pixelPoints As Collection(Of PointContour), ByVal realWorldPoints As Collection(Of PointContour), ByVal d As Direction)
        Dim overlayOptions As New OverlayTextOptions("Arial", 16)
        overlayOptions.TextDecoration.Bold = True
        If d = Direction.Horizontal Then
            overlayOptions.HorizontalAlignment = HorizontalTextAlignment.Right
            overlayOptions.VerticalAlignment = VerticalTextAlignment.Baseline
        Else
            overlayOptions.HorizontalAlignment = HorizontalTextAlignment.Center
            overlayOptions.VerticalAlignment = VerticalTextAlignment.Bottom
        End If
        For i As Integer = 0 To 2
            ' Measure the real-world distance.
            Dim realWorldDistancePoints As New Collection(Of PointContour)()
            realWorldDistancePoints.Add(realWorldPoints(2 * i))
            realWorldDistancePoints.Add(realWorldPoints(9 - 2 * i))
            Dim realWorldDistance As Double = Algorithms.FindPointDistances(realWorldDistancePoints)(0)

            ' Find the line to overlay.
            Dim line As New LineContour()
            line.Start = pixelPoints(2 * i)
            line.[End] = pixelPoints(9 - 2 * i)

            If d = Direction.Horizontal Then
                ' Measurement is horizontal, so arrows stack vertically.
                line.Start.Y += (2 - i) * 30
                line.[End].Y += (2 - i) * 30
            Else
                ' Measurement is vertical, so arrows stack horizontally.
                line.Start.X += (2 - i) * 30
                line.[End].X += (2 - i) * 30
            End If

            ' Draw the line with arrows.
            image.Overlays.[Default].AddLine(line, Rgb32Value.RedColor)
            DrawArrow(image.Overlays.[Default], line, Rgb32Value.RedColor)
            ' Flip the start and end to draw an arrow at the beginning.
            Dim tempStart As PointContour = line.Start
            line.Start = line.[End]
            line.[End] = tempStart
            DrawArrow(image.Overlays.[Default], line, Rgb32Value.RedColor)

            ' Find the origin of the text to overlay.
            image.Overlays.[Default].AddText([String].Format("{0:0.00}", realWorldDistance), tempStart, Rgb32Value.RedColor, overlayOptions)
        Next
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

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class