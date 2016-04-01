using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Logger
    {
        public delegate void WriteHandler(string text);

        public static WriteHandler writer;
        public static void Error(string msg)
        {
            LogMessage(msg, "World.Error");
        }
        public static void Warning(string msg)
        {
            LogMessage(msg, "World.Warning");
        }
        public static void Info(string msg, string tag = "")
        {
            LogMessage(msg, tag);
        }
        public static void Log(string msg)
        {
            if (writer != null)
                writer(msg);
        }
        static void LogMessage(string msg, string tag)
        {
            string text = string.IsNullOrEmpty(tag) ? "[World.Info]" : "[World." + tag + ":]" + msg;
            Log(text);
        }
    }
}
