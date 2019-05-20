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
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.minimumHeywood = New System.Windows.Forms.NumericUpDown
        Me.label3 = New System.Windows.Forms.Label
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.processImageButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        CType(Me.minimumHeywood, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(474, 325)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 342)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(12, 360)
        Me.imagePath.Multiline = True
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(445, 42)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(461, 359)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(24, 20)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 408)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(96, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Minimum Heywood"
        '
        'minimumHeywood
        '
        Me.minimumHeywood.DecimalPlaces = 2
        Me.minimumHeywood.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.minimumHeywood.Location = New System.Drawing.Point(113, 406)
        Me.minimumHeywood.Name = "minimumHeywood"
        Me.minimumHeywood.Size = New System.Drawing.Size(48, 20)
        Me.minimumHeywood.TabIndex = 5
        Me.minimumHeywood.Value = New Decimal(New Integer() {105, 0, 0, 131072})
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(167, 408)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(168, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "(The closer to 1, the more circular)"
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(398, 410)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(86, 28)
        Me.loadImageButton.TabIndex = 7
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'processImageButton
        '
        Me.processImageButton.Enabled = False
        Me.processImageButton.Location = New System.Drawing.Point(398, 444)
        Me.processImageButton.Name = "processImageButton"
        Me.processImageButton.Size = New System.Drawing.Size(86, 28)
        Me.processImageButton.TabIndex = 7
        Me.processImageButton.Text = "Process Image"
        Me.processImageButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(398, 478)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(86, 28)
        Me.quitButton.TabIndex = 7
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(9, 431)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(381, 30)
        Me.label4.TabIndex = 8
        Me.label4.Text = "This example loads an image file, displays it, and performs the following process" & _
            "es:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(9, 461)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(175, 13)
        Me.label5.TabIndex = 8
        Me.label5.Text = "- Automatically thresholds the image"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(9, 477)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(76, 13)
        Me.label6.TabIndex = 9
        Me.label6.Text = "- Detects parts"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(9, 493)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(137, 13)
        Me.label7.TabIndex = 9
        Me.label7.Text = "- Extracts shape descriptors"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(9, 509)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(277, 13)
        Me.label8.TabIndex = 9
        Me.label8.Text = "- Keeps circular parts using the Heywood circularity factor"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(9, 525)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(267, 13)
        Me.label9.TabIndex = 9
        Me.label9.Text = "- Computes and draws distances between circular parts"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 548)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.processImageButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.minimumHeywood)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Circle Distance Example"
        CType(Me.minimumHeywood, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private WithEvents minimumHeywood As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents processImageButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
End Class