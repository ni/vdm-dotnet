using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// OCR Example

// This example demostrates how to use NI Vision to read text.
// This example also demonstrates the use of the OcrSession constructor
// to read a character set and the associated options from
// a previously saved character set file.

namespace OCR
{
    public partial class Form1 : Form
    {
        Collection<VisionImage> images = new Collection<VisionImage>();
        int imageNumber;
        VisionImage curImage = new VisionImage();
        OcrSession session = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string imageDirPath = GetPath();

            // Read the character set and options from the character set file "Lot Number.abc"
            session = new OcrSession(imageDirPath + @"\Lot Number.abc");
            foreach (string file in System.IO.Directory.GetFiles(imageDirPath, "*.bmp"))
            {
                VisionImage image = new VisionImage();
                image.ReadFile(file);
                images.Add(image);
            }

            // Attach the image to the viewer
            imageViewer1.Attach(curImage);
            imageNumber = 0;
            timer1.Enabled = false;
            timer1.Interval = (int)delay.Value;
        }

        private string GetPath()
        {
            return System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"OCR\Sample Set 2");
        }

        public VisionImage GetNextImage()
        {
            VisionImage nextImage = images[imageNumber];
            // Clear any existing overlays.
            nextImage.Overlays.Default.Clear();

            // Copy the image to the user's image
            Algorithms.Copy(nextImage, curImage);

            // Advance the image number to the next image.
            imageNumber++;
            if (imageNumber >= images.Count)
            {
                imageNumber = 0;
            }
            return curImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            VisionImage image = GetNextImage();

            ReadTextReport report = session.ReadText(image);
            readTextBox.Text = report.ReadString;
            foreach (CharacterReport ch in report.CharacterReports) {
                image.Overlays.Default.AddRectangle(ch.CharacterStatistics.BoundingRectangle);
            }
        }

        private void startReadingButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void pauseReadingButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void delay_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (int)delay.Value;
        }
    }
}