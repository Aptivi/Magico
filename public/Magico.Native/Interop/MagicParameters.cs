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

namespace Magico.Native.Interop
{
    /// <summary>
    /// Magic parameters
    /// </summary>
    public enum MagicParameters
    {
        /// <summary>
        /// No parameters
        /// </summary>
        None = -1,
        /// <summary>
        /// #define MAGIC_PARAM_INDIR_MAX		0
        /// </summary>
        InDirMax = 0,
        /// <summary>
        /// #define MAGIC_PARAM_NAME_MAX		1
        /// </summary>
        NameMax = 1,
        /// <summary>
        /// #define MAGIC_PARAM_ELF_PHNUM_MAX	2
        /// </summary>
        ElfPhnumMax = 2,
        /// <summary>
        /// #define MAGIC_PARAM_ELF_SHNUM_MAX	3
        /// </summary>
        ElfShnumMax = 3,
        /// <summary>
        /// #define MAGIC_PARAM_ELF_NOTES_MAX	4
        /// </summary>
        ElfNotesMax = 4,
        /// <summary>
        /// #define MAGIC_PARAM_REGEX_MAX		5
        /// </summary>
        RegexMax = 5,
        /// <summary>
        /// #define	MAGIC_PARAM_BYTES_MAX		6
        /// </summary>
        BytesMax = 6,
        /// <summary>
        /// #define	MAGIC_PARAM_ENCODING_MAX	7
        /// </summary>
        EncodingMax = 7,
        /// <summary>
        /// #define	MAGIC_PARAM_ELF_SHSIZE_MAX	8
        /// </summary>
        ElfShSizeMax = 8,
        /// <summary>
        /// #define	MAGIC_PARAM_MAGWARN_MAX		9
        /// </summary>
        MagWarnMax = 9,
    }
}
