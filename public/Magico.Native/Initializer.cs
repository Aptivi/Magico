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
using SpecProbe.Loader;
using SpecProbe.Software.Platform;

namespace Magico.Native
{
    internal static class Initializer
    {
        internal static LibraryManager? libManager;
        private static bool _initialized;
        private const string LibraryName = "libmagic";

        internal static void InitializeNative()
        {
            if (_initialized)
                return;
            string libPath = GetLibraryPath(LibraryName);
            if (!File.Exists(libPath))
                throw new Exception($"Can't load magic library because it isn't found. Magic library was: {libPath}");
            var architecture = PlatformHelper.GetArchitecture();
            if (architecture == Architecture.X86 || architecture == Architecture.Arm)
                throw new PlatformNotSupportedException("32-bit platforms are no longer supported.");
            libManager = new LibraryManager(new LibraryFile(libPath));
            if (PlatformHelper.IsOnWindows())
            {
                string gnuRxTrePath = GetLibraryPath("libsystre-0");
                string trePath = GetLibraryPath("libtre-5");
                string intlPath = GetLibraryPath("libintl-8");
                string convPath = GetLibraryPath("libiconv-2");
                var libManagerGnuRx = new LibraryManager(
                    new LibraryFile(convPath),
                    new LibraryFile(intlPath),
                    new LibraryFile(trePath),
                    new LibraryFile(gnuRxTrePath));
                libManagerGnuRx.LoadNativeLibrary();
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
