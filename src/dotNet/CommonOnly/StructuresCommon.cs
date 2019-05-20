//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2019, National Instruments Corp.

// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:

// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
// CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Globalization;
using NationalInstruments.Vision.Internal;

namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>
    /// Specifies options for interacting with and removing extra vision information.
    /// </summary>

    [Flags]
    public enum InfoTypes
    {
        //==========================================================================================
        /// <summary>
        /// No vision information.
        /// </summary>

        None = 0,
        //==========================================================================================
        /// <summary>
        /// Calibration information
        /// </summary>

        Calibration = 0x1,
        //==========================================================================================
        /// <summary>
        /// Overlay information.
        /// </summary>

        Overlay = 0x2,
        //==========================================================================================
        /// <summary>
        /// Grayscale template information.
        /// </summary>

        GrayTemplate = 0x4,
        //==========================================================================================
        /// <summary>
        /// Color template information.
        /// </summary>

        ColorTemplate = 0x8,
        //==========================================================================================
        /// <summary>
        /// Geometric template information.
        /// </summary>

        GeometricTemplate = 0x10,
        //==========================================================================================
        /// <summary>
        /// Custom data information.
        /// </summary>

        CustomData = 0x20,
        //==========================================================================================
        /// <summary>
        /// Golden template information.
        /// </summary>

        GoldenTemplate = 0x40,
        GeometricTemplate2 = 0x80
    }
    //==============================================================================================
    /// <summary>
    /// Specifies a complex plane.
    /// </summary>

    public enum ComplexPlane
    {
        //==========================================================================================
        /// <summary>
        /// Real plane.
        /// </summary>

        Real = 0,
        //==========================================================================================
        /// <summary>
        /// Imaginary plane.
        /// </summary>

        Imaginary = 1,
        //==========================================================================================
        /// <summary>
        /// Magnitude plane.
        /// </summary>

        Magnitude = 2,
        //==========================================================================================
        /// <summary>
        /// Phase plane.
        /// </summary>

        Phase = 3
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the wavelet transform modes to use when writing the file.
    /// </summary>

    public enum WaveletTransformMode
    {
        //==========================================================================================
        /// <summary>
        /// Uses a 5-3 reversible integer transform. This transform is generally faster than the floating-point transform, but produces less accurate results.
        /// </summary>

        Integer = 0,
        //==========================================================================================
        /// <summary>
        /// Performs a 9-7 irreversible floating-point transform. This transform is generally more accurate than the integer transform, but is slower.
        /// </summary>

        FloatingPoint = 1
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the photometric interpretation options for use with the <see cref="NationalInstruments.Vision.TiffOptions.PhotometricMode" crefType="Unqualified"/> property.
    /// </summary>

    public enum PhotometricMode
    {
        //==========================================================================================
        /// <summary>
        /// Pixels with a 0 value are considered white.
        /// </summary>

        WhiteIsZero = 0,
        //==========================================================================================
        /// <summary>
        /// Pixels with a 0 value are considered black.
        /// </summary>

        BlackIsZero = 1
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the compression type for TIFF files.
    /// </summary>

    public enum TiffCompressionType
    {
        //==========================================================================================
        /// <summary>
        /// Does not apply compression when <see cref="NationalInstruments.Vision.VisionImage.WriteTiffFile" crefType="Unqualified"/> writes the TIFF file.
        /// </summary>

        None = 0,
        //==========================================================================================
        /// <summary>
        /// Applies JPEG compression when <see cref="NationalInstruments.Vision.VisionImage.WriteTiffFile" crefType="Unqualified"/> writes the TIFF file. JPEG compression is not a valid value for signed 16-bit or unsigned 64-bit RGB images.
        /// </summary>

        Jpeg = 1,
        //==========================================================================================
        /// <summary>
        /// Uses Run Length encoding when <see cref="NationalInstruments.Vision.VisionImage.WriteTiffFile" crefType="Unqualified"/> writes the TIFF file.
        /// </summary>

        RunLength = 2,
        //==========================================================================================
        /// <summary>
        /// Applies Zip compression when <see cref="NationalInstruments.Vision.VisionImage.WriteTiffFile" crefType="Unqualified"/>  writes the TIFF file.
        /// </summary>

        Zip = 3
    }
    //==============================================================================================
    /// <summary>
    /// Indicates what parts of the image to flatten.
    /// </summary>

    public enum FlattenType
    {
        //==========================================================================================
        /// <summary>
        /// Flattens only the image data.
        /// </summary>

        Image = 0,
        //==========================================================================================
        /// <summary>
        /// Flattens the image data and any Vision information associated with the image.
        /// </summary>

        ImageAndVisionInfo = 1
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the type of compression to use.
    /// </summary>

    public enum CompressionType
    {
        //==========================================================================================
        /// <summary>
        /// No compression.
        /// </summary>

        None = 0,
        //==========================================================================================
        /// <summary>
        /// JPEG compression. 
        /// This compression may cause data degradation.
        /// </summary>

        Jpeg = 1,
        //==========================================================================================
        /// <summary>
        /// Lossless binary packing compression. This setting is ideal for preserving data integrity when flattening binary images. Do not use this setting for nonbinary images.</summary>

        PackedBinary = 2
    }
    //==============================================================================================
    /// <summary>
    /// Specifies operations that you can apply to the border of the image.
    /// </summary>

    public enum BorderMethod
    {
        //==========================================================================================
        /// <summary>
        /// Symmetrically copies pixel values from the image into the border.
        /// </summary>

        Mirror = 0,
        //==========================================================================================
        /// <summary>
        /// Copies the value of the pixel closest to the edge of the image into the border.
        /// </summary>

        Copy = 1,
        //==========================================================================================
        /// <summary>
        /// Sets all pixels in the border to 0.
        /// </summary>

        Clear = 2
    }
    //==============================================================================================
    /// <summary>
    /// Specifies how to draw a contour.</summary>

    public enum DrawingMode
    {
        //==========================================================================================
        /// <summary>
        /// Draws the contour of the shape using the color specified.
        /// </summary>

        DrawValue = 0,
        //==========================================================================================
        /// <summary>
        /// Draws the contour of the shape using the inverse of the pixel values.
        /// </summary>

        DrawInvert = 2,
        //==========================================================================================
        /// <summary>
        /// Draws the contour and interior of the shape using the color specified.
        /// </summary>

        PaintValue = 1,
        //==========================================================================================
        /// <summary>
        /// Draws the contour and interior of the shape using the inverse of the pixel values.
        /// </summary>

        PaintInvert = 3,
        //==========================================================================================
        /// <summary>
        /// Fills the contour by highlighting the enclosed pixels with the color of the object.  The highlighting allows features of an image to persist inside a filled object.  This value is only valid when passed to <see cref="NationalInstruments.Vision.Overlay.AddRectangle" crefType="Unqualified"/>.
        /// </summary>

        HighlightValue = 4
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the behavior for an overlay group.
    /// </summary>

    public enum GroupBehavior
    {
        //==========================================================================================
        /// <summary>
        /// Clears the current overlay group when an image is transformed.
        /// </summary>

        Clear = 0,
        //==========================================================================================
        /// <summary>
        /// Keeps the current overlay group in place when an image is transformed.
        /// </summary>

        Keep = 1,
        //==========================================================================================
        /// <summary>
        /// Transforms the current overlay group with the image when an image is transformed.
        /// </summary>

        Transform = 2
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the symbol to represent a point in an overlay.
    /// </summary>

    public enum PointSymbolType
    {
        //==========================================================================================
        /// <summary>
        /// A single pixel represents a point in the overlay.
        /// </summary>

        Pixel = 0,
        //==========================================================================================
        /// <summary>
        /// A cross represents a point in the overlay.
        /// </summary>

        Cross = 1,
        //==========================================================================================
        /// <summary>
        /// The pattern supplied by the user with <see cref="NationalInstruments.Vision.PointSymbol.SetUserDefined" crefType="Unqualified"/> represents a point in the overlay.
        /// </summary>

        UserDefined = 2
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the horizontal alignment of text.
    /// </summary>

    public enum HorizontalTextAlignment
    {
        //==========================================================================================
        /// <summary>
        /// Left aligns the text at the reference point.
        /// </summary>

        Left = 0,
        //==========================================================================================
        /// <summary>
        /// Centers the text around the reference point.
        /// </summary>

        Center = 1,
        //==========================================================================================
        /// <summary>
        /// Right aligns the text at the reference point.
        /// </summary>

        Right = 2
    }

    //==============================================================================================
    /// <summary>
    /// Specifies where the origin of the text is in relation to the baseline of the text.
    /// </summary>

    public enum VerticalTextAlignment
    {
        //==========================================================================================
        /// <summary>
        /// Indicates that the origin point is below the baseline (i.e. the text is above the origin).
        /// </summary>

        Bottom = 0,
        //==========================================================================================
        /// <summary>
        /// Indicates that the origin point is above the baseline (i.e. the text is below the origin).
        /// </summary>

        Top = 1,
        //==========================================================================================
        /// <summary>
        /// Indicates that the origin point is on the baseline.
        /// </summary>

        Baseline = 2
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the type of distortion for which the calibration information is learned.
    /// </summary>

    public enum CalibrationMethod
    {
        //==========================================================================================
        /// <summary>
        /// Perspective calibration. This is a valid input to the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.LearnCalibrationGrid</format> class 
        /// and the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.LearnCalibrationPoints</format> class. Use this method when lens distortion is negligible.
        /// </summary>

        Perspective = 0,
        //==========================================================================================
        /// <summary>
        /// Nonlinear calibration. 
        /// This is a valid input to the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.LearnCalibrationGrid</format> class 
        /// and the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.LearnCalibrationPoints</format> class. Use this method if the image contains lens distortion.
        /// </summary>

        Nonlinear = 1,
        //==========================================================================================
        /// <summary>
        /// Simple calibration. 
        /// The <format type="monospace">NationalInstruments.Vision.Analysis.VisionImage.GetCalibrationInfo</format> 
        /// returns this value for images calibrated by the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.SetSimpleCalibration</format>  method.
        /// </summary>

        SimpleCalibration = 2,
        //==========================================================================================
        /// <summary>
        /// Corrected. <see cref="NationalInstruments.Vision.VisionImage.GetCalibrationInfo" crefType="Unqualified"/> returns this for a corrected image.
        /// A corrected image contains information about the calibration unit and scaling factor.
        /// </summary>

        CorrectedImage = 3
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the calibration method for which information is learned.
    /// </summary>

    public enum CalibrationMethod2
    {
        //==========================================================================================
        /// <summary>
        /// Perspective calibration is used when lens distortion is negligible.
        /// </summary>

        Perspective = 0,
        //==========================================================================================
        /// <summary>
        /// Microplane calibration is used when the image contains lens distortion.
        /// </summary>

        Microplane = 1,
        //==========================================================================================
        /// <summary>
        /// Simple calibration. 
        /// The <format type="monospace">NationalInstruments.Vision.Algorithms.CalibrationGetCalibrationInfo</format> 
        /// returns this value for images calibrated using Simple calibration.
        /// </summary>

        SimpleCalibration = 2,
        //==========================================================================================
        /// <summary>
        /// Corrected. A corrected image contains information about the calibration unit and scaling factor.
        /// </summary>

        CorrectedImage = 3,
        //==========================================================================================
        /// <summary>
        /// Image with no calibration.
        /// </summary>

        NoCalibration = 4
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the aspect scaling to be used in the corrected image.
    /// </summary>

    public enum ScalingMethod
    {
        //==========================================================================================
        /// <summary>
        /// The corrected image is scaled such that the features in the image have the same size as the input image.
        /// </summary>

        ScaleToPreserveArea = 0,
        //==========================================================================================
        /// <summary>
        /// The corrected image is scaled to be the same size as the input image.
        /// </summary>

        ScaleToFit = 1
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the regions you can use when correcting an image.
    /// </summary>

    public enum CalibrationCorrectionMode
    {
        //==========================================================================================
        /// <summary>
        /// The whole image is always corrected, regardless of the user-defined or calibration-defined regions.
        /// </summary>

        FullImage = 0,
        //==========================================================================================
        /// <summary>
        /// The area defined by the CalibrationRegions is corrected. The CalibrationRegions is computed by the algorithm and corresponds to the area of the calibration template containing dots.
        /// </summary>

        CalibrationRoi = 1,
        //==========================================================================================
        /// <summary>
        /// The area defined by the user-defined regions is corrected. 
        /// </summary>

        UserRoi = 2,
        //==========================================================================================
        /// <summary>
        /// The area defined by the intersection of the user-defined regions and calibration regions is corrected.
        /// </summary>

        CalibrationAndUserRoi = 3,
        //==========================================================================================
        /// <summary>
        /// The area defined by the union of the user-defined regions and calibration regions is corrected.
        /// </summary>

        CalibrationOrUserRoi = 4
    }

    //==============================================================================================
    /// <summary>
    /// Specifies direction of the coordinate system.
    /// </summary>
    /// <remarks>
    /// As shown in the following illustration, direct axis orientation indicates that the y-axis direction is 90 degrees counter-clockwise from the x-axis direction. Indirect axis orientation indicates that the y-axis direction is 90 degrees clockwise from the x-axis direction. 
    /// <image src="axis.gif"/>
    /// </remarks>

    public enum AxisOrientation
    {
        //==========================================================================================
        /// <summary>
        /// Direct axis orientation. Indicates that the y-axis direction is 90 degrees counter-clockwise from the x-axis direction.
        /// </summary>

        Direct = 0,
        //==========================================================================================
        /// <summary>
        /// Indirect axis orientation. Indicates that the y-axis direction is 90 degrees clockwise from the x-axis direction.
        /// </summary>

        Indirect = 1
    }

    //==============================================================================================
    /// <summary>
    /// Specifies the units in which the real world coordinates are expressed.
    /// </summary>

    public enum CalibrationUnit
    {
        //==========================================================================================
        /// <summary>
        /// Undefined.
        /// </summary>

        Undefined = 0,
        //==========================================================================================
        /// <summary>
        /// Angstrom
        /// </summary>

        Angstrom = 1,
        //==========================================================================================
        /// <summary>
        /// Micrometer
        /// </summary>

        Micrometer = 2,
        //==========================================================================================
        /// <summary>
        /// Millimeter
        /// </summary>

        Millimeter = 3,
        //==========================================================================================
        /// <summary>
        /// Centimeter
        /// </summary>

        Centimeter = 4,
        //==========================================================================================
        /// <summary>
        /// Meter
        /// </summary>

        Meter = 5,
        //==========================================================================================
        /// <summary>
        /// Kilometer.
        /// </summary>

        Kilometer = 6,
        //==========================================================================================
        /// <summary>
        /// Microinch
        /// </summary>

        Microinch = 7,
        //==========================================================================================
        /// <summary>
        /// Inch.
        /// </summary>

        Inch = 8,
        //==========================================================================================
        /// <summary>
        /// Foot
        /// </summary>

        Foot = 9,
        //==========================================================================================
        /// <summary>
        /// Nautical mile
        /// </summary>

        NauticalMile = 10,
        //==========================================================================================
        /// <summary>
        /// Ground mile.
        /// </summary>

        GroundMile = 11,
        //==========================================================================================
        /// <summary>
        /// Step
        /// </summary>

        Step = 12
    }
    //==============================================================================================
    /// <summary>
    /// Specifies the color mode.
    /// </summary>

    public enum ColorMode
    {
        //==========================================================================================
        /// <summary>
        /// RGB (Red, Green, Blue).
        /// </summary>

        Rgb = 0,
        //==========================================================================================
        /// <summary>
        /// HSL (Hue, Saturation, Luminance).
        /// </summary>

        Hsl = 1,
        //==========================================================================================
        /// <summary>
        /// HSV (Hue, Saturation, Value).
        /// </summary>

        Hsv = 2,
        //==========================================================================================
        /// <summary>
        /// HSI (Hue, Saturation, Intensity)
        /// </summary>

        Hsi = 3,
        //==========================================================================================
        /// <summary>
        /// CIE L*a*b*
        /// </summary>

        CieLab = 4,
        //==========================================================================================
        /// <summary>
        /// CIE XYZ
        /// </summary>

        CieXyz = 5
    }
    //==============================================================================================
    /// <summary>
    /// Provides advanced options to use when writing a JPEG2000 file.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class Jpeg2000AdvancedOptions
    {
        private WaveletTransformMode _waveletTransformMode;
        private bool _useMultiComponentTransform;
        private UInt32 _maximumWaveletTransformLevel;
        private double _quantizationStepSize;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Jpeg2000AdvancedOptions" crefType="Unqualified"/> class.
        /// </summary>

        public Jpeg2000AdvancedOptions() : this(WaveletTransformMode.Integer)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Jpeg2000AdvancedOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.WaveletTransformMode" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="waveletTransformMode">
        /// The wavelet transform to use when writing the file.
        /// </param>

        public Jpeg2000AdvancedOptions(WaveletTransformMode waveletTransformMode)
        {
            _waveletTransformMode = waveletTransformMode;
            _useMultiComponentTransform = true;
            _maximumWaveletTransformLevel = 5;
            _quantizationStepSize = 0;
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the absolute base quantization step size for derived quantization mode.
        /// </summary>
        /// <value>
        /// The absolute base quantization step size for derived quantization mode.
        /// The default value is 0.
        /// </value>
        /// <remarks>
        /// This property has no effect when the <see cref="NationalInstruments.Vision.Jpeg2000AdvancedOptions.WaveletTransformMode" crefType="Unqualified"/> property is <see cref="NationalInstruments.Vision.WaveletTransformMode.Integer" crefType="Unqualified"/>.
        /// </remarks>

        public double QuantizationStepSize
        {
            get { return _quantizationStepSize; }
            set { _quantizationStepSize = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the maximum allowed level of wavelet transform.
        /// </summary>
        /// <value>
        /// Values range from 0 to 255. The default value is 5.
        /// </value>
        /// <remarks>
        /// Increasing this value will result in a more accurate image, but will increase the time to write the image. 
        /// </remarks>

        [CLSCompliant(false)]
        public UInt32 MaximumWaveletTransformLevel
        {
            get { return _maximumWaveletTransformLevel; }
            set { _maximumWaveletTransformLevel = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether to use an additional transformation on RGB images.
        /// </summary>
        /// <value>
        /// The default value is <see langword="true"/>.
        /// </value>
        /// <remarks>
        /// Set this property to <see langword="true"/> to use an additional transform on RGB images. Set this property to <see langword="false"/> to not use an additional transform. This property has no effect when encoding grayscale images.
        /// </remarks>

        public bool UseMultipleComponentTransform
        {
            get { return _useMultiComponentTransform; }
            set { _useMultiComponentTransform = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the wavelet transform to use when writing the file.
        /// </summary>
        /// <value>
        /// The default value is <see cref="NationalInstruments.Vision.WaveletTransformMode.Integer" crefType="Unqualified"/>.
        /// </value>
        /// <remarks>
        /// 	<see cref="NationalInstruments.Vision.WaveletTransformMode.FloatingPoint" crefType="Unqualified"/> performs a 9-7 irreversible floating-point transform. This transform is generally more accurate than the integer transform, but is slower.
        /// <see cref="NationalInstruments.Vision.WaveletTransformMode.Integer" crefType="Unqualified"/> uses a 5-3 reversible integer transform. This transform is generally faster than the floating-point transform, but produces less accurate results.
        /// </remarks>

        public WaveletTransformMode WaveletTransformMode
        {
            get { return _waveletTransformMode; }
            set { _waveletTransformMode = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A Jpeg2000AdvancedOptions instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Jpeg2000AdvancedOptions other)
        {
            return other != null && _waveletTransformMode == other._waveletTransformMode && _useMultiComponentTransform == other._useMultiComponentTransform && _maximumWaveletTransformLevel == other._maximumWaveletTransformLevel && _quantizationStepSize == other._quantizationStepSize;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Jpeg2000AdvancedOptions other = (Jpeg2000AdvancedOptions)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _waveletTransformMode.GetHashCode() ^ _useMultiComponentTransform.GetHashCode() ^ _maximumWaveletTransformLevel.GetHashCode() ^ _quantizationStepSize.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Jpeg2000AdvancedOptions: WaveletTransformMode=" + _waveletTransformMode.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides the options to use when writing a TIFF file.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class TiffOptions
    {
        private int _rowsPerStrip;
        private PhotometricMode _photometricMode;
        private TiffCompressionType _compressionType;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TiffOptions" crefType="Unqualified"/> class.
        /// </summary>

        public TiffOptions()
            : this(TiffCompressionType.None)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TiffOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.TiffOptions.CompressionType" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="compressionType">
        /// The type of compression to use on the TIFF.
        /// </param>

        public TiffOptions(TiffCompressionType compressionType)
        {
            _compressionType = compressionType;
            _rowsPerStrip = 0;
            _photometricMode = PhotometricMode.BlackIsZero;
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the type of compression to use on the TIFF.
        /// </summary>
        /// <value>
        /// The type of compression to use on the TIFF.
        /// The default value is None. </value>

        public TiffCompressionType CompressionType
        {
            get { return _compressionType; }
            set { _compressionType = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the photometric interpretation to use.
        /// </summary>
        /// <value>
        /// The photometric interpretation to use.
        /// The default value is <see cref="NationalInstruments.Vision.PhotometricMode.BlackIsZero" crefType="Unqualified"/>.
        /// </value>

        public PhotometricMode PhotometricMode
        {
            get { return _photometricMode; }
            set { _photometricMode = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the number of rows to write per strip.
        /// </summary>
        /// <value>
        /// The number of rows to write per strip.
        /// The default value is 0.
        /// </value>

        public int RowsPerStrip
        {
            get { return _rowsPerStrip; }
            set { _rowsPerStrip = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A TiffOptions instance to compare to this instance.
        /// </param>
        /// <returns>
        /// </returns>

        public bool Equals(TiffOptions other)
        {
            return other != null && _rowsPerStrip == other._rowsPerStrip && _photometricMode == other._photometricMode && _compressionType == other._compressionType;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            TiffOptions other = (TiffOptions)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _rowsPerStrip.GetHashCode() ^ _photometricMode.GetHashCode() ^ _compressionType.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "TiffOptions: CompressionType=" + _compressionType.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides information describing the calibration of an image.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CalibrationInfo : IDisposable, IEquatable<CalibrationInfo>
    {
        private float[,] _errorMap;
        private Roi _userRoi;
        private Roi _calibrationRoi;
        private LearnCalibrationOptions _learnCalibrationOptions;
        private CalibrationGridOptions _calibrationGridOptions;
        private double _quality;
        private object _disposeLock = new object();

        //==========================================================================================
        /// <summary>
        /// Gets or sets the quality score of the learning process. 
        /// </summary>
        /// <value>
        /// Values are between 0-1000. 
        /// </value>
        /// <remarks>
        /// A quality of 1000 means that the feature points were well-learned by the chosen algorithm. It does not necessarily reflect the absolute accuracy of the estimated calibration mapping.
        /// </remarks>

        public double Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the scaling constants used to calibrate the image.
        /// </summary>
        /// <value>
        /// The scaling constants used to calibrate the image.
        /// </value>

        public CalibrationGridOptions CalibrationGridOptions
        {
            get { return _calibrationGridOptions; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _calibrationGridOptions = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the settings used to determine how the algorithm calibrated your imaging setup.
        /// </summary>
        /// <value>
        /// The settings used to determine how the algorithm calibrated your imaging setup.
        /// </value>

        public LearnCalibrationOptions LearnCalibrationOptions
        {
            get { return _learnCalibrationOptions; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _learnCalibrationOptions = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the regions that correspond to the region of the image where the calibration information is accurate.
        /// </summary>
        /// <value>
        /// The regions that correspond to the region of the image where the calibration information is accurate.
        /// </value>

        public Roi CalibrationRoi
        {
            get { return _calibrationRoi; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _calibrationRoi = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the regions you specified at the time of calibration.
        /// </summary>
        /// <value>
        /// The regions you specified at the time of calibration.
        /// </value>

        public Roi UserRoi
        {
            get { return _userRoi; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _userRoi = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the 2D error map, if it was determined by <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/>.
        /// </summary>
        /// <value>
        /// A 2D error map.
        /// </value>

        public float[,] ErrorMap
        {
            get { return _errorMap; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _errorMap = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CalibrationInfo" crefType="Unqualified"/> class.
        /// </summary>

        public CalibrationInfo()
        {
            _errorMap = new float[0, 0];
            _userRoi = new Roi();
            _calibrationRoi = new Roi();
            _learnCalibrationOptions = new LearnCalibrationOptions();
            _calibrationGridOptions = new CalibrationGridOptions();
            _quality = 0.0;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A CalibrationInfo instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(CalibrationInfo other)
        {
            return other != null && Utilities.ArraysEqual(_errorMap, other._errorMap) && Object.Equals(_userRoi, other._userRoi) && Object.Equals(_calibrationRoi, other._calibrationRoi) && Object.Equals(_learnCalibrationOptions, other._learnCalibrationOptions) && Object.Equals(_calibrationGridOptions, other._calibrationGridOptions) && _quality == other._quality;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CalibrationInfo other = (CalibrationInfo)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _errorMap.GetHashCode() ^ _userRoi.GetHashCode() ^ _calibrationRoi.GetHashCode() ^ _learnCalibrationOptions.GetHashCode() ^ _calibrationGridOptions.GetHashCode() ^ _quality.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CalibrationInfo: Quality=" + _quality.ToString(CultureInfo.CurrentCulture);
        }
        //==========================================================================================
        /// <summary>
        /// Releases the resources used by <see cref="NationalInstruments.Vision.CalibrationInfo" crefType="Unqualified"/>. 
        /// </summary>

        public void Dispose()
		{
            Dispose(true);
            GC.SuppressFinalize(this);
        }

private void Dispose(bool disposing) {
            if (disposing)
            {
                lock (_disposeLock)
                {
                    // Dispose the ROIs.
                    _userRoi.Dispose();
                    _calibrationRoi.Dispose();
                }
            }
		}

        
        ~CalibrationInfo()
        {
            Dispose(false);
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the behavior of overlays when an image is transformed.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class TransformBehaviors : IEquatable<TransformBehaviors>
    {
        private GroupBehavior _shift;
        private GroupBehavior _scale;
        private GroupBehavior _rotate;
        private GroupBehavior _symmetry;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TransformBehaviors" crefType="Unqualified"/> class. 
        /// </summary>

        public TransformBehaviors() : this(GroupBehavior.Clear)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TransformBehaviors" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.TransformBehaviors.Shift" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="shift">
        /// The behavior of an overlay group when a shift operation is applied to an image. 
        /// </param>

        public TransformBehaviors(GroupBehavior shift)
            : this(shift, GroupBehavior.Clear)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TransformBehaviors" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.TransformBehaviors.Shift" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.TransformBehaviors.Scale" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="shift">
        /// The behavior of an overlay group when a shift operation is applied to an image. 
        /// </param>
        /// <param name="scale">
        /// The behavior of an overlay group when a scale operation is applied to an image. 
        /// </param>

        public TransformBehaviors(GroupBehavior shift, GroupBehavior scale)
            : this(shift, scale, GroupBehavior.Clear)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TransformBehaviors" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.TransformBehaviors.Shift" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.TransformBehaviors.Scale" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.TransformBehaviors.Rotate" crefType="Unqualified"/>.  
        /// </summary>
        /// <param name="shift">
        /// The behavior of an overlay group when a shift operation is applied to an image. 
        /// </param>
        /// <param name="scale">
        /// The behavior of an overlay group when a scale operation is applied to an image. 
        /// </param>
        /// <param name="rotate">
        /// The behavior of an overlay group when a rotate operation is applied to an image. 
        /// </param>

        public TransformBehaviors(GroupBehavior shift, GroupBehavior scale, GroupBehavior rotate)
            : this(shift, scale, rotate, GroupBehavior.Clear)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TransformBehaviors" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.TransformBehaviors.Shift" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.TransformBehaviors.Scale" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.TransformBehaviors.Rotate" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.TransformBehaviors.Symmetry" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="shift">
        /// The behavior of an overlay group when a shift operation is applied to an image. 
        /// </param>
        /// <param name="scale">
        /// The behavior of an overlay group when a scale operation is applied to an image. 
        /// </param>
        /// <param name="rotate">
        /// The behavior of an overlay group when a rotate operation is applied to an image. 
        /// </param>
        /// <param name="symmetry">
        /// The behavior of an overlay group when a symmetry operation is applied to an image. 
        /// </param>

        public TransformBehaviors(GroupBehavior shift, GroupBehavior scale, GroupBehavior rotate, GroupBehavior symmetry)
        {
            _shift = shift;
            _scale = scale;
            _rotate = rotate;
            _symmetry = symmetry;
        }

        
        internal event EventHandler<EventArgs> PropertyChanged;

        
        internal void OnPropertyChanged(EventArgs args) {
            EventHandler<EventArgs> handler = PropertyChanged;
            if (handler != null) {
                handler(this, args);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the behavior of an overlay group when a symmetry operation is applied to an image. 
        /// </summary>
        /// <value>
        /// The behavior of an overlay group when a symmetry operation is applied to an image. 
        /// The default value is <see cref="NationalInstruments.Vision.GroupBehavior.Clear" crefType="Unqualified"/>.
        /// </value>

        public GroupBehavior Symmetry
        {
            get { return _symmetry; }
            set
            {
                _symmetry = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the behavior of an overlay group when a rotate operation is applied to an image. 
        /// </summary>
        /// <value>
        /// The behavior of an overlay group when a rotate operation is applied to an image. 
        /// The default value is <see cref="NationalInstruments.Vision.GroupBehavior.Clear" crefType="Unqualified"/>.
        /// </value>

        public GroupBehavior Rotate
        {
            get { return _rotate; }
            set
            {
                _rotate = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the behavior of an overlay group when a scale operation is applied to an image. 
        /// </summary>
        /// <value>
        /// The behavior of an overlay group when a scale operation is applied to an image. 
        /// The default value is <see cref="NationalInstruments.Vision.GroupBehavior.Clear" crefType="Unqualified"/>.
        /// </value>

        public GroupBehavior Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the behavior of an overlay group when a shift operation is applied to an image. 
        /// </summary>
        /// <value>
        /// The behavior of an overlay group when a shift operation is applied to an image. 
        /// The default value is <see cref="NationalInstruments.Vision.GroupBehavior.Clear" crefType="Unqualified"/>.
        /// </value>

        public GroupBehavior Shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.
        /// </summary>
        /// <param name="other">
        /// A TransformBehaviors instance to compare to this instance.
        /// </param>
        /// <returns>
        /// </returns>

        public bool Equals(TransformBehaviors other)
        {
            return other != null && _shift == other._shift && _scale == other._scale && _rotate == other._rotate && _symmetry == other._symmetry; 
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            TransformBehaviors other = (TransformBehaviors)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _shift.GetHashCode() ^ _scale.GetHashCode() ^ _rotate.GetHashCode() ^ _symmetry.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "TransformBehaviors: Shift=" + _shift.ToString() + ", Scale=" + _scale.ToString() + ", Rotate=" + _rotate.ToString() + ", Symmetry=" + _symmetry.ToString();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Defines the angles and oval of an arc.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class Arc
    {
        private PointContour _center;
        private double _radius;
        private double _startAngle;
        private double _endAngle;

public Arc()
            : this(new PointContour(), 0.0, 0.0, 0.0)
        {
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Arc" crefType="Unqualified"/> class with the specified angles, radius, and center..
        /// </summary>
        /// <param name="center">
        /// Oval on which this arc lies.
        /// </param>
        /// <param name="radius">
        /// The radius of the arc.</param>
        /// <param name="startAngle">
        /// Start angle, in degrees, of the arc.
        /// </param>
        /// <param name="endAngle">
        /// End angle, in degrees, of the arc.
        /// </param>

        public Arc(PointContour center, double radius, double startAngle, double endAngle)
        {
            if (center == null) { throw new ArgumentNullException("center"); }
            _center = center;
            _radius = radius;
            _startAngle = startAngle;
            _endAngle = endAngle;
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the end angle, in degrees, of the arc.
        /// </summary>
        /// <value>
        /// The end angle of the arc.
        /// The default value is 0.
        /// </value>

        public double EndAngle
        {
            get { return _endAngle; }
            set { _endAngle = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the start angle, in degrees, of the arc.
        /// </summary>
        /// <value>
        /// The start angle of the arc.
        /// The default value is 0.
        /// </value>

        public double StartAngle
        {
            get { return _startAngle; }
            set { _startAngle = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the radius of the arc.
        /// </summary>
        /// <value>
        /// The radius of the arc.
        /// The default value is 0.
        /// </value>

        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the center of this arc.
        /// </summary>
        /// <value>
        /// The center of this arc.
        /// The default value is (0,0).
        /// </value>

        public PointContour Center
        {
            get { return _center; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _center = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An <see cref="NationalInstruments.Vision.Arc" crefType="Unqualified"/> instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Arc other)
        {
            return (other != null) && Object.Equals(_center, other._center) && _radius == other._radius && _startAngle == other._startAngle && _endAngle == other._endAngle;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Arc other = (Arc)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _center.GetHashCode() ^ _radius.GetHashCode() ^ _startAngle.GetHashCode() ^ _endAngle.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Arc: Center=" + _center.ToString() + ", Radius=" + _radius.ToString(CultureInfo.CurrentCulture) + ", StartAngle=" + _startAngle.ToString(CultureInfo.CurrentCulture) + ", EndAngle=" + _endAngle.ToString(CultureInfo.CurrentCulture);
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines how a method overlays text.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class OverlayTextOptions
    {
        private string _fontName;
        private Int32 _fontSize;
        private TextDecoration _textDecoration;
        private HorizontalTextAlignment _horizontalAlignment;
        private VerticalTextAlignment _verticalAlignment;
        private Rgb32Value _backgroundColor;
        private double _angle;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the counterclockwise angle of the text relative to the x-axis. 
        /// </summary>
        /// <value>
        /// The counterclockwise angle, in degrees, of the text relative to the x-axis. 
        /// The default value is 0.
        /// </value>

        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the color for the text background pixels. 
        /// </summary>
        /// <value>
        /// The color for the text background pixels.
        /// The default value is R=0, G=0, and B=0.
        /// </value>

        public Rgb32Value BackgroundColor
        {
            get { return _backgroundColor; }
            set { _backgroundColor = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the horizontal alignment of the text. 
        /// </summary>
        /// <value>
        /// The horizontal alignment of the text. 
        /// The default value is Left.
        /// </value>

        public HorizontalTextAlignment HorizontalAlignment
        {
            get { return _horizontalAlignment; }
            set { _horizontalAlignment = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the vertical alignment for the text. 
        /// </summary>
        /// <value>
        /// The vertical alignment for the text. 
        /// The default value is Bottom.
        /// </value>

        public VerticalTextAlignment VerticalAlignment
        {
            get { return _verticalAlignment; }
            set { _verticalAlignment = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the style of the font.
        /// </summary>
        /// <value>
        /// The style of the font.
        /// The default value is no text decoration.
        /// </value>

        public TextDecoration TextDecoration
        {
            get { return _textDecoration; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _textDecoration = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the size of the font. 
        /// </summary>
        /// <value>
        /// The size of the font. 
        /// The default value is 12 pt.
        /// </value>

        public Int32 FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the name of the font to use.
        /// </summary>
        /// <value>
        /// The name of the font to use.
        /// The default value is Arial.
        /// </value>
        /// <remarks>
        /// This method processes only the first 32 characters.
        /// </remarks>

        public string FontName
        {
            get { return _fontName; }
            set { _fontName = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OverlayTextOptions" crefType="Unqualified"/> class.
        /// </summary>

        public OverlayTextOptions()
            : this("Arial", 12)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OverlayTextOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.OverlayTextOptions.FontName" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.OverlayTextOptions.FontSize" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="fontName">
        /// The name of the font to use.
        /// </param>
        /// <param name="fontSize">
        /// The size of the font. 
        /// </param>

        public OverlayTextOptions(string fontName, Int32 fontSize)
            : this(fontName, fontSize, HorizontalTextAlignment.Left)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.OverlayTextOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.OverlayTextOptions.FontName" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.OverlayTextOptions.FontSize" crefType="Unqualified"/>, and alignment.
        /// </summary>
        /// <param name="fontName">
        /// The name of the font to use.
        /// </param>
        /// <param name="fontSize">
        /// The size of the font. 
        /// </param>
        /// <param name="alignment">
        /// The horizontal alignment of the font.
        /// </param>

        public OverlayTextOptions(string fontName, Int32 fontSize, HorizontalTextAlignment alignment)
        {
            _fontName = fontName;
            _fontSize = fontSize;
            _horizontalAlignment = alignment;
            _verticalAlignment = VerticalTextAlignment.Bottom;
            _textDecoration = new TextDecoration();
            _backgroundColor = Rgb32Value.TransparentColor;
            _angle = 0.0;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An OverlayTextOptions instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(OverlayTextOptions other)
        {
            return other != null && _fontName == other._fontName && _fontSize == other._fontSize && _horizontalAlignment == other._horizontalAlignment && _verticalAlignment == other._verticalAlignment && _textDecoration.Equals(other._textDecoration) && _backgroundColor == other._backgroundColor && _angle == other._angle;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            OverlayTextOptions other = (OverlayTextOptions)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _fontName.GetHashCode() ^ _fontSize.GetHashCode() ^ _horizontalAlignment.GetHashCode() ^ _verticalAlignment.GetHashCode() ^ _textDecoration.GetHashCode() ^ _backgroundColor.GetHashCode() ^ _angle.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "OverlayTextOptions: FontName=" + _fontName.ToString() + ", FontSize=" + _fontSize.ToString(CultureInfo.CurrentCulture);
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides the symbol to use when overlaying a point on an image.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class PointSymbol : IEquatable<PointSymbol>
    {
        private PointSymbolType _type;
        private bool[,] _userDefined;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the PointSymbol class.
        /// </summary>

        public PointSymbol()
            : this(PointSymbolType.Cross)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the PointSymbol class.
        /// </summary>
        /// <param name="type">
        /// The type of symbol to use.
        /// </param>

        public PointSymbol(PointSymbolType type)
        {
            _type = type;
            _userDefined = new bool[3, 3] { { false, true, false }, { true, true, true }, { false, true, false } };
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the type of symbol to use.
        /// </summary>
        /// <value>
        /// The default value is Cross.
        /// </value>

        public PointSymbolType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the user-defined array defining which pixels will be turned on.</summary>
        /// <returns>
        /// </returns>

        public bool[,] GetUserDefined()
        {
            return _userDefined;
        }
        //==========================================================================================
        /// <summary>
        /// Sets the user-defined array defining which pixels will be turned on.
        /// </summary>
        /// <param name="userDefined">
        /// </param>

        public void SetUserDefined(bool[,] userDefined)
        {
            if (userDefined == null) { throw new ArgumentNullException("userDefined"); }
            _userDefined = userDefined;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A PointSymbol instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(PointSymbol other)
        {
            return other != null && _type == other._type && Utilities.ArraysEqual(_userDefined, other._userDefined);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            PointSymbol other = (PointSymbol)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _type.GetHashCode() ^ _userDefined.GetLength(0).GetHashCode() ^ _userDefined.GetLength(1).GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "PointSymbol: Type=" + _type;
        }
    }
    //==============================================================================================
    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>

    public interface IRange
    {
        //==========================================================================================
        /// <summary>
        /// Gets or sets the minimum value of the range.
        /// </summary>
        /// <value>
        /// </value>

        double Minimum
        {
            get;
            set;
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the maximum value of the range.
        /// </summary>
        /// <value>
        /// </value>

        double Maximum
        {
            get;
            set;
        }
        //==========================================================================================
        /// <summary>
        /// Sets the minimum and maximum value of the range.
        /// </summary>
        /// <param name="minimum">
        /// The minimum value of the range.
        /// </param>
        /// <param name="maximum">
        /// The maximum value of the range.
        /// </param>

        void Initialize(double minimum, double maximum);
    }

    //==============================================================================================
    /// <summary>
    /// Represents a range of values.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class Range : IEquatable<Range>, IRange
    {
        internal double _min;
        internal double _max;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the lower bound of the range.
        /// </summary>
        /// <value>
        /// The lower bound of the range.
        /// The default value is 0.
        /// </value>

        public double Minimum
        {
            get { return _min; }
            set {
                if (_min == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _min = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the upper bound of the range.
        /// </summary>
        /// <value>
        /// The upper bound of the range.
        /// The default value is 0.
        /// </value>

        public double Maximum
        {
            get { return _max; }
            set {
                if (_max == value) return;
                CancelEventArgs args = new CancelEventArgs();
                OnPropertyChanging(args);
                if (args.Cancel) return;
                _max = value;
                OnPropertyChanged(EventArgs.Empty);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Sets the upper and lower bound of the range.</summary>
        /// <param name="minimum">The lower bound of the range.
        /// </param>
        /// <param name="maximum">
        ///  The upper bound of the range.</param>

        public void Initialize(double minimum, double maximum)
        {
            if (_min == minimum && _max == maximum) return;
            CancelEventArgs args = new CancelEventArgs();
            OnPropertyChanging(args);
            if (args.Cancel) return;
            _min = minimum;
            _max = maximum;
            OnPropertyChanged(EventArgs.Empty);
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Range" crefType="Unqualified"/> class. 
        /// </summary>

        public Range() : this ((double)0, (double)0) {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Range" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.Range.Minimum" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.Range.Maximum" crefType="Unqualified"/>. 
        /// </summary>
        /// <param name="minimum">
        /// The lower bound of the range.
        /// </param>
        /// <param name="maximum">
        /// The upper bound of the range.
        /// </param>

        public Range(double minimum, double maximum)
        {
            this._min = minimum;
            this._max = maximum;
        }

internal event EventHandler<EventArgs> PropertyChanged;

        
        internal void OnPropertyChanged(EventArgs args) {
            EventHandler<EventArgs> handler = PropertyChanged;
            if (handler != null) {
                handler(this, args);
            }
        }

        
        internal event EventHandler<CancelEventArgs> PropertyChanging;

        
        internal void OnPropertyChanging(CancelEventArgs args) {
            EventHandler<CancelEventArgs> handler = PropertyChanging;
            if (handler != null) {
                handler(this, args);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A Range instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Range other)
        {
            return other != null && Minimum == other.Minimum && Maximum == other.Maximum;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Range other = (Range)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return Minimum.GetHashCode() ^ Maximum.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Range: Minimum=" + _min + ", Maximum=" + _max;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a range of values that cannot be modified.</summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class ReadOnlyRange : IRange
    {
        //==========================================================================================
        /// <summary>
        /// </summary>

        public const string ReadOnlyMemberExceptionMessage = "Member is read-only";
        //==========================================================================================
        /// <summary>
        /// </summary>

        public const string ReadOnlyObjectExceptionMessage = "Object is read-only";
        double _min;
        double _max;

        
        internal ReadOnlyRange() : this(0, 0)
        {
        }

internal ReadOnlyRange(double minimum, double maximum)
        {
            _min = minimum;
            _max = maximum;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the lower bound of the range.
        /// </summary>
        /// <value>
        /// The lower bound of the range.
        /// </value>
        /// <remarks>
        /// This property will throw a NotSupportedException if the set method is called.
        /// </remarks>

        double IRange.Minimum
        {
            get { return _min; }
            set { throw new NotSupportedException(ReadOnlyMemberExceptionMessage); }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the lower bound of the range.
        /// </summary>
        /// <value>
        /// The lower bound of the range.
        /// </value>

        public double Minimum {
            get { return _min; }
            internal set { _min = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the upper bound of the range.
        /// </summary>
        /// <value>
        /// The upper bound of the range.
        /// </value>
        /// <remarks>
        ///  This property will throw a NotSupportedException if the set method is called.
        /// </remarks>

        double IRange.Maximum
        {
            get { return _max; }
            set { throw new NotSupportedException(ReadOnlyMemberExceptionMessage); }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the upper bound of the range.
        /// </summary>
        /// <value>
        /// The upper bound of the range.
        /// </value>

        public double Maximum {
            get { return _max; }
            internal set { _max = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Sets the upper and lower bound of the range.
        /// </summary>
        /// <param name="minimum">
        /// The lower bound of the range.
        /// </param>
        /// <param name="maximum">
        /// The upper bound of the range.
        /// </param>
        /// <remarks>
        /// This property will throw a NotSupportedException if it is called.
        /// </remarks>

        void IRange.Initialize(double minimum, double maximum)
        {
            throw new NotSupportedException(ReadOnlyObjectExceptionMessage);
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ReadOnlyRange: Minimum=" + _min + ", Maximum=" + _max;
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides properties used by <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> to learn the calibration template.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class LearnCalibrationOptions : IEquatable<LearnCalibrationOptions>
    {
        private CalibrationMethod _calibrationMethod;
        private ScalingMethod _correctionScalingMethod;
        private CoordinateSystem _axisInfo;
        private CalibrationCorrectionMode _correctionMode;
        private bool _learnCorrectionTable;
        private bool _learnErrorMap;

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the control calculates and stores an error map during the learning process. 
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        /// <remarks>
        /// The image error map reflects error bounds on the calibration transformation. 
        /// </remarks>

        public bool LearnErrorMap
        {
            get { return _learnErrorMap; }
            set { _learnErrorMap = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the correction table is determined and stored. 
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>
        /// <remarks>
        /// The correction table accelerates the process of correcting an image. Use the correction table if you want to correct several images.
        /// </remarks>

        public bool LearnCorrectionTable
        {
            get { return _learnCorrectionTable; }
            set { _learnCorrectionTable = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the regions to be used when correcting an image.
        /// </summary>
        /// <value>
        /// The regions to be used when correcting an image.
        /// The default value is <see cref="NationalInstruments.Vision.CalibrationCorrectionMode.UserRoi" crefType="Unqualified"/>.</value>

        public CalibrationCorrectionMode CorrectionMode
        {
            get { return _correctionMode; }
            set { _correctionMode = value; }
        }
        
        //==========================================================================================
        /// <summary>
        /// Gets or sets the reference coordinate system for the real-world coordinates.
        /// </summary>
        /// <value>
        /// The coordinate system includes an origin, angle, and axis orientation. The default origin value is (0,0), the default angle value is 0,
        /// and the default axis orientation value is <see cref="NationalInstruments.Vision.AxisOrientation.Indirect" crefType="Unqualified"/>.
        /// </value>

        public CoordinateSystem AxisInfo
        {
            get { return _axisInfo; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _axisInfo = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the aspect scaling to be used in the corrected image.
        /// </summary>
        /// <value>
        /// The aspect scaling to be used in the corrected image.
        /// The default value is <see cref="NationalInstruments.Vision.ScalingMethod.ScaleToPreserveArea" crefType="Unqualified"/>.
        /// </value>

        public ScalingMethod CorrectionScalingMethod
        {
            get { return _correctionScalingMethod; }
            set { _correctionScalingMethod = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the type of algorithm you want to use to calibrate your imaging setup.
        /// </summary>
        /// <value>
        /// The type of algorithm used to calibrate imaging setup.
        /// The default value is <see cref="NationalInstruments.Vision.CalibrationMethod.Perspective" crefType="Unqualified"/>.</value>

        public CalibrationMethod CalibrationMethod
        {
            get { return _calibrationMethod; }
            set { _calibrationMethod = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> class.
        /// </summary>

        public LearnCalibrationOptions()
            : this(new CoordinateSystem())
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.LearnCalibrationOptions.AxisInfo" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="axisInfo">
        /// Reference coordinate system for the real-world coordinates.
        /// </param>

        public LearnCalibrationOptions(CoordinateSystem axisInfo)
            : this(axisInfo, CalibrationMethod.Perspective)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.LearnCalibrationOptions.AxisInfo" crefType="Unqualified"/> and mode.
        /// </summary>
        /// <param name="axisInfo">
        /// Reference coordinate system for the real-world coordinates.
        /// </param>
        /// <param name="mode">
        /// Type of algorithm to calibrate the image.
        /// </param>

        public LearnCalibrationOptions(CoordinateSystem axisInfo, CalibrationMethod mode)
            : this(axisInfo, mode, ScalingMethod.ScaleToPreserveArea)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.LearnCalibrationOptions.AxisInfo" crefType="Unqualified"/>, mode, and <see cref="NationalInstruments.Vision.LearnCalibrationOptions.CorrectionScalingMethod" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="axisInfo">
        /// Reference coordinate system for the real-world coordinates.
        /// </param>
        /// <param name="mode">
        /// Type of algorithm to calibrate the image.
        /// </param>
        /// <param name="correctionScalingMethod">
        /// The aspect scaling to be used in the corrected image.
        /// </param>

        public LearnCalibrationOptions(CoordinateSystem axisInfo, CalibrationMethod mode, ScalingMethod correctionScalingMethod)
            : this(axisInfo, mode, correctionScalingMethod, CalibrationCorrectionMode.UserRoi)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.LearnCalibrationOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.LearnCalibrationOptions.AxisInfo" crefType="Unqualified"/>, mode, <see cref="NationalInstruments.Vision.LearnCalibrationOptions.CorrectionScalingMethod" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.LearnCalibrationOptions.CorrectionMode" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="axisInfo">
        /// Reference coordinate system for the real-world coordinates.
        /// </param>
        /// <param name="mode">
        /// Type of algorithm to calibrate the image.
        /// </param>
        /// <param name="correctionScalingMethod">
        /// The aspect scaling to be used in the corrected image.
        /// </param>
        /// <param name="correctionMode">
        /// The regions to be used when correcting an image.
        /// </param>

        public LearnCalibrationOptions(CoordinateSystem axisInfo, CalibrationMethod mode, ScalingMethod correctionScalingMethod, CalibrationCorrectionMode correctionMode)
        {
            _axisInfo = axisInfo;
            _calibrationMethod = mode;
            _correctionScalingMethod = correctionScalingMethod;
            _correctionMode = correctionMode;
            _learnCorrectionTable = false;
            _learnErrorMap = false;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A LearnCalibrationOptions instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(LearnCalibrationOptions other)
        {
            return other != null && _calibrationMethod == other._calibrationMethod && _correctionScalingMethod == other._correctionScalingMethod && Object.Equals(_axisInfo, other._axisInfo) && _correctionMode == other._correctionMode && _learnCorrectionTable == other._learnCorrectionTable && _learnErrorMap == other._learnErrorMap;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            LearnCalibrationOptions other = (LearnCalibrationOptions)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _calibrationMethod.GetHashCode() ^ _correctionScalingMethod.GetHashCode() ^ _axisInfo.GetHashCode() ^ _correctionMode.GetHashCode() ^ _learnCorrectionTable.GetHashCode() ^ _learnErrorMap.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "LearnCalibrationOptions: AxisInfo=" + _axisInfo.ToString() + ", CalibrationMethod=" + _calibrationMethod.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides information about the calibration grid image used by the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.LearnCalibrationGrid</format> class.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CalibrationGridOptions : IEquatable<CalibrationGridOptions>
    {
        private GridDescriptor _gridDescriptor;
        private Range _thresholdRange;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the threshold range used to detect the circles in the grid image. 
        /// </summary>
        /// <value>
        /// An ordered pair of the minimum and maximum value of the threshold range.
        /// The default minimum value is 0, and the default maximum value is 128.
        /// </value>
        /// <remarks>
        /// The minimum and maximum values must be between 0 and 255.
        /// </remarks>

        public Range ThresholdRange
        {
            get { return _thresholdRange; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _thresholdRange = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the scaling constants for an image.
        /// </summary>
        /// <value>
        /// The default value for XStep is 1, the default value for YStep is 1, and the default value of Unit is undefined.
        /// </value>
        /// <remarks>
        /// XStep is the distance in the x direction between two adjacent pixels in units specified by <see cref="NationalInstruments.Vision.CalibrationUnit" crefType="Unqualified"/>.
        /// YStep is the distance in the y direction between two adjacent pixels in units specified by <see cref="NationalInstruments.Vision.CalibrationUnit" crefType="Unqualified"/>.
        /// Unit is the unit of measure for the image.
        /// </remarks>

        public GridDescriptor GridDescriptor
        {
            get { return _gridDescriptor; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _gridDescriptor = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CalibrationGridOptions" crefType="Unqualified"/> class.
        /// </summary>

        public CalibrationGridOptions()
            : this(new GridDescriptor())
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CalibrationGridOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.CalibrationGridOptions.GridDescriptor" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="gridDescriptor">
        /// The scaling constants for an image.
        /// </param>

        public CalibrationGridOptions(GridDescriptor gridDescriptor)
            : this(gridDescriptor, new Range(0.0, 128.0))
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CalibrationGridOptions" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.CalibrationGridOptions.GridDescriptor" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.CalibrationGridOptions.ThresholdRange" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="gridDescriptor">
        /// The scaling constants for an image.
        /// </param>
        /// <param name="thresholdRange">
        /// Threshold range used to detect the circles in the grid image. The minimum and maximum values must be between 0 and 255.
        /// </param>

        public CalibrationGridOptions(GridDescriptor gridDescriptor, Range thresholdRange)
        {
            _gridDescriptor = gridDescriptor;
            _thresholdRange = thresholdRange;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A CalibrationGridOptions instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(CalibrationGridOptions other)
        {
            return other != null && Object.Equals(_gridDescriptor, other._gridDescriptor) && Object.Equals(_thresholdRange, other._thresholdRange);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CalibrationGridOptions other = (CalibrationGridOptions)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _gridDescriptor.GetHashCode() ^ _thresholdRange.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CalibrationGridOptions: GridDescriptor=" + _gridDescriptor.ToString() + ", ThresholdRange=" + _thresholdRange.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Provides information about a grid image that is used to learn the calibration.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class GridDescriptor : IEquatable<GridDescriptor>
    {
        private double _xStep;
        private double _yStep;
        private CalibrationUnit _unit;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the units of <see cref="NationalInstruments.Vision.GridDescriptor.XStep" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.GridDescriptor.YStep" crefType="Unqualified"/>.
        /// </summary>
        /// <value>
        /// The units of <see cref="NationalInstruments.Vision.GridDescriptor.XStep" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.GridDescriptor.YStep" crefType="Unqualified"/>.
        /// The default value is undefined.
        /// </value>

        public CalibrationUnit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Real-world distance between circle centers in the x-direction.
        /// </summary>
        /// <value>
        /// Distance between circle centers in the x-direction.
        /// The default value is 1.
        /// </value>

        public double XStep
        {
            get { return _xStep; }
            set { _xStep = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Real-world distance between circle centers in the y-direction. 
        /// </summary>
        /// <value>
        /// Distance between circle centers in the y-direction. 
        /// The default value is 1.
        /// </value>

        public double YStep
        {
            get { return _yStep; }
            set { _yStep = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.GridDescriptor" crefType="Unqualified"/> class.
        /// </summary>

        public GridDescriptor()
            : this(1.0, 1.0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.GridDescriptor" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.GridDescriptor.XStep" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.GridDescriptor.YStep" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="xStep">
        /// Real-world distance between circle centers in the x-direction.
        /// </param>
        /// <param name="yStep">
        /// Real-world distance between circle centers in the y-direction. 
        /// </param>

        public GridDescriptor(double xStep, double yStep)
            : this(xStep, yStep, CalibrationUnit.Undefined)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.GridDescriptor" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.GridDescriptor.XStep" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.GridDescriptor.YStep" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.GridDescriptor.Unit" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="xStep">
        /// Real-world distance between circle centers in the x-direction.
        /// </param>
        /// <param name="yStep">
        /// Real-world distance between circle centers in the y-direction. 
        /// </param>
        /// <param name="unit">
        /// Units of <paramref name="xStep"/> and <paramref name="yStep"/>.
        /// </param>

        public GridDescriptor(double xStep, double yStep, CalibrationUnit unit)
        {
            _xStep = xStep;
            _yStep = yStep;
            _unit = unit;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A GridDescriptor instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(GridDescriptor other)
        {
            return other != null && _xStep == other._xStep && _yStep == other._yStep && _unit == other._unit;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            GridDescriptor other = (GridDescriptor)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _xStep.GetHashCode() ^ _yStep.GetHashCode() ^ _unit.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "GridDescriptor: XStep=" + _xStep.ToString(CultureInfo.CurrentCulture) + ", YStep=" + _yStep.ToString(CultureInfo.CurrentCulture) + ", Unit=" + _unit.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defines the text style.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class TextDecoration : IEquatable<TextDecoration>
    {
        private bool _bold;
        private bool _italic;
        private bool _underline;
        private bool _strikeout;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the text style as strikeout.
        /// </summary>
        /// <value>
        /// The text style is strikeout.
        /// The default value is <see langword="false"/>.
        /// </value>

        public bool Strikeout
        {
            get { return _strikeout; }
            set { _strikeout = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the text style as underline.
        /// </summary>
        /// <value>
        /// The text style is underline.
        /// The default value is <see langword="false"/>.
        /// </value>

        public bool Underline
        {
            get { return _underline; }
            set { _underline = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the text style as italic.
        /// </summary>
        /// <value>
        /// The text style is italic.
        /// The default value is <see langword="false"/>.
        /// </value>

        public bool Italic
        {
            get { return _italic; }
            set { _italic = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the text style as bold.
        /// </summary>
        /// <value>
        /// The text style is bold.
        /// The default value is <see langword="false"/>.
        /// </value>

        public bool Bold
        {
            get { return _bold; }
            set { _bold = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.TextDecoration" crefType="Unqualified"/> class. 
        /// </summary>

        public TextDecoration()
        {
            _bold = false;
            _italic = false;
            _underline = false;
            _strikeout = false;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance.</summary>
        /// <param name="other">
        /// A TextDecoration instance to compare to this instance.
        /// </param>
        /// <returns>
        /// </returns>

        public bool Equals(TextDecoration other)
        {
            return other != null && _bold == other._bold && _italic == other._italic && _underline == other._underline && _strikeout == other._strikeout;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            TextDecoration other = (TextDecoration)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _bold.GetHashCode() ^ _italic.GetHashCode() ^ _underline.GetHashCode() ^ _strikeout.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "TextDecoration: Bold=" + _bold.ToString() + ", Italic=" + _italic.ToString() + ", Underline=" + _underline.ToString() + ", Strikeout=" + _strikeout.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Represents a reference for any arbitrary coordinate system with respect to the image plane.
    /// </summary>
    /// <remarks>
    /// The reference of the coordinate system is specified as the position of the origin of the coordinate system, the orientation of its x-axis with respect to that of the image plane, and the direction of the axis.
    /// </remarks>

    [Serializable]
    public sealed class CoordinateSystem : IEquatable<CoordinateSystem>
    {
        private PointContour _origin;
        private double _angle;
        private AxisOrientation _axisOrientation;

        //==========================================================================================
        /// <summary>
        /// Gets or sets the direction of the coordinate system. 
        /// </summary>
        /// <value>
        /// 	<see cref="NationalInstruments.Vision.CoordinateSystem.AxisOrientation" crefType="Unqualified"/> can be <see cref="NationalInstruments.Vision.AxisOrientation.Direct" crefType="Unqualified"/> or <see cref="NationalInstruments.Vision.AxisOrientation.Indirect" crefType="Unqualified"/>. The default value is <see cref="NationalInstruments.Vision.AxisOrientation.Indirect" crefType="Unqualified"/>.
        /// </value>

        public AxisOrientation AxisOrientation
        {
            get { return _axisOrientation; }
            set { _axisOrientation = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the angle, in degrees, of the x-axis of the coordinate system relative to the x-axis of an image.
        /// </summary>
        /// <value>
        /// The angle, in degrees, of the x-axis of the coordinate system relative to the x-axis of an image.
        /// The default value is 0.
        /// </value>

        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }
        //==========================================================================================
        /// <summary>
        /// The origin of the coordinate system.
        /// </summary>
        /// <value>
        /// The origin of the coordinate system.
        /// The default value is (0,0).
        /// </value>

        public PointContour Origin
        {
            get { return _origin; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _origin = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CoordinateSystem" crefType="Unqualified"/> class.
        /// </summary>

        public CoordinateSystem()
            : this(new PointContour(0, 0))
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CoordinateSystem" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="origin">
        /// The origin of the coordinate system.
        /// </param>

        public CoordinateSystem(PointContour origin)
            : this(origin, 0.0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CoordinateSystem" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.CoordinateSystem.Origin" crefType="Unqualified"/> and <see cref="NationalInstruments.Vision.CoordinateSystem.Angle" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="origin">
        /// The origin of the coordinate system.
        /// </param>
        /// <param name="angle">
        /// The angle, in degrees, of the x-axis of the coordinate system relative to the x-axis of an image.
        /// </param>

        public CoordinateSystem(PointContour origin, double angle)
            : this(origin, angle, AxisOrientation.Indirect)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CoordinateSystem" crefType="Unqualified"/> class with the specified <see cref="NationalInstruments.Vision.CoordinateSystem.Origin" crefType="Unqualified"/>, <see cref="NationalInstruments.Vision.CoordinateSystem.Angle" crefType="Unqualified"/>, and <see cref="NationalInstruments.Vision.CoordinateSystem.AxisOrientation" crefType="Unqualified"/>.
        /// </summary>
        /// <param name="origin">
        /// The origin of the coordinate system.
        /// </param>
        /// <param name="angle">
        /// The angle, in degrees, of the x-axis of the coordinate system relative to the x-axis of an image.
        /// </param>
        /// <param name="axisOrientation">
        /// The direction of the coordinate system. 
        /// </param>

        public CoordinateSystem(PointContour origin, double angle, AxisOrientation axisOrientation)
        {
            if (origin == null) { throw new ArgumentNullException("origin"); }
            _origin = new PointContour(origin.X, origin.Y);
            _angle = angle;
            _axisOrientation = axisOrientation;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A CoordinateSystem instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(CoordinateSystem other)
        {
            return other != null && Object.Equals(_origin, other._origin) && _angle == other._angle && _axisOrientation == other._axisOrientation;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CoordinateSystem other = (CoordinateSystem)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _origin.GetHashCode() ^ _angle.GetHashCode() ^ _axisOrientation.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CoordinateSystem: Origin=" + _origin.ToString() + ", Angle=" + _angle.ToString(CultureInfo.CurrentCulture) + ", AxisOrientation=" + _axisOrientation.ToString();
        }
    }
    //==============================================================================================
    /// <summary>
    /// Defnes a color in the HSV (Hue, Saturation, and Value) color space.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Hsv32Value : IEquatable<Hsv32Value>
    {
        private byte _v;
        private byte _s;
        private byte _h;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the Hsv32Value class.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="value">
        /// </param>

        public Hsv32Value(byte hue, byte saturation, byte value)
            : this(hue, saturation, value, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the Hsv32Value class.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="value">
        /// </param>
        /// <param name="alpha">
        /// </param>

        public Hsv32Value(byte hue, byte saturation, byte value, byte alpha)
        {
            _v = value;
            _s = saturation;
            _h = hue;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <value>
        /// </value>

        public byte Value
        {
            get { return _v; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color saturation.
        /// </summary>
        /// <value>
        /// </value>

        public byte Saturation
        {
            get { return _s; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color hue.
        /// </summary>
        /// <value>
        /// </value>

        public byte Hue
        {
            get { return _h; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Hsv32Value other)
        {
            return Hue == other.Hue && Saturation == other.Saturation && Value == other.Value && Alpha == other.Alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Hsv32Value other = (Hsv32Value)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are equal.</returns>

        public static bool operator ==(Hsv32Value val1, Hsv32Value val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(Hsv32Value val1, Hsv32Value val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <returns>
        /// </returns>

        public override int GetHashCode()
        {
            return _h.GetHashCode() ^ _s.GetHashCode() ^ _v.GetHashCode() ^ _alpha.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Hsv32Value: (" + _h + ", " + _s + ", " + _v + ")";
        }
    }
    
    //==============================================================================================
    /// <summary>
    /// Defines a color in the HSI (Hue, Saturation, and Intensity) color space.</summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct Hsi32Value : IEquatable<Hsi32Value>
    {
        private byte _i;
        private byte _s;
        private byte _h;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Hsi32Value" crefType="Unqualified"/> structure.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="intensity">
        /// </param>

        public Hsi32Value(byte hue, byte saturation, byte intensity)
            : this(hue, saturation, intensity, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.Hsi32Value" crefType="Unqualified"/> structure.
        /// </summary>
        /// <param name="hue">
        /// </param>
        /// <param name="saturation">
        /// </param>
        /// <param name="intensity">
        /// </param>
        /// <param name="alpha">
        /// </param>

        public Hsi32Value(byte hue, byte saturation, byte intensity, byte alpha)
        {
            _i = intensity;
            _s = saturation;
            _h = hue;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color intensity.
        /// </summary>
        /// <value>
        /// </value>

        public byte Intensity
        {
            get { return _i; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color saturation. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Saturation
        {
            get { return _s; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color hue. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Hue
        {
            get { return _h; }
        }

        //==========================================================================================
        /// <summary>
        /// The alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An Hsi32Value instance to compare to this instance.</param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(Hsi32Value other)
        {
            return Hue == other.Hue && Saturation == other.Saturation && Intensity == other.Intensity && Alpha == other.Alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Hsi32Value other = (Hsi32Value)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.</param>
        /// <returns>
        /// Whether the two values are equal.
        /// </returns>

        public static bool operator ==(Hsi32Value val1, Hsi32Value val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// Whether the two values are not equal.
        /// </returns>

        public static bool operator !=(Hsi32Value val1, Hsi32Value val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _h.GetHashCode() ^ _s.GetHashCode() ^ _i.GetHashCode() ^ _alpha.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "Hsi32Value: (" + _h + ", " + _s + ", " + _i + ")";
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a color in the CIE L*a*b* color space.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct CieLabValue : IEquatable<CieLabValue>
    {
        private double _b;
        private double _a;
        private double _l;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CieLabValue" crefType="Unqualified"/> structure. 
        /// </summary>
        /// <param name="l">
        /// The color lightness.
        /// </param>
        /// <param name="a">
        /// The red/green information of the color.
        /// </param>
        /// <param name="b">
        /// The yellow/blue information of the color.
        /// </param>

        public CieLabValue(double l, double a, double b)
            : this(l, a, b, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="l">
        /// The color lightness.
        /// </param>
        /// <param name="a">
        /// The red/green information of the color.
        /// </param>
        /// <param name="b">
        /// The yellow/blue information of the color.
        /// </param>
        /// <param name="alpha">
        /// The alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </param>

        public CieLabValue(double l, double a, double b, byte alpha)
        {
            _b = b;
            _a = a;
            _l = l;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the yellow/blue information of the color.
        /// </summary>
        /// <value>
        /// </value>

        public double B
        {
            get { return _b; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the red/green information of the color.
        /// </summary>
        /// <value>
        /// </value>

        public double A
        {
            get { return _a; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color lightness.
        /// </summary>
        /// <value>
        /// </value>

        public double L
        {
            get { return _l; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A CieLabValue instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(CieLabValue other)
        {
            return L == other.L && A == other.A && B == other.B && Alpha == other.Alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CieLabValue other = (CieLabValue)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator ==(CieLabValue val1, CieLabValue val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are not equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator !=(CieLabValue val1, CieLabValue val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _l.GetHashCode() ^ _a.GetHashCode() ^ _b.GetHashCode() ^ _alpha.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CieLabValue: (" + _l + ", " + _a + ", " + _b + ")";
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a color in the CIE XYZ color space.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct CieXyzValue : IEquatable<CieXyzValue>
    {
        private double _z;
        private double _y;
        private double _x;
        private byte _alpha;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.CieXyzValue" crefType="Unqualified"/> structure. 
        /// </summary>
        /// <param name="x">
        /// The X color information.
        /// </param>
        /// <param name="y">
        /// The color luminance.
        /// </param>
        /// <param name="z">
        /// The Z color information.
        /// </param>

        public CieXyzValue(double x, double y, double z)
            : this(x, y, z, 0)
        {
        }
        //==========================================================================================
        /// <summary>
        /// </summary>
        /// <param name="x">
        /// The X color information.
        /// </param>
        /// <param name="y">
        /// The color luminance.
        /// </param>
        /// <param name="z">
        /// The Z color information.
        /// </param>
        /// <param name="alpha">
        /// The alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </param>

        public CieXyzValue(double x, double y, double z, byte alpha)
        {
            _z = z;
            _y = y;
            _x = x;
            _alpha = alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Gets the Z color information.
        /// </summary>
        /// <value>
        /// </value>

        public double Z
        {
            get { return _z; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the color luminance.
        /// </summary>
        /// <value>
        /// </value>

        public double Y
        {
            get { return _y; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the X color information.</summary>
        /// <value>
        /// </value>

        public double X
        {
            get { return _x; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the alpha value of the color, which represents extra information about a color image, such as gamma correction. 
        /// </summary>
        /// <value>
        /// </value>

        public byte Alpha
        {
            get { return _alpha; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A CieXyzValue instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(CieXyzValue other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && Alpha == other.Alpha;
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CieXyzValue other = (CieXyzValue)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator ==(CieXyzValue val1, CieXyzValue val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are not equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator !=(CieXyzValue val1, CieXyzValue val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object. 
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _x.GetHashCode() ^ _y.GetHashCode() ^ _z.GetHashCode() ^ _alpha.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "CieXyzValue: (" + _x + ", " + _y + ", " + _z + ")";
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a color value in one of several different formats.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public struct ColorValue : IEquatable<ColorValue>
    {
        private ColorMode _type;
        private Rgb32Value _rgb32;
        private Hsl32Value _hsl32;
        private Hsv32Value _hsv32;
        private Hsi32Value _hsi32;
        private CieLabValue _cieLab;
        private CieXyzValue _cieXyz;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(Rgb32Value value) : this()
        {
            _rgb32 = value;
            _type = ColorMode.Rgb;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(Hsl32Value value) : this()
        {
            _hsl32 = value;
            _type = ColorMode.Hsl;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(Hsv32Value value) : this()
        {
            _hsv32 = value;
            _type = ColorMode.Hsv;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(Hsi32Value value) : this()
        {
            _hsi32 = value;
            _type = ColorMode.Hsi;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(CieXyzValue value) : this()
        {
            _cieXyz = value;
            _type = ColorMode.CieXyz;
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ColorValue" crefType="Unqualified"/> class.
        /// </summary>
        /// <param name="value">The value this ColorValue will contain.
        /// </param>

        public ColorValue(CieLabValue value) : this() 
        {
            _cieLab = value;
            _type = ColorMode.CieLab;
        }

internal ColorValue(CVI_Color2 cviColor, ColorMode mode)
            : this()
        {
            _type = mode;
            switch (mode)
            {
                case ColorMode.Rgb:
                    _rgb32 = cviColor.Rgb;
                    break;
                case ColorMode.Hsl:
                    _hsl32 = cviColor.Hsl;
                    break;
                case ColorMode.Hsv:
                    _hsv32 = cviColor.Hsv;
                    break;
                case ColorMode.Hsi:
                    _hsi32 = cviColor.Hsi;
                    break;
                case ColorMode.CieXyz:
                    _cieXyz = cviColor.CieXyz;
                    break;
                case ColorMode.CieLab:
                    _cieLab = cviColor.CieLab;
                    break;
                default:
                    Debug.Fail("Unknown color mode!");
                    break;
            }
        }

private void CheckType(ColorMode requiredMode)
        {
            if (_type != requiredMode)
            {
                throw new VisionException(ErrorCode.InvalidColorMode);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets a color in the RGB color space.
        /// </summary>
        /// <value>
        /// </value>

        public Rgb32Value Rgb32
        {
            get { CheckType(ColorMode.Rgb); return _rgb32; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets a color in the HSL color space.
        /// </summary>
        /// <value>
        /// </value>

        public Hsl32Value Hsl32
        {
            get { CheckType(ColorMode.Hsl); return _hsl32; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets a color in the HSV color space.
        /// </summary>
        /// <value>
        /// </value>

        public Hsv32Value Hsv32
        {
            get { CheckType(ColorMode.Hsv); return _hsv32; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets a color in the HSI color space.
        /// </summary>
        /// <value>
        /// </value>

        public Hsi32Value Hsi32
        {
            get { CheckType(ColorMode.Hsi); return _hsi32; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets a color in the CIE XYZ color space.
        /// </summary>
        /// <value>
        /// </value>

        public CieXyzValue CieXyz
        {
            get { CheckType(ColorMode.CieXyz); return _cieXyz; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets a color in the CIE L*a*b* color space.</summary>
        /// <value>
        /// </value>

        public CieLabValue CieLab
        {
            get { CheckType(ColorMode.CieLab); return _cieLab; }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A ColorValue instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ColorValue other)
        {
            if (_type != other._type) return false;
            switch (_type)
            {
                case ColorMode.Rgb:
                    return this._rgb32 == other._rgb32;
                case ColorMode.Hsl:
                    return this._hsl32 == other._hsl32;
                case ColorMode.Hsv:
                    return this._hsv32 == other._hsv32;
                case ColorMode.Hsi:
                    return this._hsi32 == other._hsi32;
                case ColorMode.CieXyz:
                    return this._cieXyz == other._cieXyz;
                case ColorMode.CieLab:
                    return this._cieLab == other._cieLab;
                default:
                    Debug.Fail("Unknown color mode!");
                    return false;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ColorValue other = (ColorValue)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are equal.
        /// </summary>
        /// <param name="val1">
        ///  The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator ==(ColorValue val1, ColorValue val2)
        {
            return val1.Equals(val2);
        }
        //==========================================================================================
        /// <summary>
        /// Returns whether the two colors are not equal.
        /// </summary>
        /// <param name="val1">
        /// The first value to compare.
        /// </param>
        /// <param name="val2">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the two values are not equal; otherwise, <see langword="false"/>.
        /// </returns>

        public static bool operator !=(ColorValue val1, ColorValue val2)
        {
            return !(val1.Equals(val2));
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _type.GetHashCode() ^ _rgb32.GetHashCode() ^ _hsl32.GetHashCode() ^ _hsv32.GetHashCode() ^ _hsi32.GetHashCode() ^ _cieXyz.GetHashCode() ^ _cieLab.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            string toReturn = "ColorValue: ";
            switch (_type)
            {
                case ColorMode.Rgb:
                    return toReturn + this._rgb32;
                case ColorMode.Hsl:
                    return toReturn + this._hsl32;
                case ColorMode.Hsv:
                    return toReturn + this._hsv32;
                case ColorMode.Hsi:
                    return toReturn + this._hsi32;
                case ColorMode.CieLab:
                    return toReturn + this._cieLab;
                case ColorMode.CieXyz:
                    return toReturn + this._cieXyz;
                default:
                    Debug.Fail("Unknown image type!");
                    return toReturn;
            }
        }

internal ColorMode ColorMode {
            get { return _type; }
        }

internal CVI_Color2 CVI_Color2 {
            get
            {
                CVI_Color2 toReturn = new CVI_Color2();
                switch (_type)
                {
                    case ColorMode.Rgb:
                        toReturn.Rgb = Rgb32;
                        break;
                    case ColorMode.Hsl:
                        toReturn.Hsl = Hsl32;
                        break;
                    case ColorMode.Hsv:
                        toReturn.Hsv = Hsv32;
                        break;
                    case ColorMode.Hsi:
                        toReturn.Hsi = Hsi32;
                        break;
                    case ColorMode.CieLab:
                        toReturn.CieLab = CieLab;
                        break;
                    case ColorMode.CieXyz:
                        toReturn.CieXyz = CieXyz;
                        break;
                    default:
                        Debug.Fail("Unknown color mode: " + _type + "!");
                        break;
                }
                return toReturn;
            }
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides information regarding the contents of the file that was passed to the <format type="monospace">NationalInstruments.Vision.Analysis.Algorithms.GetFileInformation</format> class. 
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class FileInformation : IEquatable<FileInformation>
    {
        private Int32 _width;
        private Int32 _height;
        private ImageType _imageType;
        private GridDescriptor _calibrationGrid;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.FileInformation" crefType="Unqualified"/> class.
        /// </summary>

        public FileInformation()
        {
            _calibrationGrid = new GridDescriptor();
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the calibration grid stored in the file.
        /// </summary>
        /// <value>
        /// The default value for XStep is 1, for YStep is 1, and unit is undefined. 
        /// </value>

        public GridDescriptor CalibrationGrid
        {
            get { return _calibrationGrid; }
            set { if (value == null) { throw new ArgumentNullException("value"); } _calibrationGrid = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Type of image that best fits the pixel size defined in the header of the file.
        /// </summary>
        /// <value>
        /// Type of image.
        /// </value>

        public ImageType ImageType
        {
            get { return _imageType; }
            set { _imageType = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Vertical resolution, in pixels, of the image file.
        /// </summary>
        /// <value>
        /// Vertical resolution of the image file.
        /// </value>

        public Int32 Height
        {
            get { return _height; }
            set { _height = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Horizontal resolution, in pixels, of the image file.
        /// </summary>
        /// <value>
        /// Horizontal resolution of the image file.
        /// </value>

        public Int32 Width
        {
            get { return _width; }
            set { _width = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// A FileInformation instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(FileInformation other)
        {
            return other != null && _width == other._width && _height == other._height && _imageType == other._imageType && Object.Equals(_calibrationGrid, other._calibrationGrid);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            FileInformation other = (FileInformation)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _width.GetHashCode() ^ _height.GetHashCode() ^ _imageType.GetHashCode() ^ _calibrationGrid.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "FileInformation: Width=" + _width.ToString(CultureInfo.CurrentCulture) + ", Height=" + _height.ToString(CultureInfo.CurrentCulture) + ", ImageType=" + _imageType.ToString();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Represents a file selection dialog box that previews images and waits for the user to select an image file(s) or click <format type="bold">Cancel</format>.
    /// </summary>
    /// <remarks>
    /// </remarks>

    [Serializable]
    public sealed class ImagePreviewFileDialog
    {
        private string _fileName = "";
        private string[] _fileNames;
        private string _filter = "All files (*.*)|*.*||";
        private int _filterIndex = 1;
        private string _initialDirectory = "";
        private bool _multiselect = false;
        private string _title = "";
        private string _defaultExt = "";
        private bool _allowChangeDirectory = true;

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog" crefType="Unqualified"/> class. 
        /// </summary>

        public ImagePreviewFileDialog()
        {
            _fileNames = new string[] { };
        }

        //==========================================================================================
        /// <summary>
        /// Runs the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog" crefType="Unqualified"/> with a default owner.
        /// </summary>
        /// <returns>
        /// 	<see cref="System.Windows.Forms.DialogResult.OK" crefType="PartiallyQualified"/> if the user clicks OK in the dialog box; otherwise, <see cref="System.Windows.Forms.DialogResult.Cancel" crefType="PartiallyQualified"/>. 
        /// </returns>

        public System.Windows.Forms.DialogResult ShowDialog()
        {
            int flags = 0;
            if (!_allowChangeDirectory)
            {
                flags |= 0x8;  // OFN_NOCHANGEDIR
            }
            if (_multiselect)
            {
                flags |= 0x200;  // OFN_ALLOWMULTISELECT
            }
            // Make sure the filter ends with two pipe characters.
            if (_filter == null)
            {
                _filter = "";
            }
            while (!_filter.EndsWith("||", StringComparison.CurrentCulture)) {
                _filter = _filter + "|";
            }
            int cancelled;
            int numberOfPaths;
            Array1D returnPathArray;
            VisionDllCommon.Priv_InitArray1D(out returnPathArray);
            Array1D returnPathsArray;
            VisionDllCommon.Priv_InitArray1D(out returnPathsArray);
            try
            {

                Int32 result = VisionDllCommon.Priv_LoadImageDialog(_initialDirectory, _multiselect, _fileName, _defaultExt, _filter, _filterIndex, _title, flags, ref returnPathArray, ref returnPathsArray, out cancelled, out numberOfPaths);
                Utilities.ThrowError(result);
                if (cancelled == 0)
                {
                    byte[] returnPathBytes = Utilities.ConvertArray1DTo1DStructureArray<byte>(returnPathArray);
                    _fileName = Utilities.ConvertBytesToString(returnPathBytes);
                    byte[] returnPathsBytes = Utilities.ConvertArray1DTo1DStructureArray<byte>(returnPathsArray);
                    // We have to convert the string ourself here, since it's delimited by NULL's.
                    int nullIndex = Array.FindIndex(returnPathsBytes, delegate(byte b) { return b == 0; });
                    int lastNullIndex = -1;
                    Collection<string> returnPathsCollection = new Collection<string>();
                    while (nullIndex != -1 && nullIndex != lastNullIndex + 1) {
                        returnPathsCollection.Add(System.Text.Encoding.Default.GetString(returnPathsBytes, lastNullIndex + 1, nullIndex - (lastNullIndex + 1)));
                        lastNullIndex = nullIndex;
                        nullIndex = Array.FindIndex(returnPathsBytes, lastNullIndex + 1, delegate(byte b) { return b == 0; });
                    }
                    _fileNames = Utilities.ConvertCollectionToArray(returnPathsCollection);
                    return System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    return System.Windows.Forms.DialogResult.Cancel;
                }
            }
            finally
            {
                VisionDllCommon.Priv_DisposeArray1DBytes(ref returnPathArray);
                VisionDllCommon.Priv_DisposeArray1DBytes(ref returnPathsArray);
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the user can change the directory from within the dialog box.
        /// </summary>
        /// <value>
        /// The default value is <see langword="true"/>.
        /// </value>

        public bool AllowChangeDirectory
        {
            get { return _allowChangeDirectory; }
            set { _allowChangeDirectory = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the files to display.
        /// </summary>
        /// <value>
        /// The files to display.
        /// </value>
        /// <remarks>
        /// For example, value of <format type="monospace">*.bmp </format>displays all files with the <format type="monospace">.bmp </format>extension.
        /// </remarks>

        public string DefaultExt
        {
            get { return _defaultExt; }
            set { _defaultExt = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the title of the dialog box. 
        /// </summary>
        /// <value>
        /// The title of the dialog box. 
        /// </value>

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the user can select multiple image files.
        /// </summary>
        /// <value>
        /// The default value is <see langword="false"/>.
        /// </value>

        public bool Multiselect
        {
            get { return _multiselect; }
            set { _multiselect = value; }
        }

        //==========================================================================================
        /// <summary>
        /// The directory that the dialog box opens to.
        /// </summary>
        /// <value>
        /// </value>

        public string InitialDirectory
        {
            get { return _initialDirectory; }
            set { _initialDirectory = value; }
        }
        //==========================================================================================
        /// <summary>
        /// The default filter for the dialog box.
        /// </summary>
        /// <value>
        /// The default value is 1.
        /// </value>
        /// <remarks>
        /// This property specifies the default filter when you use the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog.Filter" crefType="Unqualified"/> property to specify filters for the dialog box.
        /// </remarks>

        public int FilterIndex
        {
            get { return _filterIndex; }
            set { _filterIndex = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the filters that display in the type listbox of a dialog box.
        /// </summary>
        /// <value>
        /// </value>
        /// <remarks>
        /// 	<para>Use the pipe ( | ) symbol (ASCII 124) to separate the description and filter values. Do not include spaces before or after the pipe symbol, because these spaces will be displayed with the description and filter values.
        /// The following code shows an example of a filter that enables the user to select bitmap files or JPEG files.</para>
        /// 	<code>
        /// Bitmaps (*.bmp)|*.bmp|JPEGs (*.jpg)|*.jpg</code>
        /// When you specify more than one filter for a dialog box, use the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog.FilterIndex" crefType="Unqualified"/> property to determine which filter is displayed as the default.
        /// </remarks>

        public string Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets the names of the image files chosen.
        /// </summary>
        /// <value>
        /// The names of the image files chosen.
        /// </value>
        /// <remarks>
        ///  This property is only populated if the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog.Multiselect" crefType="Unqualified"/> property is set to <see langword="true"/>.
        /// </remarks>

        public string[] FileNames
        {
            get { return _fileNames; }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets the name of the image file.
        /// </summary>
        /// <value>
        /// The name of the image file.
        /// </value>
        /// <remarks>
        ///  This property is only populated if the <see cref="NationalInstruments.Vision.ImagePreviewFileDialog.Multiselect" crefType="Unqualified"/> property is set to <see langword="false"/>.
        /// </remarks>

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified instance. 
        /// </summary>
        /// <param name="other">
        /// An ImagePreviewFileDialog instance to compare to this instance.
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the other parameter equals the value of this instance; otherwise, <see langword="false"/>. 
        /// </returns>

        public bool Equals(ImagePreviewFileDialog other)
        {
            return other != null && _fileName == other._fileName && Utilities.ArraysEqual(_fileNames, other._fileNames) && _filter == other._filter && _filterIndex == other._filterIndex && _initialDirectory == other._initialDirectory && _multiselect == other._multiselect && _title == other._title && _defaultExt == other._defaultExt && _allowChangeDirectory == other._allowChangeDirectory;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object. 
        /// </summary>
        /// <param name="obj">
        /// An object to compare with this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is a object that represents the same as the current; otherwise, <see langword="false"/>. 
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ImagePreviewFileDialog other = (ImagePreviewFileDialog)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for this object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>

        public override int GetHashCode()
        {
            return _fileName.GetHashCode() ^ _fileNames.Length.GetHashCode() ^ _filter.GetHashCode() ^ _filterIndex.GetHashCode() ^ _initialDirectory.GetHashCode() ^ _multiselect.GetHashCode() ^ _title.GetHashCode() ^ _defaultExt.GetHashCode() ^ _allowChangeDirectory.GetHashCode();
        }
        //==========================================================================================
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. 
        /// </summary>
        /// <returns>
        /// A string representation of the value of this instance. 
        /// </returns>

        public override string ToString()
        {
            return "ImagePreviewFileDialog: FileName=" + _fileName;
        }
    }
}