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
using System.Drawing;
using LanguagePacker;

namespace GModIDE.Classes
{
    public class SilkHandler
    {
        public static Icon ToIcon(Bitmap img, bool no_catch=false)
        {
            if (no_catch)
            {
                //Sometimes we don't want an error dialog if it fails
                return Icon.FromHandle(img.GetHicon());
            }

            try
            {
                return Icon.FromHandle(img.GetHicon());
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("The icon for the form seems to be corrupted!", "Oops!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Program.ForceQuit();
                return null;
            }
        }
    }
}
