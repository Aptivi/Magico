//
// Magico  Copyright (C) 2023-2024  Aptivi
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
using System.Runtime.InteropServices;
using NativeLand;
using SpecProbe.Software.Platform;

namespace Magico.Native
{
    internal static class Initializer
    {
        internal static LibraryManager libManager;
        private static bool _initialized;
        private const string LibraryName = "libmagic";
        private const string LibraryGnuRxName = "libgnurx-0";

        internal static void InitializeNative()
        {
            if (_initialized)
                return;
            string libPath = GetLibraryPath(LibraryName);
            if (!File.Exists(libPath))
                throw new Exception($"Can't load magic library because it isn't found. Magic library was: {libPath}");
            libManager = new LibraryManager(
                new LibraryItem(Platform.Windows, Architecture.X86, new LibraryFile(libPath)),
                new LibraryItem(Platform.Windows, Architecture.X64, new LibraryFile(libPath)),
                new LibraryItem(Platform.Windows, Architecture.Arm64, new LibraryFile(libPath)),
                new LibraryItem(Platform.MacOS, Architecture.X64, new LibraryFile(libPath)),
                new LibraryItem(Platform.MacOS, Architecture.Arm64, new LibraryFile(libPath)),
                new LibraryItem(Platform.Linux, Architecture.X64, new LibraryFile(libPath)),
                new LibraryItem(Platform.Linux, Architecture.X86, new LibraryFile(libPath)),
                new LibraryItem(Platform.Linux, Architecture.Arm, new LibraryFile(libPath)),
                new LibraryItem(Platform.Linux, Architecture.Arm64, new LibraryFile(libPath)));
            if (PlatformHelper.IsOnWindows())
            {
                string gnuRxPath = GetLibraryPath(LibraryGnuRxName);
                if (File.Exists(gnuRxPath))
                {
                    var libManagerGnuRx = new LibraryManager(
                        new LibraryItem(Platform.Windows, Architecture.X64, new LibraryFile(gnuRxPath)),
                        new LibraryItem(Platform.Windows, Architecture.X86, new LibraryFile(gnuRxPath)),
                        new LibraryItem(Platform.Windows, Architecture.Arm64, new LibraryFile(gnuRxPath)));
                    libManagerGnuRx.LoadNativeLibrary();
                }
            }
            libManager.LoadNativeLibrary();
            _initialized = true;
        }

        private static string GetLibraryPath(string libraryName)
        {
            var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            string execPath = Path.GetDirectoryName(asm.Location) + "/";
            string nonSpecificRid =
                (PlatformHelper.IsOnWindows() ? "win-" :
                 PlatformHelper.IsOnMacOS() ? "osx-" :
                 PlatformHelper.IsOnUnix() ? "linux-" :
                 "freebsd-") + RuntimeInformation.OSArchitecture.ToString().ToLower();
            string directory = $"runtimes/{nonSpecificRid}/native/";
            string libName = $"{libraryName}{(PlatformHelper.IsOnWindows() ? ".dll" : PlatformHelper.IsOnMacOS() ? ".dylib" : ".so")}";
            string path = $"{execPath}{directory}{libName}";
            return path;
        }
    }
}
