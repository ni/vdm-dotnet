Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' ReadImage example
' This example shows how to open, read, and display images in NI Vision.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Initialize the combo box
        ImageType.SelectedIndex = 0

        ' Initialize the common dialog's default directory
        openFileDialog1.InitialDirectory = ExampleImagesFolder.GetExampleImagesFolder()
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        openFileDialog1.ShowDialog()
        ReadImage()
    End Sub

    Private Sub ReadImage()
        If openFileDialog1.FileName <> "" Then
            ' Read the file into the image attached to the viewer
            imageViewer1.Image.ReadFile(openFileDialog1.FileName)
        End If
    End Sub

    Private Sub imageType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageType.SelectedIndexChanged
        ' When the image type is changed, change the viewer's image type, and
        ' reload the image from the disk.
        imageViewer1.Image.Type = DirectCast(ImageType.SelectedIndex, ImageType)
        ReadImage()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub
End Class
