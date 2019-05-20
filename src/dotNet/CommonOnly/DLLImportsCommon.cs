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
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using NationalInstruments.Vision.WindowsForms;
using NationalInstruments.Vision.WindowsForms.Internal;
using System.Collections.Specialized;

namespace NationalInstruments.Vision.Internal
{
    internal enum CVI_SelectionMode
    {
        None = 0,
        Click = 1,
        Line = 2,
        Rectangle = 3,
        Oval = 4,
        Polygon = 5,
        Free = 6,
        Annulus = 7,
        Zoom = 8,
        Pan = 9,
        BrokenLine = 10,
        FreeLine = 11,
        RotatedRectangle = 12
    }

    internal enum CVI_ContourType
    {
        EmptyContour = 0,
        Point = 1,
        Line = 2,
        Rect = 3,
        Oval = 4,
        ClosedContour = 5,
        OpenContour = 6,
        Annulus = 7,
        RotatedRect = 8
    }
    internal enum CVI_ShapeMode
    {
        Rect = 1,
        Oval = 2
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
	internal struct CVI_RotatedRectangle : IHasExternalVersionIn<RotatedRectangleContour>, IHasExternalVersionOut<RotatedRectangleContour>
	{
		private Int32 _top;
		private Int32 _left;
		private Int32 _height;
		private Int32 _width;
        private double _angle;
	
		public CVI_RotatedRectangle(Int32 top, Int32 left, Int32 height, Int32 width, double angle) 
		{
			_top = top;
			_left = left;
			_height = height;
			_width = width;
            _angle = angle;
		}
        
        public void ConvertFromExternal(RotatedRectangleContour item)
        {
            _left = (int)Math.Round(item.Center.X - (item.Width / 2.0));
            _top = (int)Math.Round(item.Center.Y - (item.Height / 2.0));
            _height = (int)Math.Round(item.Height);
            _width = (int)Math.Round(item.Width);
            _angle = item.Angle;
        }

        public RotatedRectangleContour ConvertToExternal()
        {
            return new RotatedRectangleContour(new PointContour(_left + ((double)_width/ 2.0), _top + ((double)_height/ 2.0)), _width, _height, _angle);
        }
	}
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
	internal struct CVI_Annulus: IHasExternalVersionIn<AnnulusContour>, IHasExternalVersionOut<AnnulusContour>
	{
        private CVI_Point _center;
        private Int32 _innerRadius;
        private Int32 _outerRadius;
        private double _startAngle;
        private double _endAngle;
	
        public void ConvertFromExternal(AnnulusContour item)
        {
            _center = new CVI_Point();
            _center.ConvertFromExternal(item.Center);
            _innerRadius = (Int32)Math.Round(item.InnerRadius);
            _outerRadius = (Int32)Math.Round(item.OuterRadius);
            _startAngle = item.StartAngle;
            _endAngle = item.EndAngle;
        }

        public AnnulusContour ConvertToExternal()
        {
            return new AnnulusContour(_center.ConvertToExternal(), _innerRadius, _outerRadius, _startAngle, _endAngle);
        }
	}
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
	internal struct CVI_Rectangle : IHasExternalVersionIn<RectangleContour>, IHasExternalVersionIn<OvalContour>, IHasExternalVersionOut<RectangleContour>
	{
        private Int32 _top;
        private Int32 _left;
        private Int32 _height;
        private Int32 _width;

        public Int32 Top
        {
            get { return _top; }
        }

        public Int32 Left
        {
            get { return _left; }
        }

        public Int32 Height
        {
            get { return _height; }
        }

        public Int32 Width
        {
            get { return _width; }
        }
	
		public CVI_Rectangle(Int32 top, Int32 left, Int32 height, Int32 width) 
		{
			_top = top;
			_left = left;
			_height = height;
			_width = width;
		}

		public static readonly CVI_Rectangle NoRect = new CVI_Rectangle(0, 0, 0x7FFFFFFF, 0x7FFFFFFF);
        public void ConvertFromExternal(RectangleContour item)
        {
            _top = (Int32)Math.Round(item.Top);
            _left = (Int32)Math.Round(item.Left);
            _height = (Int32)Math.Round(item.Height);
            _width = (Int32)Math.Round(item.Width);
        }

        public RectangleContour ConvertToExternal()
        {
            return new RectangleContour(_left, _top, _width, _height);
        }

        public void ConvertFromExternal(OvalContour item)
        {
            _top = (Int32)Math.Round(item.Top);
            _left = (Int32)Math.Round(item.Left);
            _height = (Int32)Math.Round(item.Height);
            _width = (Int32)Math.Round(item.Width);
        }
	}
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Point : IHasExternalVersionOut<PointContour>, IHasExternalVersionIn<PointContour> {
        private Int32 _x;
        private Int32 _y;
        public Int32 X
        {
            get { return _x; }
        }
        public Int32 Y
        {
            get { return _y; }
        }

        public CVI_Point(Int32 x, Int32 y)
        {
            _x = x;
            _y = y;
        }
        public CVI_Point(PointContour point)
        {
            _x = (int)Math.Round(point.X);
            _y = (int)Math.Round(point.Y);
        }
        public PointContour ConvertToExternal()
        {
            return new PointContour(_x, _y);
        }
        public void ConvertFromExternal(PointContour point)
        {
            _x = (int)Math.Round(point.X);
            _y = (int)Math.Round(point.Y);
        }
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    public struct CVI_PointFloat : IHasExternalVersionOut<PointContour>, IHasExternalVersionIn<PointContour> {
        private float _x;
        private float _y;

        public CVI_PointFloat(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public float X
        {
            get { return _x; }
        }
        public float Y
        {
            get { return _y; }
        }

        public PointContour ConvertToExternal()
        {
            return new PointContour(_x, _y);
        }
        public void ConvertFromExternal(PointContour point)
        {
            _x = (float)point.X;
            _y = (float)point.Y;
        }
    }
    [EditorBrowsable(EditorBrowsableState.Never)]
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    public struct CVI_PointDouble : IHasExternalVersionOut<PointContour>, IHasExternalVersionIn<PointContour>
    {
        private double _x;
        private double _y;

        public CVI_PointDouble(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X
        {
            get { return _x; }
        }
        public double Y
        {
            get { return _y; }
        }

        public PointContour ConvertToExternal()
        {
            return new PointContour(_x, _y);
        }
        public void ConvertFromExternal(PointContour point)
        {
            _x = point.X;
            _y = point.Y;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Line : IHasExternalVersionOut<LineContour>
    {
        private CVI_Point _start;
        private CVI_Point _end;

        public LineContour ConvertToExternal()
        {
            return new LineContour(_start.ConvertToExternal(), _end.ConvertToExternal());
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    internal struct CVI_Color2
    {
        [FieldOffset(0)] private Rgb32Value _rgb;
        [FieldOffset(0)] private Hsl32Value _hsl;
        [FieldOffset(0)] private Hsv32Value _hsv;
        [FieldOffset(0)] private Hsi32Value _hsi;
        [FieldOffset(0)] private CieLabValue _cieLab;
        [FieldOffset(0)] private CieXyzValue _cieXyz;

        public CieXyzValue CieXyz
        {
            get { return _cieXyz; }
            set { _cieXyz = value; }
        }
        public CieLabValue CieLab
        {
            get { return _cieLab; }
            set { _cieLab = value; }
        }
        public Hsi32Value Hsi
        {
            get { return _hsi; }
            set { _hsi = value; }
        }
        public Hsv32Value Hsv
        {
            get { return _hsv; }
            set { _hsv = value; }
        }
        public Rgb32Value Rgb
        {
            get { return _rgb; }
            set { _rgb = value; }
        }
        public Hsl32Value Hsl
        {
            get { return _hsl; }
            set { _hsl = value; }
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    internal struct ContourUnion
    {
        [FieldOffset(0)] private unsafe CVI_Point* _point;
        [FieldOffset(0)] private unsafe CVI_Line* _line;
        [FieldOffset(0)] private unsafe CVI_Rectangle* _rect;
        [FieldOffset(0)] private unsafe CVI_Rectangle* _ovalBoundingBox;
        [FieldOffset(0)] private unsafe CVI_ClosedContour* _closedContour;
        [FieldOffset(0)] private unsafe CVI_OpenContour* _openContour;
        [FieldOffset(0)] private unsafe CVI_Annulus* _annulus;
        [FieldOffset(0)] private unsafe CVI_RotatedRectangle* _rotatedRect;

        internal unsafe CVI_RotatedRectangle* RotatedRect
        {
            get { return _rotatedRect; }
            set { _rotatedRect = value; }
        }

        internal unsafe CVI_Annulus* Annulus
        {
            get { return _annulus; }
            set { _annulus = value; }
        }

        internal unsafe CVI_OpenContour* OpenContour
        {
            get { return _openContour; }
            set { _openContour = value; }
        }

        internal unsafe CVI_ClosedContour* ClosedContour
        {
            get { return _closedContour; }
            set { _closedContour = value; }
        }

        internal unsafe CVI_Rectangle* OvalBoundingBox
        {
            get { return _ovalBoundingBox; }
            set { _ovalBoundingBox = value; }
        }

        internal unsafe CVI_Rectangle* Rect
        {
            get { return _rect; }
            set { _rect = value; }
        }
        internal unsafe CVI_Line* Line
        {
            get { return _line; }
            set { _line = value; }
        }
        internal unsafe CVI_Point* Point
        {
          get { return _point; }
          set { _point = value; }
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    internal struct CVI_PixValue : IHasExternalVersionIn<PixelValue>
    {
        [FieldOffset(0)] private float _grayscale;
        [FieldOffset(0)] private Rgb32Value _rgb;
        [FieldOffset(0)] private Hsl32Value _hsl;
        [FieldOffset(0)] private Complex _complex;
        [FieldOffset(0)] private RgbU64Value _rgbu64;
        [FieldOffset(0)] private int _color32;

        public float Grayscale
        {
            get { return _grayscale; }
            set { _grayscale = value; }
        }
        public Rgb32Value Rgb
        {
            get { return _rgb; }
            set { _rgb = value; }
        }
        public Hsl32Value Hsl
        {
            get { return _hsl; }
            set { _hsl = value; }
        }
        public Complex Complex
        {
            get { return _complex; }
            set { _complex = value; }
        }
        public RgbU64Value Rgbu64
        {
            get { return _rgbu64; }
            set { _rgbu64 = value; }
        }

        public void ConvertFromExternal(PixelValue value)
        {
            // This looks a bit questionable but seems to work fine.
            this = value.CVI_PixValue;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_MouseEventInfo
    {
        private int _flags;
        private System.Drawing.Point _point;

        public int Flags
        {
            get { return _flags; }
        }
        public System.Drawing.Point Point
        {
            get { return _point; }
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_PointData
    {
        private CVI_Point _point;
        private Int32 _index;

        public CVI_Point Point
        {
            get { return _point; }
        }
        public Int32 Index
        {
            get { return _index; }
        }
    }
    // This struct is not pack=1 on purpose.

#if (NIIM_OPSYS==NIIM_OPSYS_WIN32)
    [StructLayout(LayoutKind.Sequential,Pack=1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_KeyMessage
    {
        private int _message;
        private IntPtr _wParam;
        private IntPtr _lParam;

        public IntPtr WParam
        {
            get { return _wParam; }
        }
        public IntPtr LParam
        {
            get { return _lParam; }
        }
        public int Message
        {
            get { return _message; }
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct Array1D
    {
        // We will only use this to grab C structures, so ignore the LV-specific part of the union.
        private IntPtr _ptr;
        private UInt32 _count;
        private UInt64 _resizeInfo;

        public IntPtr Ptr
        {
            get { return _ptr; }
            set { _ptr = value; }
        }
        public UInt32 Count
        {
            get { return _count; }
            set { _count = value; }
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_ConversionPolicy : IHasExternalVersionIn<DisplayMapping>
    {
        private Int32 _conversionPolicy;
        private float _minVal;
        private float _maxVal;
        private Int32 _shift;

        public void ConvertFromExternal(DisplayMapping mapping)
        {
            _conversionPolicy = (Int32)mapping.Policy;
            _minVal = (float)mapping.Range.Minimum;
            _maxVal = (float)mapping.Range.Maximum;
            _shift = mapping.Shifts;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
	internal struct VB_Rectangle
	{
        private float _left;
        private float _top;
        private float _width;
        private float _height;

        public float Width
        {
            get { return _width; }
        }
        public float Height
        {
            get { return _height; }
        }
        public float Top
        {
            get { return _top; }
        }
        public float Left
        {
            get { return _left; }
        }
	
		public VB_Rectangle(float top, float left, float height, float width) 
		{
			_top = top;
			_left = left;
			_height = height;
			_width = width;
		}
	}
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_RotatedRectangle
    {
        private CVI_PointFloat _center;
        private float _width;
        private float _height;
        private float _angle;

        public VB_RotatedRectangle(CVI_PointFloat center, float width, float height, float angle)
        {
            _center = center;
            _width = width;
            _height = height;
            _angle = angle;
        }
    }
    // This structure is used to pass to functions that expect RGB values in RGB order.
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct Rgb32OrderedValue
    {
        private byte _r;
        private byte _g;
        private byte _b;
        private byte _alpha;

        public Rgb32OrderedValue(byte r, byte g, byte b)
        {
            _r = r;
            _g = g;
            _b = b;
            _alpha = 0;
        }
        public static implicit operator Rgb32OrderedValue(Rgb32Value val)
        {
            // All the functions that take Rgb32OrderedValue's dont respect the alpha
            // byte, and in fact it causes trouble, so don't set it here.
            return new Rgb32OrderedValue(val.Red, val.Green, val.Blue);
        }
    }

    // This structure is used to pass to functions that expect RGB values in alphaBGR order.
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct ColorRefValue
    {
        private byte _alpha;
        private byte _b;
        private byte _g;
        private byte _r;

        public ColorRefValue(byte r, byte g, byte b)
        {
            _r = r;
            _g = g;
            _b = b;
            _alpha = 0;
        }
        public static implicit operator ColorRefValue(Rgb32Value val)
        {
            // All the functions that take ColorRefValue's dont respect the alpha
            // byte, and in fact it causes trouble, so don't set it here.
            return new ColorRefValue(val.Red, val.Green, val.Blue);
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_JPEG2000FileAdvancedOptions : IHasExternalVersionIn<Jpeg2000AdvancedOptions>
    {
        private WaveletTransformMode _waveletTransformMode;
        private Int32 _useMultiComponentTransform;
        private UInt32 _maxWaveletTransformLevel;
        private float _quantizationStepSize;

        public void ConvertFromExternal(Jpeg2000AdvancedOptions options)
        {
            _waveletTransformMode = options.WaveletTransformMode;
            _useMultiComponentTransform = options.UseMultipleComponentTransform ? 1 : 0;
            _maxWaveletTransformLevel = options.MaximumWaveletTransformLevel;
            _quantizationStepSize = (float)options.QuantizationStepSize;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_TIFFFileOptions : IHasExternalVersionIn<TiffOptions>
    {
        private Int32 _rowsPerStrip;
        private PhotometricMode _photoInterp;
        private TiffCompressionType _compressionType;

        public void ConvertFromExternal(TiffOptions options)
        {
            _rowsPerStrip = options.RowsPerStrip;
            _photoInterp = options.PhotometricMode;
            _compressionType = options.CompressionType;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationInfo : IHasExternalVersionOut<CalibrationInfo>
    {
        private IntPtr _errorMap;
        private Int32 _mapColumns;
        private Int32 _mapRows;
        private IntPtr _userRoi;
        private IntPtr _calibrationRoi;
        private CVI_LearnCalibrationOptions _options;
        private CVI_GridDescriptor _grid;
        private CVI_CoordinateSystem _system;
        private CVI_RangeFloat _range;
        private float _quality;

        public CalibrationInfo ConvertToExternal()
        {
            CalibrationInfo info = new CalibrationInfo();
            info.LearnCalibrationOptions = _options.ConvertToExternal(_system);
            info.CalibrationGridOptions = new CalibrationGridOptions();
            info.CalibrationGridOptions.GridDescriptor = _grid.ConvertToExternal();
            info.CalibrationGridOptions.ThresholdRange = _range.ConvertToExternal();
            info.Quality = _quality;
			Int32 totalArraySize = _mapColumns * _mapRows;
            if (totalArraySize > 0)
            {
                info.ErrorMap = Utilities.ConvertIntPtrFlatTo2DArraySingle(_errorMap, _mapRows, _mapColumns, false);
            }
            else
            {
                info.ErrorMap = new float[0, 0];
            }
            info.UserRoi = new Roi(_userRoi);
            info.CalibrationRoi = new Roi(_calibrationRoi);
            return info;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClosedContour : IHasExternalVersionOut<PolygonContour>
    {
        private IntPtr _points;
        private Int32 _numPoints;
        public PolygonContour ConvertToExternal()
        {
            PolygonContour contour = new PolygonContour();
            Collection<PointContour> points = Utilities.ConvertIntPtrToCollection<PointContour, CVI_Point>(_points, _numPoints, false);
            foreach(PointContour point in points) {
                contour.Points.Add(point);
            }
            return contour;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_OpenContour : IHasExternalVersionOut<PolylineContour>
    {
        private IntPtr _points;
        private Int32 _numPoints;
        public PolylineContour ConvertToExternal()
        {
            PolylineContour contour = new PolylineContour();
            Collection<PointContour> points = Utilities.ConvertIntPtrToCollection<PointContour, CVI_Point>(_points, _numPoints, false);
            foreach(PointContour point in points) {
                contour.Points.Add(point);
            }
            return contour;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourInfo2 : IHasExternalVersionOut<Contour>
    {
        private CVI_ContourType  _type;
        private Rgb32Value _color;
        private ContourUnion _structure;

        public unsafe Contour ConvertToExternal()
        {
            Shape shape = null;
            switch (_type)
            {
                case CVI_ContourType.Point:
                    CVI_Point* pointData = _structure.Point;
                    shape = pointData->ConvertToExternal();
                    break;
                case CVI_ContourType.Line:
                    CVI_Line* lineData = _structure.Line;
                    shape = lineData->ConvertToExternal();
                    break;
                case CVI_ContourType.Rect:
                    CVI_Rectangle* rectData = _structure.Rect;
                    shape = rectData->ConvertToExternal();
                    break;
                case CVI_ContourType.Oval:
                    CVI_Rectangle* ovalData = _structure.OvalBoundingBox;
                    shape = new OvalContour(ovalData->Left, ovalData->Top, ovalData->Width, ovalData->Height);
                    break;
                case CVI_ContourType.ClosedContour:
                    CVI_ClosedContour* closedData = _structure.ClosedContour;
                    shape = closedData->ConvertToExternal();
                    break;
                case CVI_ContourType.OpenContour:
                    CVI_OpenContour* openData = _structure.OpenContour;
                    shape = openData->ConvertToExternal();
                    break;
                case CVI_ContourType.Annulus:
                    CVI_Annulus* annulusData = _structure.Annulus;
                    shape = annulusData->ConvertToExternal();
                    break;
                case CVI_ContourType.RotatedRect:
                    CVI_RotatedRectangle* rotatedRectData = _structure.RotatedRect;
                    shape = rotatedRectData->ConvertToExternal();
                    break;
                default:
                    Debug.Fail("Unknown contour type!");
                    break;
            }
            Debug.Assert(shape != null, "Got null shape in CVI_ContourInfo2.ConvertToExternal");
            Contour contour = new Contour(shape);
            contour.Color = _color;
            return contour;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnCalibrationOptions : IHasExternalVersionIn<LearnCalibrationOptions>, IHasExternalVersionOut<LearnCalibrationOptions, CVI_CoordinateSystem>
    {
        private Int32 _calibrationMode;
        private Int32 _scalingMethod;
        private Int32 _roi;
        private Int32 _learnMap;
        private Int32 _learnTable;

        public void ConvertFromExternal(LearnCalibrationOptions options)
        {
            _calibrationMode = (Int32)options.CalibrationMethod;
            _scalingMethod = (Int32)options.CorrectionScalingMethod;
            _roi = (Int32)options.CorrectionMode;
            _learnMap = options.LearnErrorMap ? 1 : 0;
            _learnTable = options.LearnCorrectionTable ? 1 : 0;
        }

        public LearnCalibrationOptions ConvertToExternal(CVI_CoordinateSystem auxiliary)
        {
            LearnCalibrationOptions options = new LearnCalibrationOptions();
            options.CalibrationMethod = (CalibrationMethod)_calibrationMode;
            options.CorrectionScalingMethod = (ScalingMethod)_scalingMethod;
            options.CorrectionMode = (CalibrationCorrectionMode)_roi;
            options.LearnErrorMap = (_learnMap != 0);
            options.LearnCorrectionTable = (_learnTable != 0);
            options.AxisInfo = auxiliary.ConvertToExternal();
            return options;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CoordinateSystem : IHasExternalVersionIn<CoordinateSystem>, IHasExternalVersionOut<CoordinateSystem>
    {
        private CVI_PointFloat _origin;
        private float _angle;
        private Int32 _axisOrientation;

        public void ConvertFromExternal(CoordinateSystem system)
        {
            _origin = new CVI_PointFloat((float)system.Origin.X, (float)system.Origin.Y);
            _angle = (float)system.Angle;
            _axisOrientation = (Int32)system.AxisOrientation;
        }
        public CoordinateSystem ConvertToExternal()
        {
            CoordinateSystem system = new CoordinateSystem();
            system.Origin.X = _origin.X;
            system.Origin.Y = _origin.Y;
            system.Angle = _angle;
            system.AxisOrientation = (AxisOrientation)_axisOrientation;
            return system;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GridDescriptor : IHasExternalVersionOut<GridDescriptor>, IHasExternalVersionIn<GridDescriptor>
    {
        private float _xStep;
        private float _yStep;
        private Int32 _unit;

        public GridDescriptor ConvertToExternal()
        {
            return new GridDescriptor(_xStep, _yStep, (CalibrationUnit)_unit);
        }

        public void ConvertFromExternal(GridDescriptor grid)
        {
            _xStep = (float)grid.XStep;
            _yStep = (float)grid.YStep;
            _unit = (Int32)grid.Unit;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RangeFloat : IHasExternalVersionOut<Range>, IHasExternalVersionIn<Range>
    {
        private float _minValue;
        private float _maxValue;
        public Range ConvertToExternal()
        {
            return new Range(_minValue, _maxValue);
        }

        public void ConvertFromExternal(Range range)
        {
            _minValue = (float)range.Minimum;
            _maxValue = (float)range.Maximum;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RangeDouble : IHasExternalVersionOut<Range>, IHasExternalVersionIn<Range>
    {
        private double _minValue;
        private double _maxValue;
        public Range ConvertToExternal()
        {
            return new Range(_minValue, _maxValue);
        }

        public void ConvertFromExternal(Range range)
        {
            _minValue = range.Minimum;
            _maxValue = range.Maximum;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Range : IHasExternalVersionOut<Range>, IHasExternalVersionIn<Range>
    {
        private Int32 _minValue;
        private Int32 _maxValue;
        public Range ConvertToExternal()
        {
            return new Range(_minValue, _maxValue);
        }

        public void ConvertFromExternal(Range range)
        {
            _minValue = (Int32)Math.Round(range.Minimum);
            _maxValue = (Int32)Math.Round(range.Maximum);
        }
    }
	[StructLayout(LayoutKind.Sequential)]
    internal struct CVI_TransformBehaviors : IHasExternalVersionIn<TransformBehaviors>, IHasExternalVersionOut<TransformBehaviors>
    {
        private Int32 _shiftBehavior;
        private Int32 _scaleBehavior;
        private Int32 _rotateBehavior;
        private Int32 _symmetryBehavior;

        public TransformBehaviors ConvertToExternal()
        {
            return new TransformBehaviors((GroupBehavior)_shiftBehavior, (GroupBehavior)_scaleBehavior, (GroupBehavior)_rotateBehavior, (GroupBehavior)_symmetryBehavior);
        }

        public void ConvertFromExternal(TransformBehaviors behaviors)
        {
            _shiftBehavior = (Int32)behaviors.Shift;
            _scaleBehavior = (Int32)behaviors.Scale;
            _rotateBehavior = (Int32)behaviors.Rotate;
            _symmetryBehavior = (Int32)behaviors.Symmetry;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ArcInfo : IHasExternalVersionIn<Arc>
    {
        private CVI_Rectangle _boundingBox;
        private double _startAngle;
        private double _endAngle;

        public void ConvertFromExternal(Arc arc)
        {
            _boundingBox = new CVI_Rectangle((Int32)Math.Round(arc.Center.Y - arc.Radius), (Int32)Math.Round(arc.Center.X - arc.Radius), (Int32)Math.Round(arc.Radius*2), (Int32)Math.Round(arc.Radius*2));
            _startAngle = arc.StartAngle;
            _endAngle = arc.EndAngle;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_UserPointSymbol : IHasExternalVersionIn<PointSymbol>, IDisposable
    {
        private Int32 _cols;
        private Int32 _rows;
        private IntPtr _pixels;

        public void ConvertFromExternal(PointSymbol symbol)
        {
            if (symbol.Type == PointSymbolType.UserDefined)
            {
                bool[,] symbolUserDefined = symbol.GetUserDefined();
                _cols = symbolUserDefined.GetLength(1);
                _rows = symbolUserDefined.GetLength(0);
                // Since symbol.UserDefined is a bool[,], convert to an int[,] first.
                int[,] userDefined = new int[_rows, _cols];
                for (int i = 0; i < _rows; ++i)
                {
                    for (int j = 0; j < _cols; ++j)
                    {
                        userDefined[i, j] = symbolUserDefined[i, j] ? 1 : 0;
                    }
                }
                _pixels = Utilities.Convert2DArrayToIntPtr(userDefined);
            }
        }
        #region IDisposable Members

        public void Dispose()
		{
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing) {
            // Since _pixels is unmanaged, it's OK to access it here (even though we may be
            // called during finalization if disposing == false)
			if (_pixels != IntPtr.Zero) 
			{
                Marshal.FreeCoTaskMem(_pixels);
                _pixels = IntPtr.Zero;
			}
		}
		#endregion
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_OverlayTextOptions : IHasExternalVersionIn<OverlayTextOptions>
    {
        private string _fontName;
        private Int32 _fontSize;
        private Int32 _bold;
        private Int32 _italic;
        private Int32 _underline;
        private Int32 _strikeout;
        private Int32 _horizontalTextAlignment;
        private Int32 _verticalTextAlignment;
        private Rgb32Value _backgroundColor;
        private double _angle;

        public void ConvertFromExternal(OverlayTextOptions options)
        {
            _fontName = options.FontName;
            _fontSize = options.FontSize;
            _bold = options.TextDecoration.Bold ? 1 : 0;
            _italic = options.TextDecoration.Italic ? 1 : 0;
            _underline = options.TextDecoration.Underline ? 1 : 0;
            _strikeout = options.TextDecoration.Strikeout ? 1 : 0;
            _horizontalTextAlignment = (int)options.HorizontalAlignment;
            _verticalTextAlignment = (int)options.VerticalAlignment;
            _backgroundColor = options.BackgroundColor;
            _angle = options.Angle;
        }
    }
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_AVIInfo : IHasExternalVersionOut<AviInputSession.AviInfo>
    {
        private UInt32 _width;
        private UInt32 _height;
        private Int32 _imageType;
        private UInt32 _numFrames;
        private UInt32 _framesPerSecond;
        private IntPtr _filterName;
        private Int32 _hasData;
        private UInt32 _maxDataSize;

        public AviInputSession.AviInfo ConvertToExternal()
        {
            AviInputSession.AviInfo info = new AviInputSession.AviInfo();
            info.Width = _width;
            info.Height = _height;
            info.ImageType = (ImageType)_imageType;
            info.NumFrames = _numFrames;
            info.FramesPerSecond = _framesPerSecond;
            info.FilterName = Marshal.PtrToStringAnsi(_filterName);
            // We need to dispose this here even though it's not documented, because of the way our AVI code works.
            VisionDllCommon.imaqDispose(_filterName);
            _filterName = IntPtr.Zero;
            info.HasData = _hasData != 0;
            info.MaxDataSize = _maxDataSize;
            return info;
        }
    }

    /// <summary>
    /// Contains the imports from the Vision DLL(s).
    /// </summary>
    [SuppressUnmanagedCodeSecurity()]
    internal static class VisionDllCommon
    {
        #region Vision imports
        [ DllImport("nivision.dll", EntryPoint="imaqCreateImage", CharSet=CharSet.Ansi, CallingConvention=CallingConvention.StdCall)]
		internal static extern IntPtr imaqCreateImage(Int32 type, Int32 border);
		[ DllImport("nivision.dll")]
		internal static extern Int32 imaqDispose(IntPtr obj);
		[ DllImport("nivision.dll")]
		internal static extern ErrorCode imaqGetLastError();
        [ DllImport("nivision.dll", EntryPoint="imaqGetErrorText")]
        private static extern IntPtr imaqGetErrorTextInternal(Int32 errorCode);
        internal static string imaqGetErrorText(Int32 errorCode)
        {
            IntPtr externalResult = imaqGetErrorTextInternal(errorCode);
            string toReturn = Marshal.PtrToStringAnsi(externalResult);
            imaqDispose(externalResult);
            return toReturn;
        }
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, byte[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, Int16[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, float[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, Complex[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, Rgb32Value[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, Hsl32Value[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
		internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, RgbU64Value[,] array, Int32 numCols, Int32 numRows);
		[ DllImport("nivision.dll")]
        internal unsafe static extern Int32 imaqArrayToImage(IntPtr image, UInt16[,] array, Int32 numCols, Int32 numRows);
        [DllImport("nivision.dll")]
        internal unsafe static extern Int32 imaqArrayToComplexPlane(IntPtr _destination, IntPtr _source, float[,] array, ComplexPlane _plane);
		[ DllImport("nivision.dll")]
        internal static extern IntPtr imaqImageToArray(IntPtr image, CVI_Rectangle rect, out Int32 numCols, out Int32 numRows);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetLine(IntPtr _image, CVI_Point _start, CVI_Point _end, out Int32 _numPoints);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, byte[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, Int16[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, UInt16[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, float[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, Rgb32Value[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, Hsl32Value[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, RgbU64Value[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetLine(IntPtr _image, Complex[] _array, Int32 _arraySize, CVI_Point _start, CVI_Point _end);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqComplexPlaneToArray(IntPtr _image, ComplexPlane _plane, CVI_Rectangle _rect, out Int32 _rows, out Int32 _columns);
        [ DllImport("nivision.dll")]
        internal static extern Int32 imaqGetImageSize(IntPtr image, out Int32 width, out Int32 height);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetImageSize(IntPtr image, Int32 width, Int32 height);
		[ DllImport("nivision.dll")]
		internal static extern Int32 imaqGetImageType(IntPtr image, out Int32 type);
		[ DllImport("nivision.dll")]
		internal static extern Int32 imaqCast(IntPtr destination, IntPtr source, ImageType type, IntPtr zeroArray, Int32 shift);
		[ DllImport("nivision.dll")]
		internal static extern Int32 imaqCast(IntPtr destination, IntPtr source, ImageType type, [In] float[] lookupTable, Int32 shift);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqReadFile(IntPtr image, [MarshalAs(UnmanagedType.LPStr)] string fileName, [In, Out] Rgb32Value[] colorTable, out Int32 numColors);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern Int32 imaqReadFile(IntPtr image, [MarshalAs(UnmanagedType.LPStr)] string fileName, IntPtr zeroColorTable, IntPtr zeroNumColors);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqReadVisionFile(IntPtr image, [MarshalAs(UnmanagedType.LPStr)] string fileName, [In, Out] Rgb32Value[] colorTable, out Int32 numColors);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern Int32 imaqReadVisionFile(IntPtr image, [MarshalAs(UnmanagedType.LPStr)] string fileName, IntPtr zeroColorTable, IntPtr zeroNumColors);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetBitDepth(IntPtr _image, out UInt32 _bitDepth);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetBitDepth(IntPtr _image, UInt32 _bitDepth);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqIsImageEmpty(IntPtr _image, out Int32 _isEmpty);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqFillImage(IntPtr image, CVI_PixValue value, IntPtr mask);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqCreateROI();
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetROIColor(IntPtr roi, out Rgb32Value roiColor);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetROIColor(IntPtr roi, ref Rgb32Value roiColor);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqRemoveContour(IntPtr roi, Int32 contourID);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddPointContour(IntPtr roi, CVI_Point point);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddRectContour(IntPtr roi, CVI_Rectangle rect);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddLineContour(IntPtr roi, CVI_Point start, CVI_Point end);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddRotatedRectContour(IntPtr roi, CVI_RotatedRectangle rect);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddOvalContour(IntPtr roi, CVI_Rectangle rect);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddAnnulusContour(IntPtr roi, CVI_Annulus rect);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddClosedContour(IntPtr roi, [In] CVI_Point[] points, Int32 numPoints);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqAddOpenContour(IntPtr roi, [In] CVI_Point[] points, Int32 numPoints);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetContourColor(IntPtr roi, Int32 contourID, ref Rgb32Value color);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqDuplicate(IntPtr _destination, IntPtr _source);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetPixel(IntPtr _image, CVI_Point pixel, ref CVI_PixValue value);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetPixel(IntPtr _image, CVI_Point pixel, CVI_PixValue value);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCopyRect(IntPtr _destination, IntPtr _source, CVI_Rectangle _rect, CVI_Point _destinationLoc);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetVisionInfoTypes(IntPtr _image, out int _present);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqRemoveVisionInfo2(IntPtr _image, int _info);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetContourCount(IntPtr _roi);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetContourInfo2(IntPtr _roi, Int32 _contourID);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetContour(IntPtr _roi, UInt32 index);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetCalibrationInfo2(IntPtr _image);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetCalibrationInfo3(IntPtr _image, UInt32 _isGetErrorMap);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetBorderSize(IntPtr _image, out Int32 _borderSize);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetBorderSize(IntPtr _image, Int32 _borderSize);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetMaskOffset(IntPtr _image, out CVI_Point _offset);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetMaskOffset(IntPtr _image, CVI_Point _offset);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, [In] Rgb32Value[] colorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, IntPtr nullColorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteBMPFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _compress, [In] Rgb32Value[] colorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteBMPFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _compress, IntPtr _zeroColorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteJPEGFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, UInt32 _quality, IntPtr _zeroColorTable);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWriteJPEG2000File(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _lossless, float _compressionRatio, ref CVI_JPEG2000FileAdvancedOptions _advancedOptions, [In] Rgb32Value[] colorTable);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWriteJPEG2000File(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _lossless, float _compressionRatio, ref CVI_JPEG2000FileAdvancedOptions _advancedOptions, IntPtr _zeroColorTable);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWritePNGFile2(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, UInt32 _compressionSpeed, [In] Rgb32Value[] colorTable, Int32 _useBitDepth);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWritePNGFile2(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, UInt32 _compressionSpeed, IntPtr _zeroColorTable, Int32 _useBitDepth);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWriteTIFFFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, ref CVI_TIFFFileOptions _options, [In] Rgb32Value[] colorTable);
        [DllImport("nivision.dll", CharSet = CharSet.Ansi)]
        internal static extern Int32 imaqWriteTIFFFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, ref CVI_TIFFFileOptions _options, IntPtr _zeroColorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteVisionFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, [In] Rgb32Value[] colorTable);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal unsafe static extern Int32 imaqWriteVisionFile(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _fileName, IntPtr nullColorTable);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqFlatten(IntPtr _image, Int32 _flattenType, Int32 _compression, Int32 _quality, out UInt32 _size);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqUnflatten(IntPtr _image, byte[] _data, UInt32 _size);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqFillBorder(IntPtr _image, BorderMethod _method);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayLine(IntPtr _image, CVI_Point _start, CVI_Point _end, ref Rgb32Value _color, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayArc(IntPtr _image, ref CVI_ArcInfo _arc, ref Rgb32Value _color, Int32 _drawMode, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayRect(IntPtr _image, CVI_Rectangle _rect, ref Rgb32Value _color, Int32 _drawMode, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayOval(IntPtr _image, CVI_Rectangle _rect, ref Rgb32Value _color, Int32 _drawMode, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayBitmap(IntPtr _image, CVI_Point destinationLoc, byte[] bitmap, UInt32 numCols, UInt32 numRows, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayMetafile(IntPtr _image, IntPtr _metafile, CVI_Rectangle _rect, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayText(IntPtr _image, CVI_Point _origin, [MarshalAs(UnmanagedType.LPStr)] string _text, ref Rgb32Value _color, ref CVI_OverlayTextOptions _options, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayPoints(IntPtr _image, CVI_Point[] _points, Int32 _numPoints, Rgb32Value[] _colors, Int32 _numColors, PointSymbolType _pointSymbol, IntPtr zeroUserPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayPoints(IntPtr _image, CVI_Point[] _points, Int32 _numPoints, Rgb32Value[] _colors, Int32 _numColors, PointSymbolType _pointSymbol, ref CVI_UserPointSymbol _userPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayROI(IntPtr _image, IntPtr roi, PointSymbolType _pointSymbol, IntPtr zeroUserPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayROI(IntPtr _image, IntPtr roi, PointSymbolType _pointSymbol, ref CVI_UserPointSymbol _userPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayOpenContour(IntPtr _image, CVI_Point[] points, Int32 _numPoints, ref Rgb32Value _color, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqOverlayClosedContour(IntPtr _image, CVI_Point[] points, Int32 _numPoints, ref Rgb32Value _color, DrawingMode _drawMode, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqClearOverlay(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetOverlayProperties(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _group, out CVI_TransformBehaviors _transformBehaviors);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetOverlayProperties(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _group, ref CVI_TransformBehaviors _transformBehaviors);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqMergeOverlay(IntPtr _destination, IntPtr _source, Rgb32Value[] palette, UInt32 _numColors, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqMergeOverlay(IntPtr _destination, IntPtr _source, IntPtr zeroPalette, UInt32 _numColors, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCopyOverlay(IntPtr _destination, IntPtr _source, [MarshalAs(UnmanagedType.LPStr)] string _group);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqEnumerateCustomKeys(IntPtr _image, out UInt32 _size);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern IntPtr imaqReadCustomData(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _key, out UInt32 size);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern Int32 imaqRemoveCustomData(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _key);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern Int32 imaqWriteCustomData(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _key, byte[] _data, UInt32 _size);
        [DllImport("nivision.dll", EntryPoint = "#359", CharSet=CharSet.Ansi)]
        internal static extern Int32 dotNET_ImageHasCustomKey(IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _key, out Int32 _keyPresent);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetROIBoundingBox(IntPtr _roi, out CVI_Rectangle _boundingBox);
        [DllImport("nivision.dll", EntryPoint = "#159")]
        internal static extern Int32 Priv_InitArray1D(out Array1D array);
        [DllImport("nivision.dll", EntryPoint = "#156")]
        internal static extern Int32 Priv_DisposeArray1DBytes(ref Array1D array);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqDrawLineOnImage(IntPtr _destination, IntPtr _source, Int32 _mode, CVI_Point _start, CVI_Point _end, float _newPixelValue);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqDrawShapeOnImage(IntPtr _destination, IntPtr _source, CVI_Rectangle _rect, Int32 _drawMode, CVI_ShapeMode _shapeMode, float _newPixelValue);
        [DllImport("nivision.dll")]
        internal static extern CVI_Color2 imaqChangeColorSpace2(ref CVI_Color2 sourceColor, ColorMode _sourceSpace, ColorMode _destinationSpace, double _offset, IntPtr _nullWhiteReference);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern IntPtr imaqCreateAVI([MarshalAs(UnmanagedType.LPStr)] string _fileName, [MarshalAs(UnmanagedType.LPStr)] string _compressionFilter, Int32 _quality, UInt32 _framesPerSecond, UInt32 _maxDataSize);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern IntPtr imaqOpenAVI([MarshalAs(UnmanagedType.LPStr)] string _fileName);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetAVIInfo(IntPtr _session, out CVI_AVIInfo _info);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqReadAVIFrame(IntPtr _image, IntPtr _session, UInt32 _frameNum, [Out] byte[] data, [In, Out] ref UInt32 dataSize);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqReadAVIFrame(IntPtr _image, IntPtr _session, UInt32 _frameNum, IntPtr zeroData, IntPtr zeroDataSize);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqWriteAVIFrame(IntPtr _image, IntPtr _session, [In] byte[] _data, UInt32 _dataLength);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqWriteAVIFrame(IntPtr _image, IntPtr _session, IntPtr zeroData, UInt32 zeroDataLength);
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCloseAVI(IntPtr _session);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetFilterNames(out Int32 numFilters);
        [DllImport("nivision.dll", CharSet=CharSet.Ansi)]
        internal static extern Int32 imaqGetFileInfo([MarshalAs(UnmanagedType.LPStr)] string _fileName, out Int32 _calibrationUnit, out float _calibrationX, out float _calibrationY, out Int32 _width, out Int32 _height, out Int32 _imageType);
        [DllImport("nivision.dll", EntryPoint = "#306")]
        internal static extern Int32 Priv_LoadImageDialog([MarshalAs(UnmanagedType.LPStr)] string _startPath, [MarshalAs(UnmanagedType.Bool)] bool _multipleFiles, [MarshalAs(UnmanagedType.LPStr)] string _defaultName, [MarshalAs(UnmanagedType.LPStr)] string _defaultExtension, [MarshalAs(UnmanagedType.LPStr)] string _filters, int _filterIndex, [MarshalAs(UnmanagedType.LPStr)] string _dialogTitle, int _flags, ref Array1D _returnPath, ref Array1D _returnPaths, out int _cancelled, out int _numberOfPaths);
        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetPixelAddress(IntPtr _image, CVI_Point _pixel);
        #endregion
        #region Viewer imports
        [ DllImport("nivision.dll", EntryPoint="#12")]
		internal static extern Int32 Priv_AttachImage(IntPtr _hWnd, IntPtr image);
		[ DllImport("nivision.dll", EntryPoint="#13")]
        internal static extern IntPtr Priv_CreateChildWindow(IntPtr _hiddenParentWnd);
		[ DllImport("nivision.dll", EntryPoint="#14")]
		internal static extern void Priv_Reparent(IntPtr _hWnd, IntPtr _parentWnd);
		[ DllImport("nivision.dll", EntryPoint="#16")]
		internal static extern void Priv_ShowCoordinates(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool _show);
		[ DllImport("nivision.dll", EntryPoint="#19")]
		internal static extern void Priv_ShowIndicators(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool _show);
		[ DllImport("nivision.dll", EntryPoint="#18")]
        internal static extern void Priv_SetToolsDlgHeightAndOffset(IntPtr _hWnd, UInt32 _height, UInt32 _offset);
        [DllImport("nivision.dll", EntryPoint = "#326")]
        internal static extern void Priv_GetToolsDlgMinSizeWithWidth(IntPtr _hWnd, Int32 _width, out System.Drawing.Size _size);
        [DllImport("nivision.dll", EntryPoint = "#66")]
        internal static extern void Priv_ShowScrollBars(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool _show);
        [DllImport("nivision.dll", EntryPoint = "#287")]
        internal static extern void Priv_ShowToolbar(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool _show);
        [DllImport("nivision.dll", EntryPoint = "#232")]
        internal static extern void Priv_ContextSensitiveTools(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool showContextSensitiveTools);
        [DllImport("nivision.dll", EntryPoint = "#17")]
        internal static extern void Priv_ShowColor(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool _show);
        [DllImport("nivision.dll", EntryPoint = "#11")]
        internal static extern void Priv_SetTool(IntPtr _hWnd, CVI_ViewerTool tool);
        [DllImport("nivision.dll", EntryPoint = "#361")]
        internal static extern void Priv_GetTool(IntPtr _hWnd, out CVI_ViewerTool tool);
        [DllImport("nivision.dll", EntryPoint = "#288")]
        internal static extern void Priv_SetVisibleTools(IntPtr _hWnd, CVI_ViewerTool[] tools, int count);
        [DllImport("nivision.dll", EntryPoint = "#358")]
        internal static extern void Priv_SetROIInfo(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool showROIInfo);
        [DllImport("nivision.dll", EntryPoint = "#63")]
        internal static extern void Priv_SetPalette(IntPtr _hWnd, Int32 type, IntPtr nullPalette);
        [DllImport("nivision.dll", EntryPoint = "#63")]
        internal static extern void Priv_SetPalette(IntPtr _hWnd, Int32 type, [In] PaletteEntry[] userPalette);
        [DllImport("nivision.dll", EntryPoint = "#64", CallingConvention = CallingConvention.Cdecl)]
        internal static extern Int32 Priv_GetPalette(Int32 paletteNumber, [In, Out] PaletteEntry[] palette);
        [DllImport("nivision.dll", EntryPoint = "#302")]
        internal static extern void Priv_SetMaxContourCount(IntPtr _hWnd, Int32 maxContours);
        [DllImport("nivision.dll", EntryPoint = "#360")]
        internal static extern void Priv_GetMaxContourCount(IntPtr _hWnd, out Int32 maxContours);
        [DllImport("nivision.dll", EntryPoint = "#25")]
        internal static extern void Priv_SetImageOrigin(IntPtr _hWnd, ref System.Drawing.Point origin);
        [DllImport("nivision.dll", EntryPoint = "#77")]
        internal static extern void Priv_GetCenterPos(IntPtr _hWnd, ref System.Drawing.Point center);
        [DllImport("nivision.dll", EntryPoint = "#72")]
        internal static extern void Priv_SetCenterPos(IntPtr _hWnd, ref System.Drawing.Point center);
        [DllImport("nivision.dll", EntryPoint = "#71")]
        internal static extern void Priv_SetAutoDelete(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool autoDelete);
        [DllImport("nivision.dll", EntryPoint = "#335")]
        internal static extern void Priv_SetWindBackgroundOptions(IntPtr _hWnd, Int32 fillStyle, Int32 hatchStyle, ref Rgb32Value fillColor, ref Rgb32Value backgroundColor);
        [DllImport("nivision.dll", EntryPoint = "#309")]
        internal static extern Int32 Priv_SetWindNonTearing(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] bool useNonTearing);
        [DllImport("nivision.dll", EntryPoint = "#356")]
        internal static extern Int32 Priv_ZoomToFit(IntPtr _hWnd, [MarshalAs(UnmanagedType.Bool)] ref bool zoomToFit, int set);
        [DllImport("nivision.dll", EntryPoint = "#362")]
        internal static extern Int32 Priv_Zoom2(IntPtr _hWnd, ref float zoomX, ref float zoomY, [MarshalAs(UnmanagedType.Bool)] bool set);
        [DllImport("nivision.dll", EntryPoint = "#222")]
        internal static extern void Priv_SetDisplayMapping(IntPtr _hWnd, ref VB_ConversionPolicy mapping);
        [DllImport("nivision.dll", EntryPoint = "#223")]
        internal static extern Int32 Priv_CheckDisplayMapping(Int32 policy, Int32 min, Int32 max, Int32 shift);
        [DllImport("nivision.dll", EntryPoint = "#21")]
        internal static extern Int32 Priv_SetToolsDlgTextColor(IntPtr _hWnd, Rgb32OrderedValue color);
        [DllImport("nivision.dll", EntryPoint = "#20")]
        internal static extern Int32 Priv_SetToolsDlgBkColor(IntPtr _hWnd, Rgb32OrderedValue color);
        [DllImport("nivision.dll", EntryPoint = "#34")]
        internal static extern IntPtr Priv_CreateContourFromElement(IntPtr element);
        [DllImport("nivision.dll", EntryPoint = "#33")]
        internal static extern IntPtr Priv_CreateElement(IntPtr _hWnd, IntPtr roiContour, [MarshalAs(UnmanagedType.Bool)] bool redraw);
        [DllImport("nivision.dll", EntryPoint = "#43")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool Priv_DeleteElement(IntPtr _hWnd, IntPtr element);
        [DllImport("nivision.dll", EntryPoint = "#32")]
        internal static extern IntPtr Priv_ReplaceElement(IntPtr _hWnd, IntPtr element, IntPtr roiContour);
        [DllImport("nivision.dll", EntryPoint = "#118")]
        internal static extern IntPtr Priv_CreateRectangleContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 left, Int32 top, Int32 width, Int32 height);
        [DllImport("nivision.dll", EntryPoint = "#113")]
        internal static extern IntPtr Priv_CreatePointContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 x, Int32 y);
        [DllImport("nivision.dll", EntryPoint = "#38")]
        internal static extern CVI_SelectionMode Priv_GetContourType(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#36")]
        internal static extern void Priv_DeleteContour(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint="#44")]
        internal static extern void Priv_SetElementColor(IntPtr element, Rgb32OrderedValue color);
        [DllImport("nivision.dll", EntryPoint="#35")]
        internal static extern void Priv_SetROIDefaultColor(IntPtr roi, ColorRefValue color);
        [DllImport("nivision.dll", EntryPoint = "#115")]
        internal static extern Int32 Priv_GetPointContourX(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#117")]
        internal static extern Int32 Priv_GetPointContourY(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#120")]
        internal static extern Int32 Priv_GetRectangleContourLeft(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#122")]
        internal static extern Int32 Priv_GetRectangleContourTop(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#124")]
        internal static extern Int32 Priv_GetRectangleContourWidth(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#126")]
        internal static extern Int32 Priv_GetRectangleContourHeight(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#196")]
        internal unsafe static extern void Priv_GetRotatedRectangleBoundingRect(ref VB_RotatedRectangle rotatedRect, out VB_Rectangle boundingBox);
        [DllImport("nivision.dll", EntryPoint = "#95")]
        internal static extern IntPtr Priv_CreateLineContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 x1, Int32 y1, Int32 x2, Int32 y2);
        [DllImport("nivision.dll", EntryPoint = "#97")]
        internal static extern Int32 Priv_GetLineContourX1(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#99")]
        internal static extern Int32 Priv_GetLineContourY1(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#101")]
        internal static extern Int32 Priv_GetLineContourX2(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#103")]
        internal static extern Int32 Priv_GetLineContourY2(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#127")]
        internal static extern IntPtr Priv_CreateRotatedRectangleContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 left, Int32 top, Int32 width, Int32 height, double angle);
        [DllImport("nivision.dll", EntryPoint = "#133")]
        internal static extern Int32 Priv_GetRotatedRectangleContourWidth(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#135")]
        internal static extern Int32 Priv_GetRotatedRectangleContourHeight(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#137")]
        internal static extern double Priv_GetRotatedRectangleContourAngle(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#139")]
        internal static extern float Priv_GetRotatedRectangleContourCenterX(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#141")]
        internal static extern float Priv_GetRotatedRectangleContourCenterY(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#104")]
        internal static extern IntPtr Priv_CreateOvalContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 left, Int32 top, Int32 width, Int32 height);
        [DllImport("nivision.dll", EntryPoint = "#106")]
        internal static extern Int32 Priv_GetOvalContourLeft(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#108")]
        internal static extern Int32 Priv_GetOvalContourTop(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#110")]
        internal static extern Int32 Priv_GetOvalContourWidth(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#112")]
        internal static extern Int32 Priv_GetOvalContourHeight(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#82")]
        internal static extern IntPtr Priv_CreateAnnulusContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external, Int32 centerX, Int32 centerY, Int32 innerRadius, Int32 outerRadius, double startAngle, double endAngle);
        [DllImport("nivision.dll", EntryPoint = "#84")]
        internal static extern Int32 Priv_GetAnnulusContourCenterX(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#86")]
        internal static extern Int32 Priv_GetAnnulusContourCenterY(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#88")]
        internal static extern Int32 Priv_GetAnnulusContourInnerRadius(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#90")]
        internal static extern Int32 Priv_GetAnnulusContourOuterRadius(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#92")]
        internal static extern double Priv_GetAnnulusContourStartAngle(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#94")]
        internal static extern double Priv_GetAnnulusContourEndAngle(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#143")]
        internal static extern IntPtr Priv_CreatePolygonContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external);
        [DllImport("nivision.dll", EntryPoint = "#145")]
        internal static extern IntPtr Priv_CreateFreeregionContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external);
        [DllImport("nivision.dll", EntryPoint = "#144")]
        internal static extern IntPtr Priv_CreateFreelineContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external);
        [DllImport("nivision.dll", EntryPoint = "#142")]
        internal static extern IntPtr Priv_CreateBrokenlineContour(Rgb32Value color, [MarshalAs(UnmanagedType.Bool)] bool external);
        [DllImport("nivision.dll", EntryPoint = "#79")]
        internal static extern IntPtr Priv_CreateEmptyContour();
        [DllImport("nivision.dll", EntryPoint = "#37")]
        internal static extern UInt32 Priv_GetNumberOfPoints(IntPtr contour);
        [DllImport("nivision.dll", EntryPoint = "#41")]
        internal static extern UInt32 Priv_GetXData(IntPtr contour, [Out] int[] xPoints, UInt32 numPoints);
        [DllImport("nivision.dll", EntryPoint = "#42")]
        internal static extern UInt32 Priv_GetYData(IntPtr contour, [Out] int[] xPoints, UInt32 numPoints);
        [DllImport("nivision.dll", EntryPoint = "#151")]
        internal static extern Int32 Priv_SetContourPoints(IntPtr contour, CVI_ViewerTool roiType, [In] CVI_Point[] points, int numPoints);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ExternalCanvasCallbackDelegate(IntPtr _image);
#if (Bit32)
        [DllImport("nivissvc.dll", EntryPoint = "#336", CallingConvention = CallingConvention.Cdecl)]
#else
        [DllImport("nivissvc.dll", EntryPoint = "SetExternalCanvasCallback")]
#endif
        internal static extern Int32 SetExternalCanvasCallback(IntPtr _image, ExternalCanvasCallbackDelegate callback);
#endregion
#region Windows imports
		[ DllImport("user32.dll")]
		internal static extern Int32 SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, Int32 X, Int32 Y, Int32 cx, Int32 cy, UInt32 uFlags);
        [ DllImport("user32.dll")]
        internal static extern Int32 ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool InvalidateRect(IntPtr hWnd, ref System.Drawing.Rectangle rect, [MarshalAs(UnmanagedType.Bool)] bool erase);
#endregion
    }
}