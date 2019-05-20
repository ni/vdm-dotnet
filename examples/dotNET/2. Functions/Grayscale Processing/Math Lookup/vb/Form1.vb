Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Math Lookup Example
'
' This example demonstrates how to apply a lookup table to an image.  Lookup table (LUT)
' transformations are basic mathematical functions used to improve the contrast and
' brightness of an image by modifying the intensity dynamics of regions with poor
' contrast.  The LUT can also highlight details in areas containing important information.
' In NI Vision, apart from the predefined functions that can be used through the
' Algorithms.MathLookup() function, you can also apply your own lookup tables using
' the Algorithms.UserLookup() function.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Put a default image in the text box.
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")

        ' Initialize combo box.
        operatorBox.SelectedIndex = 0
    End Sub

    Private Sub ProcessImage()
        ' Perform the math lookup if an image is loaded.
        If imageViewer1.Image.Width > 0 AndAlso imageViewer1.Image.Height > 0 Then
            Algorithms.MathLookup(imageViewer1.Image, imageViewer2.Image, DirectCast(operatorBox.SelectedIndex, MathLookupOperator), CDbl(xValueUpDown.Value))
        End If
    End Sub

    ' Click the Load Image button to read an image.
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        ProcessImage()
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

    Private Sub operatorBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles operatorBox.SelectedIndexChanged
        xValueUpDown.Enabled = operatorBox.SelectedIndex >= 5
        xValueLabel.Enabled = xValueUpDown.Enabled
        ProcessImage()
    End Sub

    Private Sub xValueUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles xValueUpDown.ValueChanged
        ProcessImage()
    End Sub

    ' The following four functions keep the two image viewers in sync
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

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class