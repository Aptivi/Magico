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
using System.IO;
using System.Reflection;

namespace Magico.Reflection
{
    /// <summary>
    /// Common reflection tools
    /// </summary>
    public static class ReflectionCommon
    {
        /// <summary>
        /// If the specified file is a .NET assembly
        /// </summary>
        /// <param name="path">Absolute path to the assembly file</param>
        /// <param name="asmName">Assembly name</param>
        /// <returns>True if it's a real assembly; false otherwise</returns>
        public static bool IsDotnetAssemblyFile(string path, out AssemblyName? asmName)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException(LanguageTools.GetLocalized("MAGICO_REFLECTION_COMMON_EXCEPTION_FILENOTFOUND"), path);

            try
            {
                asmName = AssemblyName.GetAssemblyName(path);
                return true;
            }
            catch (BadImageFormatException)
            {
                asmName = null;
                return false;
            }
        }

        /// <summary>
        /// Checks to see if a specified type is numeric or not
        /// </summary>
        /// <typeparam name="T">Type to check</typeparam>
        /// <returns>True if numeric; false otherwise</returns>
        public static bool IsTypeNumeric<T>()
        {
            var thisType = typeof(T);
            if (thisType != typeof(byte) && thisType != typeof(sbyte) &&
                thisType != typeof(short) && thisType != typeof(ushort) &&
                thisType != typeof(int) && thisType != typeof(uint) &&
                thisType != typeof(long) && thisType != typeof(ulong) &&
#if NET8_0_OR_GREATER
                thisType != typeof(Int128) && thisType != typeof(UInt128) &&
#endif
                thisType != typeof(float) && thisType != typeof(double) && thisType != typeof(decimal))
                return false;
            return true;
        }
    }
}
