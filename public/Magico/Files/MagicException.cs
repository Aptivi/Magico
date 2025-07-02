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

namespace Magico.Files
{
    /// <summary>
    /// Creates an instance of magic exception
    /// </summary>
    public class MagicException : Exception
    {
        /// <summary>
        /// Raises the libmagic exception
        /// </summary>
        public MagicException()
            : base(LanguageTools.GetLocalized("MAGICO_FILE_EXCEPTION_LIBMAGIC"))
        { }

        /// <summary>
        /// Raises the libmagic exception
        /// </summary>
        /// <param name="message">Message for additional info</param>
        public MagicException(string message)
            : base(message)
        { }

        /// <summary>
        /// Raises the libmagic exception
        /// </summary>
        /// <param name="message">Message for additional info</param>
        /// <param name="innerException">Inner exception for additional diagnostic info</param>
        public MagicException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
