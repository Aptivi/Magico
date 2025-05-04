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
                throw new FileNotFoundException("File not found", path);

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
    }
}
