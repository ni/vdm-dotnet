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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.quitButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.barcodeResult = New System.Windows.Forms.TextBox
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.label3 = New System.Windows.Forms.Label
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(388, 277)
        Me.imageViewer1.TabIndex = 0
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(325, 388)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(75, 29)
        Me.quitButton.TabIndex = 3
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(227, 298)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(32, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Code"
        '
        'barcodeResult
        '
        Me.barcodeResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barcodeResult.Location = New System.Drawing.Point(230, 314)
        Me.barcodeResult.Name = "barcodeResult"
        Me.barcodeResult.ReadOnly = True
        Me.barcodeResult.Size = New System.Drawing.Size(170, 29)
        Me.barcodeResult.TabIndex = 5
        '
        'timer1
        '
        Me.timer1.Interval = 1500
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(9, 427)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(391, 79)
        Me.label3.TabIndex = 6
        Me.label3.Text = resources.GetString("label3.Text")
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(12, 298)
        Me.DelaySlider1.Maximum = 2000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 7
        Me.DelaySlider1.Value = 1500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 515)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.barcodeResult)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Barcode Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private barcodeResult As System.Windows.Forms.TextBox
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private label3 As System.Windows.Forms.Label
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
End Class