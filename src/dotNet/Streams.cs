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
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using NationalInstruments.Vision.Analysis.Internal;
using NationalInstruments.Vision.Internal;
using System.Diagnostics;

namespace NationalInstruments.Vision.Analysis
{
    //==============================================================================================
    /// <summary>
    /// Provides information about a trained character.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CharacterInfo
    {
        private int _index = -1;
        private IntPtr _character = IntPtr.Zero;
        private bool _isUpToDate = false;
        private OcrSession _owner = null;

internal CharacterInfo(OcrSession owner, int index)
        {
            _owner = owner;
            _index = index;
        }

internal void Invalidate()
        {
            _isUpToDate = false;
        }

        
        internal void UpdateData()
        {
            _owner.ThrowIfDisposed();
            if (!_isUpToDate)
            {
                _character = VisionDll.niocrGetCharacterAtIndex(_owner._session, _index);
                Utilities.ThrowError(_character);
                _isUpToDate = true;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets or sets whether the character is the reference character for the character class. 
        /// </summary>
        /// <value>
        /// This property is true if the character is the reference character for the character class.
        /// </value>

        public bool IsReferenceCharacter
        {
            get {
                UpdateData();
                Int32 toReturn;
                Utilities.ThrowError(VisionDll.niocrIsReferenceChar(_owner._session, _character, out toReturn));
                return (toReturn != 0);
            }
            set
            {
                UpdateData();
                Utilities.ThrowError(VisionDll.niocrSetReferenceChar(_owner._session, _character, value ? 1 : 0));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the character value of the corresponding character in the character set. 
        /// </summary>
        /// <value>
        /// Set this property to change the character value.
        /// </value>
        /// <remarks>
        /// Retrieves the character value of the corresponding character in the character set. Set this property to change the character value.
        /// </remarks>

        public unsafe string CharacterValue
        {
            get { 
                UpdateData();
                byte[] toReturnArray = new byte[256];
                Utilities.ThrowError(VisionDll.niocrGetCharacterValue(_owner._session, _character, toReturnArray));
                return Utilities.ConvertBytesToString(toReturnArray);
            }
            set
            {
                UpdateData();
                Utilities.ThrowError(VisionDll.niocrRenameCharacter(_owner._session, _character, value));
            }
        }
        //==========================================================================================
        /// <summary>
        /// Retrieves the internal representation that NI Vision uses to match objects to this character. 
        /// </summary>
        /// <param name="destination">The resulting image.
        /// </param>

        public void GetInternalImage(VisionImage destination)
        {
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            UpdateData();
            Utilities.ThrowError(VisionDll.dotNET_GetInternalImage(_owner._session, _character, destination._image));
        }
        //==========================================================================================
        /// <summary>
        /// Retrieves the image used to train this character.
        /// </summary>
        /// <param name="destination">The resulting image.
        /// </param>

        public void GetCharacterImage(VisionImage destination)
        {
            if (destination == null) { throw new ArgumentNullException("destination"); }
            destination.ThrowIfDisposed();
            UpdateData();
            Utilities.ThrowError(VisionDll.dotNET_GetCharacterImage(_owner._session, _character, destination._image));
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
            return "CharacterInfo: Index=" + _index;
        }
    }

    //==============================================================================================
    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CharacterInfoCollection : ReadOnlyCollection<CharacterInfo>
    {
        private OcrSession _owner;

        
        internal CharacterInfoCollection(Collection<CharacterInfo> collection, OcrSession owner) : base(collection)
        {
            _owner = owner;
        }

        //==========================================================================================
        /// <summary>
        /// Removes the CharacterInfo at the index entry from this CharacterInfoCollection.
        /// </summary>
        /// <param name="index">
        /// </param>

        public void RemoveAt(int index)
        {
            _owner.ThrowIfDisposed();
            Utilities.ThrowError(VisionDll.imaqDeleteChar(_owner._session, index));
            Items.RemoveAt(index);
            _owner.InvalidateCharacters();
        }

        //==========================================================================================
        /// <summary>
        /// Removes all CharacterInfo objects from this CharacterInfoCollection.
        /// </summary>

        public void Clear()
        {
            _owner.ThrowIfDisposed();
            // Clear the underlying session and our CharacterInfo's
            while (Items.Count > 0)
            {
                Utilities.ThrowError(VisionDll.imaqDeleteChar(_owner._session, Items.Count - 1));
                Items.RemoveAt(Items.Count - 1);
            }
            _owner.InvalidateCharacters();
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
            return base.ToString();
        }
    }

    //==============================================================================================
    /// <summary>
    /// The OCR session on which the method operates.
    /// </summary>

    public sealed class OcrSession : IDisposable
    {
        internal IntPtr _session = IntPtr.Zero;
        private OcrReadTextOptions _readTextOptions;
        private OcrProcessingOptions _processingOptions;
        private OcrSpacingOptions _spacingOptions;
        private Collection<CharacterInfo> _characterInfo;
        private CharacterInfoCollection _characterInfoCollection;
        private string _description;
        private object _disposeLock = new object();
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the OcrSession class.
        /// </summary>

        public OcrSession()
        {
            _session = VisionDll.imaqCreateCharSet();
            Utilities.ThrowError(_session);
            _readTextOptions = new OcrReadTextOptions(this);
            _processingOptions = new OcrProcessingOptions(_session);
            _spacingOptions = new OcrSpacingOptions(_session);
            _characterInfo = new Collection<CharacterInfo>();
            _characterInfoCollection = new CharacterInfoCollection(_characterInfo, this);
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the OcrSession class.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>

        public OcrSession(string fileName) : this()
        {
            ReadFile(fileName);
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the OcrSession class.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>
        /// <param name="mode">
        /// Specifies what OCR information to read. The default is All, which specifies 
        /// both the character set data and the session properties are read from file. 
        /// </param>

        public OcrSession(string fileName, OcrReadMode mode) : this()
        {
            ReadFile(fileName, mode);
        }

        //==========================================================================================
        /// <summary>
        /// Gets information about the trained character set. 
        /// </summary>

        public CharacterInfoCollection CharacterInfo
        {
            get { ThrowIfDisposed();  return _characterInfoCollection; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the configuration settings used during the reading process.
        /// </summary>

        public OcrReadTextOptions ReadTextOptions
        {
            get { ThrowIfDisposed();  return _readTextOptions; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the spacing settings for the characters in the image.
        /// </summary>

        public OcrSpacingOptions SpacingOptions
        {
            get { ThrowIfDisposed();  return _spacingOptions; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets how images are processed before training or reading characters.
        /// </summary>

        public OcrProcessingOptions ProcessingOptions
        {
            get { ThrowIfDisposed();  return _processingOptions; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets a description of the OcrSession. 
        /// </summary>

        public string Description
        {
            get { ThrowIfDisposed(); return _description; }
            set { ThrowIfDisposed(); _description = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Reads a character set from the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>

        public void ReadFile(string fileName)
        {
            ReadFile(fileName, OcrReadMode.All);
        }
        //==========================================================================================
        /// <summary>
        /// Reads a character set from the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>
        /// <param name="mode">
        /// Specifies what OCR information to read. The default is All, which specifies 
        /// both the character set data and the session properties are read from file. 
        /// </param>

        public void ReadFile(string fileName, OcrReadMode mode)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }

            byte[] cviDescription = new byte[256];
            Utilities.ThrowError(VisionDll.niocrReadFile(_session, fileName, (Int32)mode, 1, cviDescription));
            InvalidateCharacters();
            ReadTextOptions.ValidCharacters.InvalidateAll();
            _description = Utilities.ConvertBytesToString(cviDescription);
        }
        /// <summary>
        /// Reads a character set from the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>

        public void ReadFile2(string fileName)
        {
            ReadFile2(fileName, OcrReadMode.All);
        }
        //==========================================================================================
        /// <summary>
        /// Reads a character set from the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the OCR file to read.
        /// </param>
        /// <param name="mode">
        /// Specifies what OCR information to read. The default is All, which specifies 
        /// both the character set data and the session properties are read from file. 
        /// </param>

        public void ReadFile2(string fileName, OcrReadMode mode)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            byte[] cviDescription = new byte[256];
            Utilities.ThrowError(VisionDll.niocrReadFile2(_session, fileName, (Int32)mode, 1, cviDescription));
            InvalidateCharacters();
            ReadTextOptions.ValidCharacters.InvalidateAll();
            _description = Utilities.ConvertBytesToString(cviDescription);
        }
        //==========================================================================================
        /// <summary>
        /// Stores the trained character set in the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>

        public void WriteFile(string fileName)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            Utilities.ThrowError(VisionDll.niocrWriteFile(_session, fileName, _description));
        }
        //==========================================================================================
        /// <summary>
        /// Stores the trained character set in the file specified by fileName.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>

        public void WriteFile2(string fileName)
        {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            Utilities.ThrowError(VisionDll.niocrWriteFile2(_session, fileName, _description));
        }
        //==========================================================================================
        /// <summary>
        /// Reads the text from the image. 
        /// </summary>
        /// <param name="image">
        /// The image to read the text from.
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ReadTextReport" crefType="Unqualified"/>
        /// object containing information about the text read.
        /// </returns>

        public ReadTextReport ReadText(VisionImage image)
        {
            return ReadText(image, null);
        }
        //==========================================================================================
        /// <summary>
        /// Reads the text from the image. 
        /// </summary>
        /// <param name="image">
        /// The image to read the text from.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the image to read text from.
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ReadTextReport" crefType="Unqualified"/>
        /// object containing information about the text read.
        /// </returns>

        public ReadTextReport ReadText(VisionImage image, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            IntPtr reportPtr = VisionDll.dotNET_ReadText(image._image, _session, cviRoi);
            Utilities.ThrowError(reportPtr);
            ReadTextReport report = Utilities.ConvertIntPtrToStructure<ReadTextReport, CVI_ReadTextReport3>(reportPtr, true);
            return report;
        }

        public ReadTextReport2 ReadText2(VisionImage image)
        {
            return ReadText2(image, 0);
        }

        public ReadTextReport2 ReadText2(VisionImage image, Int32 numberOfLinesRequested)
        {
            return ReadText2(image, numberOfLinesRequested, null);
        }

        public ReadTextReport2 ReadText2(VisionImage image, Int32 numberOfLinesRequested, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            IntPtr reportPtr = VisionDll.dotNET_ReadText2(image._image, numberOfLinesRequested, _session, cviRoi);
            Utilities.ThrowError(reportPtr);
            ReadTextReport2 report = Utilities.ConvertIntPtrToStructure<ReadTextReport2, CVI_ReadTextReport4>(reportPtr, true);
            return report;
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>

        public void Train(VisionImage source, string characterValue)
        {
            Train(source, characterValue, -1, null);
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>
        /// <param name="index">
        /// The index of the object that you want to train in the set of objects that are identified.
        /// </param>

        public void Train(VisionImage source, string characterValue, int index)
        {
            Train(source, characterValue, index, null);
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>
        /// <param name="index">
        /// The index of the object that you want to train in the set of objects that are identified.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the image to read text from.
        /// </param>

        public void Train(VisionImage source, string characterValue, int index, Roi roi)
        {
            ThrowIfDisposed();
            if (source == null) { throw new ArgumentNullException("source"); }
            source.ThrowIfDisposed();
            if (characterValue == null) { throw new ArgumentNullException("characterValue"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            Utilities.ThrowError(VisionDll.dotNET_Train(_session, source._image, characterValue, index, cviRoi));
            InvalidateCharacters();
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>

        public void Train2(VisionImage source, string characterValue)
        {
            Train2(source, characterValue, -1, null);
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>
        /// <param name="index">
        /// The index of the object that you want to train in the set of objects that are identified.
        /// </param>

        public void Train2(VisionImage source, string characterValue, int index)
        {
            Train2(source, characterValue, index, null);
        }
        //==========================================================================================
        /// <summary>
        /// Assigns character values to the objects identified in the image. The newly trained characters are appended to the existing trained character set. An image can contain no more than 255 objects.
        /// </summary>
        /// <param name="source">
        /// The image containing the objects to be identified.
        /// </param>
        /// <param name="characterValue">
        /// The value to assign to objects identified in the image.
        /// </param>
        /// <param name="index">
        /// The index of the object that you want to train in the set of objects that are identified.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the image to read text from.
        /// </param>

        public void Train2(VisionImage source, string characterValue, int index, Roi roi)
        {
            ThrowIfDisposed();
            if (source == null) { throw new ArgumentNullException("source"); }
            source.ThrowIfDisposed();
            if (characterValue == null) { throw new ArgumentNullException("characterValue"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            Utilities.ThrowError(VisionDll.dotNET_Train2(_session, source._image, characterValue, index, cviRoi));
            InvalidateCharacters();
        }
        //==========================================================================================
        /// <summary>
        /// Verifies the accuracy of the text in the image. For each character, 
        /// the method checks for the existence of a reference character for 
        /// the expected character class and compares the character from the 
        /// image to the reference character. 
        /// </summary>
        /// <param name="image">
        /// The source image for this operation.
        /// </param>
        /// <param name="expectedText">
        /// The expected character values in the image.
        /// </param>
        /// <returns>
        /// A collection of verification scores for the patterns in the image. If a reference 
        /// character does not exist for the character class of a character, the method sets 
        /// the score corresponding to that character to 0.
        /// </returns>

        public Collection<Int32> VerifyText(VisionImage image, string expectedText)
        {
            return VerifyText(image, expectedText, null);
        }
        //==========================================================================================
        /// <summary>
        /// Verifies the accuracy of the text in the image. For each character, 
        /// the method checks for the existence of a reference character for 
        /// the expected character class and compares the character from the 
        /// image to the reference character. 
        /// </summary>
        /// <param name="image">
        /// The source image for this operation.
        /// </param>
        /// <param name="expectedText">
        /// The expected character values in the image.
        /// </param>
        /// <param name="roi">
        /// The ROI that the method performs this operation on. Pass null or Nothing to use 
        /// the entire image for this operation. If the ROI has multiple contours, each contour 
        /// is interpreted as a character in the image. If the ROI only has one contour, 
        /// the method searches the ROI for text. 
        /// </param>
        /// <returns>
        /// A collection of verification scores for the patterns in the image. If a reference 
        /// character does not exist for the character class of a character, the method sets 
        /// the score corresponding to that character to 0.
        /// </returns>

        public Collection<Int32> VerifyText(VisionImage image, string expectedText, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (expectedText == null) { throw new ArgumentNullException("expectedText"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            UInt32 numScores;
            IntPtr result = VisionDll.dotNET_VerifyText(_session, image._image, expectedText, IntPtr.Zero, out numScores, cviRoi);
            Utilities.ThrowError(result);
            return Utilities.ConvertIntPtrToCollection<Int32>(result, numScores, true);
        }
        //==========================================================================================
        /// <summary>
        /// Verifies the accuracy of the text in the image. For each pattern, 
        /// the method checks for the existence of a reference character for 
        /// the expected character class and compares the character from the 
        /// image to the reference character. 
        /// </summary>
        /// <param name="image">
        /// The source image for this operation.
        /// </param>
        /// <param name="expectedPatterns">
        /// The array of expected patterns in the image.
        /// </param>
        /// <returns>
        /// A collection of verification scores for the patterns in the image. If a reference 
        /// character does not exist for the character class of a character, the method sets 
        /// the score corresponding to that character to 0.
        /// </returns>

        public Collection<Int32> VerifyPatterns(VisionImage image, string[] expectedPatterns)
        {
            return VerifyPatterns(image, expectedPatterns, null);
        }
        //==========================================================================================
        /// <summary>
        /// Verifies the accuracy of the text in the image. For each pattern, 
        /// the method checks for the existence of a reference character for 
        /// the expected character class and compares the character from the 
        /// image to the reference character. 
        /// </summary>
        /// <param name="image">
        /// The source image for this operation.
        /// </param>
        /// <param name="expectedPatterns">
        /// The array of expected patterns in the image.
        /// </param>
        /// <param name="roi">
        /// The ROI that the method performs this operation on. Pass null or Nothing to use 
        /// the entire image for this operation. If the ROI has multiple contours, each contour 
        /// is interpreted as a pattern location in the image. If the ROI only has one contour, 
        /// the method searches the ROI for the expected patterns. 
        /// </param>
        /// <returns>
        /// A collection of verification scores for the patterns in the image. If a reference 
        /// character does not exist for the character class of a character, the method sets 
        /// the score corresponding to that character to 0.
        /// </returns>

        public Collection<Int32> VerifyPatterns(VisionImage image, string[] expectedPatterns, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (expectedPatterns == null) { throw new ArgumentNullException("expectedPatterns"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            UInt32 numScores;
            IntPtr stringCache = VisionDll.niocrCreateStringCache(expectedPatterns.Length);
            for (int i = 0; i < expectedPatterns.Length; ++i)
            {
                VisionDll.niocrAddStringToCache(stringCache, expectedPatterns[i], i);
            }
            try
            {
                IntPtr result = VisionDll.dotNET_VerifyText(_session, image._image, "", stringCache, out numScores, cviRoi);
                Utilities.ThrowError(result);
                return Utilities.ConvertIntPtrToCollection<Int32>(result, numScores, true);
            }
            finally
            {
                VisionDll.niocrDisposeStringCache(stringCache);
            }
        }

internal void ThrowIfDisposed()
        {
            if (_session == IntPtr.Zero)
            {
                throw new ObjectDisposedException("NationalInstruments.Vision.OcrSession");
            }
        }

        
        internal void InvalidateCharacters()
        {
            // Update the character info count.
            int characterCount = VisionDll.imaqGetCharCount(_session);
            while (_characterInfo.Count < characterCount)
            {
                _characterInfo.Add(new CharacterInfo(this, _characterInfo.Count));
            }
            while (_characterInfo.Count > characterCount)
            {
                _characterInfo.RemoveAt(_characterInfo.Count - 1);
            }
            foreach (CharacterInfo info in _characterInfo)
            {
                info.Invalidate();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified OcrSession.
        /// </summary>
        /// <param name="other">
        /// A OcrSession instance to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the <paramref name="other"/> parameter equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public bool Equals(OcrSession other)
        {
            return other != null && _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified OcrSession.
        /// </summary>
        /// <param name="obj">
        /// An object to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is an instance of OcrSession
        ///  and equals the value of this instance; otherwise, <see langword="false"/>.</returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            OcrSession other = (OcrSession)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for the object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code. 
        /// </returns>

        public override int GetHashCode()
        {
            return _session.GetHashCode();
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
            return "OcrSession: Characters=" + _characterInfoCollection.Count;
        }
        //==========================================================================================
        /// <summary>
        /// Releases all resources used by the OcrSession. 
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        private void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // _session is safe to use since it's unmanaged.
                if (_session != IntPtr.Zero)
                {
                    VisionDll.imaqDispose(_session);
                    _session = IntPtr.Zero;
                }
            }
        }

        
        ~OcrSession()
        {
            Dispose(false);
        }
    }

    //==============================================================================================
    /// <summary>
    /// Assigns images or feature vectors to classes based on how the classifier has been trained.
    /// </summary>

    public abstract class ClassifierSession : IDisposable
    {
        internal IntPtr _session = IntPtr.Zero;
        internal ClassifierType _type;
        internal ClassifierEngineType _engineType = ClassifierEngineType.None;
        internal ReadOnlyNearestNeighborOptions _nearestNeighborOptions;
        private string _description;
        private object _disposeLock = new object();

internal ClassifierSession()
        {
            _nearestNeighborOptions = new ReadOnlyNearestNeighborOptions(this);
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets a description of images or feature vectors for ClassifierSession.
        /// </summary>
        /// <value>
        /// </value>

        public string Description
        {
            get { ThrowIfDisposed(); return _description; }
            set { ThrowIfDisposed(); _description = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the type of the classifier.
        /// </summary>
        /// <value>
        /// </value>

        public ClassifierType Type
        {
            get { ThrowIfDisposed();  return _type; }
            internal set { _type = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets or sets the type of engine this classifier has been trained with.
        /// </summary>
        /// <value>
        /// You can use the following constants with this data type:
        /// <list type="bullet">
        /// 		<item>
        /// 			<description>
        /// EngineNearestNeighbor—This classifier has been trained with the Nearest Neighbor engine.
        /// </description>
        /// 		</item>
        /// 		<item>
        /// 			<description>
        /// EngineNone—This classifier has not been trained yet, and so has no engine.
        /// </description>
        /// 		</item>
        /// 	</list>
        /// </value>

        public ClassifierEngineType EngineType
        {
            get { ThrowIfDisposed();  return _engineType; }
            internal set { _engineType = value; }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the options the engine uses for classification.
        /// </summary>
        /// <value>
        /// </value>

        public ReadOnlyNearestNeighborOptions NearestNeighborOptions
        {
            get { ThrowIfDisposed();  return _nearestNeighborOptions; }
        }
        //==========================================================================================
        /// <summary>
        /// Creates an instance of a ClassifierSession object from a specified classifier session file.
        /// </summary>
        /// <param name="fileName">
        /// The name of the specified classifier session file.
        /// </param>
        /// <returns>A ClassifierSession containing the data in the classifier session file.
        /// </returns>

        public static ClassifierSession CreateFromFile(string fileName)
        {
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            ClassifierType type;
            ClassifierEngineType engineType;
            CVI_String255 cviDescription = new CVI_String255();
            IntPtr newSession = VisionDll.imaqReadClassifierFile(IntPtr.Zero, fileName, ReadClassifierFileMode.All, out type, out engineType, ref cviDescription);
            Utilities.ThrowError(newSession);
            ClassifierSession session;
            switch (type)
            {
                case ClassifierType.Particle:
                    session = new ParticleClassifierSession(newSession);
                    break;
                case ClassifierType.Custom:
                    session = new CustomClassifierSession(newSession);
                    break;
                case ClassifierType.Color:
                    session = new ColorClassifierSession(newSession);
                    break;
                case ClassifierType.TextureDefect:
                    session = new TextureDefectClassifierSession(newSession);
                    break;
                default:
                    Debug.Fail("Unknown classifer type " + type + " from imaqReadClassifierFile!");
                    return null;
            }
            session._engineType = engineType;
            session.OnReadFile();
            session._description = cviDescription.ConvertToExternal();
            return session;
        }
        //==========================================================================================
        /// <summary>
        /// Reads classifier information from a file.
        /// </summary>
        /// <param name="fileName">The file to read from.
        /// </param>

        public void ReadFile(string fileName)
        {
            ReadFile(fileName, ReadClassifierFileMode.All);
        }
        //==========================================================================================
        /// <summary>
        /// Reads classifier information from a file.
        /// </summary>
        /// <param name="fileName">The file to read from.
        /// </param>
        /// <param name="mode">The mode to read the file in.  You can read the whole file, just the samples, or just the properties.</param>

        public void ReadFile(string fileName, ReadClassifierFileMode mode) {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            ClassifierType type;
            ClassifierEngineType engineType;
            CVI_String255 cviDescription = new CVI_String255();
            Utilities.ThrowError(VisionDll.imaqReadClassifierFile(_session, fileName, mode, out type, out engineType, ref cviDescription));
            _description = cviDescription.ConvertToExternal();
            if (mode == ReadClassifierFileMode.All)
            {
                _engineType = engineType;
            }
            if (mode == ReadClassifierFileMode.All || mode == ReadClassifierFileMode.Samples)
            {
                _type = type;
            }
            OnReadFile();
        }

        
        internal virtual void OnReadFile() {
            InvalidateSamples();
            if (_engineType != ClassifierEngineType.SupportVectorMachine)
            {
                _nearestNeighborOptions.UpdateData();
            }
        }
        //==========================================================================================
        /// <summary>
        /// Writes this session to a file.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>

        public void WriteFile(string fileName) {
            WriteFile(fileName, WriteClassifierFileMode.All);
        }

        //==========================================================================================
        /// <summary>
        /// Writes this session to a file.
        /// </summary>
        /// <param name="fileName">
        /// The name of the file.
        /// </param>
        /// <param name="mode">The mode to write the file in.  You can write the whole file or a compact version of the file that can only train after being read.
        /// </param>

        public void WriteFile(string fileName, WriteClassifierFileMode mode) {
            ThrowIfDisposed();
            if (fileName == null) { throw new ArgumentNullException("fileName"); }
            if (_description == null)
            {
                // Just write an empty description
                _description = "";
            }
            CVI_String255 cviDescription = new CVI_String255();
            cviDescription.ConvertFromExternal(_description);
            Utilities.ThrowError(VisionDll.imaqWriteClassifierFile(_session, fileName, mode, ref cviDescription));
        }

        //==========================================================================================
        /// <summary>
        /// Reports on the accuracy and predictive value of the classifier.
        /// </summary>
        /// <returns>A ClassifierAccuracyReport containing information about the accuracy and predictive value of the classifier.</returns>
        /// <remarks>
        /// The classifier must be trained for this method to work.
        /// </remarks>

        public ClassifierAccuracyReport GetAccuracy()
        {
            ThrowIfDisposed();
            IntPtr result = VisionDll.imaqGetClassifierAccuracy(_session);
            Utilities.ThrowError(result);
            return Utilities.ConvertIntPtrToStructure<ClassifierAccuracyReport, CVI_ClassifierAccuracyReport>(result, true);
        }

        // These methods are at this level (and not at the ParticleClassifier level) for user convenience, so if
        // the user reads a session from file they can just Classify() without having to cast.

        //==========================================================================================
        /// <summary>
        /// Classifies the given image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <returns>A ClassifierReport containing the results of the classification.
        /// </returns>

        public ClassifierReport Classify(VisionImage image)
        {
            return Classify(image, null);
        }
        //==========================================================================================
        /// <summary>
        /// Classifies the given image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <param name="roi">
        /// The region of interest in the image.
        /// </param>
        /// <returns>A ClassifierReport containing the results of the classification.
        /// </returns>

        public ClassifierReport Classify(VisionImage image, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            IntPtr reportPtr = VisionDll.imaqClassify(image._image, _session, cviRoi, null, 0);
            Utilities.ThrowError(reportPtr);
            return Utilities.ConvertIntPtrToStructure<ClassifierReport, CVI_ClassifierReport>(reportPtr, true);
        }

        //==========================================================================================
        /// <summary>
        /// Trains the classifier to use the Nearest Neighbor engine, and configures the options the engine uses for classification.
        /// </summary>

        public void TrainNearestNeighbor()
        {
            TrainNearestNeighbor(new NearestNeighborOptions(_nearestNeighborOptions.Method, _nearestNeighborOptions.Metric, _nearestNeighborOptions.K), false);
        }
        //==========================================================================================
        /// <summary>
        /// Trains the classifier to use the Nearest Neighbor engine, and configures the options the engine uses for classification.
        /// </summary>
        /// <param name="options">The options to use when training.
        /// </param>

        public void TrainNearestNeighbor(NearestNeighborOptions options)
        {
            TrainNearestNeighbor(options, false);
        }
        //==========================================================================================
        /// <summary>
        /// Trains the classifier to use the Nearest Neighbor engine, and configures the options the engine uses for classification.
        /// </summary>
        /// <param name="options">The options to use when training.
        /// </param>
        /// <param name="getTrainingReport">Whether to perform a training report.
        /// </param>
        /// <returns>If getTrainingReport is <see langword="true"/>, returns a NearestNeighborTrainingReport containing information about the training process.  Otherwise, returns <see langword="null"/>.
        /// </returns>

        public NearestNeighborTrainingReport TrainNearestNeighbor(NearestNeighborOptions options, bool getTrainingReport)
        {
            ThrowIfDisposed();
            if (options == null) { throw new ArgumentNullException("options"); }
            CVI_NearestNeighborOptions cviOptions = new CVI_NearestNeighborOptions();
            cviOptions.ConvertFromExternal(options);
            IntPtr report = VisionDll.imaqTrainNearestNeighborClassifier(_session, ref cviOptions);
            Utilities.ThrowError(report);
            _engineType = ClassifierEngineType.NearestNeighbor;
            _nearestNeighborOptions.UpdateData();
            if (getTrainingReport)
            {
                return Utilities.ConvertIntPtrToStructure<NearestNeighborTrainingReport, CVI_NearestNeighborTrainingReport>(report, true);
            }
            else
            {
                VisionDll.imaqDispose(report);
                return null;
            }
        }

internal abstract string TypeName
        {
            get;
        }

        
        internal void ThrowIfDisposed()
        {
            if (_session == IntPtr.Zero)
            {
                throw new ObjectDisposedException(TypeName);
            }
        }
        //==========================================================================================
        /// <summary>Releases all resources used by the ClassifierSession.
        /// </summary>

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //==========================================================================================
        /// <summary>
        /// Releases the unmanaged resources used by the Classifier Session and optionally releases the managed resources. 
        /// </summary>
        /// <param name="disposing">
        /// </param>

        protected virtual void Dispose(bool disposing)
        {
            lock (_disposeLock)
            {
                // _session is safe to use since it's unmanaged.
                if (_session != IntPtr.Zero)
                {
                    VisionDll.imaqDispose(_session);
                    _session = IntPtr.Zero;
                }
            }
        }

        
        ~ClassifierSession()
        {
            Dispose(false);
        }

        // An apology:
        // What we'd really like to do is get a Collection<T> (where T : ClassifierSample) from our subclasses
        // so we can reuse the logic here in InvalidateSamples().  Unfortunately, C# doesn't allow us to do this
        // as far as I can tell, so instead we have these icky abstract methods that let us accomplish the same
        // thing.

        
        internal abstract Int32 GetSampleCount();

        
        internal abstract void AddSample(int index);

        
        internal abstract void RemoveSample(int index);

        
        internal abstract void InvalidateAllSamples();

        
        internal void InvalidateSamples()
        {
            // Update the sample count.
            int sampleCount;
            VisionDll.imaqGetClassifierSampleInfo(_session, -1, out sampleCount);
            while (GetSampleCount() < sampleCount)
            {
                AddSample(GetSampleCount());
            }
            while (GetSampleCount() > sampleCount)
            {
                RemoveSample(GetSampleCount() - 1);
            }
            InvalidateAllSamples();
        }
    }

    //==============================================================================================
    /// <summary>
    /// Get options from a particle classifier session. 
    /// </summary>

    public sealed class ParticleClassifierSession : ClassifierSession
    {
        private ClassifierSampleCollection _samples;
        private Collection<ClassifierSample> _samplesCollection;
        private ParticleClassifierOptions _particleOptions;
        private ParticleClassifierPreprocessingOptions _particlePreprocessingOptions;

        
        internal ParticleClassifierSession(IntPtr existingSession)
            : base()
        {
            _type = ClassifierType.Particle;
            _session = existingSession;
            Utilities.ThrowError(_session);
            _samplesCollection = new Collection<ClassifierSample>();
            _samples = new ClassifierSampleCollection(_samplesCollection, this);
            _particleOptions = new ParticleClassifierOptions(this);
            _particlePreprocessingOptions = new ParticleClassifierPreprocessingOptions(this);
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the ParticleClassifierSession class.
        /// </summary>

        public ParticleClassifierSession() : this(VisionDll.imaqCreateClassifier(ClassifierType.Particle))
        {
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the ParticleClassifierSession class.
        /// </summary>
        /// <param name="fileName">
        /// The name of the classifier file to read.
        /// </param>

        public ParticleClassifierSession(string fileName) : this()
        {
            ReadFile(fileName);
        }

        //==========================================================================================
        /// <summary>
        /// Gets information about about a sample in a classifier.
        /// </summary>

        public ClassifierSampleCollection Samples
        {
            get
            {
                ThrowIfDisposed();
                return _samples;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the options used to classify particles. 
        /// </summary>

        public ParticleClassifierOptions ClassifierOptions
        {
            get
            {
                ThrowIfDisposed();
                return _particleOptions;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the options used to process particles before classification. 
        /// </summary>

        public ParticleClassifierPreprocessingOptions PreprocessingOptions
        {
            get
            {
                ThrowIfDisposed();
                return _particlePreprocessingOptions;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>

        public void AddSample(VisionImage image, string sampleClass)
        {
            AddSample(image, sampleClass, null);
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the sample to add. Each contour of roi must be a rectangle, 
        /// rotated rectangle, oval, annulus, or closed contour. 
        /// </param>

        public void AddSample(VisionImage image, string sampleClass, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (sampleClass == null) { throw new ArgumentNullException("sampleClass"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            Utilities.ThrowError(VisionDll.imaqAddClassifierSample(image._image, _session, cviRoi, sampleClass, null, 0));
            AddSample(_samplesCollection.Count);
        }

        
        internal override void OnReadFile()
        {
            ThrowIfWrongClassifierType();
            base.OnReadFile();
            _particleOptions.UpdateData();
            _particlePreprocessingOptions.UpdateData();
        }

internal override int GetSampleCount()
        {
            return _samplesCollection.Count;
        }

        
        internal override void AddSample(int index)
        {
            _samplesCollection.Add(new ClassifierSample(this, index));
        }

        
        internal override void RemoveSample(int index)
        {
            _samplesCollection.RemoveAt(index);
        }

        
        internal override void InvalidateAllSamples()
        {
            for (int i = 0; i < _samplesCollection.Count; ++i) {
                _samplesCollection[i].Index = i;
                _samplesCollection[i].Invalidate();
            }
        }

        
        internal override string TypeName
        {
            get { return "NationalInstruments.Vision.ParticleClassifierSession"; }
        }

internal void ThrowIfWrongClassifierType()
        {
            if (_type != ClassifierType.Particle)
            {
                throw new VisionException(ErrorCode.IncompatibleClassifierTypes);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ClassifierSession.
        /// </summary>
        /// <param name="other">
        /// A ClassifierSession instance to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the <paramref name="other"/> parameter equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public bool Equals(ClassifierSession other)
        {
            if (other == null) return false;
            if (other.GetType() != this.GetType()) return false;
            return _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ClassifierSession.
        /// </summary>
        /// <param name="obj">
        /// An object to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is an instance of ClassifierSession
        ///  and equals the value of this instance; otherwise, <see langword="false"/>.</returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ParticleClassifierSession other = (ParticleClassifierSession)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for the object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code. 
        /// </returns>

        public override int GetHashCode()
        {
            return _session.GetHashCode();
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
            return "ParticleClassifierSession: Samples=" + _samplesCollection.Count;
        }
    }

    //==============================================================================================
    /// <summary>
    /// The color classifier session on which the method operates.
    /// </summary>

    public sealed class ColorClassifierSession : ClassifierSession
    {
        private ClassifierSampleCollection _samples;
        private Collection<ClassifierSample> _samplesCollection;
        private ColorClassifierOptions _colorOptions;

internal ColorClassifierSession(IntPtr existingSession)
            : base()
        {
            _type = ClassifierType.Color;
            _session = existingSession;
            Utilities.ThrowError(_session);
            _samplesCollection = new Collection<ClassifierSample>();
            _samples = new ClassifierSampleCollection(_samplesCollection, this);
            _colorOptions = new ColorClassifierOptions(this);
            
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of a ColorClassifierSession class.
        /// </summary>

        public ColorClassifierSession()
            : this(VisionDll.imaqCreateClassifier(ClassifierType.Color))
        {
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of a ColorClassifierSession class.
        /// </summary>
        /// <param name="fileName">
        /// The name of the classifier file to read.
        /// </param>

        public ColorClassifierSession(string fileName)
            : this()
        {
            ReadFile(fileName);
        }

        //==========================================================================================
        /// <summary>
        /// Gets a collection of classifier sample objects.
        /// </summary>

        public ClassifierSampleCollection Samples
        {
            get
            {
                ThrowIfDisposed();
                return _samples;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Gets the options used to process the color classifier before classification.
        /// </summary>

        public ColorClassifierOptions ClassifierOptions
        {
            get
            {
                ThrowIfDisposed();
                return _colorOptions;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>

        public void AddSample(VisionImage image, string sampleClass)
        {
            AddSample(image, sampleClass, null);
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the sample to add. Each contour of roi must be a rectangle, 
        /// rotated rectangle, oval, annulus, or closed contour. 
        /// </param>

        public void AddSample(VisionImage image, string sampleClass, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (sampleClass == null) { throw new ArgumentNullException("sampleClass"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            Utilities.ThrowError(VisionDll.imaqAddClassifierSample(image._image, _session, cviRoi, sampleClass, null, 0));
            AddSample(_samplesCollection.Count);
        }
        //==========================================================================================
        /// <summary>
        /// Classifies a color image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ClassifierReportAdvanced" crefType="Unqualified"/>
        /// object containing the results of classification.
        /// </returns>

        public ClassifierReportAdvanced ClassifyAdvanced(VisionImage image)
        {
            return ClassifyAdvanced(image, null);
        }
        //==========================================================================================
        /// <summary>
        /// Classifies a color image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the image to classify. Each contour of roi must be a rectangle, 
        /// rotated rectangle, oval, annulus, or closed contour. 
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ClassifierReportAdvanced" crefType="Unqualified"/>
        /// object containing the results of classification.
        /// </returns>

        public ClassifierReportAdvanced ClassifyAdvanced(VisionImage image, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            IntPtr reportPtr = VisionDll.imaqAdvanceClassify(image._image, _session, cviRoi, null, 0);
            Utilities.ThrowError(reportPtr);
            return Utilities.ConvertIntPtrToStructure<ClassifierReportAdvanced, CVI_ClassifierReportAdvanced>(reportPtr, true);
        }

        
        internal override void OnReadFile()
        {
            ThrowIfWrongClassifierType();
            base.OnReadFile();
            _colorOptions.UpdateData();
        }

internal override int GetSampleCount()
        {
            return _samplesCollection.Count;
        }

        
        internal override void AddSample(int index)
        {
            _samplesCollection.Add(new ClassifierSample(this, index));
        }

        
        internal override void RemoveSample(int index)
        {
            _samplesCollection.RemoveAt(index);
        }

        
        internal override void InvalidateAllSamples()
        {
            for (int i = 0; i < _samplesCollection.Count; ++i)
            {
                _samplesCollection[i].Index = i;
                _samplesCollection[i].Invalidate();
            }
        }

        
        internal override string TypeName
        {
            get { return "NationalInstruments.Vision.ColorClassifierSession"; }
        }

        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage)
        {
            return SupervisedColorSegmentation(srcImage, labelImage, 0, 0, new Collection<ROILabel>(), new ColorSegmentationOptions(), new Roi());
        }
        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <param name="maxDistance">
        /// Maximum Distance is the maximum allowed color distance to group the pixel windows. 
        /// Valid values are 0 to 1000. A value of 0 represents a conservative search strategy 
        /// and a value of 1000 represents an aggressive search strategy.
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage, Int32 maxDistance)
        {
            return SupervisedColorSegmentation(srcImage, labelImage, maxDistance, 0, new Collection<ROILabel>(), new ColorSegmentationOptions(), new Roi());
        }
        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <param name="maxDistance">
        /// Maximum Distance is the maximum allowed color distance to group the pixel windows. 
        /// Valid values are 0 to 1000. A value of 0 represents a conservative search strategy 
        /// and a value of 1000 represents an aggressive search strategy.
        /// </param>
        /// <param name="minIdentificationScore">
        /// Min Identification Score is the minimum identification score required to group 
        /// the pixel. Valid values are 0 to 1000.
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage, Int32 maxDistance, Int32 minIdentificationScore)
        {
            return SupervisedColorSegmentation(srcImage, labelImage, maxDistance, minIdentificationScore, new Collection<ROILabel>(), new ColorSegmentationOptions(), new Roi());
        }
        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <param name="maxDistance">
        /// Maximum Distance is the maximum allowed color distance to group the pixel windows. 
        /// Valid values are 0 to 1000. A value of 0 represents a conservative search strategy 
        /// and a value of 1000 represents an aggressive search strategy.
        /// </param>
        /// <param name="minIdentificationScore">
        /// Min Identification Score is the minimum identification score required to group 
        /// the pixel. Valid values are 0 to 1000.
        /// </param>
        /// <param name="labelsIn">
        /// Labels In is a Collection of ROILabel class objects having class names and labels that 
        /// you want to segment.
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage, Int32 maxDistance, Int32 minIdentificationScore, Collection<ROILabel> labelsIn)
        {
            return SupervisedColorSegmentation(srcImage, labelImage, maxDistance, minIdentificationScore, labelsIn, new ColorSegmentationOptions(), new Roi());
        }
        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <param name="maxDistance">
        /// Maximum Distance is the maximum allowed color distance to group the pixel windows. 
        /// Valid values are 0 to 1000. A value of 0 represents a conservative search strategy 
        /// and a value of 1000 represents an aggressive search strategy.
        /// </param>
        /// <param name="minIdentificationScore">
        /// Min Identification Score is the minimum identification score required to group 
        /// the pixel. Valid values are 0 to 1000.
        /// </param>
        /// <param name="labelsIn">
        /// Labels In is a Collection of ROILabel class objects having class names and labels that 
        /// you want to segment.
        /// </param>
        /// <param name="segmentOptions">
        /// Specifies the parameters used to configure the color segmentation algorithm.
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage, Int32 maxDistance, Int32 minIdentificationScore, Collection<ROILabel> labelsIn, ColorSegmentationOptions segmentOptions)
        {
            return SupervisedColorSegmentation(srcImage, labelImage, maxDistance, minIdentificationScore, labelsIn, segmentOptions, new Roi()); 
        }
        
        //==========================================================================================
        /// <summary>
        /// Segments a color image using trained samples.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="labelImage">
        /// Label Image is a reference to the label image. 
        /// </param>
        /// <param name="maxDistance">
        /// Maximum Distance is the maximum allowed color distance to group the pixel windows. 
        /// Valid values are 0 to 1000. A value of 0 represents a conservative search strategy 
        /// and a value of 1000 represents an aggressive search strategy.
        /// </param>
        /// <param name="minIdentificationScore">
        /// Min Identification Score is the minimum identification score required to group 
        /// the pixel. Valid values are 0 to 1000.
        /// </param>
        /// <param name="labelsIn">
        /// Labels In is a Collection of ROILabel class objects having class names and labels that 
        /// you want to segment.
        /// </param>
        /// <param name="segmentOptions">
        /// Specifies the parameters used to configure the color segmentation algorithm.
        /// </param>
        /// <param name="roi">
        /// Specifies the region of interest specifying the location of the sample in the image. 
        /// The ROI must be one or more closed contours. If ROI Descriptor is empty or not connected,
        /// the entire image is considered to be the region.
        /// </param>
        /// <returns>
        /// Collection of ROILabel objects.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public Collection<ROILabel> SupervisedColorSegmentation(VisionImage srcImage, VisionImage labelImage, Int32 maxDistance, Int32 minIdentificationScore, Collection<ROILabel> labelsIn, ColorSegmentationOptions segmentOptions, Roi roi)
        {
            if (srcImage == null) { throw new ArgumentNullException("srcImage"); }
            srcImage.ThrowIfDisposed();
            if (labelImage == null) { throw new ArgumentNullException("labelImage"); }
            labelImage.ThrowIfDisposed();
            if (labelsIn == null) { throw new ArgumentNullException("labelsIn"); }
            if (segmentOptions == null) { throw new ArgumentNullException("segmentOptions"); }
            if (roi == null) { throw new ArgumentNullException("roi"); }
            roi.ThrowIfDisposed();
            CVI_ROILabel[] labelsInArray;
            Int32 numLabelsIn = 0;
            IntPtr labelsInArrayPtr = IntPtr.Zero;
            if (labelsIn.Count != 0)
            {
                labelsInArray = new CVI_ROILabel[labelsIn.Count];
                foreach (ROILabel val in labelsIn)
                {
                    labelsInArray[numLabelsIn++].ConvertFromExternal(val);
                }
                labelsInArrayPtr = Utilities.ConvertArrayToIntPtr<CVI_ROILabel>(labelsInArray);
            }
            CVI_ColorSegmentationOptions cviSegmentOptions = new CVI_ColorSegmentationOptions();
            cviSegmentOptions.ConvertFromExternal(segmentOptions);
            IntPtr result = VisionDll.imaqSupervisedColorSegmentation(_session, labelImage._image, srcImage._image,Roi.GetIntPtr(roi), labelsInArrayPtr, numLabelsIn, maxDistance, minIdentificationScore, ref cviSegmentOptions);
            Utilities.ThrowError(result);
            CVI_ColorSegmentationReport report = Utilities.ConvertIntPtrToStructure<CVI_ColorSegmentationReport>(result, true);
            return report.ConvertToExternal();
        }

        //==========================================================================================
        /// <summary>
        /// Gets the maximum distance allowed to group classes in color image segmentation
        /// </summary>
        /// <param name="segmentOptions">
        /// Specifies the parameters used to configure the color segmentation algorithm.
        /// </param>
        /// <param name="distLevel">
        /// Level Type specifies the sensitivity of Maximum Distance.
        /// </param>
        /// <returns>
        /// Maximun distance which is allowed between pixel windows.
        /// </returns>
        /// <remarks>
        /// </remarks>

        public int GetColorSegmentationMaxDistance(ColorSegmentationOptions segmentOptions, SegmentationDistanceLevel distLevel)
        {
            if (segmentOptions == null) { throw new ArgumentNullException("segmentOptions"); }
            CVI_ColorSegmentationOptions cviSegmentOptions = new CVI_ColorSegmentationOptions();
            cviSegmentOptions.ConvertFromExternal(segmentOptions);
            int maxDistance = 0;
            Utilities.ThrowError(VisionDll.imaqGetColorSegmentationMaxDistance(_session, ref cviSegmentOptions, distLevel, out maxDistance));
            return maxDistance;
        }

internal void ThrowIfWrongClassifierType()
        {
            if (_type != ClassifierType.Color)
            {
                throw new VisionException(ErrorCode.IncompatibleClassifierTypes);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ColorClassifierSession.
        /// </summary>
        /// <param name="other">
        /// A ColorClassifierSession instance to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the <paramref name="other"/> parameter equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public bool Equals(ClassifierSession other)
        {
            if (other == null) return false;
            if (other.GetType() != this.GetType()) return false;
            return _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ColorClassifierSession.
        /// </summary>
        /// <param name="obj">
        /// An object to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is an instance of ColorClassifierSession
        ///  and equals the value of this instance; otherwise, <see langword="false"/>.</returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            ColorClassifierSession other = (ColorClassifierSession)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for the object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code. 
        /// </returns>

        public override int GetHashCode()
        {
            return _session.GetHashCode();
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
            return "ColorClassifierSession: Samples=" + _samplesCollection.Count;
        }
    }
    
    //==============================================================================================
    /// <summary>
    /// The Texture Defect classifier session on which the method operates.
    /// </summary>

    public sealed class TextureDefectClassifierSession : ClassifierSession
    {
        private ClassifierSampleCollection _samples;
        private Collection<ClassifierSample> _samplesCollection;
        private TextureDefectClassifierOptions _textureDefectClassifierOptions;

        
        internal TextureDefectClassifierSession(IntPtr existingSession)
            : base() 
        {
            _type = ClassifierType.Color;
            _session = existingSession;
            Utilities.ThrowError(_session);
            _samplesCollection = new Collection<ClassifierSample>();
            _samples = new ClassifierSampleCollection(_samplesCollection, this);
            _textureDefectClassifierOptions = new TextureDefectClassifierOptions();
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of a TextureClassifierSession class.
        /// </summary>

        public TextureDefectClassifierSession()
            : this(VisionDll.imaqCreateClassifier(ClassifierType.TextureDefect))
        {
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the TextureClassifierSession class.
        /// </summary>
        /// <param name="fileName">
        /// The name of the classifier file to read.
        /// </param>

        public TextureDefectClassifierSession(string fileName)
            : this()
        {
            ReadFile(fileName);
        }

        //==========================================================================================
        /// <summary>
        /// Gets Texture defect classifier options.
        /// </summary>

        public TextureDefectClassifierOptions TextureDefectClassifierOptions
        {
            get
            {
                ThrowIfDisposed();
                return _textureDefectClassifierOptions;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Gets a collection of classifier sample objects.
        /// </summary>

        public ClassifierSampleCollection Samples
        {
            get
            {
                ThrowIfDisposed();
                return _samples;
            }
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>

        public void AddSample(VisionImage image, string sampleClass)
        {
            AddSample(image, sampleClass, null);
        }

        //==========================================================================================
        /// <summary>
        /// Adds a sample to a classifier. 
        /// </summary>
        /// <param name="image">
        /// The image to add to the classifier.
        /// </param>
        /// <param name="sampleClass">
        /// The class to which the sample belongs.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the sample to add. Each contour of roi must be a rectangle, 
        /// rotated rectangle, oval, annulus, or closed contour. 
        /// </param>

        public void AddSample(VisionImage image, string sampleClass, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            if (sampleClass == null) { throw new ArgumentNullException("sampleClass"); }
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            Utilities.ThrowError(VisionDll.imaqAddClassifierSample(image._image, _session, cviRoi, sampleClass, null, 0));
            AddSample(_samplesCollection.Count);
        }

        //==========================================================================================
        /// <summary>
        /// Classifies a color image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ClassifierReportAdvanced" crefType="Unqualified"/>
        /// object containing the results of classification.
        /// </returns>

        public ClassifierReportAdvanced ClassifyAdvanced(VisionImage image)
        {
            return ClassifyAdvanced(image, null);
        }
        //==========================================================================================
        /// <summary>
        /// Classifies a color image.
        /// </summary>
        /// <param name="image">
        /// The image to classify.
        /// </param>
        /// <param name="roi">
        /// The ROI containing the image to classify. Each contour of roi must be a rectangle, 
        /// rotated rectangle, oval, annulus, or closed contour. 
        /// </param>
        /// <returns>
        /// A <see cref="NationalInstruments.Vision.Analysis.ClassifierReportAdvanced" crefType="Unqualified"/>
        /// object containing the results of classification.
        /// </returns>

        public ClassifierReportAdvanced ClassifyAdvanced(VisionImage image, Roi roi)
        {
            ThrowIfDisposed();
            if (image == null) { throw new ArgumentNullException("image"); }
            image.ThrowIfDisposed();
            IntPtr cviRoi = Roi.GetIntPtr(roi);
            IntPtr reportPtr = VisionDll.imaqAdvanceClassify(image._image, _session, cviRoi, null, 0);
            Utilities.ThrowError(reportPtr);
            return Utilities.ConvertIntPtrToStructure<ClassifierReportAdvanced, CVI_ClassifierReportAdvanced>(reportPtr, true);
        }

        //==========================================================================================
        /// <summary>
        /// Detects defects in textured images.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="destinationImage">
        /// Image Dst is a reference to the destination image. 
        /// </param>
        /// <param name="initialStepSize">
        /// Initial Step Size specifies the offset, in pixels, by which the classifier should reposition 
        /// the window during the initial defect detection phase. Values range from 0 to the smallest window 
        /// dimension. The default value of 0 indicates no overlap between windows. A small, non-zero step 
        /// size processes the image in more detail, but increases the time required to process the image.
        /// </param>
        /// <param name="finalStepSize">
        /// Final Step Size specifies the offset, in pixels, by which the classifier should reposition the 
        /// window during the final detect detection phase. The default value of 1 indicates that the classifier 
        /// will reposition the window by 1 pixel as it searches for defects.The window is positioned only on 
        /// pixels detected as defects in the initial defect detection phase. A smaller, non-zero step size 
        /// processes the image in more detail, but increases the time required to process the image. This value
        /// must be smaller than the Initial Step Size if the Initial Step Size is set to a value greater than zero.
        /// </param>
        /// <param name="defaultPixelValue">
        /// Defect Pixel Value is the value used to replace defect pixels in the image.
        /// </param>
        /// <param name="minClassificationScore">
        /// Min. Defect Identification Score is the value used to determine if a pixel in the image is a 
        /// defect. The pixel is classified as a defect if the identification score is greater than or equal to this value.
        /// </param>
        /// <returns>
        /// Nothing.
        /// </returns>
        /// <remarks>
        /// Use this method with U8, U16 and I16 images.
        /// </remarks>

        public void DetectTextureDefect(VisionImage sourceImage, VisionImage destinationImage, Int32 initialStepSize, Int32 finalStepSize, char defectPixelValue, double minClassificationScore)
        {
            DetectTextureDefect(sourceImage, destinationImage, initialStepSize, finalStepSize, defectPixelValue, minClassificationScore, new Roi());
        }
        //==========================================================================================
        /// <summary>
        /// Detects defects in textured images.
        /// </summary>
        /// <param name="sourceImage">
        /// Image Src is a reference to the source image. 
        /// </param>
        /// <param name="destinationImage">
        /// Image Dst is a reference to the destination image. 
        /// </param>
        /// <param name="initialStepSize">
        /// Initial Step Size specifies the offset, in pixels, by which the classifier should reposition 
        /// the window during the initial defect detection phase. Values range from 0 to the smallest window 
        /// dimension. The default value of 0 indicates no overlap between windows. A small, non-zero step 
        /// size processes the image in more detail, but increases the time required to process the image.
        /// </param>
        /// <param name="finalStepSize">
        /// Final Step Size specifies the offset, in pixels, by which the classifier should reposition the 
        /// window during the final detect detection phase. The default value of 1 indicates that the classifier 
        /// will reposition the window by 1 pixel as it searches for defects.The window is positioned only on 
        /// pixels detected as defects in the initial defect detection phase. A smaller, non-zero step size 
        /// processes the image in more detail, but increases the time required to process the image. This value
        /// must be smaller than the Initial Step Size if the Initial Step Size is set to a value greater than zero.
        /// </param>
        /// <param name="defectPixelValue">
        /// Defect Pixel Value is the value used to replace defect pixels in the image.
        /// </param>
        /// <param name="minClassificationScore">
        /// Min. Defect Identification Score is the value used to determine if a pixel in the image is a 
        /// defect. The pixel is classified as a defect if the identification score is greater than or equal to this value.
        /// </param>
        /// <param name="roi">
        /// ROI Descriptor specifies the region of the image in which to detect defects.
        /// </param>
        /// <returns>
        /// Nothing.
        /// </returns>
        /// <remarks>
        /// Use this method with U8, U16 and I16 images.
        /// </remarks>

        public void DetectTextureDefect(VisionImage sourceImage, VisionImage destinationImage, Int32 initialStepSize, Int32 finalStepSize, char defectPixelValue, double minClassificationScore, Roi roi)
        {
            if (sourceImage == null) { throw new ArgumentNullException("sourceImage"); }
            sourceImage.ThrowIfDisposed();
            if (destinationImage == null) { throw new ArgumentNullException("destinationImage"); }
            destinationImage.ThrowIfDisposed();
            if (roi == null) { throw new ArgumentNullException("roi"); }
            roi.ThrowIfDisposed();
            Utilities.ThrowError(VisionDll.imaqDetectTextureDefect(_session, destinationImage._image, sourceImage._image, Roi.GetIntPtr(roi), initialStepSize, finalStepSize, defectPixelValue, minClassificationScore));
        }

        
        internal override void OnReadFile()
        {
            ThrowIfWrongClassifierType();
            base.OnReadFile();
            _textureDefectClassifierOptions.UpdateData();
        }

internal override int GetSampleCount()
        {
            return _samplesCollection.Count;
        }

        
        internal override void AddSample(int index)
        {
            _samplesCollection.Add(new ClassifierSample(this, index));
        }

        
        internal override void RemoveSample(int index)
        {
            _samplesCollection.RemoveAt(index);
        }

        
        internal override void InvalidateAllSamples()
        {
            for (int i = 0; i < _samplesCollection.Count; ++i)
            {
                _samplesCollection[i].Index = i;
                _samplesCollection[i].Invalidate();
            }
        }

        
        internal override string TypeName
        {
            get { return "NationalInstruments.Vision.TextureDefectClassifierSession"; }
        }

internal void ThrowIfWrongClassifierType()
        {
            if (_type != ClassifierType.TextureDefect)
            {
                throw new VisionException(ErrorCode.IncompatibleClassifierTypes);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified TextureDefectClassifierSession.
        /// </summary>
        /// <param name="other">
        /// A TextureDefectClassifierSession instance to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the <paramref name="other"/> parameter equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public bool Equals(ClassifierSession other)
        {
            if (other == null) return false;
            if (other.GetType() != this.GetType()) return false;
            return _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified TextureDefectClassifierSession.
        /// </summary>
        /// <param name="obj">
        /// An object to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is an instance of TextureDefectClassifierSession
        ///  and equals the value of this instance; otherwise, <see langword="false"/>.</returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            TextureDefectClassifierSession other = (TextureDefectClassifierSession)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for the object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code. 
        /// </returns>

        public override int GetHashCode()
        {
            return _session.GetHashCode();
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
            return "TextureDefectClassifierSession: Samples=" + _samplesCollection.Count;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Adds a sample to this CustomClassifierSession.
    /// </summary>
    /// <remarks>
    /// </remarks>

    public sealed class CustomClassifierSession : ClassifierSession
    {
        private CustomClassifierSampleCollection _samples;
        private Collection<CustomClassifierSample> _samplesCollection;

        
        internal CustomClassifierSession(IntPtr existingSession)
            : base()
        {
            _type = ClassifierType.Custom;
            _session = existingSession;
            Utilities.ThrowError(_session);
            _samplesCollection = new Collection<CustomClassifierSample>();
            _samples = new CustomClassifierSampleCollection(_samplesCollection, this);
        }
        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the CustomClassifierSession class.
        /// </summary>

        public CustomClassifierSession() : this(VisionDll.imaqCreateClassifier(ClassifierType.Custom))
        {
        }

        //==========================================================================================
        /// <summary>
        /// Initializes a new instance of the CustomClassifierSession class.
        /// </summary>
        /// <param name="fileName">
        /// The file name of the classifier file to read in.
        /// </param>

        public CustomClassifierSession(string fileName) : this()
        {
            ReadFile(fileName);
        }

        //==========================================================================================
        /// <summary>
        /// The samples that this CustomClassifierSession contains.
        /// </summary>
        /// <value>
        /// </value>

        public CustomClassifierSampleCollection Samples
        {
            get
            {
                ThrowIfDisposed();
                return _samples;
            }
        }

        //==========================================================================================
        /// <summary>
        /// Adds a sample to this CustomClassifierSession.
        /// </summary>
        /// <param name="featureVector">
        /// The feature to add.
        /// </param>
        /// <param name="sampleClass">
        /// The class of this feature.
        /// </param>

        public void AddSample(Collection<double> featureVector, string sampleClass)
        {
            AddSample(featureVector, sampleClass, null, null);
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to this CustomClassifierSession.
        /// </summary>
        /// <param name="featureVector">
        /// The feature to add.
        /// </param>
        /// <param name="sampleClass">
        /// The class of this feature.
        /// </param>
        /// <param name="thumbnailImage">
        /// A thumbnail image to associate with this feature.
        /// </param>

        public void AddSample(Collection<double> featureVector, string sampleClass, VisionImage thumbnailImage)
        {
            AddSample(featureVector, sampleClass, thumbnailImage, null);
        }
        //==========================================================================================
        /// <summary>
        /// Adds a sample to this CustomClassifierSession.
        /// </summary>
        /// <param name="featureVector">
        /// The feature to add.
        /// </param>
        /// <param name="sampleClass">
        /// The class of this feature.
        /// </param>
        /// <param name="thumbnailImage">
        /// A thumbnail image to associate with this feature.
        /// </param>
        /// <param name="thumbnailRoi">An ROI on the thumbnail image.
        /// </param>

        public void AddSample(Collection<double> featureVector, string sampleClass, VisionImage thumbnailImage, Roi thumbnailRoi)
        {
            ThrowIfDisposed();
            if (sampleClass == null) { throw new ArgumentNullException("sampleClass"); }
            if (featureVector == null) { throw new ArgumentNullException("featureVector"); }
            // If the featureVector is of size 0, CVI will think we're trying to add to a particle classifier session.
            // Return a more appropriate error here.
            if (featureVector.Count == 0)
            {
                throw new VisionException(ErrorCode.InvalidCustomSample);
            }
            VisionImage.ThrowIfNonNullAndDisposed(thumbnailImage);
            IntPtr cviRoi = Roi.GetIntPtr(thumbnailRoi);
            double[] featureVectorArray = Utilities.ConvertCollectionToArray(featureVector);
            Utilities.ThrowError(VisionDll.imaqAddClassifierSample(VisionImage.GetIntPtr(thumbnailImage), _session, cviRoi, sampleClass, featureVectorArray, (UInt32)featureVectorArray.Length));
            AddSample(_samplesCollection.Count);
        }

        //==========================================================================================
        /// <summary>
        /// Classifies the feature vector.
        /// </summary>
        /// <param name="featureVector">
        /// </param>
        /// <returns>
        /// A ClassifierReport containing the results of the classification.</returns>

        public ClassifierReport Classify(Collection<double> featureVector)
        {
            ThrowIfDisposed();
            if (featureVector == null) { throw new ArgumentNullException("featureVector"); }
            double[] featureVectorArray = Utilities.ConvertCollectionToArray(featureVector);
            IntPtr reportPtr = VisionDll.imaqClassify(IntPtr.Zero, _session, IntPtr.Zero, featureVectorArray, (UInt32)featureVectorArray.Length);
            Utilities.ThrowError(reportPtr);
            return Utilities.ConvertIntPtrToStructure<ClassifierReport, CVI_ClassifierReport>(reportPtr, true);
        }

        //==========================================================================================
        /// <summary>
        /// Classifies the feature vector, returning an advanced report.
        /// </summary>
        /// <param name="featureVector">
        /// </param>
        /// <returns>
        ///  A ClassifierReportAdvanced containing the results of the classification.
        /// </returns>

        public ClassifierReportAdvanced ClassifyAdvanced(Collection<double> featureVector)
        {
            ThrowIfDisposed();
            if (featureVector == null) { throw new ArgumentNullException("featureVector"); }
            double[] featureVectorArray = Utilities.ConvertCollectionToArray(featureVector);
            IntPtr reportPtr = VisionDll.imaqAdvanceClassify(IntPtr.Zero, _session, IntPtr.Zero, featureVectorArray, (UInt32)featureVectorArray.Length);
            Utilities.ThrowError(reportPtr);
            return Utilities.ConvertIntPtrToStructure<ClassifierReportAdvanced, CVI_ClassifierReportAdvanced>(reportPtr, true);
        }

internal override void OnReadFile()
        {
            ThrowIfWrongClassifierType();
            base.OnReadFile();
        }

internal override int GetSampleCount()
        {
            return _samplesCollection.Count;
        }

        
        internal override void AddSample(int index)
        {
            _samplesCollection.Add(new CustomClassifierSample(this, index));
        }

        
        internal override void RemoveSample(int index)
        {
            _samplesCollection.RemoveAt(index);
        }

        
        internal override void InvalidateAllSamples()
        {
            for (int i = 0; i < _samplesCollection.Count; ++i) {
                _samplesCollection[i].Index = i;
                _samplesCollection[i].Invalidate();
            }
        }

        
        internal override string TypeName
        {
            get { return "NationalInstruments.Vision.CustomClassifierSession"; }
        }

        
        internal void ThrowIfWrongClassifierType()
        {
            if (_type != ClassifierType.Custom)
            {
                throw new VisionException(ErrorCode.IncompatibleClassifierTypes);
            }
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ClassifierSession.
        /// </summary>
        /// <param name="other">
        /// A ClassifierSession instance to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if the <paramref name="other"/> parameter equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public bool Equals(ClassifierSession other)
        {
            if (other == null) return false;
            if (other.GetType() != this.GetType()) return false;
            return _session == other._session;
        }
        //==========================================================================================
        /// <summary>
        /// Returns a value indicating whether this instance is equal to the specified ClassifierSession.
        /// </summary>
        /// <param name="obj">
        /// An object to compare to this instance. 
        /// </param>
        /// <returns>
        /// 	<see langword="true"/> if <paramref name="obj"/> is an instance of ClassifierSession and equals the value of this instance; otherwise, <see langword="false"/>.
        /// </returns>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            CustomClassifierSession other = (CustomClassifierSession)obj;
            return Equals(other);
        }
        //==========================================================================================
        /// <summary>
        /// Returns a hash code for the object.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code. 
        /// </returns>

        public override int GetHashCode()
        {
            return _session.GetHashCode();
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
            return "CustomClassifierSession: Samples=" + _samplesCollection.Count;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides a collection of classifier sample objects. It contains one item for each sample in the classifier.
    /// </summary>

    public sealed class ClassifierSampleCollection : ReadOnlyCollection<ClassifierSample>
    {
        private ClassifierSession _owner;

        
        internal ClassifierSampleCollection(Collection<ClassifierSample> collection, ClassifierSession owner) : base(collection)
        {
            _owner = owner;
        }

        //==========================================================================================
        /// <summary>
        /// Removes the ClassifierSample object at the specified index from the ClassifierSampleCollection collection.
        /// </summary>
        /// <param name="index">
        /// The location of the ClassifierSample object.
        /// </param>

        public void RemoveAt(int index)
        {
            _owner.ThrowIfDisposed();
            Utilities.ThrowError(VisionDll.imaqDeleteClassifierSample(_owner._session, index));
            Items.RemoveAt(index);
            _owner.InvalidateSamples();
        }

        //==========================================================================================
        /// <summary>
        /// Removes all items from the collection. 
        /// </summary>

        public void Clear()
        {
            _owner.ThrowIfDisposed();
            // Clear the underlying session and our CharacterInfo's
            while (Items.Count > 0)
            {
                Utilities.ThrowError(VisionDll.imaqDeleteClassifierSample(_owner._session, Items.Count - 1));
                Items.RemoveAt(Items.Count - 1);
            }
            _owner.InvalidateSamples();
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
            return "ClassifierSampleCollection: Count=" + Count;
        }
    }

    //==============================================================================================
    /// <summary>
    /// Provides a collection of CustomClassifierSample objects.  
    /// </summary>
    /// <remarks>
    /// Each collection contains one item for each sample in the custom classifier.
    /// </remarks>

    public sealed class CustomClassifierSampleCollection : ReadOnlyCollection<CustomClassifierSample>
    {
        private CustomClassifierSession _owner;

        
        internal CustomClassifierSampleCollection(Collection<CustomClassifierSample> collection, CustomClassifierSession owner) : base(collection)
        {
            _owner = owner;
        }

        //==========================================================================================
        /// <summary>
        /// Removes the CustomClassifierSample object at the specified index from the CustomClassifierSampleCollection collection.
        /// </summary>
        /// <param name="index">
        /// The location of the CustomClassifierSample object.
        /// </param>

        public void RemoveAt(int index)
        {
            _owner.ThrowIfDisposed();
            Utilities.ThrowError(VisionDll.imaqDeleteClassifierSample(_owner._session, index));
            Items.RemoveAt(index);
            _owner.InvalidateSamples();
        }

        //==========================================================================================
        /// <summary>
        /// Removes all items from the collection.
        /// </summary>

        public void Clear()
        {
            _owner.ThrowIfDisposed();
            // Clear the underlying session and our CharacterInfo's
            while (Items.Count > 0)
            {
                Utilities.ThrowError(VisionDll.imaqDeleteClassifierSample(_owner._session, Items.Count - 1));
                Items.RemoveAt(Items.Count - 1);
            }
            _owner.InvalidateSamples();
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
            return "CustomClassifierSampleCollection: Count=" + Count;
        }
    }
}