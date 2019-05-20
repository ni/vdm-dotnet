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
        Me.imageViewer1 = New NationalInstruments.Vision.WindowsForms.ImageViewer
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.noneMode = New System.Windows.Forms.RadioButton
        Me.imageMode = New System.Windows.Forms.RadioButton
        Me.imageResultsMode = New System.Windows.Forms.RadioButton
        Me.tolerance = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.partsInspected = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.quitButton = New System.Windows.Forms.Button
        Me.partOK = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.DelaySlider1 = New NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
        Me.PassFailLed1 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed2 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed3 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed4 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed5 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed6 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed7 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed8 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed9 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed10 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed11 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.PassFailLed12 = New NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
        Me.groupBox1.SuspendLayout()
        CType(Me.tolerance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(12, 12)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(521, 353)
        Me.imageViewer1.TabIndex = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(258, 378)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 16)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Pass/Fail"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.noneMode)
        Me.groupBox1.Controls.Add(Me.imageMode)
        Me.groupBox1.Controls.Add(Me.imageResultsMode)
        Me.groupBox1.Location = New System.Drawing.Point(12, 378)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(130, 83)
        Me.groupBox1.TabIndex = 3
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Display Options"
        '
        'noneMode
        '
        Me.noneMode.AutoSize = True
        Me.noneMode.Location = New System.Drawing.Point(10, 56)
        Me.noneMode.Name = "noneMode"
        Me.noneMode.Size = New System.Drawing.Size(74, 17)
        Me.noneMode.TabIndex = 0
        Me.noneMode.TabStop = True
        Me.noneMode.Text = "No display"
        Me.noneMode.UseVisualStyleBackColor = True
        '
        'imageMode
        '
        Me.imageMode.AutoSize = True
        Me.imageMode.Location = New System.Drawing.Point(10, 35)
        Me.imageMode.Name = "imageMode"
        Me.imageMode.Size = New System.Drawing.Size(54, 17)
        Me.imageMode.TabIndex = 0
        Me.imageMode.TabStop = True
        Me.imageMode.Text = "Image"
        Me.imageMode.UseVisualStyleBackColor = True
        '
        'imageResultsMode
        '
        Me.imageResultsMode.AutoSize = True
        Me.imageResultsMode.Checked = True
        Me.imageResultsMode.Location = New System.Drawing.Point(10, 16)
        Me.imageResultsMode.Name = "imageResultsMode"
        Me.imageResultsMode.Size = New System.Drawing.Size(101, 17)
        Me.imageResultsMode.TabIndex = 0
        Me.imageResultsMode.TabStop = True
        Me.imageResultsMode.Text = "Image + Results"
        Me.imageResultsMode.UseVisualStyleBackColor = True
        '
        'tolerance
        '
        Me.tolerance.DecimalPlaces = 2
        Me.tolerance.Location = New System.Drawing.Point(164, 391)
        Me.tolerance.Name = "tolerance"
        Me.tolerance.Size = New System.Drawing.Size(49, 20)
        Me.tolerance.TabIndex = 4
        Me.tolerance.Value = New Decimal(New Integer() {25, 0, 0, 65536})
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(161, 375)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(82, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Tolerance (deg)"
        '
        'partsInspected
        '
        Me.partsInspected.Location = New System.Drawing.Point(491, 501)
        Me.partsInspected.Name = "partsInspected"
        Me.partsInspected.ReadOnly = True
        Me.partsInspected.Size = New System.Drawing.Size(42, 20)
        Me.partsInspected.TabIndex = 9
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(354, 504)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(131, 13)
        Me.label4.TabIndex = 10
        Me.label4.Text = "Number of parts inspected"
        '
        'timer1
        '
        Me.timer1.Interval = 250
        '
        'quitButton
        '
        Me.quitButton.Location = New System.Drawing.Point(446, 571)
        Me.quitButton.Name = "quitButton"
        Me.quitButton.Size = New System.Drawing.Size(87, 36)
        Me.quitButton.TabIndex = 11
        Me.quitButton.Text = "Quit"
        Me.quitButton.UseVisualStyleBackColor = True
        '
        'partOK
        '
        Me.partOK.Caption = "Part OK?"
        Me.partOK.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.partOK.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.partOK.Location = New System.Drawing.Point(262, 434)
        Me.partOK.Name = "partOK"
        Me.partOK.Size = New System.Drawing.Size(270, 52)
        Me.partOK.TabIndex = 12
        Me.partOK.Value = False
        '
        'DelaySlider1
        '
        Me.DelaySlider1.AutoSize = True
        Me.DelaySlider1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DelaySlider1.Location = New System.Drawing.Point(12, 478)
        Me.DelaySlider1.Maximum = 1000
        Me.DelaySlider1.Name = "DelaySlider1"
        Me.DelaySlider1.Size = New System.Drawing.Size(165, 78)
        Me.DelaySlider1.TabIndex = 13
        Me.DelaySlider1.Value = 250
        '
        'PassFailLed1
        '
        Me.PassFailLed1.Caption = ""
        Me.PassFailLed1.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed1.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed1.Location = New System.Drawing.Point(258, 394)
        Me.PassFailLed1.Name = "PassFailLed1"
        Me.PassFailLed1.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed1.TabIndex = 14
        Me.PassFailLed1.Value = False
        '
        'PassFailLed2
        '
        Me.PassFailLed2.Caption = ""
        Me.PassFailLed2.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed2.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed2.Location = New System.Drawing.Point(280, 394)
        Me.PassFailLed2.Name = "PassFailLed2"
        Me.PassFailLed2.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed2.TabIndex = 14
        Me.PassFailLed2.Value = False
        '
        'PassFailLed3
        '
        Me.PassFailLed3.Caption = ""
        Me.PassFailLed3.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed3.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed3.Location = New System.Drawing.Point(302, 394)
        Me.PassFailLed3.Name = "PassFailLed3"
        Me.PassFailLed3.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed3.TabIndex = 14
        Me.PassFailLed3.Value = False
        '
        'PassFailLed4
        '
        Me.PassFailLed4.Caption = ""
        Me.PassFailLed4.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed4.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed4.Location = New System.Drawing.Point(324, 394)
        Me.PassFailLed4.Name = "PassFailLed4"
        Me.PassFailLed4.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed4.TabIndex = 14
        Me.PassFailLed4.Value = False
        '
        'PassFailLed5
        '
        Me.PassFailLed5.Caption = ""
        Me.PassFailLed5.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed5.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed5.Location = New System.Drawing.Point(346, 394)
        Me.PassFailLed5.Name = "PassFailLed5"
        Me.PassFailLed5.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed5.TabIndex = 14
        Me.PassFailLed5.Value = False
        '
        'PassFailLed6
        '
        Me.PassFailLed6.Caption = ""
        Me.PassFailLed6.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed6.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed6.Location = New System.Drawing.Point(368, 394)
        Me.PassFailLed6.Name = "PassFailLed6"
        Me.PassFailLed6.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed6.TabIndex = 14
        Me.PassFailLed6.Value = False
        '
        'PassFailLed7
        '
        Me.PassFailLed7.Caption = ""
        Me.PassFailLed7.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed7.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed7.Location = New System.Drawing.Point(390, 394)
        Me.PassFailLed7.Name = "PassFailLed7"
        Me.PassFailLed7.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed7.TabIndex = 14
        Me.PassFailLed7.Value = False
        '
        'PassFailLed8
        '
        Me.PassFailLed8.Caption = ""
        Me.PassFailLed8.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed8.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed8.Location = New System.Drawing.Point(412, 394)
        Me.PassFailLed8.Name = "PassFailLed8"
        Me.PassFailLed8.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed8.TabIndex = 14
        Me.PassFailLed8.Value = False
        '
        'PassFailLed9
        '
        Me.PassFailLed9.Caption = ""
        Me.PassFailLed9.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed9.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed9.Location = New System.Drawing.Point(434, 394)
        Me.PassFailLed9.Name = "PassFailLed9"
        Me.PassFailLed9.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed9.TabIndex = 14
        Me.PassFailLed9.Value = False
        '
        'PassFailLed10
        '
        Me.PassFailLed10.Caption = ""
        Me.PassFailLed10.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed10.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed10.Location = New System.Drawing.Point(456, 394)
        Me.PassFailLed10.Name = "PassFailLed10"
        Me.PassFailLed10.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed10.TabIndex = 14
        Me.PassFailLed10.Value = False
        '
        'PassFailLed11
        '
        Me.PassFailLed11.Caption = ""
        Me.PassFailLed11.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed11.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed11.Location = New System.Drawing.Point(478, 394)
        Me.PassFailLed11.Name = "PassFailLed11"
        Me.PassFailLed11.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed11.TabIndex = 14
        Me.PassFailLed11.Value = False
        '
        'PassFailLed12
        '
        Me.PassFailLed12.Caption = ""
        Me.PassFailLed12.LedColorMode = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.ColorMode.Normal
        Me.PassFailLed12.LedStyle = NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed.Style.Square3D
        Me.PassFailLed12.Location = New System.Drawing.Point(500, 394)
        Me.PassFailLed12.Name = "PassFailLed12"
        Me.PassFailLed12.Size = New System.Drawing.Size(22, 33)
        Me.PassFailLed12.TabIndex = 14
        Me.PassFailLed12.Value = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 614)
        Me.Controls.Add(Me.PassFailLed12)
        Me.Controls.Add(Me.PassFailLed11)
        Me.Controls.Add(Me.PassFailLed10)
        Me.Controls.Add(Me.PassFailLed9)
        Me.Controls.Add(Me.PassFailLed8)
        Me.Controls.Add(Me.PassFailLed7)
        Me.Controls.Add(Me.PassFailLed6)
        Me.Controls.Add(Me.PassFailLed5)
        Me.Controls.Add(Me.PassFailLed4)
        Me.Controls.Add(Me.PassFailLed3)
        Me.Controls.Add(Me.PassFailLed2)
        Me.Controls.Add(Me.PassFailLed1)
        Me.Controls.Add(Me.DelaySlider1)
        Me.Controls.Add(Me.partOK)
        Me.Controls.Add(Me.quitButton)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.partsInspected)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.tolerance)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Gauging Example"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.tolerance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private noneMode As System.Windows.Forms.RadioButton
    Private imageMode As System.Windows.Forms.RadioButton
    Private imageResultsMode As System.Windows.Forms.RadioButton
    Private tolerance As System.Windows.Forms.NumericUpDown
    Private label2 As System.Windows.Forms.Label
    Private partsInspected As System.Windows.Forms.TextBox
    Private label4 As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents quitButton As System.Windows.Forms.Button
    Friend WithEvents partOK As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents DelaySlider1 As NationalInstruments.Vision.MeasurementStudioDemo.DelaySlider
    Friend WithEvents PassFailLed1 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed2 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed3 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed4 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed5 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed6 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed7 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed8 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed9 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed10 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed11 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
    Friend WithEvents PassFailLed12 As NationalInstruments.Vision.MeasurementStudioDemo.PassFailLed
End Class