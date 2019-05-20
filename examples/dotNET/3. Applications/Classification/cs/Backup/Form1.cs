using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;
using System.Collections.ObjectModel;

// Classification example
//
// The objective of this classification example is to identify various parts in
// an image.  The example uses particle analysis to find the parts, classifies them,
// then overlays the class name on the image.  A histogram of the number of parts in the
// image is also shown.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace Classification
{
    public partial class Form1 : Form
    {
        int imageNumber;
        Collection<VisionImage> images = new Collection<VisionImage>();
        string imagePath;
        ParticleClassifierSession classifier;


        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Get the image path
            imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Parts");
            imageNumber = 0;

            // Read the classifier file
            classifier = new ParticleClassifierSession(System.IO.Path.Combine(imagePath, "Parts.clf"));

            // Enable the timer
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void delaySlider1_ValueChanged(object sender, EventArgs e)
        {
            int newInterval = (int)delaySlider1.Value;
            timer1.Interval = newInterval != 0 ? newInterval : 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double[] classCount = new double[8];
            OverlayTextOptions textOptions = new OverlayTextOptions("Arial", 14);
            textOptions.HorizontalAlignment = HorizontalTextAlignment.Center;

            // Get the next image
            GetNextImage(imageViewer1.Image);

            // Process the image
            VisionImage binaryImage = new VisionImage();
            Algorithms.Threshold(imageViewer1.Image, binaryImage, new Range(0, 200));
            Algorithms.RejectBorder(binaryImage, binaryImage);
            Collection<ParticleReport> reports = Algorithms.ParticleReport(binaryImage);
            foreach (ParticleReport report in reports)
            {
                RectangleContour contour = report.BoundingRect;
                contour.Left -= 10;
                contour.Top -= 10;
                contour.Height += 20;
                contour.Width += 20;

                // Classify the part
                ClassifierReport classifierReport = classifier.Classify(binaryImage, new Roi(new Shape[] { contour }));

                // Display the result
                if (classifierReport.ClassificationScore > 500)
                {
                    textOptions.BackgroundColor = Rgb32Value.TransparentColor;
                    int classIndex = 0;
                    Rgb32Value textColor = Rgb32Value.BlackColor;
                    switch (classifierReport.BestClassName)
                    {
                        case "Motor":
                            textColor = Rgb32Value.WhiteColor;
                            classIndex = 0;
                            break;
                        case "Bolt":
                            textColor = new Rgb32Value(Color.Cyan);
                            classIndex = 1;
                            break;
                        case "Screw":
                            textColor = Rgb32Value.RedColor;
                            classIndex = 2;
                            break;
                        case "Gear":
                            textColor = Rgb32Value.BlackColor;
                            classIndex = 3;
                            break;
                        case "Washer":
                            textColor = new Rgb32Value(Color.Magenta);
                            classIndex = 4;
                            break;
                        case "Worm Gear":
                            textColor = Rgb32Value.GreenColor;
                            classIndex = 5;
                            break;
                        case "Bracket":
                            textColor = new Rgb32Value(0x80, 0x80, 0);
                            classIndex = 6;
                            break;
                    }
                    classCount[classIndex]++;
                    imageViewer1.Image.Overlays.Default.AddText(classifierReport.BestClassName, report.CenterOfMass, textColor, textOptions);
                }
                else
                {
                    textOptions.BackgroundColor = Rgb32Value.BlackColor;
                    imageViewer1.Image.Overlays.Default.AddText("Unknown!", report.CenterOfMass, Rgb32Value.RedColor, textOptions);

                }
            }
            classificationGraph1.PlotClassifier(classCount);
        }

        private void GetNextImage(VisionImage dest) {
            VisionImage nextImage;
            // Load an image or return to the previous image
            if (imageNumber >= images.Count)
            {
                nextImage = new VisionImage();
                nextImage.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Parts\Parts0" + imageNumber + ".png"));
                images.Add(nextImage);
            }
            else
            {
                nextImage = images[imageNumber];
                // Clear any overlays.
                nextImage.Overlays.Default.Clear();
            }
            // Copy the image to the destination image
            Algorithms.Copy(nextImage, dest);

            // Advance the image number to the next image
            imageNumber++;
            if (imageNumber > 4) {
                imageNumber = 0;
            }
        }

    }
}