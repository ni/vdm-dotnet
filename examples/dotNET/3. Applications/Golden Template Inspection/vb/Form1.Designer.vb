Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.colorDialog1 = New System.Windows.Forms.ColorDialog
        Me.brightColorLabel = New System.Windows.Forms.Label
        Me.darkColorLabel = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.passFailLed = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.brightSwitch = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
        Me.darkSwitch = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(11, 24)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(319, 266)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(88, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Golden Template"
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(345, 24)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(490, 351)
        Me.imageViewer2.TabIndex = 0
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(342, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(86, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Inspected Image"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 312)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(104, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Show Bright Defects"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(137, 312)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(100, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Show Dark Defects"
        '
        'brightColorLabel
        '
        Me.brightColorLabel.BackColor = System.Drawing.Color.Lime
        Me.brightColorLabel.Location = New System.Drawing.Point(42, 413)
        Me.brightColorLabel.Name = "brightColorLabel"
        Me.brightColorLabel.Size = New System.Drawing.Size(44, 36)
        Me.brightColorLabel.TabIndex = 4
        '
        'darkColorLabel
        '
        Me.darkColorLabel.BackColor = System.Drawing.Color.Red
        Me.darkColorLabel.Location = New System.Drawing.Point(163, 413)
        Me.darkColorLabel.Name = "darkColorLabel"
        Me.darkColorLabel.Size = New System.Drawing.Size(44, 36)
        Me.darkColorLabel.TabIndex = 4
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(761, 454)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(74, 35)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 1250
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(345, 381)
        Me.DelaySlider1.Maximum = 2500
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 7
        Me.DelaySlider1.Value = 1250
        '
        'passFailLed
        '
        Me.passFailLed.Caption = "Pass?"
        Me.passFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen
        Me.passFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.passFailLed.Location = New System.Drawing.Point(269, 330)
        Me.passFailLed.Name = "passFailLed"
        Me.passFailLed.Size = New System.Drawing.Size(60, 80)
        Me.passFailLed.TabIndex = 8
        Me.passFailLed.Value = True
        '
        'brightSwitch
        '
        Me.brightSwitch.AutoSize = True
        Me.brightSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.brightSwitch.Location = New System.Drawing.Point(28, 325)
        Me.brightSwitch.Name = "brightSwitch"
        Me.brightSwitch.Size = New System.Drawing.Size(68, 85)
        Me.brightSwitch.TabIndex = 9
        Me.brightSwitch.Value = True
        '
        'darkSwitch
        '
        Me.darkSwitch.AutoSize = True
        Me.darkSwitch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.darkSwitch.Location = New System.Drawing.Point(149, 325)
        Me.darkSwitch.Name = "darkSwitch"
        Me.darkSwitch.Size = New System.Drawing.Size(68, 85)
        Me.darkSwitch.TabIndex = 9
        Me.darkSwitch.Value = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 495)
        Me.Controls.Add(Me.darkSwitch)
        Me.Controls.Add(Me.brightSwitch)
        Me.Controls.Add(Me.passFailLed)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.darkColorLabel)
        Me.Controls.Add(Me.brightColorLabel)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Golden Template Inspection Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private colorDialog1 As System.Windows.Forms.ColorDialog
    Private brightColorLabel As System.Windows.Forms.Label
    Private darkColorLabel As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
    Friend WithEvents passFailLed As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents brightSwitch As NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
    Friend WithEvents darkSwitch As NationalInstruments.Vision.MeasurementStudioDemo.SimpleSwitch
End Class