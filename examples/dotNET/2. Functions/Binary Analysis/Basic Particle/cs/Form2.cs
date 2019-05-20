using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NationalInstruments.Vision;
using NationalInstruments.Vision.Analysis;

namespace BasicParticle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            imageViewer2.Palette.Type = NationalInstruments.Vision.WindowsForms.PaletteType.Binary;
        }

        public VisionImage BeforeImage
        {
            get { return imageViewer1.Image; }
        }

        public VisionImage AfterImage
        {
            get { return imageViewer2.Image; }
        }
    }
}