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
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.confidenceLevel = New System.Windows.Forms.TextBox
        Me.barcodeString = New System.Windows.Forms.TextBox
        Me.quitButton = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.unwrapBarcodeButton = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 25)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(501, 256)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(74, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Original Image"
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 305)
        Me.imageViewer2.Name = "imageViewer2"
        Me.imageViewer2.Size = New System.Drawing.Size(501, 74)
        Me.imageViewer2.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(9, 289)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(94, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Unwrapped Image"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.confidenceLevel)
        Me.groupBox1.Controls.Add(Me.barcodeString)
        Me.groupBox1.Location = New System.Drawing.Point(12, 397)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(175, 76)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Barcode Results"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(9, 47)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(93, 13)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Confidence Level:"
        Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(22, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Barcode String:"
        Me.label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'confidenceLevel
        '
        Me.confidenceLevel.Location = New System.Drawing.Point(108, 44)
        Me.confidenceLevel.Name = "confidenceLevel"
        Me.confidenceLevel.ReadOnly = True
        Me.confidenceLevel.Size = New System.Drawing.Size(60, 20)
        Me.confidenceLevel.TabIndex = 0
        '
        'barcodeString
        '
        Me.barcodeString.Location = New System.Drawing.Point(108, 18)
        Me.barcodeString.Name = "barcodeString"
        Me.barcodeString.ReadOnly = True
        Me.barcodeString.Size = New System.Drawing.Size(60, 20)
        Me.barcodeString.TabIndex = 0
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(456, 435)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(57, 30)
        Me.quitButton.TabIndex = 5
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(355, 397)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(96, 30)
        Me.loadImageButton.TabIndex = 5
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'unwrapBarcodeButton
        '
        Me.unwrapBarcodeButton.Enabled = False
        Me.unwrapBarcodeButton.Location = New System.Drawing.Point(355, 435)
        Me.unwrapBarcodeButton.Name = "unwrapBarcodeButton"
        Me.unwrapBarcodeButton.Size = New System.Drawing.Size(95, 30)
        Me.unwrapBarcodeButton.TabIndex = 5
        Me.unwrapBarcodeButton.Text = "Unwrap Barcode"
        Me.unwrapBarcodeButton.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(194, 387)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 13)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Instructions:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(194, 406)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(111, 13)
        Me.label6.TabIndex = 6
        Me.label6.Text = "1. Load the image file."
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(194, 432)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(119, 13)
        Me.label7.TabIndex = 6
        Me.label7.Text = "2. Unwrap the barcode."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 485)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.unwrapBarcodeButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Unwrap Barcode Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imageViewer2 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label2 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label4 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private confidenceLevel As System.Windows.Forms.TextBox
    Private barcodeString As System.Windows.Forms.TextBox
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents unwrapBarcodeButton As System.Windows.Forms.Button
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
End Class