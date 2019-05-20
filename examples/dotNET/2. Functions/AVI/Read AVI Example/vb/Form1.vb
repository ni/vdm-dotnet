Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Read AVI Example
' This example loads in an AVI and displays it at its correct framerate.

Partial Public Class Form1
    Inherits Form
    Private session As AviInputSession = Nothing
    Private curFrame As UInteger
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Let user load in AVI file
        LoadAVI()
        curFrame = 0

        imageViewer1.Image.Type = ImageType.Rgb32

        ' Set up display
        progressBar1.Minimum = 0
        progressBar1.Maximum = CInt((session.Frames - 1))
        timer1.Interval = 1000 / CInt(session.FramesPerSecond)
        timer1.Enabled = True
    End Sub
    Private Sub LoadAVI()
        ' Load AVI file from dialog.
        openFileDialog1.InitialDirectory = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "AVIs")
        openFileDialog1.Filter = "AVI files (*.avi)|*.avi||"
        openFileDialog1.FileName = ""
        openFileDialog1.ShowDialog()
        If openFileDialog1.FileName <> "" Then
            session = New AviInputSession(openFileDialog1.FileName)
        End If

    End Sub

    ' Display the next frame in the AVI file
    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' End of AVI?
        If curFrame >= session.Frames Then
            session.Dispose()
            Application.[Exit]()
            Return
        End If

        ' Read the frame
        session.ReadFrame(imageViewer1.Image, curFrame)
        progressBar1.Value = CInt(curFrame)

        ' Increment frame
        curFrame += 1
    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitButton.Click
        Application.[Exit]()
    End Sub
End Class
