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

' Circle Distance Example
'
' The objective of this gauging example is to measure distances between the circular
' holes on a part that contains both circular and square holes.  The part is imaged using
' a back light so that the holes and the background appear as white regions,
' while the part itself appears black.  Blob analysis detects and isolates the
' circular holes in the part, and then computes the distances between the center
' of mass of each detected hole.  An automatic thresholding technique detects all white
' regions in the image (including the holes and the background), and the Heywood
' circularity factor determines if a particle is circular or not.  The Heywood
' circularity parameter has a value close to one for circular regions.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Holes.tif")
    End Sub

    ' The function that does the actual circle computation.
    Private Sub ComputeCircles()
        ' Perform the operation only if an image has been loaded.
        If imageViewer1.Image.Width > 0 Then
            ' Automatic threshold of the image
            Using image As New VisionImage()
                Algorithms.AutoThreshold(imageViewer1.Image, image, 2, ThresholdMethod.Entropy)

                ' Extract the shape descriptors.
                Dim particleMeasurements As Double(,) = Algorithms.ParticleMeasurements(image, New Collection(Of MeasurementType)(New MeasurementType() {MeasurementType.HeywoodCircularityFactor, MeasurementType.CenterOfMassX, MeasurementType.CenterOfMassY})).PixelMeasurements

                ' Keep circular parts using the Heywood circularity factor.
                Dim centers As New Collection(Of PointContour)()
                Dim minimumHeywoodValue As Double = CDbl(minimumHeywood.Value)
                For i As Integer = 0 To particleMeasurements.GetLength(0) - 1
                    If particleMeasurements(i, 0) < minimumHeywoodValue Then
                        centers.Add(New PointContour(particleMeasurements(i, 1), particleMeasurements(i, 2)))
                    End If
                Next

                ' Compute and draw distances between circular parts.
                DisplayResults(centers)
            End Using
        End If
    End Sub

    ' Displays the results by overlaying lines connecting the centers of the circles.
    Private Sub DisplayResults(ByVal centers As Collection(Of PointContour))
        ' Clear any overlays.
        imageViewer1.Image.Overlays.[Default].Clear()

        If centers.Count > 0 Then
            ' Draw the polygon.
            imageViewer1.Image.Overlays.[Default].AddPolygon(New PolygonContour(centers), Rgb32Value.RedColor, DrawingMode.DrawValue)

            ' Copy the first point to the end.
            centers.Add(centers(0))

            ' Label the distance of each line.
            For i As Integer = 0 To centers.Count - 2
                DisplayDistance(centers(i), centers(i + 1))
            Next
        End If

    End Sub

    Private Sub DisplayDistance(ByVal point1 As PointContour, ByVal point2 As PointContour)
        Dim points As New Collection(Of PointContour)(New PointContour() {point1, point2})
        Dim distance As Double = Algorithms.FindPointDistances(points)(0)
        Dim textOptions As New OverlayTextOptions()
        textOptions.FontSize = 14
        textOptions.BackgroundColor = Rgb32Value.WhiteColor
        textOptions.HorizontalAlignment = HorizontalTextAlignment.Center
        imageViewer1.Image.Overlays.[Default].AddText([String].Format("{0:0.00}", distance), New PointContour((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2), Rgb32Value.BlackColor, textOptions)
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    Private Sub LoadSelectedImage()
        ' Read the image
        imageViewer1.Image.ReadFile(imagePath.Text)

        ' Enable the Process Image button
        processImageButton.Enabled = True
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadSelectedImage()
        End If
    End Sub

    Private Sub processImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles processImageButton.Click
        ComputeCircles()
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub minimumHeywood_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles minimumHeywood.ValueChanged
        ' Compute the circle information.
        ComputeCircles()
    End Sub
End Class