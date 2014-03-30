using CBRemoteControl.Model;
using CBRemoteControl.Server.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CBRemoteControl.Server.Common
{
    public static class ScreenCommon
    {
        #region 方法
        public static void UploadScreen()
        {
            while (true)
            {
                try
                {
                    if (ServerCommon.Instance.IsOnline)
                    {
                        Console.WriteLine("true");
                        var tmp = ScreenCommon.GetScreen();
                        CBRCWCFService.Instance.Client.PutScreen(tmp);
                        Thread.Sleep(ServerCommon.Instance.TimeSlice);
                    }
                    else
                    {
                        Thread.Sleep(10000);
                    }
                }
                catch
                {
                    Thread.Sleep(30000);
                }
            }
        }
        public static void ServerHeartBeat()
        {
            while (true)
            {
                try
                {
                    ServerCommon.Instance.SetOnline(CBRCWCFService.Instance.Client.HeartBeat(ServerCommon.Instance.CBServerInfo));
                    Thread.Sleep(ServerCommon.Instance.HeartBeatTime);
                }
                catch
                {
                    Thread.Sleep(30000);
                }
            }
        }
        #endregion

        #region 私有方法
        private static ScreenPackage GetScreen()
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
        #endregion
    }
}
