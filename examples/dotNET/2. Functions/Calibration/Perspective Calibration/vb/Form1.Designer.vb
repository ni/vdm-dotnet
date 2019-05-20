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
        Me.loadCalibrationButton = New System.Windows.Forms.Button
        Me.learnCalibrationButton = New System.Windows.Forms.Button
        Me.measureDistancesButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(592, 423)
        Me.imageViewer1.TabIndex = 0
        '
        'loadCalibrationButton
        '
        Me.loadCalibrationButton.Location = New System.Drawing.Point(12, 441)
        Me.loadCalibrationButton.Name = "loadCalibrationButton"
        Me.loadCalibrationButton.Size = New System.Drawing.Size(163, 31)
        Me.loadCalibrationButton.TabIndex = 1
        Me.loadCalibrationButton.Text = "Load Calibration Template"
        Me.loadCalibrationButton.UseVisualStyleBackColor = True
        '
        'learnCalibrationButton
        '
        Me.learnCalibrationButton.Enabled = False
        Me.learnCalibrationButton.Location = New System.Drawing.Point(12, 478)
        Me.learnCalibrationButton.Name = "learnCalibrationButton"
        Me.learnCalibrationButton.Size = New System.Drawing.Size(163, 31)
        Me.learnCalibrationButton.TabIndex = 1
        Me.learnCalibrationButton.Text = "Learn Calibration"
        Me.learnCalibrationButton.UseVisualStyleBackColor = True
        '
        'measureDistancesButton
        '
        Me.measureDistancesButton.Enabled = False
        Me.measureDistancesButton.Location = New System.Drawing.Point(12, 515)
        Me.measureDistancesButton.Name = "measureDistancesButton"
        Me.measureDistancesButton.Size = New System.Drawing.Size(163, 31)
        Me.measureDistancesButton.TabIndex = 1
        Me.measureDistancesButton.Text = "Measure Distances"
        Me.measureDistancesButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(546, 520)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(58, 26)
        Me.quitButton.TabIndex = 2
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(190, 441)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Instructions:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(190, 459)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(135, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "1. Load the calibration grid."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(190, 478)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(138, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "2. Learn the calibration grid."
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(190, 496)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(232, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "3. Measure the distances in the distorted image."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(618, 558)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.measureDistancesButton)
        Me.Controls.Add(Me.learnCalibrationButton)
        Me.Controls.Add(Me.loadCalibrationButton)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Perspective Calibration Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents loadCalibrationButton As System.Windows.Forms.Button
    Private WithEvents learnCalibrationButton As System.Windows.Forms.Button
    Private WithEvents measureDistancesButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label1 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
End Class