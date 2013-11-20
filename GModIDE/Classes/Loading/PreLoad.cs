using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomePixel;
using AwesomePixel.GUI;
using System.IO;
using GModIDE.Windows;

namespace GModIDE.Classes
{
    public static class PreLoad
    {
        /// <summary>
        /// Execute the pre-load stuff
        /// </summary>
        public static void Load()
        {
            /* folders */
            try
            {
                if (!Directory.Exists("logs")) { Directory.CreateDirectory("logs"); }
                if (!Directory.Exists("loc")) { Directory.CreateDirectory("loc"); }
                if (!Directory.Exists("data")) { Directory.CreateDirectory("data"); }
                if (!Directory.Exists("plugins")) { Directory.CreateDirectory("plugins"); }
            }
            catch (Exception ex) { Utils.DieEx("Unable to create core directories", ex); }

            /* logging */
            try { Utils.EnableLogging(); }
            catch (Exception ex)
            {
                Utils.DieEx("Error occured when trying to initialize logging", ex);
            }
            Utils.Log("Program started", LogType.INFO);

            /* primary settings */
            SettingsManager.Load();

            /* plugins */

            PluginManager.LoadPlugins();

            /* plugin load tasks */
            PluginManager.CompileLoadTasks();

            /* load screen */
            Exception su = new SplashScreen(GModIDE.Properties.Resources.splash, 3000).Size(new System.Drawing.Size(495, 236)).IsLoadScreen(true).LoadTasks(new Action(LoadManager.Execute)).Show();

            if (su != null) { ErrorHandler.CreateError(su, "An error occured during the loading stage"); }

            /* first time wizard */
            if ((bool)SettingsManager.PrimarySettings["first_time"] == true)
            {
                new FirstTimeWizard().ShowDialog();
                return;
            }
        }

        public static void Unload()
        {
            /* logging */
            if (Utils.LoggingEnabled()) { Utils.DisableLogging(); }


        }
    }
}
