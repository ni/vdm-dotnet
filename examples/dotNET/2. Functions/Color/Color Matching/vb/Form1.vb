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

' Color Matching Example
'
' This example shows how to use Algorithms.MatchColor() to check LEDs on the front panel of an instrument.
' The color spectrum of each LED (the region of interest) is compared to the color spectrum of the
' expected color.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Public Enum LedColors
    Black = 0
    Red = 1
    Orange = 2
    Green = 3
End Enum
Partial Public Class Form1
    Inherits Form
    Private Const maxImageNumber As Integer = 16
    Private Const ledCount As Integer = 13

    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "LEDs")
    Private imageNumber As Integer = 0
    Private colorInformation As New Dictionary(Of LedColors, ColorInformation)()
    Private ledRois As Roi() = New Roi(ledCount - 1) {}
    Private expectedPatterns As LedColors()() = New LedColors(maxImageNumber)() {}
    Private images As New Collection(Of VisionImage)()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Set the viewer's image type to RGB
        imageViewer1.Image.Type = ImageType.Rgb32

        ' Load pre-calculated information.
        InitializeData()

        ' Set up the PictureBox controls to graph the color spectrum values and plot the color information.
        ColorSpectrumHelpers.PlotColorSpectrum(blackSpectrumBox, ColorSensitivity.Medium, colorInformation(LedColors.Black).Information)
        ColorSpectrumHelpers.PlotColorSpectrum(redSpectrumBox, ColorSensitivity.Medium, colorInformation(LedColors.Red).Information)
        ColorSpectrumHelpers.PlotColorSpectrum(orangeSpectrumBox, ColorSensitivity.Medium, colorInformation(LedColors.Orange).Information)
        ColorSpectrumHelpers.PlotColorSpectrum(greenSpectrumBox, ColorSensitivity.Medium, colorInformation(LedColors.Green).Information)
        AddHandler blackSpectrumBox.Paint, AddressOf spectrumBox_Paint
        AddHandler redSpectrumBox.Paint, AddressOf spectrumBox_Paint
        AddHandler orangeSpectrumBox.Paint, AddressOf spectrumBox_Paint
        AddHandler greenSpectrumBox.Paint, AddressOf spectrumBox_Paint

        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the pattern corresponding to this image and display it.
        Dim pattern As LedColors() = expectedPatterns(imageNumber)
        DisplayExpectedPattern(pattern)

        ' Display the next image.
        Dim image As VisionImage = GetNextImage()

        Dim allLedsPassed As Boolean = True
        For i As Integer = 0 To ledCount - 1
            Dim scores As Collection(Of Integer) = Algorithms.MatchColor(image, colorInformation(pattern(i)), ledRois(i))
            ' If the match score is greater than 500, the LED passes the color test.
            Dim pass As Boolean = scores(0) > 500
            Select Case i
                Case 0
                    PassFailLed1.Value = pass
                Case 1
                    PassFailLed2.Value = pass
                Case 2
                    PassFailLed3.Value = pass
                Case 3
                    PassFailLed4.Value = pass
                Case 4
                    PassFailLed5.Value = pass
                Case 5
                    PassFailLed6.Value = pass
                Case 6
                    PassFailLed7.Value = pass
                Case 7
                    PassFailLed8.Value = pass
                Case 8
                    PassFailLed9.Value = pass
                Case 9
                    PassFailLed10.Value = pass
                Case 10
                    PassFailLed11.Value = pass
                Case 11
                    PassFailLed12.Value = pass
                Case 12
                    PassFailLed13.Value = pass
            End Select
            If Not pass Then
                allLedsPassed = False
                DrawFailedLED(image.Overlays.[Default], ledRois(i))
            End If
        Next
        passFailLed.Value = allLedsPassed
        imageViewer1.Attach(image)
    End Sub

    Private Sub spectrumBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
        Dim box As PictureBox = DirectCast(sender, PictureBox)
        ColorSpectrumHelpers.DrawColorSpectrum(e.Graphics, box)
    End Sub

    Private Sub InitializeData()
        ' Load color information.  This information was learned using the Color Learn Example.
        colorInformation(LedColors.Black) = New ColorInformation(New Collection(Of Double)(New Double() {0, 0, 0, 0.01, 0, 0.02, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0.96, 0}))
        colorInformation(LedColors.Red) = New ColorInformation(New Collection(Of Double)(New Double() {0.08, 0.25, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0.06, 0.61, 0, 0}))
        colorInformation(LedColors.Orange) = New ColorInformation(New Collection(Of Double)(New Double() {0, 0, 0.01, 0, 0.22, 0.76, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0}))
        colorInformation(LedColors.Green) = New ColorInformation(New Collection(Of Double)(New Double() {0, 0, 0, 0, 0, 0, _
         0.16, 0.71, 0.02, 0.06, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0, _
         0, 0, 0, 0, 0, 0.05}))

        ' Initialize the LED Roi collection.
        ledRois(0) = New Roi(New Shape() {New RectangleContour(86, 154, 14, 14)})
        ledRois(1) = New Roi(New Shape() {New RectangleContour(136, 153, 14, 14)})
        ledRois(2) = New Roi(New Shape() {New RectangleContour(188, 152, 14, 14)})
        ledRois(3) = New Roi(New Shape() {New RectangleContour(236, 152, 14, 14)})
        ledRois(4) = New Roi(New Shape() {New RectangleContour(87, 194, 14, 14)})
        ledRois(5) = New Roi(New Shape() {New RectangleContour(136, 193, 14, 14)})
        ledRois(6) = New Roi(New Shape() {New RectangleContour(189, 193, 14, 14)})
        ledRois(7) = New Roi(New Shape() {New RectangleContour(236, 194, 14, 14)})
        ledRois(8) = New Roi(New Shape() {New RectangleContour(32, 224, 21, 21)})
        ledRois(9) = New Roi(New Shape() {New RectangleContour(86, 233, 14, 14)})
        ledRois(10) = New Roi(New Shape() {New RectangleContour(135, 233, 14, 14)})
        ledRois(11) = New Roi(New Shape() {New RectangleContour(187, 232, 14, 14)})
        ledRois(12) = New Roi(New Shape() {New RectangleContour(236, 232, 14, 14)})

        ' Initialize the expected patterns array.  This array stores the
        ' expected pattern for each image.
        expectedPatterns(0) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(1) = New LedColors() {LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Orange, LedColors.Orange, _
         LedColors.Orange, LedColors.Orange, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, _
         LedColors.Green}
        expectedPatterns(2) = New LedColors() {LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Orange, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, _
         LedColors.Green}
        expectedPatterns(3) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, _
         LedColors.Green}
        expectedPatterns(4) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(5) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Green, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(6) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Green, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(7) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Green, _
         LedColors.Black}
        expectedPatterns(8) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Green}
        expectedPatterns(9) = New LedColors() {LedColors.Black, LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(10) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(11) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black}
        expectedPatterns(12) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Orange, _
         LedColors.Orange, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Green}
        expectedPatterns(13) = New LedColors() {LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Orange, LedColors.Green, LedColors.Black, LedColors.Green, LedColors.Green, _
         LedColors.Black}
        expectedPatterns(14) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Red, LedColors.Orange, LedColors.Orange, _
         LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Green, _
         LedColors.Green}
        expectedPatterns(15) = New LedColors() {LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, _
         LedColors.Black, LedColors.Orange, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, _
         LedColors.Black}
        expectedPatterns(16) = New LedColors() {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Black, LedColors.Orange, _
         LedColors.Black, LedColors.Orange, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Black, _
         LedColors.Black}
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage(ImageType.Rgb32)
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "MID7604 " & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > maxImageNumber Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub DrawFailedLED(ByVal overlay As Overlay, ByVal roi As Roi)
        Dim rect As RectangleContour = roi.GetBoundingRectangle()
        rect.Left = rect.Left - rect.Width / 1.25
        rect.Top = rect.Top - rect.Height / 1.25
        rect.Width = rect.Width * 2.5
        rect.Height = rect.Height * 2.5

        ' Overlay on the image to indicate which LED failed.
        overlay.AddRectangle(rect, Rgb32Value.RedColor, DrawingMode.DrawValue)

        Dim textOptions As New OverlayTextOptions("Arial", 20, HorizontalTextAlignment.Center)
        textOptions.VerticalAlignment = VerticalTextAlignment.Baseline
        textOptions.TextDecoration.Bold = True
        overlay.AddText("Fail", New PointContour(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2), Rgb32Value.RedColor, textOptions)
    End Sub

    Private Sub DisplayExpectedPattern(ByVal pattern As LedColors())
        For i As Integer = 0 To ledCount - 1
            Dim ledOn As Boolean = pattern(i) <> LedColors.Black
            Select Case i
                Case 0
                    ExpectedLed1.Value = ledOn
                Case 1
                    ExpectedLed2.Value = ledOn
                Case 2
                    ExpectedLed3.Value = ledOn
                Case 3
                    ExpectedLed4.Value = ledOn
                Case 4
                    ExpectedLed5.Value = ledOn
                Case 5
                    ExpectedLed6.Value = ledOn
                Case 6
                    ExpectedLed7.Value = ledOn
                Case 7
                    ExpectedLed8.Value = ledOn
                Case 8
                    ExpectedLed9.Value = ledOn
                Case 9
                    ExpectedLed10.Value = ledOn
                Case 10
                    ExpectedLed11.Value = ledOn
                Case 11
                    ExpectedLed12.Value = ledOn
                Case 12
                    ExpectedLed13.Value = ledOn
            End Select
        Next
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub
End Class