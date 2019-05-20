Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Add Example
'
' This example demonstrates how to add two images.  You can extend this example to perform
' all basic arithmetic and logical operations (AND, OR, etc.) on images.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath1.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Moly.tif")
        imagePath2.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Iron.tif")
    End Sub

    Private Sub LoadSelectedImage(ByVal index As Integer)
        If index = 0 Then
            imageViewer1.Image.ReadFile(imagePath1.Text)
        Else
            imageViewer2.Image.ReadFile(imagePath2.Text)
        End If
        ' After both images load, enable the Add Images button.
        If imageViewer1.Image.Width > 0 AndAlso imageViewer2.Image.Width > 0 Then
            addImagesButton.Enabled = True
        End If
    End Sub
    Private Sub loadImagesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImagesButton.Click
        LoadSelectedImage(0)
        LoadSelectedImage(1)
    End Sub

    Private Sub addImagesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addImagesButton.Click
        ' Add the two images and display the result.
        Algorithms.Add(imageViewer1.Image, imageViewer2.Image, imageViewer3.Image)
    End Sub

    Private Sub browseButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton1.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath1.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath1.Text = dialog.FileName
            LoadSelectedImage(0)
        End If
    End Sub

    Private Sub browseButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton2.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath2.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath2.Text = dialog.FileName
            LoadSelectedImage(1)
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class