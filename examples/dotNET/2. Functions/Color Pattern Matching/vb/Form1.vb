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

' Color Pattern Matching Example
'
' This example shows how to use the color pattern matching tools in NI Vision.
' Color pattern matching is the technique used to quickly locate known reference or
' fiducial patterns in an image.  Pattern matching is the key to many applications and
' can provide your application with information about the
' presence or absence, number, and location of the model within an image.
'
' Color pattern matching is used in three general application areas:
'
' * Alignment  - Determine the position and orientation of a known object by locating
'                features.  The features are used as points of reference on the object.
'
' * Gauging    - Measure lengths, diameters, angles, and other critical dimensions.  If
'                the measurements fall out of set tolerance levels then the component
'                is rejected.  Gauging sometimes is used in-line with the manufacturing
'                process and off-line with a sample of components to determine the quality
'                of a lot or batch of manufactured components.
'
' * Inspection - Detect simple flaws, such as missing parts or unreadable printing.
Partial Public Class Form1
    Inherits Form
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Put a default image in the text box.
        imagePath.Text = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "pcbcolor\pcbcolor-00.jpg")

        ' Initialize combo boxes
        matchModeBox.SelectedIndex = 0
        colorSensitivity.SelectedIndex = 2
        searchStrategy.SelectedIndex = 0
        matchFeatureMode.SelectedIndex = 0

        ' Set up both viewers to load color images.
        imageViewer1.Image.Type = ImageType.Rgb32
        imageViewer2.Image.Type = ImageType.Rgb32

        ' Choose the color for drawing regions.
        imageViewer1.Roi.Color = Rgb32Value.YellowColor
        imageViewer1.Roi.MaximumContours = 1
    End Sub

    Private Sub loadImageButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadImageButton.Click
        LoadSelectedImage()
    End Sub

    ' Load an image using ReadFile.
    Private Sub LoadSelectedImage()
        imageViewer1.Image.ReadFile(imagePath.Text)
        imageViewer1.Roi.Clear()
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Dim dialog As New ImagePreviewFileDialog()
        dialog.FileName = imagePath.Text
        If dialog.ShowDialog() = DialogResult.OK Then
            imagePath.Text = dialog.FileName
            LoadSelectedImage()
        End If
    End Sub

    ' When a region is available, the Learn button is enabled.
    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As NationalInstruments.Vision.WindowsForms.ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        If imageViewer1.Roi.Count > 0 Then
            learnPatternButton.Enabled = True
        Else
            learnPatternButton.Enabled = False
        End If
    End Sub

    ' Click the Learn button to learn the template.
    Private Sub learnPatternButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles learnPatternButton.Click
        Dim mode As MatchMode = DirectCast([Enum].Parse(GetType(MatchMode), DirectCast(matchModeBox.SelectedItem, String)), MatchMode)
        Dim featureMode As ImageFeatureMode = DirectCast([Enum].Parse(GetType(ImageFeatureMode), DirectCast(matchFeatureMode.SelectedItem, String)), ImageFeatureMode)
        If mode = MatchMode.RotationInvariant AndAlso featureMode = ImageFeatureMode.Color Then
            MessageBox.Show("Rotation-Invariant Color Pattern Matching requires a feature mode including shape", "Color Pattern Matching Error")
            Exit Sub
        End If
        learnPatternButton.Text = "Learning..."
        Update()

        ' Extract the region corresponding to the region of interest.
        Algorithms.Extract(imageViewer1.Image, imageViewer2.Image, imageViewer1.Roi)
        imageViewer1.Roi.Clear()

        ' Set up learn parameters.
        Dim learnOptions As New LearnColorPatternOptions(LearnMode.All, featureMode)

        ' Learn the template.
        Algorithms.LearnColorPattern(imageViewer2.Image, learnOptions)
        learnPatternButton.Text = "Learn Pattern"

        ' Enable the Match button and disable the Learn button.
        matchPatternButton.Enabled = True
        learnPatternButton.Enabled = False
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    ' Click the Match button to find the patterns in the image.  The results
    ' are then displayed using regions.
    Private Sub matchPatternButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles matchPatternButton.Click
        ' Get match input parameters.
        Dim matchOptions As New MatchColorPatternOptions()
        matchOptions.MatchMode = DirectCast([Enum].Parse(GetType(MatchMode), DirectCast(matchModeBox.SelectedItem, String)), MatchMode)
        matchOptions.MinimumMatchScore = CDbl(minimumScore.Value)
        matchOptions.NumberOfMatchesRequested = CInt(matchesRequested.Value)
        matchOptions.MinimumContrast = CInt(minimumContrast.Value)
        matchOptions.ColorWeight = CDbl(colorScoreWeight.Value)
        matchOptions.FeatureMode = DirectCast([Enum].Parse(GetType(ImageFeatureMode), DirectCast(matchFeatureMode.SelectedItem, String)), ImageFeatureMode)
        matchOptions.ColorSensitivity = DirectCast([Enum].Parse(GetType(ColorSensitivity), DirectCast(colorSensitivity.SelectedItem, String)), ColorSensitivity)
        matchOptions.SearchStrategy = DirectCast([Enum].Parse(GetType(SearchStrategy), DirectCast(searchStrategy.SelectedItem, String)), SearchStrategy)
        matchOptions.SubpixelAccuracy = subpixelAccuracy.Checked
        If matchOptions.MatchMode = MatchMode.RotationInvariant AndAlso matchOptions.FeatureMode = ImageFeatureMode.Color Then
            MessageBox.Show("Rotation-Invariant Color Pattern Matching requires a feature mode including shape", "Color Pattern Matching Error")
            Exit Sub
        End If

        ' Do the match.
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchColorPattern(imageViewer1.Image, imageViewer2.Image, matchOptions, imageViewer1.Roi)

        ' Display the matches.
        imageViewer1.Image.Overlays.[Default].Clear()
        For Each match As PatternMatch In matches
            ' First draw the bounding box.
            imageViewer1.Image.Overlays.[Default].AddPolygon(New PolygonContour(match.Corners), Rgb32Value.RedColor)
            ' Now draw the center point.
            imageViewer1.Image.Overlays.[Default].AddOval(New OvalContour(match.Position.X - 5, match.Position.Y - 5, 11, 11), Rgb32Value.RedColor)
            ' Finally draw the crosshair.
            imageViewer1.Image.Overlays.[Default].AddLine(New LineContour(New PointContour(match.Position.X - 10, match.Position.Y), New PointContour(match.Position.X + 10, match.Position.Y)), Rgb32Value.RedColor)
            imageViewer1.Image.Overlays.[Default].AddLine(New LineContour(New PointContour(match.Position.X, match.Position.Y - 10), New PointContour(match.Position.X, match.Position.Y + 10)), Rgb32Value.RedColor)
        Next

        matchesFound.Text = matches.Count
        learnPatternButton.Enabled = False
    End Sub
End Class