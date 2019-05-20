Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization.Formatters.Binary

' AVI Read Write With Data Example
'
' 1. Select the path to save the AVI. The AVI that is created will
'    have sample data associated with each image.
'
' 2. The sample Images, waveforms and time stamps will be acquired
'    and saved to the AVI during the Writing phase.
'
' 3. After the AVI is done being written, the AVI is read along with
'    the data associated with each image. Use the Frame and Data to
'    Examine slider to examine the various images in the AVI during
'    the reading phase.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Public Enum RunMode
    NotRunning = 0
    WritingFrames = 1
    ReadingFrames = 2
End Enum
Partial Public Class Form1
    Inherits Form
    Private mode As RunMode = RunMode.NotRunning
    Private form2 As Form2 = Nothing
    Private sourceSession As AviInputSession = Nothing
    Private destSession As AviOutputSession = Nothing
    Private numFrames As UInteger = 0
    Private curFrame As UInteger = 0
    Private frame As New VisionImage()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        form2 = New Form2(Me)
        form2.Show()
    End Sub

    Private Sub QuitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles QuitButton.Click
        If mode = RunMode.ReadingFrames Then
            If sourceSession IsNot Nothing Then
                sourceSession.Dispose()
            End If
        End If
        Application.[Exit]()
    End Sub

    Private Sub startButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startButton.Click
        ' Close AVI if it is open
        If mode <> RunMode.NotRunning Then
            form2.Graph.ClearGraph()
            form2.FrameNum.Enabled = False
            form2.FrameSlider.Enabled = False
            If sourceSession IsNot Nothing Then
                sourceSession.Dispose()
                sourceSession = Nothing
            End If
        End If

        ' Load base AVI
        sourceSession = New AviInputSession(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "AVIs\Flame.avi"))
        numFrames = sourceSession.Frames

        ' Create output AVI
        If Path.Text = "" Then
            Browse()
        End If
        destSession = New AviOutputSession(Path.Text, sourceSession.FramesPerSecond, Nothing, -1, True, 10000)

        ' Start writing
        statusLabel.Text = "Writing AVI File and Data"
        curFrame = 0
        mode = RunMode.WritingFrames
        frame.Type = ImageType.Rgb32
        imageViewer1.Attach(frame)
        timer1.Enabled = True
        startButton.Enabled = False
        stopButton.Enabled = True
    End Sub

    Shared sinPhase As Double
    Shared cosPhase As Double
    ' Sample Data creates a time stamp, waveform and image. The time stamp
    ' and waveform data are bundled together and flattened to a string.
    ' This data is saved with the image in an AVI so when the AVI image is
    ' read out later, the same data it was written with can also be
    ' retrieved.
    Private Sub SampleData(ByVal sourceSession As AviInputSession, ByVal destSession As AviOutputSession, ByVal frame As VisionImage, ByVal frameIndex As UInteger)
        ' Get and display  time
        Dim timestamp As String = DateTime.Now.ToString()
        form2.curTimeBox.Text = timestamp

        ' Read the frame
        sourceSession.ReadFrame(frame, frameIndex)

        ' Get and display sample waveforms
        Dim waves As Double() = New Double(2) {}
        waves(0) = 5 * Math.Sin(sinPhase)
        waves(1) = 4 * Math.Cos(cosPhase)
        waves(2) = (New Random()).NextDouble() * 6 - 3
        sinPhase += 0.1
        cosPhase += 0.15

        form2.Graph.AppendData(waves(0), waves(1), waves(2))

        Dim data As New AviData(timestamp, waves(0), waves(1), waves(2))
        ' Flatten data to buffer
        Dim bytes As Byte() = FlattenData(data)
        destSession.WriteFrame(frame, bytes)
    End Sub

    ' WriteFrame copies an AVI frame to a new location and adds timestamp
    ' and waveform data to the frame.  The frame is then displayed in the viewer
    ' and its data plotted on the graph.
    Private Sub WriteFrame(ByVal frameIndex As UInteger)
        SampleData(sourceSession, destSession, frame, frameIndex)
        Me.Refresh()
    End Sub


    ' UnflattenData breaks a data object containing a timestamp and three waveform numbers
    ' into its respective data.
    Private Function UnflattenData(ByVal data As Byte()) As AviData
        Dim memoryStream As New MemoryStream(data)
        Dim formatter As New BinaryFormatter()
        Return DirectCast(formatter.Deserialize(memoryStream), AviData)
    End Function
    ' FlattenData combines a timestamp and three waveform numbers into a
    ' byte[]. This allows the cluster of information to be written
    ' out together.
    Private Function FlattenData(ByVal data As AviData) As Byte()
        Dim formatter As New BinaryFormatter()
        Dim memoryStream As New MemoryStream()
        formatter.Serialize(memoryStream, data)
        Return memoryStream.GetBuffer()
    End Function

    ' ReadAllData reads in each frame's data and plots the resulting graph
    Private Sub ReadAllData()
        For frameIndex As UInteger = 0 To sourceSession.Frames - 1
            Dim data As Byte() = sourceSession.ReadFrame(imageViewer1.Image, frameIndex, True)

            ' Read the data
            Dim aviData As AviData = UnflattenData(data)

            ' Display results
            form2.curTimeBox.Text = aviData.TimeStamp
            form2.Graph.AppendData(aviData.SinWave, aviData.SquareWave, aviData.Noise)
            form2.Refresh()
        Next
    End Sub

    ' ReadFrame reads and displays the specified frame and its data
    Public Sub ReadFrame(ByVal frameIndex As UInteger)
        ' Read the frame
        Dim data As Byte() = sourceSession.ReadFrame(imageViewer1.Image, frameIndex, True)

        ' Read the data
        Dim aviData As AviData = UnflattenData(data)

        ' Display results
        form2.curTimeBox.Text = aviData.TimeStamp
        form2.Graph.CursorValue = CInt(frameIndex)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Done writing?
        If curFrame >= numFrames OrElse mode <> RunMode.WritingFrames Then
            ' Close AVIs
            sourceSession.Dispose()
            sourceSession = Nothing
            destSession.Dispose()
            destSession = Nothing

            ' Setup for reading AVI frames
            mode = RunMode.ReadingFrames
            startButton.Enabled = True
            stopButton.Enabled = False
            sourceSession = New AviInputSession(Path.Text)

            form2.Graph.SetupForReading(CInt(sourceSession.Frames))
            form2.FrameSlider.Enabled = True
            form2.FrameSlider.SetRangeFromAvi(sourceSession)
            form2.FrameNum.Enabled = True
            form2.FrameNum.Maximum = CInt(sourceSession.Frames) - 1

            ' Update display to reflect change in state
            statusLabel.Text = "Reading AVI File and Data"
            Me.Refresh()
            form2.Graph.ClearGraph()

            ReadAllData()
            ReadFrame(0)
            form2.Graph.DoneReading()
            timer1.Enabled = False
            Return
        End If

        ' Write the frame
        WriteFrame(curFrame)
        curFrame += 1
    End Sub

    Private Sub stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles stopButton.Click
        mode = RunMode.NotRunning
    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles browseButton.Click
        Browse()
    End Sub
    Private Sub Browse()
        saveFileDialog1.FileName = Path.Text
        saveFileDialog1.Title = "Name of AVI file to create"
        saveFileDialog1.Filter = "AVI files (*.avi)|*.avi||"
        saveFileDialog1.ShowDialog()
        If saveFileDialog1.FileName <> "" Then
            Path.Text = saveFileDialog1.FileName
        End If
    End Sub
End Class
' This class holds the data that is stored in the AVI.
<Serializable()> _
Public Class AviData
    Private _timeStamp As String
    Private _sinWave As Double
    Private _squareWave As Double
    Private _noise As Double

    Public Property Noise() As Double
        Get
            Return _noise
        End Get
        Set(ByVal value As Double)
            _noise = Value
        End Set
    End Property

    Public Property SquareWave() As Double
        Get
            Return _squareWave
        End Get
        Set(ByVal value As Double)
            _squareWave = Value
        End Set
    End Property

    Public Property SinWave() As Double
        Get
            Return _sinWave
        End Get
        Set(ByVal value As Double)
            _sinWave = Value
        End Set
    End Property

    Public Property TimeStamp() As String
        Get
            Return _timeStamp
        End Get
        Set(ByVal value As String)
            _timeStamp = Value
        End Set
    End Property
    Public Sub New(ByVal timeStamp As String, ByVal sinWave As Double, ByVal squareWave As Double, ByVal noise As Double)
        _timeStamp = timeStamp
        _sinWave = sinWave
        _squareWave = squareWave
        _noise = noise
    End Sub
End Class
