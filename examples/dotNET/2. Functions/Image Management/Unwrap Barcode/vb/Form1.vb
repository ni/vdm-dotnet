Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Unwrap Barcode Example
' 
' This example unwraps and reads a circular barcode.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Unwrap the original image, read the barcode, and display the results.
    Private Sub unwrapBarcodeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles unwrapBarcodeButton.Click
        ' Unwrap annulus region of image.
        Algorithms.Unwrap(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi, RectangleOrientation.BaseOutside, InterpolationMethod.Bilinear)

        ' Invert unwrapped image for barcode reader.
        Algorithms.Inverse(imageViewer2.Image, imageViewer2.Image)

        ' Read the barcode from the wrapped image.
        Dim report As BarcodeReport = Algorithms.ReadBarcode(imageViewer2.Image, BarcodeTypes.Code39)

        ' Display results
        barcodeString.Text = report.Text
        confidenceLevel.Text = [String].Format("{0:0.0}", report.ConfidenceLevel)
    End Sub

    ' This function loads the CD image into memory and displays it.
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        ' Read the image.
        imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "CD.jpg"))
        ' Update the viewer so the image is loaded before we set the center.
        ' We could also set ImmediateUpdates to true to make this happen, but this
        ' hurts performance.
        imageViewer1.RefreshImage()
        imageViewer1.Center.Initialize(310, 300)

        ' Initialize and display the annulus region of interest.
        imageViewer1.Roi.Clear()
        imageViewer1.Roi.Add(New AnnulusContour(New PointContour(295, -62), 390, 425, 238, 308))

        ' Enable the Unwrap Image button.
        unwrapBarcodeButton.Enabled = True
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class