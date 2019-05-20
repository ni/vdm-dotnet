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
        Me.label1 = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.showParticleArea = New System.Windows.Forms.CheckBox
        Me.connectivity4Button = New System.Windows.Forms.RadioButton
        Me.connectivity8Button = New System.Windows.Forms.RadioButton
        Me.label2 = New System.Windows.Forms.Label
        Me.numberOfParticles = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.SimpleRangeSelect1 = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleRangeSelect
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 214)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(72, 210)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(347, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(425, 210)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(29, 20)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.showParticleArea)
        Me.groupBox1.Controls.Add(Me.connectivity4Button)
        Me.groupBox1.Controls.Add(Me.connectivity8Button)
        Me.groupBox1.Location = New System.Drawing.Point(11, 236)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(133, 79)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Options"
        '
        'showParticleArea
        '
        Me.showParticleArea.AutoSize = True
        Me.showParticleArea.Location = New System.Drawing.Point(11, 60)
        Me.showParticleArea.Name = "showParticleArea"
        Me.showParticleArea.Size = New System.Drawing.Size(123, 17)
        Me.showParticleArea.TabIndex = 1
        Me.showParticleArea.Text = "Display Particle Area"
        Me.showParticleArea.UseVisualStyleBackColor = True
        '
        'connectivity4Button
        '
        Me.connectivity4Button.AutoSize = True
        Me.connectivity4Button.Checked = True
        Me.connectivity4Button.Location = New System.Drawing.Point(11, 37)
        Me.connectivity4Button.Name = "connectivity4Button"
        Me.connectivity4Button.Size = New System.Drawing.Size(92, 17)
        Me.connectivity4Button.TabIndex = 0
        Me.connectivity4Button.TabStop = True
        Me.connectivity4Button.Text = "4-Connectivity"
        '
        'connectivity8Button
        '
        Me.connectivity8Button.AutoSize = True
        Me.connectivity8Button.Location = New System.Drawing.Point(11, 20)
        Me.connectivity8Button.Name = "connectivity8Button"
        Me.connectivity8Button.Size = New System.Drawing.Size(92, 17)
        Me.connectivity8Button.TabIndex = 0
        Me.connectivity8Button.Text = "8-Connectivity"
        Me.connectivity8Button.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(8, 333)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(99, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Number of Particles"
        '
        'numberOfParticles
        '
        Me.numberOfParticles.Location = New System.Drawing.Point(113, 330)
        Me.numberOfParticles.Name = "numberOfParticles"
        Me.numberOfParticles.ReadOnly = True
        Me.numberOfParticles.Size = New System.Drawing.Size(31, 20)
        Me.numberOfParticles.TabIndex = 6
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(159, 244)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 13)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(159, 260)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(108, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "1. Load an image file."
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(159, 277)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(192, 49)
        Me.label5.TabIndex = 7
        Me.label5.Text = "2. Drag the red cursors to change the threshold window size.  Drag the blue curso" & _
            "r to move the threshold window."
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(374, 284)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(79, 31)
        Me.loadImageButton.TabIndex = 8
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(374, 324)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(79, 31)
        Me.exitButton.TabIndex = 8
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'SimpleRangeSelect1
        '
        Me.SimpleRangeSelect1.AutoSize = True
        Me.SimpleRangeSelect1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SimpleRangeSelect1.Location = New System.Drawing.Point(11, 7)
        Me.SimpleRangeSelect1.Name = "SimpleRangeSelect1"
        Me.SimpleRangeSelect1.Size = New System.Drawing.Size(448, 197)
        Me.SimpleRangeSelect1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(465, 367)
        Me.Controls.Add(Me.SimpleRangeSelect1)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.numberOfParticles)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Basic Particle Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents connectivity8Button As System.Windows.Forms.RadioButton
    Private WithEvents connectivity4Button As System.Windows.Forms.RadioButton
    Private WithEvents showParticleArea As System.Windows.Forms.CheckBox
    Private label2 As System.Windows.Forms.Label
    Private numberOfParticles As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents SimpleRangeSelect1 As NationalInstruments.Vision.MeasurementStudioDemo.SimpleRangeSelect
End Class