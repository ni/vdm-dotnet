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
        Me.label4 = New System.Windows.Forms.Label
        Me.xValueUpDown = New System.Windows.Forms.NumericUpDown
        Me.xValueLabel = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.operatorBox = New System.Windows.Forms.ComboBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        CType(Me.xValueUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(500, 267)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 285)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(500, 267)
        Me.imageViewer2.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 557)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(76, 554)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(403, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(485, 555)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 19)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.xValueUpDown)
        Me.groupBox1.Controls.Add(Me.xValueLabel)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.operatorBox)
        Me.groupBox1.Location = New System.Drawing.Point(12, 580)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(176, 87)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Options"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 69)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(165, 13)
        Me.label4.TabIndex = 4
        Me.label4.Text = "(for Power X and Power 1/X only)"
        '
        'xValueUpDown
        '
        Me.xValueUpDown.DecimalPlaces = 1
        Me.xValueUpDown.Enabled = False
        Me.xValueUpDown.Location = New System.Drawing.Point(67, 46)
        Me.xValueUpDown.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.xValueUpDown.Name = "xValueUpDown"
        Me.xValueUpDown.Size = New System.Drawing.Size(39, 20)
        Me.xValueUpDown.TabIndex = 3
        Me.xValueUpDown.Value = New Decimal(New Integer() {15, 0, 0, 65536})
        '
        'xValueLabel
        '
        Me.xValueLabel.AutoSize = True
        Me.xValueLabel.Location = New System.Drawing.Point(14, 48)
        Me.xValueLabel.Name = "xValueLabel"
        Me.xValueLabel.Size = New System.Drawing.Size(44, 13)
        Me.xValueLabel.TabIndex = 2
        Me.xValueLabel.Text = "X Value"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 22)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(48, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Operator"
        '
        'operatorBox
        '
        Me.operatorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.operatorBox.FormattingEnabled = True
        Me.operatorBox.Items.AddRange(New Object() {"Linear", "Log", "Exponential", "Square", "Square Root", "Power X", "Power 1/X"})
        Me.operatorBox.Location = New System.Drawing.Point(67, 19)
        Me.operatorBox.Name = "operatorBox"
        Me.operatorBox.Size = New System.Drawing.Size(103, 21)
        Me.operatorBox.TabIndex = 0
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(200, 579)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 5
        Me.label5.Text = "Instructions:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(200, 597)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(108, 13)
        Me.label6.TabIndex = 5
        Me.label6.Text = "1. Load an image file."
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(200, 613)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(312, 28)
        Me.label7.TabIndex = 5
        Me.label7.Text = "2. Modify the mathematical operator and the exponent of the power function (X Val" & _
            "ue)."
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(453, 649)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(66, 25)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(371, 649)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(76, 25)
        Me.loadImageButton.TabIndex = 6
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 679)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Math Lookup Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.xValueUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label2 As System.Windows.Forms.Label
    Private WithEvents operatorBox As System.Windows.Forms.ComboBox
    Private WithEvents xValueUpDown As System.Windows.Forms.NumericUpDown
    Private xValueLabel As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
End Class