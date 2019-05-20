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
        Me.viewerLabel = New System.Windows.Forms.Label
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.browseButton = New System.Windows.Forms.Button
        Me.steps = New System.Windows.Forms.ListBox
        Me.connectivity8 = New System.Windows.Forms.CheckBox
        Me.runCurrentStepButton = New System.Windows.Forms.Button
        Me.quitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(219, 29)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(331, 344)
        Me.imageViewer1.TabIndex = 0
        '
        'viewerLabel
        '
        Me.viewerLabel.AutoSize = True
        Me.viewerLabel.Location = New System.Drawing.Point(216, 13)
        Me.viewerLabel.Name = "viewerLabel"
        Me.viewerLabel.Size = New System.Drawing.Size(36, 13)
        Me.viewerLabel.TabIndex = 1
        Me.viewerLabel.Text = "Image"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(13, 29)
        Me.imagePath.Multiline = True
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(157, 68)
        Me.imagePath.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(10, 13)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 13)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Image Path"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(176, 29)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(28, 22)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'steps
        '
        Me.steps.FormattingEnabled = True
        Me.steps.Items.AddRange(New Object() {"Load sample image", "Threshold", "Distance Transform", "Watershed Transform", "Display Watershed Lines", "Stop"})
        Me.steps.Location = New System.Drawing.Point(13, 119)
        Me.steps.Name = "steps"
        Me.steps.Size = New System.Drawing.Size(156, 95)
        Me.steps.TabIndex = 4
        '
        'connectivity8
        '
        Me.connectivity8.AutoSize = True
        Me.connectivity8.Checked = True
        Me.connectivity8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.connectivity8.Location = New System.Drawing.Point(12, 229)
        Me.connectivity8.Name = "connectivity8"
        Me.connectivity8.Size = New System.Drawing.Size(93, 17)
        Me.connectivity8.TabIndex = 5
        Me.connectivity8.Text = "Connectivity-8"
        Me.connectivity8.UseVisualStyleBackColor = True
        '
        'runCurrentStepButton
        '
        Me.runCurrentStepButton.Location = New System.Drawing.Point(12, 299)
        Me.runCurrentStepButton.Name = "runCurrentStepButton"
        Me.runCurrentStepButton.Size = New System.Drawing.Size(156, 34)
        Me.runCurrentStepButton.TabIndex = 6
        Me.runCurrentStepButton.Text = "Run Current Step"
        Me.runCurrentStepButton.UseVisualStyleBackColor = True
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(12, 339)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(156, 34)
        Me.quitButton.TabIndex = 6
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 402)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.runCurrentStepButton)
        Me.Controls.Add(Me.connectivity8)
        Me.Controls.Add(Me.steps)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.viewerLabel)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Morphological Segmentation Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private viewerLabel As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private label2 As System.Windows.Forms.Label
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private WithEvents steps As System.Windows.Forms.ListBox
    Private connectivity8 As System.Windows.Forms.CheckBox
    Private WithEvents runCurrentStepButton As System.Windows.Forms.Button
    Private WithEvents quitButton As System.Windows.Forms.Button
End Class