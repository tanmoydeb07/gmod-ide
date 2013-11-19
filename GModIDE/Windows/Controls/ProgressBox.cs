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
using System.Windows.Forms;
using System.Drawing;

namespace GModIDE.Windows
{
    public class ProgressBox : Control
    {
        /// <summary>
        /// The maximum the progress bar can reach
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// The current value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Should an outline be drawn from ForeColor
        /// </summary>
        public bool DrawOutline { get; set; }

        /// <summary>
        /// The colour of the bar
        /// </summary>
        public Color BarColor { get; set; }

        public ProgressBox()
        {
            Maximum = 100;
            Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Declare stuff
            Graphics g = e.Graphics;
            Rectangle b = new Rectangle(e.ClipRectangle.Location, Size);

            if (Value > 0)
            {
                Rectangle b2;

                if (DrawOutline)
                {
                    b2 = new Rectangle(new Point(b.X + 1, b.Y + 1), new Size(b.Width - 2, b.Height - 2));
                }
                else
                {
                    b2 = new Rectangle(b.Location, new Size(b.Width, b.Height));
                }

                float percent = (Value / Maximum) * 100;
                int width = (int)Math.Floor(percent / 100 * b2.Width);

                g.FillRectangle(new SolidBrush(BarColor), b2);

                MessageBox.Show(percent.ToString() + ":" + width + ":" + b2.Width);
            }

            if (DrawOutline)
            {
                g.DrawRectangle(new Pen(new SolidBrush(ForeColor), 1), new Rectangle(b.Location, new Size(b.Width - 1, b.Height - 1)));
            }
        }
    }
}
