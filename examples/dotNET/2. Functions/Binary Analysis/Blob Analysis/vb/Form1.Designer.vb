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
        Me.steps = New System.Windows.Forms.ListBox
        Me.label1 = New System.Windows.Forms.Label
        Me.runCurrentStepButton = New System.Windows.Forms.Button
        Me.resetButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 7)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(520, 497)
        Me.imageViewer1.TabIndex = 0
        '
        'steps
        '
        Me.steps.FormattingEnabled = True
        Me.steps.Items.AddRange(New Object() {"Load sample image", "Enhance edge information", "Threshold", "Fill holes in objects", "Remove objects touching the border", "Keep round objects", "Measure objects areas"})
        Me.steps.Location = New System.Drawing.Point(12, 510)
        Me.steps.Name = "steps"
        Me.steps.Size = New System.Drawing.Size(188, 108)
        Me.steps.TabIndex = 1
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(206, 510)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(220, 63)
        Me.label1.TabIndex = 2
        Me.label1.Text = "This example performs a series of grayscale processing, binary morphology, and bl" & _
            "ob analysis operations and measures the areas of all large circular particles in" & _
            " the image."
        '
        'runCurrentStepButton
        '
        Me.runCurrentStepButton.Location = New System.Drawing.Point(326, 586)
        Me.runCurrentStepButton.Name = "runCurrentStepButton"
        Me.runCurrentStepButton.Size = New System.Drawing.Size(100, 32)
        Me.runCurrentStepButton.TabIndex = 3
        Me.runCurrentStepButton.Text = "Run Current Step"
        Me.runCurrentStepButton.UseVisualStyleBackColor = True
        '
        'resetButton
        '
        Me.resetButton.Location = New System.Drawing.Point(445, 541)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(87, 32)
        Me.resetButton.TabIndex = 3
        Me.resetButton.Text = "Reset Example"
        Me.resetButton.UseVisualStyleBackColor = True
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(445, 586)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(87, 32)
        Me.exitButton.TabIndex = 3
        Me.exitButton.Text = "Exit"
        Me.exitButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 630)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.runCurrentStepButton)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.steps)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Blob Analysis Example"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents steps As System.Windows.Forms.ListBox
    Private label1 As System.Windows.Forms.Label
    Private WithEvents runCurrentStepButton As System.Windows.Forms.Button
    Private WithEvents resetButton As System.Windows.Forms.Button
    Private WithEvents exitButton As System.Windows.Forms.Button
End Class