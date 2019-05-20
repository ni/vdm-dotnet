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

' Mask example

' This example demonstrates how to apply a binary image (or mask image) to mask another
' image.  When an image is masked, all the pixels in the image that correspond to pixels with
' zero values in the mask image are set to zero.  The other pixels are left untouched.
' Masking is an effective way to process specific parts of an image.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        sourceImagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Iron.tif")
        maskImagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Mask.tif")
        AddHandler imageViewer1.ImagePanned, AddressOf imageViewer1_ImagePanned
        AddHandler imageViewer1.ImageZoomed, AddressOf imageViewer1_ImageZoomed
        AddHandler imageViewer2.ImagePanned, AddressOf imageViewer2_ImagePanned
        AddHandler imageViewer2.ImageZoomed, AddressOf imageViewer2_ImageZoomed
        imageViewer1.ToolsShown = ViewerTools.Pan Or ViewerTools.Point Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut Or ViewerTools.Selection
        imageViewer2.ToolsShown = ViewerTools.Pan Or ViewerTools.Point Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut Or ViewerTools.Selection
    End Sub

    ' These four functions keep imageViewer1 and imageViewer2 at the same position in the image
    ' with the same zoom scale.
    Private Sub imageViewer2_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs)
        imageViewer1.ZoomInfo.Initialize(imageViewer2.ZoomInfo.X, imageViewer2.ZoomInfo.Y)
    End Sub

    Private Sub imageViewer2_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs)
        imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y)
    End Sub

    Private Sub imageViewer1_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs)
        imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y)
    End Sub

    Private Sub imageViewer1_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs)
        imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y)
    End Sub

    Private Sub sourceBrowseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles sourceBrowseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = sourceImagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            sourceImagePath.Text = dialog.FileName
            LoadSourceImage()
        End If
    End Sub

    Private Sub LoadSourceImage()
        ' Read the source image
        imageViewer1.Image.ReadFile(sourceImagePath.Text)
    End Sub

    Private Sub maskImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles maskImageButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = maskImagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            maskImagePath.Text = dialog.FileName
            LoadMaskImage()
        End If
    End Sub

    Private Sub LoadMaskImage()
        ' Read the mask image
        imageViewerMask.Image.ReadFile(maskImagePath.Text)
    End Sub

    Private Sub loadImagesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImagesButton.Click
        LoadSourceImage()
        LoadMaskImage()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 Then
            If imageViewer1.Roi(0).Type = ContourType.Point Then
                ' Get the point from the viewer.
                Dim point As PointContour = DirectCast(imageViewer1.Roi(0).Shape, PointContour)

                ' Set the mask offset.
                imageViewerMask.Image.MaskOffset.Initialize(point.X - imageViewerMask.Image.Width / 2, point.Y - imageViewerMask.Height / 2)

                ' Mask the image.
                Algorithms.Mask(imageViewer1.Image, imageViewer2.Image, imageViewerMask.Image)
            End If
        End If
    End Sub
End Class