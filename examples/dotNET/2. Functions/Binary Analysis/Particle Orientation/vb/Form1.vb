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

' Particle Orientation Example

' This example shows how to use blob analysis to determine the orientation of
' particles or objects in an image.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Put a default image in the text box.
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Angle Test.png")
    End Sub

    Private Sub measureButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles measureButton.Click
        ' Threshold the image.
        Algorithms.Threshold(imageViewer1.Image, imageViewer1.Image)

        ' Change the viewer's palette to Binary to display the image.
        imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary

        ' Compute the basic particle statistics to get the center of mass and orientation.
        Dim reports As Collection(Of ParticleReport) = Algorithms.ParticleReport(imageViewer1.Image)

        Dim textOptions As New OverlayTextOptions()
        textOptions.HorizontalAlignment = HorizontalTextAlignment.Center
        textOptions.VerticalAlignment = VerticalTextAlignment.Baseline
        textOptions.FontSize = 16
        For Each report As ParticleReport In reports
            imageViewer1.Image.Overlays.[Default].AddText([String].Format("Angle = {0:###.#}", report.Orientation), report.CenterOfMass, Rgb32Value.WhiteColor)
        Next
    End Sub

    ' Click the Load Image button to read an image.
    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        LoadSelectedImage()
    End Sub


    ' Load an image using ReadFile.
    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray
    End Sub

    ' Click the Browse button to open the file dialog.
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            ' Load the image.
            LoadSelectedImage()
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class