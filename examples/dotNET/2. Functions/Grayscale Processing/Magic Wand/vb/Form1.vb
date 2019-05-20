Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports NationalInstruments.Vision.WindowsForms

' Magic Wand Example
'
' This example demonstrates how to create an image mask by extracting a region surrounding
' a reference pixel, called the origin, and using a tolerance (+ or -) of intensity
' variations based on this reference pixel.  Using this origin, Algorithms.MagicWand()
' searches for its neighbors with an intensity equal to or falling within the tolerance
' value of the point of reference.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imageViewer1.Roi.Color = Rgb32Value.YellowColor
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        ' If a point is on the viewer, perform the magic wand operation.
        If imageViewer1.Roi.Count > 0 AndAlso imageViewer1.Roi(0).Type = ContourType.Point Then
            Algorithms.MagicWand(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, CDbl(toleranceUpDown.Value), IIf(connectivity4Button.Checked, Connectivity.Connectivity4, Connectivity.Connectivity8))
            Dim report As MaskToRoiReport = Algorithms.MaskToRoi(imageViewer2.Image)
            imageViewer1.Roi.Clear()
            For Each c As Contour In report.Roi
                imageViewer1.Roi.Add(c.Shape)
            Next
        End If
    End Sub

    ' Click the Load Image button to read an image.
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
    End Sub

    ' Click the Browse button to open the file dialog.
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim imageDialog As New ImagePreviewFileDialog()
        imageDialog.FileName = imagePath.Text
        If imageDialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = imageDialog.FileName
            ' Load the image.
            LoadSelectedImage()
        End If
    End Sub

    ' The following four functions keep the two image viewers in sync.
    Private Sub imageViewer1_ImagePanned(ByVal sender As Object, ByVal e As ImagePannedEventArgs) Handles imageViewer1.ImagePanned
        If Not imageViewer2.Center.Equals(imageViewer1.Center) Then
            imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImagePanned(ByVal sender As Object, ByVal e As ImagePannedEventArgs) Handles imageViewer2.ImagePanned
        If Not imageViewer1.Center.Equals(imageViewer2.Center) Then
            imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y)
        End If
    End Sub

    Private Sub imageViewer1_ImageZoomed(ByVal sender As Object, ByVal e As ImageZoomedEventArgs) Handles imageViewer1.ImageZoomed
        If Not imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo) Then
            imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImageZoomed(ByVal sender As Object, ByVal e As ImageZoomedEventArgs) Handles imageViewer2.ImageZoomed
        If Not imageViewer1.ZoomInfo.Equals(imageViewer2.ZoomInfo) Then
            imageViewer1.ZoomInfo.Initialize(imageViewer2.ZoomInfo.X, imageViewer2.ZoomInfo.Y)
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class