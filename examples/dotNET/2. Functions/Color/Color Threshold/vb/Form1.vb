Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Color Threshold Example
'
' This eaxmple demonstrates how to use the HSL color space to perform inspection tasks based on object colors.
' This example illustrates the advantages of using the HSL color space over the RGB color space
' for color inspection or matching.
'
' * Step 1: The Threshold Color Mode is
'           set to RGB by default, which means that the threshold process is
'           based on the red, green, and blue values of the pixels.
'           By modifying the Red, Green, and Blue threshold
'           values, try to find the best threshold range to separate the blue parts
'           from the background.
'
' * Step 2: Good values to segment the blue parts are
'           approximately:
'           Red = [0, 142], Green = [0, 145], Blue = [80, 255]
'           Note that it is almost impossible to find a threshold range to
'           detect both blue parts at the same time.
'
' * Step 3: Select Image 2
'           Note that this threshold mode is also very sensitive to
'           lighting changes!
'
' * Step 4: Select Image 1 agani.
'
' * Step 5: Next, work in a different color mode
'           based on Hue, Saturation, and Luminance pixel values.
'
'           Select the HSL Threshold color mode.
'
' * Step 6: The necessary information is essentially present
'           in the hue plane of the image.  Set the threshold range for
'           the Saturation and Luminance planes to [0,255].
'           Check different values for the hue threshold range.
'
' * Step 7: A good Hue threshold range to detect the blue
'           part is [110, 215].  In order to segment the green parts, try
'           the [40, 100] range.
'
' * Step 8: Change the image by clicking on the Image 1
'           and Image 2 option buttons.  Note that the HSL
'           threshold color mode is insensitive to light changes.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private stepsArray As String() = New String(7) {}
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imageViewer1.Image.Type = ImageType.Rgb32
        InitializeStepsArray()
        stepsTextBox.Text = stepsArray(0)
        SetCaption()
        ReadImage()
    End Sub

    Private Sub SetCaption()
        imageViewer2Label.Text = IIf(imageTypeRGB.Checked, "RGB Threshold", "HSL Threshold")
    End Sub

    Private Sub ReadImage()
        If imageSelection1.Checked Then
            imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Candy1.png"))
        Else
            imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Candy2.png"))
        End If
        DoThreshold()
    End Sub

    Private Sub DoThreshold()
        ' Perform the color threshold as long as the image is of the right type.
        If imageViewer1.Image.Type = ImageType.Rgb32 Then
            Algorithms.ColorThreshold(imageViewer1.Image, imageViewer2.Image, IIf(imageTypeRGB.Checked, ColorMode.Rgb, ColorMode.Hsl), 1, New Range(RedMinimumSlide.Value, RedMaximumSlide.Value), New Range(GreenMinimumSlide.Value, GreenMaximumSlide.Value), _
                 New Range(BlueMinimumSlide.Value, BlueMaximumSlide.Value))
        End If
    End Sub

    Private Sub InitializeStepsArray()
        stepsArray(0) = "The Threshold Color Mode is set to RGB by default, which means that the " & "threshold process is based on the red, green, and blue pixel values. " & "By modifying the Red, Green, and Blue threshold values, try to " & "find the best threshold range to separate the blue parts from the background."
        stepsArray(1) = "Good values to segment the blue parts are approximately: " & vbCr & vbLf & "Red = [0,142], Green = [0,145], Blue = [80,255]" & vbCr & vbLf & "Note that it is almost impossible to find a threshold range to detect " & "both blue parts at the same time."
        stepsArray(2) = "Select Image #2" & vbCr & vbLf & "Note that this threshold mode is also very sensitive to lighting changes."
        stepsArray(3) = "Select Image #1 again."
        stepsArray(4) = "Work in a different color mode based on Hue, Saturation, and Luminance " & "values of the pixel." & vbCr & vbLf & vbCr & vbLf & "Select the HSL Threshold color mode."
        stepsArray(5) = "The necessary information is essentially present in the hue plane " & "of the image.  Set the threshold range for the Saturation and Luminance " & "planes to [0,255]. Check different values for the hue threshold range."
        stepsArray(6) = "A good Hue threshold range to detect the blue part is [110, 215].  In order " & "to segment the green parts, try the [40, 100] range."
        stepsArray(7) = "Change the image by clicking on the Image 1 and Image 2 option buttons.  Note " & "that the HSL threshold color mode is insensitive to light changes." & vbCr & vbLf & vbCr & vbLf & "End of the example."
    End Sub
    Private Sub RedMinimumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedMinimumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub RedMaximumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedMaximumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub GreenMinimumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenMinimumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub GreenMaximumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GreenMaximumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub BlueMinimumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueMinimumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub BlueMaximumSlide_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlueMaximumSlide.ValueChanged
        DoThreshold()
    End Sub

    Private Sub stepNumber_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles stepNumber.ValueChanged
        stepsTextBox.Text = stepsArray(CInt(stepNumber.Value) - 1)
    End Sub

    Private Sub imageSelection1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageSelection1.CheckedChanged
        ReadImage()
    End Sub

    Private Sub imageSelection2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageSelection2.CheckedChanged
        ReadImage()
    End Sub

    Private Sub imageTypeRGB_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageTypeRGB.CheckedChanged
        DoThreshold()
    End Sub

    Private Sub imageTypeHSL_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles imageTypeHSL.CheckedChanged
        DoThreshold()
    End Sub

    Private Sub quitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles quitButton.Click
        Application.Exit()
    End Sub
End Class