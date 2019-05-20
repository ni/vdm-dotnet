Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Image Averaging Example
'
' This example demonstrates how to use image averaging to improve the signal/noise
' ratio of noisy images.

Partial Public Class Form1
    Inherits Form
    Private imageNumber As Integer = 0
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Noisy Images\")
    Private result As New VisionImage()
    Private operand As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Load the first image.
        loadImageButton_Click(loadImageButton, EventArgs.Empty)
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        ReadNoisyImage(imageViewer1.Image, imageNumber)

        ' Change the label to indicate the current image number.
        filenameLabel.Text = "noise-" & [String].Format("{0:00}", imageNumber) & ".png"

        ' Advance to the next image.
        imageNumber += 1
        If imageNumber > 19 Then
            imageNumber = 0
        End If
    End Sub

    Private Sub ReadNoisyImage(ByVal image As VisionImage, ByVal index As Integer)
        image.ReadFile(System.IO.Path.Combine(imagePath, "noise-" & [String].Format("{0:00}", index) & ".png"))
    End Sub

    Private Sub averageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles averageButton.Click
        ' Set the destination image to I16 to allow for accumulation of the 8-bit values.
        result.Type = ImageType.I16
        operand.Type = ImageType.I16

        ' Read the first image into the result.
        ReadNoisyImage(result, 0)

        ' Initialize index and start processing.
        imageNumber = 1
        timer1.Enabled = True
        loadImageButton.Enabled = False
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Check to see if all images have been averaged.
        If imageNumber > 19 Then
            imageNumber = 0
            timer1.Enabled = False
            loadImageButton.Enabled = True
            Exit Sub
        End If

        ' Initialize averaging buffer to I16 for compatibility with the Result image.
        Using average As New VisionImage(ImageType.I16)
            ' Read the next image into the operand.
            ReadNoisyImage(operand, imageNumber)

            ' Add it to the result image.
            Algorithms.Add(result, operand, result)

            ' Perform the average to show the user how much the result has improved so far.
            Algorithms.Divide(result, New PixelValue(imageNumber), average)

            ' Change the average type to U8 for display.
            average.Type = ImageType.U8

            ' Display the result in imageViewer2.
            Algorithms.Copy(average, imageViewer2.Image)
        End Using

        ' Increment image index.
        imageNumber += 1
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    ' These functions make sure the viewers keep the same position and zoom level.
    Private Sub imageViewer1_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs) Handles imageViewer1.ImagePanned
        If Not imageViewer2.Center.Equals(imageViewer1.Center) Then
            imageViewer2.Center.Initialize(imageViewer1.Center.X, imageViewer1.Center.Y)
        End If
    End Sub

    Private Sub imageViewer1_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs) Handles imageViewer1.ImageZoomed
        If Not imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo) Then
            imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImagePanned(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImagePannedEventArgs) Handles imageViewer2.ImagePanned
        If Not imageViewer1.Center.Equals(imageViewer2.Center) Then
            imageViewer1.Center.Initialize(imageViewer2.Center.X, imageViewer2.Center.Y)
        End If
    End Sub

    Private Sub imageViewer2_ImageZoomed(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ImageZoomedEventArgs) Handles imageViewer2.ImageZoomed
        If Not imageViewer2.ZoomInfo.Equals(imageViewer1.ZoomInfo) Then
            imageViewer2.ZoomInfo.Initialize(imageViewer1.ZoomInfo.X, imageViewer1.ZoomInfo.Y)
        End If
    End Sub
End Class