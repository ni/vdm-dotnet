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

' BCG Transform Example
'
' This example demonstrates how to apply a brightness, contrast, and gamma correction to an
' image.  These transformations are usually applied to an image to improve its quality as
' required by a particular application.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
        LoadImage()
    End Sub

    Private Sub PerformBcg()
        ' Make sure the image has been loaded.
        If imageViewer1.Image.Width > 0 Then
            ' Set up the options.
            Dim bcgOptions As New BcgOptions(brightnessSlide.Value, contrastSlide.Value, gammaSlide.Value)

            ' Perform the BCG transform using the parameters set by the user.
            Algorithms.BcgTransform(imageViewer1.Image, imageViewer2.Image, bcgOptions)
        End If
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadImage()
    End Sub

    Private Sub LoadImage()
        ' Read and display a file and perform the BcgTransform.
        imageViewer1.Image.ReadFile(imagePath.Text)
        PerformBcg()
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadImage()
        End If
    End Sub

    ' The following four functions keep the two image viewers in sync.
    Private Sub imageViewer1_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs) Handles imageViewer1.ImagePanned
        If Not imageViewer2.Center.Equals(imageViewer1.Center) Then
            imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs) Handles imageViewer2.ImagePanned
        If Not imageViewer1.Center.Equals(imageViewer2.Center) Then
            imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y)
        End If
    End Sub

    Private Sub imageViewer1_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs) Handles imageViewer1.ImageZoomed
        If Not imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo) Then
            imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs) Handles imageViewer2.ImageZoomed

        If Not imageViewer1.ZoomInfo.Equals(imageViewer2.ZoomInfo) Then
            imageViewer1.ZoomInfo.Initialize(imageViewer2.ZoomInfo.X, imageViewer2.ZoomInfo.Y)
        End If
    End Sub
    Private Sub brightnessSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brightnessSlide.ValueChanged
        If brightnessUpDown.Value <> CDec(brightnessSlide.Value) Then
            brightnessUpDown.Value = CDec(brightnessSlide.Value)
        End If
        PerformBcg()
    End Sub

    Private Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resetButton.Click
        brightnessSlide.Value = 171
        contrastSlide.Value = 56
        gammaSlide.Value = 2
    End Sub

    Private Sub brightnessUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles brightnessUpDown.ValueChanged
        If CDec(brightnessSlide.Value) <> brightnessUpDown.Value Then
            brightnessSlide.Value = CDbl(brightnessUpDown.Value)
        End If
    End Sub

    Private Sub contrastSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles contrastSlide.ValueChanged
        If contrastUpDown.Value <> CDec(contrastSlide.Value) Then
            contrastUpDown.Value = CDec(contrastSlide.Value)
        End If
        PerformBcg()
    End Sub

    Private Sub contrastUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles contrastUpDown.ValueChanged
        If CDec(contrastSlide.Value) <> contrastUpDown.Value Then
            contrastSlide.Value = CDbl(contrastUpDown.Value)
        End If
    End Sub

    Private Sub gammaSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gammaSlide.ValueChanged
        If gammaUpDown.Value <> CDec(gammaSlide.Value) Then
            gammaUpDown.Value = CDec(gammaSlide.Value)
        End If
        PerformBcg()
    End Sub

    Private Sub gammaUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles gammaUpDown.ValueChanged
        If CDec(gammaSlide.Value) <> gammaUpDown.Value Then
            gammaSlide.Value = CDbl(gammaUpDown.Value)
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class