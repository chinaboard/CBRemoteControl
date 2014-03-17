using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBRemoteControl.Server.Common
{
    public static class InputScreen
    {
        public static ScreenPackage GetScreen()
        {
            var bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var g = Graphics.FromImage(bmp);
            g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), new Font("黑体", 20f), new SolidBrush(Color.Red), 0, 0);
            var sc = new ScreenPackage(BitmapToByte(bmp), ServerCommon.Instance.ServerID);
            bmp.Dispose();
            return sc;
        }

        private static Byte[] BitmapToByte(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            Bitmap temp = new Bitmap(bmp);
            temp.Save(ms, ImageFormat.Jpeg);
            Byte[] bytes = ms.ToArray();
            ms.Dispose();
            return bytes;

        }
    }
}
