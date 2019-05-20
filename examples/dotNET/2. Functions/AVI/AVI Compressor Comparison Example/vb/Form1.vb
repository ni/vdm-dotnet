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

' AVI Compression Comparison Example

' This example creates a new AVI using each compressor installed on
' your machine and compares the size of the file, the average write
' times, and the quality of each compressor.  The uncompressed version
' is also included to provide a benchmark data point.

' This example will take a few seconds to create all the AVIs required
' for analysis.  These AVIs are saved to a folder named AVI Compressor
' Comparison Example under the same folder as this example.
Partial Public Class Form1
    Inherits Form
    Private filters As Collection(Of String)
    Private inputSession As AviInputSession
    Private curFilter As Integer = -1
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SetupTableHeaders()
        results.Columns.Add("Compressor", 150)
        results.Columns.Add("File Size (KB)", 80)
        results.Columns.Add("Avg Write Time (ms)", 120)
        results.Columns.Add("Quality (0 to 1000)", 110)
    End Sub

    Private Sub startButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startButton.Click
        ' Clear existing results.
        results.Clear()
        results.View = View.Details
        SetupTableHeaders()
        progressBar1.Value = 0

        ' Start running conversion tests.
        curFilter = -1
        timer1.Enabled = True
    End Sub

    Private Sub AddItem(ByVal filterName As String, ByVal fileSize As Double, ByVal averageFrameTime As Double, ByVal quality As Double)
        Dim item As New ListViewItem(filterName)
        item.SubItems.Add(Math.Round(fileSize, 2).ToString())
        item.SubItems.Add(Math.Round(averageFrameTime, 2).ToString())
        item.SubItems.Add(Math.Round(quality, 2).ToString())
        results.Items.Add(item)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadAviFilters()
        LoadAvi()
        DisplayAviInfo()

        SetupTableHeaders()
        ' Initialize progress bar
        progressBar1.Minimum = 0
        progressBar1.Maximum = filters.Count + 1
        progressBar1.Value = 0
    End Sub
    Private Sub LoadAviFilters()
        filters = AviOutputSession.GetCompressionFilters()
    End Sub

    Private Sub LoadAvi()
        openFileDialog1.InitialDirectory = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "AVIs")
        openFileDialog1.FileName = "CompressorComparison.avi"
        openFileDialog1.Filter = "AVI files (*.avi)|*.avi||"
        openFileDialog1.ShowDialog()
        If openFileDialog1.FileName <> "" Then
            inputSession = New AviInputSession(openFileDialog1.FileName)
        End If

        ' Create the temp directory.
        Try
            System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AVI Compressor Comparison Example"))
        Catch generatedExceptionName As Exception
        End Try
    End Sub

    Private Sub DisplayAviInfo()
        width.Text = inputSession.Width.ToString()
        height.Text = inputSession.Height.ToString()
        numFrames.Text = inputSession.Frames.ToString()
        compressionFilter.Text = inputSession.FilterName
    End Sub

    Private Sub GetFilterName(ByVal index As Integer, ByRef filterName As String, ByRef commonName As String, ByRef outputPath As String)
        If index < 0 OrElse index > filters.Count Then
            filterName = ""
            commonName = "Uncompressed"
        Else
            filterName = filters(index)
            commonName = filterName
        End If
        outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AVI Compressor Comparison Example\" + commonName + ".avi")
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Quit running conversions if no more filters
        If curFilter >= filters.Count Then
            timer1.Enabled = False
            Return
        End If

        Dim filterName As String, commonName As String, outputPath As String
        filterName = ""
        commonName = ""
        outputPath = ""
        GetFilterName(curFilter, filterName, commonName, outputPath)

        Dim averageFrameTime As Double
        ' Create compressed AVI file.
        Using outputSession As New AviOutputSession(outputPath, 30, filterName)
            ' Copy the frames from original AVI file to the compressed file.
            CopyAvi(inputSession, outputSession, averageFrameTime)
        End Using

        ' Calculate results of compression and write them to the table
        Dim fileSize As Long = New System.IO.FileInfo(outputPath).Length
        Dim quality As Double
        Using writtenSession As New AviInputSession(outputPath)
            quality = CompareAvi(inputSession, writtenSession)
        End Using

        AddItem(commonName, CDbl(fileSize) / 1024, averageFrameTime, quality)
        progressBar1.Value = progressBar1.Value + 1
        curFilter += 1
        Refresh()
    End Sub

    Private Sub CopyAvi(ByVal source As AviInputSession, ByVal dest As AviOutputSession, ByRef averageFrameTime As Double)
        Dim totalTime As Integer = 0

        ' Grab each frame.
        Dim frames As VisionImage() = New VisionImage(source.Frames - 1) {}
        For i As UInteger = 0 To source.Frames - 1
            frames(i) = New VisionImage(ImageType.Rgb32)
            source.ReadFrame(frames(i), i)
        Next

        ' Convert each frame.
        Dim startTime As Integer = System.Environment.TickCount
        For i As Integer = 0 To source.Frames - 1
            ' Write the frame.
            dest.WriteFrame(frames(i))
        Next
        totalTime = System.Environment.TickCount - startTime
        averageFrameTime = CDbl(totalTime) / source.Frames
    End Sub

    ' CompareAvi compares each frame of two images to calculate the average
    ' difference.  This is used to compare quality.
    Private Function CompareAvi(ByVal original As AviInputSession, ByVal other As AviInputSession) As Double
        Dim totalDiff As Double = 0
        Using firstImage As New VisionImage(), secondImage As New VisionImage()
            ' Setup the images to store the frames.
            firstImage.Type = ImageType.Rgb32
            secondImage.Type = ImageType.Rgb32
            For curFrame As UInteger = 0 To original.Frames - 1

                ' Calculate the difference between frames.
                ' Read the frames.
                original.ReadFrame(firstImage, curFrame)
                other.ReadFrame(secondImage, curFrame)

                ' Resize first image to be same as second if needed.
                If firstImage.Width <> secondImage.Width OrElse firstImage.Height <> secondImage.Height Then
                    Algorithms.Resample(firstImage, firstImage, secondImage.Width, secondImage.Height, InterpolationMethod.Bilinear)
                End If

                ' Calculate the difference between the frames.
                Algorithms.AbsoluteDifference(firstImage, secondImage, firstImage)
                Dim colorReport As ColorHistogramReport = Algorithms.ColorHistogram(firstImage, 256, ColorMode.Hsl)
                totalDiff += colorReport.Plane3.Mean
            Next
        End Using
        ' Calculate quality from difference
        totalDiff = totalDiff / CDbl(original.Frames)
        Dim quality As Double = 1000 - (totalDiff * 10)
        If quality < 0 Then
            quality = 0
        End If
        Return quality
    End Function

    Private Sub stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stopButton.Click
        timer1.Enabled = False
    End Sub

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub
End Class