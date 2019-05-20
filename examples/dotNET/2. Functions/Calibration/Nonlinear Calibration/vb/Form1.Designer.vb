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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.loadCalibrationButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.learnCalibrationButton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.loadTargetButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.measurePartsButton = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.wholeImageTime = New System.Windows.Forms.TextBox
        Me.coinsImageTime = New System.Windows.Forms.TextBox
        Me.quitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(17, 21)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(542, 282)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(565, 21)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(135, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "1. Load the calibration grid."
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(17, 314)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(542, 282)
        Me.imageViewer2.TabIndex = 0
        '
        'loadCalibrationButton
        '
        Me.loadCalibrationButton.Location = New System.Drawing.Point(568, 39)
        Me.loadCalibrationButton.Name = "loadCalibrationButton"
        Me.loadCalibrationButton.Size = New System.Drawing.Size(149, 34)
        Me.loadCalibrationButton.TabIndex = 2
        Me.loadCalibrationButton.Text = "Load Calibration Template"
        Me.loadCalibrationButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(565, 91)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(225, 31)
        Me.label2.TabIndex = 1
        Me.label2.Text = "2. Learn the calibration grid. (This process is computation intensive and may tak" & _
            "e a while)"
        '
        'learnCalibrationButton
        '
        Me.learnCalibrationButton.Enabled = False
        Me.learnCalibrationButton.Location = New System.Drawing.Point(568, 125)
        Me.learnCalibrationButton.Name = "learnCalibrationButton"
        Me.learnCalibrationButton.Size = New System.Drawing.Size(149, 34)
        Me.learnCalibrationButton.TabIndex = 2
        Me.learnCalibrationButton.Text = "Learn Calibration"
        Me.learnCalibrationButton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(565, 174)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(225, 45)
        Me.label3.TabIndex = 1
        Me.label3.Text = "3. Use the calibration information learned in the previous step to measure the ob" & _
            "ject areas in the distorted target image."
        '
        'loadTargetButton
        '
        Me.loadTargetButton.Enabled = False
        Me.loadTargetButton.Location = New System.Drawing.Point(568, 222)
        Me.loadTargetButton.Name = "loadTargetButton"
        Me.loadTargetButton.Size = New System.Drawing.Size(149, 34)
        Me.loadTargetButton.TabIndex = 2
        Me.loadTargetButton.Text = "Load Target Image"
        Me.loadTargetButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(565, 272)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(225, 31)
        Me.label4.TabIndex = 1
        Me.label4.Text = "4. Correct the image and measure the object areas."
        '
        'measurePartsButton
        '
        Me.measurePartsButton.Enabled = False
        Me.measurePartsButton.Location = New System.Drawing.Point(568, 306)
        Me.measurePartsButton.Name = "measurePartsButton"
        Me.measurePartsButton.Size = New System.Drawing.Size(149, 34)
        Me.measurePartsButton.TabIndex = 2
        Me.measurePartsButton.Text = "Measure Parts"
        Me.measurePartsButton.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(565, 372)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(225, 69)
        Me.label5.TabIndex = 1
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(565, 453)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(126, 41)
        Me.label6.TabIndex = 3
        Me.label6.Text = "time (ms) to correct entire image, threshold and calculate measurements"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(697, 453)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(126, 41)
        Me.label7.TabIndex = 3
        Me.label7.Text = "time (ms) to threshold, correct just coins, and then take measurements"
        '
        'wholeImageTime
        '
        Me.wholeImageTime.Location = New System.Drawing.Point(568, 497)
        Me.wholeImageTime.Name = "wholeImageTime"
        Me.wholeImageTime.ReadOnly = True
        Me.wholeImageTime.Size = New System.Drawing.Size(46, 20)
        Me.wholeImageTime.TabIndex = 4
        '
        'coinsImageTime
        '
        Me.coinsImageTime.Location = New System.Drawing.Point(700, 497)
        Me.coinsImageTime.Name = "coinsImageTime"
        Me.coinsImageTime.ReadOnly = True
        Me.coinsImageTime.Size = New System.Drawing.Size(46, 20)
        Me.coinsImageTime.TabIndex = 4
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(568, 574)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(149, 34)
        Me.quitButton.TabIndex = 5
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 611)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.coinsImageTime)
        Me.Controls.Add(Me.wholeImageTime)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.measurePartsButton)
        Me.Controls.Add(Me.loadTargetButton)
        Me.Controls.Add(Me.learnCalibrationButton)
        Me.Controls.Add(Me.loadCalibrationButton)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Nonlinear Calibration Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents loadCalibrationButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private WithEvents learnCalibrationButton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private WithEvents loadTargetButton As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private WithEvents measurePartsButton As System.Windows.Forms.Button
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private wholeImageTime As System.Windows.Forms.TextBox
    Private coinsImageTime As System.Windows.Forms.TextBox
    Private WithEvents quitButton As System.Windows.Forms.Button
End Class