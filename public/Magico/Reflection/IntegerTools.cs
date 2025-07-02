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
using System;

namespace Magico.Reflection
{
    /// <summary>
    /// Tools to manipulate with integers
    /// </summary>
    public static class IntegerTools
    {
        private static readonly string[] sizeOrders =
        [
            "B",  // Bytes
            "KB", // Kilobytes
            "MB", // Megabytes
            "GB", // Gigabytes
            "TB", // Terabytes
            "PB", // Petabytes
            "EB", // Exabytes
            "ZB", // Zettabytes
            "YB", // Yottabytes
            "RB", // Ronnabytes
            "QB"  // Quettabytes
        ];

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static (T source, T target) SwapIfSourceLarger<T>(this T SourceNumber, T TargetNumber)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(SourceNumber, typeof(byte)) ?? 0;
                byte target = (byte?)Convert.ChangeType(TargetNumber, typeof(byte)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(SourceNumber, typeof(sbyte)) ?? 0;
                sbyte target = (sbyte?)Convert.ChangeType(TargetNumber, typeof(sbyte)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(SourceNumber, typeof(short)) ?? 0;
                short target = (short?)Convert.ChangeType(TargetNumber, typeof(short)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(SourceNumber, typeof(ushort)) ?? 0;
                ushort target = (ushort?)Convert.ChangeType(TargetNumber, typeof(ushort)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(SourceNumber, typeof(int)) ?? 0;
                int target = (int?)Convert.ChangeType(TargetNumber, typeof(int)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(SourceNumber, typeof(uint)) ?? 0;
                uint target = (uint?)Convert.ChangeType(TargetNumber, typeof(uint)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(SourceNumber, typeof(long)) ?? 0;
                long target = (long?)Convert.ChangeType(TargetNumber, typeof(long)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(ulong))
            {
                ulong source = (ulong?)Convert.ChangeType(SourceNumber, typeof(ulong)) ?? 0;
                ulong target = (ulong?)Convert.ChangeType(TargetNumber, typeof(ulong)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
#if NET8_0_OR_GREATER
            else if (thisType == typeof(Int128))
            {
                Int128 source = (Int128?)Convert.ChangeType(SourceNumber, typeof(Int128)) ?? 0;
                Int128 target = (Int128?)Convert.ChangeType(TargetNumber, typeof(Int128)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(UInt128))
            {
                UInt128 source = (UInt128?)Convert.ChangeType(SourceNumber, typeof(UInt128)) ?? 0;
                UInt128 target = (UInt128?)Convert.ChangeType(TargetNumber, typeof(UInt128)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
#endif
            else if (thisType == typeof(float))
            {
                float source = (float?)Convert.ChangeType(SourceNumber, typeof(float)) ?? 0;
                float target = (float?)Convert.ChangeType(TargetNumber, typeof(float)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(double))
            {
                double source = (double?)Convert.ChangeType(SourceNumber, typeof(double)) ?? 0;
                double target = (double?)Convert.ChangeType(TargetNumber, typeof(double)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else if (thisType == typeof(decimal))
            {
                decimal source = (decimal?)Convert.ChangeType(SourceNumber, typeof(decimal)) ?? 0;
                decimal target = (decimal?)Convert.ChangeType(TargetNumber, typeof(decimal)) ?? 0;
                if (source > target)
                    return (TargetNumber, SourceNumber);
                return (SourceNumber, TargetNumber);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref int SourceNumber, ref int TargetNumber)
        {
            var (source, target) = SwapIfSourceLarger(SourceNumber, TargetNumber);
            SourceNumber = source;
            TargetNumber = target;
        }

        /// <summary>
        /// Swaps the two numbers if the source is larger than the target
        /// </summary>
        /// <param name="SourceNumber">Number</param>
        /// <param name="TargetNumber">Number</param>
        public static void SwapIfSourceLarger(this ref long SourceNumber, ref long TargetNumber)
        {
            var (source, target) = SwapIfSourceLarger(SourceNumber, TargetNumber);
            SourceNumber = source;
            TargetNumber = target;
        }

        /// <summary>
        /// Gets the amount of digits in a specified number
        /// </summary>
        /// <param name="Number">Number to query its digit count</param>
        /// <returns>How many digits are there in a number</returns>
        public static int GetDigits<T>(this T Number)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(Number, typeof(byte)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(Number, typeof(sbyte)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(Number, typeof(short)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(Number, typeof(ushort)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(Number, typeof(int)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(Number, typeof(uint)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(Number, typeof(long)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(ulong))
            {
                ulong source = (ulong?)Convert.ChangeType(Number, typeof(ulong)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs((double)source)) + 1;
            }
#if NET8_0_OR_GREATER
            else if (thisType == typeof(Int128))
            {
                Int128 source = (Int128?)Convert.ChangeType(Number, typeof(Int128)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs((double)source)) + 1;
            }
            else if (thisType == typeof(UInt128))
            {
                UInt128 source = (UInt128?)Convert.ChangeType(Number, typeof(UInt128)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs((double)source)) + 1;
            }
#endif
            else if (thisType == typeof(float))
            {
                float source = (float?)Convert.ChangeType(Number, typeof(float)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(double))
            {
                double source = (double?)Convert.ChangeType(Number, typeof(double)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10(Math.Abs(source)) + 1;
            }
            else if (thisType == typeof(decimal))
            {
                decimal source = (decimal?)Convert.ChangeType(Number, typeof(decimal)) ?? 0;
                return source == 0 ? 1 : (int)Math.Log10((double)Math.Abs(source)) + 1;
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));
        }

        /// <summary>
        /// Converts a file size in bytes to a human-readable format
        /// </summary>
        public static string SizeString<T>(this T bytes)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(bytes, typeof(byte)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(bytes, typeof(sbyte)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(bytes, typeof(short)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(bytes, typeof(ushort)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(bytes, typeof(int)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(bytes, typeof(uint)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(bytes, typeof(long)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(ulong))
            {
                ulong source = (ulong?)Convert.ChangeType(bytes, typeof(ulong)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
#if NET8_0_OR_GREATER
            else if (thisType == typeof(Int128))
            {
                Int128 source = (Int128?)Convert.ChangeType(bytes, typeof(Int128)) ?? 0;
                if (source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = (decimal)source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(UInt128))
            {
                UInt128 source = (UInt128?)Convert.ChangeType(bytes, typeof(UInt128)) ?? 0;
                if (source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = (decimal)source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
#endif
            else if (thisType == typeof(float))
            {
                float source = (float?)Convert.ChangeType(bytes, typeof(float)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = (decimal)source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(double))
            {
                double source = (double?)Convert.ChangeType(bytes, typeof(double)) ?? 0;
                if (double.IsNaN(source) || source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = (decimal)source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else if (thisType == typeof(decimal))
            {
                decimal source = (decimal?)Convert.ChangeType(bytes, typeof(decimal)) ?? 0;
                if (source < 0)
                    source = 0;

                decimal bytesForEachKilobyte = 1024;
                var orderIdx = 0;
                decimal len = source;
                while (len >= bytesForEachKilobyte && orderIdx < sizeOrders.Length - 1)
                {
                    orderIdx++;
                    len /= bytesForEachKilobyte;
                }

                return string.Format("{0:0.#} {1}", len, sizeOrders[orderIdx]);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));
        }

        /// <summary>
        /// Converts the number to the binary representation
        /// </summary>
        /// <param name="num">Target number</param>
        /// <returns>A binary representation of the number</returns>
        public static string ToBinary<T>(this T num)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(num, typeof(byte)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(num, typeof(sbyte)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(num, typeof(short)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(num, typeof(ushort)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(num, typeof(int)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(num, typeof(uint)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(num, typeof(long)) ?? 0;
                return Convert.ToString(source, 2);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_NUMBERNOTNATURAL"));
        }

        /// <summary>
        /// Converts the number to the octal representation
        /// </summary>
        /// <param name="num">Target number</param>
        /// <returns>An octal representation of the number</returns>
        public static string ToOctal<T>(this T num)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(num, typeof(byte)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(num, typeof(sbyte)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(num, typeof(short)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(num, typeof(ushort)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(num, typeof(int)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(num, typeof(uint)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(num, typeof(long)) ?? 0;
                return Convert.ToString(source, 8);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_NUMBERNOTNATURAL"));
        }

        /// <summary>
        /// Converts the number to the number representation
        /// </summary>
        /// <param name="num">Target number</param>
        /// <returns>A number representation of the number</returns>
        public static string ToNumber<T>(this T num)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(num, typeof(byte)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(num, typeof(sbyte)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(num, typeof(short)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(num, typeof(ushort)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(num, typeof(int)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(num, typeof(uint)) ?? 0;
                return Convert.ToString(source);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(num, typeof(long)) ?? 0;
                return Convert.ToString(source);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_NUMBERNOTNATURAL"));
        }

        /// <summary>
        /// Converts the number to the hexadecimal representation
        /// </summary>
        /// <param name="num">Target number</param>
        /// <returns>A hexadecimal representation of the number</returns>
        public static string ToHex<T>(this T num)
        {
            if (!ReflectionCommon.IsTypeNumeric<T>())
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_VALUENOTNUMERIC"));

            var thisType = typeof(T);
            if (thisType == typeof(byte))
            {
                byte source = (byte?)Convert.ChangeType(num, typeof(byte)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(sbyte))
            {
                sbyte source = (sbyte?)Convert.ChangeType(num, typeof(sbyte)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(short))
            {
                short source = (short?)Convert.ChangeType(num, typeof(short)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(ushort))
            {
                ushort source = (ushort?)Convert.ChangeType(num, typeof(ushort)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(int))
            {
                int source = (int?)Convert.ChangeType(num, typeof(int)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(uint))
            {
                uint source = (uint?)Convert.ChangeType(num, typeof(uint)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else if (thisType == typeof(long))
            {
                long source = (long?)Convert.ChangeType(num, typeof(long)) ?? 0;
                return Convert.ToString(source, 16);
            }
            else
                throw new ArgumentException(LanguageTools.GetLocalized("MAGICO_REFLECTION_INTTOOLS_EXCEPTION_NUMBERNOTNATURAL"));
        }
    }
}
