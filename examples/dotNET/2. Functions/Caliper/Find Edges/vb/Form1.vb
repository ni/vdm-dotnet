Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Find Edges Example

' This example demonstrates how to use Algorithms.FindEdges() to find straight edges in
' a given ROI.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        polarity.SelectedIndex = 0
        interpolationMethod.SelectedIndex = 2
        smoothing.SelectedIndex = 0
        searchMode.SelectedIndex = 4
        searchDirection.SelectedIndex = 0
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Clamp.png")
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        FindEdges()
    End Sub

    Private Sub FindEdges()
        If imageViewer1.Roi.Count > 0 Then
            ' Use search direction selected.
            Dim direction As RakeDirection = DirectCast([Enum].Parse(GetType(RakeDirection), DirectCast(SearchDirection.SelectedItem, String)), RakeDirection)

            ' Fill in the edge options structure from the controls on the form.
            Dim edgeOptions As New EdgeOptions()
            edgeOptions.ColumnProcessingMode = DirectCast([Enum].Parse(GetType(ColumnProcessingMode), DirectCast(smoothing.SelectedItem, String)), ColumnProcessingMode)
            edgeOptions.InterpolationType = DirectCast([Enum].Parse(GetType(InterpolationMethod), DirectCast(InterpolationMethod.SelectedItem, String)), InterpolationMethod)
            edgeOptions.KernelSize = CUInt(kernelSize.Value)
            edgeOptions.MinimumThreshold = CUInt(minimumThreshold.Value)
            edgeOptions.Polarity = DirectCast([Enum].Parse(GetType(EdgePolaritySearchMode), DirectCast(polarity.SelectedItem, String)), EdgePolaritySearchMode)
            edgeOptions.Width = CUInt(Width.Value)

            ' Fill in the straight edge options structure from the controls on the form.
            Dim straightEdgeOptions As New StraightEdgeOptions()
            straightEdgeOptions.AngleRange = CDbl(angleRange.Value)
            straightEdgeOptions.AngleTolerance = CDbl(angleTolerance.Value)
            straightEdgeOptions.HoughIterations = CUInt(houghIterations.Value)
            straightEdgeOptions.ScoreRange.Initialize(CDbl(minimumScore.Value), CDbl(maximumScore.Value))
            straightEdgeOptions.MinimumCoverage = CDbl(minimumCoverage.Value)
            straightEdgeOptions.MinimumSignalToNoiseRatio = CDbl(minimumSignalToNoiseRatio.Value)
            straightEdgeOptions.NumberOfLines = CUInt(numberOfLines.Value)
            straightEdgeOptions.Orientation = CDbl(Orientation.Value)
            straightEdgeOptions.SearchMode = DirectCast([Enum].Parse(GetType(StraightEdgeSearchMode), DirectCast(searchMode.SelectedItem, String)), StraightEdgeSearchMode)
            straightEdgeOptions.StepSize = CUInt(stepSize.Value)

            Dim options As New FindEdgeOptions(direction, True, True, True, True)
            options.EdgeOptions = edgeOptions
            options.StraightEdgeOptions = straightEdgeOptions

            ' Clear all overlays from previous run.
            imageViewer1.Image.Overlays.[Default].Clear()

            ' Run the edge detection.
            Dim report As FindEdgeReport = Algorithms.FindEdge(imageViewer1.Image, imageViewer1.Roi, options)
        End If
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadSelectedImage()
        End If
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)

        ' If regions are on the viewer, remove them.
        imageViewer1.Roi.Clear()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class