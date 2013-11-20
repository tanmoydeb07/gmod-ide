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
using AwesomePixel;

namespace GModIDE.Classes.LoadingTasks
{
    public class InitLanguage : LoadTask
    {

        /// <summary>
        /// Load languages, run AFTER any kind of first time setup
        /// </summary>
        public void Run()
        {
            //Import languages
            int imported = LanguageManager.LoadFromDirectory("loc");
            Utils.Log("Language Manager loaded " + imported.ToString() + " packs", LogType.INFO);

            //Load language
            try
            {
                String p = (string)SettingsManager.PrimarySettings["languagepack"];
                if (p == "") { return; }
                LanguageManager.Current = LanguageManager.Packs[p];
            }
            catch (Exception ex) { ErrorHandler.CreateError(ex, "An error occured while loading the language pack"); }
        }

        public string Name
        {
            get { return "Language Initalization"; }
            set { }
        }
    }
}
