Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Nondestructive Overlay Example
'
' This example demonstrates how to display text and pictures on an image window without
' overwriting or changing the displayed image.  Nondestructive overlay provides an
' effective way to display calibration grids, guidelines, measurement results,
' and pass/fail results on an image window.

Partial Public Class Form1
    Inherits Form
    Private imagePath As String = ExampleImagesFolder.GetExampleImagesFolder()
    Private filenames As Collection(Of String)
    Private lastTime As New DateTime()
    Private nextTime As New DateTime()
    Private r As New Random()
    Private textOrigin As New PointContour()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Load the files in the source directory.
        filenames = New Collection(Of String)(System.IO.Directory.GetFiles(imagePath, "*", System.IO.SearchOption.TopDirectoryOnly))

        ' Enable the timer.
        lastTime = DateTime.Now
        nextTime = lastTime
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the current time.
        Dim currentTime As DateTime = DateTime.Now
        ' After advancing to the next second, update the overlay.
        If currentTime.Subtract(lastTime).TotalSeconds >= 1 Then
            lastTime = currentTime

            ' Overlay the current time.
            Dim secondsToNextImage As Integer = CInt(nextTime.Subtract(currentTime).TotalSeconds)
            OverlayTextOnImage(imageViewer1.Image, currentTime, secondsToNextImage)

            ' Is it time to load the next image?
            If secondsToNextImage < 0 Then
                ' The next image will load in 5 seconds.
                nextTime = currentTime.AddSeconds(5)

                ' Get the next image.
                LoadNextImage(imageViewer1.Image)

                ' Compute a random point to overlay the text.
                textOrigin.Initialize(r.NextDouble() * (imageViewer1.Image.Width / 2.0R), r.NextDouble() * (imageViewer1.Image.Height / 2.0R))
                OverlayTextOnImage(imageViewer1.Image, currentTime, 4)
            End If
        End If
    End Sub

    Private Sub LoadNextImage(ByVal image As VisionImage)
        ' Load a random image from the image directory.
        image.ReadFile(filenames(r.[Next](filenames.Count)))
    End Sub

    Private Sub OverlayTextOnImage(ByVal image As VisionImage, ByVal time As DateTime, ByVal secondsToNextImage As Integer)
        Dim textOptions As New OverlayTextOptions("Arial", 20)
        textOptions.TextDecoration.Bold = True

        ' Clear any overlays.
        image.Overlays.[Default].Clear()

        ' Overlay text onto the image.  This will not change the image pixels.
        image.Overlays.[Default].AddText([String].Format("{0}" & vbLf & "Next image in {1}s.", time.ToLongTimeString(), secondsToNextImage.ToString()), textOrigin, New Rgb32Value(colorDialog1.Color), textOptions)

        ' Display the overlaid text.
        overlaidTextBox.Text = [String].Format("{0}" & vbCr & vbLf & "Next image in {1}s.", time.ToLongTimeString(), secondsToNextImage.ToString())
    End Sub

    Private Sub textColorButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles textColorButton.Click
        If colorDialog1.ShowDialog() = DialogResult.OK Then
            overlaidTextBox.ForeColor = colorDialog1.Color
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class