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

' Blister Pack Inspection Example
'
' This example uses color pattern matching with an ImageFeatureMode of Color
' to inspect pills inside a blister pack.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String
    Private imageNumber As Integer
    Private images As New Collection(Of VisionImage)()
    Private template As New VisionImage(ImageType.Hsl32)
    Private matchOptions As New MatchColorPatternOptions(MatchMode.ShiftInvariant, 12, ImageFeatureMode.Color, ColorSensitivity.Low)
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Get the image path
        imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Blister\")
        imageNumber = 0

        ' Load the template image.
        template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"))

        ' Set up the color pattern matching options
        matchOptions.ColorWeight = 300
        matchOptions.MinimumMatchScore = 500
        matchOptions.SearchStrategy = SearchStrategy.Aggressive

        ' Enable the timer
        timer1.Enabled = True
        timer1.Start()
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Start timing.
        Dim stopwatch As New System.Diagnostics.Stopwatch()
        stopwatch.Start()

        ' Match the template image in the current image.
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchColorPattern(image, template, matchOptions)

        ' Determine if this part passes or fails
        If matches.Count = matchOptions.NumberOfMatchesRequested Then
            ' All pills are present, so this part passes inspection.
            passFailLed.Value = True
        Else
            ' Some pills are missing, so this part fails inspection.
            passFailLed.Value = False
        End If

        ' Stop timing.
        stopwatch.[Stop]()
        timeTaken.Text = [String].Format("{0:0}", stopwatch.ElapsedMilliseconds)

        ' Display the results.
        matchesFound.Text = matches.Count.ToString()
        For Each match As PatternMatch In matches
            ' First draw the bounding box.
            image.Overlays.[Default].AddPolygon(New PolygonContour(match.Corners), Rgb32Value.RedColor)
            ' Now draw the center point.
            image.Overlays.[Default].AddOval(New OvalContour(match.Position.X - 5, match.Position.Y - 5, 11, 11), Rgb32Value.RedColor)
            ' Finally draw the crosshair.
            image.Overlays.[Default].AddLine(New LineContour(New PointContour(match.Position.X - 10, match.Position.Y), New PointContour(match.Position.X + 10, match.Position.Y)), Rgb32Value.RedColor)
            image.Overlays.[Default].AddLine(New LineContour(New PointContour(match.Position.X, match.Position.Y - 10), New PointContour(match.Position.X, match.Position.Y + 10)), Rgb32Value.RedColor)
        Next
        imageViewer1.Attach(image)
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage(ImageType.Hsl32)
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Blister " & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 14 Then
            imageNumber = 0
        End If
        Return toReturn
    End Function

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newDelay As Integer = CInt(DelaySlider1.Value)
        If newDelay = 0 Then
            newDelay = 1
        End If
        timer1.Interval = newDelay
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

End Class