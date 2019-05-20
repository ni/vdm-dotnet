Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections.ObjectModel
Imports System.Drawing
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

' Color Spectrum Helpers
' Color Learn and Color Match examples share these functions.
Public Class ColorSpectrumHelpers
    Private Shared _plotColors As New Collection(Of Color)()
    Private Shared _colorSpectrum As New Collection(Of Double)()
    Public Shared Function GetPlotColors(ByVal sensitivity As ColorSensitivity) As Collection(Of Color)
        Dim luminanceValues As New Collection(Of Byte)()
        Select Case sensitivity
            Case ColorSensitivity.Low
                luminanceValues = New Collection(Of Byte)(New Byte() {76, 220, 150, 179, 100, 45, _
                 105})
                Exit Select
            Case ColorSensitivity.Medium
                luminanceValues = New Collection(Of Byte)(New Byte() {76, 185, 220, 185, 150, 165, _
                 179, 230, 100, 122, 45, 75, _
                 105, 90})
                Exit Select
            Case ColorSensitivity.High
                luminanceValues = New Collection(Of Byte)(New Byte() {76, 130, 185, 200, 220, 200, _
                 185, 167, 150, 157, 165, 172, _
                 179, 205, 230, 165, 100, 110, _
                 122, 83, 45, 60, 75, 90, _
                 105, 98, 90, 83})
                Exit Select
        End Select
        Dim plotColors As New Collection(Of Color)()
        Dim binSize As Double = 255.0R / luminanceValues.Count
        For i As Integer = 0 To luminanceValues.Count - 1
            Dim hue As Byte = CByte((binSize * i))
            plotColors.Add(Algorithms.ConvertColorValue(New ColorValue(New Hsl32Value(CByte(hue), 80, luminanceValues(i))), ColorMode.Rgb).Rgb32.Color)
            plotColors.Add(Algorithms.ConvertColorValue(New ColorValue(New Hsl32Value(CByte(hue), 255, luminanceValues(i))), ColorMode.Rgb).Rgb32.Color)
        Next
        plotColors.Add(Color.Black)
        plotColors.Add(Color.White)
        Return plotColors
    End Function
    Public Shared Sub PlotColorSpectrum(ByVal pictureBox As PictureBox, ByVal sensitivity As ColorSensitivity, ByVal colorSpectrum As Collection(Of Double))
        _colorSpectrum = colorSpectrum
        _plotColors = GetPlotColors(sensitivity)
        ' Make sure the PictureBox gets redrawn.
        pictureBox.Invalidate()
    End Sub
    Public Shared Sub DrawColorSpectrum(ByVal g As Graphics, ByVal bounds As Rectangle)
        ' Clear the picture
        g.Clear(Color.FromKnownColor(KnownColor.Control))

        ' If we have no color spectrum, return.
        If _colorSpectrum.Count = 0 Then
            Exit Sub
        End If

        ' Find the maximum value.
        Dim max As Single = CSng(_colorSpectrum(0))
        For Each value As Double In _colorSpectrum
            If value > max Then
                max = CSng(value)
            End If
        Next
        max *= 1.25F


        ' Compute the width and height of the PictureBox control in pixels.
        Dim width As Integer = bounds.Width
        Dim height As Integer = bounds.Height

        ' Draw a line of the appropriate height and color for each pixel found.
        Dim count As Integer = _colorSpectrum.Count
        Dim lineWidth As Single = CSng(width) / count
        Dim xOffset As Single = lineWidth / 2
        For i As Integer = 0 To count - 1
            Dim pen As New Pen(_plotColors(i), lineWidth)
            g.DrawLine(pen, New PointF(xOffset + lineWidth * i, height), New PointF(xOffset + lineWidth * i, CSng((height * (1.0R - _colorSpectrum(i) / max)))))
            pen.Dispose()
        Next
    End Sub
End Class