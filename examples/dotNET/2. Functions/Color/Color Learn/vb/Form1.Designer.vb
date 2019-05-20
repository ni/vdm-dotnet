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
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.saturationThreshold = New System.Windows.Forms.NumericUpDown
        Me.colorSensitivityBox = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.loadButton = New System.Windows.Forms.Button
        Me.learnButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label8 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        CType(Me.saturationThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(479, 361)
        Me.imageViewer1.TabIndex = 0
        '
        'pictureBox1
        '
        Me.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pictureBox1.Location = New System.Drawing.Point(505, 26)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(249, 173)
        Me.pictureBox1.TabIndex = 1
        Me.pictureBox1.TabStop = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(502, 10)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(121, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Learned Color Spectrum"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.saturationThreshold)
        Me.groupBox1.Controls.Add(Me.colorSensitivityBox)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(505, 218)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(248, 91)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Learn Parameters"
        '
        'saturationThreshold
        '
        Me.saturationThreshold.Location = New System.Drawing.Point(124, 54)
        Me.saturationThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.saturationThreshold.Name = "saturationThreshold"
        Me.saturationThreshold.Size = New System.Drawing.Size(44, 20)
        Me.saturationThreshold.TabIndex = 2
        Me.saturationThreshold.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'colorSensitivityBox
        '
        Me.colorSensitivityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.colorSensitivityBox.FormattingEnabled = True
        Me.colorSensitivityBox.Items.AddRange(New Object() {"Low", "Medium", "High"})
        Me.colorSensitivityBox.Location = New System.Drawing.Point(124, 20)
        Me.colorSensitivityBox.Name = "colorSensitivityBox"
        Me.colorSensitivityBox.Size = New System.Drawing.Size(108, 21)
        Me.colorSensitivityBox.TabIndex = 1
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 56)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(108, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Saturation Threshold:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(30, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(84, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Color Sensitivity:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(502, 322)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(64, 13)
        Me.label4.TabIndex = 4
        Me.label4.Text = "Instructions:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(502, 338)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(108, 13)
        Me.label5.TabIndex = 4
        Me.label5.Text = "1. Load an image file."
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(502, 353)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(260, 29)
        Me.label6.TabIndex = 4
        Me.label6.Text = "2. Select a region of interest (ROI).  To select multiple ROIs, press the Ctrl ke" & _
            "y while selecting an area."
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(502, 382)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(252, 35)
        Me.label7.TabIndex = 4
        Me.label7.Text = "3. Select the color sensitivity and the saturation threshold.  Click Learn Colors" & _
            "."
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(12, 384)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(85, 37)
        Me.loadButton.TabIndex = 5
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'learnButton
        '
        Me.learnButton.Location = New System.Drawing.Point(103, 384)
        Me.learnButton.Name = "learnButton"
        Me.learnButton.Size = New System.Drawing.Size(85, 37)
        Me.learnButton.TabIndex = 5
        Me.learnButton.Text = "Learn Colors"
        Me.learnButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(194, 384)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(85, 37)
        Me.quitButton.TabIndex = 5
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 433)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(64, 13)
        Me.label8.TabIndex = 6
        Me.label8.Text = "Image Path:"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(79, 430)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(381, 20)
        Me.imagePath.TabIndex = 7
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(466, 430)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(25, 20)
        Me.browseButton.TabIndex = 8
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(766, 460)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.learnButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Color Learn Example"
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.saturationThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Private label1 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private saturationThreshold As System.Windows.Forms.NumericUpDown
    Private colorSensitivityBox As System.Windows.Forms.ComboBox
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private WithEvents learnButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label8 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
End Class