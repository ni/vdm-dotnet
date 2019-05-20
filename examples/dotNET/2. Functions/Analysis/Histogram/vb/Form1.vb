Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Histogram example
'
' This example demonstrates how to compute the histogram of a region of interest (ROI).
' The example also demonstrates how to set up and use the display tools to interactively
' select and work on different regions in the image.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.Roi.Clear()
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        openFileDialog1.FileName = imagePath.Text
        openFileDialog1.ShowDialog()
        If openFileDialog1.FileName <> "" Then
            imagePath.Text = openFileDialog1.FileName
            ' Load the image
            LoadSelectedImage()
        End If
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        SimpleGraph1.ClearData()
        ' Compute the histogram of the regions selected
        If imageViewer1.Roi.Count > 0 Then
            Using mask As New VisionImage()
                ' Find the histogram of a portal of the image in imageViewer1
                ' defined by the Roi of imageViewer1.
                Algorithms.RoiToMask(mask, imageViewer1.Roi)
                Dim report As HistogramReport = Algorithms.Histogram(imageViewer1.Image, 256, New Range(0, 255), mask)

                ' Plot the histogram on the graph
                Dim histogram As Integer() = New Integer(255) {}
                report.Histogram.CopyTo(histogram, 0)
                ' Convert the int[] to a double[], which the graph requires.
                Dim histogramDouble As Double() = Array.ConvertAll(Of Integer, Double)(histogram, AddressOf IntToDouble)
                SimpleGraph1.PlotY(histogramDouble)
            End Using
        End If
    End Sub
    Private Function IntToDouble(ByVal i As Integer) As Double
        Return i
    End Function

End Class
