Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Classification Example
'
' This example demonstrates how to use the Classification functions and objects.
' The example loads in a classifier file that handles various parts.  The file is
' then used to classify images of parts loaded in by the user.

Partial Public Class Form1
    Inherits Form
    Private classifier As ColorClassifierSession
    Public Sub New()
        InitializeComponent()

        ' Set the correct image type Rgb32
        imageViewer1.Image.Type = ImageType.Rgb32
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Setup the default path for the classifier file and load it in.
        classifierPath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "ColorClassification\Color.clf")
        classifier = New ColorClassifierSession(classifierPath.Text)

        ' Setup the default path for images
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "ColorClassification")
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        openFileDialog1.InitialDirectory = classifierPath.Text
        openFileDialog1.FileName = ""
        openFileDialog1.Title = "Select a classifier file"
        openFileDialog1.DefaultExt = "*.clf"
        openFileDialog1.Filter = "*.clf|*.clf"

        ' Select the file
        Dim result As DialogResult = openFileDialog1.ShowDialog()
        ' Don't set the path if the user cancelled.
        If result = DialogResult.OK Then
            classifierPath.Text = openFileDialog1.FileName
            ' Read the classifier file.
            classifier.ReadFile(classifierPath.Text)
        End If

    End Sub

    ' loadButton_Click is called when the Load File button is pressed.
    ' The user is asked to load in an image to be used later in classification.
    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        Dim dialog As New ImagePreviewFileDialog

        ' Setup the image dialog
        dialog.InitialDirectory = imagePath.Text
        dialog.Title = "Choose an Image to Classify"
        ' Select the image.
        Dim result As DialogResult = dialog.ShowDialog()
        ' Load the file and display if not cancelled.
        If result = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            imageViewer1.Image.ReadFile(imagePath.Text)
            imageViewer1.Roi.Clear()
            classifyButton.Enabled = True
        End If
    End Sub

    ' classifyButton_Click is called when the Classify button is pressed. The
    ' classify file is read in and the currently-loaded image is classified. The
    ' class name and score are then displayed to the user.
    Private Sub classifyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles classifyButton.Click
        ' Classify the image.
        Try
            Dim report As ClassifierReport = classifier.Classify(imageViewer1.Image, imageViewer1.Roi)
            classBox.Text = report.BestClassName
            scoreBox.Text = report.ClassificationScore.ToString()
        Catch generatedExceptionName As VisionException
            ' Unable to classify image
            classBox.Text = "Unknown"
            scoreBox.Text = "0"
        End Try
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Application.Exit()
    End Sub
End Class