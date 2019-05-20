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

' LCD Example
'
' This example shows how to use the NI Vision seven-segment display reader methods
' to read values displayed on an LCD panel.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "LCD\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private lcdRoi As Roi
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Overlay the LCD segment Roi.
        image.Overlays.[Default].AddRoi(lcdRoi)

        ' Read the LCD.
        Dim report As LcdReport = Algorithms.ReadLcd(image, lcdRoi)

        ' Display the results.
        number.Text = report.Text
        segments1.SetSegments(report.SegmentInfo(0))
        segments2.SetSegments(report.SegmentInfo(1))
        segments3.SetSegments(report.SegmentInfo(2))
        segments4.SetSegments(report.SegmentInfo(3))

        imageViewer1.Attach(image)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Use FindLcdSegments to get the appropriate Roi.
        lcdRoi = Algorithms.FindLcdSegments(GetNextImage(), New RectangleContour(27, 55, 243, 92))
        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub
    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage()
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Image" & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 11 Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub

End Class