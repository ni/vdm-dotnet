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
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.loadImageButton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SimpleGraph1 = New NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Rectangle
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.ShowToolbar = True
        Me.imageViewer1.Size = New System.Drawing.Size(499, 279)
        Me.imageViewer1.TabIndex = 0
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(79, 300)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(401, 20)
        Me.imagePath.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 303)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(64, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Image Path:"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(486, 300)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(25, 21)
        Me.button1.TabIndex = 5
        Me.button1.Text = "..."
        Me.button1.UseVisualStyleBackColor = True
        '
        'loadImageButton
        '
        Me.loadImageButton.Location = New System.Drawing.Point(437, 334)
        Me.loadImageButton.Name = "loadImageButton"
        Me.loadImageButton.Size = New System.Drawing.Size(74, 36)
        Me.loadImageButton.TabIndex = 6
        Me.loadImageButton.Text = "Load Image"
        Me.loadImageButton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(327, 378)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 13)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(327, 400)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(108, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "1. Load an image file."
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(327, 422)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(184, 59)
        Me.label5.TabIndex = 7
        Me.label5.Text = "2. Select a tool by clicking on the toolbar. Draw a region of interest on the ima" & _
            "ge. The histogram displays the results."
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(442, 511)
        Me.exitButton.Name = "exitButton"
        Me.exitButton.Size = New System.Drawing.Size(69, 34)
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
        Me.SimpleGraph1.Location = New System.Drawing.Point(12, 334)
        Me.SimpleGraph1.Name = "SimpleGraph1"
        Me.SimpleGraph1.Size = New System.Drawing.Size(303, 166)
        Me.SimpleGraph1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 552)
        Me.Controls.Add(Me.SimpleGraph1)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.loadImageButton)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Histogram Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private imagePath As System.Windows.Forms.TextBox
    Private label1 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents loadImageButton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
    Private WithEvents exitButton As System.Windows.Forms.Button
    Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SimpleGraph1 As NationalInstruments.Vision.MeasurementStudioDemo.SimpleGraph
End Class