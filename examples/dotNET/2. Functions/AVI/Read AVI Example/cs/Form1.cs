using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Read AVI Example
// This example loads in an AVI and displays it at its correct framerate.

namespace Read_AVI_Example
{
    public partial class Form1 : Form
    {
        private AviInputSession session = null;
        private uint curFrame;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Let user load in AVI file
            LoadAVI();
            curFrame = 0;

            imageViewer1.Image.Type = ImageType.Rgb32;

            // Set up display
            progressBar1.Minimum = 0;
            progressBar1.Maximum = (int)(session.Frames - 1);
            timer1.Interval = 1000 / ((int)session.FramesPerSecond);
            timer1.Enabled = true;
        }
        private void LoadAVI()
        {
            // Load AVI file from dialog.
            openFileDialog1.InitialDirectory = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"AVIs");
            openFileDialog1.Filter = "AVI files (*.avi)|*.avi||";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                session = new AviInputSession(openFileDialog1.FileName);
            }
            
        }

        // Display the next frame in the AVI file
        private void timer1_Tick(object sender, EventArgs e)
        {
            // End of AVI?
            if (curFrame >= session.Frames)
            {
                session.Dispose();
                Application.Exit();
                return;
            }

            // Read the frame
            session.ReadFrame(imageViewer1.Image, curFrame);
            progressBar1.Value = (int)curFrame;

            // Increment frame
            curFrame++;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}