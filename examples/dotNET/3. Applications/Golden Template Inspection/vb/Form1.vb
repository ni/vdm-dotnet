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
Imports NationalInstruments.Vision.WindowsForms

' Golden Template Inspection Example
'
' The objective of this golden template inspection example is to determine if a label
' has been printed correctly or if it contains defects.  The example uses pattern matching
' to locate the label in the image.  Then the example compares the label in the image to
' the golden template.  After removing small defects, if any defects remain in the image
' the label fails.  Optionally the example will display the location of the defects
' by manipulating the palette of the viewer control.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Inspection\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private lookupTable As New Collection(Of Short)()
    Private template As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Create the lookup table.
        lookupTable.Add(255)
        For i As Short = 1 To 255
            lookupTable.Add(i)
        Next

        ' Read the golden template file.
        template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"))

        ' Attach the template image to the viewer.
        imageViewer1.Attach(template)

        ' Enable the timer.
        timer1.Enabled = True
        timer1.Start()
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Locate the template in the image.
        Dim matchOptions As New MatchPatternOptions(MatchMode.RotationInvariant, 1)
        matchOptions.MinimumMatchScore = 500
        matchOptions.RotationAngleRanges.Add(New Range(-5, 5))
        Dim matches As Collection(Of PatternMatch) = Algorithms.MatchPattern(image, template, matchOptions)

        If matches.Count <> 1 Then
            ' If the template could not be located, the part fails.
            passFailLed.Value = False
        Else
            ' Perform the inspection
            Dim alignment As New InspectionAlignment(matches(0).Position, matches(0).Rotation)
            Dim inspectionOptions As New InspectionOptions()
            inspectionOptions.EdgeThicknessToIgnore = 1
            Using defectImage As New VisionImage()
                Algorithms.CompareGoldenTemplate(image, template, defectImage, alignment, inspectionOptions)

                ' Remove small defects from the image.
                Algorithms.RemoveParticle(defectImage, defectImage)

                ' If there are still defects in the image, the part does not pass inspection.
                If Algorithms.ParticleReport(defectImage).Count > 0 Then
                    passFailLed.Value = False
                Else
                    passFailLed.Value = True
                End If

                ' Make a custom palette that displays the defects of interest (dark defects
                ' are set to 1 in the defect image and bright defects are set to 2):
                ' 1. Set the value of all non-defect pixels in the defect image to 255.
                ' 2. Set all of the pixels with a value of 1 or 2 to zero in the inspected image.
                ' 3. Make the requested defects visible by modifying the palette for the Viewer
                ' control.  Start with a grayscale palette.  Then modify the palette for the
                ' defect values (1 or 2) by changing them to a visible color.
                ' 4. Merge the defect image with the inspected image and place the output in
                ' the image attached to the viewer.
                Algorithms.UserLookup(defectImage, defectImage, lookupTable)
                Algorithms.Max(image, New PixelValue(3), image)
                Dim palette As New Palette(PaletteType.Gray)
                If darkSwitch.Value Then
                    palette.Entries(1) = New PaletteEntry(255, palette.Entries(1).Green, palette.Entries(1).Blue)
                End If
                If brightSwitch.Value Then
                    palette.Entries(2) = New PaletteEntry(palette.Entries(2).Red, 255, palette.Entries(2).Blue)
                End If
                imageViewer2.Palette = palette
                Algorithms.Min(image, defectImage, image)
                imageViewer2.Attach(image)
            End Using

        End If

    End Sub
    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage()
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "NI_Label_" & [String].Format("{0:0000}", imageNumber) & ".jp2"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 11 Then
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