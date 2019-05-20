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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.imageViewer2 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.toleranceUpDown = New System.Windows.Forms.NumericUpDown
        Me.connectivity4Button = New System.Windows.Forms.RadioButton
        Me.connectivity8Button = New System.Windows.Forms.RadioButton
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.quitButton = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.groupBox1.SuspendLayout()
        CType(Me.toleranceUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.ContextSensitiveTools = False
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(533, 297)
        Me.imageViewer1.TabIndex = 0
        '
        'imageViewer2
        '
        Me.imageViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer2.Location = New System.Drawing.Point(12, 326)
        Me.imageViewer2.Name = "imageViewer2"
        Palette1.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary
        Me.imageViewer2.Palette = Palette1
        Me.imageViewer2.Size = New System.Drawing.Size(533, 297)
        Me.imageViewer2.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 631)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(79, 628)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(430, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(517, 628)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(28, 20)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.toleranceUpDown)
        Me.groupBox1.Controls.Add(Me.connectivity4Button)
        Me.groupBox1.Controls.Add(Me.connectivity8Button)
        Me.groupBox1.Location = New System.Drawing.Point(12, 659)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(124, 76)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Options"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(64, 54)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(55, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Tolerance"
        '
        'toleranceUpDown
        '
        Me.toleranceUpDown.Location = New System.Drawing.Point(11, 52)
        Me.toleranceUpDown.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.toleranceUpDown.Name = "toleranceUpDown"
        Me.toleranceUpDown.Size = New System.Drawing.Size(50, 20)
        Me.toleranceUpDown.TabIndex = 1
        Me.toleranceUpDown.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'connectivity4Button
        '
        Me.connectivity4Button.AutoSize = True
        Me.connectivity4Button.Checked = True
        Me.connectivity4Button.Location = New System.Drawing.Point(11, 31)
        Me.connectivity4Button.Name = "connectivity4Button"
        Me.connectivity4Button.Size = New System.Drawing.Size(92, 17)
        Me.connectivity4Button.TabIndex = 0
        Me.connectivity4Button.TabStop = True
        Me.connectivity4Button.Text = "4-Connectivity"
        Me.connectivity4Button.UseVisualStyleBackColor = True
        '
        'connectivity8Button
        '
        Me.connectivity8Button.AutoSize = True
        Me.connectivity8Button.Location = New System.Drawing.Point(11, 15)
        Me.connectivity8Button.Name = "connectivity8Button"
        Me.connectivity8Button.Size = New System.Drawing.Size(92, 17)
        Me.connectivity8Button.TabIndex = 0
        Me.connectivity8Button.Text = "8-Connectivity"
        Me.connectivity8Button.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(169, 659)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 13)
        Me.label3.TabIndex = 5
        Me.label3.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(169, 673)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(108, 13)
        Me.label4.TabIndex = 5
        Me.label4.Text = "1. Load an image file."
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(169, 687)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(211, 13)
        Me.label5.TabIndex = 5
        Me.label5.Text = "2. Click on the object you want to segment."
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(482, 706)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(63, 29)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(404, 706)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(72, 29)
        Me.loadImageButton.TabIndex = 6
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(559, 743)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer2)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Magic Wand Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.toleranceUpDown, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private connectivity4Button As System.Windows.Forms.RadioButton
    Private connectivity8Button As System.Windows.Forms.RadioButton
    Private label2 As System.Windows.Forms.Label
    Private toleranceUpDown As System.Windows.Forms.NumericUpDown
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
End Class