Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports System.Collections.ObjectModel

' Basic Particle Example
'
' This example introduces processing blob area (particle analysis).  The example
' uses the threshold function, which converts a grayscale image into a binary image.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private form2 As Form2 = Nothing
    Public Sub New()
        InitializeComponent()
        form2 = New Form2()
        form2.Show()
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub SimpleRangeSelect1_RangeChanged(ByVal sender As System.Object, ByVal e As NationalInstruments.Vision.MeasurementStudioDemo.RangeChangedEventArgs) Handles SimpleRangeSelect1.RangeChanged
        ProcessImage()
    End Sub

    Public Sub ProcessImage()
        ' If the other form hasn't been initialized yet, do nothing.
        If form2 Is Nothing Then
            Return
        End If
        Dim beforeImage As VisionImage = form2.BeforeImage
        Dim afterImage As VisionImage = form2.AfterImage

        afterImage.Overlays.[Default].DefaultColor = Rgb32Value.GreenColor
        ' If an image is loaded
        If beforeImage.Width > 0 AndAlso beforeImage.Height > 0 Then
            ' Threshold the image.
            Algorithms.Threshold(beforeImage, afterImage, New Range(SimpleRangeSelect1.Minimum, SimpleRangeSelect1.Maximum))

            ' Perform the particle report operation
            Dim reports As Collection(Of ParticleReport) = Algorithms.ParticleReport(afterImage, IIf(connectivity4Button.Checked, Connectivity.Connectivity4, Connectivity.Connectivity8))

            ' Display the number of particles found
            numberOfParticles.Text = reports.Count.ToString()

            ' Overlay the information BasicParticle found.
            afterImage.Overlays.[Default].Clear()
            For Each report As ParticleReport In reports
                ' Overlay the bounding rectangle.
                afterImage.Overlays.[Default].AddRectangle(report.BoundingRect, Rgb32Value.GreenColor, DrawingMode.DrawValue)

                ' Overlay the particle area at user's request.
                If showParticleArea.Checked Then
                    afterImage.Overlays.[Default].AddText(String.Format("{0:0.00}", report.Area), New PointContour(report.BoundingRect.Left, report.BoundingRect.Top))
                End If
            Next
        End If
    End Sub

    ' If any inputs have changed, update the image
    Private Sub connectivity8Button_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles connectivity8Button.CheckedChanged
        ProcessImage()
    End Sub

    Private Sub connectivity4Button_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles connectivity4Button.CheckedChanged
        ProcessImage()
    End Sub

    Private Sub showParticleArea_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles showParticleArea.CheckedChanged
        ProcessImage()
    End Sub

    ' Click the Browse button to open the file dialog
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        openFileDialog1.FileName = imagePath.Text
        openFileDialog1.ShowDialog()
        If openFileDialog1.FileName <> "" Then
            imagePath.Text = openFileDialog1.FileName

            ' Load the image
            LoadSelectedImage()
        End If
    End Sub

    ' Click the Load Image button to read an image
    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        ' Load an image using ReadFile
        form2.BeforeImage.ReadFile(imagePath.Text)

        ' Histogram the image
        Dim report As HistogramReport = Algorithms.Histogram(form2.BeforeImage)
        Dim histogram As Integer() = New Integer(255) {}
        report.Histogram.CopyTo(histogram, 0)
        ' Convert the int[] to a double[], which the graph requires.
        Dim histogramDouble As Double() = Array.ConvertAll(Of Integer, Double)(histogram, AddressOf IntegerToDouble)
        SimpleRangeSelect1.PlotY(histogramDouble)

        ' Process the image
        ProcessImage()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub
    Private Function IntegerToDouble(ByVal i As Integer) As Double
        Return i
    End Function

End Class