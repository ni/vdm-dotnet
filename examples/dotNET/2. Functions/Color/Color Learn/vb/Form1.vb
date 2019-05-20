Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' ColorLearn Example
'
' This example demonstrates how to use color matching operations to learn a color set.
' Color matching compares the colors and the number of colors in a portion of an image to another
' image.  Use this example to better understand how NI Vision learns a color set and how to
' visualize the color spectrum (a result of the learning process).
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Put a default image in the text box.
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Color cubes.jpg")

        ' Set the viewer's image type to RGB
        imageViewer1.Image.Type = ImageType.Rgb32

        ' Initialize combo box
        colorSensitivityBox.SelectedIndex = 0
    End Sub

    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles pictureBox1.Paint
        ' Draw the color spectrum.
        ColorSpectrumHelpers.DrawColorSpectrum(e.Graphics, pictureBox1.ClientRectangle)
    End Sub

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        LoadSelectedImage()
    End Sub

    ' Load an image using ReadFile.
    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.Roi.Clear()
        ' Enable the learn colors button
        learnButton.Enabled = True
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

    Private Sub learnButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles learnButton.Click
        ' Learn the color information.
        Dim colorInformation As ColorInformation = Algorithms.LearnColor(imageViewer1.Image, imageViewer1.Roi, DirectCast(colorSensitivityBox.SelectedIndex, ColorSensitivity), CInt(saturationThreshold.Value))

        ' Plot the color spectrum on the graph.
        ColorSpectrumHelpers.PlotColorSpectrum(pictureBox1, DirectCast(colorSensitivityBox.SelectedIndex, ColorSensitivity), colorInformation.Information)
    End Sub
End Class