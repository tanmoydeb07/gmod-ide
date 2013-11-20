using System;
using GModIDE.PluginConnector;
using AwesomePixel;
using System.Drawing;

namespace GModIDE.Classes
{
    public class UtilsHost : IUtils
    {
        public void Log(string txt, ILogType typ, bool c = false)
        {
            AwesomePixel.LogType lt;
            bool a = Enum.TryParse<LogType>(Enum.GetName(typeof(ILogType), typ), out lt);

            if (a == false) { Utils.Log("Plugin API failed to log, enum conversion failed", LogType.FAIL); return; }

            Utils.Log(txt, lt, c);
        }

        public void Kill()
        {
            Utils.Kill();
        }

        public void Die(string err)
        {
            Utils.Die(err);
        }

        public void DieEx(string reason, Exception err)
        {
            Utils.DieEx(reason, err);
        }

        public Icon ToIcon(Bitmap img)
        {
            return SilkHandler.ToIcon(img);
        }
    }
}
