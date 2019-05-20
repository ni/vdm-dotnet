Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Edge Based Geometric Matching Example
'
' This example demonstrates how to use the edge based Geometric Matching functions and objects.
' The example loads in a geometric matching template image that is used to search for similar parts 
' in images loaded in by the user.

Partial Public Class Form1
    Inherits Form
    Private matchOptions As New MatchGeometricPatternEdgeBasedOptions(GeometricMatchModes.ShiftInvariant, 1)

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub FindMatches()
        ' Match the template in the image

        If imageViewer.Image.Width = 0 Then
            Return
        End If
        ' Setup match options
        Dim curveOptions As New CurveOptions()
        Dim mode As GeometricMatchModes
        If rotationInvariant.Checked Then
            mode = GeometricMatchModes.RotationInvariant
        Else
            mode = GeometricMatchModes.ShiftInvariant
        End If
        If occlusionInvariant.Checked Then
            mode = mode Or GeometricMatchModes.OcclusionInvariant
        End If
        If scaleInvariant.Checked Then
            mode = mode Or GeometricMatchModes.ScaleInvariant
        End If
        matchOptions.Mode = mode
        matchOptions.Advanced.MatchStrategy = GeometricMatchingSearchStrategy.Balanced
        matchOptions.SubpixelAccuracy = False
        matchOptions.RotationAngleRanges.Add(New Range(0, 360))
        matchOptions.NumberOfMatchesRequested = CInt(numMatches.Value)
        matchOptions.MinimumMatchScore = CDbl(minScore.Value)

        ' Match
        Dim matches As Collection(Of GeometricEdgeBasedPatternMatch) = Algorithms.MatchGeometricPatternEdgeBased(imageViewer.Image, templateImageViewer.Image, curveOptions, matchOptions, imageViewer.Roi)

        ' Display results
        imageViewer.Image.Overlays.[Default].Clear()
        For Each match As GeometricEdgeBasedPatternMatch In matches
            imageViewer.Image.Overlays.[Default].AddPolygon(New PolygonContour(match.Corners), Rgb32Value.RedColor)

        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Set image type to be U8
        templateImageViewer.Image.Type = ImageType.U8
        imageViewer.Image.Type = ImageType.U8

        ' Setup the default path for the classifier file and load it in.
        templatePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Geometric Matching\Template.png")
        ' Read the template file and load it into the template viewer image
        templateImageViewer.Image.ReadVisionFile(templatePath.Text)
        ' Setup the default path for images
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Geometric Matching")
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        openFileDialog1.InitialDirectory = templatePath.Text
        openFileDialog1.FileName = ""
        openFileDialog1.Title = "Select a geometric matching template file"
        openFileDialog1.DefaultExt = "*.png"
        openFileDialog1.Filter = "*.png|*.png"

        ' Select the file
        Dim result As DialogResult = openFileDialog1.ShowDialog()
        ' Don't set the path if the user cancelled.
        If result = DialogResult.OK Then
            templatePath.Text = openFileDialog1.FileName
            ' Read the template file and load it into the template image
            templateImageViewer.Image.ReadVisionFile(templatePath.Text)

        End If
    End Sub

    ' loadButton_Click is called when the Load File button is pressed.
    ' The user is asked to load in an image to be used later in classification.
    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        ' Setup the image dialog
        dialog.InitialDirectory = imagePath.Text
        dialog.Title = "Choose an Image to search patterns in"
        ' Select the image.
        Dim result As DialogResult = dialog.ShowDialog()
        ' Load the file and display if not cancelled.
        If result = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            imageViewer.Image.ReadFile(imagePath.Text)
            imageViewer.Roi.Clear()
            searchButton.Enabled = True
        End If
    End Sub

    ' searchButton_Click is called when the Search button is pressed. 
    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles searchButton.Click
        FindMatches()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub numMatches_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numMatches.ValueChanged
        FindMatches()
    End Sub

    Private Sub rotationInvariant_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rotationInvariant.CheckedChanged
        FindMatches()
    End Sub

    Private Sub scaleInvariant_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles scaleInvariant.CheckedChanged
        FindMatches()
    End Sub

    Private Sub occlusionInvariant_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles occlusionInvariant.CheckedChanged
        FindMatches()
    End Sub


    Private Sub imageViewer_RoiChanged(ByVal sender As System.Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer.RoiChanged
        FindMatches()
    End Sub
End Class

