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

using Magico.Files;
using Magico.Native.Interop;
using System;
using System.IO;
using System.Linq;
using Terminaux.Colors.Data;
using Terminaux.Writer.ConsoleWriters;

namespace Magico.Console
{
    internal class Program
    {
        static int Main(string[] args)
        {
            bool systemwide = args.Contains("-s");
            bool verbose = args.Contains("-v");
            args = args.Except(["-s", "-v"]).ToArray();

            // Check the arguments
            if (args.Length == 0)
            {
                TextWriterColor.WriteColor("Please specify the path to the target file to analyze its magic number information.", ConsoleColors.Red);
                return 1;
            }

            // Now, check the file path for existence
            string path = args[0];
            if (!File.Exists(path))
            {
                TextWriterColor.WriteColor($"The target file {path} doesn't exist.", ConsoleColors.Red);
                return 2;
            }

            // Check for custom magic
            string customMagic = null;
            if (args.Length > 1)
            {
                customMagic = Path.GetFullPath(args[1]);
                if (string.IsNullOrEmpty(customMagic))
                    TextWriterColor.WriteColor("Custom magic file path not specified. Using the defaults...", ConsoleColors.Yellow);
                else
                {
                    if (!File.Exists(customMagic))
                    {
                        TextWriterColor.WriteColor($"The custom magic database file {customMagic} doesn't exist.", ConsoleColors.Red);
                        return 3;
                    }
                }
            }

            // Now, analyze the file!
            try
            {
                string[] magicPaths = MagicHandler.GetMagicPaths(customMagic);
                string[] magicPathsSystemwide = MagicHandler.GetMagicPaths(customMagic, true);
                string[] magicPathsProbed = MagicHandler.GetMagicPaths(null);
                string[] magicPathsProbedSystemwide = MagicHandler.GetMagicPaths(null, true);
                string finalPath = systemwide ? magicPathsProbedSystemwide[0] : File.Exists(magicPaths[0]) ? magicPaths[0] : File.Exists(customMagic) ? customMagic : "";
                if (verbose)
                {
                    TextWriterColor.WriteColor($"libmagic version {MagicHandler.MagicVersionId}", ConsoleColors.Green);
                    TextWriterColor.WriteColor("Magic paths:", ConsoleColors.White);
                    ListWriterColor.WriteList(magicPaths, false);
                    TextWriterColor.WriteColor("Magic paths (systemwide):", ConsoleColors.White);
                    ListWriterColor.WriteList(magicPathsSystemwide, false);
                    TextWriterColor.WriteColor("Magic paths (probed):", ConsoleColors.White);
                    ListWriterColor.WriteList(magicPathsProbed, false);
                    TextWriterColor.WriteColor("Magic paths (probed, systemwide):", ConsoleColors.White);
                    ListWriterColor.WriteList(magicPathsProbedSystemwide, false);
                    ListEntryWriterColor.WriteListEntry("Final path", string.IsNullOrEmpty(finalPath) ? "default path" : finalPath);
                    TextWriterColor.WriteColor("File info:", ConsoleColors.White);
                }
                string normalMagic = MagicHandler.GetMagicInfo(path, finalPath);
                ListEntryWriterColor.WriteListEntry("File description", normalMagic);
                if (verbose)
                {
                    string normalMimeInfo = MagicHandler.GetMagicMimeInfo(path, finalPath);
                    string normalMimeType = MagicHandler.GetMagicMimeType(path, finalPath);
                    string normalExtensions = MagicHandler.GetMagicCustomType(path, finalPath, MagicFlags.Extension);
                    string normalMimeEncoding = MagicHandler.GetMagicCustomType(path, finalPath, MagicFlags.MimeEncoding);
                    ListEntryWriterColor.WriteListEntry("File MIME info", normalMimeInfo);
                    ListEntryWriterColor.WriteListEntry("File MIME type", normalMimeType);
                    ListEntryWriterColor.WriteListEntry("File MIME encoding", normalMimeEncoding);
                    ListEntryWriterColor.WriteListEntry("Alternative extensions", normalExtensions);
                }
            }
            catch (Exception ex)
            {
                TextWriterColor.WriteColor($"The target file {path} can't be analyzed: {ex}", ConsoleColors.Red);
                return 2;
            }
            return 0;
        }
    }
}
