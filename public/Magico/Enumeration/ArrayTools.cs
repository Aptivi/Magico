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

using Magico.Languages;
using Magico.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Magico.Enumeration
{
    /// <summary>
    /// Array tools that are useful
    /// </summary>
    public static class ArrayTools
    {
        internal static readonly Random random = new();

        /// <summary>
        /// Shared random for the random number generator (in case you don't have <see cref="Random"/>.Shared)
        /// </summary>
        public static Random RandomShared =>
#if NET8_0_OR_GREATER
            Random.Shared;
#else
            random;
#endif

        /// <summary>
        /// Randomizes the array by shuffling elements, irrespective of the type, using a type of <seealso href="http://en.wikipedia.org/wiki/Schwartzian_transform">Schwartzian transform</seealso>
        /// </summary>
        /// <typeparam name="T">Target type. It's not necessarily an integer.</typeparam>
        /// <param name="array">Target array to sort randomly</param>
        /// <returns>A new array containing elements that are shuffled.</returns>
        public static T[]? RandomizeArray<T>(this T[] array)
        {
            if (array == null || array.Length == 0)
                return array;

            // First, create a new list of random numbers with the array's value indexes
            List<(double, T)> valuesToShuffle = [];
            for (int i = 0; i < array.Length; i++)
                valuesToShuffle.Add((RandomShared.NextDouble(), array[i]));

            // Then, randomize the array after ordering the numbers
            var randomized = valuesToShuffle
                .OrderBy((val) => val.Item1)
                .Select((kvp) => kvp.Item2)
                .ToArray();
            return randomized;
        }

        /// <summary>
        /// Sorts the byte numbers using the bubble sort algorithm
        /// </summary>
        /// <param name="unsorted">An unsorted array of numbers</param>
        /// <returns>Sorted array of byte numbers</returns>
        public static T[] SortNumbers<T>(this T[] unsorted)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_ENUM_EXCEPTION_ARRAYNOTNUMERIC"));

            // Get the number of iterations
            int iteration = unsorted.Length;
            bool swap;

            // Now, iterate through the whole array to check to see if we need to sort or not
            var thisType = typeof(T);
            for (int i = 0; i < iteration - 1; i++)
            {
                // Reset the swap requirement
                swap = false;

                // Now, compare the two values to see if they need sorting
                for (int j = 0; j < iteration - i - 1; j++)
                {
                    bool needsToSwap = false;

                    // Convert to the target type and determine whether swapping is needed
                    if (thisType == typeof(byte))
                    {
                        byte source = (byte?)Convert.ChangeType(unsorted[j], typeof(byte)) ?? 0;
                        byte target = (byte?)Convert.ChangeType(unsorted[j + 1], typeof(byte)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(sbyte))
                    {
                        sbyte source = (sbyte?)Convert.ChangeType(unsorted[j], typeof(sbyte)) ?? 0;
                        sbyte target = (sbyte?)Convert.ChangeType(unsorted[j + 1], typeof(sbyte)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(short))
                    {
                        short source = (short?)Convert.ChangeType(unsorted[j], typeof(short)) ?? 0;
                        short target = (short?)Convert.ChangeType(unsorted[j + 1], typeof(short)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(ushort))
                    {
                        ushort source = (ushort?)Convert.ChangeType(unsorted[j], typeof(ushort)) ?? 0;
                        ushort target = (ushort?)Convert.ChangeType(unsorted[j + 1], typeof(ushort)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(int))
                    {
                        int source = (int?)Convert.ChangeType(unsorted[j], typeof(int)) ?? 0;
                        int target = (int?)Convert.ChangeType(unsorted[j + 1], typeof(int)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(uint))
                    {
                        uint source = (uint?)Convert.ChangeType(unsorted[j], typeof(uint)) ?? 0;
                        uint target = (uint?)Convert.ChangeType(unsorted[j + 1], typeof(uint)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(long))
                    {
                        long source = (long?)Convert.ChangeType(unsorted[j], typeof(long)) ?? 0;
                        long target = (long?)Convert.ChangeType(unsorted[j + 1], typeof(long)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(ulong))
                    {
                        ulong source = (ulong?)Convert.ChangeType(unsorted[j], typeof(ulong)) ?? 0;
                        ulong target = (ulong?)Convert.ChangeType(unsorted[j + 1], typeof(ulong)) ?? 0;
                        needsToSwap = source > target;
                    }
#if NET8_0_OR_GREATER
                    else if (thisType == typeof(Int128))
                    {
                        Int128 source = (Int128?)Convert.ChangeType(unsorted[j], typeof(Int128)) ?? 0;
                        Int128 target = (Int128?)Convert.ChangeType(unsorted[j + 1], typeof(Int128)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(UInt128))
                    {
                        UInt128 source = (UInt128?)Convert.ChangeType(unsorted[j], typeof(UInt128)) ?? 0;
                        UInt128 target = (UInt128?)Convert.ChangeType(unsorted[j + 1], typeof(UInt128)) ?? 0;
                        needsToSwap = source > target;
                    }
#endif
                    else if (thisType == typeof(float))
                    {
                        float source = (float?)Convert.ChangeType(unsorted[j], typeof(float)) ?? 0;
                        float target = (float?)Convert.ChangeType(unsorted[j + 1], typeof(float)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(double))
                    {
                        double source = (double?)Convert.ChangeType(unsorted[j], typeof(double)) ?? 0;
                        double target = (double?)Convert.ChangeType(unsorted[j + 1], typeof(double)) ?? 0;
                        needsToSwap = source > target;
                    }
                    else if (thisType == typeof(decimal))
                    {
                        decimal source = (decimal?)Convert.ChangeType(unsorted[j], typeof(decimal)) ?? 0;
                        decimal target = (decimal?)Convert.ChangeType(unsorted[j + 1], typeof(decimal)) ?? 0;
                        needsToSwap = source > target;
                    }

                    // Now, swap!
                    if (needsToSwap)
                    {
                        (unsorted[j], unsorted[j + 1]) = (unsorted[j + 1], unsorted[j]);
                        swap = true;
                    }
                }

                // Break if swap is not required
                if (!swap)
                    break;
            }
            return unsorted;
        }
    }
}
