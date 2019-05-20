Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports NationalInstruments.Vision
Imports NationalInstruments.Vision.Analysis

Partial Public Class Form2
    Inherits Form
    Public Sub New()
        InitializeComponent()
        imageViewer2.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
    End Sub

    Public ReadOnly Property BeforeImage() As VisionImage
        Get
            Return imageViewer1.Image
        End Get
    End Property

    Public ReadOnly Property AfterImage() As VisionImage
        Get
            Return imageViewer2.Image
        End Get
    End Property
End Class