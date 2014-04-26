using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Monitor.Common
{
    class BitmapCommon
    {
        public static Bitmap Byte2Bitmap(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            using (var ms = new MemoryStream(bytes))
            {
                var bmp = Image.FromStream(ms) as Bitmap;
                return bmp;
            }
        }
    }
}
