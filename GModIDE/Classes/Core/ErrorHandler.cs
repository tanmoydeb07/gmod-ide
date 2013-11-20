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
using GModIDE.Windows.Dialogs;

namespace GModIDE.Classes
{
    public class ErrorHandler
    {
        /// <summary>
        /// Create fatal error
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="SimpleDesc">A simple description</param>
        /// <param name="ID">Error ID if available</param>
        public static void CreateError(Exception e, String SimpleDesc, int ID=0)
        {
            foreach(System.Windows.Forms.Form frm in System.Windows.Forms.Application.OpenForms) {
                try
                {
                    System.Windows.Forms.Panel p = new System.Windows.Forms.Panel();
                    frm.Controls.Add(p);
                    p.BackColor = System.Drawing.Color.Red;
                    p.Size = frm.Size;
                    p.BringToFront();
                }
                catch (Exception) { }
            }

            new ErrorDialog().ShowError(e, SimpleDesc, ID);
        }

        public static void CreateStub(String name, String explanation = "Feature not ready yet!")
        {
            new StubDialog().ShowStub(name, explanation);
        }

        /// <summary>
        /// Create a minor error
        /// </summary>
        /// <param name="msg">The error's message</param>
        public static void CreateError(String msg) 
        {
            System.Windows.Forms.MessageBox.Show(msg, "Oops!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

        /// <summary>
        /// Create a warning
        /// </summary>
        /// <param name="msg">The warning's message</param>
        public static void CreateWarning(String msg, String caption="Warning!")
        {
            System.Windows.Forms.MessageBox.Show(msg, caption, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
        }
    }
}
