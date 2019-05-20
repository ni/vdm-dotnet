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
        Dim Palette1 As NationalInstruments.Vision.WindowsForms.Palette = New NationalInstruments.Vision.WindowsForms.Palette
        Me.imageViewerOriginal = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewerThresholded = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.browseButton = New System.Windows.Forms.Button
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.localTab = New System.Windows.Forms.TabPage
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.localYSize = New System.Windows.Forms.NumericUpDown
        Me.label6 = New System.Windows.Forms.Label
        Me.localXSize = New System.Windows.Forms.NumericUpDown
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.niblackUpDown = New System.Windows.Forms.NumericUpDown
        Me.label3 = New System.Windows.Forms.Label
        Me.localMethodBox = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.localObjectBox = New System.Windows.Forms.ComboBox
        Me.autoTab = New System.Windows.Forms.TabPage
        Me.label7 = New System.Windows.Forms.Label
        Me.autoObjectBox = New System.Windows.Forms.ComboBox
        Me.autoMethodBox = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.manualTab = New System.Windows.Forms.TabPage
        Me.manualMaximumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.manualMinimumSlide = New NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.tabControl1.SuspendLayout()
        Me.localTab.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.localYSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.localXSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.niblackUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.autoTab.SuspendLayout()
        Me.manualTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewerOriginal
        '
        Me.imageViewerOriginal.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
        Me.imageViewerOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewerOriginal.Location = New System.Drawing.Point(289, 7)
        Me.imageViewerOriginal.Name = "imageViewerOriginal"
        Me.imageViewerOriginal.Size = New System.Drawing.Size(267, 242)
        Me.imageViewerOriginal.TabIndex = 0
        '
        'imageViewerThresholded
        '
        Me.imageViewerThresholded.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Selection
        Me.imageViewerThresholded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewerThresholded.Location = New System.Drawing.Point(289, 267)
        Me.imageViewerThresholded.Name = "imageViewerThresholded"
        Palette1.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
        Me.imageViewerThresholded.Palette = Palette1
        Me.imageViewerThresholded.Size = New System.Drawing.Size(267, 242)
        Me.imageViewerThresholded.TabIndex = 1
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(12, 25)
        Me.imagePath.Multiline = True
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(185, 120)
        Me.imagePath.TabIndex = 2
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Image Path"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(203, 25)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(30, 23)
        Me.browseButton.TabIndex = 4
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.localTab)
        Me.tabControl1.Controls.Add(Me.autoTab)
        Me.tabControl1.Controls.Add(Me.manualTab)
        Me.tabControl1.Location = New System.Drawing.Point(12, 161)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(220, 227)
        Me.tabControl1.TabIndex = 5
        '
        'localTab
        '
        Me.localTab.Controls.Add(Me.groupBox1)
        Me.localTab.Controls.Add(Me.label4)
        Me.localTab.Controls.Add(Me.niblackUpDown)
        Me.localTab.Controls.Add(Me.label3)
        Me.localTab.Controls.Add(Me.localMethodBox)
        Me.localTab.Controls.Add(Me.label2)
        Me.localTab.Controls.Add(Me.localObjectBox)
        Me.localTab.Location = New System.Drawing.Point(4, 22)
        Me.localTab.Name = "localTab"
        Me.localTab.Padding = New System.Windows.Forms.Padding(3)
        Me.localTab.Size = New System.Drawing.Size(212, 201)
        Me.localTab.TabIndex = 0
        Me.localTab.Text = "Local"
        Me.localTab.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.localYSize)
        Me.groupBox1.Controls.Add(Me.label6)
        Me.groupBox1.Controls.Add(Me.localXSize)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Location = New System.Drawing.Point(16, 122)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(122, 73)
        Me.groupBox1.TabIndex = 6
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Window Size"
        '
        'localYSize
        '
        Me.localYSize.Location = New System.Drawing.Point(64, 44)
        Me.localYSize.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.localYSize.Name = "localYSize"
        Me.localYSize.Size = New System.Drawing.Size(43, 20)
        Me.localYSize.TabIndex = 9
        Me.localYSize.Value = New Decimal(New Integer() {160, 0, 0, 0})
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(44, 46)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(14, 13)
        Me.label6.TabIndex = 8
        Me.label6.Text = "Y"
        '
        'localXSize
        '
        Me.localXSize.Location = New System.Drawing.Point(64, 18)
        Me.localXSize.Maximum = New Decimal(New Integer() {65000, 0, 0, 0})
        Me.localXSize.Name = "localXSize"
        Me.localXSize.Size = New System.Drawing.Size(43, 20)
        Me.localXSize.TabIndex = 7
        Me.localXSize.Value = New Decimal(New Integer() {160, 0, 0, 0})
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(44, 20)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(14, 13)
        Me.label5.TabIndex = 0
        Me.label5.Text = "X"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(13, 76)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(58, 43)
        Me.label4.TabIndex = 5
        Me.label4.Text = "Niblack Deviation Factor"
        '
        'niblackUpDown
        '
        Me.niblackUpDown.DecimalPlaces = 1
        Me.niblackUpDown.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.niblackUpDown.Location = New System.Drawing.Point(76, 84)
        Me.niblackUpDown.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.niblackUpDown.Name = "niblackUpDown"
        Me.niblackUpDown.Size = New System.Drawing.Size(47, 20)
        Me.niblackUpDown.TabIndex = 4
        Me.niblackUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(28, 48)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(43, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Method"
        '
        'localMethodBox
        '
        Me.localMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.localMethodBox.FormattingEnabled = True
        Me.localMethodBox.Items.AddRange(New Object() {"Niblack", "Background Correction"})
        Me.localMethodBox.Location = New System.Drawing.Point(77, 45)
        Me.localMethodBox.Name = "localMethodBox"
        Me.localMethodBox.Size = New System.Drawing.Size(104, 21)
        Me.localMethodBox.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 19)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Object Type"
        '
        'localObjectBox
        '
        Me.localObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.localObjectBox.FormattingEnabled = True
        Me.localObjectBox.Items.AddRange(New Object() {"Bright Objects", "Dark Objects"})
        Me.localObjectBox.Location = New System.Drawing.Point(77, 16)
        Me.localObjectBox.Name = "localObjectBox"
        Me.localObjectBox.Size = New System.Drawing.Size(104, 21)
        Me.localObjectBox.TabIndex = 0
        '
        'autoTab
        '
        Me.autoTab.Controls.Add(Me.label7)
        Me.autoTab.Controls.Add(Me.autoObjectBox)
        Me.autoTab.Controls.Add(Me.autoMethodBox)
        Me.autoTab.Controls.Add(Me.label8)
        Me.autoTab.Location = New System.Drawing.Point(4, 22)
        Me.autoTab.Name = "autoTab"
        Me.autoTab.Padding = New System.Windows.Forms.Padding(3)
        Me.autoTab.Size = New System.Drawing.Size(212, 201)
        Me.autoTab.TabIndex = 1
        Me.autoTab.Text = "Automatic"
        Me.autoTab.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(28, 48)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(43, 13)
        Me.label7.TabIndex = 9
        Me.label7.Text = "Method"
        '
        'autoObjectBox
        '
        Me.autoObjectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoObjectBox.FormattingEnabled = True
        Me.autoObjectBox.Items.AddRange(New Object() {"Bright Objects", "Dark Objects"})
        Me.autoObjectBox.Location = New System.Drawing.Point(77, 16)
        Me.autoObjectBox.Name = "autoObjectBox"
        Me.autoObjectBox.Size = New System.Drawing.Size(104, 21)
        Me.autoObjectBox.TabIndex = 6
        '
        'autoMethodBox
        '
        Me.autoMethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.autoMethodBox.FormattingEnabled = True
        Me.autoMethodBox.Items.AddRange(New Object() {"clustering", "entropy", "metric", "moments", "inter-class variance"})
        Me.autoMethodBox.Location = New System.Drawing.Point(77, 45)
        Me.autoMethodBox.Name = "autoMethodBox"
        Me.autoMethodBox.Size = New System.Drawing.Size(104, 21)
        Me.autoMethodBox.TabIndex = 8
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 19)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(65, 13)
        Me.label8.TabIndex = 7
        Me.label8.Text = "Object Type"
        '
        'manualTab
        '
        Me.manualTab.Controls.Add(Me.manualMaximumSlide)
        Me.manualTab.Controls.Add(Me.manualMinimumSlide)
        Me.manualTab.Controls.Add(Me.label10)
        Me.manualTab.Controls.Add(Me.label11)
        Me.manualTab.Location = New System.Drawing.Point(4, 22)
        Me.manualTab.Name = "manualTab"
        Me.manualTab.Padding = New System.Windows.Forms.Padding(3)
        Me.manualTab.Size = New System.Drawing.Size(212, 201)
        Me.manualTab.TabIndex = 2
        Me.manualTab.Text = "Manual"
        Me.manualTab.UseVisualStyleBackColor = True
        '
        'manualMaximumSlide
        '
        Me.manualMaximumSlide.AutoSize = True
        Me.manualMaximumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.manualMaximumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.manualMaximumSlide.Location = New System.Drawing.Point(3, 109)
        Me.manualMaximumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.manualMaximumSlide.Name = "manualMaximumSlide"
        Me.manualMaximumSlide.Size = New System.Drawing.Size(203, 53)
        Me.manualMaximumSlide.TabIndex = 16
        Me.manualMaximumSlide.Value = 100
        '
        'manualMinimumSlide
        '
        Me.manualMinimumSlide.AutoSize = True
        Me.manualMinimumSlide.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.manualMinimumSlide.ColorSet = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.ColorScheme.[Default]
        Me.manualMinimumSlide.Location = New System.Drawing.Point(3, 25)
        Me.manualMinimumSlide.Mode = NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider.SliderRangeMode.[Default]
        Me.manualMinimumSlide.Name = "manualMinimumSlide"
        Me.manualMinimumSlide.Size = New System.Drawing.Size(203, 53)
        Me.manualMinimumSlide.TabIndex = 16
        Me.manualMinimumSlide.Value = 0
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(25, 93)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(81, 13)
        Me.label10.TabIndex = 14
        Me.label10.Text = "Maximum Value"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(25, 9)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(78, 13)
        Me.label11.TabIndex = 15
        Me.label11.Text = "Minimum Value"
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(17, 468)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(72, 40)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 520)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.imageViewerThresholded)
        Me.Controls.Add(Me.imageViewerOriginal)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.tabControl1.ResumeLayout(False)
        Me.localTab.ResumeLayout(False)
        Me.localTab.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.localYSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.localXSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.niblackUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.autoTab.ResumeLayout(False)
        Me.autoTab.PerformLayout()
        Me.manualTab.ResumeLayout(False)
        Me.manualTab.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewerOriginal As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewerThresholded As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imagePath As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private localTab As System.Windows.Forms.TabPage
    Private WithEvents niblackUpDown As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private WithEvents localMethodBox As System.Windows.Forms.ComboBox
    Private label2 As System.Windows.Forms.Label
    Private WithEvents localObjectBox As System.Windows.Forms.ComboBox
    Private autoTab As System.Windows.Forms.TabPage
    Private manualTab As System.Windows.Forms.TabPage
    Private label4 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents localYSize As System.Windows.Forms.NumericUpDown
    Private label6 As System.Windows.Forms.Label
    Private WithEvents localXSize As System.Windows.Forms.NumericUpDown
    Private label5 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents autoObjectBox As System.Windows.Forms.ComboBox
    Private WithEvents autoMethodBox As System.Windows.Forms.ComboBox
    Private label8 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private label11 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents manualMaximumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
    Friend WithEvents manualMinimumSlide As NationalInstruments.Vision.MeasurementStudioDemo.GenericSlider
End Class