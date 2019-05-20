Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Edge Detection Example

' This example demonstrates how to use Algorithms.EdgeTool() to find edges (or sharp
' transitions in the pixel values) along a given line or ROI profile.  Algorithms.EdgeTool()
' is a precursor function to many gauging and inspection tasks. For example, in a gauging
' application, the location of the edges found in a line profile might indicate the boundaries of
' an object whose dimensions have to be measured. In an inspection application, the location of
' the edges might indicate a crack in the object's surface.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        polarity.SelectedIndex = 0
        interpolationMethod.SelectedIndex = 2
        smoothing.SelectedIndex = 0
        process.SelectedIndex = 2
        imageViewer1.Roi.MaximumContours = 1
        imageViewer1.Roi.Color = Rgb32Value.YellowColor
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
        End If
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)

        ' If regions are on the viewer, remove them.
        imageViewer1.Roi.Clear()
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 AndAlso imageViewer1.Roi(0).Type = ContourType.Line Then
            ' Fill in the edge options structure from the controls on the form.
            Dim options As New EdgeOptions()
            options.ColumnProcessingMode = DirectCast([Enum].Parse(GetType(ColumnProcessingMode), DirectCast(smoothing.SelectedItem, String)), ColumnProcessingMode)
            options.InterpolationType = DirectCast([Enum].Parse(GetType(InterpolationMethod), DirectCast(interpolationMethod.SelectedItem, String)), InterpolationMethod)
            options.KernelSize = CUInt(kernelSize.Value)
            options.MinimumThreshold = CUInt(minimumThreshold.Value)
            options.Polarity = DirectCast([Enum].Parse(GetType(EdgePolaritySearchMode), DirectCast(polarity.SelectedItem, String)), EdgePolaritySearchMode)
            options.Width = CUInt(width.Value)

            ' Run the edge detection
            Dim report As EdgeReport = Algorithms.EdgeTool(imageViewer1.Image, imageViewer1.Roi, DirectCast([Enum].Parse(GetType(EdgeProcess), DirectCast(process.SelectedItem, String)), EdgeProcess), options)

            ' Overlay the edge positions
            imageViewer1.Image.Overlays.[Default].Clear()
            For Each edge As EdgeInfo In report.Edges
                imageViewer1.Image.Overlays.[Default].AddOval(New OvalContour(edge.Position.X - 2, edge.Position.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)
            Next

            ' Graph the line profile and gradient of the line.
            Dim lineProfile As LineProfileReport = Algorithms.LineProfile(imageViewer1.Image, imageViewer1.Roi)
            Dim profileData As Double() = New Double(lineProfile.ProfileData.Count - 1) {}
            lineProfile.ProfileData.CopyTo(profileData, 0)

            Dim gradientData As Double() = New Double(report.GradientInfo.Count - 1) {}
            report.GradientInfo.CopyTo(gradientData, 0)
            EdgeDetectionGraph1.PlotData(profileData, gradientData)
        End If
    End Sub
End Class