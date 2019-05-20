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
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.matchModeLabel = New System.Windows.Forms.Label
        Me.timeLabel = New System.Windows.Forms.Label
        Me.matchesLabel = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(13, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(527, 452)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(559, 26)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(116, 166)
        Me.imageViewer2.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(556, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(83, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Template Image"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(556, 217)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Match Mode:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(571, 242)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(55, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Time (ms):"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(575, 267)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(51, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Matches:"
        '
        'matchModeLabel
        '
        Me.matchModeLabel.AutoSize = True
        Me.matchModeLabel.Location = New System.Drawing.Point(632, 217)
        Me.matchModeLabel.Name = "matchModeLabel"
        Me.matchModeLabel.Size = New System.Drawing.Size(28, 13)
        Me.matchModeLabel.TabIndex = 4
        Me.matchModeLabel.Text = "Shift"
        '
        'timeLabel
        '
        Me.timeLabel.AutoSize = True
        Me.timeLabel.Location = New System.Drawing.Point(632, 242)
        Me.timeLabel.Name = "timeLabel"
        Me.timeLabel.Size = New System.Drawing.Size(13, 13)
        Me.timeLabel.TabIndex = 4
        Me.timeLabel.Text = "0"
        '
        'matchesLabel
        '
        Me.matchesLabel.AutoSize = True
        Me.matchesLabel.Location = New System.Drawing.Point(632, 267)
        Me.matchesLabel.Name = "matchesLabel"
        Me.matchesLabel.Size = New System.Drawing.Size(13, 13)
        Me.matchesLabel.TabIndex = 4
        Me.matchesLabel.Text = "0"
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(620, 474)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(87, 30)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(546, 306)
        Me.DelaySlider1.Maximum = 1000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 8
        Me.DelaySlider1.Value = 750
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 516)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.matchesLabel)
        Me.Controls.Add(Me.timeLabel)
        Me.Controls.Add(Me.matchModeLabel)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Fusebox Inspection Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private matchModeLabel As System.Windows.Forms.Label
    Private timeLabel As System.Windows.Forms.Label
    Private matchesLabel As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class