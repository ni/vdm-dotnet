Partial Class Form2
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.curTimeBox = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.AviSampleDataGraph1 = New NationalInstruments.Vision.MeasurementStudioDemo.AviSampleDataGraph
        Me.GenericSlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(192, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(88, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Waveform Graph"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(34, 276)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(100, 16)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Time"
        '
        'curTimeBox
        '
        Me.curTimeBox.Location = New System.Drawing.Point(37, 295)
        Me.curTimeBox.MaxLength = 0
        Me.curTimeBox.Name = "curTimeBox"
        Me.curTimeBox.Size = New System.Drawing.Size(135, 20)
        Me.curTimeBox.TabIndex = 5
        Me.curTimeBox.Text = "00:00:00"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(192, 276)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(91, 13)
        Me.label3.TabIndex = 8
        Me.label3.Text = "Frame to Examine"
        '
        'AviSampleDataGraph1
        '
        Me.AviSampleDataGraph1.AutoSize = True
        Me.AviSampleDataGraph1.CursorValue = 5
        Me.AviSampleDataGraph1.Location = New System.Drawing.Point(37, 21)
        Me.AviSampleDataGraph1.Name = "AviSampleDataGraph1"
        Me.AviSampleDataGraph1.Size = New System.Drawing.Size(405, 236)
        Me.AviSampleDataGraph1.TabIndex = 9
        '
        'GenericSlider1
        '
        Me.GenericSlider1.AutoSize = True
        Me.GenericSlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GenericSlider1.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.GenericSlider1.Enabled = False
        Me.GenericSlider1.Location = New System.Drawing.Point(178, 292)
        Me.GenericSlider1.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.AviFrame
        Me.GenericSlider1.Name = "GenericSlider1"
        Me.GenericSlider1.Size = New System.Drawing.Size(203, 53)
        Me.GenericSlider1.TabIndex = 10
        Me.GenericSlider1.Value = 0
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(375, 300)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(45, 20)
        Me.NumericUpDown1.TabIndex = 11
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 363)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.GenericSlider1)
        Me.Controls.Add(Me.AviSampleDataGraph1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.curTimeBox)
        Me.Controls.Add(Me.label1)
        Me.Location = New System.Drawing.Point(620, 30)
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Frame Data"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Friend label2 As System.Windows.Forms.Label
    Public curTimeBox As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Friend WithEvents AviSampleDataGraph1 As NationalInstruments.Vision.MeasurementStudioDemo.AviSampleDataGraph
    Friend WithEvents GenericSlider1 As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
End Class