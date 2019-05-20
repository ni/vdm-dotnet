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

' Threshold example

' This example illustrates different thresholding algorithms.
' Local thresholding calculates local statistics for each pixel in an image.
' Based on the calculation result, the algorithm categorizes the pixel as part
' of a particle or the background.  Automatic thresholding uses the histogram of
' an image to compute a single threshold value for the entire image.  Manual
' thresholding uses a specified range of values to compute a threshold value for
' the image.  Refer to the NI Vision Concept Manual for more information about
' thresholding algorithms.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private ready As Boolean = False
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        localObjectBox.SelectedIndex = 1
        localMethodBox.SelectedIndex = 0
        autoObjectBox.SelectedIndex = 1
        autoMethodBox.SelectedIndex = 0
        tabControl1.SelectedIndex = 0
        AddHandler tabControl1.SelectedIndexChanged, AddressOf tabControl1_SelectedIndexChanged
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "lcd.jpg")
        LoadSelectedImage()
    End Sub

    Private Sub tabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ready Then
            DoThreshold()
        End If
    End Sub

    ' Load an image using ReadFile
    Private Sub LoadSelectedImage()
        ' Read the image
        imageViewerOriginal.Image.ReadFile(imagePath.Text)
        ' Ensure the window size is smaller than the image size.
        If localXSize.Value >= imageViewerOriginal.Image.Width Then
            localXSize.Value = imageViewerOriginal.Image.Width - 1
        End If
        If localYSize.Value >= imageViewerOriginal.Image.Height Then
            localYSize.Value = imageViewerOriginal.Image.Height - 1
        End If
        ready = True
        DoThreshold()
    End Sub

    Private Sub DoThreshold()
        Select Case tabControl1.SelectedIndex
            Case 0
                ' Local threshold
                Dim options As New LocalThresholdOptions()
                options.DeviationWeight = CDbl(niblackUpDown.Value)
                If localMethodBox.SelectedIndex = 0 Then
                    options.Method = LocalThresholdMethod.NiBlack
                Else
                    options.Method = LocalThresholdMethod.BackgroundCorrection
                End If
                If localObjectBox.SelectedIndex = 0 Then
                    options.ParticleType = ParticleType.Bright
                Else
                    options.ParticleType = ParticleType.Dark
                End If
                options.WindowWidth = CUInt(localXSize.Value)
                options.WindowHeight = CUInt(localYSize.Value)
                Algorithms.LocalThreshold(imageViewerOriginal.Image, imageViewerThresholded.Image, options)
                Exit Select
            Case 1
                ' Auto threshold
                ' If we are looking for dark objects and the auto method is metric,
                ' moment, or interclass variance we need to take the inverse of the image
                ' first because AutoThreshold() looks for the bright objects for
                ' these methods.
                Dim thresholdData As Collection(Of ThresholdData)
                If autoObjectBox.SelectedIndex = 1 AndAlso autoObjectBox.SelectedIndex > 1 Then
                    ' Use the thresholded image to temporarily hold the inverse image.  It
                    ' will get set back to the threshold image after AutoThreshold() is called.
                    Algorithms.Inverse(imageViewerOriginal.Image, imageViewerThresholded.Image)
                    thresholdData = Algorithms.AutoThreshold(imageViewerThresholded.Image, imageViewerThresholded.Image, 2, DirectCast(autoMethodBox.SelectedIndex, ThresholdMethod))
                Else
                    thresholdData = Algorithms.AutoThreshold(imageViewerOriginal.Image, imageViewerThresholded.Image, 2, DirectCast(autoMethodBox.SelectedIndex, ThresholdMethod))
                End If
                Dim thresholdRange As Range
                If autoObjectBox.SelectedIndex = 1 Then
                    ' Look for dark objects
                    thresholdRange = New Range(0, thresholdData(0).Range.Maximum)
                Else
                    ' Look for bright objects
                    thresholdRange = New Range(thresholdData(0).Range.Minimum, 255)
                End If
                Algorithms.Threshold(imageViewerOriginal.Image, imageViewerThresholded.Image, thresholdRange)
                Exit Select
            Case 2
                ' Manual threshold
                Algorithms.Threshold(imageViewerOriginal.Image, imageViewerThresholded.Image, New Range(manualMinimumSlide.Value, manualMaximumSlide.Value))
                Exit Select
        End Select
    End Sub

    Private Sub manualMinimumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manualMinimumSlide.ValueChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub manualMaximumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manualMaximumSlide.ValueChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    ' Click the Browse button to open the file dialog
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        ready = False
        dialog.Filter = "AIPD Images (*.apd;*.aipd)|*.apd;*.aipd|BMP Images (*.bmp)|*.bmp|JPEG Images (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Images (*.png)|*.png|TIFF Images (*.tif;*.tiff)|*.tif;*.tiff|All Image Files|*.apd;*.aipd;*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files (*.*)|*||"
        dialog.FilterIndex = 6
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            ' Load the image
            LoadSelectedImage()
        End If
    End Sub

    Private Sub localObjectBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles localObjectBox.SelectedIndexChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub localMethodBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles localMethodBox.SelectedIndexChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub niblackUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles niblackUpDown.ValueChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub localXSize_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles localXSize.ValueChanged
        If (imageViewerOriginal.Image.Width > 0) Then
            If localXSize.Value >= imageViewerOriginal.Image.Width Then
                localXSize.Value = imageViewerOriginal.Image.Width - 1
            ElseIf localXSize.Value < 3 Then
                localXSize.Value = 3
            End If
            If ready Then
                DoThreshold()
            End If
        End If
    End Sub

    Private Sub localYSize_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles localYSize.ValueChanged
        If (imageViewerOriginal.Image.Height > 0) Then
            If localYSize.Value >= imageViewerOriginal.Image.Height Then
                localYSize.Value = imageViewerOriginal.Image.Height - 1
            ElseIf localYSize.Value < 3 Then
                localYSize.Value = 3
            End If
            If ready Then
                DoThreshold()
            End If
        End If
    End Sub

    Private Sub autoObjectBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoObjectBox.SelectedIndexChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub autoMethodBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles autoMethodBox.SelectedIndexChanged
        If ready Then
            DoThreshold()
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class