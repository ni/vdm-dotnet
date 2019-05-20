Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports System.Collections.ObjectModel

' Label Example
'
' This example shows how to label a binary image that contains multiple particles.
' The labeling proecssing assigns a unique value to all pixels that belong to a particle.
' Some processing functions in NI Vision require the input binary image to be labeled.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private form2 As Form2 = Nothing
    Public Sub New()
        InitializeComponent()
        form2 = New Form2()
        form2.Show()
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub SimpleRangeSelect1_RangeChanged(ByVal sender As System.Object, ByVal e As NationalInstruments.Vision.MeasurementStudioDemo.RangeChangedEventArgs) Handles SimpleRangeSelect1.RangeChanged
        ProcessImage()
    End Sub

    Public Sub ProcessImage()
        ' If the other form hasn't been initialized yet, do nothing.
        If form2 Is Nothing Then
            Return
        End If
        Dim beforeImage As VisionImage = form2.BeforeImage
        Dim afterImage As VisionImage = form2.AfterImage

        ' If an image is loaded
        If beforeImage.Width > 0 AndAlso beforeImage.Height > 0 Then
            ' Threshold the image.
            Algorithms.Threshold(beforeImage, afterImage, New Range(SimpleRangeSelect1.Minimum, SimpleRangeSelect1.Maximum))

            ' Label the image.
            Dim numParticles As Integer = Algorithms.Label(afterImage, afterImage, IIf(connectivity4Button.Checked, Connectivity.Connectivity4, Connectivity.Connectivity8))
            numberOfParticles.Text = numParticles.ToString()
        End If
    End Sub

    ' If any inputs have changed, update the image
    Private Sub connectivity8Button_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles connectivity8Button.CheckedChanged
        ProcessImage()
    End Sub

    Private Sub connectivity4Button_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles connectivity4Button.CheckedChanged
        ProcessImage()
    End Sub

    ' Click the Browse button to open the file dialog
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName

            ' Load the image
            LoadSelectedImage()
        End If
    End Sub

    ' Click the Load Image button to read an image
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        ' Load an image using ReadFile
        form2.BeforeImage.ReadFile(imagePath.Text)

        ' Histogram the image
        Dim report As HistogramReport = Algorithms.Histogram(form2.BeforeImage)
        Dim histogram As Integer() = New Integer(255) {}
        report.Histogram.CopyTo(histogram, 0)
        ' Convert the int[] to a double[], which the graph requires.
        Dim histogramDouble As Double() = Array.ConvertAll(Of Integer, Double)(histogram, AddressOf IntegerToDouble)
        SimpleRangeSelect1.PlotY(histogramDouble)

        ' Process the image
        ProcessImage()
    End Sub
    Private Function IntegerToDouble(ByVal i As Integer) As Double
        Return i
    End Function

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

End Class