using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class LogFormat
    {
        public static void WriteLine(string contentA, string contentB)
        {
            Console.WriteLine(Format(contentA, contentB));
        }
        public static string Format(string contentA, string contentB)
        {
            return String.Format("{0} : {1} {2}", DateTime.Now.ToString("HH:mm:ss.fff"), contentA, contentB);
        }
    }
}
