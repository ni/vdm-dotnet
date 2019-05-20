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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.startButton = New System.Windows.Forms.Button
        Me.stopButton = New System.Windows.Forms.Button
        Me.results = New System.Windows.Forms.ListView
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label4 = New System.Windows.Forms.Label
        Me.compressionFilter = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.numFrames = New System.Windows.Forms.TextBox
        Me.height = New System.Windows.Forms.TextBox
        Me.width = New System.Windows.Forms.TextBox
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(44, 425)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(50, 32)
        Me.startButton.TabIndex = 0
        Me.startButton.Text = "Start"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'stopButton
        '
        Me.stopButton.Location = New System.Drawing.Point(100, 425)
        Me.stopButton.Name = "stopButton"
        Me.stopButton.Size = New System.Drawing.Size(50, 32)
        Me.stopButton.TabIndex = 0
        Me.stopButton.Text = "Stop"
        Me.stopButton.UseVisualStyleBackColor = True
        '
        'results
        '
        Me.results.LabelWrap = False
        Me.results.Location = New System.Drawing.Point(44, 12)
        Me.results.Name = "results"
        Me.results.ShowItemToolTips = True
        Me.results.Size = New System.Drawing.Size(471, 219)
        Me.results.TabIndex = 2
        Me.results.UseCompatibleStateImageBehavior = False
        Me.results.View = System.Windows.Forms.View.Details
        '
        'openFileDialog1
        '
        Me.openFileDialog1.FileName = "openFileDialog1"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.compressionFilter)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.numFrames)
        Me.groupBox1.Controls.Add(Me.height)
        Me.groupBox1.Controls.Add(Me.width)
        Me.groupBox1.Location = New System.Drawing.Point(299, 371)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(222, 96)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Original Avi Info"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 54)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(92, 13)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Compression Filter"
        '
        'compressionFilter
        '
        Me.compressionFilter.Location = New System.Drawing.Point(17, 70)
        Me.compressionFilter.Name = "compressionFilter"
        Me.compressionFilter.Size = New System.Drawing.Size(199, 20)
        Me.compressionFilter.TabIndex = 2
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(158, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "# of frames"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(90, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Height"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(35, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Width"
        '
        'numFrames
        '
        Me.numFrames.Location = New System.Drawing.Point(161, 29)
        Me.numFrames.Name = "numFrames"
        Me.numFrames.Size = New System.Drawing.Size(55, 20)
        Me.numFrames.TabIndex = 0
        '
        'height
        '
        Me.height.Location = New System.Drawing.Point(93, 29)
        Me.height.Name = "height"
        Me.height.Size = New System.Drawing.Size(59, 20)
        Me.height.TabIndex = 0
        '
        'width
        '
        Me.width.Location = New System.Drawing.Point(16, 29)
        Me.width.Name = "width"
        Me.width.Size = New System.Drawing.Size(54, 20)
        Me.width.TabIndex = 0
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(44, 237)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(471, 23)
        Me.progressBar1.TabIndex = 4
        '
        'timer1
        '
        Me.timer1.Interval = 30
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(156, 425)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(50, 32)
        Me.quitButton.TabIndex = 0
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(41, 263)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(470, 45)
        Me.label5.TabIndex = 5
        Me.label5.Text = resources.GetString("label5.Text")
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(41, 308)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(470, 45)
        Me.label6.TabIndex = 5
        Me.label6.Text = "This example will take a few seconds to create all the AVIs required for analysis" & _
            ".  These AVIs are saved to a folder named AVI Compressor Comparison Example unde" & _
            "r the same folder as this example."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 494)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.results)
        Me.Controls.Add(Me.stopButton)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.startButton)
        Me.Name = "Form1"
        Me.Text = "AVI Compressor Comparison Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private WithEvents startButton As System.Windows.Forms.Button
    Private WithEvents stopButton As System.Windows.Forms.Button
    Private results As System.Windows.Forms.ListView
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private compressionFilter As System.Windows.Forms.TextBox
    Private label3 As System.Windows.Forms.Label
    Private label2 As System.Windows.Forms.Label
    Private label1 As System.Windows.Forms.Label
    Private numFrames As System.Windows.Forms.TextBox
    Private Shadows height As System.Windows.Forms.TextBox
    Private Shadows width As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label5 As System.Windows.Forms.Label
    Private label6 As System.Windows.Forms.Label
End Class
