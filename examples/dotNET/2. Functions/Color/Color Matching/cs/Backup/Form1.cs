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

// Color Matching Example
//
// This example shows how to use Algorithms.MatchColor() to check LEDs on the front panel of an instrument.
// The color spectrum of each LED (the region of interest) is compared to the color spectrum of the
// expected color.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace ColorMatching
{
    public enum LedColors
    {
        Black = 0,
        Red = 1,
        Orange = 2,
        Green = 3
    }
    public partial class Form1 : Form
    {
        private const int maxImageNumber = 16;
        private const int ledCount = 13;

        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "LEDs");
        private int imageNumber = 0;
        private Dictionary<LedColors, ColorInformation> colorInformation = new Dictionary<LedColors, ColorInformation>();
        private Roi[] ledRois = new Roi[ledCount];
        private LedColors[][] expectedPatterns = new LedColors[maxImageNumber + 1][];
        private Collection<VisionImage> images = new Collection<VisionImage>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the viewer's image type to RGB
            imageViewer1.Image.Type = ImageType.Rgb32;

            // Load pre-calculated information.
            InitializeData();

            // Set up the PictureBox controls to graph the color spectrum values and plot the color information.
            ColorSpectrumHelpers.PlotColorSpectrum(blackSpectrumBox, ColorSensitivity.Medium, colorInformation[LedColors.Black].Information);
            ColorSpectrumHelpers.PlotColorSpectrum(redSpectrumBox, ColorSensitivity.Medium, colorInformation[LedColors.Red].Information);
            ColorSpectrumHelpers.PlotColorSpectrum(orangeSpectrumBox, ColorSensitivity.Medium, colorInformation[LedColors.Orange].Information);
            ColorSpectrumHelpers.PlotColorSpectrum(greenSpectrumBox, ColorSensitivity.Medium, colorInformation[LedColors.Green].Information);
            blackSpectrumBox.Paint += new PaintEventHandler(spectrumBox_Paint);
            redSpectrumBox.Paint += new PaintEventHandler(spectrumBox_Paint);
            orangeSpectrumBox.Paint += new PaintEventHandler(spectrumBox_Paint);
            greenSpectrumBox.Paint += new PaintEventHandler(spectrumBox_Paint);

            // Enable the timer.
            timer1.Enabled = true;
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the pattern corresponding to this image and display it.
            LedColors[] pattern = expectedPatterns[imageNumber];
            DisplayExpectedPattern(pattern);

            // Display the next image.
            VisionImage image = GetNextImage();

            bool allLedsPassed = true;
            for (int i = 0; i < ledCount; ++i)
            {
                Collection<int> scores = Algorithms.MatchColor(image, colorInformation[pattern[i]], ledRois[i]);
                // If the match score is greater than 500, the LED passes the color test.
                bool pass = scores[0] > 500;
                switch (i)
                {
                    case 0:
                        passFailLed1.Value = pass;
                        break;
                    case 1:
                        passFailLed2.Value = pass;
                        break;
                    case 2:
                        passFailLed3.Value = pass;
                        break;
                    case 3:
                        passFailLed4.Value = pass;
                        break;
                    case 4:
                        passFailLed5.Value = pass;
                        break;
                    case 5:
                        passFailLed6.Value = pass;
                        break;
                    case 6:
                        passFailLed7.Value = pass;
                        break;
                    case 7:
                        passFailLed8.Value = pass;
                        break;
                    case 8:
                        passFailLed9.Value = pass;
                        break;
                    case 9:
                        passFailLed10.Value = pass;
                        break;
                    case 10:
                        passFailLed11.Value = pass;
                        break;
                    case 11:
                        passFailLed12.Value = pass;
                        break;
                    case 12:
                        passFailLed13.Value = pass;
                        break;
                }
                if (!pass)
                {
                    allLedsPassed = false;
                    DrawFailedLED(image.Overlays.Default, ledRois[i]);
                }
            }
            passFailLed.Value = allLedsPassed;
            imageViewer1.Attach(image);
        }

        void spectrumBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            ColorSpectrumHelpers.DrawColorSpectrum(e.Graphics, box);
        }

        private void InitializeData()
        {
            // Load color information.  This information was learned using the Color Learn Example.
            colorInformation[LedColors.Black] = new ColorInformation(new Collection<double>(new double[] { 0, 0, 0, 0.01, 0, 0.02, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.96, 0}));
            colorInformation[LedColors.Red] = new ColorInformation(new Collection<double>(new double[] { 0.08, 0.25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.06, 0.61, 0, 0 }));
            colorInformation[LedColors.Orange] = new ColorInformation(new Collection<double>(new double[] { 0, 0, 0.01, 0, 0.22, 0.76, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }));
            colorInformation[LedColors.Green] = new ColorInformation(new Collection<double>(new double[] { 0, 0, 0, 0, 0, 0, 0.16, 0.71, 0.02, 0.06, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.05 }));

            // Initialize the LED Roi collection.
            ledRois[0] = new Roi( new Shape[] {new RectangleContour(86, 154, 14, 14)});
            ledRois[1] = new Roi( new Shape[] {new RectangleContour(136, 153, 14, 14)});
            ledRois[2] = new Roi( new Shape[] {new RectangleContour(188, 152, 14, 14)});
            ledRois[3] = new Roi( new Shape[] {new RectangleContour(236, 152, 14, 14)});
            ledRois[4] = new Roi( new Shape[] {new RectangleContour(87, 194, 14, 14)});
            ledRois[5] = new Roi( new Shape[] {new RectangleContour(136, 193, 14, 14)});
            ledRois[6] = new Roi( new Shape[] {new RectangleContour(189, 193, 14, 14)});
            ledRois[7] = new Roi( new Shape[] {new RectangleContour(236, 194, 14, 14)});
            ledRois[8] = new Roi( new Shape[] {new RectangleContour(32, 224, 21, 21)});
            ledRois[9] = new Roi( new Shape[] {new RectangleContour(86, 233, 14, 14)});
            ledRois[10] = new Roi( new Shape[] {new RectangleContour(135, 233, 14, 14)});
            ledRois[11] = new Roi( new Shape[] {new RectangleContour(187, 232, 14, 14)});
            ledRois[12] = new Roi( new Shape[] {new RectangleContour(236, 232, 14, 14)});

            // Initialize the expected patterns array.  This array stores the
            // expected pattern for each image.
            expectedPatterns[0] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[1] = new LedColors[] {LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Red,
                                                   LedColors.Orange, LedColors.Orange, LedColors.Orange, LedColors.Orange,
                                                   LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green};
            expectedPatterns[2] = new LedColors[] {LedColors.Red, LedColors.Red, LedColors.Red, LedColors.Red,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Orange,
                                                   LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green};
            expectedPatterns[3] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green};
            expectedPatterns[4] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[5] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[6] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Black, LedColors.Green, LedColors.Black, LedColors.Black};
            expectedPatterns[7] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Black};
            expectedPatterns[8] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Green};
            expectedPatterns[9] = new LedColors[] {LedColors.Black, LedColors.Red, LedColors.Black, LedColors.Black,
                                                   LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                   LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[10] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Black,
                                                    LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                    LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[11] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Red,
                                                    LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                    LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black};
            expectedPatterns[12] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Black,
                                                    LedColors.Black, LedColors.Orange, LedColors.Orange, LedColors.Black,
                                                    LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Green};
            expectedPatterns[13] = new LedColors[] {LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black,
                                                    LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Orange,
                                                    LedColors.Green, LedColors.Black, LedColors.Green, LedColors.Green, LedColors.Black};
            expectedPatterns[14] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Red, LedColors.Red,
                                                    LedColors.Orange, LedColors.Orange, LedColors.Black, LedColors.Black,
                                                    LedColors.Green, LedColors.Black, LedColors.Black, LedColors.Green, LedColors.Green};
            expectedPatterns[15] = new LedColors[] {LedColors.Red, LedColors.Black, LedColors.Black, LedColors.Black,
                                                    LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Orange,
                                                    LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Black};
            expectedPatterns[16] = new LedColors[] {LedColors.Black, LedColors.Black, LedColors.Black, LedColors.Red,
                                                    LedColors.Black, LedColors.Orange, LedColors.Black, LedColors.Orange,
                                                    LedColors.Green, LedColors.Green, LedColors.Green, LedColors.Black, LedColors.Black};
        }

        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage(ImageType.Rgb32);
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "MID7604 " + String.Format("{0:00}", imageNumber) + ".jpg"));
                images.Add(toReturn);
            }
            else
            {
                toReturn = images[imageNumber];
                // Clear any overlays
                toReturn.Overlays.Default.Clear();
            }

            // Advance the image number to the next image
            imageNumber++;
            if (imageNumber > maxImageNumber)
            {
                imageNumber = 0;
            }
            return toReturn;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DrawFailedLED(Overlay overlay, Roi roi)
        {
            RectangleContour rect = roi.GetBoundingRectangle();
            rect.Left = rect.Left - rect.Width / 1.25;
            rect.Top = rect.Top - rect.Height / 1.25;
            rect.Width = rect.Width * 2.5;
            rect.Height = rect.Height * 2.5;

            // Overlay on the image to indicate which LED failed.
            overlay.AddRectangle(rect, Rgb32Value.RedColor, DrawingMode.DrawValue);

            OverlayTextOptions textOptions = new OverlayTextOptions("Arial", 20, HorizontalTextAlignment.Center);
            textOptions.VerticalAlignment = VerticalTextAlignment.Baseline;
            textOptions.TextDecoration.Bold = true;
            overlay.AddText("Fail", new PointContour(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2), Rgb32Value.RedColor, textOptions);
        }

        private void DisplayExpectedPattern(LedColors[] pattern)
        {
            for (int i = 0; i < ledCount; ++i) {
                bool ledOn = pattern[i] != LedColors.Black;
                switch (i)
                {
                    case 0:
                        expectedLed1.Value = ledOn;
                        break;
                    case 1:
                        expectedLed2.Value = ledOn;
                        break;
                    case 2:
                        expectedLed3.Value = ledOn;
                        break;
                    case 3:
                        expectedLed4.Value = ledOn;
                        break;
                    case 4:
                        expectedLed5.Value = ledOn;
                        break;
                    case 5:
                        expectedLed6.Value = ledOn;
                        break;
                    case 6:
                        expectedLed7.Value = ledOn;
                        break;
                    case 7:
                        expectedLed8.Value = ledOn;
                        break;
                    case 8:
                        expectedLed9.Value = ledOn;
                        break;
                    case 9:
                        expectedLed10.Value = ledOn;
                        break;
                    case 10:
                        expectedLed11.Value = ledOn;
                        break;
                    case 11:
                        expectedLed12.Value = ledOn;
                        break;
                    case 12:
                        expectedLed13.Value = ledOn;
                        break;
                }
            }
        }

        private void delaySlider1_ValueChanged(object sender, EventArgs e)
        {
            int newDelay = (int)delaySlider1.Value;
            if (newDelay == 0)
            {
                newDelay = 1;
            }
            timer1.Interval = newDelay;
        }
    }
}