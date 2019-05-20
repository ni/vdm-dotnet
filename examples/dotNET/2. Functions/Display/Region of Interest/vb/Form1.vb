Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Region of Interest Example

' This example demonstrates how to set up the display tools in order to interactively
' select one or more regions for inspection.
Partial Public Class Form1
    Inherits Form
    Private source As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "alu.bmp")
    End Sub

    Private Sub InvertImage()
        ' Invert any pixels inside a region of interest.
        If imageViewer1.Roi.Count > 0 Then
            Using mask As New VisionImage()
                ' Compute the mask image of the selected regions
                Algorithms.RoiToMask(mask, imageViewer1.Roi, New PixelValue(255), source)

                ' Invert the image
                Algorithms.Inverse(source, imageViewer1.Image, mask)
            End Using
        Else
            Algorithms.Copy(source, imageViewer1.Image)
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

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        source.ReadFile(imagePath.Text)
        InvertImage()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        InvertImage()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class