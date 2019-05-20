Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Morphological Segmentation Example

' This example demonstrates the steps involved in morphological segmentation
' of an image.  This process is usually performed to segment a noisy image or
' an image that contains particles that touch each other.

Partial Public Class Form1
    Inherits Form
    ' Stores a copy of the image for use during the Display Watershed Lines step
    Private imageCopy As New VisionImage()
    ' Enumeration corresponding to each step of the morphological segmentation process.
    Private Enum [Step]
        LoadSampleImage = 0
        Threshold = 1
        DistanceTransform = 2
        WatershedTransform = 3
        DisplayWatershedLines = 4
        Done = 5
    End Enum
    ' The array of labels for the viewer, which are displayed after each step is executed.
    Private viewerLabels As String() = New String() {"Image", "Image", "Thresholded Image", "Distance Transform", "Watershed Transform", "Watershed Lines"}
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        steps.SelectedIndex = 0
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Pills.jp2")
    End Sub

    ' Handler for the runCurrentStepButton.  This is the main subroutine that performs
    ' all the processing steps.
    Private Sub runCurrentStepButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles runCurrentStepButton.Click
        ' Select what to do based on the current index in the listbox.
        Select Case DirectCast(steps.SelectedIndex, [Step])
            Case [Step].LoadSampleImage
                ' Disable the browse button.
                browseButton.Enabled = False
                ' Load an image from the selected location into the viewer.
                imageViewer1.Image.ReadFile(imagePath.Text)
                ' Store a copy of the image in imageCopy.
                Algorithms.Copy(imageViewer1.Image, imageCopy)
                ' Set the palette on the viewer to a grayscale palette.
                imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray
                Exit Select
            Case [Step].Threshold
                ' Auto threshold the image.
                Algorithms.AutoThreshold(imageViewer1.Image, imageViewer1.Image, 2, ThresholdMethod.InterclassVariance)
                ' Set the palette on the viewer to a binary palette.
                imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
                Exit Select
            Case [Step].DistanceTransform
                ' Transform the image using the Danielsson method.
                Algorithms.Danielsson(imageViewer1.Image, imageViewer1.Image)
                ' Set the palette on the viewer to a gradient palette.
                imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gradient
                Exit Select
            Case [Step].WatershedTransform
                ' Disable the Connectivity-8 checkbox.
                connectivity8.Enabled = False
                ' Watershed transform the image.
                Algorithms.WatershedTransform(imageViewer1.Image, imageViewer1.Image, IIf(connectivity8.Checked, Connectivity.Connectivity8, Connectivity.Connectivity4))
                ' Set the palette on the viewer to a binary palette.
                imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
                Exit Select
            Case [Step].DisplayWatershedLines
                ' Remove the value of 0 from the copy of the image
                ' by replacing everything less than 1 to 1.
                Algorithms.Max(imageCopy, New PixelValue(1), imageCopy)
                ' Use the Watershed trasnformed image as a mask on the copy.
                ' This will cause the pixels along the watershed lines to
                ' be set to 0.
                Algorithms.Mask(imageCopy, imageCopy, imageViewer1.Image)
                ' Attach the copy to the viewer.
                imageViewer1.Attach(imageCopy)
                ' Create a palette where 0 is green and the rest of the values
                ' are grayscale values.  If you display masked imageCopy with this
                ' palette, the watershed lines will be green in color.
                imageViewer1.Palette.Entries.Clear()
                imageViewer1.Palette.Entries.Add(New NationalInstruments.Vision.WindowsForms.PaletteEntry(0, 255, 0))
                Exit Select
            Case [Step].Done
                Application.[Exit]()
                Exit Sub
        End Select
        steps.SelectedIndex += 1
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        dialog.Title = "Select Sample Image"
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
        End If
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    ' Handler called whenever the list index changes.
    Private Sub steps_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles steps.SelectedIndexChanged
        ' Set the RunCurrentStep button caption to the text corresponding
        ' to the current step.
        runCurrentStepButton.Text = DirectCast(steps.Items(steps.SelectedIndex), String)
        ' Set the viewer label
        viewerLabel.Text = viewerLabels(steps.SelectedIndex)
    End Sub
End Class