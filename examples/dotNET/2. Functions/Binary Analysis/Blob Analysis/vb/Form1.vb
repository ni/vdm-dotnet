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

' Blob Analysis example
'
' This example performs a series of grayscale filtering, threshold, binary morphology,
' and blob analysis operations and measures the areas of all large circular particles
' in the image.

Partial Public Class Form1
    Inherits Form
    Private currentStep As Integer
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resetButton.Click
        ResetExample()
    End Sub

    Private Sub ResetExample()
        ' Clear the image from the viewer.
        imageViewer1.Image.SetSize(0, 0)

        ' Start over with the first step
        currentStep = 0
        steps.SelectedIndex = 0
    End Sub

    Private Sub steps_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles steps.SelectedIndexChanged
        ' Do not allow the user to change the step selected in the listbox
        steps.SelectedIndex = currentStep
    End Sub

    Private Sub runCurrentStepButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles runCurrentStepButton.Click
        ' Call the appropriate routine based on the current step.
        Select Case currentStep
            Case 0
                LoadSampleImage()
                Exit Select
            Case 1
                EnhanceEdgeInformation()
                Exit Select
            Case 2
                Threshold()
                Exit Select
            Case 3
                FillHolesInObjects()
                Exit Select
            Case 4
                RemoveObjectsTouchingTheBorder()
                Exit Select
            Case 5
                KeepRoundObjects()
                Exit Select
            Case 6
                MeasureObjectsAreas()
                Exit Select
        End Select
        ' Advance to the next step
        currentStep += 1
        If currentStep > 6 Then
            currentStep = 0
        End If
        ' Update the listbox.
        steps.SelectedIndex = currentStep
    End Sub

    Private Sub LoadSampleImage()
        ' Read the image and set the viewer's palette to Gray to display it properly
        imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "metal.jpg"))
        imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Gray
    End Sub

    Private Sub EnhanceEdgeInformation()
        ' Use convolution to sharpen the edges.
        Algorithms.Convolute(imageViewer1.Image, imageViewer1.Image, New Kernel(KernelFamily.Laplacian, 3, 5))
    End Sub

    Private Sub Threshold()
        ' Threshold the image and change the viewer's palette to Binary so the foreground of
        ' the image is visible.
        Algorithms.Threshold(imageViewer1.Image, imageViewer1.Image, New Range(150, 255))
        imageViewer1.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
    End Sub

    Private Sub FillHolesInObjects()
        ' Fill holes in particles
        Algorithms.FillHoles(imageViewer1.Image, imageViewer1.Image)
    End Sub

    Private Sub RemoveObjectsTouchingTheBorder()
        ' Remove particles touching the border
        Algorithms.RejectBorder(imageViewer1.Image, imageViewer1.Image)
    End Sub

    Private Sub KeepRoundObjects()
        ' Filter out all very small particles
        Algorithms.RemoveParticle(imageViewer1.Image, imageViewer1.Image, 1)

        ' Filter out non-circular particles
        Dim criteria As Collection(Of ParticleFilterCriteria) = New System.Collections.ObjectModel.Collection(Of ParticleFilterCriteria)()
        criteria.Add(New ParticleFilterCriteria(MeasurementType.HeywoodCircularityFactor, New Range(0, 1.06)))
        Algorithms.ParticleFilter(imageViewer1.Image, imageViewer1.Image, criteria)
    End Sub

    Private Sub MeasureObjectsAreas()
        ' Compute the full particle report.
        Dim reports As Collection(Of ParticleReport) = Algorithms.ParticleReport(imageViewer1.Image)

        ' Overlay the area of each particle.
        Dim options As New OverlayTextOptions()
        options.HorizontalAlignment = HorizontalTextAlignment.Center
        options.VerticalAlignment = VerticalTextAlignment.Bottom
        options.FontSize = 16
        For Each report As ParticleReport In reports
            imageViewer1.Image.Overlays.[Default].AddText([String].Format("{0}", report.Area), New PointContour(report.CenterOfMass.X, report.BoundingRect.Top), Rgb32Value.GreenColor, options)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        steps.SelectedIndex = 0
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub
End Class