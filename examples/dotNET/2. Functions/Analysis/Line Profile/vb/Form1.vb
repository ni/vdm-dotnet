Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports NationalInstruments.Vision.WindowsForms

' Line Profile Example
'
' This example demonstrates how to use the display tools to draw a line on 
' an image to display the line's pixel values (line profile).  Line profiles are
' typically used in inspection and gauging tasks to find the edges of the object
' being inspected.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub LineProfile()
        ' Perform the line profile
        Dim report As LineProfileReport = Algorithms.LineProfile(imageViewer1.Image, imageViewer1.Roi)
        countBox.Text = report.ProfileData.Count.ToString()

        ' Graph the line profile.
        Dim profileData As Double() = New Double(report.ProfileData.Count - 1) {}
        report.ProfileData.CopyTo(profileData, 0)
        SimpleGraph1.PlotY(profileData)

        ' Display the results
        minimumBox.Text = report.PixelRange.Minimum.ToString()
        maximumBox.Text = report.PixelRange.Maximum.ToString()
        meanBox.Text = report.Mean.ToString()
        stdDevBox.Text = report.StandardDeviation.ToString()
    End Sub

    Private Sub LoadImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        ' Remove the Roi on the viewer.
        imageViewer1.Roi.Clear()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Alu.bmp")
        openFileDialog1.InitialDirectory = ExampleImagesFolder.GetExampleImagesFolder()
        imageViewer1.Roi.MaximumContours = 1
        imageViewer1.ToolsShown = ViewerTools.Line Or ViewerTools.Pan Or ViewerTools.Selection Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut
        imageViewer1.ActiveTool = ViewerTools.Line
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            imagePath.Text = openFileDialog1.FileName
            LoadImage()
        End If
    End Sub

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadButton.Click
        LoadImage()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 Then
            LineProfile()
        End If

    End Sub
End Class
