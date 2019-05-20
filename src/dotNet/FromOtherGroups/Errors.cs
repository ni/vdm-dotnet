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
namespace NationalInstruments.Vision
{
    //==============================================================================================
    /// <summary>The array sizes are not compatible.</summary>
    /// <summary>
    /// Represents an error code returned by NI Vision.
    /// </summary>

    public enum ErrorCode
    {
        //==========================================================================================
        /// <summary>No error.</summary>

        Success                                                       =    0,
        //==========================================================================================
        /// <summary>System error.</summary>

        SystemError                                                   =    -1074396160,
        //==========================================================================================
        /// <summary>Not enough memory for requested operation.</summary>

        OutOfMemory                                                   =    -1074396159,
        //==========================================================================================
        /// <summary>Memory error.</summary>

        MemoryError                                                   =    -1074396158,
        //==========================================================================================
        /// <summary>Unlicensed copy of NI Vision.</summary>

        Unregistered                                                  =    -1074396157,
        //==========================================================================================
        /// <summary>The function requires an NI Vision 5.0 Advanced license.</summary>

        NeedFullVersion                                               =    -1074396156,
        //==========================================================================================
        /// <summary>NI Vision did not initialize properly.</summary>

        Uninit                                                        =    -1074396155,
        //==========================================================================================
        /// <summary>The image is not large enough for the operation.</summary>

        ImageTooSmall                                                 =    -1074396154,
        //==========================================================================================
        /// <summary>The decoded barcode information did not pass the checksum test.</summary>

        BarcodeCodabar                                                =    -1074396153,
        //==========================================================================================
        /// <summary>The barcode is not a valid Code 3 of 9 barcode.</summary>

        BarcodeCode39                                                 =    -1074396152,
        //==========================================================================================
        /// <summary>The barcode is not a valid Code93 barcode.</summary>

        BarcodeCode93                                                 =    -1074396151,
        //==========================================================================================
        /// <summary>The barcode is not a valid Code128 barcode.</summary>

        BarcodeCode128                                                =    -1074396150,
        //==========================================================================================
        /// <summary>The barcode is not a valid EAN8 barcode.</summary>

        BarcodeEan8                                                   =    -1074396149,
        //==========================================================================================
        /// <summary>The barcode is not a valid EAN13 barcode.</summary>

        BarcodeEan13                                                  =    -1074396148,
        //==========================================================================================
        /// <summary>The barcode is not a valid Interleaved 2 of 5 barcode.</summary>

        BarcodeI25                                                    =    -1074396147,
        //==========================================================================================
        /// <summary>The barcode is not a valid MSI barcode.</summary>

        BarcodeMsi                                                    =    -1074396146,
        //==========================================================================================
        /// <summary>The barcode is not a valid UPCA barcode.</summary>

        BarcodeUpca                                                   =    -1074396145,
        //==========================================================================================
        /// <summary>The Code93 barcode contains invalid shift encoding.</summary>

        BarcodeCode93Shift                                            =    -1074396144,
        //==========================================================================================
        /// <summary>The barcode type is invalid.</summary>

        BarcodeType                                                   =    -1074396143,
        //==========================================================================================
        /// <summary>The image does not represent a valid linear barcode.</summary>

        BarcodeInvalid                                                =    -1074396142,
        //==========================================================================================
        /// <summary>The FNC value in the Code128 barcode is not located before the first data value.</summary>

        BarcodeCode128Fnc                                             =    -1074396141,
        //==========================================================================================
        /// <summary>The starting code set in the Code128 barcode is not valid.</summary>

        BarcodeCode128Set                                             =    -1074396140,
        //==========================================================================================
        /// <summary>Not enough reserved memory in the timed environment for the requested operation.</summary>

        RollbackResourceOutOfMemory                                   =    -1074396139,
        //==========================================================================================
        /// <summary>The function is not supported when a time limit is active.</summary>

        RollbackNotSupported                                          =    -1074396138,
        //==========================================================================================
        /// <summary>Quartz.dll not found. Install DirectX 8.1 or later.</summary>

        DirectxDllNotFound                                            =    -1074396137,
        //==========================================================================================
        /// <summary>The filter quality you provided is invalid. Valid quality values range from -1 to 1000.</summary>

        DirectxInvalidFilterQuality                                   =    -1074396136,
        //==========================================================================================
        /// <summary>Invalid button label.</summary>

        InvalidButtonLabel                                            =    -1074396135,
        //==========================================================================================
        /// <summary>Could not execute the function in the separate thread because the thread has not completed initialization.</summary>

        ThreadInitializing                                            =    -1074396134,
        //==========================================================================================
        /// <summary>Could not execute the function in the separate thread because the thread could not initialize.</summary>

        ThreadCouldNotInitialize                                      =    -1074396133,
        //==========================================================================================
        /// <summary>The mask must be the same size as the template.</summary>

        MaskNotTemplateSize                                           =    -1074396132,
        //==========================================================================================
        /// <summary>The ROI must only have either a single Rectangle contour or a single Rotated Rectangle contour.</summary>

        NotRectOrRotatedRect                                          =    -1074396130,
        //==========================================================================================
        /// <summary>During timed execution, you must use the preallocated version of this operation.</summary>

        RollbackUnboundedInterface                                    =    -1074396129,
        //==========================================================================================
        /// <summary>An image being modified by one process cannot be requested by another process while a time limit is active.</summary>

        RollbackResourceConflict3                                     =    -1074396128,
        //==========================================================================================
        /// <summary>An image with pattern matching, calibration, or overlay information cannot be manipulated while a time limit is active.</summary>

        RollbackResourceConflict2                                     =    -1074396127,
        //==========================================================================================
        /// <summary>An image created before a time limit is started cannot be resized while a time limit is active.</summary>

        RollbackResourceConflict1                                     =    -1074396126,
        //==========================================================================================
        /// <summary>Invalid contrast threshold. The threshold value must be greater than 0.</summary>

        InvalidContrastThreshold                                      =    -1074396125,
        //==========================================================================================
        /// <summary>NI Vision does not support the calibration ROI mode you supplied.</summary>

        InvalidCalibrationRoiMode                                     =    -1074396124,
        //==========================================================================================
        /// <summary>NI Vision does not support the calibration mode you supplied.</summary>

        InvalidCalibrationMode                                        =    -1074396123,
        //==========================================================================================
        /// <summary>Set the foreground and background text colors to grayscale to draw on a U8 image.</summary>

        DrawtextColorMustBeGrayscale                                  =    -1074396122,
        //==========================================================================================
        /// <summary>The value of the saturation threshold must be from 0 to 255.</summary>

        SaturationThresholdOutOfRange                                 =    -1074396121,
        //==========================================================================================
        /// <summary>Not an image.</summary>

        NotImage                                                      =    -1074396120,
        //==========================================================================================
        /// <summary>They custom data key you supplied is invalid. The only valid character values are decimal 32-126 and 161-255. There must also be no repeated, leading, or trailing spaces.</summary>

        CustomdataInvalidKey                                          =    -1074396119,
        //==========================================================================================
        /// <summary>Step size must be greater than zero.</summary>

        InvalidStepSize                                               =    -1074396118,
        //==========================================================================================
        /// <summary>Invalid matrix size in the structuring element.</summary>

        MatrixSize                                                    =    -1074396117,
        //==========================================================================================
        /// <summary>Insufficient number of calibration feature points.</summary>

        CalibrationInsfPoints                                         =    -1074396116,
        //==========================================================================================
        /// <summary>The operation is invalid in a corrected image.</summary>

        CalibrationImageCorrected                                     =    -1074396115,
        //==========================================================================================
        /// <summary>The ROI contains an invalid contour type or is not contained in the ROI learned for calibration.</summary>

        CalibrationInvalidRoi                                         =    -1074396114,
        //==========================================================================================
        /// <summary>The source/input image has not been calibrated.</summary>

        CalibrationImageUncalibrated                                  =    -1074396113,
        //==========================================================================================
        /// <summary>The number of pixel and real-world coordinates must be equal.</summary>

        IncompMatrixSize                                              =    -1074396112,
        //==========================================================================================
        /// <summary>Unable to automatically detect grid because the image is too distorted.</summary>

        CalibrationFailedToFindGrid                                   =    -1074396111,
        //==========================================================================================
        /// <summary>Invalid calibration information version.</summary>

        CalibrationInfoVersion                                        =    -1074396110,
        //==========================================================================================
        /// <summary>Invalid calibration scaling factor.</summary>

        CalibrationInvalidScalingFactor                               =    -1074396109,
        //==========================================================================================
        /// <summary>The calibration error map cannot be computed.</summary>

        CalibrationErrormap                                           =    -1074396108,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo1                                              =    -1074396107,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo2                                              =    -1074396106,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo3                                              =    -1074396105,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo4                                              =    -1074396104,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo5                                              =    -1074396103,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfo6                                              =    -1074396102,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfoMicroPlane                                     =    -1074396101,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfoPerspectiveProjection                          =    -1074396100,
        //==========================================================================================
        /// <summary>Invalid calibration template image.</summary>

        CalibrationInfoSimpleTransform                                =    -1074396099,
        //==========================================================================================
        /// <summary>You must pass NULL for the reserved parameter.</summary>

        ReservedMustBeNull                                            =    -1074396098,
        //==========================================================================================
        /// <summary>You entered an invalid selection in the particle parameter.</summary>

        InvalidParticleParameterValue                                 =    -1074396097,
        //==========================================================================================
        /// <summary>Not an object.</summary>

        NotAnObject                                                   =    -1074396096,
        //==========================================================================================
        /// <summary>The reference points passed are inconsistent. At least two similar pixel coordinates correspond to different real-world coordinates.</summary>

        CalibrationDuplicateReferencePoint                            =    -1074396095,
        //==========================================================================================
        /// <summary>A resource conflict occurred in the timed environment. Two processes cannot manage the same resource and be time bounded.</summary>

        RollbackResourceCannotUnlock                                  =    -1074396094,
        //==========================================================================================
        /// <summary>A resource conflict occurred in the timed environment. Two processes cannot access the same resource and be time bounded.</summary>

        RollbackResourceLocked                                        =    -1074396093,
        //==========================================================================================
        /// <summary>Multiple timed environments are not supported.</summary>

        RollbackResourceNonEmptyInitialize                            =    -1074396092,
        //==========================================================================================
        /// <summary>A time limit cannot be started until the timed environment is initialized.</summary>

        RollbackResourceUninitializedEnable                           =    -1074396091,
        //==========================================================================================
        /// <summary>Multiple timed environments are not supported.</summary>

        RollbackResourceEnabled                                       =    -1074396090,
        //==========================================================================================
        /// <summary>The timed environment is already initialized.</summary>

        RollbackResourceReinitialize                                  =    -1074396089,
        //==========================================================================================
        /// <summary>The results of the operation exceeded the size limits on the output data arrays.</summary>

        RollbackResize                                                =    -1074396088,
        //==========================================================================================
        /// <summary>No time limit is available to stop.</summary>

        RollbackStopTimer                                             =    -1074396087,
        //==========================================================================================
        /// <summary>A time limit could not be set.</summary>

        RollbackStartTimer                                            =    -1074396086,
        //==========================================================================================
        /// <summary>The timed environment could not be initialized.</summary>

        RollbackInitTimer                                             =    -1074396085,
        //==========================================================================================
        /// <summary>No initialized timed environment is available to close.</summary>

        RollbackDeleteTimer                                           =    -1074396084,
        //==========================================================================================
        /// <summary>The time limit has expired.</summary>

        RollbackTimeout                                               =    -1074396083,
        //==========================================================================================
        /// <summary>Only 8-bit images support the use of palettes. Either do not use a palette, or convert your image to an 8-bit image before using a palette.</summary>

        PaletteNotSupported                                           =    -1074396082,
        //==========================================================================================
        /// <summary>Incorrect password.</summary>

        BadPassword                                                   =    -1074396081,
        //==========================================================================================
        /// <summary>Invalid image type.</summary>

        InvalidImageType                                              =    -1074396080,
        //==========================================================================================
        /// <summary>Invalid metafile handle.</summary>

        InvalidMetafileHandle                                         =    -1074396079,
        //==========================================================================================
        /// <summary>Incompatible image type.</summary>

        IncompType                                                    =    -1074396077,
        //==========================================================================================
        /// <summary>Unable to fit a line for the primary axis.</summary>

        CoordSysFirstAxis                                             =    -1074396076,
        //==========================================================================================
        /// <summary>Unable to fit a line for the secondary axis.</summary>

        CoordSysSecondAxis                                            =    -1074396075,
        //==========================================================================================
        /// <summary>Incompatible image size.</summary>

        IncompSize                                                    =    -1074396074,
        //==========================================================================================
        /// <summary>When the mask's offset was applied, the mask was entirely outside of the image.</summary>

        MaskOutsideImage                                              =    -1074396073,
        //==========================================================================================
        /// <summary>Invalid image border.</summary>

        InvalidBorder                                                 =    -1074396072,
        //==========================================================================================
        /// <summary>Invalid scan direction.</summary>

        InvalidScanDirection                                          =    -1074396071,
        //==========================================================================================
        /// <summary>Unsupported function.</summary>

        InvalidFunction                                               =    -1074396070,
        //==========================================================================================
        /// <summary>NI Vision does not support the color mode you specified.</summary>

        InvalidColorMode                                              =    -1074396069,
        //==========================================================================================
        /// <summary>The function does not support the requested action.</summary>

        InvalidAction                                                 =    -1074396068,
        //==========================================================================================
        /// <summary>The source image and destination image must be different.</summary>

        ImagesNotDiff                                                 =    -1074396067,
        //==========================================================================================
        /// <summary>Invalid point symbol.</summary>

        InvalidPointsymbol                                            =    -1074396066,
        //==========================================================================================
        /// <summary>Cannot resize an image in an acquisition buffer.</summary>

        CantResizeExternal                                            =    -1074396065,
        //==========================================================================================
        /// <summary>This operation is not supported for images in an acquisition buffer.</summary>

        ExternalNotSupported                                          =    -1074396064,
        //==========================================================================================
        /// <summary>The external buffer must be aligned on a 4-byte boundary. The line width and border pixels must be 4-byte aligned, as well.</summary>

        ExternalAlignment                                             =    -1074396063,
        //==========================================================================================
        /// <summary>The tolerance parameter must be greater than or equal to 0.</summary>

        InvalidTolerance                                              =    -1074396062,
        //==========================================================================================
        /// <summary>The size of each dimension of the window must be greater than 2 and less than or equal to the size of the image in the corresponding dimension.</summary>

        InvalidWindowSize                                             =    -1074396061,
        //==========================================================================================
        /// <summary>Lossless compression cannot be used with the floating point wavelet transform mode. Either set the wavelet transform mode to integer, or use lossy compression.</summary>

        Jpeg2000LosslessWithFloatingPoint                             =    -1074396060,
        //==========================================================================================
        /// <summary>Invalid maximum number of iterations. Maximum number of iterations must be greater than zero.</summary>

        InvalidMaxIterations                                          =    -1074396059,
        //==========================================================================================
        /// <summary>Invalid rotation mode.</summary>

        InvalidRotationMode                                           =    -1074396058,
        //==========================================================================================
        /// <summary>Invalid search vector width. The width must be an odd number greater than zero.</summary>

        InvalidSearchVectorWidth                                      =    -1074396057,
        //==========================================================================================
        /// <summary>Invalid matrix mirror mode.</summary>

        InvalidMatrixMirrorMode                                       =    -1074396056,
        //==========================================================================================
        /// <summary>Invalid aspect ratio. Valid aspect ratios must be greater than or equal to zero.</summary>

        InvalidAspectRatio                                            =    -1074396055,
        //==========================================================================================
        /// <summary>Invalid cell fill type.</summary>

        InvalidCellFillType                                           =    -1074396054,
        //==========================================================================================
        /// <summary>Invalid border integrity. Valid values range from 0 to 100.</summary>

        InvalidBorderIntegrity                                        =    -1074396053,
        //==========================================================================================
        /// <summary>Invalid demodulation mode.</summary>

        InvalidDemodulationMode                                       =    -1074396052,
        //==========================================================================================
        /// <summary>Invalid cell filter mode.</summary>

        InvalidCellFilterMode                                         =    -1074396051,
        //==========================================================================================
        /// <summary>Invalid ECC type.</summary>

        InvalidEccType                                                =    -1074396050,
        //==========================================================================================
        /// <summary>Invalid matrix polarity.</summary>

        InvalidMatrixPolarity                                         =    -1074396049,
        //==========================================================================================
        /// <summary>Invalid cell sample size.</summary>

        InvalidCellSampleSize                                         =    -1074396048,
        //==========================================================================================
        /// <summary>Invalid linear average mode.</summary>

        InvalidLinearAverageMode                                      =    -1074396047,
        //==========================================================================================
        /// <summary>When using a region of interest that is not a rectangle, you must specify the contrast mode of the barcode as either black on white or white on black.</summary>

        Invalid2dBarcodeContrastForRoi                                =    -1074396046,
        //==========================================================================================
        /// <summary>Invalid 2-D barcode Data Matrix subtype.</summary>

        Invalid2dBarcodeSubtype                                       =    -1074396045,
        //==========================================================================================
        /// <summary>Invalid 2-D barcode shape.</summary>

        Invalid2dBarcodeShape                                         =    -1074396044,
        //==========================================================================================
        /// <summary>Invalid 2-D barcode cell shape.</summary>

        Invalid2dBarcodeCellShape                                     =    -1074396043,
        //==========================================================================================
        /// <summary>Invalid 2-D barcode contrast.</summary>

        Invalid2dBarcodeContrast                                      =    -1074396042,
        //==========================================================================================
        /// <summary>Invalid 2-D barcode type.</summary>

        Invalid2dBarcodeType                                          =    -1074396041,
        //==========================================================================================
        /// <summary>Cannot access NI-IMAQ driver.</summary>

        Driver                                                        =    -1074396040,
        //==========================================================================================
        /// <summary>I/O error.</summary>

        IoError                                                       =    -1074396039,
        //==========================================================================================
        /// <summary>When searching for a coordinate system, the number of lines to fit must be 1.</summary>

        FindCoordsysMoreThanOneEdge                                   =    -1074396038,
        //==========================================================================================
        /// <summary>Trigger timeout.</summary>

        Timeout                                                       =    -1074396037,
        //==========================================================================================
        /// <summary>The Skeleton mode you specified is invalid.</summary>

        InvalidSkeletonmode                                           =    -1074396036,
        TemplateimageNocircle                                         =    -1074396035,
        TemplateimageEdgeinfo                                         =    -1074396034,
        TemplatedescriptorLearnsetupdata                              =    -1074396033,
        //==========================================================================================
        /// <summary>The template descriptor does not contain data required for the requested search strategy in rotation-invariant matching.</summary>

        TemplatedescriptorRotationSearchstrategy                      =    -1074396032,
        InvalidTetragon                                               =    -1074396031,
        TooManyClassificationSessions                                 =    -1074396030,
        TimeBoundedExecutionNotSupported                              =    -1074396028,
        InvalidColorResolution                                        =    -1074396027,
        //==========================================================================================
        /// <summary>Invalid process type for edge detection.</summary>

        InvalidProcessTypeForEdgeDetection                            =    -1074396026,
        //==========================================================================================
        /// <summary>Angle range value should be equal to or greater than zero.</summary>

        InvalidAngleRangeForStraightEdge                              =    -1074396025,
        //==========================================================================================
        /// <summary>Minimum coverage value should be greater than zero.</summary>

        InvalidMinCoverageForStraightEdge                             =    -1074396024,
        //==========================================================================================
        /// <summary>The angle tolerance should be equal to or greater than 0.001.</summary>

        InvalidAngleTolForStraightEdge                                =    -1074396023,
        //==========================================================================================
        /// <summary>Invalid search mode for detecting straight edges</summary>

        InvalidSearchModeForStraightEdge                              =    -1074396022,
        //==========================================================================================
        /// <summary>Invalid kernel size for edge detection. The minimum kernel size is 3, the maximum kernel size is 1073741823 and the kernel size must be odd.</summary>

        InvalidKernelSizeForEdgeDetection                             =    -1074396021,
        //==========================================================================================
        /// <summary>Invalid grading mode.</summary>

        InvalidGradingMode                                            =    -1074396020,
        //==========================================================================================
        /// <summary>Invalid threshold percentage. Valid values range from 0 to 100.</summary>

        InvalidThresholdPercentage                                    =    -1074396019,
        //==========================================================================================
        /// <summary>Invalid edge polarity search mode.</summary>

        InvalidEdgePolaritySearchMode                                 =    -1074396018,
        //==========================================================================================
        /// <summary>The AIM grading data attached to the image you tried to open was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this file.</summary>

        OpeningNewerAimGradingData                                    =    -1074396017,
        //==========================================================================================
        /// <summary>No video driver is installed.</summary>

        NoVideoDriver                                                 =    -1074396016,
        //==========================================================================================
        /// <summary>Unable to establish network connection with remote system.</summary>

        RpcExecuteIvb                                                 =    -1074396015,
        //==========================================================================================
        /// <summary>RT Video Out does not support displaying the supplied image type at the selected color depth.</summary>

        InvalidVideoBlit                                              =    -1074396014,
        //==========================================================================================
        /// <summary>Invalid video mode.</summary>

        InvalidVideoMode                                              =    -1074396013,
        //==========================================================================================
        /// <summary>Unable to display remote image on network connection.</summary>

        RpcExecute                                                    =    -1074396012,
        //==========================================================================================
        /// <summary>Unable to establish network connection.</summary>

        RpcBind                                                       =    -1074396011,
        //==========================================================================================
        /// <summary>Invalid frame number.</summary>

        InvalidFrameNumber                                            =    -1074396010,
        //==========================================================================================
        /// <summary>An internal DirectX error has occurred. Try upgrading to the latest version of DirectX.</summary>

        Directx                                                       =    -1074396009,
        //==========================================================================================
        /// <summary>An appropriate DirectX filter to process this file could not be found. Install the filter that was used to create this AVI. Upgrading to the latest version of DirectX may correct this error. NI Vision requires DirectX 8.1 or higher.</summary>

        DirectxNoFilter                                               =    -1074396008,
        //==========================================================================================
        /// <summary>Incompatible compression filter.</summary>

        DirectxIncompatibleCompressionFilter                          =    -1074396007,
        //==========================================================================================
        /// <summary>Unknown compression filter.</summary>

        DirectxUnknownCompressionFilter                               =    -1074396006,
        //==========================================================================================
        /// <summary>Invalid AVI session.</summary>

        InvalidAviSession                                             =    -1074396005,
        //==========================================================================================
        /// <summary>A software key is restricting the use of this compression filter.</summary>

        DirectxCertificationFailure                                   =    -1074396004,
        //==========================================================================================
        /// <summary>The data for this frame exceeds the data buffer size specified when creating the AVI file.</summary>

        AviDataExceedsBufferSize                                      =    -1074396003,
        //==========================================================================================
        /// <summary>Invalid line gauge method.</summary>

        InvalidLinegaugemethod                                        =    -1074396002,
        //==========================================================================================
        /// <summary>There are too many AVI sessions open. You must close a session before you can open another one.</summary>

        TooManyAviSessions                                            =    -1074396001,
        //==========================================================================================
        /// <summary>Invalid file header.</summary>

        FileFileHeader                                                =    -1074396000,
        //==========================================================================================
        /// <summary>Invalid file type.</summary>

        FileFileType                                                  =    -1074395999,
        //==========================================================================================
        /// <summary>Invalid color table.</summary>

        FileColorTable                                                =    -1074395998,
        //==========================================================================================
        /// <summary>Invalid parameter.</summary>

        FileArgerr                                                    =    -1074395997,
        //==========================================================================================
        /// <summary>File is already open for writing.</summary>

        FileOpen                                                      =    -1074395996,
        //==========================================================================================
        /// <summary>File not found.</summary>

        FileNotFound                                                  =    -1074395995,
        //==========================================================================================
        /// <summary>Too many files open.</summary>

        FileTooManyOpen                                               =    -1074395994,
        //==========================================================================================
        /// <summary>File I/O error.</summary>

        FileIoErr                                                     =    -1074395993,
        //==========================================================================================
        /// <summary>File access denied.</summary>

        FilePermission                                                =    -1074395992,
        //==========================================================================================
        /// <summary>NI Vision does not support the file type you specified.</summary>

        FileInvalidType                                               =    -1074395991,
        //==========================================================================================
        /// <summary>Could not read Vision info from file.</summary>

        FileGetInfo                                                   =    -1074395990,
        //==========================================================================================
        /// <summary>Unable to read data.</summary>

        FileRead                                                      =    -1074395989,
        //==========================================================================================
        /// <summary>Unable to write data.</summary>

        FileWrite                                                     =    -1074395988,
        //==========================================================================================
        /// <summary>Premature end of file.</summary>

        FileEof                                                       =    -1074395987,
        //==========================================================================================
        /// <summary>Invalid file format.</summary>

        FileFormat                                                    =    -1074395986,
        //==========================================================================================
        /// <summary>Invalid file operation.</summary>

        FileOperation                                                 =    -1074395985,
        //==========================================================================================
        /// <summary>NI Vision does not support the file data type you specified.</summary>

        FileInvalidDataType                                           =    -1074395984,
        //==========================================================================================
        /// <summary>Disk full.</summary>

        FileNoSpace                                                   =    -1074395983,
        //==========================================================================================
        /// <summary>The frames per second in an AVI must be greater than zero.</summary>

        InvalidFramesPerSecond                                        =    -1074395982,
        //==========================================================================================
        /// <summary>The buffer that was passed in is not big enough to hold all of the data.</summary>

        InsufficientBufferSize                                        =    -1074395981,
        //==========================================================================================
        /// <summary>Error initializing COM.</summary>

        ComInitialize                                                 =    -1074395980,
        //==========================================================================================
        /// <summary>The image has invalid particle information. Call imaqCountParticles on the image to create particle information.</summary>

        InvalidParticleInfo                                           =    -1074395979,
        //==========================================================================================
        /// <summary>Invalid particle number.</summary>

        InvalidParticleNumber                                         =    -1074395978,
        //==========================================================================================
        /// <summary>The AVI file was created in a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this AVI file.</summary>

        AviVersion                                                    =    -1074395977,
        //==========================================================================================
        /// <summary>The color palette must have exactly 0 or 256 entries.</summary>

        NumberOfPaletteColors                                         =    -1074395976,
        //==========================================================================================
        /// <summary>DirectX has timed out reading or writing the AVI file. When closing an AVI file, try adding an additional delay. When reading an AVI file, try reducing CPU and disk load.</summary>

        AviTimeout                                                    =    -1074395975,
        //==========================================================================================
        /// <summary>NI Vision does not support reading JPEG2000 files with this colorspace method.</summary>

        UnsupportedJpeg2000ColorspaceMethod                           =    -1074395974,
        //==========================================================================================
        /// <summary>NI Vision does not support reading JPEG2000 files with more than one layer.</summary>

        Jpeg2000UnsupportedMultipleLayers                             =    -1074395973,
        //==========================================================================================
        /// <summary>DirectX is unable to enumerate the compression filters. This is caused by a third-party compression filter that is either improperly installed or is preventing itself from being enumerated. Remove any recently installed compression filters and try again.</summary>

        DirectxEnumerateFilters                                       =    -1074395972,
        //==========================================================================================
        /// <summary>The offset you specified must be size 2.</summary>

        InvalidOffset                                                 =    -1074395971,
        AviOpen                                                       =    -1074395970,
        AviCreate                                                     =    -1074395969,
        AviWrite                                                      =    -1074395968,
        AviRead                                                       =    -1074395967,
        AviImageConversion                                            =    -1074395966,
        AviMaxSizeReached                                             =    -1074395965,
        AviInvalidCodecSource                                         =    -1074395964,
        AviExtensionRequired                                          =    -1074395963,
        EmptyCodec                                                    =    -1074395962,
        Init                                                          =    -1074395960,
        //==========================================================================================
        /// <summary>Unable to create window.</summary>

        CreateWindow                                                  =    -1074395959,
        //==========================================================================================
        /// <summary>Invalid window ID.</summary>

        WindowId                                                      =    -1074395958,
        //==========================================================================================
        /// <summary>The array sizes are not compatible.</summary>

        ArraySizeMismatch                                             =    -1074395957,
        //==========================================================================================
        /// <summary>The quality you provided is invalid. Valid quality values range from -1 to 1000.</summary>

        InvalidQuality                                                =    -1074395956,
        //==========================================================================================
        /// <summary>Invalid maximum wavelet transform level. Valid values range from 0 to 255.</summary>

        InvalidMaxWaveletTransformLevel                               =    -1074395955,
        //==========================================================================================
        /// <summary>The quantization step size must be greater than or equal to 0.</summary>

        InvalidQuantizationStepSize                                   =    -1074395954,
        //==========================================================================================
        /// <summary>Invalid wavelet transform mode.</summary>

        InvalidWaveletTransformMode                                   =    -1074395953,
        RoiNotPoint                                                   =    -1074395952,
        RoiNotPoints                                                  =    -1074395951,
        RoiNotLine                                                    =    -1074395950,
        RoiNotAnnulus                                                 =    -1074395949,
        InvalidMeasureParticlesCalibrationMode                        =    -1074395948,
        InvalidParticleClassifierThresholdType                        =    -1074395947,
        InvalidDistance                                               =    -1074395946,
        InvalidParticleArea                                           =    -1074395945,
        ClassNameNotFound                                             =    -1074395944,
        NumberLabelLimitExceeded                                      =    -1074395943,
        InvalidDistanceLevel                                          =    -1074395942,
        InvalidSvmType                                                =    -1074395941,
        InvalidSvmKernel                                              =    -1074395940,
        NoSupportVectorFound                                          =    -1074395939,
        CostLabelNotFound                                             =    -1074395938,
        ExceededSvmMaxIteration                                       =    -1074395937,
        InvalidSvmParameter                                           =    -1074395936,
        InvalidIdentificationScore                                    =    -1074395935,
        InvalidTextureFeature                                         =    -1074395934,
        InvalidCooccurrenceLevel                                      =    -1074395933,
        InvalidWaveletSubband                                         =    -1074395932,
        InvalidFinalStepSize                                          =    -1074395931,
        InvalidEnergy                                                 =    -1074395930,
        InvalidTextureLabel                                           =    -1074395929,
        InvalidWaveletType                                            =    -1074395928,
        SameWaveletBandsSelected                                      =    -1074395927,
        ImageSizeMismatch                                             =    -1074395926,
        InvalidObjectTrackingFile                                     =    -1074395925,
        PyramidLevelNotValid                                          =    -1074395924,
        InvalidAngleRange                                             =    -1074395923,
        InvalidLearnAngleRange                                        =    -1074395922,
        OpeningNewerObjectTrackingRefnum                              =    -1074395921,
		//==========================================================================================
        /// <summary>Invalid number of classes.</summary>

        NumberClass                                                   =    -1074395920,
        InvalidThresholdType                                          =    -1074395919,
        MultipleLineDetectionNotEnabled                               =    -1074395918,
        OcrInvalidLineSeparator                                       =    -1074395917,
        InvalidObjectPosition                                         =    -1074395916,
        UnequalImageSizeForObjectAddition                             =    -1074395915,
        InvalidInitialAngle                                           =    -1074395914,
        UninitiatedShapeAdaptedMeanshift                              =    -1074395913,
        UninitiatedMeanshift                                          =    -1074395912,
        InvalidMinScore                                               =    -1074395911,
        InvalidBoundingbox                                            =    -1074395910,
        InvalidCovariancematrix                                       =    -1074395909,
        BadGaussiankernel                                             =    -1074395908,
        ObjectIsLost                                                  =    -1074395907,
        InvalidHistogramsize                                          =    -1074395906,
        InvalidHistogramtypes                                         =    -1074395905,
        ObjectOutsideFrame                                            =    -1074395904,
        InvalidHistogrambinsForColorProcessing                        =    -1074395903,
        SumhistUnexpected                                             =    -1074395902,
        InvalidObjecttrackingRefnum                                   =    -1074395901,
        NoShapeadaptedmeanshiftInstance                               =    -1074395900,
        NoMeanshiftInstance                                           =    -1074395899,
        InvalidObjectTrackingInstanceNumber                           =    -1074395898,
        InvalidTrackingmehod                                          =    -1074395897,
        InvalidBlobtrackingInfo                                       =    -1074395896,
        UninitializedObjecttrackingRefnum                             =    -1074395895,
        InvalidInstancenumber                                         =    -1074395894,
        InvalidMaxshapechange                                         =    -1074395893,
        InvalidMaxrotationchange                                      =    -1074395892,
        InvalidMaxscalechange                                         =    -1074395891,
        InvalidNumberOfHistogrambins                                  =    -1074395890,
        InvalidBlendingparameter                                      =    -1074395889,
        InvalidLucasKanadeWindowSize                                  =    -1074395888,
        InvalidMatrixType                                             =    -1074395887,
        InvalidOpticalFlowTerminationCriteriaType                     =    -1074395886,
        LkpNullPyramid                                                =    -1074395885,
        InvalidPyramidLevel                                           =    -1074395884,
        InvalidLkpKernel                                              =    -1074395883,
        InvalidHornSchunckLambda                                      =    -1074395882,
        InvalidHornSchunckType                                        =    -1074395881,
        //==========================================================================================
        /// <summary>Invalid particle.</summary>

        Particle                                                      =    -1074395880,
        //==========================================================================================
        /// <summary>Invalid measure number.</summary>

        BadMeasure                                                    =    -1074395879,
        //==========================================================================================
        /// <summary>The Image Display control does not support writing this property node.</summary>

        PropNodeWriteNotSupported                                     =    -1074395878,
        ColormodeRequiresChangecolorspace2                            =    -1074395877,
        //==========================================================================================
        /// <summary>This function does not currently support the color mode you specified.</summary>

        UnsupportedColorMode                                          =    -1074395876,
        //==========================================================================================
        /// <summary>The barcode is not a valid Pharmacode symbol</summary>

        BarcodePharmacode                                             =    -1074395875,
        //==========================================================================================
        /// <summary>Invalid handle table index.</summary>

        BadIndex                                                      =    -1074395840,
        //==========================================================================================
        /// <summary>The compression ratio must be greater than or equal to 1.</summary>

        InvalidCompressionRatio                                       =    -1074395837,
        //==========================================================================================
        /// <summary>The ROI contains too many contours.</summary>

        TooManyContours                                               =    -1074395801,
        //==========================================================================================
        /// <summary>Protection error.</summary>

        Protection                                                    =    -1074395800,
        //==========================================================================================
        /// <summary>Internal error.</summary>

        Internal                                                      =    -1074395799,
        //==========================================================================================
        /// <summary>The size of the feature vector in the custom sample must match the size of those you have already added.</summary>

        InvalidCustomSample                                           =    -1074395798,
        //==========================================================================================
        /// <summary>Not a valid classifier session.</summary>

        InvalidClassifierSession                                      =    -1074395797,
        //==========================================================================================
        /// <summary>You requested an invalid Nearest Neighbor classifier method.</summary>

        InvalidKnnMethod                                              =    -1074395796,
        //==========================================================================================
        /// <summary>The k parameter must be greater than two.</summary>

        KTooLow                                                       =    -1074395795,
        //==========================================================================================
        /// <summary>The k parameter must be <entity value="le"/> the number of samples in each class.</summary>

        KTooHigh                                                      =    -1074395794,
        //==========================================================================================
        /// <summary>This classifier session is compact. Only the Classify and Dispose functions may be called on a compact classifier session.</summary>

        InvalidOperationOnCompactSessionAttempted                     =    -1074395793,
        //==========================================================================================
        /// <summary>This classifier session is not trained. You may only call this function on a trained classifier session.</summary>

        ClassifierSessionNotTrained                                   =    -1074395792,
        //==========================================================================================
        /// <summary>This classifier function cannot be called on this type of classifier session.</summary>

        ClassifierInvalidSessionType                                  =    -1074395791,
        //==========================================================================================
        /// <summary>You requested an invalid distance metric.</summary>

        InvalidDistanceMetric                                         =    -1074395790,
        //==========================================================================================
        /// <summary>The classifier session you tried to open was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this file.</summary>

        OpeningNewerClassifierSession                                 =    -1074395789,
        //==========================================================================================
        /// <summary>This operation cannot be performed because you have not added any samples.</summary>

        NoSamples                                                     =    -1074395788,
        //==========================================================================================
        /// <summary>You requested an invalid classifier type.</summary>

        InvalidClassifierType                                         =    -1074395787,
        //==========================================================================================
        /// <summary>The sum of Scale Dependence and Symmetry Dependence must be less than 1000.</summary>

        InvalidParticleOptions                                        =    -1074395786,
        //==========================================================================================
        /// <summary>The image yielded no particles.</summary>

        NoParticle                                                    =    -1074395785,
        //==========================================================================================
        /// <summary>The limits you supplied are not valid.</summary>

        InvalidLimits                                                 =    -1074395784,
        //==========================================================================================
        /// <summary>The Sample Index fell outside the range of Samples.</summary>

        BadSampleIndex                                                =    -1074395783,
        //==========================================================================================
        /// <summary>The description must be <entity value="le"/> 255 characters.</summary>

        DescriptionTooLong                                            =    -1074395782,
        //==========================================================================================
        /// <summary>The engine for this classifier session does not support this operation.</summary>

        ClassifierInvalidEngineType                                   =    -1074395781,
        //==========================================================================================
        /// <summary>You requested an invalid particle type.</summary>

        InvalidParticleType                                           =    -1074395780,
        //==========================================================================================
        /// <summary>You may only save a session in compact form if it is trained.</summary>

        CannotCompactUntrained                                        =    -1074395779,
        //==========================================================================================
        /// <summary>The Kernel size must be smaller than the image size.</summary>

        InvalidKernelSize                                             =    -1074395778,
        //==========================================================================================
        /// <summary>The session you read from file must be the same type as the session you passed in.</summary>

        IncompatibleClassifierTypes                                   =    -1074395777,
        //==========================================================================================
        /// <summary>You can not use a compact classification file with read options other than Read All.</summary>

        InvalidUseOfCompactSessionFile                                =    -1074395776,
        //==========================================================================================
        /// <summary>The ROI you passed in may only contain closed contours.</summary>

        RoiHasOpenContours                                            =    -1074395775,
        //==========================================================================================
        /// <summary>You must pass in a label.</summary>

        NoLabel                                                       =    -1074395774,
        //==========================================================================================
        /// <summary>You must provide a destination image.</summary>

        NoDestImage                                                   =    -1074395773,
        //==========================================================================================
        /// <summary>You provided an invalid registration method.</summary>

        InvalidRegistrationMethod                                     =    -1074395772,
        //==========================================================================================
        /// <summary>The golden template you tried to open was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this file.</summary>

        OpeningNewerInspectionTemplate                                =    -1074395771,
        //==========================================================================================
        /// <summary>Invalid golden template.</summary>

        InvalidInspectionTemplate                                     =    -1074395770,
        //==========================================================================================
        /// <summary>Edge Thickness to Ignore must be greater than zero.</summary>

        InvalidEdgeThickness                                          =    -1074395769,
        //==========================================================================================
        /// <summary>Scale must be greater than zero.</summary>

        InvalidScale                                                  =    -1074395768,
        //==========================================================================================
        /// <summary>The supplied scale is invalid for your template.</summary>

        InvalidAlignment                                              =    -1074395767,
        //==========================================================================================
        /// <summary>This backwards-compatibility function can not be used with this session. Use newer, supported functions instead.</summary>

        DeprecatedFunction                                            =    -1074395766,
        //==========================================================================================
        /// <summary>You must provide a valid normalization method.</summary>

        InvalidNormalizationMethod                                    =    -1074395763,
        //==========================================================================================
        /// <summary>The deviation factor for Niblack local threshold must be between 0 and 1.</summary>

        InvalidNiblackDeviationFactor                                 =    -1074395762,
        //==========================================================================================
        /// <summary>Board not found.</summary>

        BoardNotFound                                                 =    -1074395760,
        //==========================================================================================
        /// <summary>Board not opened.</summary>

        BoardNotOpen                                                  =    -1074395758,
        //==========================================================================================
        /// <summary>DLL not found.</summary>

        DllNotFound                                                   =    -1074395757,
        //==========================================================================================
        /// <summary>DLL function not found.</summary>

        DllFunctionNotFound                                           =    -1074395756,
        //==========================================================================================
        /// <summary>Trigger timeout.</summary>

        TrigTimeout                                                   =    -1074395754,
        ContourInvalidRefinements                                     =    -1074395746,
        TooManyCurves                                                 =    -1074395745,
        ContourInvalidKernelForSmoothing                              =    -1074395744,
        ContourLineInvalid                                            =    -1074395743,
        ContourTemplateImageInvalid                                   =    -1074395742,
        ContourGpmFail                                                =    -1074395741,
        ContourOpeningNewerVersion                                    =    -1074395740,
        ContourConnectDuplicate                                       =    -1074395739,
        ContourConnectType                                            =    -1074395738,
        ContourMatchStrNotApplicable                                  =    -1074395737,
        ContourCurvatureKernel                                        =    -1074395736,
        ContourExtractSelection                                       =    -1074395735,
        ContourExtractDirection                                       =    -1074395734,
        ContourExtractRoi                                             =    -1074395733,
        ContourNoCurves                                               =    -1074395732,
        ContourCompareKernel                                          =    -1074395731,
        ContourCompareSingleImage                                     =    -1074395730,
        ContourInvalid                                                =    -1074395729,
        //==========================================================================================
        /// <summary>NI Vision does not support the search mode you provided.</summary>

        Invalid2dBarcodeSearchMode                                    =    -1074395728,
        //==========================================================================================
        /// <summary>NI Vision does not support the search mode you provided for the type of 2D barcode for which you are searching.</summary>

        Unsupported2dBarcodeSearchMode                                =    -1074395727,
        //==========================================================================================
        /// <summary>matchFactor has been obsoleted. Instead, set the initialMatchListLength and matchListReductionFactor in the MatchPatternAdvancedOptions structure.</summary>

        MatchfactorObsolete                                           =    -1074395726,
        //==========================================================================================
        /// <summary>The data was stored with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this data.</summary>

        DataVersion                                                   =    -1074395725,
        //==========================================================================================
        /// <summary>The size you specified is out of the valid range.</summary>

        CustomdataInvalidSize                                         =    -1074395724,
        //==========================================================================================
        /// <summary>The key you specified cannot be found in the image.</summary>

        CustomdataKeyNotFound                                         =    -1074395723,
        //==========================================================================================
        /// <summary>Custom classifier sessions only classify feature vectors. They do not support classifying images.</summary>

        ClassifierClassifyImageWithCustomSession                      =    -1074395722,
        //==========================================================================================
        /// <summary>NI Vision does not support the bit depth you supplied for the image you supplied.</summary>

        InvalidBitDepth                                               =    -1074395721,
        //==========================================================================================
        /// <summary>Invalid ROI.</summary>

        BadRoi                                                        =    -1074395720,
        //==========================================================================================
        /// <summary>Invalid ROI global rectangle.</summary>

        BadRoiBox                                                     =    -1074395719,
        //==========================================================================================
        /// <summary>The version of LabVIEW or BridgeVIEW you are running does not support this operation.</summary>

        LabVersion                                                    =    -1074395718,
        //==========================================================================================
        /// <summary>The range you supplied is invalid.</summary>

        InvalidRange                                                  =    -1074395717,
        //==========================================================================================
        /// <summary>NI Vision does not support the scaling method you provided.</summary>

        InvalidScalingMethod                                          =    -1074395716,
        //==========================================================================================
        /// <summary>NI Vision does not support the calibration unit you supplied.</summary>

        InvalidCalibrationUnit                                        =    -1074395715,
        //==========================================================================================
        /// <summary>NI Vision does not support the axis orientation you supplied.</summary>

        InvalidAxisOrientation                                        =    -1074395714,
        //==========================================================================================
        /// <summary>Value not in enumeration.</summary>

        ValueNotInEnum                                                =    -1074395713,
        //==========================================================================================
        /// <summary>You selected a region that is not of the right type.</summary>

        WrongRegionType                                               =    -1074395712,
        //==========================================================================================
        /// <summary>You specified a viewer that does not contain enough regions.</summary>

        NotEnoughRegions                                              =    -1074395711,
        //==========================================================================================
        /// <summary>The image has too many particles for this process.</summary>

        TooManyParticles                                              =    -1074395710,
        //==========================================================================================
        /// <summary>The AVI session has not been opened.</summary>

        AviUnopenedSession                                            =    -1074395709,
        //==========================================================================================
        /// <summary>The AVI session is a write session, but this operation requires a read session.</summary>

        AviReadSessionRequired                                        =    -1074395708,
        //==========================================================================================
        /// <summary>The AVI session is a read session, but this operation requires a write session.</summary>

        AviWriteSessionRequired                                       =    -1074395707,
        //==========================================================================================
        /// <summary>This AVI session is already open. You must close it before calling the Create or Open functions.</summary>

        AviSessionAlreadyOpen                                         =    -1074395706,
        //==========================================================================================
        /// <summary>The data is corrupted and cannot be read.</summary>

        DataCorrupted                                                 =    -1074395705,
        //==========================================================================================
        /// <summary>Invalid compression type.</summary>

        InvalidCompressionType                                        =    -1074395704,
        //==========================================================================================
        /// <summary>Invalid type of flatten.</summary>

        InvalidTypeOfFlatten                                          =    -1074395703,
        //==========================================================================================
        /// <summary>The length of the edge detection line must be greater than zero.</summary>

        InvalidLength                                                 =    -1074395702,
        //==========================================================================================
        /// <summary>The maximum Data Matrix barcode size must be equal to or greater than the minimum Data Matrix barcode size.</summary>

        InvalidMatrixSizeRange                                        =    -1074395701,
        //==========================================================================================
        /// <summary>The function requires the operating system to be Microsoft Windows 2000 or newer.</summary>

        RequiresWin2000OrNewer                                        =    -1074395700,
        //==========================================================================================
        /// <summary>You must specify the same value for the smooth contours advanced match option for all templates you want to match.</summary>

        SmoothContoursMustBeSame                                      =    -1074395656,
        //==========================================================================================
        /// <summary>You must specify the same value for the enable calibration support advanced match option for all templates you want to match.</summary>

        EnableCalibrationSupportMustBeSame                            =    -1074395655,
        //==========================================================================================
        /// <summary>The source image does not contain grading information. You must prepare the source image for grading when reading the Data Matrix, and you cannot change the contents of the source image between reading and grading the Data Matrix.</summary>

        GradingInformationNotFound                                    =    -1074395654,
        //==========================================================================================
        /// <summary>The multiple geometric matching template you tried to open was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this file.</summary>

        OpeningNewerMultipleGeometricTemplate                         =    -1074395653,
        //==========================================================================================
        /// <summary>The geometric matching template you tried to open was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to read this file.</summary>

        OpeningNewerGeometricMatchingTemplate                         =    -1074395652,
        //==========================================================================================
        /// <summary>You must specify the same edge filter size for all the templates you want to match.</summary>

        EdgeFilterSizeMustBeSame                                      =    -1074395651,
        //==========================================================================================
        /// <summary>You must specify the same curve extraction mode for all the templates you want to match.</summary>

        CurveExtractionModeMustBeSame                                 =    -1074395650,
        //==========================================================================================
        /// <summary>The geometric feature type specified is invalid.</summary>

        InvalidGeometricFeatureType                                   =    -1074395649,
        //==========================================================================================
        /// <summary>You supplied a template that was not learned.</summary>

        TemplateNotLearned                                            =    -1074395648,
        //==========================================================================================
        /// <summary>Invalid multiple geometric template.</summary>

        InvalidMultipleGeometricTemplate                              =    -1074395647,
        //==========================================================================================
        /// <summary>Need at least one template to learn.</summary>

        NoTemplateToLearn                                             =    -1074395646,
        //==========================================================================================
        /// <summary>You supplied an invalid number of labels.</summary>

        InvalidNumberOfLabels                                         =    -1074395645,
        //==========================================================================================
        /// <summary>Labels must be <entity value="le"/> 255 characters.</summary>

        LabelTooLong                                                  =    -1074395644,
        //==========================================================================================
        /// <summary>You supplied an invalid number of match options.</summary>

        InvalidNumberOfMatchOptions                                   =    -1074395643,
        //==========================================================================================
        /// <summary>Cannot find a label that matches the one you specified.</summary>

        LabelNotFound                                                 =    -1074395642,
        //==========================================================================================
        /// <summary>Duplicate labels are not allowed.</summary>

        DuplicateLabel                                                =    -1074395641,
        //==========================================================================================
        /// <summary>The number of zones found exceeded the capacity of the algorithm.</summary>

        TooManyZones                                                  =    -1074395640,
        //==========================================================================================
        /// <summary>The hatch style for the window background is invalid.</summary>

        InvalidHatchStyle                                             =    -1074395639,
        //==========================================================================================
        /// <summary>The fill style for the window background is invalid.</summary>

        InvalidFillStyle                                              =    -1074395638,
        //==========================================================================================
        /// <summary>Your hardware is not supported by DirectX and cannot be put into NonTearing mode.</summary>

        HardwareDoesntSupportNontearing                               =    -1074395637,
        //==========================================================================================
        /// <summary>DirectX is required for this feature. Please install the latest version..</summary>

        DirectxNotFound                                               =    -1074395636,
        //==========================================================================================
        /// <summary>The passed shape descriptor is invalid.</summary>

        InvalidShapeDescriptor                                        =    -1074395635,
        //==========================================================================================
        /// <summary>Invalid max match overlap. Values must be between -1 and 100.</summary>

        InvalidMaxMatchOverlap                                        =    -1074395634,
        //==========================================================================================
        /// <summary>Invalid minimum match separation scale. Values must be greater than or equal to -1.</summary>

        InvalidMinMatchSeparationScale                                =    -1074395633,
        //==========================================================================================
        /// <summary>Invalid minimum match separation angle. Values must be between -1 and 360.</summary>

        InvalidMinMatchSeparationAngle                                =    -1074395632,
        //==========================================================================================
        /// <summary>Invalid minimum match separation distance. Values must be greater than or equal to -1.</summary>

        InvalidMinMatchSeparationDistance                             =    -1074395631,
        //==========================================================================================
        /// <summary>Invalid maximum number of features learn. Values must be integers greater than zero.</summary>

        InvalidMaximumFeaturesLearned                                 =    -1074395630,
        //==========================================================================================
        /// <summary>Invalid maximum pixel distance from line. Values must be positive real numbers.</summary>

        InvalidMaximumPixelDistanceFromLine                           =    -1074395629,
        //==========================================================================================
        /// <summary>Invalid geometric matching template image.</summary>

        InvalidGeometricMatchingTemplate                              =    -1074395628,
        //==========================================================================================
        /// <summary>The template does not contain enough features for geometric matching.</summary>

        NotEnoughTemplateFeatures1                                    =    -1074395627,
        //==========================================================================================
        /// <summary>The template does not contain enough features for geometric matching.</summary>

        NotEnoughTemplateFeatures                                     =    -1074395626,
        //==========================================================================================
        /// <summary>You specified an invalid value for the match constraint value of the range settings.</summary>

        InvalidMatchConstraintType                                    =    -1074395625,
        //==========================================================================================
        /// <summary>Invalid occlusion range. Valid values for the bounds range from 0 to 100 and the upper bound must be greater than or equal to the lower bound.</summary>

        InvalidOcclusionRange                                         =    -1074395624,
        //==========================================================================================
        /// <summary>Invalid scale range. Values for the lower bound must be a positive real numbers and the upper bound must be greater than or equal to the lower bound.</summary>

        InvalidScaleRange                                             =    -1074395623,
        //==========================================================================================
        /// <summary>Invalid match geometric pattern setup data.</summary>

        InvalidMatchGeometricPatternSetupData                         =    -1074395622,
        //==========================================================================================
        /// <summary>Invalid learn geometric pattern setup data.</summary>

        InvalidLearnGeometricPatternSetupData                         =    -1074395621,
        //==========================================================================================
        /// <summary>You must specify the same curve extraction mode for all the templates you want to match.</summary>

        InvalidCurveExtractionMode                                    =    -1074395620,
        //==========================================================================================
        /// <summary>You can specify only one occlusion range.</summary>

        TooManyOcclusionRanges                                        =    -1074395619,
        //==========================================================================================
        /// <summary>You can specify only one scale range.</summary>

        TooManyScaleRanges                                            =    -1074395618,
        //==========================================================================================
        /// <summary>The minimum number of features must be less than or equal to the maximum number of features.</summary>

        InvalidNumberOfFeaturesRange                                  =    -1074395617,
        //==========================================================================================
        /// <summary>Invalid edge filter size.</summary>

        InvalidEdgeFilterSize                                         =    -1074395616,
        //==========================================================================================
        /// <summary>Invalid minimum strength for features. Values must be positive real numbers.</summary>

        InvalidMinimumFeatureStrength                                 =    -1074395615,
        //==========================================================================================
        /// <summary>Invalid aspect ratio for rectangular features. Values must be positive real numbers in the range 0.01 to 1.0.</summary>

        InvalidMinimumFeatureAspectRatio                              =    -1074395614,
        //==========================================================================================
        /// <summary>Invalid minimum length for linear features. Values must be integers greater than 0.</summary>

        InvalidMinimumFeatureLength                                   =    -1074395613,
        //==========================================================================================
        /// <summary>Invalid minimum radius for circular features. Values must be integers greater than 0.</summary>

        InvalidMinimumFeatureRadius                                   =    -1074395612,
        //==========================================================================================
        /// <summary>Invalid minimum rectangle dimension. Values must be integers greater than 0.</summary>

        InvalidMinimumRectangleDimension                              =    -1074395611,
        //==========================================================================================
        /// <summary>Invalid initial match list length. Values must be integers greater than 5.</summary>

        InvalidInitialMatchListLength                                 =    -1074395610,
        //==========================================================================================
        /// <summary>Invalid subpixel tolerance. Values must be positive real numbers.</summary>

        InvalidSubpixelTolerance                                      =    -1074395609,
        //==========================================================================================
        /// <summary>Invalid number of subpixel iterations. Values must be integers greater 10.</summary>

        InvalidSubpixelIterations                                     =    -1074395608,
        //==========================================================================================
        /// <summary>Invalid maximum number of features used per match. Values must be integers greater than or equal to zero.</summary>

        InvalidMaximumFeaturesPerMatch                                =    -1074395607,
        //==========================================================================================
        /// <summary>Invalid minimum number of features used for matching. Values must be integers greater than zero.</summary>

        InvalidMinimumFeaturesToMatch                                 =    -1074395606,
        //==========================================================================================
        /// <summary>Invalid maximum end point gap. Valid values range from 0 to 32767.</summary>

        InvalidMaximumEndPointGap                                     =    -1074395605,
        //==========================================================================================
        /// <summary>Invalid column step. Valid range is 1 to 255.</summary>

        InvalidColumnStep                                             =    -1074395604,
        //==========================================================================================
        /// <summary>Invalid row step. Valid range is 1 to 255.</summary>

        InvalidRowStep                                                =    -1074395603,
        //==========================================================================================
        /// <summary>Invalid minimum length. Valid values must be greater than or equal to zero.</summary>

        InvalidMinimumCurveLength                                     =    -1074395602,
        //==========================================================================================
        /// <summary>Invalid edge threshold. Valid values range from 1 to 360.</summary>

        InvalidEdgeThreshold                                          =    -1074395601,
        //==========================================================================================
        /// <summary>You must provide information about the subimage within the browser.</summary>

        InfoNotFound                                                  =    -1074395600,
        //==========================================================================================
        /// <summary>The acceptance level is outside the valid range of 0 to 1000.</summary>

        NiocrInvalidAcceptanceLevel                                   =    -1074395598,
        //==========================================================================================
        /// <summary>Not a valid OCR session.</summary>

        NiocrNotAValidSession                                         =    -1074395597,
        //==========================================================================================
        /// <summary>Invalid character size. Character size must be <entity value="ge"/> 1.</summary>

        NiocrInvalidCharacterSize                                     =    -1074395596,
        //==========================================================================================
        /// <summary>Invalid threshold mode value.</summary>

        NiocrInvalidThresholdMode                                     =    -1074395595,
        //==========================================================================================
        /// <summary>Invalid substitution character. Valid substitution characters are ASCII values that range from 1 to 254.</summary>

        NiocrInvalidSubstitutionCharacter                             =    -1074395594,
        //==========================================================================================
        /// <summary>Invalid number of blocks. Number of blocks must be <entity value="ge"/> 4 and <entity value="le"/>50.</summary>

        NiocrInvalidNumberOfBlocks                                    =    -1074395593,
        //==========================================================================================
        /// <summary>Invalid read strategy.</summary>

        NiocrInvalidReadStrategy                                      =    -1074395592,
        //==========================================================================================
        /// <summary>Invalid character index.</summary>

        NiocrInvalidCharacterIndex                                    =    -1074395591,
        //==========================================================================================
        /// <summary>Invalid number of character positions. Valid values range from 0 to 255.</summary>

        NiocrInvalidNumberOfValidCharacterPositions                   =    -1074395590,
        //==========================================================================================
        /// <summary>Invalid high threshold value. Valid threshold values range from 0 to 255.</summary>

        NiocrInvalidLowThresholdValue                                 =    -1074395589,
        //==========================================================================================
        /// <summary>Invalid high threshold value. Valid threshold values range from 0 to 255.</summary>

        NiocrInvalidHighThresholdValue                                =    -1074395588,
        //==========================================================================================
        /// <summary>The low threshold must be less than the high threshold.</summary>

        NiocrInvalidThresholdRange                                    =    -1074395587,
        //==========================================================================================
        /// <summary>Invalid lower threshold limit. Valid lower threshold limits range from 0 to 255.</summary>

        NiocrInvalidLowerThresholdLimit                               =    -1074395586,
        //==========================================================================================
        /// <summary>Invalid upper threshold limit. Valid upper threshold limits range from 0 to 255.</summary>

        NiocrInvalidUpperThresholdLimit                               =    -1074395585,
        //==========================================================================================
        /// <summary>The lower threshold limit must be less than the upper threshold limit.</summary>

        NiocrInvalidThresholdLimits                                   =    -1074395584,
        //==========================================================================================
        /// <summary>Invalid minimum character spacing value. Character spacing must be &gt;= 0 pixels.</summary>

        NiocrInvalidMinCharSpacing                                    =    -1074395583,
        //==========================================================================================
        /// <summary>Invalid maximum horizontal element spacing value. Maximum horizontal element spacing must be &gt;= 0.</summary>

        NiocrInvalidMaxHorizElementSpacing                            =    -1074395582,
        //==========================================================================================
        /// <summary>Invalid maximum vertical element spacing value. Maximum vertical element spacing must be &gt;= 0.</summary>

        NiocrInvalidMaxVertElementSpacing                             =    -1074395581,
        //==========================================================================================
        /// <summary>Invalid minimum bounding rectangle width. Minimum bounding rectangle width must be &gt;= 1.</summary>

        NiocrInvalidMinBoundingRectWidth                              =    -1074395580,
        //==========================================================================================
        /// <summary>Invalid aspect ratio value. The aspect ratio must be zero or &gt;= 100.</summary>

        NiocrInvalidAspectRatio                                       =    -1074395579,
        //==========================================================================================
        /// <summary>Invalid or corrupt character set file.</summary>

        NiocrInvalidCharacterSetFile                                  =    -1074395578,
        //==========================================================================================
        /// <summary>The character value must not be an empty string.</summary>

        NiocrCharacterValueCannotBeEmptystring                        =    -1074395577,
        //==========================================================================================
        /// <summary>Character values must be <entity value="le"/>255 characters.</summary>

        NiocrCharacterValueTooLong                                    =    -1074395576,
        //==========================================================================================
        /// <summary>Invalid number of erosions. The number of erosions must be &gt;= 0.</summary>

        NiocrInvalidNumberOfErosions                                  =    -1074395575,
        //==========================================================================================
        /// <summary>The character set description must be <entity value="le"/>255 characters.</summary>

        NiocrCharacterSetDescriptionTooLong                           =    -1074395574,
        //==========================================================================================
        /// <summary>The character set file was created by a newer version of NI Vision. Upgrade to the latest version of NI Vision to read the character set file.</summary>

        NiocrInvalidCharacterSetFileVersion                           =    -1074395573,
        //==========================================================================================
        /// <summary>You must specify characters for a string. A string cannot contain integers.</summary>

        NiocrIntegerValueForStringAttribute                           =    -1074395572,
        //==========================================================================================
        /// <summary>This attribute is read-only.</summary>

        NiocrGetOnlyAttribute                                         =    -1074395571,
        //==========================================================================================
        /// <summary>This attribute requires a Boolean value.</summary>

        NiocrIntegerValueForBooleanAttribute                          =    -1074395570,
        //==========================================================================================
        /// <summary>Invalid attribute.</summary>

        NiocrInvalidAttribute                                         =    -1074395569,
        //==========================================================================================
        /// <summary>This attribute requires integer values.</summary>

        NiocrStringValueForIntegerAttribute                           =    -1074395568,
        //==========================================================================================
        /// <summary>String values are invalid for this attribute. Enter a boolean value.</summary>

        NiocrStringValueForBooleanAttribute                           =    -1074395567,
        //==========================================================================================
        /// <summary>Boolean values are not valid for this attribute. Enter an integer value.</summary>

        NiocrBooleanValueForIntegerAttribute                          =    -1074395566,
        //==========================================================================================
        /// <summary>Requires a single-character string.</summary>

        NiocrMustBeSingleCharacter                                    =    -1074395565,
        //==========================================================================================
        /// <summary>Invalid predefined character value.</summary>

        NiocrInvalidPredefinedCharacter                               =    -1074395564,
        //==========================================================================================
        /// <summary>This copy of NI OCR is unlicensed.</summary>

        NiocrUnlicensed                                               =    -1074395563,
        //==========================================================================================
        /// <summary>String values are not valid for this attribute. Enter a Boolean value.</summary>

        NiocrBooleanValueForStringAttribute                           =    -1074395562,
        //==========================================================================================
        /// <summary>The number of characters in the character value must match the number of objects in the image.</summary>

        NiocrInvalidNumberOfCharacters                                =    -1074395561,
        //==========================================================================================
        /// <summary>Invalid object index.</summary>

        NiocrInvalidObjectIndex                                       =    -1074395560,
        //==========================================================================================
        /// <summary>Invalid read option.</summary>

        NiocrInvalidReadOption                                        =    -1074395559,
        //==========================================================================================
        /// <summary>The minimum character size must be less than the maximum character size.</summary>

        NiocrInvalidCharacterSizeRange                                =    -1074395558,
        //==========================================================================================
        /// <summary>The minimum character bounding rectangle width must be less than the maximum character bounding rectangle width.</summary>

        NiocrInvalidBoundingRectWidthRange                            =    -1074395557,
        //==========================================================================================
        /// <summary>The minimum character bounding rectangle height must be less than the maximum character bounding rectangle height.</summary>

        NiocrInvalidBoundingRectHeightRange                           =    -1074395556,
        //==========================================================================================
        /// <summary>The maximum horizontal element spacing value must not exceed the minimum character spacing value.</summary>

        NiocrInvalidSpacingRange                                      =    -1074395555,
        //==========================================================================================
        /// <summary>Invalid read resolution.</summary>

        NiocrInvalidReadResolution                                    =    -1074395554,
        //==========================================================================================
        /// <summary>Invalid minimum bounding rectangle height. The minimum bounding rectangle height must be &gt;= 1.</summary>

        NiocrInvalidMinBoundingRectHeight                             =    -1074395553,
        //==========================================================================================
        /// <summary>Not a valid character set.</summary>

        NiocrNotAValidCharacterSet                                    =    -1074395552,
        //==========================================================================================
        /// <summary>A trained OCR character cannot be renamed while it is a reference character.</summary>

        NiocrRenameRefchar                                            =    -1074395551,
        //==========================================================================================
        /// <summary>A character cannot have an ASCII value of 255.</summary>

        NiocrInvalidCharacterValue                                    =    -1074395550,
        //==========================================================================================
        /// <summary>The number of objects found does not match the number of expected characters or patterns to verify.</summary>

        NiocrInvalidNumberOfObjectsToVerify                           =    -1074395549,
        //==========================================================================================
        /// <summary>NI Vision does not support less than one icon per line.</summary>

        MaxCharLengthPerLine                                          =    -1074395437,
        IncompImageSizeForTracking                                    =    -1074395436,
        InvalidMinOrMaxDepthValue                                     =    -1074395435,
        InvalidPolynomialOrder                                        =    -1074395434,
        InvalidInterpolationSamplingFrequency                         =    -1074395433,
        InvalidStereoInvalidMinDepth                                  =    -1074395432,
        InvalidStereoInvalidDisparityValue                            =    -1074395431,
        InvalidStereoCameraTranslation                                =    -1074395430,
        InvalidStereoCameraPosition                                   =    -1074395429,
        InvalidStereoBlockmatchingPostfilterSpecklerange              =    -1074395428,
        InvalidStereoBlockmatchingPostfilterSpecklesize               =    -1074395427,
        InvalidStereoBlockmatchingPostfilterTexture                   =    -1074395426,
        InvalidStereoBlockmatchingPostfilterUniqueness                =    -1074395425,
        InvalidMinDepthValue                                          =    -1074395424,
        InvalidStereoQMatrix                                          =    -1074395423,
        InvalidStereoScalingParameter                                 =    -1074395422,
        InvalidStereoBlockmatchingPrefilterCap                        =    -1074395421,
        InvalidStereoBlockmatchingPrefilterSize                       =    -1074395420,
        InvalidStereoBlockmatchingPrefilterType                       =    -1074395419,
        InvalidStereoBlockmatchingNumdisparities                      =    -1074395418,
        InvalidStereoBlockmatchingWindowSize                          =    -1074395417,
        Invalid3dvisionSessionType                                    =    -1074395416,
        TooMany3dvisionSessions                                       =    -1074395415,
        OpeningNewer3dvisionSession                                   =    -1074395414,
        InvalidStereoBlockmatchingFiltertype                          =    -1074395413,
        Invalid3dvisionSession                                        =    -1074395411,
        InvalidIconsPerLine                                           =    -1074395410,
        //==========================================================================================
        /// <summary>Invalid subpixel divisions.</summary>

        InvalidSubpixelDivisions                                      =    -1074395409,
        //==========================================================================================
        /// <summary>Invalid detection mode.</summary>

        InvalidDetectionMode                                          =    -1074395408,
        //==========================================================================================
        /// <summary>Invalid contrast value. Valid contrast values range from 0 to 255.</summary>

        InvalidContrast                                               =    -1074395407,
        //==========================================================================================
        /// <summary>The supplied ContourID did not correlate to a contour inside the ROI.</summary>

        CoordsysNotFound                                              =    -1074395406,
        //==========================================================================================
        /// <summary>NI Vision does not support the text orientation value you supplied.</summary>

        InvalidTextorientation                                        =    -1074395405,
        //==========================================================================================
        /// <summary>UnwrapImage does not support the interpolation method value you supplied. Valid interpolation methods are zero order and bilinear.</summary>

        InvalidInterpolationmethodForUnwrap                           =    -1074395404,
        //==========================================================================================
        /// <summary>The image was created in a newer version of NI Vision. Upgrade to the latest version of NI Vision to use this image.</summary>

        ExtrainfoVersion                                              =    -1074395403,
        //==========================================================================================
        /// <summary>The function does not support the maximum number of points that you specified.</summary>

        InvalidMaxpoints                                              =    -1074395402,
        //==========================================================================================
        /// <summary>The function does not support the matchFactor that you specified.</summary>

        InvalidMatchfactor                                            =    -1074395401,
        //==========================================================================================
        /// <summary>The operation you have given Multicore Options is invalid. Please see the available enumeration values for Multicore Operation.</summary>

        MulticoreOperation                                            =    -1074395400,
        //==========================================================================================
        /// <summary>You have given Multicore Options an invalid argument.</summary>

        MulticoreInvalidArgument                                      =    -1074395399,
        //==========================================================================================
        /// <summary>A complex image is required.</summary>

        ComplexImageRequired                                          =    -1074395397,
        //==========================================================================================
        /// <summary>The input image must be a color image.</summary>

        ColorImageRequired                                            =    -1074395395,
        //==========================================================================================
        /// <summary>The color mask removes too much color information.</summary>

        ColorSpectrumMask                                             =    -1074395394,
        //==========================================================================================
        /// <summary>The color template image is too small.</summary>

        ColorTemplateImageTooSmall                                    =    -1074395393,
        //==========================================================================================
        /// <summary>The color template image is too large.</summary>

        ColorTemplateImageTooLarge                                    =    -1074395392,
        //==========================================================================================
        /// <summary>The contrast in the hue plane of the image is too low for learning shape features.</summary>

        ColorTemplateImageHueContrastTooLow                           =    -1074395391,
        //==========================================================================================
        /// <summary>The contrast in the luminance plane of the image is too low to learn shape features.</summary>

        ColorTemplateImageLuminanceContrastTooLow                     =    -1074395390,
        //==========================================================================================
        /// <summary>Invalid color learn setup data.</summary>

        ColorLearnSetupData                                           =    -1074395389,
        //==========================================================================================
        /// <summary>Invalid color learn setup data.</summary>

        ColorLearnSetupDataShape                                      =    -1074395388,
        //==========================================================================================
        /// <summary>Invalid color match setup data.</summary>

        ColorMatchSetupData                                           =    -1074395387,
        //==========================================================================================
        /// <summary>Invalid color match setup data.</summary>

        ColorMatchSetupDataShape                                      =    -1074395386,
        //==========================================================================================
        /// <summary>Rotation-invariant color pattern matching requires a feature mode including shape.</summary>

        ColorRotationRequiresShapeFeature                             =    -1074395385,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor                                       =    -1074395384,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor1                                      =    -1074395383,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor2                                      =    -1074395382,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor3                                      =    -1074395381,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor4                                      =    -1074395380,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor5                                      =    -1074395379,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptor6                                      =    -1074395378,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorShift                                  =    -1074395377,
        //==========================================================================================
        /// <summary>The color template image does not contain data required for shift-invariant color matching.</summary>

        ColorTemplateDescriptorNoshift                                =    -1074395376,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorShift1                                 =    -1074395375,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorShift2                                 =    -1074395374,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation                               =    -1074395373,
        //==========================================================================================
        /// <summary>The color template image does not contain data required for rotation-invariant color matching.</summary>

        ColorTemplateDescriptorNorotation                             =    -1074395372,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation1                              =    -1074395371,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation2                              =    -1074395370,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation3                              =    -1074395369,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation4                              =    -1074395368,
        //==========================================================================================
        /// <summary>Invalid color template image.</summary>

        ColorTemplateDescriptorRotation5                              =    -1074395367,
        //==========================================================================================
        /// <summary>The color template image does not contain data required for color matching in shape feature mode.</summary>

        ColorTemplateDescriptorNoshape                                =    -1074395366,
        //==========================================================================================
        /// <summary>The color template image does not contain data required for color matching in color feature mode.</summary>

        ColorTemplateDescriptorNospectrum                             =    -1074395365,
        //==========================================================================================
        /// <summary>The ignore color spectra array is invalid.</summary>

        IgnoreColorSpectrumSet                                        =    -1074395364,
        //==========================================================================================
        /// <summary>Invalid subsampling ratio.</summary>

        InvalidSubsamplingRatio                                       =    -1074395363,
        //==========================================================================================
        /// <summary>Invalid pixel width.</summary>

        InvalidWidth                                                  =    -1074395362,
        //==========================================================================================
        /// <summary>Invalid steepness.</summary>

        InvalidSteepness                                              =    -1074395361,
        //==========================================================================================
        /// <summary>Invalid complex plane.</summary>

        ComplexPlane                                                  =    -1074395360,
        //==========================================================================================
        /// <summary>Invalid color ignore mode.</summary>

        InvalidColorIgnoreMode                                        =    -1074395357,
        //==========================================================================================
        /// <summary>Invalid minimum match score. Acceptable values range from 0 to 1000.</summary>

        InvalidMinMatchScore                                          =    -1074395356,
        //==========================================================================================
        /// <summary>Invalid number of matches requested. You must request a minimum of one match.</summary>

        InvalidNumMatchesRequested                                    =    -1074395355,
        //==========================================================================================
        /// <summary>Invalid color weight. Acceptable values range from 0 to 1000.</summary>

        InvalidColorWeight                                            =    -1074395354,
        //==========================================================================================
        /// <summary>Invalid search strategy.</summary>

        InvalidSearchStrategy                                         =    -1074395353,
        //==========================================================================================
        /// <summary>Invalid feature mode.</summary>

        InvalidFeatureMode                                            =    -1074395352,
        //==========================================================================================
        /// <summary>NI Vision does not support rectangles with negative widths or negative heights.</summary>

        InvalidRect                                                   =    -1074395351,
        //==========================================================================================
        /// <summary>NI Vision does not support the vision information type you supplied.</summary>

        InvalidVisionInfo                                             =    -1074395350,
        //==========================================================================================
        /// <summary>NI Vision does not support the SkeletonMethod value you supplied.</summary>

        InvalidSkeletonmethod                                         =    -1074395349,
        //==========================================================================================
        /// <summary>NI Vision does not support the 3DPlane value you supplied.</summary>

        Invalid3dplane                                                =    -1074395348,
        //==========================================================================================
        /// <summary>NI Vision does not support the 3DDirection value you supplied.</summary>

        Invalid3ddirection                                            =    -1074395347,
        //==========================================================================================
        /// <summary>imaqRotate does not support the InterpolationMethod value you supplied.</summary>

        InvalidInterpolationmethodForRotate                           =    -1074395346,
        //==========================================================================================
        /// <summary>NI Vision does not support the axis of symmetry you supplied.</summary>

        InvalidFlipaxis                                               =    -1074395345,
        //==========================================================================================
        /// <summary>You must pass a valid file name. Do not pass in NULL.</summary>

        FileFilenameNull                                              =    -1074395343,
        //==========================================================================================
        /// <summary>NI Vision does not support the SizeType value you supplied.</summary>

        InvalidSizetype                                               =    -1074395340,
        //==========================================================================================
        /// <summary>You specified the dispatch status of an unknown algorithm.</summary>

        UnknownAlgorithm                                              =    -1074395336,
        //==========================================================================================
        /// <summary>You are attempting to set the same algorithm to dispatch and to not dispatch. Remove one of the conflicting settings.</summary>

        DispatchStatusConflict                                        =    -1074395335,
        //==========================================================================================
        /// <summary>NI Vision does not support the Conversion Method value you supplied.</summary>

        InvalidConversionstyle                                        =    -1074395334,
        //==========================================================================================
        /// <summary>NI Vision does not support the VerticalTextAlignment value you supplied.</summary>

        InvalidVerticalTextAlignment                                  =    -1074395333,
        //==========================================================================================
        /// <summary>NI Vision does not support the CompareFunction value you supplied.</summary>

        InvalidComparefunction                                        =    -1074395332,
        //==========================================================================================
        /// <summary>NI Vision does not support the BorderMethod value you supplied.</summary>

        InvalidBordermethod                                           =    -1074395331,
        //==========================================================================================
        /// <summary>Invalid border size. Acceptable values range from 0 to 50.</summary>

        InvalidBorderSize                                             =    -1074395330,
        //==========================================================================================
        /// <summary>NI Vision does not support the OutlineMethod value you supplied.</summary>

        InvalidOutlinemethod                                          =    -1074395329,
        //==========================================================================================
        /// <summary>NI Vision does not support the InterpolationMethod value you supplied.</summary>

        InvalidInterpolationmethod                                    =    -1074395328,
        //==========================================================================================
        /// <summary>NI Vision does not support the ScalingMode value you supplied.</summary>

        InvalidScalingmode                                            =    -1074395327,
        //==========================================================================================
        /// <summary>imaqDrawLineOnImage does not support the DrawMode value you supplied.</summary>

        InvalidDrawmodeForLine                                        =    -1074395326,
        //==========================================================================================
        /// <summary>NI Vision does not support the DrawMode value you supplied.</summary>

        InvalidDrawmode                                               =    -1074395325,
        //==========================================================================================
        /// <summary>NI Vision does not support the ShapeMode value you supplied.</summary>

        InvalidShapemode                                              =    -1074395324,
        //==========================================================================================
        /// <summary>NI Vision does not support the FontColor value you supplied.</summary>

        InvalidFontcolor                                              =    -1074395323,
        //==========================================================================================
        /// <summary>NI Vision does not support the TextAlignment value you supplied.</summary>

        InvalidTextalignment                                          =    -1074395322,
        //==========================================================================================
        /// <summary>NI Vision does not support the MorphologyMethod value you supplied.</summary>

        InvalidMorphologymethod                                       =    -1074395321,
        //==========================================================================================
        /// <summary>The template image is empty.</summary>

        TemplateEmpty                                                 =    -1074395320,
        //==========================================================================================
        /// <summary>NI Vision does not support the interpolation type you supplied.</summary>

        InvalidSubpixType                                             =    -1074395319,
        //==========================================================================================
        /// <summary>You supplied an insufficient number of points to perform this operation.</summary>

        InsfPoints                                                    =    -1074395318,
        //==========================================================================================
        /// <summary>You specified a point that lies outside the image.</summary>

        UndefPoint                                                    =    -1074395317,
        //==========================================================================================
        /// <summary>Invalid kernel code.</summary>

        InvalidKernelCode                                             =    -1074395316,
        InefficientPoints                                             =    -1074395315,
        //==========================================================================================
        /// <summary>Writing files is not supported on this device.</summary>

        WriteFileNotSupported                                         =    -1074395313,
        //==========================================================================================
        /// <summary>The input image does not seem to be a valid LCD or LED calibration image.</summary>

        LcdCalibrate                                                  =    -1074395312,
        //==========================================================================================
        /// <summary>The color spectrum array you provided does not contain enough elements or contains an element set to not-a-number (NaN).</summary>

        InvalidColorSpectrum                                          =    -1074395311,
        //==========================================================================================
        /// <summary>NI Vision does not support the PaletteType value you supplied.</summary>

        InvalidPaletteType                                            =    -1074395310,
        //==========================================================================================
        /// <summary>NI Vision does not support the WindowThreadPolicy value you supplied.</summary>

        InvalidWindowThreadPolicy                                     =    -1074395309,
        //==========================================================================================
        /// <summary>NI Vision does not support the ColorSensitivity value you supplied.</summary>

        InvalidColorsensitivity                                       =    -1074395308,
        //==========================================================================================
        /// <summary>The precision parameter must be greater than 0.</summary>

        PrecisionNotGtrThan0                                          =    -1074395307,
        //==========================================================================================
        /// <summary>NI Vision does not support the Tool value you supplied.</summary>

        InvalidTool                                                   =    -1074395306,
        //==========================================================================================
        /// <summary>NI Vision does not support the ReferenceMode value you supplied.</summary>

        InvalidReferencemode                                          =    -1074395305,
        //==========================================================================================
        /// <summary>NI Vision does not support the MathTransformMethod value you supplied.</summary>

        InvalidMathtransformmethod                                    =    -1074395304,
        //==========================================================================================
        /// <summary>Invalid number of classes for auto threshold. Acceptable values range from 2 to 256.</summary>

        InvalidNumOfClasses                                           =    -1074395303,
        //==========================================================================================
        /// <summary>NI Vision does not support the threshold method value you supplied.</summary>

        InvalidThresholdmethod                                        =    -1074395302,
        //==========================================================================================
        /// <summary>The ROI you passed into imaqGetMeterArc must consist of two lines.</summary>

        RoiNot2Lines                                                  =    -1074395301,
        //==========================================================================================
        /// <summary>NI Vision does not support the MeterArcMode value you supplied.</summary>

        InvalidMeterarcmode                                           =    -1074395300,
        //==========================================================================================
        /// <summary>NI Vision does not support the ComplexPlane value you supplied.</summary>

        InvalidComplexplane                                           =    -1074395299,
        //==========================================================================================
        /// <summary>You can perform this operation on a real or an imaginary ComplexPlane only.</summary>

        ComplexplaneNotRealOrImaginary                                =    -1074395298,
        //==========================================================================================
        /// <summary>NI Vision does not support the ParticleInfoMode value you supplied.</summary>

        InvalidParticleinfomode                                       =    -1074395297,
        //==========================================================================================
        /// <summary>NI Vision does not support the BarcodeType value you supplied.</summary>

        InvalidBarcodetype                                            =    -1074395296,
        //==========================================================================================
        /// <summary>imaqInterpolatePoints does not support the InterpolationMethod value you supplied.</summary>

        InvalidInterpolationmethodInterpolatepoints                   =    -1074395295,
        //==========================================================================================
        /// <summary>The contour index you supplied is larger than the number of contours in the ROI.</summary>

        ContourIndexOutOfRange                                        =    -1074395294,
        //==========================================================================================
        /// <summary>The supplied ContourID did not correlate to a contour inside the ROI.</summary>

        ContouridNotFound                                             =    -1074395293,
        //==========================================================================================
        /// <summary>Do not supply collinear points for this operation.</summary>

        PointsAreCollinear                                            =    -1074395292,
        //==========================================================================================
        /// <summary>Shape Match requires the image to contain only pixel values of 0 or 1.</summary>

        ShapematchBadimagedata                                        =    -1074395291,
        //==========================================================================================
        /// <summary>The template you supplied for ShapeMatch contains no shape information.</summary>

        ShapematchBadtemplate                                         =    -1074395290,
        ContainerCapacityExceededUintMax                              =    -1074395289,
        ContainerCapacityExceededIntMax                               =    -1074395288,
        //==========================================================================================
        /// <summary>The line you provided contains two identical points, or one of the coordinate locations for the line is not a number (NaN).</summary>

        InvalidLine                                                   =    -1074395287,
        //==========================================================================================
        /// <summary>Invalid concentric rake direction.</summary>

        InvalidConcentricRakeDirection                                =    -1074395286,
        //==========================================================================================
        /// <summary>Invalid spoke direction.</summary>

        InvalidSpokeDirection                                         =    -1074395285,
        //==========================================================================================
        /// <summary>Invalid edge process.</summary>

        InvalidEdgeProcess                                            =    -1074395284,
        //==========================================================================================
        /// <summary>Invalid rake direction.</summary>

        InvalidRakeDirection                                          =    -1074395283,
        //==========================================================================================
        /// <summary>Unable to draw to viewer. You must have the latest version of the control.</summary>

        CantDrawIntoViewer                                            =    -1074395282,
        //==========================================================================================
        /// <summary>Your image must be larger than its border size for this operation.</summary>

        ImageSmallerThanBorder                                        =    -1074395281,
        //==========================================================================================
        /// <summary>The ROI must only have a single Rectangle contour.</summary>

        RoiNotRect                                                    =    -1074395280,
        //==========================================================================================
        /// <summary>ROI is not a polygon.</summary>

        RoiNotPolygon                                                 =    -1074395279,
        //==========================================================================================
        /// <summary>LCD image is not a number.</summary>

        LcdNotNumeric                                                 =    -1074395278,
        //==========================================================================================
        /// <summary>The decoded barcode information did not pass the checksum test.</summary>

        BarcodeChecksum                                               =    -1074395277,
        //==========================================================================================
        /// <summary>You specified parallel lines for the meter ROI.</summary>

        LinesParallel                                                 =    -1074395276,
        //==========================================================================================
        /// <summary>Invalid browser image.</summary>

        InvalidBrowserImage                                           =    -1074395275,
        //==========================================================================================
        /// <summary>Cannot divide by zero.</summary>

        DivByZero                                                     =    -1074395270,
        //==========================================================================================
        /// <summary>Null pointer.</summary>

        NullPointer                                                   =    -1074395269,
        //==========================================================================================
        /// <summary>The linear equations are not independent.</summary>

        LinearCoeff                                                   =    -1074395268,
        //==========================================================================================
        /// <summary>The roots of the equation are complex.</summary>

        ComplexRoot                                                   =    -1074395267,
        //==========================================================================================
        /// <summary>The barcode does not match the type you specified.</summary>

        Barcode                                                       =    -1074395265,
        //==========================================================================================
        /// <summary>No lit segment.</summary>

        LcdNoSegments                                                 =    -1074395263,
        //==========================================================================================
        /// <summary>The LCD does not form a known digit.</summary>

        LcdBadMatch                                                   =    -1074395262,
        //==========================================================================================
        /// <summary>An internal error occurred while attempting to access an invalid coordinate on an image.</summary>

        GipRange                                                      =    -1074395261,
        //==========================================================================================
        /// <summary>An internal memory error occurred.</summary>

        HeapTrashed                                                   =    -1074395260,
        //==========================================================================================
        /// <summary>The filter width must be odd for the Canny operator.</summary>

        BadFilterWidth                                                =    -1074395258,
        //==========================================================================================
        /// <summary>You supplied an invalid edge direction in the Canny operator.</summary>

        InvalidEdgeDir                                                =    -1074395257,
        //==========================================================================================
        /// <summary>The window size must be odd for the Canny operator.</summary>

        EvenWindowSize                                                =    -1074395256,
        //==========================================================================================
        /// <summary>Invalid learn mode.</summary>

        InvalidLearnMode                                              =    -1074395253,
        //==========================================================================================
        /// <summary>Invalid learn setup data.</summary>

        LearnSetupData                                                =    -1074395252,
        //==========================================================================================
        /// <summary>Invalid match mode.</summary>

        InvalidMatchMode                                              =    -1074395251,
        //==========================================================================================
        /// <summary>Invalid match setup data.</summary>

        MatchSetupData                                                =    -1074395250,
        //==========================================================================================
        /// <summary>At least one range in the array of rotation angle ranges exceeds 360 degrees.</summary>

        RotationAngleRangeTooLarge                                    =    -1074395249,
        //==========================================================================================
        /// <summary>The array of rotation angle ranges contains too many ranges.</summary>

        TooManyRotationAngleRanges                                    =    -1074395248,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptor                                            =    -1074395247,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptor1                                           =    -1074395246,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptor2                                           =    -1074395245,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptor3                                           =    -1074395244,
        //==========================================================================================
        /// <summary>The template descriptor was created with a newer version of NI Vision. Upgrade to the latest version of NI Vision to use this template.</summary>

        TemplateDescriptor4                                           =    -1074395243,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptorRotation                                    =    -1074395242,
        //==========================================================================================
        /// <summary>The template descriptor does not contain data required for rotation-invariant matching.</summary>

        TemplateDescriptorNorotation                                  =    -1074395241,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptorRotation1                                   =    -1074395240,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptorShift                                       =    -1074395239,
        //==========================================================================================
        /// <summary>The template descriptor does not contain data required for shift-invariant matching.</summary>

        TemplateDescriptorNoshift                                     =    -1074395238,
        //==========================================================================================
        /// <summary>Invalid template descriptor.</summary>

        TemplateDescriptorShift1                                      =    -1074395237,
        TemplateDescriptorNoscale                                     =    -1074395236,
        //==========================================================================================
        /// <summary>The template image does not contain enough contrast.</summary>

        TemplateImageContrastTooLow                                   =    -1074395235,
        //==========================================================================================
        /// <summary>The template image is too small.</summary>

        TemplateImageTooSmall                                         =    -1074395234,
        //==========================================================================================
        /// <summary>The template image is too large.</summary>

        TemplateImageTooLarge                                         =    -1074395233,
        TooManyOcrSessions                                            =    -1074395214,
        //==========================================================================================
        /// <summary>The size of the template string must match the size of the string you are trying to correct.</summary>

        OcrTemplateWrongSize                                          =    -1074395212,
        //==========================================================================================
        /// <summary>The supplied text template contains nonstandard characters that cannot be generated by OCR.</summary>

        OcrBadTextTemplate                                            =    -1074395211,
        //==========================================================================================
        /// <summary>At least one character in the text template was of a lexical class that did not match the supplied character reports.</summary>

        OcrCannotMatchTextTemplate                                    =    -1074395210,
        EccCodeNotSupported                                           =    -1074395208,
        InvalidGradingReflectanceParameter                            =    -1074395207,
		//==========================================================================================
        /// <summary>The OCR library cannot be initialized correctly.</summary>

        OcrLibInit                                                    =    -1074395203,
        //==========================================================================================
        /// <summary>There was a failure when loading one of the internal OCR engine or LabView libraries.</summary>

        OcrLoadLibrary                                                =    -1074395201,
        //==========================================================================================
        /// <summary>One of the parameters supplied to the OCR function that generated this error is invalid.</summary>

        OcrInvalidParameter                                           =    -1074395200,
        MarkerInformationNotSupplied                                  =    -1074395199,
        IncompatibleMarkerImageSize                                   =    -1074395198,
        BothMarkerInputsSupplied                                      =    -1074395197,
        InvalidMorphologicalOperation                                 =    -1074395196,
        ImageContainsNanValues                                        =    -1074395195,
        OverlayExtrainfoOpeningNewVersion                             =    -1074395194,
        NoClampFound                                                  =    -1074395193,
        NoClampWithinAngleRange                                       =    -1074395192,
        GhtInvalidUseAllCurvesValue                                   =    -1074395188,
        InvalidGaussSigmaValue                                        =    -1074395187,
        InvalidGaussFilterType                                        =    -1074395186,
        InvalidContrastReversalMode                                   =    -1074395185,
        InvalidRotationRange                                          =    -1074395184,
        GhtInvalidMinimumLearnAngleValue                              =    -1074395183,
        GhtInvalidMaximumLearnAngleValue                              =    -1074395182,
        GhtInvalidMaximumLearnScaleFactor                             =    -1074395181,
        GhtInvalidMinimumLearnScaleFactor                             =    -1074395180,
        //==========================================================================================
        /// <summary>The OCR engine failed during the preprocessing stage.</summary>

        OcrPreprocessingFailed                                        =    -1074395179,
        //==========================================================================================
        /// <summary>The OCR engine failed during the recognition stage.</summary>

        OcrRecognitionFailed                                          =    -1074395178,
        //==========================================================================================
        /// <summary>The provided filename is not valid user dictionary filename.</summary>

        OcrBadUserDictionary                                          =    -1074395175,
        //==========================================================================================
        /// <summary>NI Vision does not support the AutoOrientMode value you supplied.</summary>

        OcrInvalidAutoorientmode                                      =    -1074395174,
        //==========================================================================================
        /// <summary>NI Vision does not support the Language value you supplied.</summary>

        OcrInvalidLanguage                                            =    -1074395173,
        //==========================================================================================
        /// <summary>NI Vision does not support the CharacterSet value you supplied.</summary>

        OcrInvalidCharacterset                                        =    -1074395172,
        //==========================================================================================
        /// <summary>The system could not locate the initialization file required for OCR initialization.</summary>

        OcrIniFileNotFound                                            =    -1074395171,
        //==========================================================================================
        /// <summary>NI Vision does not support the CharacterType value you supplied.</summary>

        OcrInvalidCharactertype                                       =    -1074395170,
        //==========================================================================================
        /// <summary>NI Vision does not support the RecognitionMode value you supplied.</summary>

        OcrInvalidRecognitionmode                                     =    -1074395169,
        //==========================================================================================
        /// <summary>NI Vision does not support the AutoCorrectionMode value you supplied.</summary>

        OcrInvalidAutocorrectionmode                                  =    -1074395168,
        //==========================================================================================
        /// <summary>NI Vision does not support the OutputDelimiter value you supplied.</summary>

        OcrInvalidOutputdelimiter                                     =    -1074395167,
        //==========================================================================================
        /// <summary>The system could not locate the OCR binary directory required for OCR initialization.</summary>

        OcrBinDirNotFound                                             =    -1074395166,
        //==========================================================================================
        /// <summary>The system could not locate the OCR weights directory required for OCR initialization.</summary>

        OcrWtsDirNotFound                                             =    -1074395165,
        //==========================================================================================
        /// <summary>The supplied word could not be added to the user dictionary.</summary>

        OcrAddWordFailed                                              =    -1074395164,
        //==========================================================================================
        /// <summary>NI Vision does not support the CharacterPreference value you supplied.</summary>

        OcrInvalidCharacterpreference                                 =    -1074395163,
        //==========================================================================================
        /// <summary>NI Vision does not support the CorrectionMethod value you supplied.</summary>

        OcrInvalidCorrectionmode                                      =    -1074395162,
        //==========================================================================================
        /// <summary>NI Vision does not support the CorrectionLevel value you supplied.</summary>

        OcrInvalidCorrectionlevel                                     =    -1074395161,
        //==========================================================================================
        /// <summary>NI Vision does not support the maximum point size you supplied. Valid values range from 4 to 72.</summary>

        OcrInvalidMaxpointsize                                        =    -1074395160,
        //==========================================================================================
        /// <summary>NI Vision does not support the tolerance value you supplied. Valid values are non-negative.</summary>

        OcrInvalidTolerance                                           =    -1074395159,
        //==========================================================================================
        /// <summary>NI Vision does not support the ContrastMode value you supplied.</summary>

        OcrInvalidContrastmode                                        =    -1074395158,
        //==========================================================================================
        /// <summary>The OCR attempted to detected the text skew and failed.</summary>

        OcrSkewDetectFailed                                           =    -1074395156,
        //==========================================================================================
        /// <summary>The OCR attempted to detected the text orientation and failed.</summary>

        OcrOrientDetectFailed                                         =    -1074395155,
        //==========================================================================================
        /// <summary>Invalid font file format.</summary>

        FontFileFormat                                                =    -1074395153,
        //==========================================================================================
        /// <summary>Font file not found.</summary>

        FontFileNotFound                                              =    -1074395152,
        //==========================================================================================
        /// <summary>The OCR engine failed during the correction stage.</summary>

        OcrCorrectionFailed                                           =    -1074395151,
        //==========================================================================================
        /// <summary>NI Vision does not support the RoundingMode value you supplied.</summary>

        InvalidRoundingMode                                           =    -1074395150,
        //==========================================================================================
        /// <summary>Found a duplicate transform type in the properties array. Each properties array may only contain one behavior for each transform type.</summary>

        DuplicateTransformType                                        =    -1074395149,
        //==========================================================================================
        /// <summary>Overlay Group Not Found.</summary>

        OverlayGroupNotFound                                          =    -1074395148,
        //==========================================================================================
        /// <summary>The barcode is not a valid RSS Limited symbol</summary>

        BarcodeRsslimited                                             =    -1074395147,
        //==========================================================================================
        /// <summary>Couldn't determine the correct version of the QR code.</summary>

        QrDetectionVersion                                            =    -1074395146,
        //==========================================================================================
        /// <summary>Invalid read of the QR code.</summary>

        QrInvalidRead                                                 =    -1074395145,
        //==========================================================================================
        /// <summary>The barcode that was read contains invalid parameters.</summary>

        QrInvalidBarcode                                              =    -1074395144,
        //==========================================================================================
        /// <summary>The data stream that was demodulated could not be read because the mode was not detected.</summary>

        QrDetectionMode                                               =    -1074395143,
        //==========================================================================================
        /// <summary>Couldn't determine the correct model of the QR code.</summary>

        QrDetectionModeltype                                          =    -1074395142,
        //==========================================================================================
        /// <summary>The OCR engine could not find any text in the supplied region.</summary>

        OcrNoTextFound                                                =    -1074395141,
        //==========================================================================================
        /// <summary>One of the character reports is no longer usable by the system.</summary>

        OcrCharReportCorrupted                                        =    -1074395140,
        //==========================================================================================
        /// <summary>Invalid Dimensions.</summary>

        ImaqQrDimensionInvalid                                        =    -1074395139,
        //==========================================================================================
        /// <summary>The OCR region provided was too small to have contained any characters.</summary>

        OcrRegionTooSmall                                             =    -1074395138,
        InvalidCalibrationMethod                                      =    -1074395662,
        InvalidOperationOnCompactCalibrationAttempted                 =    -1074395661,
        InvalidPolynomialModelKCount                                  =    -1074395660,
        InvalidDistortionModel                                        =    -1074395659,
        CameraModelNotAvailable                                       =    -1074395658,
        InvalidThumbnailIndex                                         =    -1074395657,
        BayerInvalidAlgorithm                                         =    -1074395135,
        BayerInvalidPattern                                           =    -1074395134,
        BayerInvalidRedGain                                           =    -1074395133,
        BayerInvalidGreenGain                                         =    -1074395132,
        BayerInvalidBlueGain                                          =    -1074395131,
    }
}
