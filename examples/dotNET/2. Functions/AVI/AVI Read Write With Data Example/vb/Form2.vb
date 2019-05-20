Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision.MeasurementStudioDemo

Partial Public Class Form2
    Inherits Form
    Private form1 As Form1
    Public Sub New(ByVal owner As Form1)
        InitializeComponent()
        form1 = owner
    End Sub

    Public ReadOnly Property Graph() As AviSampleDataGraph
        Get
            Return AviSampleDataGraph1
        End Get
    End Property

    Public ReadOnly Property FrameSlider() As GenericSlider
        Get
            Return GenericSlider1
        End Get
    End Property

    Public ReadOnly Property FrameNum() As NumericUpDown
        Get
            Return NumericUpDown1
        End Get
    End Property

    Public ReadOnly Property CurTime() As TextBox
        Get
            Return curTimeBox
        End Get
    End Property

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        If FrameSlider.Value <> CType(NumericUpDown1.Value, Double) Then
            FrameSlider.Value = NumericUpDown1.Value
        End If
    End Sub

    Private Sub GenericSlider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenericSlider1.ValueChanged
        FrameNum.Value = CType(FrameSlider.Value, Decimal)
        form1.ReadFrame(CInt(FrameSlider.Value))
    End Sub

    Private Sub AviSampleDataGraph1_AfterCursorMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AviSampleDataGraph1.AfterCursorMove
        If FrameSlider.Value <> Graph.CursorValue Then
            FrameSlider.Value = Graph.CursorValue
        End If
    End Sub
End Class