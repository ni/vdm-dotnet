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
Imports NationalInstruments.Vision.MeasurementStudioDemo

' Rotating Part Example
'
' This example shows inspection of a rotating brake drum.  The inspection task
' is to determine if the brake drum contains all holes required for proper
' mounting.  To perform the inspection, the example uses edge detection and a function
' that tracks objects that undergo pure rotation.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private imagePath As String = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Rotate\")
    Private imageNumber As Integer = 0
    Private images As New Collection(Of VisionImage)()
    Private testLines As New Roi()
    Private simpleEdgeOptions As SimpleEdgeOptions
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Do not delete new lines that the user places.
        imageViewer1.AutoDelete = False
        EnableRoiSelection()

        ' Limit the number of regions to 5.
        imageViewer1.Roi.MaximumContours = 5

        ' Set up the edge options.
        simpleEdgeOptions = New SimpleEdgeOptions()
        simpleEdgeOptions.Threshold = 200

        ' Display the first image.
        imageViewer1.Attach(GetNextImage())
    End Sub

    Private Sub imageViewer1_RoiChanged(ByVal sender As Object, ByVal e As ContoursChangedEventArgs) Handles imageViewer1.RoiChanged
        ' Enable the Test Parts button if at least one region is selected.
        testPartsButton.Enabled = imageViewer1.Roi.Count > 0

        ' Update the target display.
        For i As Integer = 0 To imageViewer1.Roi.Count - 1
            ' Enable the indicators.
            GetExpectedTextBox(i).Enabled = True
            GetActualTextBox(i).Enabled = True
            GetPassFailLed(i).Enabled = True
            GetPassFailLed(i).LedColorMode = PassFailLed.ColorMode.RedGreen

            ' Find the number of edges along the line.  This is the expected
            ' number of edges.
            Dim linePoints As Collection(Of PointContour) = Algorithms.GetPointsOnLine(DirectCast(imageViewer1.Roi(i).Shape, LineContour))
            Dim edges As Collection(Of PointContour) = Algorithms.SimpleEdge(imageViewer1.Image, linePoints, simpleEdgeOptions)
            GetExpectedTextBox(i).Text = edges.Count.ToString()

        Next
        For i As Integer = imageViewer1.Roi.Count To 4
            ' Disable the indicators.
            GetExpectedTextBox(i).Text = "0"
            GetExpectedTextBox(i).Enabled = False
            GetActualTextBox(i).Text = "0"
            GetActualTextBox(i).Enabled = False
            GetPassFailLed(i).Enabled = False
            GetPassFailLed(i).LedColorMode = PassFailLed.ColorMode.RedGray
        Next
    End Sub

    Private Sub testPartsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles testPartsButton.Click
        ' Save the regions on the viewer.
        testLines.Clear()
        For Each c As Contour In imageViewer1.Roi
            testLines.Add(c.Shape)
        Next

        ' Clear the viewer regions and disable the Test Parts button.
        imageViewer1.Roi.Clear()
        DisableRoiSelection()
        testPartsButton.Enabled = False
        resetButton.Enabled = True

        ' Enable the timer.
        timer1.Enabled = True
        timer1_Tick(timer1, EventArgs.Empty)
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image.
        Dim image As VisionImage = GetNextImage()

        ' Look for rotational shift in the image.
        Dim imageCenter As New PointContour(image.Width / 2.0R, image.Height / 2.0R)
        Dim angle As Double = Algorithms.DetectRotation(images(0), image, imageCenter, imageCenter, CInt((0.475 * image.Width)))

        ' Transform the regions of interest.
        Dim transform As New CoordinateTransform(New CoordinateSystem(imageCenter), New CoordinateSystem(imageCenter, angle))
        ' Copy to a new Roi so we don't lose the information.
        Dim transformedRoi As New Roi(testLines)
        Algorithms.TransformRoi(transformedRoi, transform)

        ' Find the actual number of edges along each line in the image.
        Dim allTargetsPassed As Boolean = True
        For i As Integer = 0 To transformedRoi.Count - 1
            Dim linePoints As Collection(Of PointContour) = Algorithms.GetPointsOnLine(DirectCast(transformedRoi(i).Shape, LineContour))
            Dim edges As Collection(Of PointContour) = Algorithms.SimpleEdge(image, linePoints, simpleEdgeOptions)

            ' Display the results.
            GetActualTextBox(i).Text = edges.Count.ToString()
            For Each pt As PointContour In edges
                image.Overlays.[Default].AddOval(New OvalContour(pt.X - 2, pt.Y - 2, 5, 5), Rgb32Value.YellowColor, DrawingMode.PaintValue)
            Next

            If Int32.Parse(GetExpectedTextBox(i).Text) = edges.Count Then
                ' Part passes.
                GetPassFailLed(i).Value = True
                image.Overlays.[Default].AddLine(DirectCast(transformedRoi(i).Shape, LineContour), Rgb32Value.GreenColor)
            Else
                ' Part fails.
                GetPassFailLed(i).Value = False
                image.Overlays.[Default].AddLine(DirectCast(transformedRoi(i).Shape, LineContour), Rgb32Value.RedColor)
            End If
            allTargetsPassed = allTargetsPassed AndAlso GetPassFailLed(i).Value
        Next
        globalPassFailLed.Value = allTargetsPassed
        ' Overlay the outside circle of the part.
        Dim outsideOval As New OvalContour(image.Width * 0.025, image.Height * 0.025, image.Width * 0.95, image.Height * 0.95)
        image.Overlays.[Default].AddOval(outsideOval, IIf(allTargetsPassed, Rgb32Value.GreenColor, Rgb32Value.RedColor))

        imageViewer1.Attach(image)
    End Sub

    Private Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles resetButton.Click
        ' Disable the timer.
        timer1.Enabled = False
        resetButton.Enabled = False

        ' Reset the output state.
        For i As Integer = 0 To 4
            GetPassFailLed(i).Value = True
            GetActualTextBox(i).Text = "0"
            GetExpectedTextBox(i).Text = "0"
        Next
        globalPassFailLed.Value = True

        ' Display the first image.
        imageNumber = 0

        ' Enable region of interest selection.
        EnableRoiSelection()
        imageViewer1.Attach(GetNextImage())
        imageViewer1_RoiChanged(imageViewer1, New ContoursChangedEventArgs(ContoursChangedAction.Clear, New Collection(Of Contour)(), 0, New Collection(Of Contour)(), 0))
    End Sub

    Private Function GetExpectedTextBox(ByVal i As Integer) As TextBox
        Select Case i
            Case 0
                Return expectedEdges1
            Case 1
                Return expectedEdges2
            Case 2
                Return expectedEdges3
            Case 3
                Return expectedEdges4
            Case 4
                Return expectedEdges5
            Case Else
                ' This should never happen.
                Return Nothing
        End Select
    End Function

    Private Function GetActualTextBox(ByVal i As Integer) As TextBox
        Select Case i
            Case 0
                Return actualEdges1
            Case 1
                Return actualEdges2
            Case 2
                Return actualEdges3
            Case 3
                Return actualEdges4
            Case 4
                Return actualEdges5
            Case Else
                ' This should never happen.
                Return Nothing
        End Select
    End Function

    Private Function GetPassFailLed(ByVal i As Integer) As PassFailLed
        Select Case i
            Case 0
                Return PassFailLed1
            Case 1
                Return PassFailLed2
            Case 2
                Return PassFailLed3
            Case 3
                Return PassFailLed4
            Case 4
                Return PassFailLed5
            Case Else
                ' This should never happen.
                Return Nothing
        End Select
    End Function

    Private Sub DisableRoiSelection()
        imageViewer1.ToolsShown = ViewerTools.Selection Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut Or ViewerTools.Pan
        imageViewer1.ActiveTool = ViewerTools.Pan
    End Sub

    Private Sub EnableRoiSelection()
        imageViewer1.ToolsShown = ViewerTools.Line Or ViewerTools.Selection Or ViewerTools.ZoomIn Or ViewerTools.ZoomOut Or ViewerTools.Pan
        imageViewer1.ActiveTool = ViewerTools.Line
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage()
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "Image" & [String].Format("{0:00}", imageNumber) & ".jpg"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Remove any overlays.
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