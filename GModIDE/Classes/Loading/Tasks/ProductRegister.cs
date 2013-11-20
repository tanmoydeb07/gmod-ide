using System;
using AwesomePixel.Management;
using Microsoft.Win32;

namespace GModIDE.Classes.LoadingTasks
{
    public class ProductRegister : LoadTask
    {
        /// <summary>
        /// Load languages, run AFTER any kind of first time setup
        /// </summary>
        public void Run()
        {
            Product.CurrentProduct = new ProductInfo("com.killerlua.gide", "GMod IDE", "KillerLUA", 1, "1.0", 0)
            {
                Register = true,
                Update = true
            };
            Product.InstallPath = Environment.CurrentDirectory;
        }

        public string Name
        {
            get { return "Plugin Language Packs"; }
            set { }
        }
    }
}