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

using SpecProbe.Platform;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;


#if !NETCOREAPP
using NativeLand;
using NativeLand.Tools;
#endif

namespace Magico.Native
{
    internal static class Initializer
    {
        private static bool _initialized;
        private const string LibraryName = "libmagic";
        private const string LibraryGnuRxName = "libgnurx-0";

        internal static void InitializeNative()
        {
            if (_initialized)
                return;
            string libPath = GetLibraryPath();
            if (!File.Exists(libPath))
                throw new Exception($"Can't load magic library because it isn't found. Magic library was: {libPath}");
#if NETCOREAPP
            NativeLibrary.SetDllImportResolver(typeof(Initializer).Assembly, ResolveLibrary);
#else
            var bytes = File.ReadAllBytes(GetLibraryPath());
            var libManager = new LibraryManager(
                new LibraryItem(Platform.Windows, Architecture.X86,
                    new LibraryFile("libmagic.dll", bytes)),
                new LibraryItem(Platform.Windows, Architecture.X64,
                    new LibraryFile("libmagic.dll", bytes)),
                new LibraryItem(Platform.MacOS, Architecture.X64,
                    new LibraryFile("libmagic.dylib", bytes)),
                new LibraryItem(Platform.Linux, Architecture.X64,
                    new LibraryFile("libmagic.so", bytes)),
                new LibraryItem(Platform.Linux, Architecture.X86,
                    new LibraryFile("libmagic.so", bytes)));
            libManager.LoadNativeLibrary();
            if (PlatformHelper.IsOnWindows())
            {
                string gnuRxPath = GetLibraryGnuRxPath();
                if (File.Exists(gnuRxPath))
                {
                    var bytesGnuRx = File.ReadAllBytes(gnuRxPath);
                    var libManagerGnuRx = new LibraryManager(
                        new LibraryItem(Platform.Windows, Architecture.X64,
                            new LibraryFile("libgnurx-0.dll", bytesGnuRx)));
                    libManagerGnuRx.LoadNativeLibrary();
                }
            }
#endif
            _initialized = true;
        }

        private static string GetLibraryPath()
        {
            var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            string execPath = Path.GetDirectoryName(asm.Location) + "/";
            string nonSpecificRid =
                (PlatformHelper.IsOnWindows() ? "win-" :
                 PlatformHelper.IsOnMacOS() ? "osx-" :
                 PlatformHelper.IsOnUnix() ? "linux-" :
                 "freebsd-") + RuntimeInformation.OSArchitecture.ToString().ToLower();
            string directory = $"runtimes/{nonSpecificRid}/native/";
            string libName = $"{LibraryName}{(PlatformHelper.IsOnWindows() ? ".dll" : PlatformHelper.IsOnMacOS() ? ".dylib" : ".so")}";
            string path = $"{execPath}{directory}{libName}";
            return path;
        }

#if !NETCOREAPP
        private static string GetLibraryGnuRxPath()
        {
            var asm = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            string execPath = Path.GetDirectoryName(asm.Location) + "/";
            string nonSpecificRid =
                (PlatformHelper.IsOnWindows() ? "win-" :
                 PlatformHelper.IsOnMacOS() ? "osx-" :
                 PlatformHelper.IsOnUnix() ? "linux-" :
                 "freebsd-") + RuntimeInformation.OSArchitecture.ToString().ToLower();
            string directory = $"runtimes/{nonSpecificRid}/native/";
            string libName = $"{LibraryGnuRxName}{(PlatformHelper.IsOnWindows() ? ".dll" : PlatformHelper.IsOnMacOS() ? ".dylib" : ".so")}";
            string path = $"{execPath}{directory}{libName}";
            return path;
        }
#endif

#if NETCOREAPP
        private static nint ResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            nint libHandle = nint.Zero;
            if (libraryName == LibraryName)
            {
                string path = GetLibraryPath();
                libHandle = NativeLibrary.Load(path);
            }
            return libHandle;
        }
#endif
    }
}
