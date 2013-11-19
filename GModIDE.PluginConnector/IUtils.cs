using System;
using System.Drawing;

namespace GModIDE.PluginConnector
{
    public interface IUtils
    {
        void Log(String txt, ILogType typ, bool c);
        void Kill();
        void Die(String err);
        void DieEx(String reason, Exception err);
        Icon ToIcon(Bitmap img);
    }

    public enum ILogType
    {
        ERROR,
        SUCCESS,
        FAIL,
        INFO
    }
}
