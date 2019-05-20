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
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using NationalInstruments.Vision.Internal;
using NationalInstruments.Vision.WindowsForms;
using NationalInstruments.Vision.WindowsForms.Internal;
using System.Collections.Specialized;

namespace NationalInstruments.Vision.Analysis.Internal
{

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineFloat : IHasExternalVersionOut<LineContour>
	{
		private CVI_PointFloat _start;
		private CVI_PointFloat _end;

		
		public LineContour ConvertToExternal()
		{
			return new LineContour(_start.ConvertToExternal(), _end.ConvertToExternal());
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_HistogramReport : IHasExternalVersionOut<HistogramReport>
	{
		private IntPtr _histogram;
		private Int32 _histogramCount;
		private float _min;
		private float _max;
		private float _start;
		private float _width;
		private float _mean;
		private float _stdDev;
		private Int32 _numPixels;

		
		public HistogramReport ConvertToExternal()
		{
			HistogramReport toReturn = new HistogramReport();
			toReturn.Histogram = Utilities.ConvertIntPtrToCollection<int>(_histogram, _histogramCount, false);
			toReturn.Mean = _mean;
			toReturn.NumberOfPixels = _numPixels;
			toReturn.PixelRange.Minimum = _min;
			toReturn.PixelRange.Maximum = _max;
			toReturn.StandardDeviation = _stdDev;
			toReturn.Start = _start;
			toReturn.Width = _width;
			return toReturn;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal unsafe struct Priv_HistographReport : IHasExternalVersionIn<HistogramReport, Array1D>
	{
		private Array1D* _histogram;
		private float _min;
		private float _max;
		private float _start;
		private float _width;
		private float _mean;
		private float _stdDev;
		private Int32 _numPixels;

		
		public void ConvertFromExternal(HistogramReport report, Array1D realHistogram)
		{
			_histogram = &realHistogram;
			_min = (float)report.PixelRange.Minimum;
			_max = (float)report.PixelRange.Maximum;
			_start = (float)report.Start;
			_width = (float)report.Width;
			_mean = (float)report.Mean;
			_stdDev = (float)report.StandardDeviation;
			_numPixels = report.NumberOfPixels;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ColorHistogramReport : IHasExternalVersionOut<ColorHistogramReport>
	{
		private CVI_HistogramReport _plane1;
		private CVI_HistogramReport _plane2;
		private CVI_HistogramReport _plane3;

		
		public ColorHistogramReport ConvertToExternal()
		{
			ColorHistogramReport report = new ColorHistogramReport();
			report.Plane1 = _plane1.ConvertToExternal();
			report.Plane2 = _plane2.ConvertToExternal();
			report.Plane3 = _plane3.ConvertToExternal();
			return report;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnPatternAdvancedShiftOptions : IHasExternalVersionIn<LearnPatternAdvancedShiftOptions>
	{
		private Int32 _initialStepSize;
		private Int32 _initialSampleSize;
		private double _initialSampleSizeFactor;
		private Int32 _finalSampleSize;
		private double _finalSampleSizeFactor;
		private Int32 _subpixelSampleSize;
		private double _subpixelSampleSizeFactor;

		
		public void ConvertFromExternal(LearnPatternAdvancedShiftOptions item)
		{
			_initialStepSize = item.InitialStepSize;
			_initialSampleSize = item.InitialSampleSize;
			_initialSampleSizeFactor = item.InitialSampleSizeFactor;
			_finalSampleSize = item.FinalSampleSize;
			_finalSampleSizeFactor = item.FinalSampleSizeFactor;
			_subpixelSampleSize = item.SubpixelSampleSize;
			_subpixelSampleSizeFactor = item.SubpixelSampleSizeFactor;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnPatternAdvancedRotationOptions : IHasExternalVersionIn<LearnPatternAdvancedRotationOptions>
	{
		private SearchStrategy _searchStrategySupport;
		private Int32 _initialStepSize;
		private Int32 _initialSampleSize;
		private double _initialSampleSizeFactor;
		private Int32 _initialAngularAccuracy;
		private Int32 _finalSampleSize;
		private double _finalSampleSizeFactor;
		private Int32 _finalAngularAccuracy;
		private Int32 _subpixelSampleSize;
		private double _subpixelSampleSizeFactor;

		
		public void ConvertFromExternal(LearnPatternAdvancedRotationOptions item)
		{
			_searchStrategySupport = item.StrategySupport;
			_initialStepSize = item.InitialStepSize;
			_initialSampleSize = item.InitialSampleSize;
			_initialSampleSizeFactor = item.InitialSampleSizeFactor;
			_initialAngularAccuracy = item.InitialAngularAccuracy;
			_finalSampleSize = item.FinalSampleSize;
			_finalSampleSizeFactor = item.FinalSampleSizeFactor;
			_finalAngularAccuracy = item.FinalAngularAccuracy;
			_subpixelSampleSize = item.SubpixelSampleSize;
			_subpixelSampleSizeFactor = item.SubpixelSampleSizeFactor;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnPatternAdvancedOptions
	{
		private unsafe CVI_LearnPatternAdvancedShiftOptions* _shiftOptions;
		private unsafe CVI_LearnPatternAdvancedRotationOptions* _rotationOptions;

		
		public unsafe CVI_LearnPatternAdvancedOptions(CVI_LearnPatternAdvancedShiftOptions* shiftOptions, CVI_LearnPatternAdvancedRotationOptions* rotationOptions)
		{
			_shiftOptions = shiftOptions;
			_rotationOptions = rotationOptions;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchPatternAdvancedOptions : IHasExternalVersionIn<MatchPatternAdvancedOptions>
	{
		private Int32 _subpixelIterations;
		private double _subpixelTolerance;
		private Int32 _initialMatchListLength;
		private Int32 _matchListReductionFactor;
		private Int32 _initialStepSize;
		private Int32 _searchStrategy;
		private Int32 _intermediateAngularAccuracy;

		
		public void ConvertFromExternal(MatchPatternAdvancedOptions item){
			_subpixelIterations = item.SubpixelIterations;
			_subpixelTolerance = item.SubpixelTolerance;
			_initialMatchListLength = item.InitialMatchListLength;
			_matchListReductionFactor = item.MatchListReductionFactor;
			_initialStepSize = item.InitialStepSize;
			_searchStrategy = (int)item.SearchStrategy;
			_intermediateAngularAccuracy = item.IntermediateAngularAccuracy;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RotationAngleRange : IHasExternalVersionIn<Range> {
		private float _lower;
		private float _upper;

		
		public void ConvertFromExternal(Range range)
		{
			_lower = (float)range.Minimum;
			_upper = (float)range.Maximum;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchPatternOptions : IDisposable, IHasExternalVersionIn<MatchPatternOptions>
	{
		private Int32 _mode;
		private Int32 _minContrast;
		private Int32 _subpixelAccuracy;
		private IntPtr _angleRanges;
		private Int32 _numRanges;
		private Int32 _numMatchesRequested;
		private Int32 _matchFactor;
		private float _minMatchScore;

		
		public void ConvertFromExternal(MatchPatternOptions item)
		{
			_mode = (int)(item.Mode);
			_minContrast = item.MinimumContrast;
			_subpixelAccuracy = (item.SubpixelAccuracy) ? 1 : 0;
			_numRanges = item.RotationAngleRanges.Count;
			_angleRanges = Utilities.ConvertCollectionToIntPtr<Range, CVI_RotationAngleRange>(item.RotationAngleRanges);
			_numMatchesRequested = item.NumberOfMatchesRequested;
			_matchFactor = 0;
			_minMatchScore = (float)item.MinimumMatchScore;
		}

		#region IDisposable Members

		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _angleRanges is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_angleRanges != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_angleRanges);
				_angleRanges = IntPtr.Zero;
			}
		}

		#endregion
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_InspectionAlignment : IHasExternalVersionIn<InspectionAlignment>
	{
		private CVI_PointFloat _position;
		private float _rotation;
		private float _scale;

		
		public void ConvertFromExternal(InspectionAlignment align)
		{
			_position = new CVI_PointFloat((float)align.Position.X, (float)align.Position.Y);
			_rotation = (float) align.Rotation;
			_scale = (float) align.Scale;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_InspectionOptions : IHasExternalVersionIn<InspectionOptions>
	{
		private Int32 _registrationMethod;
		private Int32 _normalizationMethod;
		private Int32 _edgeThicknessToIgnore;
		private float _brightThreshold;
		private float _darkThreshold;
		private Int32 _binary;

		
		public void ConvertFromExternal(InspectionOptions options)
		{
			_registrationMethod = (Int32)options.RegistrationMethod;
			_normalizationMethod = (Int32)options.NormalizationMethod;
			_edgeThicknessToIgnore = options.EdgeThicknessToIgnore;
			_brightThreshold = (float)options.BrightThreshold;
			_darkThreshold = (float)options.DarkThreshold;
			_binary = options.Binary ? 1 : 0;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PatternMatch : IHasExternalVersionOut<PatternMatch>, IHasExternalVersionIn<PatternMatch>
	{
		private CVI_PointFloat _position;
		private float _rotation;
		private float _scale;
		private float _score;
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;

		
		public PatternMatch ConvertToExternal()
		{
			PatternMatch toReturn = new PatternMatch();
			toReturn.Corners.Add(new PointContour(_corner0.X, _corner0.Y));
			toReturn.Corners.Add(new PointContour(_corner1.X, _corner1.Y));
			toReturn.Corners.Add(new PointContour(_corner2.X, _corner2.Y));
			toReturn.Corners.Add(new PointContour(_corner3.X, _corner3.Y));
			toReturn.Position.X = _position.X;
			toReturn.Position.Y = _position.Y;
			toReturn.Rotation = _rotation;
			toReturn.Scale = _scale;
			toReturn.Score = _score;
			return toReturn;
		}

		
		public void ConvertFromExternal(PatternMatch match)
		{
			_position = new CVI_PointFloat();
			_position.ConvertFromExternal(match.Position);
			_rotation = (float)match.Rotation;
			_scale = (float)match.Scale;
			_score = (float)match.Score;
			_corner0 = new CVI_PointFloat();
			_corner0.ConvertFromExternal(match.Corners[0]);
			_corner1 = new CVI_PointFloat();
			_corner1.ConvertFromExternal(match.Corners[1]);
			_corner2 = new CVI_PointFloat();
			_corner2.ConvertFromExternal(match.Corners[2]);
			_corner3 = new CVI_PointFloat();
			_corner3.ConvertFromExternal(match.Corners[3]);
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PatternMatchReport : IHasExternalVersionOut<PatternMatchReport>, IHasExternalVersionIn<PatternMatchReport>
    {
        private CVI_PointFloat _position;
        private CVI_PointFloat _calibratedPosition;
        private float _rotation;
        private float _calibratedRotation;
        private float _scale;
        private float _calibratedScale;
        private float _score;
        private float _calibratedScore;
        private CVI_PointFloat _corner0;
        private CVI_PointFloat _corner1;
        private CVI_PointFloat _corner2;
        private CVI_PointFloat _corner3;
        private CVI_PointFloat _calibratedCorner0;
        private CVI_PointFloat _calibratedCorner1;
        private CVI_PointFloat _calibratedCorner2;
        private CVI_PointFloat _calibratedCorner3;

        
        public PatternMatchReport ConvertToExternal()
        {
            PatternMatchReport toReturn = new PatternMatchReport();
            toReturn.Corners.Add(new PointContour(_corner0.X, _corner0.Y));
            toReturn.Corners.Add(new PointContour(_corner1.X, _corner1.Y));
            toReturn.Corners.Add(new PointContour(_corner2.X, _corner2.Y));
            toReturn.Corners.Add(new PointContour(_corner3.X, _corner3.Y));
            toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner0.X, _calibratedCorner0.Y));
            toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner1.X, _calibratedCorner1.Y));
            toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner2.X, _calibratedCorner2.Y));
            toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner3.X, _calibratedCorner3.Y));

            toReturn.Position.X = _position.X;
            toReturn.Position.Y = _position.Y;

            toReturn.CalibratedPosition.X = _calibratedPosition.X;
            toReturn.CalibratedPosition.Y = _calibratedPosition.Y;

            toReturn.Rotation = _rotation;
            toReturn.Scale = _scale;
            toReturn.Score = _score;

            toReturn.CalibratedRotation = _calibratedRotation;
            toReturn.CalibratedScale    = _calibratedScale;
            toReturn.CalibratedScore    = _calibratedScore;
            return toReturn;
        }

        
        public void ConvertFromExternal(PatternMatchReport match)
        {
            _position = new CVI_PointFloat();
            _position.ConvertFromExternal(match.Position);

            _calibratedPosition = new CVI_PointFloat();
            _calibratedPosition.ConvertFromExternal(match.CalibratedPosition);

            _rotation   = (float)match.Rotation;
            _scale      = (float)match.Scale;
            _score      = (float)match.Score;

            _calibratedRotation = (float)match.CalibratedRotation;
            _calibratedScale    = (float)match.CalibratedScale;
            _calibratedScore    = (float)match.CalibratedScore;

            _corner0 = new CVI_PointFloat();
            _corner0.ConvertFromExternal(match.Corners[0]);
            _corner1 = new CVI_PointFloat();
            _corner1.ConvertFromExternal(match.Corners[1]);
            _corner2 = new CVI_PointFloat();
            _corner2.ConvertFromExternal(match.Corners[2]);
            _corner3 = new CVI_PointFloat();
            _corner3.ConvertFromExternal(match.Corners[3]);

            _calibratedCorner0 = new CVI_PointFloat();
            _calibratedCorner0.ConvertFromExternal(match.CalibratedCorners[0]);
            _calibratedCorner1 = new CVI_PointFloat();
            _calibratedCorner1.ConvertFromExternal(match.CalibratedCorners[1]);
            _calibratedCorner2 = new CVI_PointFloat();
            _calibratedCorner2.ConvertFromExternal(match.CalibratedCorners[2]);
            _calibratedCorner3 = new CVI_PointFloat();
            _calibratedCorner3.ConvertFromExternal(match.CalibratedCorners[3]);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnTemplateReport : IHasExternalVersionOut<LearnTemplateReport>
    {
        private Int32 templateContrast;
        private Int32 grayvalueMaxPyramidLevel;
        private Int32 grayvalueOptimalPyramidLevel;
        private Int32 gradientMaxPyramidLevel;
        private Int32 gradientOptimalPyramidLevel;

        public LearnTemplateReport ConvertToExternal()
        {
            LearnTemplateReport report = new LearnTemplateReport();
            report.TemplateContrast = this.templateContrast;
            report.GrayvalueMaxPyramidLevel = this.grayvalueMaxPyramidLevel;
            report.GrayvalueOptimalPyramidLevel = this.grayvalueOptimalPyramidLevel;
            report.GradientMaxPyramidLevel = this.gradientMaxPyramidLevel;
            report.GradientOptimalPyramidLevel = this.gradientOptimalPyramidLevel;
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PMLearnAdvancedSetupDataOption : IHasExternalVersionIn<PMLearnAdvancedSetupDataOption>
    {
        private LearnSetupOption type;
        private double value;

        public void ConvertFromExternal(PMLearnAdvancedSetupDataOption advancedOptions)
        {
            this.type = advancedOptions.Type;
            this.value = advancedOptions.Value;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PMMatchAdvancedSetupDataOption : IHasExternalVersionIn<PMMatchAdvancedSetupDataOption>
    {
        private MatchSetupOption type;
        private double value;

        public void ConvertFromExternal(PMMatchAdvancedSetupDataOption advancedOptions)
        {
            this.type   = advancedOptions.Type;
            this.value  = advancedOptions.Value;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PyramidInfo
    {
        private Int32 maxPyramidLevel;
        private Int32 optimalPyramidLevel;
        private Int32 maxPyramidLevelToStoreData;

        public Int32 MaxPyramidLevelToStoreData
        {
            get { return maxPyramidLevelToStoreData; }
            set { maxPyramidLevelToStoreData = value; }
        }

        public Int32 OptimalPyramidLevel
        {
          get { return optimalPyramidLevel; }
          set { optimalPyramidLevel = value; }
        }
        public Int32 MaxPyramidLevel
        {
            get { return maxPyramidLevel; }
            set { maxPyramidLevel = value; }
        }

        public CVI_PyramidInfo(Int32 _maxPyramidLevel, Int32 _optimalPyramidLevel, Int32 _maxPyramidLevelToStoreData)
        {
            maxPyramidLevel     = _maxPyramidLevel;
            optimalPyramidLevel = _optimalPyramidLevel;
            maxPyramidLevelToStoreData = _maxPyramidLevelToStoreData;
        }

    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchOffsetInfo
    {
        private double matchOffsetX;
        private double matchOffsetY;
        private double angleOffset;

        public double AngleOffset
        {
            get { return angleOffset; }
            set { angleOffset = value; }
        }

        public double MatchOffsetY
        {
            get { return matchOffsetY; }
            set { matchOffsetY = value; }
        }

        public double MatchOffsetX
        {
            get { return matchOffsetX; }
            set { matchOffsetX = value; }
        }

        public CVI_MatchOffsetInfo(double _matchOffsetX, double _matchOffsetY, double _angleOffset)
        {
            matchOffsetX = _matchOffsetX;
            matchOffsetY = _matchOffsetY;
            angleOffset = _angleOffset;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PatternMatchTemplateInfo : IHasExternalVersionOut<PatternMatchTemplateInfo>
    {
        public CVI_PyramidInfo pyramidInfo;
        public CVI_MatchOffsetInfo matchOffSetInfo;

        internal CVI_MatchOffsetInfo MatchOffSetInfo
        {
            get { return matchOffSetInfo; }
        }
        internal CVI_PyramidInfo PyramidInfo
        {
            get { return pyramidInfo; }
        }
        public PatternMatchTemplateInfo ConvertToExternal()
        {
            PatternMatchTemplateInfo report = new PatternMatchTemplateInfo();
            report.PyramidMatchInfo.MaxPyramidLevel     = this.PyramidInfo.MaxPyramidLevel;
            report.PyramidMatchInfo.OptimalPyramidLevel = this.PyramidInfo.OptimalPyramidLevel;
            report.PyramidMatchInfo.MaxPyramidLevelToStoreData = this.pyramidInfo.MaxPyramidLevelToStoreData;

            report.MatchOffsetInfo.MatchOffsetX = this.MatchOffSetInfo.MatchOffsetX;
            report.MatchOffsetInfo.MatchOffsetY = this.MatchOffSetInfo.MatchOffsetY;
            report.MatchOffsetInfo.AngleOffset = this.MatchOffSetInfo.AngleOffset;
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PMRotationAngleRange : IHasExternalVersionIn<RotationAngleRange>
    {
        private float lower;
        private float upper;

        public float Upper
        {
            get { return upper; }
            set { upper = value; }
        }
        public float Lower
        {
            get { return lower; }
            set { lower = value; }
        }
        public void ConvertFromExternal(RotationAngleRange item)
        {
            this.lower = item.Lower;
            this.upper = item.Upper;
        }
   }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnGeometricPatternAdvancedOptions2 : IHasExternalVersionIn<LearnGeometricPatternEdgeBasedAdvancedOptions>
	{
		private double _minScaleFactor;
		private double _maxScaleFactor;
		private double _minRotationAngleValue;
		private double _maxRotationAngleValue;
		private UInt32 _imageSamplingFactor;

		
		public void ConvertFromExternal(LearnGeometricPatternEdgeBasedAdvancedOptions options)
		{
			_minScaleFactor = options.ScaleRange.Minimum;
			_maxScaleFactor = options.ScaleRange.Maximum;
			_minRotationAngleValue = options.RotationAngleRange.Minimum;
			_maxRotationAngleValue = options.RotationAngleRange.Maximum;
			_imageSamplingFactor = options.ImageSamplingFactor;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnGeometricPatternAdvancedOptions : IHasExternalVersionIn<LearnGeometricPatternFeatureBasedAdvancedOptions>
	{
		private Int32 _minRectLength;
		private double _minRectAspectRatio;
		private Int32 _minRadius;
		private Int32 _minLineLength;
		private double _minFeatureStrength;
		private Int32 _maxFeaturesUsed;
		private Int32 _maxPixelDistanceFromLine;

		
		public void ConvertFromExternal(LearnGeometricPatternFeatureBasedAdvancedOptions options)
		{
			_minRectLength = options.MinimumRectangleLength;
			_minRectAspectRatio = options.MinimumRectangleAspectRatio;
			_minRadius = options.MinimumRadius;
			_minLineLength = options.MinimumLineLength;
			_minFeatureStrength = options.MinimumFeatureStrength;
			_maxFeaturesUsed = options.MaximumFeaturesUsed;
			_maxPixelDistanceFromLine = options.MaximumPixelDistanceFromLine;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchGeometricPatternOptions :  IHasExternalVersionIn<MatchGeometricPatternEdgeBasedOptions>, IHasExternalVersionIn<MatchGeometricPatternFeatureBasedOptions>, IDisposable
	{
		private UInt32          _mode; 
		private Int32           _subpixelAccuracy;
		private IntPtr          _angleRanges;
		private Int32           _numAngleRanges;  
		private CVI_RangeFloat  _scaleRange; 
		private CVI_RangeFloat  _occlusionRange;      
		private Int32           _numMatchesRequested; 
		private float           _minMatchScore;

		
		public void ConvertFromExternal(MatchGeometricPatternEdgeBasedOptions options)
		{
			_mode = (UInt32) (options.Mode);
			_subpixelAccuracy = (options.SubpixelAccuracy) ? 1:0;
			_angleRanges = Utilities.ConvertCollectionToIntPtr<Range, CVI_RangeFloat>(options.RotationAngleRanges);
			_numAngleRanges = options.RotationAngleRanges.Count;
			_scaleRange = new CVI_RangeFloat();
			_scaleRange.ConvertFromExternal(options.ScaleRange);
			_occlusionRange = new CVI_RangeFloat();
			_occlusionRange.ConvertFromExternal(options.OcclusionRange);
			_numMatchesRequested = options.NumberOfMatchesRequested;
		}

		public void ConvertFromExternal(MatchGeometricPatternFeatureBasedOptions options)
		{
			_mode = (UInt32) (options.Mode);
			_subpixelAccuracy = (options.SubpixelAccuracy) ? 1:0;
			_angleRanges = Utilities.ConvertCollectionToIntPtr<Range, CVI_RangeFloat>(options.RotationAngleRanges);
			_numAngleRanges = options.RotationAngleRanges.Count;
			_scaleRange = new CVI_RangeFloat();
			_scaleRange.ConvertFromExternal(options.ScaleRange);
			_occlusionRange = new CVI_RangeFloat();
			_occlusionRange.ConvertFromExternal(options.OcclusionRange);
			_numMatchesRequested = options.NumberOfMatchesRequested;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing)
		{
			// Since _angleRanges is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_angleRanges != IntPtr.Zero)
			{
				Marshal.FreeCoTaskMem(_angleRanges);
				_angleRanges = IntPtr.Zero;
			}
		}
		#endregion
}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchGeometricPatternAdvancedOptions2 : IHasExternalVersionIn<MatchGeometricPatternFeatureBasedAdvancedOptions>
	{
		private Int32 _minFeaturesUsed;
		private Int32 _maxFeaturesUsed;
		private Int32 _subpixelIterations;
		private double _subpixelTolerance;
		private Int32 _initialMatchListLength;
		private Int32 _targetTemplateCurveScore;
		private Int32 _correlationScore;
		private double _minMatchSeparationDistance;
		private double _minMatchSeparationAngle;
		private double _minMatchSeparationScale;
		private double _maxMatchOverlap;
		private Int32 _coarseResult;
		private Int32 _smoothContours;
		private Int32 _enableCalibrationSupport;

		
		public void ConvertFromExternal(MatchGeometricPatternFeatureBasedAdvancedOptions options)
		{
			_minFeaturesUsed = (Int32)options.FeaturesUsedRange.Minimum;
			_maxFeaturesUsed = (Int32)options.FeaturesUsedRange.Maximum;
			_subpixelIterations = options.SubpixelIterations;
			_subpixelTolerance = options.SubpixelTolerance;
			_initialMatchListLength = options.InitialMatchListLength;
			_targetTemplateCurveScore = options.TargetTemplateCurveScore ? 1 : 0;
			_correlationScore = (options.CorrelationScore) ? 1:0;
			_minMatchSeparationDistance = options.MinimumMatchSeparationDistance;
			_minMatchSeparationAngle = options.MinimumMatchSeparationAngle;
			_minMatchSeparationScale = options.MinimumMatchSeparationScale;
			_maxMatchOverlap = options.MaximumMatchOverlap;
			_coarseResult = (options.CoarseResult)?1:0;
			_smoothContours = options.SmoothContours ? 1 : 0;
			_enableCalibrationSupport = options.EnableCalibrationSupport ? 1 : 0;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchGeometricPatternAdvancedOptions3 : IHasExternalVersionIn<MatchGeometricPatternEdgeBasedAdvancedOptions>
	{
		private UInt32                          _subpixelIterations;         
		private double                          _subpixelTolerance;          
		private UInt32                          _initialMatchListLength;     
		private Int32                           _targetTemplateCurveScore;    
		private Int32                           _correlationScore;           
		private double                          _minMatchSeparationDistance; 
		private double                          _minMatchSeparationAngle;    
		private double                          _minMatchSeparationScale;    
		private double                          _maxMatchOverlap;            
		private Int32                           _coarseResult;               
		private Int32                           _enableCalibrationSupport;   
		private ContrastMode                    _enableContrastReversal;     
		private GeometricMatchingSearchStrategy _matchStrategy;              
		private UInt32                          _refineMatchFactor;
		private UInt32                          _subpixelMatchFactor;

		
		public void ConvertFromExternal(MatchGeometricPatternEdgeBasedAdvancedOptions options)
		{
			_subpixelIterations = options.SubpixelIterations;
			_subpixelTolerance = options.SubpixelTolerance;
			_initialMatchListLength = options.InitialMatchListLength;
			_targetTemplateCurveScore = (options.TargetTemplateCurveScore) ? 1:0;
			_correlationScore = (options.CorrelationScore) ? 1:0;
			_minMatchSeparationDistance = options.MinimumMatchSeparationDistance;
			_minMatchSeparationAngle = options.MinimumMatchSeparationAngle;
			_minMatchSeparationScale = options.MinimumMatchSeparationScale;
			_maxMatchOverlap = options.MaximumMatchOverlap;
			_coarseResult = (options.CoarseResult)?1:0;
			_enableCalibrationSupport = (options.EnableCalibrationSupport)?1:0;
			_enableContrastReversal = options.ContrastMode;
			_matchStrategy = options.MatchStrategy;
			_refineMatchFactor = options.RefineMatchFactor;
			_subpixelMatchFactor = options.SubpixelMatchFactor;     
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CircleFeature : IHasExternalVersionOut<CircleFeature>
	{
		private CVI_PointFloat _position;
		private double _radius;

		
		public CircleFeature ConvertToExternal()
		{
			CircleFeature feature = new CircleFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Radius = _radius;
			return feature;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EllipseFeature :IHasExternalVersionOut<EllipseFeature>
	{
		private CVI_PointFloat _position;
		private double _rotation;
		private double _minorRadius;
		private double _majorRadius;

		
		public EllipseFeature ConvertToExternal()
		{
			EllipseFeature feature = new EllipseFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Rotation = _rotation;
			feature.MinorRadius = _minorRadius;
			feature.MajorRadius = _majorRadius;
			return feature;
		}
	}


#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ConstCurveFeature : IHasExternalVersionOut<ConstCurveFeature>
	{
		private CVI_PointFloat _position;
		private double _radius;
		private double _startAngle;
		private double _endAngle;

		
		public ConstCurveFeature ConvertToExternal()
		{
			ConstCurveFeature feature = new ConstCurveFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Radius = _radius;
			feature.StartAngle = _startAngle;
			feature.EndAngle = _endAngle;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RectangleFeature : IHasExternalVersionOut<RectangleFeature>
	{
		private CVI_PointFloat _position;
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;
		private double _rotation;
		private double _width;
		private double _height;

		
		public RectangleFeature ConvertToExternal()
		{
			RectangleFeature feature = new RectangleFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Corners.Add(_corner0.ConvertToExternal());
			feature.Corners.Add(_corner1.ConvertToExternal());
			feature.Corners.Add(_corner2.ConvertToExternal());
			feature.Corners.Add(_corner3.ConvertToExternal());
			feature.Rotation = _rotation;
			feature.Width = _width;
			feature.Height = _height;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LegFeature : IHasExternalVersionOut<LegFeature>
	{
		private CVI_PointFloat _position;
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;
		private double _rotation;
		private double _width;
		private double _height;

		
		public LegFeature ConvertToExternal()
		{
			LegFeature feature = new LegFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Corners.Add(_corner0.ConvertToExternal());
			feature.Corners.Add(_corner1.ConvertToExternal());
			feature.Corners.Add(_corner2.ConvertToExternal());
			feature.Corners.Add(_corner3.ConvertToExternal());
			feature.Rotation = _rotation;
			feature.Width = _width;
			feature.Height = _height;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CornerFeature : IHasExternalVersionOut<CornerFeature>
	{
		private CVI_PointFloat _position;
		private double _rotation;
		private double _enclosedAngle;
		private Int32 _isVirtual;

		
		public CornerFeature ConvertToExternal()
		{
			CornerFeature feature = new CornerFeature();
			feature.Position = _position.ConvertToExternal();
			feature.Rotation = _rotation;
			feature.EnclosedAngle = _enclosedAngle;
			feature.IsVirtual = _isVirtual != 0;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParallelLinePairFeature : IHasExternalVersionOut<ParallelLinePairFeature>
	{
		private CVI_PointFloat _firstStartPoint;
		private CVI_PointFloat _firstEndPoint;
		private CVI_PointFloat _secondStartPoint;
		private CVI_PointFloat _secondEndPoint;
		private double _rotation;
		private double _distance;

		
		public ParallelLinePairFeature ConvertToExternal()
		{
			ParallelLinePairFeature feature = new ParallelLinePairFeature();
			feature.FirstLine = new LineContour(_firstStartPoint.ConvertToExternal(), _firstEndPoint.ConvertToExternal());
			feature.SecondLine = new LineContour(_secondStartPoint.ConvertToExternal(), _secondEndPoint.ConvertToExternal());
			feature.Rotation = _rotation;
			feature.Distance = _distance;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PairOfParallelLinePairsFeature : IHasExternalVersionOut<PairOfParallelLinePairsFeature>
	{
		private CVI_ParallelLinePairFeature _firstParallelLinePair;
		private CVI_ParallelLinePairFeature _secondParallelLinePair;
		private double _rotation;
		private double _distance;

		
		public PairOfParallelLinePairsFeature ConvertToExternal()
		{
			PairOfParallelLinePairsFeature feature = new PairOfParallelLinePairsFeature();
			feature.FirstParallelLinePair = _firstParallelLinePair.ConvertToExternal();
			feature.SecondParallelLinePair = _secondParallelLinePair.ConvertToExternal();
			feature.Rotation = _rotation;
			feature.Distance = _distance;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineFeature : IHasExternalVersionOut<LineFeature>
	{
		private CVI_PointFloat _startPoint;
		private CVI_PointFloat _endPoint;
		private double _length;
		private double _rotation;

		
		public LineFeature ConvertToExternal()
		{
			LineFeature feature = new LineFeature();
			feature.Line = new LineContour(_startPoint.ConvertToExternal(), _endPoint.ConvertToExternal());
			feature.Length = _length;
			feature.Rotation = _rotation;
			return feature;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClosedCurveFeature : IHasExternalVersionOut<ClosedCurveFeature>
	{
		private CVI_PointFloat _position;
		private double _arcLength;

		
		public ClosedCurveFeature ConvertToExternal()
		{
			ClosedCurveFeature feature = new ClosedCurveFeature();
			feature.Position = _position.ConvertToExternal();
			feature.ArcLength = _arcLength;
			return feature;
		}
	}

	
	[StructLayout(LayoutKind.Explicit)]
	internal struct CVI_GeometricFeature
	{
		[FieldOffset(0)] private unsafe CVI_CircleFeature* _circle;
		[FieldOffset(0)] private unsafe CVI_EllipseFeature* _ellipse;
		[FieldOffset(0)] private unsafe CVI_ConstCurveFeature* _constCurve;
		[FieldOffset(0)] private unsafe CVI_RectangleFeature* _rectangle;
		[FieldOffset(0)] private unsafe CVI_LegFeature* _leg;
		[FieldOffset(0)] private unsafe CVI_CornerFeature* _corner;
		[FieldOffset(0)] private unsafe CVI_ParallelLinePairFeature* _parallelLinePair;
		[FieldOffset(0)] private unsafe CVI_PairOfParallelLinePairsFeature* _pairOfParallelLinePairs;
		[FieldOffset(0)] private unsafe CVI_LineFeature* _line;
		[FieldOffset(0)] private unsafe CVI_ClosedCurveFeature* _closedCurve;

		
		internal unsafe CVI_ClosedCurveFeature* ClosedCurve
		{
			get { return _closedCurve; }
			set { _closedCurve = value; }
		}

		
		internal unsafe CVI_LineFeature* Line
		{
			get { return _line; }
			set { _line = value; }
		}

		
		internal unsafe CVI_PairOfParallelLinePairsFeature* PairOfParallelLinePairs
		{
			get { return _pairOfParallelLinePairs; }
			set { _pairOfParallelLinePairs = value; }
		}

		
		internal unsafe CVI_ParallelLinePairFeature* ParallelLinePair
		{
			get { return _parallelLinePair; }
			set { _parallelLinePair = value; }
		}

		
		internal unsafe CVI_CornerFeature* Corner
		{
			get { return _corner; }
			set { _corner = value; }
		}

		
		internal unsafe CVI_LegFeature* Leg
		{
			get { return _leg; }
			set { _leg = value; }
		}

		
		internal unsafe CVI_RectangleFeature* Rectangle
		{
			get { return _rectangle; }
			set { _rectangle = value; }
		}

		
		internal unsafe CVI_ConstCurveFeature* ConstCurve
		{
			get { return _constCurve; }
			set { _constCurve = value; }
		}

		
		internal unsafe CVI_EllipseFeature* Ellipse
		{
			get { return _ellipse; }
			set { _ellipse = value; }
		}

		
		internal unsafe CVI_CircleFeature* Circle
		{
			get { return _circle; }
			set { _circle = value; }
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FeatureData : IHasExternalVersionOut<GeometricFeatureData>
	{
		private GeometricFeatureType _type;
		private IntPtr _contourPoints;
		private Int32 _numContourPoints;
		private CVI_GeometricFeature _feature;

		
		public unsafe GeometricFeatureData ConvertToExternal()
		{
			GeometricFeatureData featureData = new GeometricFeatureData(_type);
			featureData.ContourPoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointFloat>(_contourPoints, _numContourPoints, false);
			object feature = new object();
			switch (_type)
			{
				case GeometricFeatureType.Circle:
					feature = _feature.Circle->ConvertToExternal();
					break;
				case GeometricFeatureType.Ellipse:
					feature = _feature.Ellipse->ConvertToExternal();
					break;
				case GeometricFeatureType.ConstCurve:
					feature = _feature.ConstCurve->ConvertToExternal();
					break;
				case GeometricFeatureType.Rectangle:
					feature = _feature.Rectangle->ConvertToExternal();
					break;
				case GeometricFeatureType.Leg:
					feature = _feature.Leg->ConvertToExternal();
					break;
				case GeometricFeatureType.Corner:
					feature = _feature.Corner->ConvertToExternal();
					break;
				case GeometricFeatureType.ParallelLinePair:
					feature = _feature.ParallelLinePair->ConvertToExternal();
					break;
				case GeometricFeatureType.PairOfParallelLinePairs:
					feature = _feature.PairOfParallelLinePairs->ConvertToExternal();
					break;
				case GeometricFeatureType.Line:
					feature = _feature.Line->ConvertToExternal();
					break;
				case GeometricFeatureType.ClosedCurve:
					feature = _feature.ClosedCurve->ConvertToExternal();
					break;
			}
			featureData.Feature = feature;
			return featureData;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GeometricPatternMatch2 : IHasExternalVersionOut<GeometricFeatureBasedPatternMatch>
	{
		private CVI_PointFloat _position;
		private float _rotation;
		private float _scale;
		private float _score;
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;
		private Int32 _inverse;
		private float _occlusion;
		private float _templateMatchCurveScore;
		private float _matchTemplateCurveScore;
		private float _correlationScore;
		private CVI_String255 _label;
		private IntPtr _featureData;
		private Int32 _numFeatureData;
		private CVI_PointFloat _calibratedPosition;
		private float _calibratedRotation;
		private CVI_PointFloat _calibratedCorner0;
		private CVI_PointFloat _calibratedCorner1;
		private CVI_PointFloat _calibratedCorner2;
		private CVI_PointFloat _calibratedCorner3;

		
		public GeometricFeatureBasedPatternMatch ConvertToExternal()
		{
			GeometricFeatureBasedPatternMatch match = new GeometricFeatureBasedPatternMatch();
			match.Position = _position.ConvertToExternal();
			match.Rotation = _rotation;
			match.Scale = _scale;
			match.Score = _score;
			match.Corners.Add(_corner0.ConvertToExternal());
			match.Corners.Add(_corner1.ConvertToExternal());
			match.Corners.Add(_corner2.ConvertToExternal());
			match.Corners.Add(_corner3.ConvertToExternal());
			match.Inverse = _inverse != 0;
			match.Occlusion = _occlusion;
			match.TemplateMatchCurveScore = _templateMatchCurveScore;
			match.MatchTemplateCurveScore = _matchTemplateCurveScore;
			match.CorrelationScore = _correlationScore;
			// Ignoring label since we don't support matching multiple geometric patterns
			match.Features = Utilities.ConvertIntPtrToCollection<GeometricFeatureData, CVI_FeatureData>(_featureData, _numFeatureData, false);
			match.CalibratedPosition = _calibratedPosition.ConvertToExternal();
			match.CalibratedRotation = _calibratedRotation;
			match.CalibratedCorners.Add(_calibratedCorner0.ConvertToExternal());
			match.CalibratedCorners.Add(_calibratedCorner1.ConvertToExternal());
			match.CalibratedCorners.Add(_calibratedCorner2.ConvertToExternal());
			match.CalibratedCorners.Add(_calibratedCorner3.ConvertToExternal());
			return match;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GeometricPatternMatch3 : IHasExternalVersionOut<GeometricEdgeBasedPatternMatch>
	{
		private CVI_PointFloat _position;
		private float _rotation;
		private float _scale;
		private float _score;
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;
		private Int32 _inverse;
		private float _occlusion;
		private float _templateMatchCurveScore;
		private float _matchTemplateCurveScore;
		private float _correlationScore;
		private CVI_PointFloat _calibratedPosition;
		private float _calibratedRotation;
		private CVI_PointFloat _calibratedCorner0;
		private CVI_PointFloat _calibratedCorner1;
		private CVI_PointFloat _calibratedCorner2;
		private CVI_PointFloat _calibratedCorner3;

		
		public GeometricEdgeBasedPatternMatch ConvertToExternal()
		{
			GeometricEdgeBasedPatternMatch toReturn = new GeometricEdgeBasedPatternMatch();
			toReturn.Corners.Add(new PointContour(_corner0.X, _corner0.Y));
			toReturn.Corners.Add(new PointContour(_corner1.X, _corner1.Y));
			toReturn.Corners.Add(new PointContour(_corner2.X, _corner2.Y));
			toReturn.Corners.Add(new PointContour(_corner3.X, _corner3.Y));
			toReturn.Position.X = _position.X;
			toReturn.Position.Y = _position.Y;
			toReturn.Rotation = _rotation;
			toReturn.Scale = _scale;
			toReturn.Score = _score;
			toReturn.Inverse = (_inverse > 0) ? true : false;
			toReturn.Occlusion = _occlusion;
			toReturn.TemplateMatchCurveScore = _templateMatchCurveScore;
			toReturn.MatchTemplateCurveScore = _matchTemplateCurveScore;
			toReturn.CorrelationScore = _correlationScore;
			toReturn.CalibratedPosition.X = _calibratedPosition.X;
			toReturn.CalibratedPosition.Y = _calibratedPosition.Y;
			toReturn.CalibratedRotation = _calibratedRotation;
			toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner0.X, _calibratedCorner0.Y));
			toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner1.X, _calibratedCorner1.Y));
			toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner2.X, _calibratedCorner2.Y));
			toReturn.CalibratedCorners.Add(new PointContour(_calibratedCorner3.X, _calibratedCorner3.Y));

			return toReturn;
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
    internal struct CVI_CalibrationPoints : IHasExternalVersionIn<Collection<PointContour>, Collection<PointContour>>, IDisposable
	{
		private IntPtr _pixelCoordinates;
		private IntPtr _realWorldCoordinates;
		private Int32 _numCoordinates;

		
		public void ConvertFromExternal(Collection<PointContour> pixelCoords, Collection<PointContour> realWorldCoords)
		{
			// Since we're going in through CVI, we need to validate that we have the same number of points in both
			// collections and throw an error if not.
			if (pixelCoords.Count != realWorldCoords.Count)
			{
				throw new VisionException(ErrorCode.IncompMatrixSize);
			}
			_numCoordinates = pixelCoords.Count;
			_pixelCoordinates = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointFloat>(pixelCoords);
			_realWorldCoordinates = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointFloat>(realWorldCoords);
		}

		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		private void Dispose(bool disposing) {
			// Since _pixelCoordinates and _realWorldCoordinates are unmanaged, it's OK to access them here (even though we may be
			// called during finalization if disposing == false)
			if (_pixelCoordinates != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_pixelCoordinates);
				_pixelCoordinates = IntPtr.Zero;
			}
			if (_realWorldCoordinates != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_realWorldCoordinates);
				_realWorldCoordinates = IntPtr.Zero;
			}
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_TextureFeaturesReport : IHasExternalVersionOut<TextureFeaturesReport>
	{
		private IntPtr _waveletBands;
		private int _numWaveletBands;
		private IntPtr _textureFeatures;
		private int _textureFeaturesRows;
		private int _textureFeaturesCols;

		
		public TextureFeaturesReport ConvertToExternal()
		{
			double[,] textureFeaturesArray = Utilities.ConvertIntPtrIndirectTo2DArrayDouble(_textureFeatures, _textureFeaturesRows, _textureFeaturesCols, false);
			if (_waveletBands == IntPtr.Zero)
			{
				return new TextureFeaturesReport(textureFeaturesArray);
			}
			else
			{
                return new TextureFeaturesReport(textureFeaturesArray, Utilities.ConvertIntPtrToCollection<int>(_waveletBands, _numWaveletBands, false));
			}
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_WaveletBandsReport : IHasExternalVersionOut<WaveletBandsReport>
	{
		private IntPtr _LL;
		private IntPtr _LH;
		private IntPtr _HL;
		private IntPtr _HH;
		private IntPtr _LLL;
		private IntPtr _LLH;
		private IntPtr _LHL;
		private IntPtr _LHH;
		private Int32 _rows;
		private Int32 _cols;

		
		public WaveletBandsReport ConvertToExternal()
		{
			float[,] LLBand;
			float[,] LHBand;
			float[,] HLBand;
			float[,] HHBand;
			float[,] LLLBand;
			float[,] LLHBand;
			float[,] LHLBand;
			float[,] LHHBand;
			if (_LL != IntPtr.Zero)
			{
                LLBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LL, _rows, _cols, false);
			}
			else
			{
				LLBand = new float[0, 0];
			}
			if (_LH != IntPtr.Zero)
			{
                LHBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LH, _rows, _cols, false);
			}
			else
			{
				LHBand = new float[0, 0];
			}
			if (_HL != IntPtr.Zero)
			{
                HLBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_HL, _rows, _cols, false);
			}
			else
			{
				HLBand = new float[0, 0];
			}
			if (_HH != IntPtr.Zero)
			{
                HHBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_HH, _rows, _cols, false);
			}
			else
			{
				HHBand = new float[0, 0];
			}
			if (_LLL != IntPtr.Zero)
			{
                LLLBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LLL, _rows, _cols, false);
			}
			else
			{
				LLLBand = new float[0, 0];
			}
			if (_LLH != IntPtr.Zero)
			{
                LLHBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LLH, _rows, _cols, false);
			}
			else
			{
				LLHBand = new float[0, 0];
			}
			if (_LHL != IntPtr.Zero)
			{
                LHLBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LHL, _rows, _cols, false);
			}
			else
			{
				LHLBand = new float[0, 0];
			}
			if (_LHH != IntPtr.Zero)
			{
                LHHBand = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_LHH, _rows, _cols, false);
			}
			else
			{
				LHHBand = new float[0, 0];
			}
			WaveletBandsReport toReturn = new WaveletBandsReport(LLBand, LHBand, HLBand, HHBand, LLLBand, LLHBand, LHLBand, LHHBand, _rows, _cols);
			return toReturn;
		}

	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_TransformReport : IHasExternalVersionOut<CoordinatesReport>
	{
		private IntPtr _points;
		private IntPtr _validPoints;
		private Int32 _numCoordinates;

		
		public CoordinatesReport ConvertToExternal()
		{
			CoordinatesReport report = new CoordinatesReport();
			if (_points == IntPtr.Zero)
			{
				report.Points = new Collection<PointContour>();
				report.ValidPoints = new Collection<bool>();
			}
			else
			{
				report.Points = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointFloat>(_points, _numCoordinates, false);
				// We're not gonna be converting arrays like this much, so just do it by hand.
				Int32[] tempValidPoints = Utilities.ConvertIntPtrTo1DStructureArray<Int32>(_validPoints, _numCoordinates, false);
				Collection<bool> valids = new Collection<bool>();
				for (Int32 i = 0; i < _numCoordinates; ++i)
				{
					valids.Add(tempValidPoints[i] != 0);
				}
				report.ValidPoints = valids;
			}
			return report;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_IMAQRectangle : IHasExternalVersionOut<RectangleContour>
	{
		private float _left;
		private float _top;
		private float _width;
		private float _height;

		
		public RectangleContour ConvertToExternal()
		{
			return new RectangleContour(_left, _top, _width, _height);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct VB_ParticleReport : IHasExternalVersionOut<ParticleReport>
	{
		private float _area;
		private Int32 _numberOfHoles;
		private VB_IMAQRectangle _boundingRect;
		private CVI_PointFloat _centerOfMass;
		private float _orientation;

		
		public ParticleReport ConvertToExternal()
		{
			ParticleReport report = new ParticleReport();
			report.Area = _area;
			report.BoundingRect = _boundingRect.ConvertToExternal();
			report.CenterOfMass = _centerOfMass.ConvertToExternal();
			report.NumberOfHoles = _numberOfHoles;
			report.Orientation = _orientation;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_WindowOptions : IHasExternalVersionIn<WindowOptions>
	{
		private Int32 _x;
		private Int32 _y;
		private Int32 _stepSize;

		
        public void ConvertFromExternal(WindowOptions item)
		{
			_x = item.X;
			_y = item.Y;
			_stepSize = item.StepSize;
		}

		
        public WindowOptions ConvertToExternal()
		{
            WindowOptions windowOptions = new WindowOptions();
            windowOptions.X = _x;
            windowOptions.Y = _y;
            windowOptions.StepSize = _stepSize;
            return windowOptions;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DisplacementVector : IHasExternalVersionIn<DisplacementVector>
	{
		private int _x;
		private int _y;

		
		public void ConvertFromExternal(DisplacementVector item)
		{
			_x = item.X;
			_y = item.Y;
		}

		public DisplacementVector ConvertToExternal()
		{
			DisplacementVector item = new DisplacementVector();
			item.X = _x;
			item.Y = _y;
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_WaveletOptions : IHasExternalVersionIn<WaveletOptions>
	{
		private WaveletType _typeOfWavelet;
		private float _minEnergy;

		
		public void ConvertFromExternal(WaveletOptions item)
		{
			_typeOfWavelet = item.Wavelet_Type;
			_minEnergy = (float)item.MinEnergy;
		}

		
		public WaveletOptions ConvertToExternal()
		{
			WaveletOptions item = new WaveletOptions();
			item.MinEnergy = _minEnergy;
			item.Wavelet_Type = _typeOfWavelet;
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CooccurrenceOptions : IHasExternalVersionIn<CooccurrenceOptions>
	{
		private Int32 _level;
		private CVI_DisplacementVector _displacement;

		
		public void ConvertFromExternal(CooccurrenceOptions item)
		{
			_level = item.Level;
			_displacement = new CVI_DisplacementVector();
			_displacement.ConvertFromExternal(item.Displacement);
		}

		
		public CooccurrenceOptions ConvertToExternal()
		{
			CooccurrenceOptions item = new CooccurrenceOptions();
			item.Displacement = _displacement.ConvertToExternal();
			item.Level = _level;
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CurveParameters : IHasExternalVersionIn<CurveParameters>
    {
        private ExtractionMode _extractionMode;
        private Int32 _threshold;
        private EdgeFilterSize _filterSize;
        private Int32 _minLength;
        private Int32 _searchStepSize;
        private Int32 _maxEndPointGap;
        private Int32 _subpixelAccuracy;

        
        public void ConvertFromExternal(CurveParameters parameters)
        {
            _extractionMode = parameters.ExtractionMode;
            _threshold = parameters.Threshold;
            _filterSize = parameters.FilterSize;
            _minLength = parameters.MinimumLength;
            _searchStepSize = parameters.SearchStepSize;
            _maxEndPointGap = parameters.MaximumEndPointGap;
            _subpixelAccuracy = parameters.SubpixelAccuracy ? 1 : 0;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ConnectionConstraint : IHasExternalVersionIn<ConnectionConstraint>
    {
        private ConnectionConstraintType _constraintType;
        private CVI_RangeDouble _range;

        
        public void ConvertFromExternal(ConnectionConstraint constraint)
        {
            _constraintType = constraint.ConstraintType;
            _range.ConvertFromExternal(constraint.Range);
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourOverlaySettings : IHasExternalVersionIn<ContourOverlaySettings>
    {
        private UInt32 _overlay;
        private Rgb32Value _color;
        private UInt32 _width;
        private UInt32 _maintainWidth;

        
        public void ConvertFromExternal(ContourOverlaySettings settings)
        {
            _overlay = (UInt32)(settings.Overlay ? 1 : 0);
            _color = settings.Color;
            _width = settings.Width;
            _maintainWidth = (UInt32)(settings.MaintainWidth ? 1 : 0);
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RangeLabel : IHasExternalVersionIn<RangeLabel>
    {
        private CVI_RangeDouble _range;
        private UInt32 _label;

        
        public void ConvertFromExternal(RangeLabel rangeLabel)
        {
            _range.ConvertFromExternal(rangeLabel.Range);
            _label = rangeLabel.Label;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SetupMatchPatternData : IHasExternalVersionIn<SetupMatchPatternData>, IHasExternalVersionOut<SetupMatchPatternData>
    {
        private IntPtr _matchPatternData;
        private UInt32 _numMatchPatternData;

        
        public void ConvertFromExternal(SetupMatchPatternData matchPatterData)
        {
            _matchPatternData = (matchPatterData.MatchPatternData.Count == 0) ? IntPtr.Zero : Utilities.ConvertCollectionToIntPtr<char>(matchPatterData.MatchPatternData);
            _numMatchPatternData = (UInt32)matchPatterData.MatchPatternData.Count;
        }

        public SetupMatchPatternData ConvertToExternal()
        {
            Collection<char> matchPatternData = Utilities.ConvertIntPtrToCollection<char>(_matchPatternData, _numMatchPatternData, false);
            SetupMatchPatternData report = new SetupMatchPatternData(matchPatternData);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourMatchMode : IHasExternalVersionIn<ContourMatchMode>
    {
        private UInt32 _rotation;
        private UInt32 _scale;
        private UInt32 _occlusion;

        
        public void ConvertFromExternal(ContourMatchMode matchMode)
        {
            _rotation = (UInt32)(matchMode.Rotation ? 1 : 0);
            _scale = (UInt32)(matchMode.Scale ? 1 : 0);
            _occlusion = (UInt32)(matchMode.Occlusion ? 1 : 0);
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RangeSettings : IHasExternalVersionIn<RangeSettings>
    {
        private SettingType _type;
        private double _minimum;
        private double _maximum;

        
        public void ConvertFromExternal(RangeSettings rangeSettings)
        {
            _type = rangeSettings.Type;
            _minimum = rangeSettings.Minimum;
            _maximum = rangeSettings.Maximum;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GeometricAdvancedSetupDataOption : IHasExternalVersionIn<GeometricAdvancedSetupDataOption>
    {
        private GeometricSetupData _type;
        private double _value;

        
        public void ConvertFromExternal(GeometricAdvancedSetupDataOption setupData)
        {
            // converting the enum value to short. direct conversion would result in error.
            _type = setupData.Type;
            _value = setupData.Value;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifiedCurve : IHasExternalVersionIn<ClassifiedCurve>, IHasExternalVersionOut<ClassifiedCurve>
    {
        private double _length;
        private double _lengthReal;
        private double _maxCurvature;
        private double _maxCurvatureReal;
        private UInt32 _label;
        private IntPtr _curvePoints;
        private UInt32 _numCurvePoints;

        public void ConvertFromExternal(ClassifiedCurve curves)
        {
            _length = curves.Length;
            _lengthReal = curves.LengthReal;
            _maxCurvature = curves.MaxCurvature;
            _maxCurvatureReal = curves.MaxCurvatureReal;
            _label = curves.Label;
            _curvePoints = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointDouble>(curves.CurvePoints);
        }

        
        public ClassifiedCurve ConvertToExternal()
        {
            Collection<PointContour> curvePoints;
            if (_curvePoints == IntPtr.Zero)
            {
                curvePoints = new Collection<PointContour>();
            }
            else
            {
                curvePoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_curvePoints, _numCurvePoints, false);
            }
            ClassifiedCurve curves = new ClassifiedCurve(_length, _lengthReal, _maxCurvature, _maxCurvatureReal, _label, curvePoints);
            return curves;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Disparity : IHasExternalVersionIn<Disparity>, IHasExternalVersionOut<Disparity>
    {
        private CVI_PointDouble _currentPoint;
        private CVI_PointDouble _referencePoint;
        private double _distance;

        
        public void ConvertFromExternal(Disparity disparity)
        {
            _currentPoint.ConvertFromExternal(disparity.CurrentPoint);
            _referencePoint.ConvertFromExternal(disparity.ReferencePoint);
            _distance = disparity.Distance;
        }

        
        public Disparity ConvertToExternal()
        {
            Disparity disparity = new Disparity(_currentPoint.ConvertToExternal(), _referencePoint.ConvertToExternal(), _distance);
            return disparity;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifiedDisparity : IHasExternalVersionIn<ClassifiedDisparity>, IHasExternalVersionOut<ClassifiedDisparity>
    {
        private double _length;
        private double _lengthReal;
        private double _maxDistance;
        private double _maxDistanceReal;
        private UInt32 _label;
        private IntPtr _templateSubsectionPoints;
        private UInt32 _numTemplateSubsectionPoints;
        private IntPtr _targetSubsectionPoints;
        private UInt32 _numTargetSubsectionPoints;

        
        public void ConvertFromExternal(ClassifiedDisparity classifiedDisparity)
        {
            _length = classifiedDisparity.Length;
            _lengthReal = classifiedDisparity.LengthReal;
            _maxDistance = classifiedDisparity.MaximumDistance;
            _maxDistanceReal = classifiedDisparity.MaximumDistanceReal;
            _label = classifiedDisparity.Label;
            _templateSubsectionPoints = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointDouble>(classifiedDisparity.TargetSubsectionPoints);
            _targetSubsectionPoints = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointDouble>(classifiedDisparity.TemplateSubsectionPoints);
        }

        
        public ClassifiedDisparity ConvertToExternal()
        {
            Collection<PointContour> templateSubsectionPoints, targetSubsectionPoints;
            if (_templateSubsectionPoints == IntPtr.Zero)
            {
                templateSubsectionPoints = new Collection<PointContour>();
            }
            else
            {
                templateSubsectionPoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_templateSubsectionPoints, _numTemplateSubsectionPoints, false);
            }

            if (_targetSubsectionPoints == IntPtr.Zero)
            {
                targetSubsectionPoints = new Collection<PointContour>();
            }
            else
            {
                targetSubsectionPoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_targetSubsectionPoints, _numTargetSubsectionPoints, false);
            }
            ClassifiedDisparity classifiedDisparity = new ClassifiedDisparity(_length, _lengthReal, _maxDistance, _maxDistanceReal, _label, templateSubsectionPoints, targetSubsectionPoints);
            return classifiedDisparity;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ExtractContourReport : IHasExternalVersionOut<ExtractContourReport>
    {
        private IntPtr _contourPoints;
        private UInt32 _numContourPoints;
        private IntPtr _sourcePoints;
        private UInt32 _numSourcePoints;

        
        public ExtractContourReport ConvertToExternal()
        {
            Collection<PointContour> contourPoints, sourcePoints;
            if (_contourPoints == IntPtr.Zero)
            {
                contourPoints = new Collection<PointContour>();
            }
            else
            {
                contourPoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_contourPoints, _numContourPoints, false);
            }

            if (_sourcePoints == IntPtr.Zero)
            {
                sourcePoints = new Collection<PointContour>();
            }
            else
            {
                sourcePoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_sourcePoints, _numSourcePoints, false);
            }
            ExtractContourReport report = new ExtractContourReport(contourPoints, sourcePoints);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourInfoReport : IHasExternalVersionOut<ContourInfoReport>
    {
        private IntPtr _contourPoints;
        private UInt32 _numContourPoints;
        private IntPtr _sourcePoints;
        private UInt32 _numSourcePoints;
        private IntPtr _curvaturePixel;
        private UInt32 _numCurvaturePixel;
        private IntPtr _curvatureReal;
        private UInt32 _numCurvatureReal;
        private double _length;
        private double _lengthReal;
        private bool _hasEquation;

        public ContourInfoReport ConvertToExternal()
        {
            Collection<PointContour> contourPoints, sourcePoints;
            Collection<double> curvaturePixel, curvatureReal;
            if (_contourPoints == IntPtr.Zero)
            {
                contourPoints = new Collection<PointContour>();
            }
            else
            {
                contourPoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_contourPoints, _numContourPoints, false);
            }

            if (_sourcePoints == IntPtr.Zero)
            {
                sourcePoints = new Collection<PointContour>();
            }
            else
            {
                sourcePoints = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_sourcePoints, _numSourcePoints, false);
            }

            if (_curvaturePixel == IntPtr.Zero)
            {
                curvaturePixel = new Collection<double>();
            }
            else
            {
                curvaturePixel = Utilities.ConvertIntPtrToCollection<double>(_curvaturePixel, _numCurvaturePixel, false);
            }

            if (_curvatureReal == IntPtr.Zero)
            {
                curvatureReal = new Collection<double>();
            }
            else
            {
                curvatureReal = Utilities.ConvertIntPtrToCollection<double>(_curvatureReal, _numCurvatureReal, false);
            }
            ContourInfoReport report = new ContourInfoReport(contourPoints, sourcePoints, curvaturePixel, curvatureReal, _length, _lengthReal, _hasEquation);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ComputeCurvatureReport : IHasExternalVersionOut<ComputeCurvatureReport>
    {
        private IntPtr _curvaturePixel;
        private UInt32 _numCurvaturePixel;
        private IntPtr _curvatureReal;
        private UInt32 _numCurvatureReal;

        
        public ComputeCurvatureReport ConvertToExternal()
        {
            Collection<double> curvaturePixel, curvatureReal;

            if (_curvaturePixel == IntPtr.Zero)
            {
                curvaturePixel = new Collection<double>();
            }
            else
            {
                curvaturePixel = Utilities.ConvertIntPtrToCollection<double>(_curvaturePixel, _numCurvaturePixel, false);
            }

            if (_curvatureReal == IntPtr.Zero)
            {
                curvatureReal = new Collection<double>();
            }
            else
            {
                curvatureReal = Utilities.ConvertIntPtrToCollection<double>(_curvatureReal, _numCurvatureReal, false);
            }
            ComputeCurvatureReport report = new ComputeCurvatureReport(curvaturePixel, curvatureReal);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifyCurvatureReport : IHasExternalVersionOut<ClassifyCurvatureReport>
    {
        private IntPtr _curves;
        private UInt32 _numCurves;

        
        public ClassifyCurvatureReport ConvertToExternal()
        {
            Collection<ClassifiedCurve> curves;

            if (_curves == IntPtr.Zero)
            {
                curves = new Collection<ClassifiedCurve>();
            }
            else
            {
                curves = Utilities.ConvertIntPtrToCollection<ClassifiedCurve, CVI_ClassifiedCurve>(_curves, _numCurves, false);
            }

            ClassifyCurvatureReport report = new ClassifyCurvatureReport(curves);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ComputeDistanceReport : IHasExternalVersionOut<ComputeDistanceReport>
    {
        private IntPtr _distances;
        private UInt32 _numDistances;
        private IntPtr _distancesReal;
        private UInt32 _numDistancesReal;

        
        public ComputeDistanceReport ConvertToExternal()
        {
            Collection<Disparity> distances, distancesReal;

            if (_distances == IntPtr.Zero)
            {
                distances = new Collection<Disparity>();
            }
            else
            {
                distances = Utilities.ConvertIntPtrToCollection<Disparity, CVI_Disparity>(_distances, _numDistances, false);
            }

            if (_distancesReal == IntPtr.Zero)
            {
                distancesReal = new Collection<Disparity>();
            }
            else
            {
                distancesReal = Utilities.ConvertIntPtrToCollection<Disparity, CVI_Disparity>(_distancesReal, _numDistancesReal, false);
            }
            ComputeDistanceReport report = new ComputeDistanceReport(distances, distancesReal);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifyDistancesReport : IHasExternalVersionOut<ClassifyDistancesReport>
    {
        private IntPtr _classifiedDistances;
        private UInt32 _numClassifiedDistances;

        
        public ClassifyDistancesReport ConvertToExternal()
        {
            Collection<ClassifiedDisparity> classifiedDistance;

            if (_classifiedDistances == IntPtr.Zero)
            {
                classifiedDistance = new Collection<ClassifiedDisparity>();
            }
            else
            {
                classifiedDistance = Utilities.ConvertIntPtrToCollection<ClassifiedDisparity, CVI_ClassifiedDisparity>(_classifiedDistances, _numClassifiedDistances, false);
            }

            ClassifyDistancesReport report = new ClassifyDistancesReport(classifiedDistance);
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ROILabel : IHasExternalVersionIn<ROILabel>, IHasExternalVersionOut<ROILabel>
    {
        [MarshalAs(UnmanagedType.LPStr)] private string _className;
        private UInt32 _label;

        
        public void ConvertFromExternal(ROILabel label)
        {
            _className = label.ClassName;
            _label = label.Label;
        }

        public ROILabel ConvertToExternal()
        {
            return new ROILabel(_className, _label);
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ColorSegmentationOptions : IHasExternalVersionIn<ColorSegmentationOptions>
    {
        private UInt32 _windowX;
        private UInt32 _windowY;
        private UInt32 _stepSize;
        private UInt32 _minParticleArea;
        private UInt32 _maxParticleArea;
        private int _isFineSegment;

        
        public void ConvertFromExternal(ColorSegmentationOptions external)
        {
            _windowX = external.WindowX;
            _windowY = external.WindowY;
            _stepSize = external.StepSize;
            _minParticleArea = external.MinParticleArea;
            _maxParticleArea = external.MaxParticleArea;
            _isFineSegment = (external.IsFineSegment) ? 1 : 0;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ColorSegmentationReport : IHasExternalVersionOut<Collection<ROILabel>>
    {
        private IntPtr _cviLabelsOut;
        private UInt32 _numLabelsOut;

        
        public Collection<ROILabel> ConvertToExternal()
        {
            Collection<ROILabel> toReturn = new Collection<ROILabel>();
            if (_numLabelsOut > 0)
            {
                toReturn = Utilities.ConvertIntPtrToCollection<ROILabel, CVI_ROILabel>(_cviLabelsOut, _numLabelsOut, false);
            }
            return toReturn;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LabelToROIReport : IHasExternalVersionOut<LabelToROIReport>
    {
        private IntPtr _roiArray;
        private UInt32 _numOfROIs;
        private IntPtr _labelsOutArray;
        private UInt32 _numOfLabels;
        private IntPtr _isTooManyVectorsArray;
        private UInt32 _isTooManyVectorsArraySize;

        
        public LabelToROIReport ConvertToExternal()
        {
            LabelToROIReport toReturn = new LabelToROIReport();
            if (_numOfLabels > 0) 
            {
                toReturn.LabelsOut = Utilities.ConvertIntPtrToCollection<UInt32>(_labelsOutArray, _numOfLabels, false);
            } else
            {
                toReturn.LabelsOut = new Collection<UInt32>();
            }
            if (_numOfROIs > 0)
            {
                IntPtr[] roiPtrs = Utilities.ConvertIntPtrTo1DStructureArray<IntPtr>(_roiArray, _numOfROIs, false);
                Collection<Roi> roiArray = new Collection<Roi>();
                foreach (IntPtr val in roiPtrs)
                {
                    roiArray.Add(new Roi(val));
                }
                toReturn.Rois = roiArray;
            }
            else
            {
                toReturn.Rois = new Collection<Roi>();
            }
            if (_isTooManyVectorsArraySize > 0)
            {
                Collection<int> isTooManyVectorsArray = Utilities.ConvertIntPtrToCollection<int>(_isTooManyVectorsArray, _isTooManyVectorsArraySize, false);
                Collection<bool> TooManyVectors = new Collection<bool>();
                int index = 0;
                for (; index < _isTooManyVectorsArraySize; ++index)
                {
                    TooManyVectors.Add((isTooManyVectorsArray[index] == 0) ? false : true);
                }
                toReturn.IsTooManyVectors = TooManyVectors;
            }
            else
            {
                toReturn.IsTooManyVectors = new Collection<bool>();
            }
            return toReturn;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourFitLineReport : IHasExternalVersionOut<ContourFitLineReport>
    {
        private CVI_LineSegment _lineSegment;
        private CVI_LineEquation _equation;

        
        public ContourFitLineReport ConvertToExternal()
        {
            ContourFitLineReport report = new ContourFitLineReport();
            report.lineSegment = _lineSegment.ConvertToExternal();
            report.equation = _equation.ConvertToExternal();
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PartialCircle : IHasExternalVersionOut<PartialCircle>
    {
        private CVI_PointFloat _center;
        private double _radius;
        private double _startAngle;
        private double _endAngle;

        
        public PartialCircle ConvertToExternal()
        {
            PartialCircle report = new PartialCircle();
            report.Center = _center.ConvertToExternal();
            report.Radius = _radius;
            report.StartAngle = _startAngle;
            report.EndAngle = _endAngle;
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PartialEllipse : IHasExternalVersionOut<PartialEllipse>
    {
        private CVI_PointFloat _center;
        private double _angle;
        private double _majorRadius;
        private double _minorRadius;
        private double _startAngle;
        private double _endAngle;

        
        public PartialEllipse ConvertToExternal()
        {
            PartialEllipse report = new PartialEllipse();
            report.Center = _center.ConvertToExternal();
            report.Angle = _angle;
            report.MajorRadius = _majorRadius;
            report.MinorRadius = _minorRadius;
            report.StartAngle = _startAngle;
            report.EndAngle = _endAngle;
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourFitSplineReport : IHasExternalVersionOut<ContourFitSplineReport>
    {
        private IntPtr _points;
        private UInt32 _numberOfPoints;

        
        public ContourFitSplineReport ConvertToExternal()
        {
            ContourFitSplineReport report = new ContourFitSplineReport();
            report.Points = new Collection<PointContour>();
            if (_numberOfPoints > 0)
            {
                Collection<CVI_PointDouble> points = Utilities.ConvertIntPtrToCollection<CVI_PointDouble>(_points, _numberOfPoints, false);
                foreach (CVI_PointDouble val in points)
                {
                    report.Points.Add(val.ConvertToExternal());
                }
            }
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourFitPolynomialReport : IHasExternalVersionOut<ContourFitPolynomialReport>
    {
        private IntPtr _points;
        private UInt32 _numberOfPoints;
        private IntPtr _coefficients;
        private UInt32 _numberOfCoefficients;

        
        public ContourFitPolynomialReport ConvertToExternal()
        {
            ContourFitPolynomialReport report = new ContourFitPolynomialReport();
            if (_numberOfPoints > 0)
            {
                report.Points = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_points, _numberOfPoints, false);
            }
            else
            {
                report.Points = new Collection<PointContour>();
            }
            if (_numberOfCoefficients > 0)
            {
                report.PolynomialCoefficients = Utilities.ConvertIntPtrToCollection<double>(_coefficients, _numberOfCoefficients, false);
            }
            else
            {
                report.PolynomialCoefficients = new Collection<double>();
            }
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EdgePolarityClamp : IHasExternalVersionOut<EdgePolarityClamp>, IHasExternalVersionIn<EdgePolarityClamp>
    {
        private EdgePolaritySearchMode _start;
        private EdgePolaritySearchMode _end;

        
        public EdgePolarityClamp ConvertToExternal()
        {
            return new EdgePolarityClamp(_start, _end);
        }

        public void ConvertFromExternal(EdgePolarityClamp edgePolarityClamp)
        {
            _start = edgePolarityClamp.Start;
            _end = edgePolarityClamp.End;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClampSettings : IHasExternalVersionIn<ClampSettings>
    {
        private double _angleRange;
        private CVI_EdgePolarityClamp _edgePolarity;

        
        public void ConvertFromExternal(ClampSettings settings)
        {
            _angleRange = settings.AngleRange;
            _edgePolarity.ConvertFromExternal(settings.EdgePolarity);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClampOverlaySettings : IHasExternalVersionIn<ClampOverlaySettings>
    {
        private Int32 _showSearchArea;
        private Int32 _showCurves;
        private Int32 _showClampLocations;
        private Int32 _showResult;
        private Rgb32Value _searchAreaColor;
        private Rgb32Value _curvesColor;
        private Rgb32Value _clampLocationsColor;
        private Rgb32Value _resultColor;
        private String _overlayGroupName;

        public void ConvertFromExternal(ClampOverlaySettings settings)
        {
            _showSearchArea = settings.ShowSearchArea ? 1 : 0;
            _showCurves = settings.ShowCurves ? 1 : 0;
            _showClampLocations = settings.ShowClampLocations ? 1 : 0;
            _showResult = settings.ShowResult ? 1 : 0;
            _searchAreaColor = settings.SearchAreaColor;
            _curvesColor = settings.CurvesColor;
            _clampLocationsColor = settings.ClampLocationsColor;
            _resultColor = settings.ResultColor;
            _overlayGroupName = settings.OverlayGroupName;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClampResults : IHasExternalVersionOut<ClampResults>
    {
        private double _distancePix;
        private double _distanceRealWorld;
        private double _angleAbs;
        private double _angleRelative;

        
        public ClampResults ConvertToExternal()
        {
            return new ClampResults(_distancePix, _distanceRealWorld, _angleAbs, _angleRelative);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PointPairDouble : IHasExternalVersionOut<PointPairDouble>
    {
        private CVI_PointDouble _start;
        private CVI_PointDouble _end;

        
        public PointPairDouble ConvertToExternal()
        {
            return new PointPairDouble(_start.ConvertToExternal(), _end.ConvertToExternal());
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClampPoints : IHasExternalVersionOut<ClampPoints>
    {
        private CVI_PointPairDouble _pixels;
        private CVI_PointPairDouble _realWorld;

        
        public ClampPoints ConvertToExternal()
        {
            return new ClampPoints(_pixels.ConvertToExternal(), _realWorld.ConvertToExternal());
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClampMaxReport : IHasExternalVersionOut<ClampMaxReport>
    {
        private CVI_ClampResults _clampResults;
        private CVI_ClampPoints _clampPoints;
        private UInt32 _calibrationValid;

        
        public ClampMaxReport ConvertToExternal()
        {
            ClampMaxReport report = new ClampMaxReport();
            report.ClampResults = _clampResults.ConvertToExternal();
            report.ClampPoints = _clampPoints.ConvertToExternal();
            report.CalibrationValid = _calibrationValid != 0 ? true : false;
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_PolyModel : IHasExternalVersionOut<PolyModel>, IHasExternalVersionIn<PolyModel>
    {
        private IntPtr _kCoefficients;
        private Int32 _numKCoefficients;        
        private float _p1;
        private float _p2;

        
        public PolyModel ConvertToExternal()
        {
            Collection<float> kCoefficients;
            if (_numKCoefficients > 0)
            {
                kCoefficients = Utilities.ConvertIntPtrToCollection<float>(_kCoefficients, _numKCoefficients, false);
            }
            else
            {
                kCoefficients = new Collection<float>();
            }

            return new PolyModel(kCoefficients, _p1, _p2);
        }

        public void ConvertFromExternal(PolyModel polyModel)
        {
            _kCoefficients = Utilities.ConvertCollectionToIntPtr<float>(polyModel.KCoefficients);
            _numKCoefficients = polyModel.KCoefficients.Count;
            _p1 = polyModel.P1;
            _p2 = polyModel.P2;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DivModel : IHasExternalVersionOut<DivModel>, IHasExternalVersionIn<DivModel>
    {
        private float _kappa;

        
        public DivModel ConvertToExternal()
        {
            return new DivModel(_kappa);
        }

        public void ConvertFromExternal(DivModel divModel)
        {
            _kappa = divModel.Kappa;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DistortionModelParams : IHasExternalVersionOut<DistortionModelParams>, IHasExternalVersionIn<DistortionModelParams>
    {
        private DistortionModel _distortionModel;
        private CVI_PolyModel _polyModel;
        private CVI_DivModel _divModel;

        
        public DistortionModelParams ConvertToExternal()
        {
            DistortionModelParams distortion = new DistortionModelParams();
            distortion.DistortionModel = _distortionModel;
            distortion.PolyModel = _polyModel.ConvertToExternal();
            distortion.DivModel = _divModel.ConvertToExternal();
            return distortion;
        }

        public void ConvertFromExternal(DistortionModelParams distortion)
        {
            _distortionModel = distortion.DistortionModel;
            _polyModel.ConvertFromExternal(distortion.PolyModel);
            _divModel.ConvertFromExternal(distortion.DivModel);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FocalLength : IHasExternalVersionOut<FocalLength>, IHasExternalVersionIn<FocalLength>
    {
        private float _fx;
        private float _fy;

        
        public FocalLength ConvertToExternal()
        {
            return new FocalLength(_fx, _fy);
        }

        public void ConvertFromExternal(FocalLength focalLength)
        {
            _fx = focalLength.Fx;
            _fy = focalLength.Fy;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_InternalParameters : IHasExternalVersionOut<InternalParameters>, IHasExternalVersionIn<InternalParameters>
    {
        private char _isInsufficientData;
        private CVI_FocalLength _focalLength;
        private CVI_PointFloat _opticalCenter;

        
        public InternalParameters ConvertToExternal()
        {
            InternalParameters param = new InternalParameters();
            param.IsInsufficientData = _isInsufficientData != 0 ? true : false;
            param.FocalLength = _focalLength.ConvertToExternal();
            param.OpticalCenter = _opticalCenter.ConvertToExternal();
            return param;
        }

        public void ConvertFromExternal(InternalParameters param)
        {
            _isInsufficientData = param.IsInsufficientData ? (char)1 : (char)0;
            _focalLength.ConvertFromExternal(param.FocalLength);
            _opticalCenter.ConvertFromExternal(param.OpticalCenter);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CameraParametersReport : IHasExternalVersionOut<CameraParametersReport>
    {
        private IntPtr _projectionMatrix;
        private Int32  _projectionMatrixRows;
        private Int32  _projectionMatrixCols;
        private CVI_DistortionModelParams _distortion;
        private CVI_InternalParameters _internalParams;

        
        public CameraParametersReport ConvertToExternal()
        {
            CameraParametersReport report = new CameraParametersReport();
            if (_projectionMatrix != null && _projectionMatrixRows > 0 && _projectionMatrixCols > 0)
            {
                report.ProjectionMatrix = Utilities.ConvertIntPtrTo2DStructureArray<double>(_projectionMatrix, _projectionMatrixRows, _projectionMatrixCols, false);
            }
            else
            {
                report.ProjectionMatrix = new double[0, 0];
            }
            report.Distortion = _distortion.ConvertToExternal();
            report.InternalParams = _internalParams.ConvertToExternal();
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationModelSetup : IHasExternalVersionOut<CalibrationModelSetup>, IHasExternalVersionIn<CalibrationModelSetup>
    {
        private DistortionModel _distortionModel;
        private RadialCoefficients _radialCoefficients;
        private Int32 _tangentialCoefficients;

        
        public CalibrationModelSetup ConvertToExternal()
        {
            return new CalibrationModelSetup(_distortionModel, _radialCoefficients, (_tangentialCoefficients != 0));
        }

        public void ConvertFromExternal(CalibrationModelSetup setup)
        {
            _distortionModel = setup.DistortionModel;
            _radialCoefficients = setup.RadialCoefficients;
            _tangentialCoefficients = (Int32)(setup.TangentialCoefficients ? 1 : 0);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationAxisInfo : IHasExternalVersionOut<CalibrationAxisInfo>, IHasExternalVersionIn<CalibrationAxisInfo>
    {
        private CVI_PointFloat _center;
        private float _rotationAngle;
        private UInt32 _axisDirection;

        
        public CalibrationAxisInfo ConvertToExternal()
        {
            CalibrationAxisInfo info = new CalibrationAxisInfo();
            info.Center = _center.ConvertToExternal();
            info.RotationAngle = _rotationAngle;
            info.AxisDirection = (AxisOrientation)_axisDirection;
            return info;
        }

        public void ConvertFromExternal(CalibrationAxisInfo info)
        {
            _center.ConvertFromExternal(info.Center);
            _rotationAngle = info.RotationAngle;
            _axisDirection = (UInt32)info.AxisDirection;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationLearnSetupInfoAll : IHasExternalVersionOut<CalibrationLearnSetupInfoAll>, IHasExternalVersionIn<CalibrationLearnSetupInfoAll>
    {
        private CalibrationMethod2 _calibrationMethod;
        private DistortionModel _distortionModel;
        private ScalingMethod _scaleMode;
        private CalibrationCorrectionMode _calibrationCorrectionMode;
        private char _learnCorrectionTable; 

        
        public CalibrationLearnSetupInfoAll ConvertToExternal()
        {
            return new CalibrationLearnSetupInfoAll(_calibrationMethod, _distortionModel, _scaleMode, _calibrationCorrectionMode, _learnCorrectionTable != 0? true: false);
        }

        public void ConvertFromExternal(CalibrationLearnSetupInfoAll info)
        {
            _calibrationMethod = info.CalibrationMethod;
            _calibrationCorrectionMode = info.CalibrationCorrectionMode;
            _distortionModel = info.DistortionModel;
            _scaleMode = info.ScaleMode;
            _learnCorrectionTable = info.LearnCorrectionTable? (char)1 : (char)0;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationLearnSetupInfo : IHasExternalVersionOut<CalibrationLearnSetupInfo>, IHasExternalVersionIn<CalibrationLearnSetupInfo>
    {
        private ScalingMethod _scaleMode;
        private CalibrationCorrectionMode _calibrationCorrectionMode;
        private char _learnCorrectionTable; 

        
        public CalibrationLearnSetupInfo ConvertToExternal()
        {
            return new CalibrationLearnSetupInfo( _scaleMode, _calibrationCorrectionMode, _learnCorrectionTable != 0? true: false);
        }

        public void ConvertFromExternal(CalibrationLearnSetupInfo info)
        {
            _calibrationCorrectionMode = info.CalibrationCorrectionMode;
            _scaleMode = info.ScalingMethod;
            _learnCorrectionTable = info.LearnCorrectionTable? (char)1 : (char)0;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ErrorStatistics : IHasExternalVersionOut<ErrorStatistics>, IHasExternalVersionIn<ErrorStatistics>
    {
        private double _mean;
        private double _maximum;
        private double _standardDeviation;
        private double _distortion;

        
        public ErrorStatistics ConvertToExternal()
        {
            return new ErrorStatistics(_mean, _maximum, _standardDeviation, _distortion);
        }

        public void ConvertFromExternal(ErrorStatistics statistics)
        {
            _mean = statistics.Mean;
            _maximum = statistics.Maximum;
            _standardDeviation = statistics.StandardDeviation;
            _distortion = statistics.Distortion;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GetCalibrationInfoReport : IHasExternalVersionOut<GetCalibrationInfoReport>
    {
        private IntPtr _userROI;
        private IntPtr _calibrationROI;
        private CVI_CalibrationAxisInfo _axisInfo;
        private CVI_CalibrationLearnSetupInfoAll _learnSetupInfo;
        private CVI_GridDescriptor _simpleGridDescriptor;
        private IntPtr _errorMap;
        private Int32  _errorMapRows;
        private Int32  _errorMapCols;
        private CVI_ErrorStatistics _errorStatistics;

        
        public GetCalibrationInfoReport ConvertToExternal()
        {
            GetCalibrationInfoReport report = new GetCalibrationInfoReport();
            if (_userROI != null)
            {
                report.UserROI = new Roi(_userROI);
            }
            else
            {
                report.UserROI = new Roi();
            }
            if (_calibrationROI != null)
            {
                report.CalibrationROI = new Roi(_calibrationROI);
            }
            else
            {
                report.CalibrationROI = new Roi();
            }
            report.AxisInfo = _axisInfo.ConvertToExternal();
            report.LearnSetupInfo = _learnSetupInfo.ConvertToExternal();
            report.SimpleGridDescriptor = _simpleGridDescriptor.ConvertToExternal();
            if (_errorMap != null && _errorMapRows > 0 && _errorMapCols > 0)
            {
                report.ErrorMap = Utilities.ConvertIntPtrTo2DStructureArray<float>(_errorMap, _errorMapRows, _errorMapCols, false);
            }
            else
            {
                report.ErrorMap = new float[0, 0];
            }
            report.ErrorStatistics = _errorStatistics.ConvertToExternal();
            return report;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MaxGridSize : IHasExternalVersionOut<MaxGridSize>, IHasExternalVersionIn<MaxGridSize>
    {
        private UInt32 _xMax;
        private UInt32 _yMax;

        
        public MaxGridSize ConvertToExternal()
        {
            return new MaxGridSize(_xMax, _yMax);
        }

        public void ConvertFromExternal(MaxGridSize maxGridSize)
        {
            _xMax = maxGridSize.XMax;
            _yMax = maxGridSize.YMax;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ImageSize : IHasExternalVersionOut<ImageSize>, IHasExternalVersionIn<ImageSize>
    {
        private UInt32 _xRes;
        private UInt32 _yRes;

        
        public ImageSize ConvertToExternal()
        {
            return new ImageSize(_xRes, _yRes);
        }

        public void ConvertFromExternal(ImageSize imageSize)
        {
            _xRes = imageSize.XRes;
            _yRes = imageSize.YRes;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibrationReferencePoints : IHasExternalVersionOut<CalibrationReferencePoints>, IHasExternalVersionIn<CalibrationReferencePoints>
    {
        private IntPtr _pixelCoords;
        private UInt32 _numPixelCoords;
        private IntPtr _realCoords;
        private UInt32 _numRealCoords;
        private CalibrationUnit _calibrationUnit;
        private CVI_ImageSize _imageSize; 

        
        public CalibrationReferencePoints ConvertToExternal()
        {
            CalibrationReferencePoints report = new CalibrationReferencePoints();
            if (_pixelCoords != null)
            {
                report.PixelCoords = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_pixelCoords, _numPixelCoords, false);
            }
            else
            {
                report.PixelCoords = new Collection<PointContour>();
            }
            if (_realCoords != null)
            {
                report.RealCoords = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointDouble>(_realCoords, _numRealCoords, false);
            }
            else
            {
                report.RealCoords = new Collection<PointContour>();
            }
            report.CalibrationUnit = _calibrationUnit;
            report.ImageSize = _imageSize.ConvertToExternal();
            return report;
        }

        public void ConvertFromExternal(CalibrationReferencePoints referencePts)
        {
            _pixelCoords = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointDouble>(referencePts.PixelCoords);
            _numPixelCoords = (UInt32)referencePts.PixelCoords.Count;
            _realCoords = Utilities.ConvertCollectionToIntPtr<PointContour, CVI_PointDouble>(referencePts.RealCoords);
            _numRealCoords = (UInt32)referencePts.RealCoords.Count;
            _calibrationUnit = referencePts.CalibrationUnit;
            _imageSize.ConvertFromExternal(referencePts.ImageSize);
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleFilterCriteria2 : IHasExternalVersionIn<ParticleFilterCriteria>
	{
		private Int32 _parameter;
		private float _lower;
		private float _upper;
		private Int32 _calibrated;
		private Int32 _exclude;

		
		public void ConvertFromExternal(ParticleFilterCriteria criteria)
		{
			_parameter = (Int32)criteria.Parameter;
			_lower = (float)criteria.Range.Minimum;
			_upper = (float)criteria.Range.Maximum;
			_calibrated = criteria.Calibrated ? 1 : 0;
			_exclude = (Int32)criteria.RangeType;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleFilterOptions2 : IHasExternalVersionIn<ParticleFilterOptions>
	{
		private Int32 _rejectMatches;
		private Int32 _rejectBorder;
		private Int32 _fillHoles;
		private Int32 _connectivity;

		
		public void ConvertFromExternal(ParticleFilterOptions options)
		{
			_rejectMatches = options.RejectMatches ? 1 : 0;
			_rejectBorder = options.RejectBorder ? 1 : 0;
			_fillHoles = options.FillHoles ? 1 : 0;
			_connectivity = (Int32)options.Connectivity;
		}
	}

    // I'm leaving this code around for a while to demonstrate how to deal with structures too big for the Marshaller to deal
    // with.  Hopefully we'll never have to do this (because of the performance penalty).
    // Because this structure is so big, the Marshaller cannot deal with it directly, so DO NOT use it as a parameter to
    // a DLL call!  Instead, pass an IntPtr, allocated with Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CVI_ReadTextOptions))),
    // and use ConvertFromIntPtr/ConvertToIntPtr to convert it.  Then dispose the IntPtr with Marshal.FreeHGlobal().
    // See OcrSession.ReadFile or OcrSession.ReadText for examples of how to deal with this and other too-large structures.
    /*[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct CVI_ReadTextOptions : IHasExternalVersionIn<OcrReadTextOptions>, IHasExternalVersionOut<OcrReadTextOptions>
	{
		private fixed char _validChars[256*255];
		private Int32 _numValidChars;
		private char _substitutionChar;
		private Int32 _readStrategy;
		private Int32 _acceptanceLevel;
		private Int32 _aspectRatio;
		private Int32 _readResolution;

		public void ConvertFromIntPtr(IntPtr ptr)
		{
			fixed (char* validCharsPtr = _validChars)
			{
				//Marshal.Copy(ip, _validChars, 0, 256 * 255);
				char* tempValidCharsPtr = validCharsPtr;
				for (int i = 0; i < 256 * 255; ++i)
				{
					*tempValidCharsPtr = (char) Marshal.ReadByte(ptr);
					ptr = Utilities.AdvanceIntPtr(ptr, sizeof(byte));
					tempValidCharsPtr++;
				}
			}
			_numValidChars = Marshal.ReadInt32(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			_substitutionChar = (char) Marshal.ReadByte(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(byte));
			_readStrategy = Marshal.ReadInt32(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			_acceptanceLevel = Marshal.ReadInt32(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			_aspectRatio = Marshal.ReadInt32(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			_readResolution = Marshal.ReadInt32(ptr);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
		}

		// The IntPtr must have been allocated with Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CVI_ReadTextOptions)))
		// When done, you must dispose the IntPtr with Marshal.FreeHGlobal()
		public void ConvertToIntPtr(IntPtr ptr)
		{
			fixed (char* validCharsPtr = _validChars)
			{
				//Marshal.Copy(ip, _validChars, 0, 256 * 255);
				char* tempValidCharsPtr = validCharsPtr;
				for (int i = 0; i < 256 * 255; ++i)
				{
					Marshal.WriteByte(ptr, (byte)*tempValidCharsPtr);
					ptr = Utilities.AdvanceIntPtr(ptr, sizeof(byte));
					tempValidCharsPtr++;
				}
			}
			Marshal.WriteInt32(ptr, _numValidChars);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			Marshal.WriteByte(ptr, (byte)_substitutionChar);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(byte));
			Marshal.WriteInt32(ptr, _readStrategy);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			Marshal.WriteInt32(ptr, _acceptanceLevel);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			Marshal.WriteInt32(ptr, _aspectRatio);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
			Marshal.WriteInt32(ptr, _readResolution);
			ptr = Utilities.AdvanceIntPtr(ptr, sizeof(Int32));
		}

		public OcrReadTextOptions ConvertToExternal()
		{
			OcrReadTextOptions options = new OcrReadTextOptions();
			fixed(char* _validCharsPtr = _validChars) {
				char* startPtr = _validCharsPtr;
				for (int i = 0; i < _numValidChars; ++i)
				{
					char* tempStartPtr = startPtr;
					StringBuilder builder = new StringBuilder();
					for (int j = 0; *tempStartPtr != '\0' && j < 256; ++j) {
						builder.Append(*tempStartPtr);
						tempStartPtr++;
					}
					options.ValidCharacters.Add(builder.ToString());
					startPtr += 256;
				}
			}
			options.SubstitutionCharacter = _substitutionChar;
			options.ReadStrategy = (OcrReadStrategy)_readStrategy;
			options.AcceptanceLevel = _acceptanceLevel;
			options.AspectRatio = _aspectRatio;
			options.ReadResolution = (OcrReadResolution)_readResolution;
			return options;
		}

		public void ConvertFromExternal(OcrReadTextOptions options)
		{
			fixed(char* _validCharsPtr = _validChars) {
				char* startPtr = _validCharsPtr;
				for (int i = 0; i < options.ValidCharacters.Count && i < 255; ++i)
				{
					char* tempStartPtr = startPtr;
					for (int j = 0; j < options.ValidCharacters[i].Length && j < 256; ++j)
					{
						*tempStartPtr = options.ValidCharacters[i][j];
						tempStartPtr++;
					}
					startPtr += 256;
				}
			}
			_numValidChars = options.ValidCharacters.Count <= 255 ? options.ValidCharacters.Count : 255;
			_substitutionChar = options.SubstitutionCharacter;
			_readStrategy = (Int32)options.ReadStrategy;
			_acceptanceLevel = options.AcceptanceLevel;
			_aspectRatio = options.AspectRatio;
			_readResolution = (Int32)options.ReadResolution;
		}

	 * }*/

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CharacterStatistics : IHasExternalVersionOut<CharacterStatistics>
	{
		private Int32 _left;
		private Int32 _top;
		private Int32 _width;
		private Int32 _height;
		private Int32 _characterSize;

		
		public CharacterStatistics ConvertToExternal()
		{
			CharacterStatistics statistics = new CharacterStatistics();
			statistics.BoundingRectangle.Left = _left;
			statistics.BoundingRectangle.Top = _top;
			statistics.BoundingRectangle.Width = _width;
			statistics.BoundingRectangle.Height = _height;
			statistics.CharacterSize = _characterSize;
			return statistics;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CharReport3 : IHasExternalVersionOut<CharacterReport>
	{
		private IntPtr _character;
		private Int32 _classificationScore;
		private Int32 _verificationScore;
		private Int32 _verified;
		private Int32 _lowThreshold;
		private Int32 _highThreshold;
		private CVI_CharacterStatistics _characterStats;

		
		public CharacterReport ConvertToExternal() {
			CharacterReport report = new CharacterReport();
			report.CharacterValue = Marshal.PtrToStringAnsi(_character);
			report.ClassificationScore = _classificationScore;
			report.VerificationScore = _verificationScore;
			report.Verified = (_verified != 0);
			report.ThresholdRange.Minimum = _lowThreshold;
			report.ThresholdRange.Maximum = _highThreshold;
			report.CharacterStatistics = _characterStats.ConvertToExternal();
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ReadTextReport3 : IHasExternalVersionOut<ReadTextReport>
	{
		private IntPtr _readString;
		private IntPtr _characterReport;
		private Int32 _numCharacterReports;
		private IntPtr _roiBoundingCharacters;

		
		public ReadTextReport ConvertToExternal()
		{
			ReadTextReport report = new ReadTextReport();
			report.ReadString = Marshal.PtrToStringAnsi(_readString);
			report.CharacterReports = Utilities.ConvertIntPtrToCollection<CharacterReport, CVI_CharReport3>(_characterReport, _numCharacterReports, false);
			report.RoiBoundingCharacters = new Roi(_roiBoundingCharacters);
			return report;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ReadTextReport4 : IHasExternalVersionOut<ReadTextReport2>
    {
        private IntPtr _readString;
        private IntPtr _characterReport;
        private Int32  _numCharacterReports;
        private IntPtr _roiBoundingCharacters;
        private Int32  _numberOflinesDetected;

        public ReadTextReport2 ConvertToExternal()
        {
            ReadTextReport2 report  = new ReadTextReport2();
            report.ReadString       = Marshal.PtrToStringAnsi(_readString);
            report.CharacterReports = Utilities.ConvertIntPtrToCollection<CharacterReport, CVI_CharReport3>(_characterReport, _numCharacterReports, false);
            report.RoiBoundingCharacters = new Roi(_roiBoundingCharacters);
            report.NumberOflinesDetected = this._numberOflinesDetected;
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal unsafe struct CVI_String255 : IHasExternalVersionOut<string>, IHasExternalVersionIn<string>
	{
		private fixed byte _str[256];

		
		public void ConvertFromExternal(string str)
		{
			byte[] _strBytes = System.Text.Encoding.Default.GetBytes(str);
			if (_strBytes.Length > 255)
			{
				throw new VisionException(ErrorCode.DescriptionTooLong);
			}
			fixed (byte* _strPtr = _str) {
				for (int i = 0; i < _strBytes.Length; ++i)
				{
					_strPtr[i] = _strBytes[i];
				}
				_strPtr[_strBytes.Length] = (byte)0;
			}
		}

		
		public string ConvertToExternal()
		{
			// It would be great if we could use Utilities.BytesToString() here, but we can't
			// because _str is fixed.
			fixed(byte* _strPtr = _str) {
				int length = 0;
				for (int i = 0; i < 256; ++i)
				{
					if (_strPtr[i] == 0)
					{
						length = i;
						break;
					}
				}
				byte[] bytes = new byte[length];
				for (int i = 0; i < length; ++i) {
					bytes[i] = _strPtr[i];
				}
				return System.Text.Encoding.Default.GetString(bytes);
			}
		}
	}

	
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

	
	internal enum CVI_ScalingMode
	{

		Larger = 0,

		Smaller = 1
	}

	
	internal enum CVI_MulticoreOperation
	{

		GetCores = 0,

		SetCores = 1,

		UseMaxAvailable = 2
	}

	
	internal enum VB_FileType
	{

		Bmp = 0,

		Aipd = 1,

		Tiff = 2,

		Jpeg = 3,

		Png = 4,

		Raw = 5,

		Jpeg2000 = 6
	}

	
	internal enum CVI_ReferenceMode 
	{

		CoordXY = 0,

		CoordOriginX = 1
	}

	
	internal enum CVI_RoundingMode
	{

		Optimize = 0,

		Truncate = 1
	}

	internal enum CVI_MeterArcMode
	{

		Roi = 0,

		Points = 1
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
    internal struct CVI_ClassifierAccuracyReport : IHasExternalVersionOut<ClassifierAccuracyReport>
	{
		private Int32 _size;
		private float _accuracy;
		private IntPtr _classNames;
		private IntPtr _classAccuracy;
		private IntPtr _classPredictiveValue;
		private IntPtr _classificationDistribution;

		
		public ClassifierAccuracyReport ConvertToExternal()
		{
			ClassifierAccuracyReport report = new ClassifierAccuracyReport();
			report.Accuracy = _accuracy;
			Collection<string> names = Utilities.ConvertIntPtrToStringCollection(_classNames, _size, false);
			Collection<double> accuracies = Utilities.ConvertIntPtrToCollection<double>(_classAccuracy, _size, false);
			Collection<double> predictiveValues = Utilities.ConvertIntPtrToCollection<double>(_classPredictiveValue, _size, false);
			for (int i = 0; i < _size; ++i)
			{
				report.Classes.Add(new ClassifierClass(names[i], accuracies[i], predictiveValues[i]));
			}
			report.SetClassifierDistribution(Utilities.ConvertIntPtrFlatTo2DArrayInt32(_classificationDistribution, _size, _size, false));
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassScore : IHasExternalVersionOut<ClassScore>
	{
		private IntPtr _className;
		private float _distance;

		
		public ClassScore ConvertToExternal()
		{
			return new ClassScore(Marshal.PtrToStringAnsi(_className), _distance);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SampleScore : IHasExternalVersionOut<SampleScore>
	{
		private IntPtr _className;
		private float _distance;
		private Int32 _index;

		
		public SampleScore ConvertToExternal()
		{
			return new SampleScore(Marshal.PtrToStringAnsi(_className), _distance, _index);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifierReport : IHasExternalVersionOut<ClassifierReport>
	{
		private IntPtr _bestClassName;
		private float _classificationScore;
		private float _identificationScore;
		private IntPtr _allScores;
		private Int32 _allScoresSize;

		
		public ClassifierReport ConvertToExternal()
		{
			ClassifierReport report = new ClassifierReport();
			report.AllScores = Utilities.ConvertIntPtrToCollection<ClassScore, CVI_ClassScore>(_allScores, _allScoresSize, false);
			report.BestClassName = Marshal.PtrToStringAnsi(_bestClassName);
			report.ClassificationScore = _classificationScore;
			report.IdentificationScore = _identificationScore;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ClassifierReportAdvanced : IHasExternalVersionOut<ClassifierReportAdvanced>
	{
		private IntPtr _bestClassName;
		private float _classificationScore;
		private float _identificationScore;
		private IntPtr _allScores;
		private Int32 _allScoresSize;
		private IntPtr _sampleScores;
		private Int32 _sampleScoresSize;

		
		public ClassifierReportAdvanced ConvertToExternal()
		{
			ClassifierReportAdvanced report = new ClassifierReportAdvanced();
			report.AllScores = Utilities.ConvertIntPtrToCollection<ClassScore, CVI_ClassScore>(_allScores, _allScoresSize, false);
			report.SampleScores = Utilities.ConvertIntPtrToCollection<SampleScore, CVI_SampleScore>(_sampleScores, _sampleScoresSize, false);
			report.BestClassName = Marshal.PtrToStringAnsi(_bestClassName);
			report.ClassificationScore = _classificationScore;
			report.IdentificationScore = _identificationScore;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_NearestNeighborOptions : IHasExternalVersionOut<NearestNeighborOptions>, IHasExternalVersionIn<NearestNeighborOptions>
	{
		private Int32 _method;
		private Int32 _metric;
		private Int32 _k;

		
		public NearestNeighborOptions ConvertToExternal()
		{
			return new NearestNeighborOptions((NearestNeighborMethod)_method, (NearestNeighborMetric)_metric, _k);
		}

		
		public void ConvertFromExternal(NearestNeighborOptions options)
		{
			_method = (Int32)options.Method;
			_metric = (Int32)options.Metric;
			_k = options.K;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_NearestNeighborClassResult : IHasExternalVersionOut<NearestNeighborClassResult>
	{
		private IntPtr _className;
		private float _standardDeviation;
		private Int32 _count;

		
		public NearestNeighborClassResult ConvertToExternal()
		{
			NearestNeighborClassResult result = new NearestNeighborClassResult();
			result.ClassName = Marshal.PtrToStringAnsi(_className);
			result.StandardDeviation = _standardDeviation;
			result.Count = _count;
			return result;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_NearestNeighborTrainingReport : IHasExternalVersionOut<NearestNeighborTrainingReport>
	{
		private IntPtr _classDistancesTable;
		private IntPtr _allScores;
		private Int32 _allScoresSize;

		
		public NearestNeighborTrainingReport ConvertToExternal()
		{
			NearestNeighborTrainingReport report = new NearestNeighborTrainingReport();
			float[,] classDistancesArray = Utilities.ConvertIntPtrIndirectTo2DArraySingle(_classDistancesTable, _allScoresSize, _allScoresSize, false);
			double[,] classDistancesTable = new double[classDistancesArray.GetLength(0), classDistancesArray.GetLength(1)];
			for (int i = 0; i < classDistancesArray.GetLength(0); ++i)
			{
				for (int j = 0; j < classDistancesArray.GetLength(1); ++j)
				{
					classDistancesTable[i, j] = classDistancesArray[i, j];
				}
			}
			report.SetClassDistancesTable(classDistancesTable);
			report.ClassResults = Utilities.ConvertIntPtrToCollection<NearestNeighborClassResult, CVI_NearestNeighborClassResult>(_allScores, _allScoresSize, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleClassifierAutoThresholdOptions : IHasExternalVersionIn<ParticleClassifierAutoThresholdOptions>, IHasExternalVersionOut<ParticleClassifierAutoThresholdOptions>
	{
		private ThresholdMethod _method;
		private ParticleType _particleType;
		private CVI_RangeFloat _limits;

		
		public ParticleClassifierAutoThresholdOptions ConvertToExternal()
		{
			ParticleClassifierAutoThresholdOptions options = new ParticleClassifierAutoThresholdOptions();
			options.Method = _method;
			options.ParticleType = _particleType;
			options.Limits = _limits.ConvertToExternal();
			return options;
		}

		public void ConvertFromExternal(ParticleClassifierAutoThresholdOptions options)
		{
			_method = options.Method;
			_particleType = options.ParticleType;
			_limits.ConvertFromExternal(options.Limits);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleClassifierLocalThresholdOptions : IHasExternalVersionIn<ParticleClassifierLocalThresholdOptions>, IHasExternalVersionOut<ParticleClassifierLocalThresholdOptions>
	{
		private LocalThresholdMethod _method;
		private ParticleType _particleType;
		private UInt32 _windowWidth;
		private UInt32 _windowHeight;
		private double _deviationWeight;

		
		public ParticleClassifierLocalThresholdOptions ConvertToExternal()
		{
			ParticleClassifierLocalThresholdOptions options = new ParticleClassifierLocalThresholdOptions();
			options.Method = _method;
			options.ParticleType = _particleType;
			options.WindowWidth = _windowWidth;
			options.WindowHeight = _windowHeight;
			options.DeviationWeight = _deviationWeight;
			return options;
		}

		public void ConvertFromExternal(ParticleClassifierLocalThresholdOptions options)
		{
			_method = options.Method;
			_particleType = options.ParticleType;
			_windowWidth = options.WindowWidth;
			_windowHeight = options.WindowHeight;
			_deviationWeight = options.DeviationWeight;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleClassifierPreprocessingOptions2 : IHasExternalVersionOut<ParticleClassifierPreprocessingOptions>, IHasExternalVersionIn<ParticleClassifierPreprocessingOptions>
	{
		private ThresholdType _thresholdType;
		private CVI_RangeFloat _manualThresholdRange;
		private CVI_ParticleClassifierAutoThresholdOptions _autoThresholdOptions;
		private CVI_ParticleClassifierLocalThresholdOptions _localThresholdOptions;
		private Int32 _rejectBorder;
		private Int32 _numErosions;

		
		public ParticleClassifierPreprocessingOptions ConvertToExternal()
		{
			ParticleClassifierPreprocessingOptions options = new ParticleClassifierPreprocessingOptions();
			options.ThresholdType = _thresholdType;
			options.ManualThresholdRange = _manualThresholdRange.ConvertToExternal();
			options.AutoThresholdOptions = _autoThresholdOptions.ConvertToExternal();
			options.LocalThresholdOptions = _localThresholdOptions.ConvertToExternal();
			options.RejectBorder = _rejectBorder != 0;
			options.NumberOfErosions = _numErosions;
			return options;
		}

		
		public void ConvertFromExternal(ParticleClassifierPreprocessingOptions options)
		{
			_thresholdType = options.ThresholdType;
			_manualThresholdRange.ConvertFromExternal(options.ManualThresholdRange);
			_autoThresholdOptions.ConvertFromExternal(options.AutoThresholdOptions);
			_localThresholdOptions.ConvertFromExternal(options.LocalThresholdOptions);
			_rejectBorder = options.RejectBorder ? 1 : 0;
			_numErosions = options.NumberOfErosions;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ParticleClassifierOptions : IHasExternalVersionIn<ParticleClassifierOptions>, IHasExternalVersionOut<ParticleClassifierOptions>
	{
		private float _scaleDependence;
		private float _mirrorDependence;

		
		public ParticleClassifierOptions ConvertToExternal()
		{
			ParticleClassifierOptions options = new ParticleClassifierOptions();
			options.MirrorDependence = _mirrorDependence;
			options.ScaleDependence = _scaleDependence;
			return options;
		}

		
		public void ConvertFromExternal(ParticleClassifierOptions options)
		{
			_scaleDependence = (float)options.ScaleDependence;
			_mirrorDependence = (float)options.MirrorDependence;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ColorOptions : IHasExternalVersionIn<ColorClassifierOptions>, IHasExternalVersionOut<ColorClassifierOptions>
	{
		private ColorClassifierResolution _colorClassificationResolution;
		private Int32 _useLuminance;
		private ColorMode _colorMode;

		
		public ColorClassifierOptions ConvertToExternal()
		{
			ColorClassifierOptions options = new ColorClassifierOptions();
			options.ColorClassifierResolution = _colorClassificationResolution;
			options.UseLuminance = _useLuminance != 0;
			return options;
		}

		
		public void ConvertFromExternal(ColorClassifierOptions options)
		{
			_colorClassificationResolution = options.ColorClassifierResolution;
			_useLuminance = options.UseLuminance ? 1 : 0;
			_colorMode = ColorMode.Hsl;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineProfile : IHasExternalVersionOut<LineProfileReport>
	{
		private IntPtr _profileData;
		private CVI_Rectangle _boundingBox;
		private float _min;
		private float _max;
		private float _mean;
		private float _stdDev;
		private Int32 _dataCount;

		
		public LineProfileReport ConvertToExternal()
		{
			LineProfileReport profile = new LineProfileReport();
			profile.ProfileData = Utilities.ConvertIntPtrToCollection<double, float>(_profileData, _dataCount, false, delegate(float f) { return f; });
			profile.BoundingBox = _boundingBox.ConvertToExternal();
			profile.PixelRange.Minimum = _min;
			profile.PixelRange.Maximum = _max;
			profile.Mean = _mean;
			profile.StandardDeviation = _stdDev;
			return profile;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_StructuringElement : IHasExternalVersionIn<StructuringElement>, IDisposable
	{
		private int _matrixCols;
		private int _matrixRows;
		private int _hexa;
		private IntPtr _kernel;

		
		public void ConvertFromExternal(StructuringElement element)
		{
			_matrixCols = element.Width;
			_matrixRows = element.Height;
			_hexa = (element.Shape == StructuringElementShape.Hexagon) ? 1 : 0;
			_kernel = Utilities.ConvertArrayToIntPtr<int>(element.Entries);
		}
		#region IDisposable Members

		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _kernel is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_kernel != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_kernel);
				_kernel = IntPtr.Zero;
			}
		}
		#endregion
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_BarcodeInfo : IHasExternalVersionOut<BarcodeReport>
	{
		private IntPtr _outputString;
		private Int32 _size;
		private byte _outputChar1;
		private byte _outputChar2;
		private double _confidenceLevel;
		private BarcodeTypes _type;

		
		public BarcodeReport ConvertToExternal()
		{
			BarcodeReport info = new BarcodeReport();
			byte[] outputStringBytes = Utilities.ConvertIntPtrTo1DStructureArray<byte>(_outputString, _size, false);
			info.Text = Utilities.ConvertBytesToString(outputStringBytes);
			info.OutputChar1 = (char)_outputChar1;
			info.OutputChar2 = (char)_outputChar2;
			info.ConfidenceLevel = _confidenceLevel;
			info.BarcodeType = _type;
			return info;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Barcode2DInfo : IHasExternalVersionOut<Pdf417Report>
	{
		private Int32 _unusedBarcodeType;
		private Int32 _binary;
		private IntPtr _data;
		private UInt32 _dataLength;
		private CVI_PointFloat _boundingBox0;
		private CVI_PointFloat _boundingBox1;
		private CVI_PointFloat _boundingBox2;
		private CVI_PointFloat _boundingBox3;
		private UInt32 _numErrorsCorrected;
		private UInt32 _numErasuresCorrected;
		private UInt32 _rows;
		private UInt32 _columns;

		
		public Pdf417Report ConvertToExternal()
		{
			Pdf417Report report = new Pdf417Report();
			report.Binary = _binary != 0;
			report.SetBinaryData(Utilities.ConvertIntPtrTo1DStructureArray<byte>(_data, _dataLength, false));
			if (!report.Binary)
			{
				report.StringData = Utilities.ConvertBytesToString(report.GetBinaryData());
			}
			report.Corners.Add(_boundingBox0.ConvertToExternal());
			report.Corners.Add(_boundingBox1.ConvertToExternal());
			report.Corners.Add(_boundingBox2.ConvertToExternal());
			report.Corners.Add(_boundingBox3.ConvertToExternal());
			report.ErrorsCorrected = _numErrorsCorrected;
			report.ErasuresCorrected = _numErasuresCorrected;
			report.Rows = _rows;
			report.Columns = _columns;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QRCodeDescriptionOptions : IHasExternalVersionIn<QRDescriptionOptions>
	{
		private QRDimension _dimensions;
		private QRPolarity _polarity;
		private QRMirrorMode _mirror;
		private QRModelType _modelType;

		
		public void ConvertFromExternal(QRDescriptionOptions options)
		{
			_dimensions = options.Dimensions;
			_polarity = options.Polarity;
			_mirror = options.MirrorMode;
			_modelType = options.ModelType;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QRCodeSizeOptions : IHasExternalVersionIn<QRSizeOptions>
	{
		private UInt32 _minSize;
		private UInt32 _maxSize;

		
		public void ConvertFromExternal(QRSizeOptions options)
		{
			_minSize = options.MinimumSize;
			_maxSize = options.MaximumSize;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QRCodeSearchOptions : IHasExternalVersionIn<QRSearchOptions>
	{
		private QRRotationMode _rotationMode;
		private UInt32 _skipLocation;
		private UInt32 _edgeThreshold;
		private QRDemodulationMode _demodulationMode;
		private QRCellSampleSize _cellSampleSize;
		private QRCellFilterMode _cellFilterMode;
		private UInt32 _skewDegreesAllowed;

		
		public void ConvertFromExternal(QRSearchOptions options)
		{
			_rotationMode = options.RotationMode;
			_skipLocation = options.SkipLocation ? (uint)1 : (uint)0;
			_edgeThreshold = options.EdgeThreshold;
			_demodulationMode = options.DemodulationMode;
			_cellSampleSize = options.CellSampleSize;
			_cellFilterMode = options.CellFilterMode;
			_skewDegreesAllowed = options.SkewDegreesAllowed;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QRCodeDataToken : IHasExternalVersionOut<QRDataToken>
	{
		private QRStreamMode _mode;
		private UInt32 _modeData;
		private IntPtr _data;
		private UInt32 _dataLength;

		
		public QRDataToken ConvertToExternal()
		{
			QRDataToken token = new QRDataToken();
			token.Mode = _mode;
			token.ModeData = _modeData;
			token.SetData(Utilities.ConvertIntPtrTo1DStructureArray<byte>(_data, _dataLength, false));
			return token;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QRCodeReport : IHasExternalVersionOut<QRReport>
	{
		private UInt32 _found;
		private IntPtr _data;
		private UInt32 _dataLength;
		private CVI_PointFloat _boundingBox0;
		private CVI_PointFloat _boundingBox1;
		private CVI_PointFloat _boundingBox2;
		private CVI_PointFloat _boundingBox3;
		private IntPtr _tokenizedData;
		private UInt32 _sizeOfTokenizedData;
		private UInt32 _numErrorsCorrected;
		private UInt32 _dimensions;
		private UInt32 _version;
		private QRModelType _modelType;
		private QRStreamMode _streamMode;
		private QRPolarity _matrixPolarity;
		private UInt32 _mirrored;
		private UInt32 _positionInAppendStream;
		private UInt32 _sizeOfAppendStream;
		private Int32 _firstEAN128ApplicationID;
		private Int32 _firstECIDesignator;
		private UInt32 _appendStreamIdentifier;
		private UInt32 _minimumEdgeStrength;
		private QRDemodulationMode _demodulationMode;
		private QRCellSampleSize _cellSampleSize;
		private QRCellFilterMode _cellFilterMode;

		
		public QRReport ConvertToExternal()
		{
			QRReport report = new QRReport();
			report.Found = _found != 0;
			report.SetData(Utilities.ConvertIntPtrTo1DStructureArray<byte>(_data, _dataLength, false));
			report.Corners.Add(_boundingBox0.ConvertToExternal());
			report.Corners.Add(_boundingBox1.ConvertToExternal());
			report.Corners.Add(_boundingBox2.ConvertToExternal());
			report.Corners.Add(_boundingBox3.ConvertToExternal());
			report.TokenizedData = Utilities.ConvertIntPtrToCollection<QRDataToken, CVI_QRCodeDataToken>(_tokenizedData, _sizeOfTokenizedData, false);
			report.ErrorsCorrected = _numErrorsCorrected;
			report.Dimensions = _dimensions;
			report.Version = _version;
			report.ModelType = _modelType;
			report.StreamMode = _streamMode;
			report.MatrixPolarity = _matrixPolarity;
			report.Mirrored = _mirrored != 0;
			report.AppendStreamPosition = _positionInAppendStream;
			report.AppendStreamSize = _sizeOfAppendStream;
			report.FirstEan128ApplicationId = _firstEAN128ApplicationID;
			report.FirstEciDesignator = _firstECIDesignator;
			report.AppendStreamIdentifier = _appendStreamIdentifier;
			report.MinimumEdgeStrength = _minimumEdgeStrength;
			report.DemodulationMode = _demodulationMode;
			report.CellSampleSize = _cellSampleSize;
			report.CellFilterMode = _cellFilterMode;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DataMatrixDescriptionOptions : IHasExternalVersionIn<DataMatrixDescriptionOptions>
	{
		private float _aspectRatio;
		private UInt32 _rows;
		private UInt32 _columns;
		private Int32 _rectangle;
		private DataMatrixEcc _ecc;
		private DataMatrixPolarity _polarity;
		private DataMatrixCellFillMode _cellFill;
		private float _minBorderIntegrity;
		private DataMatrixMirrorMode _mirrorMode;

		
		public void ConvertFromExternal(DataMatrixDescriptionOptions options)
		{
			_aspectRatio = (float)options.AspectRatio;
			_rows = options.Rows;
			_columns = options.Columns;
			_rectangle = options.Rectangle ? 1 : 0;
			_ecc = options.Ecc;
			_polarity = options.Polarity;
			_cellFill = options.CellFill;
			_minBorderIntegrity = (float)options.MinimumBorderIntegrity;
			_mirrorMode = options.MirrorMode;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DataMatrixSizeOptions : IHasExternalVersionIn<DataMatrixSizeOptions>
	{
		private UInt32 _minSize;
		private UInt32 _maxSize;
		private UInt32 _quietZoneWidth;

		
		public void ConvertFromExternal(DataMatrixSizeOptions options)
		{
			_minSize = options.MinimumSize;
			_maxSize = options.MaximumSize;
			_quietZoneWidth = options.QuietZoneWidth;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DataMatrixSearchOptions : IHasExternalVersionIn<DataMatrixSearchOptions>
	{
		private DataMatrixRotationMode _rotationMode;
		private Int32 _skipLocation;
		private UInt32 _edgeThreshold;
		private DataMatrixDemodulationMode _demodulationMode;
		private DataMatrixCellSampleSize _cellSampleSize;
		private DataMatrixCellFilterMode _cellFilterMode;
		private UInt32 _skewDegreesAllowed;
		private UInt32 _maxIterations;
		private UInt32 _initialSearchVectorWidth;

		
		public void ConvertFromExternal(DataMatrixSearchOptions options)
		{
			_rotationMode = options.RotationMode;
			_skipLocation = options.SkipLocation ? 1 : 0;
			_edgeThreshold = options.EdgeThreshold;
			_demodulationMode = options.DemodulationMode;
			_cellSampleSize = options.CellSampleSize;
			_cellFilterMode = options.CellFilterMode;
			_skewDegreesAllowed = options.SkewDegreesAllowed;
			_maxIterations = options.MaximumIterations;
			_initialSearchVectorWidth = options.InitialSearchVectorWidth;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DataMatrixReport : IHasExternalVersionOut<DataMatrixReport>
	{
		private Int32 _found;
		private Int32 _binary;
		private IntPtr _data;
		private UInt32 _dataLength;
		private CVI_PointFloat _boundingBox0;
		private CVI_PointFloat _boundingBox1;
		private CVI_PointFloat _boundingBox2;
		private CVI_PointFloat _boundingBox3;
		private UInt32 _numErrorsCorrected;
		private UInt32 _numErasuresCorrected;
		private float _aspectRatio;
		private UInt32 _rows;
		private UInt32 _columns;
		private DataMatrixEcc _ecc;
		private DataMatrixPolarity _polarity;
		private DataMatrixCellFillMode _cellFill;
		private float _borderIntegrity;
		private Int32 _mirrored;
		private UInt32 _minimumEdgeStrength;
		private DataMatrixDemodulationMode _demodulationMode;
		private DataMatrixCellSampleSize _cellSampleSize;
		private DataMatrixCellFilterMode _cellFilterMode;
		private UInt32 _iterations;

		
		public DataMatrixReport ConvertToExternal()
		{
			DataMatrixReport report = new DataMatrixReport();
			report.Found = _found != 0;
			report.Binary = _binary != 0;
			report.SetBinaryData(Utilities.ConvertIntPtrTo1DStructureArray<byte>(_data, _dataLength, false));
			if (!report.Binary)
			{
				report.StringData = Utilities.ConvertBytesToString(report.GetBinaryData());
			}
			report.Corners.Add(_boundingBox0.ConvertToExternal());
			report.Corners.Add(_boundingBox1.ConvertToExternal());
			report.Corners.Add(_boundingBox2.ConvertToExternal());
			report.Corners.Add(_boundingBox3.ConvertToExternal());
			report.ErrorsCorrected = _numErrorsCorrected;
			report.ErasuresCorrected = _numErasuresCorrected;
			report.AspectRatio = _aspectRatio;
			report.Rows = _rows;
			report.Columns = _columns;
			report.Ecc = _ecc;
			report.Polarity = _polarity;
			report.CellFill = _cellFill;
			report.BorderIntegrity = _borderIntegrity;
			report.Mirrored = _mirrored != 0;
			report.MinimumEdgeStrength = _minimumEdgeStrength;
			report.DemodulationMode = _demodulationMode;
			report.CellSampleSize = _cellSampleSize;
			report.CellFilterMode = _cellFilterMode;
			report.Iterations = _iterations;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_AIMGradeReport : IHasExternalVersionOut<AimGradeReport>
	{
		private AimGrade _overallGrade;
		private AimGrade _decodingGrade;
		private AimGrade _symbolContrastGrade;
		private float _symbolContrast;
		private AimGrade _printGrowthGrade;
		private float _printGrowth;
		private AimGrade _axialNonuniformityGrade;
		private float _axialNonuniformity;
		private AimGrade _unusedErrorCorrectionGrade;
		private float _unusedErrorCorrection;

		
		public AimGradeReport ConvertToExternal()
		{
			AimGradeReport report = new AimGradeReport();
			report.OverallGrade = _overallGrade;
			report.DecodingGrade = _decodingGrade;
			report.SymbolContrastGrade = _symbolContrastGrade;
			report.SymbolContrast = _symbolContrast;
			report.PrintGrowthGrade = _printGrowthGrade;
			report.PrintGrowth = _printGrowth;
			report.AxialNonuniformityGrade = _axialNonuniformityGrade;
			report.AxialNonuniformity = _axialNonuniformity;
			report.UnusedErrorCorrectionGrade = _unusedErrorCorrectionGrade;
			report.UnusedErrorCorrection = _unusedErrorCorrection;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DataMatrixAdvancedOptions : IHasExternalVersionIn<DataMatrixAdvancedOptions>
    {
        private DataMatrixAdvancedProcessing _type;
        private double _value;

        public void ConvertFromExternal(DataMatrixAdvancedOptions advancedOptions)
        {
            this._type = advancedOptions.Type;
            this._value = advancedOptions.Value;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CalibReflectanceStruct : IHasExternalVersionIn<CalibReflectanceStruct>
    {
        private double _rcal;
        private double _srcal;
        private double _mlcal;
        private double _srtarget;

        public void ConvertFromExternal(CalibReflectanceStruct refStruct)
        {
            this._rcal = refStruct.Rcal;
            this._srcal = refStruct.Srcal;
            this._mlcal = refStruct.Mlcal;
            this._srtarget = refStruct.Srtarget;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_OCRPanelRange : IHasExternalVersionIn<OCRPanelRange>, IHasExternalVersionOut<OCRPanelRange>
    {
        private Int32 _minValue;
        private Int32 _maxValue;

        public void ConvertFromExternal(OCRPanelRange _ocrPanelRange)
        {
            this._minValue = _ocrPanelRange.MinValue;
            this._maxValue = _ocrPanelRange.MaxValue;
        }

        public OCRPanelRange ConvertToExternal()
        {
            OCRPanelRange toReturn = new OCRPanelRange();
            toReturn.MaxValue = this._maxValue ;
            toReturn.MinValue = this._minValue;
            return toReturn;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_OCRWindowRect : IHasExternalVersionIn<WindowRect>, IHasExternalVersionOut<WindowRect>
    {
        private UInt32 _windowWidth;
        private UInt32 _windowHeight;

        public void ConvertFromExternal(WindowRect _windowRect)
        {
            this._windowWidth = _windowRect.WindowWidth;
            this._windowHeight = _windowRect.WindowHeight;
        }

        public WindowRect ConvertToExternal()
        {
            WindowRect toReturn = new WindowRect();
            toReturn.WindowWidth = this._windowWidth;
            toReturn.WindowHeight = this._windowHeight;
            return toReturn;
        }
    }

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_AIMDPMGradeReport : IHasExternalVersionOut<AimDpmGradeReport>
    {
        private AimGrade _overallGrade;
        private AimGrade _decodingGrade;
        private AimGrade _cellContrastGrade;
        private float _cellContrast;
        private AimGrade _printGrowthGrade;
        private float _printGrowth;
        private AimGrade _axialNonUniformityGrade;
        private float _axialNonUniformity;
        private AimGrade _unusedErrorCorrectionGrade;
        private float _unusedErrorCorrection;
        private AimGrade _gridNonUniformityGrade;
        private float _gridNonUniformity;
        private AimGrade _cellModulationGrade;
        private AimGrade _fixedPatternDamageGrade;
        private float _fixedPatternDamage;
        private AimGrade _minimumReflectanceGrade;
        private float _minimumReflectance;

        public AimDpmGradeReport ConvertToExternal()
        {
            AimDpmGradeReport report = new AimDpmGradeReport();
            report.OverallGrade = this._overallGrade;
            report.DecodingGrade = this._decodingGrade;
            report.CellContrastGrade = this._cellContrastGrade;
            report.PrintGrowthGrade = this._printGrowthGrade;
            report.AxialNonUniformityGrade = this._axialNonUniformityGrade;
            report.UnusedErrorCorrectionGrade = this._unusedErrorCorrectionGrade;
            report.GridNonUniformityGrade = this._gridNonUniformityGrade;
            report.CellModulationGrade = this._cellModulationGrade;
            report.FixedPatternDamageGrade = this._fixedPatternDamageGrade;
            report.MinimumReflectanceGrade = this._minimumReflectanceGrade;
            report.CellContrast = this._cellContrast;
            report.PrintGrowth = this._printGrowth;
            report.AxialNonUniformity = this._axialNonUniformity;
            report.UnusedErrorCorrection = this._unusedErrorCorrection;
            report.GridNonUniformity = this._gridNonUniformity;
            report.FixedPatternDamage = this._fixedPatternDamage;
            report.MinimumReflectance = this._minimumReflectance;
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GradeReportISO15415 : IHasExternalVersionOut<GradeReportISO15415>
    {
        private AimGrade _overallGrade;
        private AimGrade _decodingGrade;
        private AimGrade _symbolContrastGrade;
        private float _symbolContrast;
        private AimGrade _printGrowthGrade;
        private float _printGrowth;
        private AimGrade _axialNonUniformityGrade;
        private float _axialNonUniformity;
        private AimGrade _unusedErrorCorrectionGrade;
        private float _unusedErrorCorrection;
        private AimGrade _gridNonUniformityGrade;
        private float _gridNonUniformity;
        private AimGrade _modulationGrade;
        private AimGrade _fixedPatternDamageGrade;
        private float _fixedPatternDamage;

        public GradeReportISO15415 ConvertToExternal()
        {
            GradeReportISO15415 report = new GradeReportISO15415();
            report.OverallGrade = this._overallGrade;
            report.DecodingGrade = this._decodingGrade;
            report.SymbolContrastGrade = this._symbolContrastGrade;
            report.PrintGrowthGrade = this._printGrowthGrade;
            report.AxialNonUniformityGrade = this._axialNonUniformityGrade;
            report.UnusedErrorCorrectionGrade = this._unusedErrorCorrectionGrade;
            report.GridNonUniformityGrade = this._gridNonUniformityGrade;
            report.ModulationGrade = this._modulationGrade;
            report.FixedPatternDamageGrade = this._fixedPatternDamageGrade;
            report.SymbolContrast = this._symbolContrast;
            report.PrintGrowth = this._printGrowth;
            report.AxialNonUniformity = this._axialNonUniformity;
            report.UnusedErrorCorrection = this._unusedErrorCorrection;
            report.GridNonUniformity = this._gridNonUniformity;
            report.FixedPatternDamage = this._fixedPatternDamage;
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_GradeReportISO16022 : IHasExternalVersionOut<GradeReportISO16022>
    {
        private AimGrade _overallGrade;
        private AimGrade _decodingGrade;
        private AimGrade _symbolContrastGrade;
        private float _symbolContrast;
        private AimGrade _printGrowthGrade;
        private float _printGrowth;
        private AimGrade _axialNonUniformityGrade;
        private float _axialNonUniformity;
        private AimGrade _unusedErrorCorrectionGrade;
        private float _unusedErrorCorrection;
        public GradeReportISO16022 ConvertToExternal()
        {
            GradeReportISO16022 report = new GradeReportISO16022();
            report.OverallGrade = this._overallGrade;
            report.DecodingGrade = this._decodingGrade;
            report.SymbolContrastGrade = this._symbolContrastGrade;
            report.PrintGrowthGrade = this._printGrowthGrade;
            report.AxialNonUniformityGrade = this._axialNonUniformityGrade;
            report.UnusedErrorCorrectionGrade = this._unusedErrorCorrectionGrade;
            report.SymbolContrast = this._symbolContrast;
            report.PrintGrowth = this._printGrowth;
            report.AxialNonUniformity = this._axialNonUniformity;
            report.UnusedErrorCorrection = this._unusedErrorCorrection;
            return report;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EdgeOptions2 : IHasExternalVersionIn<EdgeOptions>
	{
		private EdgePolaritySearchMode _polarity;
		private UInt32 _kernelSize;
		private UInt32 _width;
		private float _minThreshold;
		private InterpolationMethod _interpolationType;
		private ColumnProcessingMode _columnProcessingMode;

		
		public void ConvertFromExternal(EdgeOptions options)
		{
			_polarity = options.Polarity;
			_kernelSize = options.KernelSize;
			_width = options.Width;
			_minThreshold = (float)options.MinimumThreshold;
			_interpolationType = options.InterpolationType;
			_columnProcessingMode = options.ColumnProcessingMode;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ArcInfo2 : IHasExternalVersionOut<Arc>
	{
		private CVI_PointFloat _center;
		private double _radius;
		private double _startAngle;
		private double _endAngle;

		
		public Arc ConvertToExternal()
		{
			return new Arc(_center.ConvertToExternal(), _radius, _startAngle, _endAngle);
		}
	}

	
	[EditorBrowsable(EditorBrowsableState.Never)]
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    public struct CVI_EdgeInfo : IHasExternalVersionOut<EdgeInfo>
	{
		private CVI_PointFloat _position;
		private CVI_PointFloat _calibratedPosition;
		private double _distance;
		private double _calibratedDistance;
		private double _magnitude;
		private double _noisePeak;
		private Int32 _rising;

		
		public EdgeInfo ConvertToExternal()
		{
			EdgeInfo info = new EdgeInfo();
			info.Position = _position.ConvertToExternal();
			info.CalibratedPosition = _calibratedPosition.ConvertToExternal();
			info.Distance = _distance;
			info.CalibratedDistance = _calibratedDistance;
			info.Magnitude = _magnitude;
			info.NoisePeak = _noisePeak;
			info.Polarity = (_rising != 0) ? EdgePolarity.Rising : EdgePolarity.Falling;
			return info;
		}

		public CVI_PointFloat Position 
		{
			get { return _position; }
		}
		public CVI_PointFloat CalibratedPosition
		{
			get { return _calibratedPosition; }
		}
		public double Distance 
		{
			get { return _distance; }
		}
		public double CalibratedDistance 
		{
			get { return _calibratedDistance; }
		}
		public double Magnitude 
		{
			get { return _magnitude; }
		}
		public double NoisePeak 
		{
			get { return _noisePeak; }
		}
		public Int32 Rising 
		{
			get { return _rising; }
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EdgeReport2 : IHasExternalVersionOut<EdgeReport>
	{
		private IntPtr _edges;
		private UInt32 _numEdges;
		private IntPtr _gradientInfo;
		private UInt32 _numGradientInfo;
		private Int32 _calibrationValid;

		
		public EdgeReport ConvertToExternal()
		{
			EdgeReport report = new EdgeReport();
			report.Edges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_edges, _numEdges, false);
			report.GradientInfo = Utilities.ConvertIntPtrToCollection<double>(_gradientInfo, _numGradientInfo, false);
			report.CalibrationValid = _calibrationValid != 0;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SearchArcInfo : IHasExternalVersionOut<SearchArcInfo>
	{
		private CVI_ArcInfo2 _arcCoordinates;
		private CVI_EdgeReport2 _edgeReport;

		
		public SearchArcInfo ConvertToExternal()
		{
			SearchArcInfo info = new SearchArcInfo();
			info.Arc = _arcCoordinates.ConvertToExternal();
			info.EdgeReport = _edgeReport.ConvertToExternal();
			return info;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ConcentricRakeReport2 : IHasExternalVersionOut<ConcentricRakeReport>
	{
		private IntPtr _firstEdges;
		private UInt32 _numFirstEdges;
		private IntPtr _lastEdges;
		private UInt32 _numLastEdges;
		private IntPtr _searchArcs;
		private UInt32 _numSearchArcs;

		
		public ConcentricRakeReport ConvertToExternal()
		{
			ConcentricRakeReport report = new ConcentricRakeReport();
			report.FirstEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_firstEdges, _numFirstEdges, false);
			report.LastEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_lastEdges, _numLastEdges, false);
			report.SearchArcs = Utilities.ConvertIntPtrToCollection<SearchArcInfo, CVI_SearchArcInfo>(_searchArcs, _numSearchArcs, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ThresholdData : IHasExternalVersionIn<ThresholdData>, IHasExternalVersionOut<ThresholdData>
	{
		private float _rangeMin;
		private float _rangeMax;
		private float _newValue;
		private int _useNewValue;

		
		public void ConvertFromExternal(ThresholdData data)
		{
			_rangeMin = (float)data.Range.Minimum;
			_rangeMax = (float)data.Range.Maximum;
			_newValue = (float)data.NewValue;
			_useNewValue = data.UseNewValue ? 1 : 0;
		}

		public ThresholdData ConvertToExternal()
		{
			Range range = new Range(_rangeMin, _rangeMax);
			ThresholdData data = new ThresholdData(range);
			data.UseNewValue = _useNewValue != 0;
			data.NewValue = _newValue;
			return data;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CircleReport : IHasExternalVersionOut<CircleReport>
	{
		private CVI_Point _center;
		private int _radius;
		private int _area;

		
		public CircleReport ConvertToExternal()
		{
			CircleReport report = new CircleReport(_center.ConvertToExternal());
			report.Radius = _radius;
			report.Area = _area;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CurveOptions : IHasExternalVersionIn<CurveOptions>
	{
		private ExtractionMode _extractionMode;
		private int _threshold;
		private EdgeFilterSize _filterSize;
		private int _minLength;
		private int _rowStepSize;
		private int _columnStepSize;
		private int _maxEndPointGap;
		private int _onlyClosed;
		private int _subpixelAccuracy;

		
		public void ConvertFromExternal(CurveOptions options)
		{
			_extractionMode = options.ExtractionMode;
			_threshold = options.Threshold;
			_filterSize = options.FilterSize;
			_minLength = options.MinimumLength;
			_rowStepSize = options.RowStepSize;
			_columnStepSize = options.ColumnStepSize;
			_maxEndPointGap = options.MaximumEndPointGap;
			_onlyClosed = options.OnlyClosed ? 1 : 0;
			_subpixelAccuracy = options.SubpixelAccuracy ? 1 : 0;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_Curve : IHasExternalVersionOut<CurveReport>
	{
		private IntPtr _points;
		private UInt32 _numPoints;
		private int _closed;
		private double _curveLength;
		private double _minEdgeStrength;
		private double _maxEdgeStrength;
		private double _averageEdgeStrength;

		
		public CurveReport ConvertToExternal()
		{
			CurveReport report = new CurveReport();
			report.Points = Utilities.ConvertIntPtrToCollection<PointContour, CVI_PointFloat>(_points, _numPoints, false);
			report.Closed = _closed != 0;
			report.CurveLength = _curveLength;
			report.MinimumEdgeStrength = _minEdgeStrength;
			report.MaximumEdgeStrength = _maxEdgeStrength;
			report.AverageEdgeStrength = _averageEdgeStrength;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LinearAverages : IHasExternalVersionOut<LinearAveragesReport>
	{
		private IntPtr _columnAverages;
		private int _columnCount;
		private IntPtr _rowAverages;
		private int _rowCount;
		private IntPtr _risingDiagAverages;
		private int _risingDiagCount;
		private IntPtr _fallingDiagAverages;
		private int _fallingDiagCount;

		
		public LinearAveragesReport ConvertToExternal()
		{
			LinearAveragesReport report = new LinearAveragesReport();
			report.ColumnAverages = Utilities.ConvertIntPtrToCollection<double, float>(_columnAverages, _columnCount, false, delegate(float f) { return f; });
			report.RowAverages = Utilities.ConvertIntPtrToCollection<double, float>(_rowAverages, _rowCount, false, delegate(float f) { return f; });
			report.RisingDiagonalAverages = Utilities.ConvertIntPtrToCollection<double, float>(_risingDiagAverages, _risingDiagCount, false, delegate(float f) { return f; });
			report.FallingDiagonalAverages = Utilities.ConvertIntPtrToCollection<double, float>(_fallingDiagAverages, _fallingDiagCount, false, delegate(float f) { return f; });
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QuantifyData : IHasExternalVersionOut<QuantifyReportItem>
	{
		private float _mean;
		private float _stdDev;
		private float _min;
		private float _max;
		private float _calibratedArea;
		private Int32 _pixelArea;
		private float _relativeSize;

		
		public QuantifyReportItem ConvertToExternal()
		{
			QuantifyReportItem item = new QuantifyReportItem();
			item.Mean = _mean;
			item.StandardDeviation = _stdDev;
			item.PixelRange.Initialize(_min, _max);
			item.CalibratedArea = _calibratedArea;
			item.PixelArea = _pixelArea;
			item.RelativeSize = _relativeSize;
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_QuantifyReport : IHasExternalVersionOut<QuantifyReport>
	{
		private CVI_QuantifyData _global;
		private IntPtr _regions;
		private Int32 _regionCount;

		
		public QuantifyReport ConvertToExternal()
		{
			QuantifyReport report = new QuantifyReport();
			report.Global = _global.ConvertToExternal();
			report.Regions = Utilities.ConvertIntPtrToCollection<QuantifyReportItem, CVI_QuantifyData>(_regions, _regionCount, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ROIProfile : IHasExternalVersionOut<RoiProfileReport>
	{
		private CVI_LineProfile _report;
		private IntPtr _pixels;

		
		public RoiProfileReport ConvertToExternal()
		{
			RoiProfileReport profile = new RoiProfileReport();
			profile.Report = _report.ConvertToExternal();
			// There are the same number of entries in Pixels as in Report.ProfileData
			profile.Pixels = Utilities.ConvertIntPtrToCollection<PointContour, CVI_Point>(_pixels, profile.Report.ProfileData.Count, false);
			return profile;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_View3DOptions : IHasExternalVersionIn<View3DOptions>
	{
		private Int32 _sizeReduction;
		private Int32 _maxHeight;
		private Direction3D _direction;
		private float _alpha;
		private float _beta;
		private Int32 _border;
		private Int32 _background;
		private Plane3D _plane;

		
		public void ConvertFromExternal(View3DOptions options) {
			_sizeReduction = options.SizeReduction;
			_maxHeight = options.MaximumHeight;
			_direction = options.Direction;
			_alpha = (float)options.Alpha;
			_beta = (float)options.Beta;
			_border = options.Border;
			_background = options.Background;
			_plane = options.Plane;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_BCGOptions : IHasExternalVersionIn<BcgOptions>
	{
		private float _brightness;
		private float _contrast;
		private float _gamma;

		
		public void ConvertFromExternal(BcgOptions options)
		{
			_brightness = (float)options.Brightness;
			_contrast = (float)options.Contrast;
			_gamma = (float)options.Gamma;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FitCircleOptions : IHasExternalVersionIn<FitCircleOptions>
	{
		private Int32 _rejectOutliers;
		private double _minScore;
		private double _pixelRadius;
		private Int32 _maxIterations;

		
		public void ConvertFromExternal(FitCircleOptions options)
		{
			_rejectOutliers = options.RejectOutliers ? 1 : 0;
			_minScore = options.MinimumScore;
			_pixelRadius = options.PixelRadius;
			_maxIterations = options.MaximumIterations;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_BestCircle2 : IHasExternalVersionOut<FitCircleReport, Collection<PointContour>>
	{
		private CVI_PointFloat _center;
		private double _radius;
		private double _area;
		private double _perimeter;
		private double _error;
		private Int32 _valid;
		private IntPtr _pointsUsed;
		private Int32 _numPointsUsed;

		
		public FitCircleReport ConvertToExternal(Collection<PointContour> points)
		{
			FitCircleReport report = new FitCircleReport();
			report.Center = _center.ConvertToExternal();
			report.Radius = _radius;
			report.Circle.Initialize(_center.X - _radius, _center.Y - _radius, 2 * _radius, 2 * _radius);
			report.Area = _area;
			report.Perimeter = _perimeter;
			report.Error = _error;
			report.Valid = _valid != 0;
			Collection<int> pointsIndices = Utilities.ConvertIntPtrToCollection<Int32>(_pointsUsed, _numPointsUsed, false);
			report.PointsUsed.Clear();
			foreach (int index in pointsIndices) {
				report.PointsUsed.Add((PointContour)points[index].Clone());
			}
			return report;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FitEllipseOptions : IHasExternalVersionIn<FitEllipseOptions>
	{
		private Int32 _rejectOutliers;
		private double _minScore;
		private double _pixelRadius;
		private Int32 _maxIterations;

		
		public void ConvertFromExternal(FitEllipseOptions options)
		{
			_rejectOutliers = options.RejectOutliers ? 1 : 0;
			_minScore = options.MinimumScore;
			_pixelRadius = options.PixelRadius;
			_maxIterations = options.MaximumIterations;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_BestEllipse2 : IHasExternalVersionOut<FitEllipseReport, Collection<PointContour>>
	{
		private CVI_PointFloat _center;
		private CVI_PointFloat _majorAxisStart;
		private CVI_PointFloat _majorAxisEnd;
		private CVI_PointFloat _minorAxisStart;
		private CVI_PointFloat _minorAxisEnd;
		private double _area;
		private double _perimeter;
		private double _error;
		private Int32 _valid;
		private IntPtr _pointsUsed;
		private Int32 _numPointsUsed;

		
		public FitEllipseReport ConvertToExternal(Collection<PointContour> points)
		{
			FitEllipseReport report = new FitEllipseReport();
			report.Center = _center.ConvertToExternal();
			report.MajorAxis = new LineContour(_majorAxisStart.ConvertToExternal(), _majorAxisEnd.ConvertToExternal());
			report.MinorAxis = new LineContour(_minorAxisStart.ConvertToExternal(), _minorAxisEnd.ConvertToExternal());
			report.Area = _area;
			report.Perimeter = _perimeter;
			report.Error = _error;
			report.Valid = _valid != 0;
			Collection<int> pointsIndices = Utilities.ConvertIntPtrToCollection<Int32>(_pointsUsed, _numPointsUsed, false);
			report.PointsUsed.Clear();
			foreach (int index in pointsIndices) {
				report.PointsUsed.Add((PointContour)points[index].Clone());
			}
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FitLineOptions : IHasExternalVersionIn<FitLineOptions>
	{
		private float _minScore;
		private float _pixelRadius;
		private Int32 _numRefinements;

		
		public void ConvertFromExternal(FitLineOptions options)
		{
			_minScore = (float)options.MinimumScore;
			_pixelRadius = (float)options.PixelRadius;
			_numRefinements = options.MaximumIterations;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineEquation : IHasExternalVersionOut<LineEquation>
	{
		private double _a;
		private double _b;
		private double _c;

		
		public LineEquation ConvertToExternal()
		{
			LineEquation equation = new LineEquation();
			equation.A = _a;
			equation.B = _b;
			equation.C = _c;
			return equation;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineSegment : IHasExternalVersionOut<LineContour>
    {
        private CVI_PointFloat _start;
        private CVI_PointFloat _end;

        
        public LineContour ConvertToExternal()
        {
            LineContour item = new LineContour();
            item.Start = _start.ConvertToExternal();
            item.End = _end.ConvertToExternal();
            return item;
        }
    }

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_BestLine : IHasExternalVersionOut<FitLineReport, Collection<PointContour>>
	{
		private CVI_PointFloat _start;
		private CVI_PointFloat _end;
		private CVI_LineEquation _equation;
		private Int32 _valid;
		private double _error;
		private IntPtr _pointsUsed;
		private Int32 _numPointsUsed;

		
		public FitLineReport ConvertToExternal(Collection<PointContour> points)
		{
			FitLineReport report = new FitLineReport();
			report.LineSegment = new LineContour(_start.ConvertToExternal(), _end.ConvertToExternal());
			report.Equation = _equation.ConvertToExternal();
			report.Valid = _valid != 0;
			report.Error = _error;
			Collection<int> pointsIndices = Utilities.ConvertIntPtrToCollection<Int32>(_pointsUsed, _numPointsUsed, false);
			report.PointsUsed.Clear();
			foreach (int index in pointsIndices) {
				report.PointsUsed.Add((PointContour)points[index].Clone());
			}
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ContourPoint : IHasExternalVersionOut<ContourPoint>
	{
		private double _x;
		private double _y;
		private double _curvature;
		private double _xDisplacement;
		private double _yDisplacement;

		
		public ContourPoint ConvertToExternal()
		{
			ContourPoint point = new ContourPoint();
			point.Point.Initialize(_x, _y);
			point.Curvature = _curvature;
			point.XDisplacement = _xDisplacement;
			point.YDisplacement = _yDisplacement;
			return point;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SegmentInfo : IHasExternalVersionOut<SegmentReport>
	{
		private Int32 _numberOfPoints;
		private Int32 _isOpen;
		private double _weight;
		private IntPtr _points;

		
		public SegmentReport ConvertToExternal()
		{
			SegmentReport report = new SegmentReport();
			report.IsOpen = _isOpen != 0;
			report.Weight = _weight;
			report.Points = Utilities.ConvertIntPtrToCollection<ContourPoint, CVI_ContourPoint>(_points, _numberOfPoints, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_DetectExtremesOptions : IHasExternalVersionIn<DetectPeaksOrValleysOptions>
	{
		private double _threshold;
		private int _width;

		
		public void ConvertFromExternal(DetectPeaksOrValleysOptions options)
		{
			_threshold = options.Threshold;
			_width = options.Width;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ExtremeReport : IHasExternalVersionOut<PeakValleyReportItem>
	{
		private double _location;
		private double _amplitude;
		private double _secondDerivative;

		
		public PeakValleyReportItem ConvertToExternal()
		{
			PeakValleyReportItem item = new PeakValleyReportItem();
			item.Location = _location;
			item.Amplitude = _amplitude;
			item.SecondDerivative = _secondDerivative;
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindEdgeOptions2 : IHasExternalVersionIn<FindEdgeOptions>
	{
		private RakeDirection _direction;
		private Int32 _showSearchArea;
		private Int32 _showSearchLines;
		private Int32 _showEdgesFound;
		private Int32 _showResult;
		private Rgb32Value _searchAreaColor;
		private Rgb32Value _searchLinesColor;
		private Rgb32Value _searchEdgesColor;
		private Rgb32Value _resultColor;
		private string _overlayGroupName;
		private CVI_EdgeOptions2 _edgeOptions;

		
		public void ConvertFromExternal(FindEdgeOptions options)
		{
			_direction = options.Direction;
			_showSearchArea = options.ShowSearchArea ? 1 : 0;
			_showSearchLines = options.ShowSearchLines ? 1 : 0;
			_showEdgesFound = options.ShowEdgesFound ? 1 : 0;
			_showResult = options.ShowResult ? 1 : 0;
			_searchAreaColor = options.SearchAreaColor;
			_searchLinesColor = options.SearchLinesColor;
			_searchEdgesColor = options.SearchEdgesColor;
			_resultColor = options.ResultColor;
			_overlayGroupName = options.OverlayGroupName;
			_edgeOptions = new CVI_EdgeOptions2();
			_edgeOptions.ConvertFromExternal(options.EdgeOptions);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindCircularEdgeOptions : IHasExternalVersionIn<FindCircularEdgeOptions>
	{
		private SpokeDirection _direction;
		private Int32 _showSearchArea;
		private Int32 _showSearchLines;
		private Int32 _showEdgesFound;
		private Int32 _showResult;
		private Rgb32Value _searchAreaColor;
		private Rgb32Value _searchLinesColor;
		private Rgb32Value _searchEdgesColor;
		private Rgb32Value _resultColor;
		private string _overlayGroupName;
		private CVI_EdgeOptions2 _edgeOptions;

		
		public void ConvertFromExternal(FindCircularEdgeOptions options)
		{
			_direction = options.Direction;
			_showSearchArea = options.ShowSearchArea ? 1 : 0;
			_showSearchLines = options.ShowSearchLines ? 1 : 0;
			_showEdgesFound = options.ShowEdgesFound ? 1 : 0;
			_showResult = options.ShowResult ? 1 : 0;
			_searchAreaColor = options.SearchAreaColor;
			_searchLinesColor = options.SearchLinesColor;
			_searchEdgesColor = options.SearchEdgesColor;
			_resultColor = options.ResultColor;
			_overlayGroupName = options.OverlayGroupName;
			_edgeOptions = new CVI_EdgeOptions2();
			_edgeOptions.ConvertFromExternal(options.EdgeOptions);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindConcentricEdgeOptions : IHasExternalVersionIn<FindConcentricEdgeOptions>
	{
		private ConcentricRakeDirection _direction;
		private Int32 _showSearchArea;
		private Int32 _showSearchLines;
		private Int32 _showEdgesFound;
		private Int32 _showResult;
		private Rgb32Value _searchAreaColor;
		private Rgb32Value _searchLinesColor;
		private Rgb32Value _searchEdgesColor;
		private Rgb32Value _resultColor;
		private string _overlayGroupName;
		private CVI_EdgeOptions2 _edgeOptions;

		
		public void ConvertFromExternal(FindConcentricEdgeOptions options)
		{
			_direction = options.Direction;
			_showSearchArea = options.ShowSearchArea ? 1 : 0;
			_showSearchLines = options.ShowSearchLines ? 1 : 0;
			_showEdgesFound = options.ShowEdgesFound ? 1 : 0;
			_showResult = options.ShowResult ? 1 : 0;
			_searchAreaColor = options.SearchAreaColor;
			_searchLinesColor = options.SearchLinesColor;
			_searchEdgesColor = options.SearchEdgesColor;
			_resultColor = options.ResultColor;
			_overlayGroupName = options.OverlayGroupName;
			_edgeOptions = new CVI_EdgeOptions2();
			_edgeOptions.ConvertFromExternal(options.EdgeOptions);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CircularEdgeFitOptions : IHasExternalVersionIn<CircularEdgeFitOptions>
	{
		private UInt32 _maxPixelRadius;
		private double _stepSize;
		private RakeProcessType _processType;

		
		public void ConvertFromExternal(CircularEdgeFitOptions options)
		{
			_maxPixelRadius = options.MaxPixelRadius;
			_stepSize = options.StepSize;
			_processType = options.ProcessType;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ConcentricEdgeFitOptions : IHasExternalVersionIn<ConcentricEdgeFitOptions>
	{
		private UInt32 _maxPixelRadius;
		private double _stepSize;
		private RakeProcessType _processType;

		
		public void ConvertFromExternal(ConcentricEdgeFitOptions options)
		{
			_maxPixelRadius = options.MaxPixelRadius;
			_stepSize = options.StepSize;
			_processType = options.ProcessType;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_StraightEdgeOptions : IHasExternalVersionIn<StraightEdgeOptions>
	{
		private UInt32 _numLines;
		private StraightEdgeSearchMode _searchMode;
		private double _minScore;
		private double _maxScore;
		private double _orientation;
		private double _angleRange;
		private double _angleTolerance;
		private UInt32 _stepSize;
		private double _minSignalToNoiseRatio;
		private double _minCoverage;
		private UInt32 _houghIterations;

		
		public void ConvertFromExternal(StraightEdgeOptions options)
		{
			_numLines = options.NumberOfLines;
			_searchMode = options.SearchMode;
			_minScore = options.ScoreRange.Minimum;
			_maxScore = options.ScoreRange.Maximum;
			_orientation = options.Orientation;
			_angleRange = options.AngleRange;
			_angleTolerance = options.AngleTolerance;
			_stepSize = options.StepSize;
			_minSignalToNoiseRatio = options.MinimumSignalToNoiseRatio;
			_minCoverage = options.MinimumCoverage;
			_houghIterations = options.HoughIterations;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_StraightEdge : IHasExternalVersionOut<StraightEdgeReportItem>
	{
		private CVI_LineFloat _straightEdgeCoordinates;
		private CVI_LineFloat _calibratedStraightEdgeCoordinates;
		private double _angle;
		private double _calibratedAngle;
		private double _score;
		private double _straightness;
		private double _averageSignalToNoiseRatio;
		private int _calibrationValid;
		private IntPtr _usedEdges;
		private UInt32 _numUsedEdges;

		
		public StraightEdgeReportItem ConvertToExternal()
		{
			StraightEdgeReportItem item = new StraightEdgeReportItem();
			item.StraightEdge = _straightEdgeCoordinates.ConvertToExternal();
			item.CalibratedStraightEdge = _calibratedStraightEdgeCoordinates.ConvertToExternal();
			item.Angle = _angle;
			item.CalibratedAngle = _calibratedAngle;
			item.Score = _score;
			item.Straightness = _straightness;
			item.AverageSignalToNoiseRatio = _averageSignalToNoiseRatio;
			item.CalibrationValid = _calibrationValid != 0;
			item.EdgesUsed = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_usedEdges, _numUsedEdges, false);
			return item;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindCircularEdgeReport : IHasExternalVersionOut<FindCircularEdgeReport>
	{
		private CVI_PointFloat _centerCalibrated;
		private double _radiusCalibrated;
		private CVI_PointFloat _center;
		private double _radius;
		private double _roundness;
		private double _avgStrength;
		private double _avgSNR;
		private Int32 _circleFound;

		
		public FindCircularEdgeReport ConvertToExternal()
		{
			FindCircularEdgeReport report = new FindCircularEdgeReport();
			report.CircleFound = _circleFound != 0 ? true : false;
			report.Center = _center.ConvertToExternal();
			report.CenterCalibrated = _centerCalibrated.ConvertToExternal();
			report.Radius = _radius;
			report.RadiusCalibrated = _radiusCalibrated;
			report.Roundness = _roundness;
			report.AvgSNR = _avgSNR;
			report.AvgStrength = _avgStrength;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindConcentricEdgeReport : IHasExternalVersionOut<FindConcentricEdgeReport>
	{
		private CVI_PointFloat _startPt;
		private CVI_PointFloat _endPt;
		private CVI_PointFloat _startPtCalibrated;
		private CVI_PointFloat _endPtCalibrated;
		private double _angle;
		private double _angleCalibrated;
		private double _straightness;
		private double _avgStrength;
		private double _avgSNR;
		private Int32 _lineFound;

		
		public FindConcentricEdgeReport ConvertToExternal()
		{
			FindConcentricEdgeReport report = new FindConcentricEdgeReport();
			report.LineFound = _lineFound != 0 ? true : false;
			report.StartPt = _startPt.ConvertToExternal();
			report.StartPtCalibrated = _startPtCalibrated.ConvertToExternal();
			report.EndPt = _endPt.ConvertToExternal();
			report.EndPtCalibrated = _endPtCalibrated.ConvertToExternal();
			report.Angle = _angle;
			report.AngleCalibrated = _angleCalibrated;
			report.Straightness = _straightness;
			report.AvgSNR = _avgSNR;
			report.AvgStrength = _avgStrength;
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindEdgeReport : IHasExternalVersionOut<FindEdgeReport>
	{
		private IntPtr _straightEdges;
		private UInt32 _numStraightEdges;

		
		public FindEdgeReport ConvertToExternal()
		{
			FindEdgeReport report = new FindEdgeReport();
			report.StraightEdges = Utilities.ConvertIntPtrToCollection<StraightEdgeReportItem, CVI_StraightEdge>(_straightEdges, _numStraightEdges, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindTransformRectOptions2 : IHasExternalVersionIn<FindTransformRectOptions>
	{
		private FindReferenceDirection _direction;
		private Int32 _showSearchArea;
		private Int32 _showSearchLines;
		private Int32 _showEdgesFound;
		private Int32 _showResult;
		private Rgb32Value _searchAreaColor;
		private Rgb32Value _searchLinesColor;
		private Rgb32Value _searchEdgesColor;
		private Rgb32Value _resultColor;
		private string _overlayGroupName;
		private CVI_EdgeOptions2 _edgeOptions;

		
		public void ConvertFromExternal(FindTransformRectOptions options)
		{
			_direction = options.Direction;
			_showSearchArea = options.ShowSearchArea ? 1 : 0;
			_showSearchLines = options.ShowSearchLines ? 1 : 0;
			_showEdgesFound = options.ShowEdgesFound ? 1 : 0;
			_showResult = options.ShowResult ? 1 : 0;
			_searchAreaColor = options.SearchAreaColor;
			_searchLinesColor = options.SearchLinesColor;
			_searchEdgesColor = options.SearchEdgesColor;
			_resultColor = options.ResultColor;
			_overlayGroupName = options.OverlayGroupName;
			_edgeOptions = new CVI_EdgeOptions2();
			_edgeOptions.ConvertFromExternal(options.EdgeOptions);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_AxisReport : IHasExternalVersionOut<AxisReport>
	{
		private CVI_PointFloat _origin;
		private CVI_PointFloat _mainAxisEnd;
		private CVI_PointFloat _secondaryAxisEnd;

		
		public AxisReport ConvertToExternal()
		{
			AxisReport report = new AxisReport();
			report.MainAxis = new LineContour(_origin.ConvertToExternal(), _mainAxisEnd.ConvertToExternal());
			report.SecondaryAxis = new LineContour(_origin.ConvertToExternal(), _secondaryAxisEnd.ConvertToExternal());
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_FindTransformRectsOptions2 : IHasExternalVersionIn<FindTransformRectsOptions>
	{
		private FindReferenceDirection _direction;
		private Int32 _showSearchArea;
		private Int32 _showSearchLines;
		private Int32 _showEdgesFound;
		private Int32 _showResult;
		private Rgb32Value _searchAreaColor;
		private Rgb32Value _searchLinesColor;
		private Rgb32Value _searchEdgesColor;
		private Rgb32Value _resultColor;
		private string _overlayGroupName;
		private CVI_EdgeOptions2 _primaryEdgeOptions;
		private CVI_EdgeOptions2 _secondaryEdgeOptions;

		
		public void ConvertFromExternal(FindTransformRectsOptions options)
		{
			_direction = options.Direction;
			_showSearchArea = options.ShowSearchArea ? 1 : 0;
			_showSearchLines = options.ShowSearchLines ? 1 : 0;
			_showEdgesFound = options.ShowEdgesFound ? 1 : 0;
			_showResult = options.ShowResult ? 1 : 0;
			_searchAreaColor = options.SearchAreaColor;
			_searchLinesColor = options.SearchLinesColor;
			_searchEdgesColor = options.SearchEdgesColor;
			_resultColor = options.ResultColor;
			_overlayGroupName = options.OverlayGroupName;
			_primaryEdgeOptions = new CVI_EdgeOptions2();
			_primaryEdgeOptions.ConvertFromExternal(options.PrimaryEdgeOptions);
			_secondaryEdgeOptions = new CVI_EdgeOptions2();
			_secondaryEdgeOptions.ConvertFromExternal(options.SecondaryEdgeOptions);
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SearchLineInfo : IHasExternalVersionOut<SearchLineInfo>
	{
		private CVI_LineFloat _lineCoordinates;
		private CVI_EdgeReport2 _edgeReport;

		
		public SearchLineInfo ConvertToExternal()
		{
			SearchLineInfo info = new SearchLineInfo();
			info.Line = _lineCoordinates.ConvertToExternal();
			info.EdgeReport = _edgeReport.ConvertToExternal();
			return info;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RakeReport2 : IHasExternalVersionOut<RakeReport>
	{
		private IntPtr _firstEdges;
		private UInt32 _numFirstEdges;
		private IntPtr _lastEdges;
		private UInt32 _numLastEdges;
		private IntPtr _searchLines;
		private UInt32 _numSearchLines;

		
		public RakeReport ConvertToExternal()
		{
			RakeReport report = new RakeReport();
			report.FirstEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_firstEdges, _numFirstEdges, false);
			report.LastEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_lastEdges, _numLastEdges, false);
			report.SearchLines = Utilities.ConvertIntPtrToCollection<SearchLineInfo, CVI_SearchLineInfo>(_searchLines, _numSearchLines, false);
			return report;
		}

		public IntPtr FirstEdges
		{
			get { return _firstEdges; }
		}

		public UInt32 NumFirstEdges
		{
			get { return _numFirstEdges; }
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SimpleEdgeOptions : IHasExternalVersionIn<SimpleEdgeOptions>
	{
		private LevelType _type;
		private Int32 _threshold;
		private Int32 _hysteresis;
		private EdgeProcess _process;
		private Int32 _subpixel;

		
		public void ConvertFromExternal(SimpleEdgeOptions options)
		{
			_type = options.Type;
			_threshold = options.Threshold;
			_hysteresis = options.Hysteresis;
			_process = options.Process;
			_subpixel = options.SubPixel ? 1 : 0;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_StraightEdgeReport2 : IHasExternalVersionOut<StraightEdgeReport>
	{
		private IntPtr _straightEdges;
		private UInt32 _numStraightEdges;
		private IntPtr _searchLines;
		private UInt32 _numSearchLines;

		
		public StraightEdgeReport ConvertToExternal()
		{
			StraightEdgeReport report = new StraightEdgeReport();
			report.StraightEdges = Utilities.ConvertIntPtrToCollection<StraightEdgeReportItem, CVI_StraightEdge>(_straightEdges, _numStraightEdges, false);
			report.SearchLines = Utilities.ConvertIntPtrToCollection<SearchLineInfo, CVI_SearchLineInfo>(_searchLines, _numSearchLines, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_SpokeReport2 : IHasExternalVersionOut<SpokeReport>
	{
		private IntPtr _firstEdges;
		private UInt32 _numFirstEdges;
		private IntPtr _lastEdges;
		private UInt32 _numLastEdges;
		private IntPtr _searchLines;
		private UInt32 _numSearchLines;

		
		public SpokeReport ConvertToExternal()
		{
			SpokeReport report = new SpokeReport();
			report.FirstEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_firstEdges, _numFirstEdges, false);
			report.LastEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo, CVI_EdgeInfo>(_lastEdges, _numLastEdges, false);
			report.SearchLines = Utilities.ConvertIntPtrToCollection<SearchLineInfo, CVI_SearchLineInfo>(_searchLines, _numSearchLines, false);
			return report;
		}

		public IntPtr FirstEdges
		{
			get { return _firstEdges; }
		}

		public UInt32 NumFirstEdges
		{
			get { return _numFirstEdges; }
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ColorInformation : IHasExternalVersionOut<ColorInformation>, IHasExternalVersionIn<ColorInformation>, IDisposable
	{
		private Int32 _infoCount;
		private Int32 _saturation;
		private IntPtr _info;

		
		public ColorInformation ConvertToExternal()
		{
			ColorInformation info = new ColorInformation();
			info.Saturation = _saturation;
			info.Information = Utilities.ConvertIntPtrToCollection<double>(_info, _infoCount, false);
			return info;
		}

		
		public void ConvertFromExternal(ColorInformation info)
		{
			_saturation = info.Saturation;
			_infoCount = info.Information.Count;
			_info = Utilities.ConvertCollectionToIntPtr(info.Information);
		}
		#region IDisposable Members

		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _info is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_info != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_info);
				_info = IntPtr.Zero;
			}
		}
		#endregion
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal unsafe struct CVI_DrawTextOptions : IHasExternalVersionIn<DrawTextOptions>
	{
		private fixed byte _fontName[32];
		private Int32 _fontSize;
		private Int32 _bold;
		private Int32 _italic;
		private Int32 _underline;
		private Int32 _strikeout;
		private Int32 _textAlignment;
		private Int32 _fontColor;

		
		public void ConvertFromExternal(DrawTextOptions options)
		{
			byte[] _strBytes = System.Text.Encoding.Default.GetBytes(options.FontName);
			fixed (byte* _strPtr = _fontName) {
				for (int i = 0; i < _strBytes.Length && i < 31; ++i)
				{
					_strPtr[i] = _strBytes[i];
				}
				_strPtr[(_strBytes.Length < 31) ? _strBytes.Length : 31] = (byte)0;
			}
			_fontSize = options.FontSize;
			_bold = options.TextDecoration.Bold ? 1 : 0;
			_italic = options.TextDecoration.Italic ? 1 : 0;
			_underline = options.TextDecoration.Underline ? 1 : 0;
			_strikeout = options.TextDecoration.Strikeout ? 1 : 0;
			_textAlignment = (int)options.Alignment;
			_fontColor = (int)options.Color;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CannyOptions : IHasExternalVersionIn<CannyOptions>
	{
		private float _sigma;
		private float _upperThreshold;
		private float _lowerThreshold;
		private int _windowSize;

		
		public void ConvertFromExternal(CannyOptions options)
		{
			_sigma = (float)options.Sigma;
			_upperThreshold = (float)options.ThresholdRange.Maximum;
			_lowerThreshold = (float)options.ThresholdRange.Minimum;
			_windowSize = options.WindowSize;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ShapeReport : IHasExternalVersionOut<ShapeReport>
	{
		private CVI_Rectangle _coordinates;
		private CVI_Point _centroid;
		private int _size;
		private double _score;

		
		public ShapeReport ConvertToExternal()
		{
			ShapeReport _report = new ShapeReport();
			_report.BoundingRectangle = _coordinates.ConvertToExternal();
			_report.Centroid = _centroid.ConvertToExternal();
			_report.Size = _size;
			_report.Score = _score;
			return _report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LCDOptions : IHasExternalVersionIn<LcdOptions>
	{
		private int _litSegments;
		private float _threshold;
		private int _sign;
		private int _decimalPoint;

		
		public void ConvertFromExternal(LcdOptions options)
		{
			_litSegments = options.LitSegments ? 1 : 0;
			_threshold = (float)options.Threshold;
			_sign = options.Sign ? 1 : 0;
			_decimalPoint = options.DecimalPoint ? 1 : 0;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LCDSegments : IHasExternalVersionOut<LcdSegments>
	{
		private BitVector32 _bits;

		
		public LcdSegments ConvertToExternal()
		{
			LcdSegments segments = new LcdSegments();
			// The bits we want are actually at the end, in reverse order.
			BitVector32.Section aSection = BitVector32.CreateSection(1);
			BitVector32.Section bSection = BitVector32.CreateSection(1, aSection);
			BitVector32.Section cSection = BitVector32.CreateSection(1, bSection);
			BitVector32.Section dSection = BitVector32.CreateSection(1, cSection);
			BitVector32.Section eSection = BitVector32.CreateSection(1, dSection);
			BitVector32.Section fSection = BitVector32.CreateSection(1, eSection);
			BitVector32.Section gSection = BitVector32.CreateSection(1, fSection);
			segments.A = _bits[aSection] != 0;
			segments.B = _bits[bSection] != 0;
			segments.C = _bits[cSection] != 0;
			segments.D = _bits[dSection] != 0;
			segments.E = _bits[eSection] != 0;
			segments.F = _bits[fSection] != 0;
			segments.G = _bits[gSection] != 0;
			return segments;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LCDReport : IHasExternalVersionOut<LcdReport>
	{
		private IntPtr _text;
		private IntPtr _segmentInfo;
		private Int32 _numCharacters;
		private Int32 _reserved;

		
		public LcdReport ConvertToExternal()
		{
			LcdReport report = new LcdReport();
			report.Text = Marshal.PtrToStringAnsi(_text);
			report.SegmentInfo = Utilities.ConvertIntPtrToCollection<LcdSegments, CVI_LCDSegments>(_segmentInfo, _numCharacters, false);
			return report;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LearnColorPatternOptions : IHasExternalVersionIn<LearnColorPatternOptions>, IDisposable
	{
		private LearnMode _learnMode;
		private ImageFeatureMode _featureMode;
		private Int32 _threshold;
		private ColorIgnoreMode _ignoreMode;
		private IntPtr _colorsToIgnore;
		private Int32 _numColorsToIgnore;

		
		public void ConvertFromExternal(LearnColorPatternOptions options)
		{
			_learnMode = options.LearnMode;
			_featureMode = options.FeatureMode;
			_threshold = options.Threshold;
			_ignoreMode = options.IgnoreMode;
			_colorsToIgnore = Utilities.ConvertCollectionToIntPtr<ColorInformation, CVI_ColorInformation>(options.ColorsToIgnore);
			_numColorsToIgnore = options.ColorsToIgnore.Count;
		}
		#region IDisposable Members

		
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _colorsToIgnore is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_colorsToIgnore != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_colorsToIgnore);
				_colorsToIgnore = IntPtr.Zero;
			}
		}
		#endregion
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MatchColorPatternOptions : IDisposable, IHasExternalVersionIn<MatchColorPatternOptions>
	{
		private MatchMode _matchMode;
		private ImageFeatureMode _featureMode;
		private Int32 _minContrast;
		private Int32 _subpixelAccuracy;
		private IntPtr _angleRanges;
		private Int32 _numRanges;
		private double _colorWeight;
		private ColorSensitivity _sensitivity;
		private SearchStrategy _strategy;
		private Int32 _numMatchesRequested;
		private float _minMatchScore;

		
		public void ConvertFromExternal(MatchColorPatternOptions options)
		{
			_matchMode = options.MatchMode;
			_featureMode = options.FeatureMode;
			_minContrast = options.MinimumContrast;
			_subpixelAccuracy = (options.SubpixelAccuracy) ? 1 : 0;
			_numRanges = options.RotationAngleRanges.Count;
			_angleRanges = Utilities.ConvertCollectionToIntPtr<Range, CVI_RotationAngleRange>(options.RotationAngleRanges);
			_colorWeight = options.ColorWeight;
			_sensitivity = options.ColorSensitivity;
			_strategy = options.SearchStrategy;
			_numMatchesRequested = options.NumberOfMatchesRequested;
			_minMatchScore = (float)options.MinimumMatchScore;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _angleRanges is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_angleRanges != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_angleRanges);
				_angleRanges = IntPtr.Zero;
			}
		}
		#endregion
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CircleDescriptor : IHasExternalVersionIn<CircleDescriptor>
	{
		private double _minRadius;
		private double _maxRadius;

		
		public void ConvertFromExternal(CircleDescriptor descriptor)
		{
			_minRadius = descriptor.RadiusRange.Minimum;
			_maxRadius = descriptor.RadiusRange.Maximum;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_ShapeDetectionOptions : IDisposable, IHasExternalVersionIn<ShapeDetectionOptions>
	{
		private GeometricMatchModes _mode;
		private IntPtr _angleRanges;
		private Int32 _numAngleRanges;
		private CVI_RangeFloat _scaleRange;
		private double _minMatchScore;

		
		public void ConvertFromExternal(ShapeDetectionOptions item)
		{
			_mode = item.Mode;
			_numAngleRanges = item.RotationAngleRanges.Count;
			_angleRanges = Utilities.ConvertCollectionToIntPtr<Range, CVI_RangeFloat>(item.RotationAngleRanges);
			_scaleRange = new CVI_RangeFloat();
			_scaleRange.ConvertFromExternal(item.ScaleRange);
			_minMatchScore = item.MinimumMatchScore;
		}

		#region IDisposable Members

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		
		public void Dispose(bool disposing) {
			// Since _angleRanges is unmanaged, it's OK to access it here (even though we may be
			// called during finalization if disposing == false)
			if (_angleRanges != IntPtr.Zero) 
			{
				Marshal.FreeCoTaskMem(_angleRanges);
				_angleRanges = IntPtr.Zero;
			}
		}
		#endregion
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_CircleMatch : IHasExternalVersionOut<CircleMatch>
	{
		private CVI_PointFloat _position;
		private double _radius;
		private double _score;

		
		public CircleMatch ConvertToExternal()
		{
			CircleMatch match = new CircleMatch();
			match.Center = _position.ConvertToExternal();
			match.Radius = _radius;
			match.Score = _score;
			match.Circle = new OvalContour(match.Center.X - match.Radius, match.Center.Y - match.Radius, match.Radius * 2, match.Radius * 2);
			return match;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EllipseDescriptor : IHasExternalVersionIn<EllipseDescriptor>
	{
		private double _minMajorRadius;
		private double _maxMajorRadius;
		private double _minMinorRadius;
		private double _maxMinorRadius;

		
		public void ConvertFromExternal(EllipseDescriptor descriptor)
		{
			_minMajorRadius = descriptor.MajorRadiusRange.Minimum;
			_maxMajorRadius = descriptor.MajorRadiusRange.Maximum;
			_minMinorRadius = descriptor.MinorRadiusRange.Minimum;
			_maxMinorRadius = descriptor.MinorRadiusRange.Maximum;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_EllipseMatch : IHasExternalVersionOut<EllipseMatch>
	{
		private CVI_PointFloat _position;
		private double _rotation;
		private double _majorRadius;
		private double _minorRadius;
		private double _score;

		
		public EllipseMatch ConvertToExternal()
		{
			EllipseMatch match = new EllipseMatch();
			match.Center = _position.ConvertToExternal();
			match.Rotation = _rotation;
			match.MajorRadius = _majorRadius;
			match.MinorRadius = _minorRadius;
			match.Score = _score;
			return match;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineDescriptor : IHasExternalVersionIn<LineDescriptor>
	{
		private double _minLength;
		private double _maxLength;

		
		public void ConvertFromExternal(LineDescriptor descriptor)
		{
			_minLength = descriptor.LengthRange.Minimum;
			_maxLength = descriptor.LengthRange.Maximum;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_LineMatch : IHasExternalVersionOut<LineMatch>
	{
		private CVI_PointFloat _startPoint;
		private CVI_PointFloat _endPoint;
		private double _length;
		private double _rotation;
		private double _score;

		
		public LineMatch ConvertToExternal()
		{
			LineMatch match = new LineMatch();
			match.Line = new LineContour(_startPoint.ConvertToExternal(), _endPoint.ConvertToExternal());
			match.Length = _length;
			match.Rotation = _rotation;
			match.Score = _score;
			return match;
		}
	}

#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RectangleDescriptor : IHasExternalVersionIn<RectangleDescriptor>
	{
		private double _minWidth;
		private double _maxWidth;
		private double _minHeight;
		private double _maxHeight;

		
		public void ConvertFromExternal(RectangleDescriptor descriptor)
		{
			_minWidth = descriptor.WidthRange.Minimum;
			_maxWidth = descriptor.WidthRange.Maximum;
			_minHeight = descriptor.HeightRange.Minimum;
			_maxHeight = descriptor.HeightRange.Maximum;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_RectangleMatch : IHasExternalVersionOut<RectangleMatch>
	{
		private CVI_PointFloat _corner0;
		private CVI_PointFloat _corner1;
		private CVI_PointFloat _corner2;
		private CVI_PointFloat _corner3;
		private double _rotation;
		private double _width;
		private double _height;
		private double _score;

		
		public RectangleMatch ConvertToExternal()
		{
			RectangleMatch match = new RectangleMatch();
			match.Corners.Add(_corner0.ConvertToExternal());
			match.Corners.Add(_corner1.ConvertToExternal());
			match.Corners.Add(_corner2.ConvertToExternal());
			match.Corners.Add(_corner3.ConvertToExternal());
			match.Rotation = _rotation;
			match.Width = _width;
			match.Height = _height;
			match.Score = _score;
			return match;
		}
	}

    
#if (Bit32)
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
#else
    [StructLayout(LayoutKind.Sequential)]
#endif
    internal struct CVI_MeasureParticlesReport : IHasExternalVersionOut<ParticleMeasurementsReport>
	{
		private IntPtr _pixelMeasurements;
		private IntPtr _calibratedMeasurements;
		private IntPtr _numParticles;
		private IntPtr _numMeasurements;

		
		public ParticleMeasurementsReport ConvertToExternal()
		{
			double[,] pixelArray = new double[0,0], calibratedArray = new double[0,0];
			if (_pixelMeasurements != IntPtr.Zero)
			{
				pixelArray = Utilities.ConvertIntPtrIndirectTo2DArrayDouble(_pixelMeasurements, _numParticles, _numMeasurements, false);
			}
			if (_calibratedMeasurements != IntPtr.Zero)
			{
				calibratedArray = Utilities.ConvertIntPtrIndirectTo2DArrayDouble(_calibratedMeasurements, _numParticles, _numMeasurements, false);
			}
			return new ParticleMeasurementsReport(pixelArray, calibratedArray);
		}
	}

	
	[SuppressUnmanagedCodeSecurity()]
	internal static class VisionDll
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
		internal static extern IntPtr imaqHistogram(IntPtr image, Int32 numClasses, float min, float max, IntPtr mask);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqColorHistogram2(IntPtr image, Int32 numClasses, ColorMode colorMode, IntPtr zeroWhiteReference, IntPtr mask);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqColorHistogram2(IntPtr image, Int32 numClasses, ColorMode colorMode, ref CieXyzValue whiteReference, IntPtr mask);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqSupervisedColorSegmentation(IntPtr _session, IntPtr _labelImage, IntPtr _srcImage, IntPtr _roi, IntPtr _labelsIn, int _numLabelsIn, int maxDistance, int minIdentificationScore, ref CVI_ColorSegmentationOptions _segmentOptions);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGetColorSegmentationMaxDistance(IntPtr _session, ref CVI_ColorSegmentationOptions _segmentOptions, SegmentationDistanceLevel _distLevel, out int maxDistance);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqLabelToROI(IntPtr _srcImage, IntPtr _labelsIn, int _numLabelsIn, int _maxNumVectors, int _isExternalEdges);

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
		internal unsafe static extern Int32 imaqLearnPattern3(IntPtr _image, Int32 learningMode, [In] CVI_LearnPatternAdvancedOptions* advancedOptions, IntPtr _mask);

        [DllImport("nivision.dll")]
        internal unsafe static extern Int32 imaqLearnPattern4(IntPtr _image, IntPtr _mask, MatchingAlgorithm matchingAlgorithm, ref CVI_PMRotationAngleRange rotationAngleRange, IntPtr cviLearnAdvancedSetupDataOption, Int32 Count, out CVI_LearnTemplateReport cviLearnReport);

		
		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchPattern2(IntPtr _image, IntPtr _pattern, ref CVI_MatchPatternOptions options, ref CVI_MatchPatternAdvancedOptions advancedOptions, CVI_Rectangle searchRect, out Int32 numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchPattern3(IntPtr _image, IntPtr _pattern, ref CVI_MatchPatternOptions options, ref CVI_MatchPatternAdvancedOptions advancedOptions, IntPtr roi, out Int32 numMatches);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqMatchPattern4(IntPtr _image, IntPtr _pattern, MatchingAlgorithm matchingAlgorithm, Int32 numRequestedMatches, float minScore, IntPtr cviRotationAngleRange, Int32 noRanges, IntPtr roi, IntPtr cviMatchAdvancedSetupDataOption, Int32 Countout, out Int32 numMatches);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqGetTemplateInformation(IntPtr _image, IntPtr _mask, MatchingAlgorithm matchingAlgorithm, out CVI_PyramidInfo PyramidInfo, out CVI_MatchOffsetInfo MatchOffSetInfo);

		
		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqRefineMatches(IntPtr _image, IntPtr _pattern, [In] CVI_PatternMatch[] _candidatesIn, int _numCandidatesIn, ref CVI_MatchPatternOptions _options, ref CVI_MatchPatternAdvancedOptions _advancedOptions, out Int32 _numCandidates);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLearnGeometricPattern(IntPtr _image, [In] CVI_PointFloat originOffset, ref CVI_CurveOptions curveOptions, ref CVI_LearnGeometricPatternAdvancedOptions advancedOptions, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLearnGeometricPattern2(IntPtr _image, [In] CVI_PointFloat originOffset, [In] double angleOffset, ref CVI_CurveOptions curveOptions, ref CVI_LearnGeometricPatternAdvancedOptions2 advancedOptions, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchGeometricPattern2(IntPtr _image, IntPtr _pattern, ref CVI_CurveOptions curveOptions, ref CVI_MatchGeometricPatternOptions matchOptions, ref CVI_MatchGeometricPatternAdvancedOptions2 advancedMatchOptions, IntPtr roi, out IntPtr numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchGeometricPattern3(IntPtr _image, IntPtr _pattern, ref CVI_CurveOptions curveOptions, ref CVI_MatchGeometricPatternOptions matchOptions, ref CVI_MatchGeometricPatternAdvancedOptions3 advancedMatchOptions, IntPtr roi, out IntPtr numMatches);

		[DllImport("nivision.dll")]      
		internal static extern Int32 imaqScale(IntPtr _destination, IntPtr _source, Int32 xScale, Int32 yScale, CVI_ScalingMode scaleMode, CVI_Rectangle rect);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDuplicate(IntPtr _destination, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetPixel(IntPtr _image, CVI_Point pixel, ref CVI_PixValue value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetPixel(IntPtr _image, CVI_Point pixel, CVI_PixValue value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCopyRect(IntPtr _destination, IntPtr _source, CVI_Rectangle _rect, CVI_Point _destinationLoc);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLearnGoldenTemplate(IntPtr _image, CVI_PointFloat originOffset, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCompareGoldenTemplate(IntPtr _image, IntPtr _goldenTemplate, IntPtr _brightDefects, IntPtr _darkDefects, ref CVI_InspectionAlignment alignment, ref CVI_InspectionOptions options);

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
		internal static extern Int32 imaqLearnCalibrationGrid(IntPtr _image, IntPtr _roi, ref CVI_LearnCalibrationOptions _options, ref CVI_GridDescriptor _grid, ref CVI_CoordinateSystem _system, ref CVI_RangeFloat _range, out float quality);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLearnCalibrationPoints(IntPtr _image, ref CVI_CalibrationPoints _points, IntPtr _roi, ref CVI_LearnCalibrationOptions _options, ref CVI_GridDescriptor _grid, ref CVI_CoordinateSystem _system, out float quality);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetSimpleCalibration(IntPtr _image, Int32 method, Int32 learnTable, ref CVI_GridDescriptor _grid, ref CVI_CoordinateSystem _system);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCorrectCalibratedImage(IntPtr _destination, IntPtr _source, CVI_PixValue _fill, Int32 _interpolationMethod, IntPtr _roi);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqTransformPixelToRealWorld(IntPtr _image, CVI_PointFloat[] _pixelCoordinates, Int32 _numCoordinates);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqTransformRealWorldToPixel(IntPtr _image, CVI_PointFloat[] _realWorldCoordinates, Int32 _numCoordinates);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqThreshold(IntPtr _destination, IntPtr _source, float rangeMin, float rangeMax, int useNewValue, float newValue);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqRejectBorder(IntPtr _destination, IntPtr _source, Int32 _connectivity8);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDrawLineOnImage(IntPtr _destination, IntPtr _source, Int32 _mode, CVI_Point _start, CVI_Point _end, float _newPixelValue);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDrawShapeOnImage(IntPtr _destination, IntPtr _source, CVI_Rectangle _rect, Int32 _drawMode, CVI_ShapeMode _shapeMode, float _newPixelValue);

		[DllImport("nivision.dll")]
		internal static extern CVI_Color2 imaqChangeColorSpace2(ref CVI_Color2 sourceColor, ColorMode _sourceSpace, ColorMode _destinationSpace, double _offset, IntPtr _nullWhiteReference);

		[DllImport("nivision.dll")]
		internal static extern CVI_Color2 imaqChangeColorSpace2(ref CVI_Color2 sourceColor, ColorMode _sourceSpace, ColorMode _destinationSpace, double _offset, ref CieXyzValue _whiteReference);

		[DllImport("nivision.dll", EntryPoint="#298")]
		internal static extern Int32 Priv_Particle(IntPtr _image, Int32 _connectivity8, Int32 _calibrated, out Array1D _reportArray);

		[DllImport("nivision.dll", EntryPoint = "#159")]
		internal static extern Int32 Priv_InitArray1D(out Array1D array);

		[DllImport("nivision.dll", EntryPoint = "#156")]
		internal static extern Int32 Priv_DisposeArray1DBytes(ref Array1D array);

		[DllImport("nivision.dll", EntryPoint = "#299")]
		internal static extern Int32 Priv_ParticleMeasurement(IntPtr _image, Int32 _measurementType, Int32 _connectivity8, Int32 _calibrated, out Array1D _measurementArray);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqParticleFilter4(IntPtr _destination, IntPtr _source, CVI_ParticleFilterCriteria2[] _criteria, Int32 _criteriaCount, ref CVI_ParticleFilterOptions2 _options, IntPtr _roi, out Int32 _numParticles);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqExtractColorPlanes(IntPtr _image, Int32 _colorMode, IntPtr _plane1, IntPtr _plane2, IntPtr _plane3);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqReplaceColorPlanes(IntPtr _destination, IntPtr _source, ColorMode _colorMode, IntPtr _plane1, IntPtr _plane2, IntPtr _plane3);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqResample(IntPtr _destination, IntPtr _source, Int32 _newWidth, Int32 _newHeight, Int32 _interpolationMethod, CVI_Rectangle _rect);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqCreateCharSet();

		[DllImport("nivision.dll", EntryPoint = "#2052", CharSet=CharSet.Ansi)]
		internal static extern Int32 niocrReadFile(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _readOptions, Int32 _appendToCharacterSet, [In, Out] byte[] _characterSetDescription);

        [DllImport("nivision.dll", EntryPoint = "#2087", CharSet = CharSet.Ansi)]
        internal static extern Int32 niocrReadFile2(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, Int32 _readOptions, Int32 _appendToCharacterSet, [In, Out] byte[] _characterSetDescription);

		[DllImport("nivision.dll", EntryPoint = "#2053", CharSet = CharSet.Ansi)]
		internal static extern Int32 niocrWriteFile(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, string _characterSetDescription);

        [DllImport("nivision.dll", EntryPoint = "#2088", CharSet = CharSet.Ansi)]
        internal static extern Int32 niocrWriteFile2(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, string _characterSetDescription);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetCharCount(IntPtr _set);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDeleteChar(IntPtr _set, int _index);

		[DllImport("nivision.dll", EntryPoint = "#2082", CharSet=CharSet.Ansi)]
		internal static extern Int32 dotNET_Train(IntPtr _set, IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _newCharValue, Int32 _index, IntPtr _roi);

        [DllImport("nivision.dll", EntryPoint = "#3003", CharSet = CharSet.Ansi)]
        internal static extern Int32 dotNET_Train2(IntPtr _set, IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _newCharValue, Int32 _index, IntPtr _roi);

		[DllImport("nivision.dll", EntryPoint = "#2083")]
		internal static extern IntPtr dotNET_ReadText(IntPtr _image, IntPtr _set, IntPtr _roi);

        [DllImport("nivision.dll", EntryPoint = "#3002")]
        internal static extern IntPtr dotNET_ReadText2(IntPtr _image, Int32 numberOfLinesRequested, IntPtr _set, IntPtr _roi);

		[DllImport("nivision.dll", EntryPoint = "#2084")]
		internal static extern Int32 dotNET_GetCharacterImage(IntPtr _session, IntPtr _character, IntPtr _image);

		[DllImport("nivision.dll", EntryPoint = "#2085")]
		internal static extern Int32 dotNET_GetInternalImage(IntPtr _session, IntPtr _character, IntPtr _image);

		[DllImport("nivision.dll", EntryPoint = "#2003")]
		internal static extern Int32 niocrGetThresholdMode(IntPtr _session, out Int32 _thresholdMode);

        [DllImport("nivision.dll", EntryPoint = "#2089")]
        internal static extern Int32 niocrGetOCRThresholdType(IntPtr _session, out OCRThresholdType _thresholdType);

		
		[DllImport("nivision.dll", EntryPoint = "#2002")]
		internal static extern Int32 niocrSetThresholdMode(IntPtr _session, Int32 _thresholdMode);

        [DllImport("nivision.dll", EntryPoint = "#3016")]
        internal static extern Int32 niocrSetOCRThresholdType(IntPtr _session, OCRThresholdType _thresholdType);

        [DllImport("nivision.dll", EntryPoint = "#2090")]
        internal static extern Int32 niocrSetLocalThresholdOptions(IntPtr _session, LocalThresholdMethod _method, CVI_OCRWindowRect _windowBounds, double _devWeight, ParticleType _darkObj);
        
        [DllImport("nivision.dll", EntryPoint = "#2091")]
        internal static extern Int32 niocrGetLocalThresholdOptions(IntPtr _session, out LocalThresholdMethod _method, out CVI_OCRWindowRect _windowBounds, out double _devWeight, out ParticleType _darkObj);

        [DllImport("nivision.dll", EntryPoint = "#2092")]
        internal static extern Int32 niocrSetColorThresholdOptions(IntPtr _session, ColorMode _mode, CVI_OCRPanelRange _RedHue, CVI_OCRPanelRange _GreenSaturation, CVI_OCRPanelRange _BlueLumIntenVal);

        [DllImport("nivision.dll", EntryPoint = "#2093")]
        internal static extern Int32 niocrGetColorThresholdOptions(IntPtr _sesson, out ColorMode _mode, out CVI_OCRPanelRange _RedHue, out CVI_OCRPanelRange _GreenSaturation, out CVI_OCRPanelRange _BlueLumIntenVal);

		[DllImport("nivision.dll", EntryPoint = "#2009")]
		internal static extern Int32 niocrGetOptimizeForSpeed(IntPtr _session, out Int32 _optimizeForSpeed);

		[DllImport("nivision.dll", EntryPoint = "#2008")]
		internal static extern Int32 niocrSetOptimizeForSpeed(IntPtr _session, Int32 _optimizeForSpeed);

		[DllImport("nivision.dll", EntryPoint = "#2011")]
		internal static extern Int32 niocrGetPerformBiModalCalculation(IntPtr _session, out Int32 _performBiModalCalculation);

		[DllImport("nivision.dll", EntryPoint = "#2010")]
		internal static extern Int32 niocrSetPerformBiModalCalculation(IntPtr _session, Int32 _performBiModalCalculation);

		[DllImport("nivision.dll", EntryPoint = "#2013")]
		internal static extern Int32 niocrGetNumberOfBlocks(IntPtr _session, out Int32 _numberOfBlocks);

		[DllImport("nivision.dll", EntryPoint = "#2012")]
		internal static extern Int32 niocrSetNumberOfBlocks(IntPtr _session, Int32 _numberOfBlocks);

		[DllImport("nivision.dll", EntryPoint = "#2015")]
		internal static extern Int32 niocrGetElementVerticalSpacingMaximum(IntPtr _session, out Int32 _elementVerticalSpacingMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2014")]
		internal static extern Int32 niocrSetElementVerticalSpacingMaximum(IntPtr _session, Int32 _elementVerticalSpacingMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2017")]
		internal static extern Int32 niocrGetElementHorizontalSpacingMaximum(IntPtr _session, out Int32 _elementHorizontalSpacingMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2016")]
		internal static extern Int32 niocrSetElementHorizontalSpacingMaximum(IntPtr _session, Int32 _elementHorizontalSpacingMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2020")]
		internal static extern Int32 niocrSetNumberOfValidCharacterPositions(IntPtr _session, Int32 _numberOfPositions);

		[DllImport("nivision.dll", EntryPoint = "#2023")]
		internal static extern IntPtr niocrGetCharacterAtIndex(IntPtr _session, Int32 _characterIndex);

		[DllImport("nivision.dll", EntryPoint = "#2031")]
		internal static extern Int32 niocrGetAcceptanceLevel(IntPtr _session, out Int32 _acceptanceLevel);

		[DllImport("nivision.dll", EntryPoint = "#2032")]
		internal static extern Int32 niocrGetAspectRatio(IntPtr _session, out Int32 _aspectRatio);

        [DllImport("nivision.dll", EntryPoint = "#2095")]
        internal static extern Int32 niocrGetTextLocation(IntPtr _session, out Int32 _textLocation);

        [DllImport("nivision.dll", EntryPoint = "#2097")]
        internal static extern Int32 niocrGetLineSeparatorType(IntPtr _session, out Int32 _lineSeparator);

		
		[DllImport("nivision.dll", EntryPoint = "#2033")]
		internal static extern Int32 niocrGetDarkCharacters(IntPtr _session, out Int32 _darkCharacters);

		[DllImport("nivision.dll", EntryPoint = "#2035")]
		internal static extern Int32 niocrGetBoundingRectangleWidthMaximum(IntPtr _session, out Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2036")]
		internal static extern Int32 niocrGetCharacterSizeMinimum(IntPtr _session, out Int32 _characterSizeMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2037")]
		internal static extern Int32 niocrGetCharacterSpacingMinimum(IntPtr _session, out Int32 _characterSpacingMinimum);

        [DllImport("nivision.dll", EntryPoint = "#2099")]
        internal static extern Int32 niocrGetShortestPathSegment(IntPtr _session, out Int32 _shortestPathSegment);

        [DllImport("nivision.dll", EntryPoint = "#3001")]
        internal static extern Int32 niocrGetMinPixelsForSpace(IntPtr _session, out Int32 _minPixelsForSpace);

		
		[DllImport("nivision.dll", EntryPoint = "#2038")]
		internal static extern Int32 niocrGetNumberOfErosions(IntPtr _session, out Int32 _numberOfErosions);

		[DllImport("nivision.dll", EntryPoint = "#2039")]
		internal static extern Int32 niocrGetReadStrategy(IntPtr _session, out Int32 _readStrategy);

		[DllImport("nivision.dll", EntryPoint = "#2040")]
		internal static extern Int32 niocrGetRemoveObjectsTouchingROI(IntPtr _session, out Int32 _remove);

		[DllImport("nivision.dll", EntryPoint = "#2041")]
		internal static extern Int32 niocrGetSubstitutionCharacter(IntPtr _session, out byte _substitutionCharacter);

		[DllImport("nivision.dll", EntryPoint = "#2042")]
		internal static extern Int32 niocrSetAcceptanceLevel(IntPtr _session, Int32 _acceptanceLevel);

		[DllImport("nivision.dll", EntryPoint = "#2043")]
		internal static extern Int32 niocrSetAspectRatio(IntPtr _session, Int32 _aspectRatio);
        
        [DllImport("nivision.dll", EntryPoint = "#2094")]
        internal static extern Int32 niocrSetTextLocation(IntPtr _session, Int32 _textLocation);

        [DllImport("nivision.dll", EntryPoint = "#2096")]
        internal static extern Int32 niocrSetLineSeparatorType(IntPtr _session, Int32 _lineSeparator);

		
		[DllImport("nivision.dll", EntryPoint = "#2044")]
		internal static extern Int32 niocrSetDarkCharacters(IntPtr _session, Int32 _darkCharacters);

		[DllImport("nivision.dll", EntryPoint = "#2045")]
		internal static extern Int32 niocrSetBoundingRectangleWidthMaximum(IntPtr _session, Int32 _boundingRectangleWidthMinimum);
		//================================================ ==========================================
		/// <exclude/>
[DllImport("nivision.dll", EntryPoint = "#2046")]
		internal static extern Int32 niocrSetCharacterSizeMinimum(IntPtr _session, Int32 _characterSizeMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2047")]
		internal static extern Int32 niocrSetCharacterSpacingMinimum(IntPtr _session, Int32 _characterSpacingMinimum);

        [DllImport("nivision.dll", EntryPoint = "#2098")]
        internal static extern Int32 niocrSetShortestPathSegment(IntPtr _session, Int32 _ShortestPathSegment);

        [DllImport("nivision.dll", EntryPoint = "#3000")]
        internal static extern Int32 niocrSetMinPixelsForSpace(IntPtr _session, Int32 _minPixelsForSpace);

		
		[DllImport("nivision.dll", EntryPoint = "#2048")]
		internal static extern Int32 niocrSetNumberOfErosions(IntPtr _session, Int32 _numberOfErosions);

		[DllImport("nivision.dll", EntryPoint = "#2049")]
		internal static extern Int32 niocrSetReadStrategy(IntPtr _session, Int32 _readStrategy);

		[DllImport("nivision.dll", EntryPoint = "#2050")]
		internal static extern Int32 niocrSetRemoveObjectsTouchingROI(IntPtr _session, Int32 _remove);

		[DllImport("nivision.dll", EntryPoint = "#2051")]
		internal static extern Int32 niocrSetSubstitutionCharacter(IntPtr _session, byte _substitutionCharacter);

		[DllImport("nivision.dll", EntryPoint = "#2054")]
		internal static extern Int32 niocrGetNumberOfValidCharacterPositions(IntPtr _session, out Int32 _numberOfPositions);

		[DllImport("nivision.dll", EntryPoint = "#2056")]
		internal static extern Int32 niocrGetReadResolution(IntPtr _session, out Int32 _readResolution);

		[DllImport("nivision.dll", EntryPoint = "#2057")]
		internal static extern Int32 niocrSetReadResolution(IntPtr _session, Int32 _readResolution);

		[DllImport("nivision.dll", EntryPoint = "#2058")]
		internal static extern Int32 niocrGetAutoSplit(IntPtr _session, out Int32 _autoSplit);

		[DllImport("nivision.dll", EntryPoint = "#2059")]
		internal static extern Int32 niocrSetAutoSplit(IntPtr _session, Int32 _autoSplit);

		[DllImport("nivision.dll", EntryPoint = "#2060")]
		internal static extern Int32 niocrGetBoundingRectangleWidthMinimum(IntPtr _session, out Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2061")]
		internal static extern Int32 niocrSetBoundingRectangleWidthMinimum(IntPtr _session, Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2062")]
		internal static extern Int32 niocrGetBoundingRectangleHeightMinimum(IntPtr _session, out Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2063")]
		internal static extern Int32 niocrSetBoundingRectangleHeightMinimum(IntPtr _session, Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2064")]
		internal static extern Int32 niocrGetBoundingRectangleHeightMaximum(IntPtr _session, out Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2065")]
		internal static extern Int32 niocrSetBoundingRectangleHeightMaximum(IntPtr _session, Int32 _boundingRectangleWidthMinimum);

		[DllImport("nivision.dll", EntryPoint = "#2066")]
		internal static extern Int32 niocrGetCharacterSizeMaximum(IntPtr _session, out Int32 _characterSizeMaximum);

		[DllImport("nivision.dll", EntryPoint = "#2067")]
		internal static extern Int32 niocrSetCharacterSizeMaximum(IntPtr _session, Int32 _characterSizeMaximum);

		[DllImport("nivision.dll", EntryPoint = "#2005")]
		internal static extern Int32 niocrGetThresholdRange(IntPtr _session, out Int32 _minThreshold, out Int32 _maxThreshold);

		[DllImport("nivision.dll", EntryPoint = "#2004")]
		internal static extern Int32 niocrSetThresholdRange(IntPtr _session, Int32 _minThreshold, Int32 _maxThreshold);

		[DllImport("nivision.dll", EntryPoint = "#2007")]
		internal static extern Int32 niocrGetThresholdLimits(IntPtr _session, out Int32 _minThreshold, out Int32 _maxThreshold);

		[DllImport("nivision.dll", EntryPoint = "#2006")]
		internal static extern Int32 niocrSetThresholdLimits(IntPtr _session, Int32 _minThreshold, Int32 _maxThreshold);

		[DllImport("nivision.dll", EntryPoint = "#2073")]
		internal static extern Int32 niocrIsReferenceChar(IntPtr _session, IntPtr _character, out Int32 _isReferenceChar);

		[DllImport("nivision.dll", EntryPoint = "#2074")]
		internal static extern Int32 niocrSetReferenceChar(IntPtr _session, IntPtr _character, Int32 _isReferenceChar);

		[DllImport("nivision.dll", EntryPoint = "#2024")]
		internal static extern Int32 niocrGetCharacterValue(IntPtr _session, IntPtr _character, [In, Out] byte[] _characterValue);

		[DllImport("nivision.dll", EntryPoint = "#2027", CharSet=CharSet.Ansi)]
		internal static extern Int32 niocrRenameCharacter(IntPtr _session, IntPtr _character, [MarshalAs(UnmanagedType.LPStr)] string _characterValue);

		[DllImport("nivision.dll", EntryPoint = "#2021", CharSet=CharSet.Ansi)]
		internal static extern Int32 niocrSetValidCharacters(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _userDefinedCharacters, Int32 _predefinedCharacters, Int32 _position);

		[DllImport("nivision.dll", EntryPoint = "#2055")]
		internal static extern Int32 niocrGetValidCharacters(IntPtr _session, [In, Out] byte[] _userDefinedCharacters, out Int32 _predefinedCharacters, Int32 _position);

		[DllImport("nivision.dll", EntryPoint = "#2086", CharSet=CharSet.Ansi)]
		internal static extern IntPtr dotNET_VerifyText(IntPtr _session, IntPtr _image, [MarshalAs(UnmanagedType.LPStr)] string _expectedText, IntPtr _stringCache, out UInt32 _numScores, IntPtr _roi);

		[DllImport("nivision.dll", EntryPoint = "#2075")]
		internal static extern IntPtr niocrCreateStringCache(Int32 _size);

		[DllImport("nivision.dll", EntryPoint = "#2076")]
		internal static extern void niocrDisposeStringCache(IntPtr _stringCache);

		[DllImport("nivision.dll", EntryPoint = "#2077", CharSet=CharSet.Ansi)]
		internal static extern void niocrAddStringToCache(IntPtr _stringCache, [MarshalAs(UnmanagedType.LPStr)] string _newString, Int32 _position);

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
		internal static extern Int32 imaqOverlayPoints(IntPtr _image, CVI_Point[] _points, Int32 _numPoints, ref Rgb32Value _color, PointSymbolType _pointSymbol, IntPtr zeroUserPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqOverlayPoints(IntPtr _image, CVI_Point[] _points, Int32 _numPoints, ref Rgb32Value _color, PointSymbolType _pointSymbol, ref CVI_UserPointSymbol _userPointSymbol, [MarshalAs(UnmanagedType.LPStr)] string _group);

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
		internal static extern Int32 imaqAbsoluteDifference(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAbsoluteDifferenceConstant(IntPtr _destination, IntPtr _sourceA, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqCreateClassifier(ClassifierType _type);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqWriteClassifierFile(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, WriteClassifierFileMode _mode, ref CVI_String255 _description);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadClassifierFile(IntPtr _session, [MarshalAs(UnmanagedType.LPStr)] string _fileName, ReadClassifierFileMode _mode, out ClassifierType _type, out ClassifierEngineType _engine, ref CVI_String255 _description);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetClassifierAccuracy(IntPtr _session);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetClassifierSampleInfo(IntPtr _session, Int32 _index, out Int32 _numSamples);

		[DllImport("nivision.dll", EntryPoint = "#312")]
		internal static extern Int32 Priv_GetClassifierSampleInfo(IntPtr _thumbnailImage, IntPtr _session, Int32 _index, out Int32 _numSamples, ref Array1D _className, ref Array1D _featureVector);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDeleteClassifierSample(IntPtr _session, Int32 _index);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqRelabelClassifierSample(IntPtr _session, Int32 _index, [MarshalAs(UnmanagedType.LPStr)] string _newClass);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAddClassifierSample(IntPtr _image, IntPtr _session, IntPtr _roi, [MarshalAs(UnmanagedType.LPStr)] string _sampleClass, double[] _featureVector, UInt32 _vectorSize);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqClassify(IntPtr _image, IntPtr _session, IntPtr _roi, double[] _featureVector, UInt32 _vectorSize);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqAdvanceClassify(IntPtr _image, IntPtr _session, IntPtr _roi, double[] _featureVector, UInt32 _vectorSize);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetNearestNeighborOptions(IntPtr _session, out CVI_NearestNeighborOptions _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqTrainNearestNeighborClassifier(IntPtr _session, ref CVI_NearestNeighborOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetParticleClassifierOptions2(IntPtr _session, out CVI_ParticleClassifierPreprocessingOptions2 _preprocessingOptions, IntPtr _zeroOptions);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetParticleClassifierOptions2(IntPtr _session, IntPtr _zeroPreprocessingOptions, out CVI_ParticleClassifierOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetParticleClassifierOptions2(IntPtr _session, ref CVI_ParticleClassifierPreprocessingOptions2 _preprocessingOptions, IntPtr _zeroOptions);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetParticleClassifierOptions2(IntPtr _session, IntPtr _zeroPreprocessingOptions, ref CVI_ParticleClassifierOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetColorClassifierOptions(IntPtr _session, out CVI_ColorOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetColorClassifierOptions(IntPtr _session, ref CVI_ColorOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqClassificationTextureDefectOptions(IntPtr _session, ref CVI_WindowOptions _windowOptions, ref CVI_WaveletOptions _waveletOptions, IntPtr _bandsUsed, ref Int32 numBandsUsed, ref CVI_CooccurrenceOptions _coOccurenceOptions, char _set);

		[DllImport("nivision.dll")]
        internal static extern IntPtr imaqExtractTextureFeatures(IntPtr _srcImage, IntPtr _roi, ref CVI_WindowOptions _windowOptions, ref CVI_WaveletOptions _waveletOptions, IntPtr _bandsUsed, Int32 numBandsUsed, ref CVI_CooccurrenceOptions _coOccurenceOptions, char _useWindow);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqExtractWaveletBands(IntPtr _srcImage, ref CVI_WaveletOptions _waveletOptions, IntPtr _bandsUsed, Int32 numBandsUsed);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCooccurrenceMatrix(IntPtr _srcImage, IntPtr _roi, Int32 _levelPixel, ref CVI_DisplacementVector _displacementVector, IntPtr _featureOptionArray, Int32 _featureOptionArraySize, ref IntPtr _coOccurenceMatrix, ref Int32 _rows, ref Int32 _cols, ref IntPtr _featureVector, ref Int32 _featureVectorSize);

		[DllImport("nivision.dll")]
        internal static extern Int32 imaqDetectTextureDefect(IntPtr _session, IntPtr _destImage, IntPtr _srcImage, IntPtr _roi, Int32 _initialStepSize, Int32 _finalStepSize, char _defectPixelValue, double _minClassificationScore);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqROIToMask(IntPtr _mask, IntPtr _roi, Int32 _fillValue, IntPtr _imageModel, out Int32 _inSpace);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetMaskOffset(IntPtr _image, out CVI_Point _offset);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetMaskOffset(IntPtr _image, CVI_Point _offset);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqLineProfile(IntPtr _image, CVI_Point _start, CVI_Point _end);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetKernel(KernelFamily _family, Int32 _size, Int32 _number);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqConvolve2(IntPtr _destination, IntPtr _source, float[] _kernel, Int32 _matrixRows, Int32 _matrixCols, float _normalize, IntPtr _mask, CVI_RoundingMode _roundingMode);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetBorderSize(IntPtr _image, out Int32 _borderSize);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetBorderSize(IntPtr _image, Int32 _borderSize);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFillHoles(IntPtr _destination, IntPtr _source, Connectivity _connectivity8);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSizeFilter(IntPtr _destination, IntPtr _source, Connectivity _connectivity8, Int32 _erosions, SizeToKeep _keepSize, ref CVI_StructuringElement _structuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSizeFilter(IntPtr _destination, IntPtr _source, Connectivity _connectivity8, Int32 _erosions, SizeToKeep _keepSize, IntPtr _zeroStructuringElement);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadBarcode(IntPtr _image, BarcodeTypes _type, IntPtr _roi, Int32 _validate);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadPDF417Barcode(IntPtr _image, IntPtr _roi, Pdf417SearchMode _searchMode, out UInt32 numBarcodes);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadQRCode(IntPtr _image, IntPtr _roi, Int32 _reserved, ref CVI_QRCodeDescriptionOptions _descriptionOptions, ref CVI_QRCodeSizeOptions _sizeOptions, ref CVI_QRCodeSearchOptions _searchOptions);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadDataMatrixBarcode2(IntPtr _image, IntPtr _roi, DataMatrixGradingMode _prepareForGrading, ref CVI_DataMatrixDescriptionOptions _descriptionOptions, ref CVI_DataMatrixSizeOptions _sizeOptions, ref CVI_DataMatrixSearchOptions _searchOptions);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqReadDataMatrixBarcode3(IntPtr _image, IntPtr _roi, DataMatrixGradingMode _prepareForGrading, ref CVI_DataMatrixDescriptionOptions _descriptionOptions, ref CVI_DataMatrixSizeOptions _sizeOptions, ref CVI_DataMatrixSearchOptions _searchOptions, IntPtr _advancedOptions, Int32 Count);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqReadDataMatrixBarcode4(IntPtr _image, IntPtr _roi, DataMatrixGradingMode _prepareForGrading, ref CVI_DataMatrixDescriptionOptions _descriptionOptions, ref CVI_DataMatrixSizeOptions _sizeOptions, ref CVI_DataMatrixSearchOptions _searchOptions, IntPtr _advancedOptions, Int32 Count, ref float meanLightRef);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGradeDataMatrixBarcodeAIM(IntPtr _image, out CVI_AIMGradeReport _report);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGradeDataMatrixBarcodeAIMDPM(IntPtr _image, ref CVI_CalibReflectanceStruct _calibReflectance, out CVI_AIMDPMGradeReport _report);

        
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGradeDataMatrixBarcodeISO15415(IntPtr _image, out CVI_GradeReportISO15415 _report);

        
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGradeDataMatrixBarcodeISO16022(IntPtr _image, out CVI_GradeReportISO16022 _report);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqConcentricRake2(IntPtr _image, IntPtr _roi, ConcentricRakeDirection _direction, EdgeProcess _process, Int32 _stepSize, ref CVI_EdgeOptions2 _edgeOptions);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMultithreshold(IntPtr _destination, IntPtr _source, CVI_ThresholdData[] _ranges, int _numRanges);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqAutoThreshold2(IntPtr _destination, IntPtr _source, Int32 _numClasses, ThresholdMethod _method, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLocalThreshold(IntPtr _destination, IntPtr _source, UInt32 _windowWidth, UInt32 _windowHeight, LocalThresholdMethod _method, double _deviationWeight, ParticleType _type, float _replaceValue);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMagicWand(IntPtr _destination, IntPtr _source, CVI_Point _coord, float _tolerance, Connectivity _connectivity8, float _replaceValue);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGrayMorphology(IntPtr _destination, IntPtr _source, MorphologyMethod _method, ref CVI_StructuringElement _structuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGrayMorphology(IntPtr _destination, IntPtr _source, MorphologyMethod _method, IntPtr _zeroStructuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqConvexHull(IntPtr _destination, IntPtr _source, Connectivity connectivity);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGrayMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, [In] CVI_PointFloat[] _points, Int32 _numPoints, MorphologyReconstructOperation _method, IntPtr _zeroStructuringElement, IntPtr _roi);

                
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGrayMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, IntPtr _points, Int32 _numPoints, MorphologyReconstructOperation _method, IntPtr _zeroStructuringElement, IntPtr _roi);

                
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGrayMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, [In] CVI_PointFloat[] _points, Int32 _numPoints, MorphologyReconstructOperation _method, ref CVI_StructuringElement _structuringElement, IntPtr _roi);

                
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqGrayMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, IntPtr _points, Int32 _numPoints, MorphologyReconstructOperation _method, ref CVI_StructuringElement _structuringElement, IntPtr _roi);

        
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, [In] CVI_PointFloat[] _points, Int32 _numPoints, MorphologyReconstructOperation _method, Connectivity _connectivity, IntPtr _roi);

        
        [DllImport("nivision.dll")]
        internal static extern Int32 imaqMorphologyReconstruct(IntPtr _destination, IntPtr _source, IntPtr _marker, IntPtr _points, Int32 _numPoints, MorphologyReconstructOperation _method, Connectivity _connectivity, IntPtr _roi);        

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDanielssonDistance(IntPtr _destination, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFindCircles(IntPtr _destination, IntPtr _source, float _minRadius, float _maxRadius, out Int32 _numCircles);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLabel2(IntPtr _destination, IntPtr _source, Connectivity _connectivity, out Int32 _particleCount);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMorphology(IntPtr _destination, IntPtr _source, MorphologyMethod _method, ref CVI_StructuringElement _structuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMorphology(IntPtr _destination, IntPtr _source, MorphologyMethod _method, IntPtr _zeroStructuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSegmentation(IntPtr _destination, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSeparation(IntPtr _destination, IntPtr _source, Int32 _erosions, ref CVI_StructuringElement _structuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSeparation(IntPtr _destination, IntPtr _source, Int32 _erosions, IntPtr _zeroStructuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSimpleDistance(IntPtr _destination, IntPtr _source, ref CVI_StructuringElement _structuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSimpleDistance(IntPtr _destination, IntPtr _source, IntPtr _zeroStructuringElement);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSkeleton(IntPtr _destination, IntPtr _source, SkeletonMethod _method);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCentroid(IntPtr _image, out CVI_PointFloat _centroid, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqExtractCurves(IntPtr _image, IntPtr _roi, ref CVI_CurveOptions _curveOptions, out UInt32 _numCurves);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqLinearAverages2(IntPtr _image, LinearAveragesModes _mode, CVI_Rectangle _rect);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqQuantify(IntPtr _image, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMaskToROI(IntPtr _mask, out Int32 _withinLimit);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqROIProfile(IntPtr _image, IntPtr _roi);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqTransformROI2(IntPtr _roi, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetROIBoundingBox(IntPtr _roi, out CVI_Rectangle _boundingBox);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFlip(IntPtr _destination, IntPtr _source, SymmetryOperation _axis);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMask(IntPtr _destination, IntPtr _source, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqRotate2(IntPtr _destination, IntPtr _source, float _angle, CVI_PixValue _fill, InterpolationMethod _method, Int32 _maintainSize);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqShift(IntPtr _destination, IntPtr _source, Int32 _shiftX, Int32 _shiftY, CVI_PixValue _fill);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqTranspose(IntPtr _destination, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqUnwrapImage(IntPtr _destination, IntPtr _source, CVI_Annulus _annulus, RectangleOrientation _orientation, InterpolationMethod _method);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqView3D(IntPtr _destination, IntPtr _source, ref CVI_View3DOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetBitDepth(IntPtr _image, out UInt32 _bitDepth);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSetBitDepth(IntPtr _image, UInt32 _bitDepth);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqIsImageEmpty(IntPtr _image, out Int32 _isEmpty);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMulticoreOptions(CVI_MulticoreOperation _operation, ref UInt32 _customNumCores);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCopyCalibrationInfo2(IntPtr _destination, IntPtr _source, CVI_Point _offset);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqBCGTransform(IntPtr _destination, IntPtr _source, ref CVI_BCGOptions _options, IntPtr _mask);

		[DllImport("nivision.dll", EntryPoint="#67")]
		internal static extern Int32 Priv_Equalize(IntPtr _destination, IntPtr _source, ref Priv_HistographReport _report, float _min, float _max, IntPtr _mask);

		[DllImport("nivision.dll", EntryPoint="#67")]
		internal static extern Int32 Priv_Equalize(IntPtr _destination, IntPtr _source, IntPtr _zeroReport, float _min, float _max, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqInverse(IntPtr _destination, IntPtr _source, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLookup(IntPtr _destination, IntPtr _source, [In] Int16[] table, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMathTransform(IntPtr _destination, IntPtr _source, MathLookupOperator _method, float _min, float _max, float _power, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqWatershedTransform(IntPtr _destination, IntPtr _source, Connectivity _connectivity8, out Int32 _zoneCount);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqBuildCoordinateSystem([In] CVI_Point[] _points, CVI_ReferenceMode _mode, AxisOrientation _orientation, out CVI_CoordinateSystem _system);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFitCircle2([In] CVI_PointFloat[] _points, Int32 _numPoints, ref CVI_FitCircleOptions _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFitEllipse2([In] CVI_PointFloat[] _points, Int32 _numPoints, ref CVI_FitEllipseOptions _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFitLine([In] CVI_PointFloat[] _points, Int32 _numPoints, ref CVI_FitLineOptions _options);

		[DllImport("nivision.dll", EntryPoint = "#220")]
		internal static extern Int32 Priv_GetAngles2(ref Array1D _coordinates, ref Array1D _anglesInDegrees, IntPtr _zeroAnglesInRadians, ref CVI_PointFloat _vertex);

		[DllImport("nivision.dll", EntryPoint = "#220")]
		internal static extern Int32 Priv_GetAngles2(ref Array1D _coordinates, ref Array1D _anglesInDegrees, IntPtr _zeroAnglesInRadians, IntPtr _zeroVertex);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetBisectingLine(CVI_PointFloat _start1, CVI_PointFloat _end1, CVI_PointFloat _start2, CVI_PointFloat _end2, out CVI_PointFloat _bisectStart, out CVI_PointFloat _bisectEnd);

		[DllImport("nivision.dll", EntryPoint = "#211")]
		internal static extern Int32 Priv_FindPointDistances(ref Array1D _points, ref Array1D _distances);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetIntersection(CVI_PointFloat _start1, CVI_PointFloat _end1, CVI_PointFloat _start2, CVI_PointFloat _end2, out CVI_PointFloat _intersection);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetMidLine(CVI_PointFloat _refLineStart, CVI_PointFloat _refLineEnd, CVI_PointFloat _point, out CVI_PointFloat _midLineStart, out CVI_PointFloat _midLineEnd);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetPerpendicularLine(CVI_PointFloat _refLineStart, CVI_PointFloat _refLineEnd, CVI_PointFloat _point, out CVI_PointFloat _perpLineStart, out CVI_PointFloat _perpLineEnd, IntPtr _zeroDistance);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetPointsOnContour(IntPtr _image, out Int32 _numSegments);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetPointsOnLine(CVI_Point _start, CVI_Point _end, out Int32 _numPoints);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqGetPolygonArea([In] CVI_PointFloat[] _points, Int32 _numPoints, out float _area);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqInterpolatePoints(IntPtr _image, [In] CVI_Point[] _points, Int32 _numPoints, InterpolationMethod _method, SubPixelAccuracy _subpixelAccuracy, out Int32 _interpCount);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqExtractComplexPlane(IntPtr _destination, IntPtr _source, ComplexPlane _plane);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqReplaceComplexPlane(IntPtr _destination, IntPtr _source, IntPtr _newValues, ComplexPlane _plane);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAdd(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAddConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAverage(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAverageConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDivide2(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB, CVI_RoundingMode _mode);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDivideConstant2(IntPtr _destination, IntPtr _source, CVI_PixValue _value, CVI_RoundingMode _mode);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMax(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMaxConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMin(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMinConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqModulo(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqModuloConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMultiply(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMultiplyConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMulDiv(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB, float _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSubtract(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqSubtractConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAnd(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAndConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCompare(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB, ComparisonFunction _compare);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCompareConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value, ComparisonFunction _compare);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLogicalDifference(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLogicalDifferenceConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqNand(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqNandConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqNor(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqNorConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqOr(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqOrConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqXnor(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqXnorConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqXor(IntPtr _destination, IntPtr _sourceA, IntPtr _sourceB);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqXorConstant(IntPtr _destination, IntPtr _source, CVI_PixValue _value);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqDetectExtremes([In] double[] _pixels, Int32 _numPixels, PeakOrValley _mode, ref CVI_DetectExtremesOptions _options, out Int32 _numExtremes);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDetectRotation(IntPtr _referenceImage, IntPtr _testImage, CVI_PointFloat _referenceCenter, CVI_PointFloat _testCenter, Int32 _radius, float _precision, out double _angle);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqEdgeTool4(IntPtr _image, IntPtr _roi, EdgeProcess _processType, ref CVI_EdgeOptions2 _edgeOptions, UInt32 _reverseDirection);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFindEdge2(IntPtr _image, IntPtr _roi, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem, ref CVI_FindEdgeOptions2 _findEdgeOptions, ref CVI_StraightEdgeOptions _straightEdgeOptions);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFindCircularEdge2(IntPtr _image, IntPtr _roi, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem, ref CVI_FindCircularEdgeOptions _findEdgeOptions, ref CVI_CircularEdgeFitOptions _circularEdgeOptions);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqFindConcentricEdge2(IntPtr _image, IntPtr _roi, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem, ref CVI_FindConcentricEdgeOptions _findEdgeOptions, ref CVI_ConcentricEdgeFitOptions _concentricEdgeOptions);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFindTransformRect2(IntPtr _image, IntPtr _roi, FindTransformMode _mode, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem, ref CVI_FindTransformRectOptions2 _findTransformOptions, ref CVI_StraightEdgeOptions _straightEdgeOptions, out CVI_AxisReport _axisReport);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFindTransformRects2(IntPtr _image, IntPtr _primaryRoi, IntPtr _secondaryRoi, FindTransformMode _mode, ref CVI_CoordinateSystem _baseSystem, ref CVI_CoordinateSystem _newSystem, ref CVI_FindTransformRectsOptions2 _findTransformOptions, ref CVI_StraightEdgeOptions _primaryStraightEdgeOptions, ref CVI_StraightEdgeOptions _secondaryStraightEdgeOptions, out CVI_AxisReport _axisReport);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqRake2(IntPtr _image, IntPtr _roi, RakeDirection _direction, EdgeProcess _process, Int32 _stepSize, ref CVI_EdgeOptions2 _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqSimpleEdge(IntPtr _image, [In] CVI_Point[] _points, Int32 _numPoints, ref CVI_SimpleEdgeOptions _options, out Int32 _numEdges);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqStraightEdge(IntPtr _image, IntPtr _roi, SearchDirection _searchDirection, ref CVI_EdgeOptions2 _edgeOptions, ref CVI_StraightEdgeOptions _straightEdgeOptions);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqStraightEdge2(IntPtr _image, IntPtr _roi, SearchDirection _searchDirection, ref CVI_EdgeOptions2 _edgeOptions, ref CVI_StraightEdgeOptions _straightEdgeOptions, Int32 _optimizedMode);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqSpoke2(IntPtr _image, IntPtr _roi, SpokeDirection _direction, EdgeProcess _process, Int32 _stepSize, ref CVI_EdgeOptions2 _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqAttenuate(IntPtr _dest, IntPtr _source, AttenuateMode _highlow);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqConjugate(IntPtr _dest, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFFT(IntPtr _dest, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFlipFrequencies(IntPtr _dest, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqInverseFFT(IntPtr _dest, IntPtr _source);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqTruncate(IntPtr _dest, IntPtr _source, TruncateMode _highlow, float _ratioToKeep);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqLearnColor(IntPtr _image, IntPtr _roi, ColorSensitivity _sensitivity, Int32 _saturation);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchColor(IntPtr _image, ref CVI_ColorInformation _info, IntPtr _roi, out Int32 _numScores);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqColorBCGTransform(IntPtr _dest, IntPtr _source, ref CVI_BCGOptions _redOptions, ref CVI_BCGOptions _greenOptions, ref CVI_BCGOptions _blueOptions, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqColorEqualize(IntPtr _dest, IntPtr _source, Int32 _colorEqualization);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqColorLookup(IntPtr _destination, IntPtr _source, ColorMode _mode, IntPtr _mask, [In] Int16[] _plane1, [In] Int16[] _plane2, [In] Int16[] _plane3);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqColorThreshold(IntPtr _destination, IntPtr _source, Int32 _replaceValue, ColorMode _mode, ref CVI_Range _plane1Range, ref CVI_Range _plane2Range, ref CVI_Range _plane3Range);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqDrawTextOnImage(IntPtr _dest, IntPtr _source, CVI_Point _coord, [MarshalAs(UnmanagedType.LPStr)] string _text, ref CVI_DrawTextOptions _options, out Int32 _fontNameUsed);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCannyEdgeFilter(IntPtr _dest, IntPtr _source, ref CVI_CannyOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCorrelate(IntPtr _dest, IntPtr _source, IntPtr _templateImage, CVI_Rectangle _rect);

		[DllImport("nivision.dll", EntryPoint="#75")]
		internal static extern Int32 Priv_EdgeFilter(IntPtr _dest, IntPtr _source, OutlineMethod _method, float _threshold, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLowPass(IntPtr _dest, IntPtr _source, Int32 _width, Int32 _height, float _tolerance, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqMedianFilter(IntPtr _dest, IntPtr _source, Int32 _width, Int32 _height, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqNthOrderFilter(IntPtr _dest, IntPtr _source, Int32 _width, Int32 _height, Int32 _n, IntPtr _mask);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFillBorder(IntPtr _image, BorderMethod _method);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchShape(IntPtr _dest, IntPtr _source, IntPtr _templateImage, Int32 _scaleInvariant, Connectivity _connectivity8, double _tolerance, out Int32 _numMatches);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqFindLCDSegments(IntPtr _roi, IntPtr _image, ref CVI_LCDOptions _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqReadLCD(IntPtr _image, IntPtr _roi, ref CVI_LCDOptions _options);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqInterlaceCombine(IntPtr _frame, IntPtr _odd, IntPtr _even);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqInterlaceSeparate(IntPtr _frame, IntPtr _odd, IntPtr _even);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqImageToClipboard(IntPtr _image, [In] Rgb32Value[] colorTable);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqClipboardToImage(IntPtr _image, [Out] Rgb32Value[] colorTable);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqGetMeterArc(Int32 _lightNeedle, CVI_MeterArcMode _mode, IntPtr _roi, CVI_PointFloat _basePoint, CVI_PointFloat _start, CVI_PointFloat _end);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqReadMeter(IntPtr _image, IntPtr _arcInfo, out double _percentage, out CVI_PointFloat _endOfNeedle);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqLearnColorPattern(IntPtr _image, ref CVI_LearnColorPatternOptions _options);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMatchColorPattern(IntPtr _image, IntPtr _pattern, ref CVI_MatchColorPatternOptions options, CVI_Rectangle searchRect, out Int32 numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqDetectCircles(IntPtr _image, ref CVI_CircleDescriptor _circleDescriptor, ref CVI_CurveOptions _curveOptions, ref CVI_ShapeDetectionOptions _shapeDetectionOptions, IntPtr _roi, out Int32 _numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqDetectEllipses(IntPtr _image, ref CVI_EllipseDescriptor _ellipseDescriptor, ref CVI_CurveOptions _curveOptions, ref CVI_ShapeDetectionOptions _shapeDetectionOptions, IntPtr _roi, out Int32 _numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqDetectLines(IntPtr _image, ref CVI_LineDescriptor _lineDescriptor, ref CVI_CurveOptions _curveOptions, ref CVI_ShapeDetectionOptions _shapeDetectionOptions, IntPtr _roi, out Int32 _numMatches);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqDetectRectangles(IntPtr _image, ref CVI_RectangleDescriptor _rectangleDescriptor, ref CVI_CurveOptions _curveOptions, ref CVI_ShapeDetectionOptions _shapeDetectionOptions, IntPtr _roi, out Int32 _numMatches);

		[DllImport("nivision.dll")]
		internal static extern Int32 imaqCountParticles(IntPtr _image, Connectivity _connectivity8, out Int32 _numParticles);

		[DllImport("nivision.dll")]
		internal static extern IntPtr imaqMeasureParticles(IntPtr _image, ParticleMeasurementsCalibrationMode _calibrationMode, [In] MeasurementType[] _measurements, IntPtr _numMeasurements);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourFitLine(IntPtr _image, double _pixelRadius);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourFitCircle(IntPtr _image, double _pixelRadius, UInt32 _rejectOutliers);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourFitEllipse(IntPtr _image, double _pixelRadius, UInt32 _rejectOutliers);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourFitSpline(IntPtr _image, UInt32 _degree, UInt32 _nControlPoints);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourFitPolynomial(IntPtr _image, UInt32 _order);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqExtractContour(IntPtr _image, IntPtr _roi, ExtractContourDirection _direction, ref CVI_CurveParameters _curveParams, IntPtr _connectionConstraints, Int32 _numOfConstraints, ExtractContourSelection _selection, IntPtr _contourImage);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourInfo(IntPtr _image);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourOverlay(IntPtr _image, IntPtr _contourImage, ref CVI_ContourOverlaySettings _pointsSettings, ref CVI_ContourOverlaySettings _equationSettings, [MarshalAs(UnmanagedType.LPStr)] string _groupName);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourComputeCurvature(IntPtr _image, UInt32 kernel);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourClassifyCurvature(IntPtr _image, UInt32 kernel, IntPtr _curvatureClasses, Int32 _numCurvatureClasses);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourComputeDistances(IntPtr _tartgetImage, IntPtr _templateImage, ref CVI_SetupMatchPatternData _matchSetupData, UInt32 _smoothingKernel);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourClassifyDistances(IntPtr _tartgetImage, IntPtr _templateImage, ref CVI_SetupMatchPatternData _matchSetupData, UInt32 _smoothingKernel, IntPtr _distanceClasses, Int32 _numDistanceClasses);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqContourSetupMatchPattern(ref CVI_ContourMatchMode _matchMode, Int32 _enableAccuracy, ref CVI_CurveParameters _curveParams, Int32 _useLearnCurveParameters, IntPtr _rangeSettings, Int32 _numRangeSettings);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqContourAdvancedSetupMatchPattern(ref CVI_SetupMatchPatternData _setupMatchData, IntPtr _setupDataOptions, Int32 _numSetupDataOptions);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqClampMax2(IntPtr image, IntPtr roi, ref CVI_CoordinateSystem baseSystem, ref CVI_CoordinateSystem newSystem, ref CVI_CurveOptions curveParameters, ref CVI_ClampSettings clampSettings, ref CVI_ClampOverlaySettings clampOverlaySettings);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqClampMax3(IntPtr image, IntPtr roi, ref CVI_CoordinateSystem baseSystem, ref CVI_CoordinateSystem newSystem, ref CVI_CurveOptions curveParameters, ref CVI_ClampSettings clampSettings, ref CVI_ClampOverlaySettings clampOverlaySettings);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqCalibrationTargetToPoints(IntPtr _image, IntPtr _roi, ref CVI_GridDescriptor _gridDescriptor, ref CVI_MaxGridSize _maxGridSize);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqSetSimpleCalibration2(IntPtr _image, ref CVI_GridDescriptor _gridDescriptor);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCalibrationSetAxisInfo(IntPtr _image, ref CVI_CoordinateSystem _axisInfo);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCalibrationSetAxisInfoByReferencePoints(IntPtr _image, CVI_PointDouble[] _pixelCoordinates, Int32 _numPixelCoordinates, CVI_PointDouble[] _realCoordinates, Int32 _numRealCoordinates);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCalibrationGetThumbnailImage(IntPtr _templateImage, IntPtr _image, CalibrationThumbnailType _type, UInt32 _index);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqCalibrationGetCalibrationInfo(IntPtr _image, UInt32 isGetErrorMap);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqCalibrationGetCameraParameters(IntPtr _image);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCalibrationCompactInformation(IntPtr _image);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqLearnPerspectiveCalibration(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqLearnMicroPlaneCalibration(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqLearnCameraModel(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts, ref CVI_CalibrationModelSetup _setup, Int32 _isAddPointsLearn);

        [DllImport("nivision.dll")]
        internal static extern IntPtr imaqLearnCameraModel2(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts, ref CVI_CalibrationModelSetup _setup, Int32 _isAddPointsLearn);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqLearnDistortionModel(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts, ref CVI_CalibrationModelSetup _setup, Int32 _isAddPointsLearn);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqLearnDistortionModel2(IntPtr _templateImage, IntPtr _image, ref CVI_CalibrationReferencePoints _referencePts, ref CVI_CalibrationModelSetup _setup, Int32 _isAddPointsLearn);

        [DllImport("nivision.dll")]
        internal static extern Int32 imaqCalibrationCorrectionLearnSetup(IntPtr _templateImage, ref CVI_CalibrationLearnSetupInfo _setupInfo, IntPtr _roi);
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
