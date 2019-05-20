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

' Barcode Example

' This example demonstrates how to use Algorithms.ReadBarcode() to read standard barcodes.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Barcode\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Start the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        Dim image As VisionImage = GetNextImage()

        ' Initialize the barcode roi.
        Dim barcodeRoi As New Roi(New Shape() {New RectangleContour(9, 100, 340, 48)})

        image.Overlays.[Default].AddRoi(barcodeRoi)

        ' Read the barcode.
        Dim report As BarcodeReport = Algorithms.ReadBarcode(image, BarcodeTypes.Ean13, barcodeRoi, True)

        ' Display the result.
        barcodeResult.Text = report.OutputChar1.ToString() + report.OutputChar2.ToString() + report.Text
        imageViewer1.Attach(image)
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim nextImage As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            nextImage = New VisionImage()
            nextImage.ReadFile(System.IO.Path.Combine(imagePath, "Image" & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(nextImage)
        Else
            nextImage = images(imageNumber)
            ' Clear any overlays
            nextImage.Overlays.[Default].Clear()
        End If

        ' Advance the number number to the next image
        imageNumber += 1
        If imageNumber > 6 Then
            imageNumber = 0
        End If
        Return nextImage
    End Function

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        timer1.Interval = IIf((newDelay > 0), newDelay, 1)
    End Sub
End Class