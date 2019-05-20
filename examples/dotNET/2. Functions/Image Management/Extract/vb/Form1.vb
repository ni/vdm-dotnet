Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Extract Example
'
' This example demonstrates how to extract one region of an image.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
        imageViewer1.Roi.MaximumContours = 1
    End Sub

    Private Sub ProcessImage()
        ' Perform the extract operation if the user loads an image and selects a region of interest.
        If Not (imageViewer1.Image.Width = 0 OrElse imageViewer1.Image.Height = 0) AndAlso imageViewer1.Roi.Count > 0 Then
            Algorithms.Extract(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, CInt(xStep.Value), CInt(yStep.Value))
        End If
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName

            ' Load the image.
            LoadSelectedImage()
        End If
    End Sub

    Private Sub LoadSelectedImage()
        ' Load an image using ReadFile
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.Roi.Clear()
    End Sub

    ' Click the Load Image button to read an image.
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
        ProcessImage()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        ProcessImage()
    End Sub

    ' If any settings change, update the image
    Private Sub xStep_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles xStep.ValueChanged
        ProcessImage()
    End Sub

    Private Sub yStep_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles yStep.ValueChanged
        ProcessImage()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class