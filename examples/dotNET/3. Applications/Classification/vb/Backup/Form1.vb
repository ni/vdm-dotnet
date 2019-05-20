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

' Classification example
'
' The objective of this classification example is to identify various parts in
' an image.  The example uses particle analysis to find the parts, classifies them,
' then overlays the class name on the image.  A histogram of the number of parts in the
' image is also shown.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imageNumber As Integer
    Private images As New Collection(Of VisionImage)()
    Private imagePath As String
    Private classifier As ParticleClassifierSession


    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Get the image path
        imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Parts")
        imageNumber = 0

        ' Read the classifier file
        classifier = New ParticleClassifierSession(System.IO.Path.Combine(imagePath, "Parts.clf"))

        ' Enable the timer
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub DelaySlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelaySlider1.ValueChanged
        Dim newInterval As Integer = CInt(DelaySlider1.Value)
        timer1.Interval = IIf(newInterval <> 0, newInterval, 1)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        Dim classCount As Double() = New Double(7) {}
        Dim textOptions As New OverlayTextOptions("Arial", 14)
        textOptions.HorizontalAlignment = HorizontalTextAlignment.Center

        ' Get the next image
        GetNextImage(imageViewer1.Image)

        ' Process the image
        Dim binaryImage As New VisionImage()
        Algorithms.Threshold(imageViewer1.Image, binaryImage, New Range(0, 200))
        Algorithms.RejectBorder(binaryImage, binaryImage)
        Dim reports As Collection(Of ParticleReport) = Algorithms.ParticleReport(binaryImage)
        For Each report As ParticleReport In reports
            Dim contour As RectangleContour = report.BoundingRect
            contour.Left -= 10
            contour.Top -= 10
            contour.Height += 20
            contour.Width += 20

            ' Classify the part
            Dim classifierReport As ClassifierReport = classifier.Classify(binaryImage, New Roi(New Shape() {contour}))

            ' Display the result
            If classifierReport.ClassificationScore > 500 Then
                textOptions.BackgroundColor = Rgb32Value.TransparentColor
                Dim classIndex As Integer = 0
                Dim textColor As Rgb32Value = Rgb32Value.BlackColor
                Select Case classifierReport.BestClassName
                    Case "Motor"
                        textColor = Rgb32Value.WhiteColor
                        classIndex = 0
                        Exit Select
                    Case "Bolt"
                        textColor = New Rgb32Value(Color.Cyan)
                        classIndex = 1
                        Exit Select
                    Case "Screw"
                        textColor = Rgb32Value.RedColor
                        classIndex = 2
                        Exit Select
                    Case "Gear"
                        textColor = Rgb32Value.BlackColor
                        classIndex = 3
                        Exit Select
                    Case "Washer"
                        textColor = New Rgb32Value(Color.Magenta)
                        classIndex = 4
                        Exit Select
                    Case "Worm Gear"
                        textColor = Rgb32Value.GreenColor
                        classIndex = 5
                        Exit Select
                    Case "Bracket"
                        textColor = New Rgb32Value(128, 128, 0)
                        classIndex = 6
                        Exit Select
                End Select
                classCount(classIndex) += 1
                imageViewer1.Image.Overlays.[Default].AddText(classifierReport.BestClassName, report.CenterOfMass, textColor, textOptions)
            Else
                textOptions.BackgroundColor = Rgb32Value.BlackColor

                imageViewer1.Image.Overlays.[Default].AddText("Unknown!", report.CenterOfMass, Rgb32Value.RedColor, textOptions)
            End If
        Next
        ClassificationGraph1.PlotClassifier(classCount)

    End Sub

    Private Sub GetNextImage(ByVal dest As VisionImage)
        Dim nextImage As VisionImage
        ' Load an image or return to the previous image
        If imageNumber >= images.Count Then
            nextImage = New VisionImage()
            nextImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Parts\Parts0" + imageNumber.ToString() + ".png"))
            images.Add(nextImage)
        Else
            nextImage = images(imageNumber)
            ' Clear any overlays.
            nextImage.Overlays.[Default].Clear()
        End If
        ' Copy the image to the destination image
        Algorithms.Copy(nextImage, dest)

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 4 Then
            imageNumber = 0
        End If
    End Sub

End Class