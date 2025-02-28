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
    /// libmagic flags
    /// </summary>
    public enum MagicFlags
    {
        /// <summary>
        /// #define    MAGIC_NONE                    0x0000000
        /// </summary>
        None = 0x0,
        /// <summary>
        /// #define    MAGIC_DEBUG                   0x0000001
        /// </summary>
        Debug = 0x1,
        /// <summary>
        /// #define    MAGIC_SYMLINK                 0x0000002
        /// </summary>
        Symlink = 0x2,
        /// <summary>
        /// #define    MAGIC_COMPRESS                0x0000004
        /// </summary>
        Compress = 0x4,
        /// <summary>
        /// #define    MAGIC_DEVICES                 0x0000008
        /// </summary>
        Devices = 0x8,
        /// <summary>
        /// #define    MAGIC_MIME_TYPE               0x0000010
        /// </summary>
        MimeType = 0x10,
        /// <summary>
        /// #define    MAGIC_CONTINUE                0x0000020
        /// </summary>
        Continue = 0x20,
        /// <summary>
        /// #define    MAGIC_CHECK                   0x0000040
        /// </summary>
        Check = 0x40,
        /// <summary>
        /// #define    MAGIC_PRESERVE_ATIME          0x0000080
        /// </summary>
        PreserveAccessTime = 0x80,
        /// <summary>
        /// #define    MAGIC_RAW                     0x0000100
        /// </summary>
        Raw = 0x100,
        /// <summary>
        /// #define    MAGIC_ERROR                   0x0000200
        /// </summary>
        Error = 0x200,
        /// <summary>
        /// #define    MAGIC_MIME_ENCODING           0x0000400
        /// </summary>
        MimeEncoding = 0x400,
        /// <summary>
        /// #define    MAGIC_MIME                    (MAGIC_MIME_TYPE|MAGIC_MIME_ENCODING)
        /// </summary>
        Mime = MimeType | MimeEncoding,
        /// <summary>
        /// #define    MAGIC_APPLE                   0x0000800
        /// </summary>
        Apple = 0x800,
        /// <summary>
        /// #define    MAGIC_EXTENSION               0x1000000
        /// </summary>
        Extension = 0x1000000,
        /// <summary>
        /// #define    MAGIC_COMPRESS_TRANSP         0x2000000
        /// </summary>
        CompressTransp = 0x2000000,
        /// <summary>
        /// #define    MAGIC_NO_COMPRESS_FORK        0x4000000
        /// </summary>
        NoCompressFork = 0x4000000,
        /// <summary>
        /// #define    MAGIC_NODESC                  (MAGIC_EXTENSION|MAGIC_MIME|MAGIC_APPLE)
        /// </summary>
        NoDesc = Extension | Mime | Apple,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_COMPRESS       0x0001000
        /// </summary>
        NoCheckCompress = 0x0001000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_TAR            0x0002000
        /// </summary>
        NoCheckTar = 0x0002000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_SOFT           0x0004000
        /// </summary>
        NoCheckSoft = 0x0004000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_APPTYPE        0x0008000
        /// </summary>
        NoCheckAppType = 0x0008000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_ELF            0x0010000
        /// </summary>
        NoCheckElf = 0x0010000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_TEXT           0x0020000
        /// </summary>
        NoCheckText = 0x0020000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_CDF            0x0040000
        /// </summary>
        NoCheckCdf = 0x0040000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_CSV            0x0080000
        /// </summary>
        NoCheckCsv = 0x0080000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_TOKENS         0x0100000
        /// </summary>
        NoCheckTokens = 0x0100000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_ENCODING       0x0200000
        /// </summary>
        NoCheckEncoding = 0x0200000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_JSON           0x0400000
        /// </summary>
        NoCheckJson = 0x0400000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_SIMH           0x0800000
        /// </summary>
        NoCheckSimh = 0x0800000,
        /// <summary>
        /// #define    MAGIC_NO_CHECK_BUILTIN ...
        /// </summary>
        NoCheckBuiltin = NoCheckCompress | NoCheckTar | NoCheckSoft | NoCheckAppType | NoCheckElf | NoCheckText | NoCheckCsv | NoCheckCdf | NoCheckTokens | NoCheckEncoding | NoCheckJson | NoCheckSimh | 0,
    }
}
