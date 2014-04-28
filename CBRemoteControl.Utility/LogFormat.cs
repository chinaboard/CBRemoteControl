using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class LogFormat
    {
        public static void WriteLine(string who, string what)
        {
            Console.WriteLine(Format(who, what));
        }
        public static string Format(string who, string what)
        {
            return String.Format("{0} : {1} {2}", DateTime.Now, who, what);
        }
    }
}
