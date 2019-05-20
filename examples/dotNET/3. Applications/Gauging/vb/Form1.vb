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
Imports NationalInstruments.Vision.MeasurementStudioDemo

' Gauging Example

' The objective of this gauging application example is to determine if the
' pins on a chip are straight and evenly spaced.  The example uses edge detection
' to find the boundaries of the pins and uses the distances between the edges to
' determine if the pins are uniformly spaced.  The edge locations are also used to
' compute the orientation of the pins.

' This example uses a demonstration version of the Measurement Studio user interface
' controls.  For more information, see http://www.ni.com/mstudio.
Partial Public Class Form1
    Inherits Form
    Private Shared imagePath As String
    Private Shared imageNumber As Integer
    Private Shared numberOfPartsInspected As Integer
    Private images As New Collection(Of VisionImage)()
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Get the image path
        imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Pins\")
        imageNumber = 0

        ' Enable the timer
        timer1.Enabled = True
        timer1.Start()
    End Sub

    Private Function ByteToDouble(ByVal b As Byte) As Double
        Return b
    End Function


    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer1.Tick
        ' Get the next image
        Dim image As VisionImage = GetNextImage()

        ' Find peaks along 3 predetermined rows of the image.  Store the points found
        ' along each line in the pointsForRow array.
        Dim pointsForRow As Collection(Of PointContour)() = New Collection(Of PointContour)(2) {}
        Dim yPositions As Integer() = New Integer() {145, 200, 300}
        For i As Integer = 0 To 2
            Dim yPosition As Integer = yPositions(i)
            Dim rowPixels As Byte() = image.GetLinePixels(New LineContour(New PointContour(0, yPosition), New PointContour(image.Width - 1, yPosition))).U8
            Dim rowPixelsDouble As Double() = Array.ConvertAll(Of Byte, Double)(rowPixels, AddressOf ByteToDouble)
            Dim peakValleyReport As Collection(Of PeakValleyReportItem) = Algorithms.DetectPeaksOrValleys(rowPixelsDouble, PeakOrValley.Peaks, New DetectPeaksOrValleysOptions(19, 70))
            pointsForRow(i) = New Collection(Of PointContour)()
            For Each item As PeakValleyReportItem In peakValleyReport
                pointsForRow(i).Add(New PointContour(item.Location, yPosition))
            Next
        Next

        ' Find the top and bottom points nearest each point found along the middle line.
        Dim angles As Double() = New Double(11) {}
        Dim points As New Collection(Of PointContour)()
        points.Add(New PointContour())
        points.Add(New PointContour())
        Dim allPassed As Boolean = True
        Dim pinPoints As Collection(Of PointContour)() = New Collection(Of PointContour)(11) {}
        For i As Integer = 0 To pointsForRow(0).Count - 1
            ' pinPoints[i][j] denotes the jth point of the ith pin.
            pinPoints(i) = New Collection(Of PointContour)()
            pinPoints(i).Add(New PointContour())
            pinPoints(i).Add(pointsForRow(1)(i))
            pinPoints(i).Add(New PointContour())
            points(0) = pinPoints(i)(1)

            ' For the top and bottom rows...
            For Each j As Integer In New Integer(1) {0, 2}
                Dim minIndex As Integer = -1
                Dim minDistance As Double = Double.PositiveInfinity

                ' For each point along that row...
                For k As Integer = 0 To pointsForRow(j).Count - 1
                    ' Compute the distance between this point and the current point in the center row.
                    points(1) = pointsForRow(j)(k)
                    Dim distance As Double = Algorithms.FindPointDistances(points)(0)

                    ' The point with the smallest distance should be associated with the pin
                    ' corresponding to the center point.
                    If distance < minDistance Then
                        minDistance = distance
                        minIndex = k
                    End If
                Next

                ' Save the point.
                pinPoints(i)(j) = pointsForRow(j)(minIndex)
            Next
            ' Use the information found to determine if the angle is within range.
            points(0) = pinPoints(i)(0)
            points(1) = pinPoints(i)(2)
            angles(i) = Algorithms.GetAngles(points, pinPoints(i)(1))(0)
            ' If the angle is within [180-tolerance, 180+tolerance], the part
            ' passes inspection.
            GetLed(i).Value = (angles(i) >= (180 - CDbl(tolerance.Value)) AndAlso angles(i) <= (180 + CDbl(tolerance.Value)))
            allPassed = allPassed And GetLed(i).Value
        Next

        ' Because not all images have 12 pins, set any remaining indicators to pass.
        For i As Integer = pointsForRow(0).Count To 11
            GetLed(i).Value = True
        Next

        ' Display results
        partOK.Value = allPassed
        numberOfPartsInspected += 1
        partsInspected.Text = numberOfPartsInspected.ToString()

        If imageResultsMode.Checked Then
            ' Display the overlay
            Dim textOptions As New OverlayTextOptions()
            textOptions.HorizontalAlignment = HorizontalTextAlignment.Center
            textOptions.FontSize = 14

            ' Overlay the pin positions on the image
            For i As Integer = 0 To pointsForRow(0).Count - 1
                If GetLed(i).Value Then
                    ' Part passed

                    ' Draw a circle at each point on the pin.
                    For j As Integer = 0 To 2
                        image.Overlays.[Default].AddOval(New OvalContour(pinPoints(i)(j).X - 2, pinPoints(i)(j).Y - 2, 4, 4), Rgb32Value.GreenColor, DrawingMode.PaintValue)
                    Next

                    ' Connect the points
                    image.Overlays.[Default].AddPolyline(New PolylineContour(pinPoints(i)), Rgb32Value.GreenColor)
                    image.Overlays.[Default].AddText([String].Format("{0:0.0}", angles(i)), New PointContour(pinPoints(i)(1).X, 100), Rgb32Value.GreenColor, textOptions)
                Else
                    ' Part failed
                    ' Overlay a rectangle with an X inside
                    Dim rect As New RectangleContour(pinPoints(i)(1).X - 20, 120, 40, 210)
                    image.Overlays.[Default].AddRectangle(rect, Rgb32Value.RedColor, DrawingMode.DrawValue)
                    image.Overlays.[Default].AddLine(New LineContour(New PointContour(rect.Left, rect.Top), New PointContour(rect.Left + rect.Width, rect.Top + rect.Height)), Rgb32Value.RedColor)
                    image.Overlays.[Default].AddLine(New LineContour(New PointContour(rect.Left + rect.Width, rect.Top), New PointContour(rect.Left, rect.Top + rect.Height)), Rgb32Value.RedColor)
                End If
            Next
        End If

        If imageResultsMode.Checked OrElse imageMode.Checked Then
            ' Display the image
            Algorithms.Copy(image, imageViewer1.Image)
        End If
    End Sub

    Private Function GetLed(ByVal i As Integer) As PassFailLed
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
            Case 5
                Return PassFailLed6
            Case 6
                Return PassFailLed7
            Case 7
                Return PassFailLed8
            Case 8
                Return PassFailLed9
            Case 9
                Return PassFailLed10
            Case 10
                Return PassFailLed11
            Case Else
                Return PassFailLed12
        End Select

    End Function

    Private Sub quitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitButton.Click
        Application.[Exit]()
    End Sub

    Private Function GetNextImage() As VisionImage
        Dim toReturn As VisionImage
        ' Load an image or return to the previous image.
        If imageNumber >= images.Count Then
            toReturn = New VisionImage()
            toReturn.ReadFile(System.IO.Path.Combine(imagePath, "pins-" & [String].Format("{0:00}", imageNumber) & ".bmp"))
            images.Add(toReturn)
        Else
            toReturn = images(imageNumber)
            ' Clear any overlays
            toReturn.Overlays.[Default].Clear()
        End If

        ' Advance the image number to the next image
        imageNumber += 1
        If imageNumber > 21 Then
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
End Class