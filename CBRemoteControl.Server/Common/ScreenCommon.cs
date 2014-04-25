using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBRemoteControl.Server.Common
{
    class ScreenCommon
    {
        #region 方法

        #endregion

        #region 私有方法
        public static void GetScreen()
        {
            var screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var g = Graphics.FromImage(screen);
            g.CopyFromScreen(0, 0, 0, 0, screen.Size);
            //g.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), new Font("黑体", 20f), new SolidBrush(Color.Red), 0, 0);
            //var sc = new ScreenPackage(BitmapToByte(bmp), ServerCommon.Instance.ServerID);
            BitmapToByte(screen);
            screen.Dispose();
            
        }
        private static byte[] BitmapToByte(Bitmap bmp)
        {
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            bmp.Save(String.Format(@"z:\data\{0}.jpg",DateTime.Now.Ticks), ImageFormat.Jpeg);
            return ms.ToArray();
        }
        #endregion
    }
}
