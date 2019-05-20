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
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.matchesRequested = New System.Windows.Forms.Label
        Me.matchesFound = New System.Windows.Forms.Label
        Me.timeTaken = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.passFailLed = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(426, 279)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(8, 294)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(298, 24)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Number of matches requested:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(49, 318)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(257, 24)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Number of matches found:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.Location = New System.Drawing.Point(196, 342)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(110, 24)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Time (ms):"
        '
        'matchesRequested
        '
        Me.matchesRequested.AutoSize = True
        Me.matchesRequested.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.matchesRequested.Location = New System.Drawing.Point(312, 294)
        Me.matchesRequested.Name = "matchesRequested"
        Me.matchesRequested.Size = New System.Drawing.Size(32, 24)
        Me.matchesRequested.TabIndex = 2
        Me.matchesRequested.Text = "12"
        '
        'matchesFound
        '
        Me.matchesFound.AutoSize = True
        Me.matchesFound.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.matchesFound.Location = New System.Drawing.Point(312, 318)
        Me.matchesFound.Name = "matchesFound"
        Me.matchesFound.Size = New System.Drawing.Size(21, 24)
        Me.matchesFound.TabIndex = 2
        Me.matchesFound.Text = "0"
        '
        'timeTaken
        '
        Me.timeTaken.AutoSize = True
        Me.timeTaken.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timeTaken.Location = New System.Drawing.Point(312, 342)
        Me.timeTaken.Name = "timeTaken"
        Me.timeTaken.Size = New System.Drawing.Size(21, 24)
        Me.timeTaken.TabIndex = 2
        Me.timeTaken.Text = "0"
        '
        'timer1
        '
        Me.timer1.Interval = 750
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(385, 426)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(51, 29)
        Me.quitButton.TabIndex = 4
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(12, 378)
        Me.DelaySlider1.Maximum = 1000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 5
        Me.DelaySlider1.Value = 750
        '
        'passFailLed
        '
        Me.passFailLed.Caption = "Pass?"
        Me.passFailLed.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.RedGreen
        Me.passFailLed.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Round3D
        Me.passFailLed.Location = New System.Drawing.Point(343, 299)
        Me.passFailLed.Name = "passFailLed"
        Me.passFailLed.Size = New System.Drawing.Size(92, 99)
        Me.passFailLed.TabIndex = 6
        Me.passFailLed.Value = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 468)
        Me.Controls.Add(Me.passFailLed)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.timeTaken)
        Me.Controls.Add(Me.matchesFound)
        Me.Controls.Add(Me.matchesRequested)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Blister Pack Inspection Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private matchesRequested As System.Windows.Forms.Label
    Private matchesFound As System.Windows.Forms.Label
    Private timeTaken As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
    Friend WithEvents passFailLed As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
End Class