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

' This example demonstrates how to grab in-depth information about the particles found in
' an image.  Threshold separates particles in the image from the background.  ParticleReport
' retrieves the information about each particle.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private reports As New Collection(Of ParticleReport)()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        ' Load the image
        imageViewer1.Image.ReadFile(imagePath.Text)
        processButton.Enabled = True
    End Sub

    ' Click the Browse button to open the file dialog
    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        openFileDialog1.FileName = imagePath.Text
        If openFileDialog1.ShowDialog() <> DialogResult.Cancel Then
            imagePath.Text = openFileDialog1.FileName
        End If
    End Sub

    ' Click the Process button to separate the particles from an image and
    ' display the processed image.
    Private Sub processButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles processButton.Click
        ' Process the Threshold
        Algorithms.Threshold(imageViewer1.Image, imageViewer2.Image, New Range(minimumSlide.Value, maximumSlide.Value), True, 255)

        ' Get the particle reports
        reports = Algorithms.ParticleReport(imageViewer2.Image, IIf((connectivitySwitch.Value), Connectivity.Connectivity8, Connectivity.Connectivity4))

        ' display results
        numberOfParticles.Text = reports.Count.ToString()

        reportIndex.Value = 0
        reportIndex.Enabled = reports.Count > 0
        If reports.Count > 0 Then
            reportIndex.Maximum = reports.Count - 1
        End If
        DisplayReport(0)
    End Sub

    Private Sub DisplayReport(ByVal reportIndex As Integer)
        If reportIndex < 0 OrElse reportIndex >= reports.Count Then
            area.Text = "0"
            numberOfHoles.Text = "0"
            centerOfMassX.Text = "0"
            centerOfMassY.Text = "0"
            orientation.Text = "0"
            boundingRectLeft.Text = "0"
            boundingRectRight.Text = "0"
            boundingRectTop.Text = "0"
            boundingRectBottom.Text = "0"
            widthBox.Text = "0"
            heightBox.Text = "0"
            Return
        End If
        Dim report As ParticleReport = reports(reportIndex)
        area.Text = report.Area.ToString()
        numberOfHoles.Text = report.NumberOfHoles.ToString()
        centerOfMassX.Text = report.CenterOfMass.X.ToString()
        centerOfMassY.Text = report.CenterOfMass.Y.ToString()
        orientation.Text = report.Orientation.ToString()
        boundingRectLeft.Text = report.BoundingRect.Left.ToString()
        boundingRectTop.Text = report.BoundingRect.Top.ToString()
        widthBox.Text = report.BoundingRect.Width.ToString()
        heightBox.Text = report.BoundingRect.Height.ToString()
        boundingRectRight.Text = (report.BoundingRect.Left + report.BoundingRect.Width).ToString()
        boundingRectBottom.Text = (report.BoundingRect.Top + report.BoundingRect.Height).ToString()
    End Sub

    Private Sub reportIndex_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reportIndex.ValueChanged
        DisplayReport(reportIndex.Value)
    End Sub
End Class
