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

namespace Magico.Reflection
{
    /// <summary>
    /// Tools for base classes
    /// </summary>
    public static class BaseClassTools
    {
        /// <summary>
        /// Gets the base types that a class inherits from
        /// </summary>
        /// <param name="sourceType">Source type to query the base classes</param>
        /// <returns>Type instances that contain information about base classes</returns>
        public static Type[] GetBaseTypes(Type sourceType)
        {
            List<Type> types = [];
            Type? baseType = sourceType.BaseType;
            while (baseType != null)
            {
                types.Add(baseType);
                baseType = baseType.BaseType;
            }
            return [.. types];
        }
    }
}
