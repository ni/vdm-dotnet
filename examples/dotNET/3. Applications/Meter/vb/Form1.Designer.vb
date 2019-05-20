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
        Me.speedBox = New System.Windows.Forms.TextBox
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.SpeedKnob1 = New NationalInstruments.Vision.MeasurementStudioDemo.SpeedKnob
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(307, 220)
        Me.imageViewer1.TabIndex = 0
        '
        'speedBox
        '
        Me.speedBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.speedBox.Location = New System.Drawing.Point(333, 13)
        Me.speedBox.Name = "speedBox"
        Me.speedBox.ReadOnly = True
        Me.speedBox.Size = New System.Drawing.Size(67, 38)
        Me.speedBox.TabIndex = 2
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(395, 188)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(58, 33)
        Me.quitButton.TabIndex = 5
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'SpeedKnob1
        '
        Me.SpeedKnob1.AutoSize = True
        Me.SpeedKnob1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SpeedKnob1.Location = New System.Drawing.Point(-41, 203)
        Me.SpeedKnob1.Name = "SpeedKnob1"
        Me.SpeedKnob1.Size = New System.Drawing.Size(406, 447)
        Me.SpeedKnob1.TabIndex = 6
        Me.SpeedKnob1.Value = 0
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(333, 81)
        Me.DelaySlider1.Maximum = 1500
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 7
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 438)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Controls.Add(Me.SpeedKnob1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.speedBox)
        Me.Name = "Form1"
        Me.Text = "Meter Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private speedBox As System.Windows.Forms.TextBox
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents SpeedKnob1 As NationalInstruments.Vision.MeasurementStudioDemo.SpeedKnob
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class