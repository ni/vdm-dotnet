Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Image to Array Example

' This example demonstrates how to convert an image into a two-dimensional array.  By
' converting an image to an array, you can apply .NET functions to the image data.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
        imageViewer1.Roi.MaximumContours = 1
    End Sub

    Private Sub DoImageToArray()
        ' Get the point from the viewer.
        Dim point As PointContour = TryCast(imageViewer1.Roi(0).Shape, PointContour)
        If point IsNot Nothing Then
            ' Get the pixel data in a 7x7 region surrounding the point on the viewer.
            Dim rectangle As New RectangleContour(point.X - 3, point.Y - 3, 7, 7)
            Dim pixelValues As Byte(,) = imageViewer1.Image.ImageToArray(rectangle).U8

            ' Display the data
            textBox1.Text = [String].Format("{0:0}", pixelValues(0, 0))
            textBox2.Text = [String].Format("{0:0}", pixelValues(0, 1))
            textBox3.Text = [String].Format("{0:0}", pixelValues(0, 2))
            textBox4.Text = [String].Format("{0:0}", pixelValues(0, 3))
            textBox5.Text = [String].Format("{0:0}", pixelValues(0, 4))
            textBox6.Text = [String].Format("{0:0}", pixelValues(0, 5))
            textBox7.Text = [String].Format("{0:0}", pixelValues(0, 6))
            textBox8.Text = [String].Format("{0:0}", pixelValues(1, 0))
            textBox9.Text = [String].Format("{0:0}", pixelValues(1, 1))
            textBox10.Text = [String].Format("{0:0}", pixelValues(1, 2))
            textBox11.Text = [String].Format("{0:0}", pixelValues(1, 3))
            textBox12.Text = [String].Format("{0:0}", pixelValues(1, 4))
            textBox13.Text = [String].Format("{0:0}", pixelValues(1, 5))
            textBox14.Text = [String].Format("{0:0}", pixelValues(1, 6))
            textBox15.Text = [String].Format("{0:0}", pixelValues(2, 0))
            textBox16.Text = [String].Format("{0:0}", pixelValues(2, 1))
            textBox17.Text = [String].Format("{0:0}", pixelValues(2, 2))
            textBox18.Text = [String].Format("{0:0}", pixelValues(2, 3))
            textBox19.Text = [String].Format("{0:0}", pixelValues(2, 4))
            textBox20.Text = [String].Format("{0:0}", pixelValues(2, 5))
            textBox21.Text = [String].Format("{0:0}", pixelValues(2, 6))
            textBox22.Text = [String].Format("{0:0}", pixelValues(3, 0))
            textBox23.Text = [String].Format("{0:0}", pixelValues(3, 1))
            textBox24.Text = [String].Format("{0:0}", pixelValues(3, 2))
            textBox25.Text = [String].Format("{0:0}", pixelValues(3, 3))
            textBox26.Text = [String].Format("{0:0}", pixelValues(3, 4))
            textBox27.Text = [String].Format("{0:0}", pixelValues(3, 5))
            textBox28.Text = [String].Format("{0:0}", pixelValues(3, 6))
            textBox29.Text = [String].Format("{0:0}", pixelValues(4, 0))
            textBox30.Text = [String].Format("{0:0}", pixelValues(4, 1))
            textBox31.Text = [String].Format("{0:0}", pixelValues(4, 2))
            textBox32.Text = [String].Format("{0:0}", pixelValues(4, 3))
            textBox33.Text = [String].Format("{0:0}", pixelValues(4, 4))
            textBox34.Text = [String].Format("{0:0}", pixelValues(4, 5))
            textBox35.Text = [String].Format("{0:0}", pixelValues(4, 6))
            textBox36.Text = [String].Format("{0:0}", pixelValues(5, 0))
            textBox37.Text = [String].Format("{0:0}", pixelValues(5, 1))
            textBox38.Text = [String].Format("{0:0}", pixelValues(5, 2))
            textBox39.Text = [String].Format("{0:0}", pixelValues(5, 3))
            textBox40.Text = [String].Format("{0:0}", pixelValues(5, 4))
            textBox41.Text = [String].Format("{0:0}", pixelValues(5, 5))
            textBox42.Text = [String].Format("{0:0}", pixelValues(5, 6))
            textBox43.Text = [String].Format("{0:0}", pixelValues(6, 0))
            textBox44.Text = [String].Format("{0:0}", pixelValues(6, 1))
            textBox45.Text = [String].Format("{0:0}", pixelValues(6, 2))
            textBox46.Text = [String].Format("{0:0}", pixelValues(6, 3))
            textBox47.Text = [String].Format("{0:0}", pixelValues(6, 4))
            textBox48.Text = [String].Format("{0:0}", pixelValues(6, 5))
            textBox49.Text = [String].Format("{0:0}", pixelValues(6, 6))
        End If
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadSelectedImage()
        End If
    End Sub

    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)

        ' If regions are on the viewer, update the array data
        If imageViewer1.Roi.Count > 0 Then
            DoImageToArray()
        End If
    End Sub

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub quitbutton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitbutton.Click
        Application.[Exit]()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 Then
            DoImageToArray()
        End If
    End Sub
End Class