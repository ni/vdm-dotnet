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

' Pattern Matching Example
' 
' This example demonstrates how to use the NI Vision pattern matching tools. The pattern
' matching technique allows you to quickly locate known references or fiducial patterns
' in an image. Pattern matching is the key to many applications and can
' provide your application with information about the presence or absence, number,
' and location of the model within an image.
' 
' Pattern matching is used in three general applications areas:
' 
'   * Alignment  Determine the position and orientation of a known object by locating
'                features. The features serve as reference points on the object.
' 
'   * Gauging    Measure lengths, diameters, angles, and other critical dimensions. If
'                the measurements fall outside set tolerance levels, the component
'                is rejected. Gauging is sometimes used in-line with the manufacturing
'                process and off-line with a sample of components to determine the quality
'                of a lot or batch of manufactured components.
' 
'   * Inspection Detect simple flaws, such as missing parts or unreadable printing.

Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SetImagePath()
        MatchMode.SelectedIndex = 0
        imageViewerMain.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        AddHandler imageViewerMain.Roi.ContoursChanged, AddressOf Roi_ContoursChanged
    End Sub

    Private Sub Roi_ContoursChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs)
        learnPatternButton.Enabled = imageViewerMain.Roi.Count > 0
    End Sub

    Private Sub SetImagePath()
        If imagePath.Text = "" Then
            imagePath.Text = System.IO.Path.GetFullPath(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "pcb\pcb03-01.png"))
        End If
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadImage()
    End Sub

    Private Sub LoadImage()
        imageViewerMain.Image.ReadFile(imagePath.Text)
        imageViewerMain.Roi.Clear()
    End Sub

    Private Sub learnPatternButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles learnPatternButton.Click
        learnPatternButton.Text = "Learning..."
        ' Extract region corresponding to the region of interest in the image window
        Algorithms.Extract(imageViewerMain.Image, imageViewerPattern.Image, DirectCast(imageViewerMain.Roi(0).Shape, RectangleContour))
        imageViewerMain.Roi.Clear()

        ' Learn template
        Algorithms.LearnPattern(imageViewerPattern.Image)

        learnPatternButton.Text = "Learn Pattern"

        ' Enable the Match button and disable the Learn button
        learnPatternButton.Enabled = False
        matchPatternButton.Enabled = True
    End Sub

    Private Sub matchPatternButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles matchPatternButton.Click
        Dim options As New MatchPatternOptions(DirectCast((matchMode.SelectedIndex + 1), MatchMode), CInt(matchesRequested.Value))
        options.MinimumMatchScore = CInt(minimumScore.Value)
        options.MinimumContrast = CInt(minimumContrast.Value)
        options.SubpixelAccuracy = subpixelAccuracy.Checked

        ' Match
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchPattern(imageViewerMain.Image, imageViewerPattern.Image, options, imageViewerMain.Roi)

        ' Display results.
        imageViewerMain.Image.Overlays.[Default].Clear()
        For Each match As PatternMatch In matches
            imageViewerMain.Image.Overlays.[Default].AddPolygon(New PolygonContour(match.Corners), Rgb32Value.RedColor)
        Next
        matchesFound.Text = matches.Count.ToString()
        learnPatternButton.Enabled = False
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        openFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(imagePath.Text)
        openFileDialog1.FileName = System.IO.Path.GetFileName(imagePath.Text)
        openFileDialog1.ShowDialog()
        imagePath.Text = openFileDialog1.FileName

    End Sub

End Class