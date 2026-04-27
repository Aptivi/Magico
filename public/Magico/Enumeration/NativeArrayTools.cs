//
// Magico  Copyright (C) 2024  Aptivi
//
// This file is part of Magico
//
// Magico is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Magico is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Magico.Enumeration
{
    /// <summary>
    /// Unmanaged array tools for interaction with native libraries
    /// </summary>
    public static class NativeArrayTools
    {
        /// <summary>
        /// Gets an array of strings with a known length
        /// </summary>
        /// <param name="arrayPointer">Address in process memory pointing to the start of the string "array" (<c>char **</c> or <c>const char **</c>)</param>
        /// <param name="elements">Number of elements to fetch (usually an unmanaged function return code for functions that return unmanaged arrays)</param>
        /// <returns>A list of strings fetched from the array pointer in a native .NET array</returns>
        /// <remarks>Consult the native library documentation for exact instructions on how to use this unmanaged array and functions related to it</remarks>
        public static string[] GetStringsKnownLength(IntPtr arrayPointer, int elements)
        {
            List<string> strings = [];
            for (int i = 0; i < elements; i++)
            {
                // Seek to next element
                IntPtr elementPtr = Marshal.ReadIntPtr(arrayPointer, i * IntPtr.Size);
                string value = Marshal.PtrToStringAnsi(elementPtr) ?? "";
                strings.Add(value);
            }
            return [.. strings];
        }

        /// <summary>
        /// Gets an array of strings with an unknown length
        /// </summary>
        /// <param name="arrayPointer">Address in process memory pointing to the start of the string "array" (<c>char **</c> or <c>const char **</c>)</param>
        /// <returns>A list of strings fetched from the array pointer in a native .NET array, with variable length until the last element</returns>
        /// <remarks>Consult the native library documentation for exact instructions on how to use this unmanaged array and functions related to it</remarks>
        public static string[] GetStringsUnknownLength(IntPtr arrayPointer)
        {
            List<string> strings = [];
            for (int i = 0; i < int.MaxValue; i++)
            {
                // Seek to next element
                IntPtr elementPtr = Marshal.ReadIntPtr(arrayPointer, i * IntPtr.Size);
                if (elementPtr == IntPtr.Zero)
                    break;
                string value = Marshal.PtrToStringAnsi(elementPtr) ?? "";
                strings.Add(value);
            }
            return [.. strings];
        }

        /// <summary>
        /// Gets an array of integers with a known length
        /// </summary>
        /// <param name="arrayPointer">Address in process memory pointing to the start of the integer "array" (<c>int **</c> or <c>const int **</c>)</param>
        /// <param name="elements">Number of elements to fetch (usually an unmanaged function return code for functions that return unmanaged arrays)</param>
        /// <param name="size">Size of unmanaged integer element. While <see langword="sizeof"/>() can be used, check integer size in memory that the native library expects</param>
        /// <returns>A list of integers fetched from the array pointer in a native .NET array</returns>
        /// <remarks>Consult the native library documentation for exact instructions on how to use this unmanaged array and functions related to it</remarks>
        public static int[] GetIntegersKnownLength(IntPtr arrayPointer, int elements, int size)
        {
            List<int> ints = [];
            for (int i = 0; i < elements; i++)
            {
                // Seek to next element
                IntPtr elementPtr = arrayPointer + i * size;
                int value = Marshal.ReadInt32(elementPtr);
                ints.Add(value);
            }
            return [.. ints];
        }
    }
}
