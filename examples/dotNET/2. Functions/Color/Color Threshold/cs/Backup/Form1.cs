using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

// Color Threshold Example
//
// This eaxmple demonstrates how to use the HSL color space to perform inspection tasks based on object colors.
// This example illustrates the advantages of using the HSL color space over the RGB color space
// for color inspection or matching.
//
// * Step 1: The Threshold Color Mode is
//           set to RGB by default, which means that the threshold process is
//           based on the red, green, and blue values of the pixels.
//           By modifying the Red, Green, and Blue threshold
//           values, try to find the best threshold range to separate the blue parts
//           from the background.
//
// * Step 2: Good values to segment the blue parts are
//           approximately:
//           Red = [0, 142], Green = [0, 145], Blue = [80, 255]
//           Note that it is almost impossible to find a threshold range to
//           detect both blue parts at the same time.
//
// * Step 3: Select Image 2
//           Note that this threshold mode is also very sensitive to
//           lighting changes!
//
// * Step 4: Select Image 1 agani.
//
// * Step 5: Next, work in a different color mode
//           based on Hue, Saturation, and Luminance pixel values.
//
//           Select the HSL Threshold color mode.
//
// * Step 6: The necessary information is essentially present
//           in the hue plane of the image.  Set the threshold range for
//           the Saturation and Luminance planes to [0,255].
//           Check different values for the hue threshold range.
//
// * Step 7: A good Hue threshold range to detect the blue
//           part is [110, 215].  In order to segment the green parts, try
//           the [40, 100] range.
//
// * Step 8: Change the image by clicking on the Image 1
//           and Image 2 option buttons.  Note that the HSL
//           threshold color mode is insensitive to light changes.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace ColorThreshold
{
    public partial class Form1 : Form
    {
        private string[] stepsArray = new string[8];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageViewer1.Image.Type = ImageType.Rgb32;
            InitializeStepsArray();
            stepsTextBox.Text = stepsArray[0];
            SetCaption();
            ReadImage();
        }

        private void SetCaption()
        {
            imageViewer2Label.Text = imageTypeRGB.Checked ? "RGB Threshold" : "HSL Threshold";
        }

        private void ReadImage()
        {
            if (imageSelection1.Checked)
            {
                imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Candy1.png"));
            }
            else
            {
                imageViewer1.Image.ReadFile(System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), "Candy2.png"));
            }
            DoThreshold();
        }

        private void DoThreshold()
        {
            // Perform the color threshold as long as the image is of the right type.
            if (imageViewer1.Image.Type == ImageType.Rgb32)
            {
                Algorithms.ColorThreshold(imageViewer1.Image, imageViewer2.Image, imageTypeRGB.Checked ? ColorMode.Rgb : ColorMode.Hsl, 1,
                    new Range(redMinimumSlide.Value, redMaximumSlide.Value), new Range(greenMinimumSlide.Value, greenMaximumSlide.Value),
                    new Range(blueMinimumSlide.Value, blueMaximumSlide.Value));
            }
        }

        private void InitializeStepsArray()
        {
            stepsArray[0] = "The Threshold Color Mode is set to RGB by default, which means that the " +
                            "threshold process is based on the red, green, and blue pixel values. " +
                            "By modifying the Red, Green, and Blue threshold values, try to " +
                            "find the best threshold range to separate the blue parts from the background.";
            stepsArray[1] = "Good values to segment the blue parts are approximately: \r\n" +
                            "Red = [0,142], Green = [0,145], Blue = [80,255]\r\n" +
                            "Note that it is almost impossible to find a threshold range to detect " +
                            "both blue parts at the same time.";
            stepsArray[2] = "Select Image #2\r\n" +
                            "Note that this threshold mode is also very sensitive to lighting changes.";
            stepsArray[3] = "Select Image #1 again.";
            stepsArray[4] = "Work in a different color mode based on Hue, Saturation, and Luminance " +
                            "values of the pixel.\r\n\r\n" +
                            "Select the HSL Threshold color mode.";
            stepsArray[5] = "The necessary information is essentially present in the hue plane " +
                            "of the image.  Set the threshold range for the Saturation and Luminance " +
                            "planes to [0,255]. Check different values for the hue threshold range.";
            stepsArray[6] = "A good Hue threshold range to detect the blue part is [110, 215].  In order " +
                            "to segment the green parts, try the [40, 100] range.";
            stepsArray[7] = "Change the image by clicking on the Image 1 and Image 2 option buttons.  Note " +
                            "that the HSL threshold color mode is insensitive to light changes.\r\n\r\n" +
                            "End of the example.";
        }
        private void redMinimumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void redMaximumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void greenMinimumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void greenMaximumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void blueMinimumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void blueMaximumSlide_ValueChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void stepNumber_ValueChanged(object sender, EventArgs e)
        {
            stepsTextBox.Text = stepsArray[(int)stepNumber.Value - 1];
        }

        private void imageSelection1_CheckedChanged(object sender, EventArgs e)
        {
            ReadImage();
        }

        private void imageSelection2_CheckedChanged(object sender, EventArgs e)
        {
            ReadImage();
        }

        private void imageTypeRGB_CheckedChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void imageTypeHSL_CheckedChanged(object sender, EventArgs e)
        {
            DoThreshold();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
