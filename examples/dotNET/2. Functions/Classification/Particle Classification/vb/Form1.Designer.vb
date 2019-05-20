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
        Me.classifierPath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.loadButton = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.classifyButton = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.label6 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.scoreBox = New System.Windows.Forms.TextBox
        Me.classBox = New System.Windows.Forms.TextBox
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(279, 22)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(322, 300)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(276, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(36, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image"
        '
        'classifierPath
        '
        Me.classifierPath.Location = New System.Drawing.Point(10, 20)
        Me.classifierPath.Multiline = True
        Me.classifierPath.Name = "classifierPath"
        Me.classifierPath.Size = New System.Drawing.Size(173, 56)
        Me.classifierPath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(189, 20)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(57, 29)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "Browse"
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 4)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(92, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Classifier File Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(10, 100)
        Me.imagePath.Multiline = True
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(172, 59)
        Me.imagePath.TabIndex = 5
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 84)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(80, 13)
        Me.label3.TabIndex = 6
        Me.label3.Text = "Image File Path"
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(10, 177)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(87, 40)
        Me.loadButton.TabIndex = 7
        Me.loadButton.Text = "Load File"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(103, 191)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(91, 13)
        Me.label4.TabIndex = 8
        Me.label4.Text = "1. Click Load File."
        '
        'classifyButton
        '
        Me.classifyButton.Enabled = False
        Me.classifyButton.Location = New System.Drawing.Point(10, 223)
        Me.classifyButton.Name = "classifyButton"
        Me.classifyButton.Size = New System.Drawing.Size(87, 40)
        Me.classifyButton.TabIndex = 7
        Me.classifyButton.Text = "Classify"
        Me.classifyButton.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(103, 223)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(170, 40)
        Me.label5.TabIndex = 8
        Me.label5.Text = "2. Draw an ROI around the object to classify, and then click Classify."
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(10, 421)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(87, 41)
        Me.exitButton.TabIndex = 7
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(103, 435)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(170, 27)
        Me.label6.TabIndex = 8
        Me.label6.Text = "3. Stop the example."
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label8)
        Me.groupBox1.Controls.Add(Me.label7)
        Me.groupBox1.Controls.Add(Me.scoreBox)
        Me.groupBox1.Controls.Add(Me.classBox)
        Me.groupBox1.Location = New System.Drawing.Point(13, 276)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(128, 98)
        Me.groupBox1.TabIndex = 9
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Results"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 55)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(77, 13)
        Me.label8.TabIndex = 1
        Me.label8.Text = "Score (0-1000)"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 16)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(32, 13)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Class"
        '
        'scoreBox
        '
        Me.scoreBox.Location = New System.Drawing.Point(6, 71)
        Me.scoreBox.Name = "scoreBox"
        Me.scoreBox.Size = New System.Drawing.Size(74, 20)
        Me.scoreBox.TabIndex = 0
        '
        'classBox
        '
        Me.classBox.Location = New System.Drawing.Point(6, 32)
        Me.classBox.Name = "classBox"
        Me.classBox.Size = New System.Drawing.Size(105, 20)
        Me.classBox.TabIndex = 0
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(613, 477)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.classifyButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.classifierPath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Classification"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private classifierPath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private WithEvents classifyButton As System.Windows.Forms.Button
    Private label5 As System.Windows.Forms.Label
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private label6 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label8 As System.Windows.Forms.Label
    Private label7 As System.Windows.Forms.Label
    Private scoreBox As System.Windows.Forms.TextBox
    Private classBox As System.Windows.Forms.TextBox
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class