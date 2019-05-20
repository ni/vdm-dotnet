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
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.yStep = New System.Windows.Forms.NumericUpDown
        Me.xStep = New System.Windows.Forms.NumericUpDown
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        CType(Me.yStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(486, 249)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 267)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(486, 249)
        Me.imageViewer2.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 524)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(76, 521)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(388, 20)
        Me.imagePath.TabIndex = 3
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(470, 522)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 19)
        Me.browseButton.TabIndex = 4
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.yStep)
        Me.groupBox1.Controls.Add(Me.xStep)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(12, 556)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(113, 69)
        Me.groupBox1.TabIndex = 5
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Options"
        '
        'yStep
        '
        Me.yStep.Location = New System.Drawing.Point(58, 37)
        Me.yStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.yStep.Name = "yStep"
        Me.yStep.Size = New System.Drawing.Size(44, 20)
        Me.yStep.TabIndex = 1
        Me.yStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'xStep
        '
        Me.xStep.Location = New System.Drawing.Point(58, 14)
        Me.xStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.xStep.Name = "xStep"
        Me.xStep.Size = New System.Drawing.Size(44, 20)
        Me.xStep.TabIndex = 1
        Me.xStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(10, 39)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(39, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Y Step"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(39, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "X Step"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(155, 547)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(64, 13)
        Me.label4.TabIndex = 6
        Me.label4.Text = "Instructions:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(155, 560)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(108, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "1. Load an image file."
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(155, 573)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(298, 13)
        Me.label6.TabIndex = 6
        Me.label6.Text = "2. Draw a region of interest (ROI) around the region to extract."
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(444, 597)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(53, 28)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(365, 597)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(73, 28)
        Me.loadImageButton.TabIndex = 7
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 637)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Extract Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.yStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents yStep As System.Windows.Forms.NumericUpDown
    Private WithEvents xStep As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
End Class