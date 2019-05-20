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

' Meter Example
'
' This example uses Algorithms.ReadMeter() to read the position of a needle.
' This method has many applications, one of which is to calibrate speedometers and
' gauges in the automotive industry.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Meter\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Create the meter arc (stores information about the meter).
        Dim arc As MeterArc = Algorithms.GetMeterArc(MeterNeedleColor.DarkOnLight, New LineContour(New PointContour(53, 75), New PointContour(101, 134)), New LineContour(New PointContour(203, 75), New PointContour(155, 138)))

        ' Read the meter.
        Dim report As MeterReport = Algorithms.ReadMeter(image, arc)

        ' Display results.
        image.Overlays.[Default].AddOval(New OvalContour(report.EndOfNeedle.X - 2, report.EndOfNeedle.Y - 2, 5, 5), Rgb32Value.RedColor, DrawingMode.PaintValue)
        SpeedKnob1.Value = report.Percentage
        speedBox.Text = [String].Format("{0:0.0}", report.Percentage)
        imageViewer1.Attach(image)
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
        If imageNumber > 17 Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

End Class