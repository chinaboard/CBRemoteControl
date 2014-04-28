using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class LogFormat
    {
        public static void Write(string contentA, string contentB)
        {
            var content = Format(contentA, contentB);
            Console.WriteLine(content);
            WriteFile(content);
        }
        public static string Format(string contentA, string contentB)
        {
            return String.Format("{0} : {1} {2}", DateTime.Now.ToString("HH:mm:ss"), contentA, contentB);
        }

        private static void WriteFile(string content)
        {
            var filename = DateTime.Now.ToString("yyyyMMdd") + ".txt";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, filename);
            File.AppendAllText(path, content + Environment.NewLine);
        }
    }
}
