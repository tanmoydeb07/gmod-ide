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
using System.IO.Compression;
using System.Drawing;

namespace GModIDE.Classes
{
    public class LanguagePack
    {
        /// <summary>
        /// The current version
        /// </summary>
        public static int LPVERSION = 1;

        /// <summary>
        /// Name of language pack
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Author
        /// </summary>
        public String Author { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public String Language { get; set; }

        /// <summary>
        /// A picture of the language (use silk icons flags)
        /// </summary>
        public Image Picture { get; set; }

        /// <summary>
        /// If this was loaded and tested
        /// </summary>
        public bool Valid { get; set; }

        /// <summary>
        /// String table
        /// </summary>
        public Dictionary<String, String> Table { get; set; }

        /// <summary>
        /// Retrieve a translation
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String Get(String name)
        {
            if (Table.ContainsKey(name.ToLower()))
            {
                return "[MISSING]";
            }

            return Table[name];
        }

        /// <summary>
        /// Change a translation
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Put(String name, String value)
        {
            Table[name] = value;
        }

        /// <summary>
        /// Save this pack
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>If it was a success</returns>
        public bool Save(String path)
        {
            return LanguagePack.Save(this, path);
        }

        /// <summary>
        /// Do not use unless LanguagePack.Load
        /// </summary>
        public LanguagePack()
        {
            Table = new Dictionary<string, string>();
        }

        /// <summary>
        /// Create a new language pack object
        /// </summary>
        /// <param name="name">e.g English</param>
        /// <param name="author">e.g John.B</param>
        /// <param name="language">e.g en-gb</param>
        /// <param name="flag">e.g FamFam Flags</param>
        public LanguagePack(String name, String author, String language, Image flag)
        {
            Name = name;
            Author = author;
            Language = language;
            Picture = flag;
            Table = new Dictionary<string, string>();
        }

        /// <summary>
        /// Load language pack from bytes
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static LanguagePack Load(byte[] s)
        {
            LanguagePack lp = null;
            BinaryReader br = null;

            byte[] o_data = null;

            try
            {
                o_data = Compressor.Decompress(s);
            }
            catch (Exception ex)
            {
                throw new CannotLoadLanguagePack("Cannot decompress language pack, " + ex.Message, LanguagePackErrorCode.CompressionError, ex);
            }

            try
            {
                br = new BinaryReader(new MemoryStream(o_data));

                short version = br.ReadInt16();

                if (version > LPVERSION)
                {
                    throw new CannotLoadLanguagePack("The language pack is newer than the pack reader in this program, update!", LanguagePackErrorCode.VersionHigher);
                }
                else if (version < LPVERSION)
                {
                    throw new CannotLoadLanguagePack("The language pack is old, use the Language Packer tool to upgrade it!", LanguagePackErrorCode.VersionLower);
                }

                lp = new LanguagePack();
                lp.Name = br.ReadString();
                lp.Author = br.ReadString();
                lp.Language = br.ReadString();

                int i_length = br.ReadInt32();

                byte[] image = br.ReadBytes(i_length);

                lp.Picture = Util.BytesToImage(image);

                int s_length = br.ReadInt32();
                lp.Table = new Dictionary<string, string>();

                for (int i = 1; i <= s_length; i++)
                {
                    lp.Table[br.ReadString()] = br.ReadString();
                }

                lp.Valid = true;
            }
            catch (Exception ex)
            {
                throw new CannotLoadLanguagePack("Language pack is corrupted, " + ex.Message, LanguagePackErrorCode.PackCorrupted, ex);
            }

            br.Close();
            return lp;
        }

        /// <summary>
        /// Load pack from file
        /// </summary>
        /// <param name="file">File to load</param>
        public static LanguagePack LoadFromFile(String file)
        {
            if (!File.Exists(file))
            {
                throw new CannotLoadLanguagePack("Could not load Pack from file, input file missing!", LanguagePackErrorCode.FileMissing);
            }

            try
            {
                return Load(File.ReadAllBytes(file));
            }
            catch (Exception ex)
            {
                throw new CannotLoadLanguagePack("Unable to open file", LanguagePackErrorCode.FileSystemError, ex);
            }
        }

        /// <summary>
        /// Save language pack
        /// </summary>
        /// <param name="pack">Language Pack</param>
        /// <param name="path">The location to save</param>
        /// <returns>If it was a success</returns>
        public static bool Save(LanguagePack pack, String path)
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            byte[] buffer;

            //Try and open the path for writing
            try
            {
                fs = new FileStream(path, FileMode.Create);
                bw = new BinaryWriter(fs);
            }
            catch (Exception ex)
            {
                throw new CannotLoadLanguagePack("Unable to open the path target for writing!", LanguagePackErrorCode.FileSystemError, ex);
            }

            try
            {
                byte[] image = Util.ImageToBytes(pack.Picture);

                bw.Write((Int16)LPVERSION);
                bw.Write(pack.Name);
                bw.Write(pack.Author);
                bw.Write(pack.Language);

                bw.Write((Int32)image.Length);
                bw.Write(image, 0, image.Length);

                //Write strings
                bw.Write((Int32)pack.Table.Count);

                foreach (KeyValuePair<String, String> entry in pack.Table)
                {
                    bw.Write(entry.Key);
                    bw.Write(entry.Value);
                }

                bw.Close();

                buffer = File.ReadAllBytes(path);
                File.Delete(path);
                File.WriteAllBytes(path, Compressor.Compress(buffer));

                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (File.Exists(path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch (Exception ex2)
                    {
                        throw new CannotLoadLanguagePack("Could not remove buffer!", LanguagePackErrorCode.FileSystemError, ex2);
                    }
                }
                throw new CannotLoadLanguagePack("Unable to create the language pack!", LanguagePackErrorCode.PackCorrupted, ex);
            }
        }
    }
}
