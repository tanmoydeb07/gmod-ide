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
using System.Drawing;

namespace GModIDE.Classes
{
    class Util
    {
        /// <summary>
        /// Covert the image to bytes
        /// </summary>
        /// <param name="imageIn">The image</param>
        /// <returns>Bytes (yum)</returns>
        public static byte[] ImageToBytes(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        /// <summary>
        /// Covert the bytes to image
        /// </summary>
        /// <param name="byteArrayIn">The bytes</param>
        /// <returns>Image (not yum)</returns>
        public static Image BytesToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        /// <summary>
        /// Returns if a image at the file is valid
        /// </summary>
        /// <param name="filePath">The file path</param>
        /// <returns>If the image is valid</returns>
        public static bool IsValidImage(string filePath)
        {
            return File.Exists(filePath) && IsValidImage(new FileStream(filePath, FileMode.Open, FileAccess.Read));
        }

        /// <summary>
        /// Returns if the image at the stream is valid
        /// </summary>
        /// <param name="imageStream">The stream to check</param>
        /// <returns>If the image is valid</returns>
        public static bool IsValidImage(Stream imageStream)
        {
            if (imageStream.Length > 0)
            {
                byte[] header = new byte[4];
                string[] imageHeaders = new[]{
                "\xFF\xD8",
                "BM",
                "GIF",
                Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71})};

                imageStream.Read(header, 0, header.Length);

                bool isImageHeader = imageHeaders.Count(str => Encoding.ASCII.GetString(header).StartsWith(str)) > 0;
                if (isImageHeader == true)
                {
                    try
                    {
                        Image.FromStream(imageStream).Dispose();
                        imageStream.Close();
                        return true;
                    }
                    catch
                    {

                    }
                }
            }

            imageStream.Close();
            return false;
        }
    }
}
