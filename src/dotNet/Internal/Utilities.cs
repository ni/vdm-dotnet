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
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace NationalInstruments.Vision.Internal
{
    static internal class Utilities
    {
        public static void ThrowError(Int32 success) 
        {
            if (success == 0) 
            {
                ThrowError();
            }
        }

        public static void ThrowError(IntPtr errorPtr) 
        {
            if (errorPtr == IntPtr.Zero)
            {
                ThrowError();
            }
        }
        public static void ThrowError(bool isError)
        {
            if (isError)
            {
                ThrowError();
            }
        }
        public static void ThrowError()
        {
            ErrorCode lastError = VisionDllCommon.imaqGetLastError();
            if (lastError != ErrorCode.Success)
            {
                throw new VisionException(lastError);
            }
        }

        public static IntPtr AdvanceIntPtr(IntPtr intPtr, int i)
        {
#if Bit64
            return (IntPtr)((Int64)intPtr + i);
#else
            return (IntPtr)((Int32)intPtr + i);
#endif
        }

        /// <summary>
        /// Converts the collection to an IntPtr suitable to be passed to the DLL.
        /// NOTE: you must FreeCoTaskMem on the result after you're done with it!
        /// </summary>
        /// <typeparam name="E">external type</typeparam>
        /// <typeparam name="I">internal type</typeparam>
        /// <param name="coll">collection to convert</param>
        /// <returns>IntPtr that MUST be FreeCoTaskMem()'d after done!</returns>
        public static IntPtr ConvertCollectionToIntPtr<E, I>(Collection<E> coll) where I : IHasExternalVersionIn<E>, new()
        {
            I[] array = ConvertCollectionToArray<E, I>(coll);
            return ConvertArrayToIntPtr(array);
        }
        /// <summary>
        /// Converts the collection to an IntPtr suitable to be passed to the DLL.
        /// NOTE: you must FreeCoTaskMem on the result after you're done with it!
        /// </summary>
        /// <typeparam name="T">internal type</typeparam>
        /// <param name="coll">collection to convert</param>
        /// <returns>IntPtr that MUST be FreeCoTaskMem()'d after done!</returns>
        public static IntPtr ConvertCollectionToIntPtr<T>(Collection<T> coll) where T : new()
        {
            T[] array = ConvertCollectionToArray<T>(coll);
            return ConvertArrayToIntPtr(array);
        }

        /// <summary>
        /// Converts an array to an IntPtr suitable to be passed to the DLL.
        /// NOTE: you must FreeCoTaskMem on the result after you're done with it!
        /// </summary>
        /// <typeparam name="I">internal type</typeparam>
        /// <param name="array">array to convert</param>
        /// <returns>IntPtr that MUST be FreeCoTaskMem()'d after done!</returns>
        public static IntPtr ConvertArrayToIntPtr<I>(I[] array)
        {
            IntPtr toReturn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(I)) * array.Length);
            IntPtr current = toReturn;
            for (int i = 0; i < array.Length; ++i)
            {
                Marshal.StructureToPtr(array[i], current, false);
                current = AdvanceIntPtr(current, Marshal.SizeOf(typeof(I)));
            }
            return toReturn;
        }

        /// <summary>
        /// Converts an array to an IntPtr suitable to be passed to the DLL.
        /// NOTE: you must FreeCoTaskMem on the result after you're done with it!
        /// </summary>
        /// <typeparam name="I">internal type</typeparam>
        /// <param name="array">array to convert</param>
        /// <returns>IntPtr that MUST be FreeCoTaskMem()'d after done!</returns>
        public static IntPtr Convert2DArrayToIntPtr<I>(I[,] array) {
            IntPtr toReturn = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(I)) * array.Length);
            IntPtr current = toReturn;
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    Marshal.StructureToPtr(array[i, j], current, false);
                    current = AdvanceIntPtr(current, Marshal.SizeOf(typeof(I)));
                }
            }
            return toReturn;
        }

        public static T[] ConvertCollectionToArray<T>(Collection<T> coll)
        {
            T[] toReturn = new T[coll.Count];
            for (int i = 0; i < coll.Count; ++i)
            {
                toReturn[i] = coll[i];
            }
            return toReturn;
        }
        public static I[] ConvertCollectionToArray<E,I>(Collection<E> coll) where I : IHasExternalVersionIn<E>, new()
        {
            I[] toReturn = new I[coll.Count];
            for (int i = 0; i < coll.Count; ++i)
            {
                toReturn[i] = new I();
                toReturn[i].ConvertFromExternal(coll[i]);
            }
            return toReturn;
        }
        public static Collection<E> ConvertArrayToCollection<E, I>(I[] array) where I: IHasExternalVersionOut<E>
        {
            Collection<E> toReturn = new Collection<E>();
            for (int i = 0; i < array.Length; ++i)
            {
                toReturn.Add(array[i].ConvertToExternal());
            }
            return toReturn;
        }
        public static Collection<T> ConvertArrayToCollection<T>(T[] array)
        {
            return ConvertArrayToCollection(array, array.Length);
        }
        public static Collection<T> ConvertArrayToCollection<T>(T[] array, int arraySize)
        {
            Collection<T> toReturn = new Collection<T>();
            for (int i = 0; i < arraySize; ++i)
            {
                toReturn.Add(array[i]);
            }
            return toReturn;
        }

        public static Collection<string> ConvertIntPtrToStringCollection(IntPtr ptr, int count, bool dispose)
        {
            Collection<string> toReturn = new Collection<string>();
            IntPtr tempPtr = ptr;
            try
            {
                for (int i = 0; i < count; ++i)
                {
                    IntPtr currentPtr = Marshal.ReadIntPtr(tempPtr);
                    toReturn.Add(Marshal.PtrToStringAnsi(currentPtr));
                    tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(IntPtr)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Collection<T> ConvertIntPtrToCollection<T>(IntPtr ptr, IntPtr count, bool dispose)
        {
            if (count.ToInt64() > UInt32.MaxValue)
            {
                throw new VisionException(ErrorCode.ContainerCapacityExceededUintMax);
            }
            return ConvertIntPtrToCollection<T>(ptr, (uint)count, dispose);
        }
        public static Collection<T> ConvertIntPtrToCollection<T>(IntPtr ptr, int count, bool dispose)
        {
            return ConvertIntPtrToCollection<T>(ptr, (uint)count, dispose);
        }
        public static Collection<T> ConvertIntPtrToCollection<T>(IntPtr ptr, uint count, bool dispose)
        {
            Collection<T> toReturn = new Collection<T>();
            IntPtr tempPtr = ptr;
            try
            {
                for (uint i = 0; i < count; ++i)
                {
                    toReturn.Add(ConvertIntPtrToStructure<T>(tempPtr, false));
                    tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(T)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Collection<E> ConvertIntPtrToCollection<E, I>(IntPtr ptr, int count, bool dispose, Converter<I, E> converter)
        {
            return ConvertIntPtrToCollection<E, I>(ptr, (uint)count, dispose, converter);
        }
        public static Collection<E> ConvertIntPtrToCollection<E, I>(IntPtr ptr, uint count, bool dispose, Converter<I, E> converter)
        {
            Collection<E> toReturn = new Collection<E>();
            IntPtr tempPtr = ptr;
            try
            {
                for (uint i = 0; i < count; ++i)
                {
                    toReturn.Add(converter(ConvertIntPtrToStructure<I>(tempPtr, false)));
                    tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(I)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Collection<E> ConvertIntPtrToCollection<E, I>(IntPtr ptr, IntPtr count, bool dispose) where I : IHasExternalVersionOut<E>
        {
            if (count.ToInt64() > UInt32.MaxValue)
            {
                throw new VisionException(ErrorCode.ContainerCapacityExceededUintMax);
            }
            return ConvertIntPtrToCollection<E, I>(ptr, (uint)count, dispose);
        }
        public static Collection<E> ConvertIntPtrToCollection<E, I>(IntPtr ptr, int count, bool dispose) where I : IHasExternalVersionOut<E>
        {
            return ConvertIntPtrToCollection<E, I>(ptr, (uint)count, dispose);
        }
        /// <summary>
        /// This method converts an array of items (like a report) that we get from CVI
        /// to its corresponding external type, and disposes the array.
        /// </summary>
        /// <param name="ptr">The array that we get back from CVI.</param>
        /// <param name="count">The number of elements in the array.</param>
        /// <param name="dispose">Whether to dispose the pointer after done</param>
        /// <returns>The collection to return to the user.</returns>
        public static Collection<E> ConvertIntPtrToCollection<E,I>(IntPtr ptr, uint count, bool dispose) where I : IHasExternalVersionOut<E>
        {
            Collection<E> toReturn = new Collection<E>();
            IntPtr tempPtr = ptr;
            try
            {
                for (int i = 0; i < count; ++i)
                {
                    I curItem = (I)Marshal.PtrToStructure(tempPtr, typeof(I));
                    toReturn.Add(curItem.ConvertToExternal());
                    tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(I)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }

        // It would be awesome if we could make a generic version of this, but we can't because Marshal.Copy()
        // only works on certain array types.  *sob*
        public static byte[] ConvertIntPtrTo1DArrayByte(IntPtr ptr, Int32 size, bool dispose)
        {
            byte[] toReturn = new byte[size];
            try
            {
                Marshal.Copy(ptr, toReturn, 0, size);
                return toReturn;
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
        }
        public static Int16[] ConvertIntPtrTo1DArrayInt16(IntPtr ptr, Int32 size, bool dispose)
        {
            Int16[] toReturn = new Int16[size];
            try
            {
                Marshal.Copy(ptr, toReturn, 0, size);
                return toReturn;
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
        }
        public static Int32[] ConvertIntPtrTo1DArrayInt32(IntPtr ptr, Int32 size, bool dispose)
        {
            Int32[] toReturn = new Int32[size];
            try
            {
                Marshal.Copy(ptr, toReturn, 0, size);
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static float[] ConvertIntPtrTo1DArraySingle(IntPtr ptr, Int32 size, bool dispose)
        {
            float[] toReturn = new float[size];
            try
            {
                Marshal.Copy(ptr, toReturn, 0, size);
                return toReturn;
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
        }

        // It would be awesome if we could make a generic version of this, but we can't because Marshal.Copy()
        // only works on certain array types.  *sob*
        public static byte[,] ConvertIntPtrFlatTo2DArrayByte(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            byte[,] toReturn = new byte[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                byte[] currentRow = new byte[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(tempPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(byte));
                    arrayIndex += cols * sizeof(byte);
                    tempPtr = AdvanceIntPtr(tempPtr, cols * sizeof(byte));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Int16[,] ConvertIntPtrFlatTo2DArrayInt16(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            Int16[,] toReturn = new Int16[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                Int16[] currentRow = new Int16[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(tempPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(Int16));
                    arrayIndex += cols * sizeof(Int16);
                    tempPtr = AdvanceIntPtr(tempPtr, cols * sizeof(Int16));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Int32[,] ConvertIntPtrFlatTo2DArrayInt32(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            Int32[,] toReturn = new Int32[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                Int32[] currentRow = new Int32[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(tempPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(Int32));
                    arrayIndex += cols * sizeof(Int32);
                    tempPtr = AdvanceIntPtr(tempPtr, cols * sizeof(Int32));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Single[,] ConvertIntPtrFlatTo2DArraySingle(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            Single[,] toReturn = new Single[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                Single[] currentRow = new Single[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(tempPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(Single));
                    arrayIndex += cols *sizeof(Single);
                    tempPtr = AdvanceIntPtr(tempPtr, cols * sizeof(Single));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static UInt16[,] ConvertIntPtrFlatTo2DArrayUInt16(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            UInt16[,] toReturn = new UInt16[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                Int16[] currentRow = new Int16[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(tempPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(Int16));
                    arrayIndex += cols * sizeof(Int16);
                    tempPtr = AdvanceIntPtr(tempPtr, cols * sizeof(Int16));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static Single[,] ConvertIntPtrIndirectTo2DArraySingle(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            Single[,] toReturn = new Single[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                Single[] currentRow = new Single[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    IntPtr rowPtr = Marshal.ReadIntPtr(tempPtr);
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(rowPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(Single));
                    arrayIndex += cols *sizeof(Single);
                    tempPtr = AdvanceIntPtr(tempPtr, System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static double[,] ConvertIntPtrIndirectTo2DArrayDouble(IntPtr ptr, int rows, int cols, bool dispose)
        {
            double[,] toReturn = new double[rows, cols];
            IntPtr tempPtr = ptr;
            try
            {
                double[] currentRow = new double[cols];
                int arrayIndex = 0;
                for (int i = 0; i < rows; ++i)
                {
                    IntPtr rowPtr = tempPtr;
                    // Copy from the pointer to the currentRow array.
                    Marshal.Copy(rowPtr, currentRow, 0, cols);
                    // Copy from the currentRow array to the array to return.
                    Buffer.BlockCopy(currentRow, 0, toReturn, arrayIndex, cols * sizeof(double));
                    arrayIndex += cols *sizeof(double);
                    tempPtr = AdvanceIntPtr(tempPtr, System.Runtime.InteropServices.Marshal.SizeOf(typeof(IntPtr)));
                }
            }
            finally
            {
                if (dispose)
                {
                    VisionDllCommon.imaqDispose(ptr);
                }
            }
            return toReturn;
        }
        public static double[,] ConvertIntPtrIndirectTo2DArrayDouble(IntPtr ptr, IntPtr rows, IntPtr cols, bool dispose)
        {
            if (rows.ToInt64() > Int32.MaxValue || cols.ToInt64() > Int32.MaxValue)
            {
                throw new VisionException(ErrorCode.ContainerCapacityExceededIntMax);
            }
            return ConvertIntPtrIndirectTo2DArrayDouble(ptr, (int)rows, (int)cols, dispose);
        }
        public static T[,] ConvertIntPtrTo2DStructureArray<T>(IntPtr ptr, Int32 rows, Int32 cols, bool dispose)
        {
            T[,] toReturn = new T[rows, cols];
            IntPtr tempPtr = ptr;
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    toReturn[i, j] = (T)Marshal.PtrToStructure(tempPtr, typeof(T));
                    tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(T)));
                }
            }
            if (dispose)
            {
                VisionDllCommon.imaqDispose(ptr);
            }
            return toReturn;
        }
        public static Collection<T> ConvertArray1DToCollection<T>(Array1D array)
        {
            T[] tempArray = ConvertArray1DTo1DStructureArray<T>(array);
            return ConvertArrayToCollection<T>(tempArray);
        }
        public static Collection<E> ConvertArray1DToCollection<E, I>(Array1D array, Converter<I, E> converter)
        {
            return ConvertIntPtrToCollection<E, I>(array.Ptr, array.Count, false, converter);
        }
        public static Collection<E> ConvertArray1DToCollection<E, I>(Array1D array) where I : IHasExternalVersionOut<E>
        {
            I[] tempArray = ConvertArray1DTo1DStructureArray<I>(array);
            return ConvertArrayToCollection<E, I>(tempArray);
        }
        public static T[] ConvertArray1DTo1DStructureArray<T>(Array1D array)
        {
            return ConvertIntPtrTo1DStructureArray<T>(array.Ptr, (Int32)array.Count, false);
        }
        public static Array1D ConvertCollectionToArray1D<T>(Collection<T> collection) where T: new()
        {
            Array1D toReturn;
            VisionDllCommon.Priv_InitArray1D(out toReturn);
            IntPtr ptr = ConvertCollectionToIntPtr<T>(collection);
            toReturn.Count = (uint)collection.Count;
            toReturn.Ptr = ptr;
            return toReturn;
        }
        public static Array1D ConvertCollectionToArray1D<E, I>(Collection<E> collection) where I : IHasExternalVersionIn<E>, new()
        {
            Array1D toReturn;
            VisionDllCommon.Priv_InitArray1D(out toReturn);
            IntPtr ptr = ConvertCollectionToIntPtr<E,I>(collection);
            toReturn.Count = (uint)collection.Count;
            toReturn.Ptr = ptr;
            return toReturn;
        }
        public static T[] ConvertIntPtrTo1DStructureArray<T>(IntPtr ptr, Int32 count, bool dispose)
        {
            return ConvertIntPtrTo1DStructureArray<T>(ptr, (uint)count, dispose);
        }
        public static T[] ConvertIntPtrTo1DStructureArray<T>(IntPtr ptr, UInt32 count, bool dispose)
        {
            T[] toReturn = new T[count];
            IntPtr tempPtr = ptr;
            for (uint i = 0; i < count; ++i)
            {
                toReturn[i] = (T)Marshal.PtrToStructure(tempPtr, typeof(T));
                tempPtr = AdvanceIntPtr(tempPtr, Marshal.SizeOf(typeof(T)));
            }
            if (dispose)
            {
                VisionDllCommon.imaqDispose(ptr);
            }
            return toReturn;
        }

        public static T ConvertIntPtrToStructure<T>(IntPtr ptr, bool dispose)
        {
            T toReturn = (T)Marshal.PtrToStructure(ptr, typeof(T));
            if (dispose)
            {
                VisionDllCommon.imaqDispose(ptr);
            }
            return toReturn;
        }
        /// <summary>
        /// This method converts a single item we get from CVI to its corresponding
        /// external type, and disposes it.
        /// </summary>
        /// <param name="ptr">The item that we get back from CVI.</param>
        /// <returns>The item to return to the user.</returns>
        public static E ConvertIntPtrToStructure<E, I>(IntPtr ptr, bool dispose) where I: IHasExternalVersionOut<E>
        {
            E toReturn = ((I)Marshal.PtrToStructure(ptr, typeof(I))).ConvertToExternal();
            if (dispose)
            {
                VisionDllCommon.imaqDispose(ptr);
            }
            return toReturn;
        }
        public static E ConvertIntPtrToStructure<E, I, E2>(IntPtr ptr, E2 auxiliary, bool dispose) where I: IHasExternalVersionOut<E, E2>
        {
            E toReturn = ((I)Marshal.PtrToStructure(ptr, typeof(I))).ConvertToExternal(auxiliary);
            if (dispose)
            {
                VisionDllCommon.imaqDispose(ptr);
            }
            return toReturn;
        }
        private static void ThrowIfNotSingleRectangleOrNone(Roi roi)
        {
            if (roi.Count > 1 || (roi.Count > 0 && roi[0].Type != ContourType.Rectangle))
            {
                throw new VisionException(ErrorCode.RoiNotRect);
            }
        }

        public static void ThrowIfNotSinglePoint(Roi roi)
        {
            if (roi.Count != 1 || roi[0].Type != ContourType.Point)
            {
                throw new VisionException(ErrorCode.RoiNotPoint);
            }
        }

        public static void ThrowIfNotSingleLine(Roi roi)
        {
            if (roi.Count != 1 || roi[0].Type != ContourType.Line)
            {
                throw new VisionException(ErrorCode.RoiNotLine);
            }
        }

        private static void ThrowIfNotAllPoints(Roi roi)
        {
            foreach (Contour c in roi)
            {
                if (c.Type != ContourType.Point)
                {
                    throw new VisionException(ErrorCode.RoiNotPoints);
                }
            }
        }

        /// <summary>
        /// This method converts the Roi to a collection of points.
        /// Requires that the Roi is not null and not disposed.
        /// </summary>
        /// <param name="roi">The Roi to convert</param>
        /// <returns>The points in the Roi</returns>
        public static Collection<PointContour> ConvertRoiToPoints(Roi roi)
        {
            Utilities.ThrowIfNotAllPoints(roi);
            Collection<PointContour> points = new Collection<PointContour>();
            foreach (Contour c in roi) {
                points.Add((PointContour)c.Shape);
            }
            return points;
        }

        /// <summary>
        /// This method converts the Roi to a RectangleContour or RectangleContour.None.
        /// Requires that the Roi is not disposed (checks if it's a rectangle or not)
        /// </summary>
        /// <param name="roi">The Roi to convert</param>
        /// <returns>The RectangleContour in the Roi</returns>
        public static RectangleContour ConvertRoiToRectangle(Roi roi)
        {
            if (roi != null)
            {
                Utilities.ThrowIfNotSingleRectangleOrNone(roi);
                if (roi.Count > 0)
                {
                    return (RectangleContour)roi[0].Shape;
                }
            }
            return RectangleContour.None;
        }

        public static void ThrowIfNotSingleAnnulus(Roi roi)
        {
            if (roi.Count != 1 || roi[0].Type != ContourType.Annulus)
            {
                throw new VisionException(ErrorCode.RoiNotAnnulus);
            }
        }

        public static bool ArraysEqual<T>(T[] array1, T[] array2)
        {
            if ((array1 == null) != (array2 == null)) return false;
            if (array1 == null && array2 == null) return true;
            if (array1.Length != array2.Length)
            {
                return false;
            }
            for (int i = 0; i < array1.Length; ++i)
            {
                if (!array1[i].Equals(array2[i])) return false;
            }
            return true;
        }
        public static bool ArraysEqual<T>(T[,] array1, T[,] array2)
        {
            if ((array1 == null) != (array2 == null)) return false;
            if (array1 == null && array2 == null) return true;
            if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            {
                return false;
            }
            for (int i = 0; i < array1.GetLength(0); ++i)
            {
                for (int j = 0; j < array1.GetLength(1); ++j)
                {
                    if (!array1[i, j].Equals(array2[i, j])) return false;
                }
            }
            return true;
        }

        public static bool CollectionsEqual<T>(Collection<T> coll1, Collection<T> coll2)
        {
            if ((coll1 == null) != (coll2 == null)) return false;
            if (coll1 == null && coll2 == null) return true;
            if (coll1.Count != coll2.Count)
            {
                return false;
            }
            for (int i = 0; i < coll1.Count; ++i)
            {
                if (!coll1[i].Equals(coll2[i])) return false;
            }
            return true;
        }

        // imaqDraw*OnImage uses this weird format for passing colors.
        // Most things are grayscale, RGB is 0xAABBGGRR, and HSL is 0xAABBGGRR as well,
        // meaning you have to convert it to an RGB value first.
        public static float ConvertPixelValueToFloat(PixelValue value, ImageType type)
        {
            switch (type)
            {
                case ImageType.U8:
                case ImageType.I16:
                case ImageType.U16:
                case ImageType.Single:
                    return value.Grayscale;
                case ImageType.Rgb32:
                    Rgb32Value rgbValue = value.Rgb32;
                    return rgbValue.Blue << 16 | rgbValue.Green << 8 | rgbValue.Red;
                case ImageType.Hsl32:
                    Hsl32Value hslValue = value.Hsl32;
                    // We need to convert this to a Rgb32 first.
                    CVI_Color2 hslColor = new CVI_Color2();
                    hslColor.Hsl = hslValue;
                    CVI_Color2 result = VisionDllCommon.imaqChangeColorSpace2(ref hslColor, ColorMode.Hsl, ColorMode.Rgb, 0.0, IntPtr.Zero);
                    Rgb32Value rgbToConvert = result.Rgb;
                    return rgbToConvert.Blue << 16 | rgbToConvert.Green << 8 | rgbToConvert.Red;
                default:
                    // Don't DebugAssert here since the user could get here by passing an invalid image type.
                    //Debug.Fail("Unexpected image type " + type + " passed to ConvertPixelValueToFloat!");
                    return 0.0F;
            }
        }

        /// <summary>
        /// Converts a null-terminated byte[] returned from the Vision DLL to a string.  Uses the default system encoding.
        /// </summary>
        /// <param name="bytes">The array to convert.</param>
        /// <returns>The string.</returns>
        public static string ConvertBytesToString(byte[] bytes)
        {
            Int32 numBytes = Array.FindIndex(bytes, delegate(byte b) { return b == '\0'; });
            if (numBytes == -1)
            {
                numBytes = bytes.Length;
            }
            return System.Text.Encoding.Default.GetString(bytes, 0, numBytes);
        }
    }
}
