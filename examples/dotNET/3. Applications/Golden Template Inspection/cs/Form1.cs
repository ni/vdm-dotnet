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
using NationalInstruments.Vision.WindowsForms;

// Golden Template Inspection Example
//
// The objective of this golden template inspection example is to determine if a label
// has been printed correctly or if it contains defects.  The example uses pattern matching
// to locate the label in the image.  Then the example compares the label in the image to
// the golden template.  After removing small defects, if any defects remain in the image
// the label fails.  Optionally the example will display the location of the defects
// by manipulating the palette of the viewer control.

// This example uses a demonstration version of the Measurement Studio user interface
// controls.  For more information, see http://www.ni.com/mstudio.
namespace GoldenTemplateInspection
{
    public partial class Form1 : Form
    {
        private string imagePath = System.IO.Path.Combine(ExampleImagesFolder.GetExampleImagesFolder(), @"Inspection\");
        private int imageNumber = 0;
        private Collection<VisionImage> images = new Collection<VisionImage>();
        private Collection<short> lookupTable = new Collection<short>();
        private VisionImage template = new VisionImage();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the lookup table.
            lookupTable.Add(255);
            for (short i = 1; i < 256; ++i)
            {
                lookupTable.Add(i);
            }

            // Read the golden template file.
            template.ReadVisionFile(System.IO.Path.Combine(imagePath, "template.png"));

            // Attach the template image to the viewer.
            imageViewer1.Attach(template);

            // Enable the timer.
            timer1.Enabled = true;
            timer1.Start();
            timer1_Tick(timer1, EventArgs.Empty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Get the next image.
            VisionImage image = GetNextImage();

            // Locate the template in the image.
            MatchPatternOptions matchOptions = new MatchPatternOptions(MatchMode.RotationInvariant, 1);
            matchOptions.MinimumMatchScore = 500;
            matchOptions.RotationAngleRanges.Add(new Range(-5, 5));
            Collection<PatternMatch> matches = Algorithms.MatchPattern(image, template, matchOptions);

            if (matches.Count != 1)
            {
                // If the template could not be located, the part fails.
                passFailLed.Value = false;
            }
            else
            {
                // Perform the inspection
                InspectionAlignment alignment = new InspectionAlignment(matches[0].Position, matches[0].Rotation);
                InspectionOptions inspectionOptions = new InspectionOptions();
                inspectionOptions.EdgeThicknessToIgnore = 1;
                using (VisionImage defectImage = new VisionImage())
                {
                    Algorithms.CompareGoldenTemplate(image, template, defectImage, alignment, inspectionOptions);

                    // Remove small defects from the image.
                    Algorithms.RemoveParticle(defectImage, defectImage);

                    // If there are still defects in the image, the part does not pass inspection.
                    if (Algorithms.ParticleReport(defectImage).Count > 0)
                    {
                        passFailLed.Value = false;
                    }
                    else
                    {
                        passFailLed.Value = true;
                    }

                    // Make a custom palette that displays the defects of interest (dark defects
                    // are set to 1 in the defect image and bright defects are set to 2):
                    // 1. Set the value of all non-defect pixels in the defect image to 255.
                    // 2. Set all of the pixels with a value of 1 or 2 to zero in the inspected image.
                    // 3. Make the requested defects visible by modifying the palette for the Viewer
                    // control.  Start with a grayscale palette.  Then modify the palette for the
                    // defect values (1 or 2) by changing them to a visible color.
                    // 4. Merge the defect image with the inspected image and place the output in
                    // the image attached to the viewer.
                    Algorithms.UserLookup(defectImage, defectImage, lookupTable);
                    Algorithms.Max(image, new PixelValue(3), image);
                    Palette palette = new Palette(PaletteType.Gray);
                    if (darkSwitch.Value)
                    {
                        palette.Entries[1] = new PaletteEntry(255, palette.Entries[1].Green, palette.Entries[1].Blue);
                    }
                    if (brightSwitch.Value)
                    {
                        palette.Entries[2] = new PaletteEntry(palette.Entries[2].Red, 255, palette.Entries[2].Blue);
                    }
                    imageViewer2.Palette = palette;
                    Algorithms.Min(image, defectImage, image);
                    imageViewer2.Attach(image);
                }

            }

        }
        private VisionImage GetNextImage()
        {
            VisionImage toReturn;
            // Load an image or return to the previous image.
            if (imageNumber >= images.Count)
            {
                toReturn = new VisionImage();
                toReturn.ReadFile(System.IO.Path.Combine(imagePath, "NI_Label_" + String.Format("{0:0000}", imageNumber) + ".jp2"));
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
            if (imageNumber > 11)
            {
                imageNumber = 0;
            }
            return toReturn;
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}