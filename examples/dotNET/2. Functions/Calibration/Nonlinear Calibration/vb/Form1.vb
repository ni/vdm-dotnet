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

' Nonlinear Calibration Example
'
' This example illustrates how to use a calibration grid to calibrate an image for nonlinear
' distortion.  The example corrects the image, making it possible to perform accurate measurements
' in real-world units on the resulting image.
'
' The example loads a template image of a grid used to calibrate a system.  It uses the loaded
' image to learn the grid calibration, uses the learned calibration information to correct
' the distorted image, and measures distances in the corrected image.

Partial Public Class Form1
    Inherits Form
    Private calibrationTemplate As New VisionImage()
    Private partImage As New VisionImage()
    Private processedPartImage As New VisionImage()
    Private uncorrectedImage As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub loadCalibrationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadCalibrationButton.Click
        ' Load Calibration Grid image.
        calibrationTemplate.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Nonlinear grid.png"))
        imageViewer1.Attach(calibrationTemplate)

        ' Update command buttons.
        learnCalibrationButton.Enabled = True
        loadTargetButton.Enabled = False
        measurePartsButton.Enabled = False
    End Sub

    Private Sub learnCalibrationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles learnCalibrationButton.Click
        Dim learnCalibrationText As String = learnCalibrationButton.Text
        learnCalibrationButton.Text = "Learning..."
        Update()

        ' Set up the calibration grid options.
        ' Dots in the grid image are horizontally and vertically 6.35 mm apart.
        ' The dots have a pixel intensity in the range [0, 128].
        Dim calibrationGridOptions As New CalibrationGridOptions(New GridDescriptor(0.635, 0.635, CalibrationUnit.Centimeter), New Range(0, 128))

        ' Set up the calibration options.
        Dim learnCalibrationOptions As New LearnCalibrationOptions(New CoordinateSystem(), CalibrationMethod.Nonlinear, ScalingMethod.ScaleToPreserveArea, CalibrationCorrectionMode.FullImage)
        learnCalibrationOptions.LearnCorrectionTable = True
        learnCalibrationOptions.LearnErrorMap = True

        ' Learn the Grid Image calibration.
        Algorithms.LearnCalibrationGrid(calibrationTemplate, calibrationGridOptions, learnCalibrationOptions)

        ' Restore the original description.
        learnCalibrationButton.Text = learnCalibrationText

        ' Update the command buttons.
        learnCalibrationButton.Enabled = False
        loadTargetButton.Enabled = True
    End Sub

    Private Sub loadTargetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadTargetButton.Click
        ' Load Calibration Grid image.
        uncorrectedImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Distorted coins.png"))
        imageViewer1.Attach(uncorrectedImage)

        measurePartsButton.Enabled = True
    End Sub

    Private Sub measurePartsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles measurePartsButton.Click
        ' Start timing.
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()

        ' Apply the calibration to the parts image and correct it.
        Algorithms.CopyCalibrationInformation(calibrationTemplate, uncorrectedImage)
        Algorithms.CorrectCalibratedImage(uncorrectedImage, partImage, New PixelValue(0), InterpolationMethod.Bilinear)

        ' Process the image to segment the parts from the background.
        Algorithms.Threshold(partImage, processedPartImage, New Range(0, 150))
        Algorithms.RejectBorder(processedPartImage, processedPartImage)
        Algorithms.FillHoles(processedPartImage, processedPartImage)
        Algorithms.ConvexHull(processedPartImage, processedPartImage)

        ' Perform particle analysis.
        Dim particleReports As Collection(Of ParticleReport) = Algorithms.ParticleReport(processedPartImage, Connectivity.Connectivity8, False)
        Dim areas As Double(,) = Algorithms.ParticleMeasurements(processedPartImage, New Collection(Of MeasurementType)(New MeasurementType() {MeasurementType.Area}), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Calibrated).CalibratedMeasurements
        ' Stop timing and overlay results.
        stopwatch.[Stop]()

        Dim overlayOptions As New OverlayTextOptions("Arial", 18, HorizontalTextAlignment.Center)
        overlayOptions.TextDecoration.Bold = True
        overlayOptions.VerticalAlignment = VerticalTextAlignment.Baseline
        For i As Integer = 0 To particleReports.Count - 1
            partImage.Overlays.[Default].AddText([String].Format("{0:0.00} cm^2", areas(i, 0)), particleReports(i).CenterOfMass, Rgb32Value.GreenColor, overlayOptions)
        Next
        wholeImageTime.Text = [String].Format("{0:0}", stopwatch.ElapsedMilliseconds)
        imageViewer1.Attach(partImage)
        imageViewer2.Attach(uncorrectedImage)

        stopwatch.Reset()
        ' Start timing.
        stopwatch.Start()

        ' Apply the calibration to the parts image.
        Algorithms.CopyCalibrationInformation(calibrationTemplate, uncorrectedImage)

        ' Process the image to segment the parts from the background.
        Algorithms.Threshold(uncorrectedImage, processedPartImage, New Range(0, 150))
        Algorithms.RejectBorder(processedPartImage, processedPartImage)
        Algorithms.FillHoles(processedPartImage, processedPartImage)
        Algorithms.ConvexHull(processedPartImage, processedPartImage)

        ' Perform particle analysis.
        particleReports = Algorithms.ParticleReport(processedPartImage, Connectivity.Connectivity8, False)
        areas = Algorithms.ParticleMeasurements(processedPartImage, New Collection(Of MeasurementType)(New MeasurementType() {MeasurementType.Area}), Connectivity.Connectivity8, ParticleMeasurementsCalibrationMode.Calibrated).CalibratedMeasurements

        ' Stop timing and overlay results.
        stopwatch.[Stop]()

        For i As Integer = 0 To particleReports.Count - 1
            uncorrectedImage.Overlays.[Default].AddText([String].Format("{0:0.00} cm^2", areas(i, 0)), particleReports(i).CenterOfMass, Rgb32Value.GreenColor, overlayOptions)
        Next
        coinsImageTime.Text = [String].Format("{0:0}", stopwatch.ElapsedMilliseconds)

        ' Update command buttons.
        measurePartsButton.Enabled = False
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class