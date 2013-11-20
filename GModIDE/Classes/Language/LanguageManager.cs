/*
   Garrys Mod IDE
   -----------------------------
   
   Copyright (C) 2012 Alan Doherty
   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
   to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
   and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
   
   - "YOU" as in, the "DOWNLOADER" of this software package, these conditions exclude the copyright holder
   - You may only sell this software when FULL profits go towards a registered charity of your choice
   - You may not redistribute this software on any website owned by Garry, Valve or Facepunch Studios
    
   The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
   IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GModIDE.Classes
{
    public static class LanguageManager
    {
        #region Static Stuff
        /// <summary>
        /// Has the manager been loaded yet
        /// </summary>
        public static bool HasLoaded { get; set; }

        /// <summary>
        /// Loaded packs
        /// </summary>
        public static Dictionary<String, LanguagePack> Packs { get; set; }

        /// <summary>
        /// The current language pack
        /// </summary>
        public static LanguagePack Current { get; set; }

        /// <summary>
        /// Add a pack to main list
        /// </summary>
        /// <param name="task"></param>
        public static void AddPack(LanguagePack pack)
        {
            if (Packs == null) { Packs = new Dictionary<string, LanguagePack>(); }

            Packs.Add(pack.Language, pack);
        }

        /// <summary>
        /// Load pack from bytes
        /// </summary>
        /// <param name="s">Bytes to load</param>
        public static void LoadFromBytes(byte[] s)
        {
            if (Packs == null) { Packs = new Dictionary<string, LanguagePack>(); }

            LanguagePack lp = LanguagePack.Load(s);
            Packs.Add(lp.Language, lp);
        }

        /// <summary>
        /// Load pack from file
        /// </summary>
        /// <param name="file">File to load</param>
        public static void LoadFromFile(String file)
        {
            if (!File.Exists(file))
            {
                throw new CannotLoadLanguagePack("Could not load Pack from file, input file missing!", LanguagePackErrorCode.FileMissing);
            }

            try
            {
                LoadFromBytes(File.ReadAllBytes(file));
            }
            catch (Exception ex)
            {
                throw new CannotLoadLanguagePack("Unable to open file", LanguagePackErrorCode.FileSystemError, ex);
            }
        }

        /// <summary>
        /// Load packs from directory
        /// </summary>
        /// <param name="path">The path to check</param>
        /// <param name="extension">The extension of language packs</param>
        /// <returns>The amount of packs loaded from directory</returns>
        public static int LoadFromDirectory(String path, String extension)
        {
            if (!Directory.Exists(path))
            {
                throw new CannotLoadLanguagePack("The directory provided to load packs from does not exist!", LanguagePackErrorCode.DirectoryMissing);
            }

            String[] files = Directory.GetFiles(path, "*." + extension, SearchOption.TopDirectoryOnly);

            if (files.Length == 0)
            {
                ErrorHandler.CreateWarning("There are no language packs in this directory!", "Whoops!");
                return 0;
            }

            return LoadFiles(files);
        }

        /// <summary>
        /// Load files
        /// </summary>
        /// <param name="files">The file paths</param>
        /// <returns></returns>
        private static int LoadFiles(String[] files)
        {
            foreach (String file in files)
            {
                LoadFromFile(file);
            }

            return 0;
        }

        /// <summary>
        /// Load without warnings
        /// </summary>
        /// <param name="path">The path to load</param>
        public static int LoadFromDirectory(String path)
        {
            String[] files = Directory.GetFiles(path, "*.lang", SearchOption.TopDirectoryOnly);

            if (files.Length == 0)
            {
                return 0;
            }

            LoadFiles(files);
            return files.Length;
        }

        /// <summary>
        /// Get language string from current pack
        /// </summary>
        /// <param name="key">Language Key</param>
        /// <returns>Language String</returns>
        public static String Get(String key)
        {
            if (Current == null) { return key; }
            return Current.Get(key);
        }

        /// <summary>
        /// Automagically fill in form controls with text
        /// </summary>
        /// <param name="w">Form</param>
        public static void HandleForm(Form w)
        {
            /* form title */
            w.Text = Get((string)w.Text);

            /* controls */
            if (w.Controls.Count > 0)
            {
                foreach (Control c in w.Controls) { c.Text = Get((string)c.Text); }
            }
        }
        #endregion
    }
}
