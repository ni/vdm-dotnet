Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Color Distance Example
'
' This example calculates the distance between two colors in the CIE
' colorspace.  The user selects two points in one image by using the
' point tool.  These two color values are then used to calculate and
' plot the distance.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Color cubes.jpg")

        ' Set up image buffers
        imageViewer1.Image.Type = ImageType.Rgb32
        imageViewer2.Image.Type = ImageType.Rgb32

        ' Load in and display the default image.
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.ZoomInfo.Initialize(0.5, 0.5)
        imageViewer1.Roi.MaximumContours = 2

        imageViewer2.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "CIE Color Space.png"))
        imageViewer2.RefreshImage()
        imageViewer2.Center.Initialize(85, 102)
    End Sub

    ' Click the browse button to open the file dialog.
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            ' Load the image.
            LoadSelectedImage()
        End If
    End Sub

    Private Sub LoadSelectedImage()
        ' Load an image using ReadFile.
        imageViewer1.Image.ReadFile(imagePath.Text)
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        DisplayColorDistance()
    End Sub

    ' DisplayColorDistance plots two points in the CIE colorspace and draws
    ' a line between these two points.
    Private Sub DisplayColorDistance()
        ' Only handle two points.
        If imageViewer1.Roi.Count <> 2 Then
            Exit Sub
        End If

        ' Get pixel values.
        Dim rgb32Value1 As Rgb32Value = imageViewer1.Image.GetPixel(TryCast(imageViewer1.Roi(0).Shape, PointContour)).Rgb32
        Dim rgb32Value2 As Rgb32Value = imageViewer1.Image.GetPixel(TryCast(imageViewer1.Roi(1).Shape, PointContour)).Rgb32

        ' Remove any previous overlays.
        imageViewer2.Image.Overlays.[Default].Clear()

        ' Transform to the correct colorspace.
        Dim cieXyzValue1 As CieXyzValue = Algorithms.ConvertColorValue(New ColorValue(rgb32Value1), ColorMode.CieXyz).CieXyz
        Dim cieXyzValue2 As CieXyzValue = Algorithms.ConvertColorValue(New ColorValue(rgb32Value2), ColorMode.CieXyz).CieXyz

        ' Calculate points.
        Dim sum1 As Double = cieXyzValue1.X + cieXyzValue1.Y + cieXyzValue1.Z
        If sum1 = 0.0R Then
            sum1 = 1
        End If
        Dim point1 As New PointContour(cieXyzValue1.Y / sum1 * 255, cieXyzValue1.X / sum1 * 255)
        Dim sum2 As Double = cieXyzValue2.X + cieXyzValue2.Y + cieXyzValue2.Z
        If sum2 = 0.0R Then
            sum2 = 1
        End If
        Dim point2 As New PointContour(cieXyzValue2.Y / sum2 * 255, cieXyzValue2.X / sum2 * 255)

        ' Display ovals around the points to make them more visible.
        imageViewer2.Image.Overlays.[Default].AddOval(New OvalContour(point1.X - 5, point1.Y - 5, 10, 10), Rgb32Value.BlackColor)
        imageViewer2.Image.Overlays.[Default].AddOval(New OvalContour(point2.X - 5, point2.Y - 5, 10, 10), Rgb32Value.BlackColor)

        ' Draw a line between the points.
        imageViewer2.Image.Overlays.[Default].AddLine(New LineContour(point1, point2), Rgb32Value.BlackColor)

        ' Calculate distance in CIE
        CalculateColorDistance(rgb32Value1, rgb32Value2)
    End Sub

    ' Calculates the distance between the two color values in the CIE colorspace.
    Private Sub CalculateColorDistance(ByVal rgb32Value1 As Rgb32Value, ByVal rgb32Value2 As Rgb32Value)
        ' Transform to the correct colorspace.
        Dim cieLabValue1 As CieLabValue = Algorithms.ConvertColorValue(New ColorValue(rgb32Value1), ColorMode.CieLab).CieLab
        Dim cieLabValue2 As CieLabValue = Algorithms.ConvertColorValue(New ColorValue(rgb32Value2), ColorMode.CieLab).CieLab

        ' Calculate distance in CIE.
        Dim distance As Double = Math.Pow(cieLabValue1.L - cieLabValue2.L, 2) + Math.Pow(cieLabValue1.A - cieLabValue2.A, 2) + Math.Pow(cieLabValue1.B - cieLabValue2.B, 2)
        distance = Math.Sqrt(distance)
        distanceTextBox.Text = [String].Format("{0:0.00}", distance)
    End Sub


    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub loadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadButton.Click
        LoadSelectedImage()
    End Sub
End Class