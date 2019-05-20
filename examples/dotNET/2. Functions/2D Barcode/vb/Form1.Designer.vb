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
        Me.barcodeType = New System.Windows.Forms.ListBox
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label5 = New System.Windows.Forms.Label
        Me.readTime = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.dataFound = New System.Windows.Forms.TextBox
        Me.typeFound = New System.Windows.Forms.TextBox
        Me.startButton = New System.Windows.Forms.Button
        Me.stopButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.useOptionsBox = New System.Windows.Forms.CheckBox
        Me.gradeDMBox = New System.Windows.Forms.CheckBox
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label12 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.gradeUnusedErrorCorrection = New System.Windows.Forms.TextBox
        Me.gradeAxialNonuniformity = New System.Windows.Forms.TextBox
        Me.gradePrintGrowth = New System.Windows.Forms.TextBox
        Me.gradeSymbolContrast = New System.Windows.Forms.TextBox
        Me.gradeDecoding = New System.Windows.Forms.TextBox
        Me.gradeOverall = New System.Windows.Forms.TextBox
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.groupBox1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(391, 46)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(407, 390)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(388, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(36, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image"
        '
        'barcodeType
        '
        Me.barcodeType.FormattingEnabled = True
        Me.barcodeType.Location = New System.Drawing.Point(12, 46)
        Me.barcodeType.Name = "barcodeType"
        Me.barcodeType.Size = New System.Drawing.Size(119, 56)
        Me.barcodeType.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 26)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(74, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Barcode Type"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.readTime)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.dataFound)
        Me.groupBox1.Controls.Add(Me.typeFound)
        Me.groupBox1.Location = New System.Drawing.Point(12, 173)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(146, 235)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Results"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 190)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(81, 13)
        Me.label5.TabIndex = 5
        Me.label5.Text = "Read Time (ms)"
        '
        'readTime
        '
        Me.readTime.Location = New System.Drawing.Point(5, 206)
        Me.readTime.Name = "readTime"
        Me.readTime.Size = New System.Drawing.Size(57, 20)
        Me.readTime.TabIndex = 4
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(2, 67)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(30, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Data"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(2, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(31, 13)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Type"
        '
        'dataFound
        '
        Me.dataFound.Location = New System.Drawing.Point(5, 83)
        Me.dataFound.Multiline = True
        Me.dataFound.Name = "dataFound"
        Me.dataFound.Size = New System.Drawing.Size(131, 96)
        Me.dataFound.TabIndex = 1
        '
        'typeFound
        '
        Me.typeFound.Location = New System.Drawing.Point(5, 37)
        Me.typeFound.Name = "typeFound"
        Me.typeFound.Size = New System.Drawing.Size(131, 20)
        Me.typeFound.TabIndex = 0
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(15, 429)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(71, 37)
        Me.startButton.TabIndex = 6
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Location = New System.Drawing.Point(92, 429)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(71, 37)
        Me.stopButton.TabIndex = 7
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(192, 429)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(71, 37)
        Me.quitButton.TabIndex = 8
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'useOptionsBox
        '
        Me.useOptionsBox.AutoSize = True
        Me.useOptionsBox.Location = New System.Drawing.Point(188, 43)
        Me.useOptionsBox.Name = "useOptionsBox"
        Me.useOptionsBox.Size = New System.Drawing.Size(143, 17)
        Me.useOptionsBox.TabIndex = 10
        Me.useOptionsBox.Text = "Use Options (if available)"
        Me.useOptionsBox.UseVisualStyleBackColor = True
        '
        'gradeDMBox
        '
        Me.gradeDMBox.AutoSize = True
        Me.gradeDMBox.Location = New System.Drawing.Point(188, 66)
        Me.gradeDMBox.Name = "gradeDMBox"
        Me.gradeDMBox.Size = New System.Drawing.Size(139, 17)
        Me.gradeDMBox.TabIndex = 11
        Me.gradeDMBox.Text = "Grade Data Matrix code"
        Me.gradeDMBox.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.gradeUnusedErrorCorrection)
        Me.groupBox2.Controls.Add(Me.gradeAxialNonuniformity)
        Me.groupBox2.Controls.Add(Me.gradePrintGrowth)
        Me.groupBox2.Controls.Add(Me.gradeSymbolContrast)
        Me.groupBox2.Controls.Add(Me.gradeDecoding)
        Me.groupBox2.Controls.Add(Me.gradeOverall)
        Me.groupBox2.Location = New System.Drawing.Point(164, 173)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(221, 179)
        Me.groupBox2.TabIndex = 13
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "AIM Grading Report"
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(6, 149)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(157, 17)
        Me.label12.TabIndex = 11
        Me.label12.Text = "Unused Error Correction Grade"
        Me.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(35, 123)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(128, 17)
        Me.label11.TabIndex = 10
        Me.label11.Text = "Axial Nonuniformity Grade"
        Me.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(35, 97)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(128, 17)
        Me.label10.TabIndex = 9
        Me.label10.Text = "Print Growth Grade"
        Me.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(35, 73)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(128, 17)
        Me.label9.TabIndex = 8
        Me.label9.Text = "Symbol Contrast Grade"
        Me.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(35, 47)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(128, 17)
        Me.label8.TabIndex = 7
        Me.label8.Text = "Decoding Grade"
        Me.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(33, 21)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(130, 17)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Overall Grade"
        Me.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gradeUnusedErrorCorrection
        '
        Me.gradeUnusedErrorCorrection.Location = New System.Drawing.Point(171, 148)
        Me.gradeUnusedErrorCorrection.Name = "gradeUnusedErrorCorrection"
        Me.gradeUnusedErrorCorrection.Size = New System.Drawing.Size(41, 20)
        Me.gradeUnusedErrorCorrection.TabIndex = 5
        '
        'gradeAxialNonuniformity
        '
        Me.gradeAxialNonuniformity.Location = New System.Drawing.Point(171, 122)
        Me.gradeAxialNonuniformity.Name = "gradeAxialNonuniformity"
        Me.gradeAxialNonuniformity.Size = New System.Drawing.Size(41, 20)
        Me.gradeAxialNonuniformity.TabIndex = 4
        '
        'gradePrintGrowth
        '
        Me.gradePrintGrowth.Location = New System.Drawing.Point(171, 96)
        Me.gradePrintGrowth.Name = "gradePrintGrowth"
        Me.gradePrintGrowth.Size = New System.Drawing.Size(41, 20)
        Me.gradePrintGrowth.TabIndex = 3
        '
        'gradeSymbolContrast
        '
        Me.gradeSymbolContrast.Location = New System.Drawing.Point(171, 70)
        Me.gradeSymbolContrast.Name = "gradeSymbolContrast"
        Me.gradeSymbolContrast.Size = New System.Drawing.Size(41, 20)
        Me.gradeSymbolContrast.TabIndex = 2
        '
        'gradeDecoding
        '
        Me.gradeDecoding.Location = New System.Drawing.Point(171, 44)
        Me.gradeDecoding.Name = "gradeDecoding"
        Me.gradeDecoding.Size = New System.Drawing.Size(41, 20)
        Me.gradeDecoding.TabIndex = 1
        '
        'gradeOverall
        '
        Me.gradeOverall.Location = New System.Drawing.Point(171, 18)
        Me.gradeOverall.Name = "gradeOverall"
        Me.gradeOverall.Size = New System.Drawing.Size(41, 20)
        Me.gradeOverall.TabIndex = 0
        '
        'timer1
        '
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(164, 89)
        Me.DelaySlider1.Maximum = 1000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 14
        Me.DelaySlider1.Value = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 475)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.gradeDMBox)
        Me.Controls.Add(Me.useOptionsBox)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.barcodeType)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "2D Barcode"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private WithEvents barcodeType As System.Windows.Forms.ListBox
    Private label2 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private dataFound As System.Windows.Forms.TextBox
    Private typeFound As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private readTime As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private WithEvents startButton As System.Windows.Forms.Button
    Private WithEvents stopButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private useOptionsBox As System.Windows.Forms.CheckBox
    Private gradeDMBox As System.Windows.Forms.CheckBox
    Private groupBox2 As System.Windows.Forms.GroupBox
    Private label7 As System.Windows.Forms.Label
    Private gradeUnusedErrorCorrection As System.Windows.Forms.TextBox
    Private gradeAxialNonuniformity As System.Windows.Forms.TextBox
    Private gradePrintGrowth As System.Windows.Forms.TextBox
    Private gradeSymbolContrast As System.Windows.Forms.TextBox
    Private gradeDecoding As System.Windows.Forms.TextBox
    Private gradeOverall As System.Windows.Forms.TextBox
    Private label10 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label12 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class
