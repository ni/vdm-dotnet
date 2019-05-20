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

' OCR Example

' This example demostrates how to use NI Vision to read text.
' This example also demonstrates the use of the OcrSession constructor
' to read a character set and the associated options from
' a previously saved character set file.

Partial Public Class Form1
    Inherits Form
    Private images As New Collection(Of VisionImage)()
    Private imageNumber As Integer
    Private curImage As New VisionImage()
    Private session As OcrSession = Nothing
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim imageDirPath As String = GetPath()

        ' Read the character set and options from the character set file "Lot Number.abc"
        session = New OcrSession(imageDirPath + "\Lot Number.abc")
        For Each file As String In System.IO.Directory.GetFiles(imageDirPath, "*.bmp")
            Dim image As New VisionImage()
            image.ReadFile(file)
            images.Add(image)
        Next

        ' Attach the image to the viewer
        imageViewer1.Attach(curImage)
        imageNumber = 0
        timer1.Enabled = False
        timer1.Interval = CInt(delay.Value)
    End Sub

    Private Function GetPath() As String
        Return System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "OCR\Sample Set 2")
    End Function

    Public Function GetNextImage() As VisionImage
        Dim nextImage As VisionImage = images(imageNumber)
        ' Clear any existing overlays.
        nextImage.Overlays.[Default].Clear()

        ' Copy the image to the user's image
        Algorithms.Copy(nextImage, curImage)

        ' Advance the image number to the next image.
        imageNumber += 1
        If imageNumber >= images.Count Then
            imageNumber = 0
        End If
        Return curImage
    End Function

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        Dim image As VisionImage = GetNextImage()

        Dim report As ReadTextReport = session.ReadText(image)
        readTextBox.Text = report.ReadString
        For Each ch As CharacterReport In report.CharacterReports
            image.Overlays.[Default].AddRectangle(ch.CharacterStatistics.BoundingRectangle)
        Next
    End Sub

    Private Sub startReadingButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startReadingButton.Click
        timer1.Enabled = True
    End Sub

    Private Sub pauseReadingButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pauseReadingButton.Click
        timer1.Enabled = False
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Sub delay_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles delay.ValueChanged
        timer1.Interval = CInt(delay.Value)
    End Sub
End Class