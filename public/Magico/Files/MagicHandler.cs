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

using Magico.Native;
using Magico.Native.Interop;
using SpecProbe.Software.Platform;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Magico.Files
{
    /// <summary>
    /// Magic handling tools
    /// </summary>
	public static class MagicHandler
    {
        private const string magicFileName = "magic.mgc";
        private static readonly string magicPathDefault = Path.GetFullPath(magicFileName);

        /// <summary>
        /// libmagic version identification number
        /// </summary>
        public static int MagicVersionId
        {
            get
            {
                if (Initializer.libManager is null)
                    throw new MagicException("The native library is not initialized yet.");
                var @delegate = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_version>(nameof(MagicHelper.magic_version)) ??
                    throw new MagicException("Can't get delegate");
                return @delegate.Invoke();
            }
        }

        /// <summary>
        /// Gets the file magic paths
        /// </summary>
        /// <param name="magicPath">Magic path. If null, the libmagic library tries to find the magic database files.</param>
        /// <param name="systemWide">Uses system-wide magic path if <paramref name="magicPath"/> is null. This has no effect if that path is not null</param>
        /// <returns>A colon separated list of magic locations</returns>
        public static string[] GetMagicPaths(string? magicPath = null, bool systemWide = false)
        {
            // We need to make another magicPath handle, because if we directly passed the magicPath string, we'll get corrupt
            // string. We need to make a native handle to our string.
            if (Initializer.libManager is null)
                throw new MagicException("The native library is not initialized yet.");
            var @delegate = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_getpath>(nameof(MagicHelper.magic_getpath)) ??
                throw new MagicException("Can't get delegate");
            var magicPathHandle = !string.IsNullOrEmpty(magicPath) ? Marshal.StringToHGlobalAnsi(magicPath) : IntPtr.Zero;
            var pathsStringHandle = @delegate.Invoke(magicPathHandle, systemWide ? 1 : 0);
            string pathsString = Marshal.PtrToStringAnsi(pathsStringHandle) ?? "";

            // Dispose of our magic path handle
            if (magicPathHandle != IntPtr.Zero)
                Marshal.FreeHGlobal(magicPathHandle);

            // Now, separate the paths by colon. If on Windows, it'll never return more than one path.
            string[] paths = PlatformHelper.IsOnWindows() ? [pathsString] : pathsString.Split(':');
            return paths;
        }

        /// <summary>
        /// Gets the file magic information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicInfo(string filePath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            GetMagicInfo(filePath, magicPathDefault, parameter, paramValue);

        /// <summary>
        /// Gets the file magic information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="magicPath">Path to the file magic database</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicInfo(string filePath, string magicPath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            HandleMagic(filePath, !string.IsNullOrEmpty(magicPath) ? magicPath : magicPathDefault, MagicFlags.None, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicMimeInfo(string filePath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            GetMagicMimeInfo(filePath, magicPathDefault, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="magicPath">Path to the file magic database</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicMimeInfo(string filePath, string magicPath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            HandleMagic(filePath, !string.IsNullOrEmpty(magicPath) ? magicPath : magicPathDefault, MagicFlags.Mime, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime type information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicMimeType(string filePath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            GetMagicMimeType(filePath, magicPathDefault, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime type information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="magicPath">Path to the file magic database</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicMimeType(string filePath, string magicPath, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            HandleMagic(filePath, !string.IsNullOrEmpty(magicPath) ? magicPath : magicPathDefault, MagicFlags.MimeType, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime type information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="flags">Magic flags to customize the output and the behavior of the native library</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicCustomType(string filePath, MagicFlags flags, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            GetMagicCustomType(filePath, magicPathDefault, flags, parameter, paramValue);

        /// <summary>
        /// Gets the file magic Mime type information
        /// </summary>
        /// <param name="filePath">Target file path</param>
        /// <param name="magicPath">Path to the file magic database</param>
        /// <param name="flags">Magic flags to customize the output and the behavior of the native library</param>
        /// <param name="parameter">Parameter to use</param>
        /// <param name="paramValue">Parameter value to set to</param>
        public static string GetMagicCustomType(string filePath, string magicPath, MagicFlags flags, MagicParameters parameter = MagicParameters.None, int paramValue = 0) =>
            HandleMagic(filePath, !string.IsNullOrEmpty(magicPath) ? magicPath : magicPathDefault, flags, parameter, paramValue);

        internal static string HandleMagic(string filePath, string magicPath, MagicFlags flags, MagicParameters parameter = MagicParameters.None, int paramValue = 0)
        {
            nint magicStringHandle;

            // Check the paths
            if (!File.Exists(filePath))
                throw new MagicException($"Failed to load file from path {filePath} because it wasn't found.");
            if (!File.Exists(magicPath))
                throw new MagicException($"Failed to load magic file from path {magicPath} because it wasn't found.");

            // Now, let's go back to the dark side
            unsafe
            {
                // Open the magic handle
                if (Initializer.libManager is null)
                    throw new MagicException("The native library is not initialized yet.");
                var @delegate = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_open>(nameof(MagicHelper.magic_open)) ??
                    throw new MagicException("Can't get delegate");
                var handle = @delegate.Invoke(flags);

                // Check to see if we're going to set the parameter
                if (parameter != MagicParameters.None)
                {
                    var valuePtr = (nint)paramValue;
                    var valueHandle = Marshal.AllocHGlobal(IntPtr.Size);
                    var valueHandleResult = Marshal.AllocHGlobal(IntPtr.Size);
                    Marshal.WriteIntPtr(valueHandle, valuePtr);

                    // Set the parameter
                    var delegate2 = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_setparam>(nameof(MagicHelper.magic_setparam)) ??
                        throw new MagicException("Can't get delegate");
                    int paramResult = delegate2.Invoke(handle, parameter, valueHandle);
                    if (paramResult != 0)
                        throw new MagicException($"Failed to set parameter {parameter} to {paramValue}: [{MagicHelper.GetErrorNumber(handle)}] {MagicHelper.GetError(handle)}");

                    // Validate the parameter
                    nint result;
                    var delegate3 = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_getparam>(nameof(MagicHelper.magic_getparam)) ??
                        throw new MagicException("Can't get delegate");
                    int paramGetResult = delegate3.Invoke(handle, parameter, valueHandleResult);
                    if (paramGetResult != 0)
                        throw new MagicException($"Failed to get parameter {parameter} value: [{MagicHelper.GetErrorNumber(handle)}] {MagicHelper.GetError(handle)}");
                    result = Marshal.ReadIntPtr(valueHandleResult);
                    if (result != valuePtr)
                        throw new MagicException($"Failed to validate parameter {parameter} for value {paramValue} (got {result}): [{MagicHelper.GetErrorNumber(handle)}] {MagicHelper.GetError(handle)}");

                    // Free the addresses
                    Marshal.FreeHGlobal(valueHandle);
                    Marshal.FreeHGlobal(valueHandleResult);
                }

                // Use this handle to load the magic database
                var delegate4 = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_load>(nameof(MagicHelper.magic_load)) ??
                    throw new MagicException("Can't get delegate");
                int loadResult = delegate4.Invoke(handle, magicPath);
                if (loadResult != 0)
                    throw new MagicException($"Failed to load magic database file from path {magicPath}: [{MagicHelper.GetErrorNumber(handle)}] {MagicHelper.GetError(handle)}");

                // Now, get the magic
                var delegate5 = Initializer.libManager.GetNativeMethodDelegate<MagicHelper.magic_file>(nameof(MagicHelper.magic_file)) ??
                    throw new MagicException("Can't get delegate");
                magicStringHandle = delegate5.Invoke(handle, filePath);
                if (magicStringHandle == IntPtr.Zero)
                    throw new MagicException($"Failed to get magic of file {filePath} from magic database {magicPath}: [{MagicHelper.GetErrorNumber(handle)}] {MagicHelper.GetError(handle)}");
            }

            // Return the magic
            string magicString = Marshal.PtrToStringAnsi(magicStringHandle) ?? "";
            return magicString;
        }

        static MagicHandler()
        {
            // Initialize native library
            Initializer.InitializeNative();
        }
    }
}
