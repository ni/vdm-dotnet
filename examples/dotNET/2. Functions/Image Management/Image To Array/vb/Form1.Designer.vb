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
        Me.imagePath = New System.Windows.Forms.TextBox
        Me.browseButton = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.textBox2 = New System.Windows.Forms.TextBox
        Me.textBox3 = New System.Windows.Forms.TextBox
        Me.textBox4 = New System.Windows.Forms.TextBox
        Me.textBox5 = New System.Windows.Forms.TextBox
        Me.textBox6 = New System.Windows.Forms.TextBox
        Me.textBox7 = New System.Windows.Forms.TextBox
        Me.textBox8 = New System.Windows.Forms.TextBox
        Me.textBox9 = New System.Windows.Forms.TextBox
        Me.textBox10 = New System.Windows.Forms.TextBox
        Me.textBox11 = New System.Windows.Forms.TextBox
        Me.textBox12 = New System.Windows.Forms.TextBox
        Me.textBox13 = New System.Windows.Forms.TextBox
        Me.textBox14 = New System.Windows.Forms.TextBox
        Me.textBox15 = New System.Windows.Forms.TextBox
        Me.textBox16 = New System.Windows.Forms.TextBox
        Me.textBox17 = New System.Windows.Forms.TextBox
        Me.textBox18 = New System.Windows.Forms.TextBox
        Me.textBox19 = New System.Windows.Forms.TextBox
        Me.textBox20 = New System.Windows.Forms.TextBox
        Me.textBox21 = New System.Windows.Forms.TextBox
        Me.textBox22 = New System.Windows.Forms.TextBox
        Me.textBox23 = New System.Windows.Forms.TextBox
        Me.textBox24 = New System.Windows.Forms.TextBox
        Me.textBox25 = New System.Windows.Forms.TextBox
        Me.textBox26 = New System.Windows.Forms.TextBox
        Me.textBox27 = New System.Windows.Forms.TextBox
        Me.textBox28 = New System.Windows.Forms.TextBox
        Me.textBox29 = New System.Windows.Forms.TextBox
        Me.textBox30 = New System.Windows.Forms.TextBox
        Me.textBox31 = New System.Windows.Forms.TextBox
        Me.textBox32 = New System.Windows.Forms.TextBox
        Me.textBox33 = New System.Windows.Forms.TextBox
        Me.textBox34 = New System.Windows.Forms.TextBox
        Me.textBox35 = New System.Windows.Forms.TextBox
        Me.textBox36 = New System.Windows.Forms.TextBox
        Me.textBox37 = New System.Windows.Forms.TextBox
        Me.textBox38 = New System.Windows.Forms.TextBox
        Me.textBox39 = New System.Windows.Forms.TextBox
        Me.textBox40 = New System.Windows.Forms.TextBox
        Me.textBox41 = New System.Windows.Forms.TextBox
        Me.textBox42 = New System.Windows.Forms.TextBox
        Me.textBox43 = New System.Windows.Forms.TextBox
        Me.textBox44 = New System.Windows.Forms.TextBox
        Me.textBox45 = New System.Windows.Forms.TextBox
        Me.textBox46 = New System.Windows.Forms.TextBox
        Me.textBox47 = New System.Windows.Forms.TextBox
        Me.textBox48 = New System.Windows.Forms.TextBox
        Me.textBox49 = New System.Windows.Forms.TextBox
        Me.loadButton = New System.Windows.Forms.Button
        Me.quitbutton = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'imageViewer1
        '
        Me.imageViewer1.ActiveTool = NationalInstruments.Vision.WindowsForms.ViewerTools.Point
        Me.imageViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imageViewer1.Location = New System.Drawing.Point(11, 10)
        Me.imageViewer1.Name = "imageViewer1"
        Me.imageViewer1.Size = New System.Drawing.Size(393, 313)
        Me.imageViewer1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(8, 335)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(61, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Image Path"
        '
        'imagePath
        '
        Me.imagePath.Location = New System.Drawing.Point(75, 332)
        Me.imagePath.Name = "imagePath"
        Me.imagePath.Size = New System.Drawing.Size(296, 20)
        Me.imagePath.TabIndex = 2
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(377, 333)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 19)
        Me.browseButton.TabIndex = 3
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(433, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 13)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Pixel Values"
        '
        'textBox1
        '
        Me.textBox1.Location = New System.Drawing.Point(410, 29)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(24, 20)
        Me.textBox1.TabIndex = 5
        '
        'textBox2
        '
        Me.textBox2.Location = New System.Drawing.Point(440, 29)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.ReadOnly = True
        Me.textBox2.Size = New System.Drawing.Size(24, 20)
        Me.textBox2.TabIndex = 5
        '
        'textBox3
        '
        Me.textBox3.Location = New System.Drawing.Point(470, 29)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.ReadOnly = True
        Me.textBox3.Size = New System.Drawing.Size(24, 20)
        Me.textBox3.TabIndex = 5
        '
        'textBox4
        '
        Me.textBox4.Location = New System.Drawing.Point(500, 29)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.ReadOnly = True
        Me.textBox4.Size = New System.Drawing.Size(24, 20)
        Me.textBox4.TabIndex = 5
        '
        'textBox5
        '
        Me.textBox5.Location = New System.Drawing.Point(530, 29)
        Me.textBox5.Name = "textBox5"
        Me.textBox5.ReadOnly = True
        Me.textBox5.Size = New System.Drawing.Size(24, 20)
        Me.textBox5.TabIndex = 5
        '
        'textBox6
        '
        Me.textBox6.Location = New System.Drawing.Point(560, 29)
        Me.textBox6.Name = "textBox6"
        Me.textBox6.ReadOnly = True
        Me.textBox6.Size = New System.Drawing.Size(24, 20)
        Me.textBox6.TabIndex = 5
        '
        'textBox7
        '
        Me.textBox7.Location = New System.Drawing.Point(590, 29)
        Me.textBox7.Name = "textBox7"
        Me.textBox7.ReadOnly = True
        Me.textBox7.Size = New System.Drawing.Size(24, 20)
        Me.textBox7.TabIndex = 5
        '
        'textBox8
        '
        Me.textBox8.Location = New System.Drawing.Point(410, 55)
        Me.textBox8.Name = "textBox8"
        Me.textBox8.ReadOnly = True
        Me.textBox8.Size = New System.Drawing.Size(24, 20)
        Me.textBox8.TabIndex = 5
        '
        'textBox9
        '
        Me.textBox9.Location = New System.Drawing.Point(440, 55)
        Me.textBox9.Name = "textBox9"
        Me.textBox9.ReadOnly = True
        Me.textBox9.Size = New System.Drawing.Size(24, 20)
        Me.textBox9.TabIndex = 5
        '
        'textBox10
        '
        Me.textBox10.Location = New System.Drawing.Point(470, 55)
        Me.textBox10.Name = "textBox10"
        Me.textBox10.ReadOnly = True
        Me.textBox10.Size = New System.Drawing.Size(24, 20)
        Me.textBox10.TabIndex = 5
        '
        'textBox11
        '
        Me.textBox11.Location = New System.Drawing.Point(500, 55)
        Me.textBox11.Name = "textBox11"
        Me.textBox11.ReadOnly = True
        Me.textBox11.Size = New System.Drawing.Size(24, 20)
        Me.textBox11.TabIndex = 5
        '
        'textBox12
        '
        Me.textBox12.Location = New System.Drawing.Point(530, 55)
        Me.textBox12.Name = "textBox12"
        Me.textBox12.ReadOnly = True
        Me.textBox12.Size = New System.Drawing.Size(24, 20)
        Me.textBox12.TabIndex = 5
        '
        'textBox13
        '
        Me.textBox13.Location = New System.Drawing.Point(560, 55)
        Me.textBox13.Name = "textBox13"
        Me.textBox13.ReadOnly = True
        Me.textBox13.Size = New System.Drawing.Size(24, 20)
        Me.textBox13.TabIndex = 5
        '
        'textBox14
        '
        Me.textBox14.Location = New System.Drawing.Point(590, 55)
        Me.textBox14.Name = "textBox14"
        Me.textBox14.ReadOnly = True
        Me.textBox14.Size = New System.Drawing.Size(24, 20)
        Me.textBox14.TabIndex = 5
        '
        'textBox15
        '
        Me.textBox15.Location = New System.Drawing.Point(410, 81)
        Me.textBox15.Name = "textBox15"
        Me.textBox15.ReadOnly = True
        Me.textBox15.Size = New System.Drawing.Size(24, 20)
        Me.textBox15.TabIndex = 5
        '
        'textBox16
        '
        Me.textBox16.Location = New System.Drawing.Point(440, 81)
        Me.textBox16.Name = "textBox16"
        Me.textBox16.ReadOnly = True
        Me.textBox16.Size = New System.Drawing.Size(24, 20)
        Me.textBox16.TabIndex = 5
        '
        'textBox17
        '
        Me.textBox17.Location = New System.Drawing.Point(470, 81)
        Me.textBox17.Name = "textBox17"
        Me.textBox17.ReadOnly = True
        Me.textBox17.Size = New System.Drawing.Size(24, 20)
        Me.textBox17.TabIndex = 5
        '
        'textBox18
        '
        Me.textBox18.Location = New System.Drawing.Point(500, 81)
        Me.textBox18.Name = "textBox18"
        Me.textBox18.ReadOnly = True
        Me.textBox18.Size = New System.Drawing.Size(24, 20)
        Me.textBox18.TabIndex = 5
        '
        'textBox19
        '
        Me.textBox19.Location = New System.Drawing.Point(530, 81)
        Me.textBox19.Name = "textBox19"
        Me.textBox19.ReadOnly = True
        Me.textBox19.Size = New System.Drawing.Size(24, 20)
        Me.textBox19.TabIndex = 5
        '
        'textBox20
        '
        Me.textBox20.Location = New System.Drawing.Point(560, 81)
        Me.textBox20.Name = "textBox20"
        Me.textBox20.ReadOnly = True
        Me.textBox20.Size = New System.Drawing.Size(24, 20)
        Me.textBox20.TabIndex = 5
        '
        'textBox21
        '
        Me.textBox21.Location = New System.Drawing.Point(590, 81)
        Me.textBox21.Name = "textBox21"
        Me.textBox21.ReadOnly = True
        Me.textBox21.Size = New System.Drawing.Size(24, 20)
        Me.textBox21.TabIndex = 5
        '
        'textBox22
        '
        Me.textBox22.Location = New System.Drawing.Point(410, 107)
        Me.textBox22.Name = "textBox22"
        Me.textBox22.ReadOnly = True
        Me.textBox22.Size = New System.Drawing.Size(24, 20)
        Me.textBox22.TabIndex = 5
        '
        'textBox23
        '
        Me.textBox23.Location = New System.Drawing.Point(440, 107)
        Me.textBox23.Name = "textBox23"
        Me.textBox23.ReadOnly = True
        Me.textBox23.Size = New System.Drawing.Size(24, 20)
        Me.textBox23.TabIndex = 5
        '
        'textBox24
        '
        Me.textBox24.Location = New System.Drawing.Point(470, 107)
        Me.textBox24.Name = "textBox24"
        Me.textBox24.ReadOnly = True
        Me.textBox24.Size = New System.Drawing.Size(24, 20)
        Me.textBox24.TabIndex = 5
        '
        'textBox25
        '
        Me.textBox25.Location = New System.Drawing.Point(500, 107)
        Me.textBox25.Name = "textBox25"
        Me.textBox25.ReadOnly = True
        Me.textBox25.Size = New System.Drawing.Size(24, 20)
        Me.textBox25.TabIndex = 5
        '
        'textBox26
        '
        Me.textBox26.Location = New System.Drawing.Point(530, 107)
        Me.textBox26.Name = "textBox26"
        Me.textBox26.ReadOnly = True
        Me.textBox26.Size = New System.Drawing.Size(24, 20)
        Me.textBox26.TabIndex = 5
        '
        'textBox27
        '
        Me.textBox27.Location = New System.Drawing.Point(560, 107)
        Me.textBox27.Name = "textBox27"
        Me.textBox27.ReadOnly = True
        Me.textBox27.Size = New System.Drawing.Size(24, 20)
        Me.textBox27.TabIndex = 5
        '
        'textBox28
        '
        Me.textBox28.Location = New System.Drawing.Point(590, 107)
        Me.textBox28.Name = "textBox28"
        Me.textBox28.ReadOnly = True
        Me.textBox28.Size = New System.Drawing.Size(24, 20)
        Me.textBox28.TabIndex = 5
        '
        'textBox29
        '
        Me.textBox29.Location = New System.Drawing.Point(410, 133)
        Me.textBox29.Name = "textBox29"
        Me.textBox29.ReadOnly = True
        Me.textBox29.Size = New System.Drawing.Size(24, 20)
        Me.textBox29.TabIndex = 5
        '
        'textBox30
        '
        Me.textBox30.Location = New System.Drawing.Point(440, 133)
        Me.textBox30.Name = "textBox30"
        Me.textBox30.ReadOnly = True
        Me.textBox30.Size = New System.Drawing.Size(24, 20)
        Me.textBox30.TabIndex = 5
        '
        'textBox31
        '
        Me.textBox31.Location = New System.Drawing.Point(470, 133)
        Me.textBox31.Name = "textBox31"
        Me.textBox31.ReadOnly = True
        Me.textBox31.Size = New System.Drawing.Size(24, 20)
        Me.textBox31.TabIndex = 5
        '
        'textBox32
        '
        Me.textBox32.Location = New System.Drawing.Point(500, 133)
        Me.textBox32.Name = "textBox32"
        Me.textBox32.ReadOnly = True
        Me.textBox32.Size = New System.Drawing.Size(24, 20)
        Me.textBox32.TabIndex = 5
        '
        'textBox33
        '
        Me.textBox33.Location = New System.Drawing.Point(530, 133)
        Me.textBox33.Name = "textBox33"
        Me.textBox33.ReadOnly = True
        Me.textBox33.Size = New System.Drawing.Size(24, 20)
        Me.textBox33.TabIndex = 5
        '
        'textBox34
        '
        Me.textBox34.Location = New System.Drawing.Point(560, 133)
        Me.textBox34.Name = "textBox34"
        Me.textBox34.ReadOnly = True
        Me.textBox34.Size = New System.Drawing.Size(24, 20)
        Me.textBox34.TabIndex = 5
        '
        'textBox35
        '
        Me.textBox35.Location = New System.Drawing.Point(590, 133)
        Me.textBox35.Name = "textBox35"
        Me.textBox35.ReadOnly = True
        Me.textBox35.Size = New System.Drawing.Size(24, 20)
        Me.textBox35.TabIndex = 5
        '
        'textBox36
        '
        Me.textBox36.Location = New System.Drawing.Point(410, 159)
        Me.textBox36.Name = "textBox36"
        Me.textBox36.ReadOnly = True
        Me.textBox36.Size = New System.Drawing.Size(24, 20)
        Me.textBox36.TabIndex = 5
        '
        'textBox37
        '
        Me.textBox37.Location = New System.Drawing.Point(440, 159)
        Me.textBox37.Name = "textBox37"
        Me.textBox37.ReadOnly = True
        Me.textBox37.Size = New System.Drawing.Size(24, 20)
        Me.textBox37.TabIndex = 5
        '
        'textBox38
        '
        Me.textBox38.Location = New System.Drawing.Point(470, 159)
        Me.textBox38.Name = "textBox38"
        Me.textBox38.ReadOnly = True
        Me.textBox38.Size = New System.Drawing.Size(24, 20)
        Me.textBox38.TabIndex = 5
        '
        'textBox39
        '
        Me.textBox39.Location = New System.Drawing.Point(500, 159)
        Me.textBox39.Name = "textBox39"
        Me.textBox39.ReadOnly = True
        Me.textBox39.Size = New System.Drawing.Size(24, 20)
        Me.textBox39.TabIndex = 5
        '
        'textBox40
        '
        Me.textBox40.Location = New System.Drawing.Point(530, 159)
        Me.textBox40.Name = "textBox40"
        Me.textBox40.ReadOnly = True
        Me.textBox40.Size = New System.Drawing.Size(24, 20)
        Me.textBox40.TabIndex = 5
        '
        'textBox41
        '
        Me.textBox41.Location = New System.Drawing.Point(560, 159)
        Me.textBox41.Name = "textBox41"
        Me.textBox41.ReadOnly = True
        Me.textBox41.Size = New System.Drawing.Size(24, 20)
        Me.textBox41.TabIndex = 5
        '
        'textBox42
        '
        Me.textBox42.Location = New System.Drawing.Point(590, 159)
        Me.textBox42.Name = "textBox42"
        Me.textBox42.ReadOnly = True
        Me.textBox42.Size = New System.Drawing.Size(24, 20)
        Me.textBox42.TabIndex = 5
        '
        'textBox43
        '
        Me.textBox43.Location = New System.Drawing.Point(410, 185)
        Me.textBox43.Name = "textBox43"
        Me.textBox43.ReadOnly = True
        Me.textBox43.Size = New System.Drawing.Size(24, 20)
        Me.textBox43.TabIndex = 5
        '
        'textBox44
        '
        Me.textBox44.Location = New System.Drawing.Point(440, 185)
        Me.textBox44.Name = "textBox44"
        Me.textBox44.ReadOnly = True
        Me.textBox44.Size = New System.Drawing.Size(24, 20)
        Me.textBox44.TabIndex = 5
        '
        'textBox45
        '
        Me.textBox45.Location = New System.Drawing.Point(470, 185)
        Me.textBox45.Name = "textBox45"
        Me.textBox45.ReadOnly = True
        Me.textBox45.Size = New System.Drawing.Size(24, 20)
        Me.textBox45.TabIndex = 5
        '
        'textBox46
        '
        Me.textBox46.Location = New System.Drawing.Point(500, 185)
        Me.textBox46.Name = "textBox46"
        Me.textBox46.ReadOnly = True
        Me.textBox46.Size = New System.Drawing.Size(24, 20)
        Me.textBox46.TabIndex = 5
        '
        'textBox47
        '
        Me.textBox47.Location = New System.Drawing.Point(530, 185)
        Me.textBox47.Name = "textBox47"
        Me.textBox47.ReadOnly = True
        Me.textBox47.Size = New System.Drawing.Size(24, 20)
        Me.textBox47.TabIndex = 5
        '
        'textBox48
        '
        Me.textBox48.Location = New System.Drawing.Point(560, 185)
        Me.textBox48.Name = "textBox48"
        Me.textBox48.ReadOnly = True
        Me.textBox48.Size = New System.Drawing.Size(24, 20)
        Me.textBox48.TabIndex = 5
        '
        'textBox49
        '
        Me.textBox49.Location = New System.Drawing.Point(590, 185)
        Me.textBox49.Name = "textBox49"
        Me.textBox49.ReadOnly = True
        Me.textBox49.Size = New System.Drawing.Size(24, 20)
        Me.textBox49.TabIndex = 5
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(542, 303)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(71, 35)
        Me.loadButton.TabIndex = 6
        Me.loadButton.Text = "Load Image"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'quitbutton
        '
        Me.quitbutton.Location = New System.Drawing.Point(542, 344)
        Me.quitbutton.Name = "quitbutton"
        Me.quitbutton.Size = New System.Drawing.Size(71, 35)
        Me.quitbutton.TabIndex = 6
        Me.quitbutton.Text = "Quit"
        Me.quitbutton.UseVisualStyleBackColor = True
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(410, 262)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(64, 13)
        Me.label3.TabIndex = 7
        Me.label3.Text = "Instructions:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(410, 284)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(108, 13)
        Me.label4.TabIndex = 7
        Me.label4.Text = "1. Load an image file."
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(410, 303)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(126, 35)
        Me.label5.TabIndex = 7
        Me.label5.Text = "2. Click an area to display its pixel values."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(630, 386)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.quitbutton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.textBox49)
        Me.Controls.Add(Me.textBox42)
        Me.Controls.Add(Me.textBox35)
        Me.Controls.Add(Me.textBox28)
        Me.Controls.Add(Me.textBox21)
        Me.Controls.Add(Me.textBox14)
        Me.Controls.Add(Me.textBox7)
        Me.Controls.Add(Me.textBox48)
        Me.Controls.Add(Me.textBox41)
        Me.Controls.Add(Me.textBox34)
        Me.Controls.Add(Me.textBox27)
        Me.Controls.Add(Me.textBox20)
        Me.Controls.Add(Me.textBox13)
        Me.Controls.Add(Me.textBox6)
        Me.Controls.Add(Me.textBox47)
        Me.Controls.Add(Me.textBox40)
        Me.Controls.Add(Me.textBox33)
        Me.Controls.Add(Me.textBox26)
        Me.Controls.Add(Me.textBox19)
        Me.Controls.Add(Me.textBox12)
        Me.Controls.Add(Me.textBox5)
        Me.Controls.Add(Me.textBox46)
        Me.Controls.Add(Me.textBox39)
        Me.Controls.Add(Me.textBox32)
        Me.Controls.Add(Me.textBox25)
        Me.Controls.Add(Me.textBox18)
        Me.Controls.Add(Me.textBox11)
        Me.Controls.Add(Me.textBox4)
        Me.Controls.Add(Me.textBox45)
        Me.Controls.Add(Me.textBox38)
        Me.Controls.Add(Me.textBox31)
        Me.Controls.Add(Me.textBox24)
        Me.Controls.Add(Me.textBox17)
        Me.Controls.Add(Me.textBox10)
        Me.Controls.Add(Me.textBox3)
        Me.Controls.Add(Me.textBox44)
        Me.Controls.Add(Me.textBox37)
        Me.Controls.Add(Me.textBox30)
        Me.Controls.Add(Me.textBox23)
        Me.Controls.Add(Me.textBox16)
        Me.Controls.Add(Me.textBox9)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.textBox43)
        Me.Controls.Add(Me.textBox36)
        Me.Controls.Add(Me.textBox29)
        Me.Controls.Add(Me.textBox22)
        Me.Controls.Add(Me.textBox15)
        Me.Controls.Add(Me.textBox8)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.imagePath)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.imageViewer1)
        Me.Name = "Form1"
        Me.Text = "Image to Array Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents imageViewer1 As NationalInstruments.Vision.WindowsForms.ImageViewer
    Private label1 As System.Windows.Forms.Label
    Private imagePath As System.Windows.Forms.TextBox
    Private WithEvents browseButton As System.Windows.Forms.Button
    Private label2 As System.Windows.Forms.Label
    Private textBox1 As System.Windows.Forms.TextBox
    Private textBox2 As System.Windows.Forms.TextBox
    Private textBox3 As System.Windows.Forms.TextBox
    Private textBox4 As System.Windows.Forms.TextBox
    Private textBox5 As System.Windows.Forms.TextBox
    Private textBox6 As System.Windows.Forms.TextBox
    Private textBox7 As System.Windows.Forms.TextBox
    Private textBox8 As System.Windows.Forms.TextBox
    Private textBox9 As System.Windows.Forms.TextBox
    Private textBox10 As System.Windows.Forms.TextBox
    Private textBox11 As System.Windows.Forms.TextBox
    Private textBox12 As System.Windows.Forms.TextBox
    Private textBox13 As System.Windows.Forms.TextBox
    Private textBox14 As System.Windows.Forms.TextBox
    Private textBox15 As System.Windows.Forms.TextBox
    Private textBox16 As System.Windows.Forms.TextBox
    Private textBox17 As System.Windows.Forms.TextBox
    Private textBox18 As System.Windows.Forms.TextBox
    Private textBox19 As System.Windows.Forms.TextBox
    Private textBox20 As System.Windows.Forms.TextBox
    Private textBox21 As System.Windows.Forms.TextBox
    Private textBox22 As System.Windows.Forms.TextBox
    Private textBox23 As System.Windows.Forms.TextBox
    Private textBox24 As System.Windows.Forms.TextBox
    Private textBox25 As System.Windows.Forms.TextBox
    Private textBox26 As System.Windows.Forms.TextBox
    Private textBox27 As System.Windows.Forms.TextBox
    Private textBox28 As System.Windows.Forms.TextBox
    Private textBox29 As System.Windows.Forms.TextBox
    Private textBox30 As System.Windows.Forms.TextBox
    Private textBox31 As System.Windows.Forms.TextBox
    Private textBox32 As System.Windows.Forms.TextBox
    Private textBox33 As System.Windows.Forms.TextBox
    Private textBox34 As System.Windows.Forms.TextBox
    Private textBox35 As System.Windows.Forms.TextBox
    Private textBox36 As System.Windows.Forms.TextBox
    Private textBox37 As System.Windows.Forms.TextBox
    Private textBox38 As System.Windows.Forms.TextBox
    Private textBox39 As System.Windows.Forms.TextBox
    Private textBox40 As System.Windows.Forms.TextBox
    Private textBox41 As System.Windows.Forms.TextBox
    Private textBox42 As System.Windows.Forms.TextBox
    Private textBox43 As System.Windows.Forms.TextBox
    Private textBox44 As System.Windows.Forms.TextBox
    Private textBox45 As System.Windows.Forms.TextBox
    Private textBox46 As System.Windows.Forms.TextBox
    Private textBox47 As System.Windows.Forms.TextBox
    Private textBox48 As System.Windows.Forms.TextBox
    Private textBox49 As System.Windows.Forms.TextBox
    Private WithEvents loadButton As System.Windows.Forms.Button
    Private WithEvents quitbutton As System.Windows.Forms.Button
    Private label3 As System.Windows.Forms.Label
    Private label4 As System.Windows.Forms.Label
    Private label5 As System.Windows.Forms.Label
End Class