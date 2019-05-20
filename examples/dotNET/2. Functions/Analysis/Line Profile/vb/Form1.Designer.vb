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
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.countBox = New System.Windows.Forms.TextBox
        Me.maximumBox = New System.Windows.Forms.TextBox
        Me.stdDevBox = New System.Windows.Forms.TextBox
        Me.meanBox = New System.Windows.Forms.TextBox
        Me.minimumBox = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.loadButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SimpleGraph1 = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(452, 347)
        Me.imageViewer1.TabIndex = 0
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.countBox)
        Me.groupBox1.Controls.Add(Me.maximumBox)
        Me.groupBox1.Controls.Add(Me.stdDevBox)
        Me.groupBox1.Controls.Add(Me.meanBox)
        Me.groupBox1.Controls.Add(Me.minimumBox)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(470, 202)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(300, 102)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Line Information"
        '
        'countBox
        '
        Me.countBox.Location = New System.Drawing.Point(63, 76)
        Me.countBox.Name = "countBox"
        Me.countBox.Size = New System.Drawing.Size(55, 20)
        Me.countBox.TabIndex = 1
        '
        'maximumBox
        '
        Me.maximumBox.Location = New System.Drawing.Point(63, 50)
        Me.maximumBox.Name = "maximumBox"
        Me.maximumBox.Size = New System.Drawing.Size(55, 20)
        Me.maximumBox.TabIndex = 1
        '
        'stdDevBox
        '
        Me.stdDevBox.Location = New System.Drawing.Point(229, 63)
        Me.stdDevBox.Name = "stdDevBox"
        Me.stdDevBox.Size = New System.Drawing.Size(55, 20)
        Me.stdDevBox.TabIndex = 1
        '
        'meanBox
        '
        Me.meanBox.Location = New System.Drawing.Point(229, 36)
        Me.meanBox.Name = "meanBox"
        Me.meanBox.Size = New System.Drawing.Size(55, 20)
        Me.meanBox.TabIndex = 1
        '
        'minimumBox
        '
        Me.minimumBox.Location = New System.Drawing.Point(63, 23)
        Me.minimumBox.Name = "minimumBox"
        Me.minimumBox.Size = New System.Drawing.Size(55, 20)
        Me.minimumBox.TabIndex = 1
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 79)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(38, 13)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Count:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 53)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(54, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Maximum:"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(130, 66)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(101, 13)
        Me.label5.TabIndex = 0
        Me.label5.Text = "Standard Deviation:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(130, 39)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(67, 13)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Mean Value:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(51, 13)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Minimum:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(10, 374)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(64, 13)
        Me.label6.TabIndex = 3
        Me.label6.Text = "Image Path:"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(81, 371)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(348, 20)
        Me.imagePath.TabIndex = 4
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(435, 372)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(29, 19)
        Me.browseButton.TabIndex = 5
        Me.browseButton.Text = "..."
        Me.browseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(467, 329)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(64, 13)
        Me.label8.TabIndex = 7
        Me.label8.Text = "Instructions:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(466, 342)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(108, 13)
        Me.label9.TabIndex = 7
        Me.label9.Text = "1. Load an image file."
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(466, 355)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(257, 32)
        Me.label10.TabIndex = 7
        Me.label10.Text = "2. Draw a line on the image.  The line information is computed and displayed."
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(470, 403)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(73, 32)
        Me.loadButton.TabIndex = 8
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(549, 403)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(73, 32)
        Me.exitButton.TabIndex = 8
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'SimpleGraph1
        '
        Me.SimpleGraph1.AutoSize = True
        Me.SimpleGraph1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SimpleGraph1.Location = New System.Drawing.Point(470, 12)
        Me.SimpleGraph1.Name = "SimpleGraph1"
        Me.SimpleGraph1.Size = New System.Drawing.Size(303, 166)
        Me.SimpleGraph1.TabIndex = 9
        Me.SimpleGraph1.XAxisScaling = NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph.AxisScalingMode.[Auto]
        Me.SimpleGraph1.YAxisScaling = NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph.AxisScalingMode.Fixed
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(777, 445)
        Me.Controls.Add(Me.SimpleGraph1)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Line Profile Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private countBox As System.Windows.Forms.TextBox
    Private maximumBox As System.Windows.Forms.TextBox
    Private stdDevBox As System.Windows.Forms.TextBox
    Private meanBox As System.Windows.Forms.TextBox
    Private minimumBox As System.Windows.Forms.TextBox
    Private label5 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label8 As System.Windows.Forms.Label
    Private label9 As System.Windows.Forms.Label
    Private label10 As System.Windows.Forms.Label
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SimpleGraph1 As NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph
End Class