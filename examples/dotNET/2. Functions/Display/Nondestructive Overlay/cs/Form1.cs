using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Nondestructive Overlay Example
//
// This example demonstrates how to display text and pictures on an image window without
// overwriting or changing the displayed image.  Nondestructive overlay provides an
// effective way to display calibration grids, guidelines, measurement results,
// and pass/fail results on an image window.

namespace NondestructiveOverlay
{
    public partial class Form1 : Form
    {
        private string imagePath = ExampleImagesFolder.GetExampleImagesFolder();
        private Collection<string> filenames;
        private DateTime lastTime = new DateTime();
        private DateTime nextTime = new DateTime();
        private Random r = new Random();
        private PointContour textOrigin = new PointContour();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the files in the source directory.
            filenames = new Collection<string>(System.IO.Directory.GetFiles(imagePath, "*", System.IO.SearchOption.TopDirectoryOnly));

            // Enable the timer.
            lastTime = DateTime.Now;
            nextTime = lastTime;
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the current time.
            DateTime currentTime = DateTime.Now;
            // After advancing to the next second, update the overlay.
            if (currentTime.Subtract(lastTime).TotalSeconds >= 1)
            {
                lastTime = currentTime;

                // Overlay the current time.
                int secondsToNextImage = (int)nextTime.Subtract(currentTime).TotalSeconds;
                OverlayTextOnImage(imageViewer1.Image, currentTime, secondsToNextImage);

                // Is it time to load the next image?
                if (secondsToNextImage < 0)
                {
                    // The next image will load in 5 seconds.
                    nextTime = currentTime.AddSeconds(5);

                    // Get the next image.
                    LoadNextImage(imageViewer1.Image);

                    // Compute a random point to overlay the text.
                    textOrigin.Initialize(r.NextDouble() * (imageViewer1.Image.Width / 2.0),
                                          r.NextDouble() * (imageViewer1.Image.Height / 2.0));
                    OverlayTextOnImage(imageViewer1.Image, currentTime, 4);
                }
            }
        }

        private void LoadNextImage(VisionImage image)
        {
            // Load a random image from the image directory.
            image.ReadFile(filenames[r.Next(filenames.Count)]);
        }

        private void OverlayTextOnImage(VisionImage image, DateTime time, int secondsToNextImage)
        {
            OverlayTextOptions textOptions = new OverlayTextOptions("Arial", 20);
            textOptions.TextDecoration.Bold = true;

            // Clear any overlays.
            image.Overlays.Default.Clear();

            // Overlay text onto the image.  This will not change the image pixels.
            image.Overlays.Default.AddText(String.Format("{0}\nNext image in {1}s.", time.ToLongTimeString(), secondsToNextImage.ToString()), textOrigin, new Rgb32Value(colorDialog1.Color), textOptions);

            // Display the overlaid text.
            overlaidTextBox.Text = String.Format("{0}\r\nNext image in {1}s.", time.ToLongTimeString(), secondsToNextImage.ToString());
        }

        private void textColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                overlaidTextBox.ForeColor = colorDialog1.Color;
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}