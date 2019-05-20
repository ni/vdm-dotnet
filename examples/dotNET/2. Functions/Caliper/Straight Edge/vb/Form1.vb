Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports NationalInstruments.Vision.WindowsForms

' Find Straight Edges Example
'
' This example demonstrates how to use Algorithms.StraightEdge to find straight edges
' in a given ROI.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Set the path to the default image.
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Clamp.png")

        imageViewer1.ToolsShown = ViewerTools.Pan Or ViewerTools.Rectangle Or ViewerTools.RotatedRectangle Or ViewerTools.Selection Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut

        ' Initialize combo boxes.
        polarity.SelectedIndex = 0
        interpolationMethod.SelectedIndex = 2
        smoothing.SelectedIndex = 0
        searchMode.SelectedIndex = 4
        searchDirection.SelectedIndex = 0
    End Sub

    Private Sub FindStraightEdges()
        ' Use search direction selected.
        Dim direction As SearchDirection = DirectCast([Enum].Parse(GetType(SearchDirection), DirectCast(searchDirection.SelectedItem, String)), SearchDirection)

        ' Fill in the edge options structure from the controls on the form.
        Dim edgeOptions As New EdgeOptions()
        edgeOptions.ColumnProcessingMode = DirectCast([Enum].Parse(GetType(ColumnProcessingMode), DirectCast(smoothing.SelectedItem, String)), ColumnProcessingMode)
        edgeOptions.InterpolationType = DirectCast([Enum].Parse(GetType(InterpolationMethod), DirectCast(interpolationMethod.SelectedItem, String)), InterpolationMethod)
        edgeOptions.KernelSize = CUInt(kernelSize.Value)
        edgeOptions.MinimumThreshold = CUInt(minimumThreshold.Value)
        edgeOptions.Polarity = DirectCast([Enum].Parse(GetType(EdgePolaritySearchMode), DirectCast(polarity.SelectedItem, String)), EdgePolaritySearchMode)
        edgeOptions.Width = CUInt(width.Value)

        ' Fill in the straight edge options structure from the controls on the form.
        Dim straightEdgeOptions As New StraightEdgeOptions()
        straightEdgeOptions.AngleRange = CDbl(angleRange.Value)
        straightEdgeOptions.AngleTolerance = CDbl(angleTolerance.Value)
        straightEdgeOptions.HoughIterations = CUInt(houghIterations.Value)
        straightEdgeOptions.ScoreRange.Initialize(CDbl(minimumScore.Value), CDbl(maximumScore.Value))
        straightEdgeOptions.MinimumCoverage = CDbl(minimumCoverage.Value)
        straightEdgeOptions.MinimumSignalToNoiseRatio = CDbl(minimumSignalToNoiseRatio.Value)
        straightEdgeOptions.NumberOfLines = CUInt(numberOfLines.Value)
        straightEdgeOptions.Orientation = CDbl(orientation.Value)
        straightEdgeOptions.SearchMode = DirectCast([Enum].Parse(GetType(StraightEdgeSearchMode), DirectCast(searchMode.SelectedItem, String)), StraightEdgeSearchMode)
        straightEdgeOptions.StepSize = CUInt(stepSize.Value)

        ' Run the edge detection.
        Dim report As StraightEdgeReport = Algorithms.StraightEdge(imageViewer1.Image, imageViewer1.Roi, direction, edgeOptions, straightEdgeOptions)

        ' Clear all overlays from previous run.
        imageViewer1.Image.Overlays.[Default].Clear()

        ' Overlay the straight edges.
        For Each item As StraightEdgeReportItem In report.StraightEdges
            imageViewer1.Image.Overlays.[Default].AddLine(item.StraightEdge, Rgb32Value.RedColor)
        Next

        ' Overlay the search lines.
        For Each info As SearchLineInfo In report.SearchLines
            ' First the line itself.
            imageViewer1.Image.Overlays.[Default].AddLine(info.Line, Rgb32Value.BlueColor)
            ' Then the found edges on each line.
            For Each edgeInfo As EdgeInfo In info.EdgeReport.Edges
                imageViewer1.Image.Overlays.[Default].AddOval(New OvalContour(edgeInfo.Position.X - 1, edgeInfo.Position.Y - 1, 3, 3), Rgb32Value.YellowColor, DrawingMode.PaintValue)
            Next
        Next

    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 Then
            FindStraightEdges()
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

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadSelectedImage()
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class