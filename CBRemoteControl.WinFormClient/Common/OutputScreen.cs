using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CBRemoteControl.WinFormClient.Common
{
    public static class OutputScreen
    {
        public static Bitmap OutScreen(ScreenPackage sp)
        {
            if (sp == null || sp.PicData == null)
            {
                return null;
            }
            return ByteToBitmap(sp.PicData);
        }
        private static Bitmap ByteToBitmap(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = (Bitmap)Image.FromStream(ms);
            ms.Close();
            return bm;
        }
    }
}
