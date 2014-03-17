using CBRemoteControl.Model;
using CBRemoteControl.Server.Common;
using CBRemoteControl.Server.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBRemoteControl.Server
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.notifyIcon.Visible = true;
            this.btn_Start.Enabled = false;
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            Task.Factory.StartNew(() => ServerHeartBeat());
            Task.Factory.StartNew(() => UploadScreen());
        }

        private void UploadScreen()
        {
            while (true)
            {
                try
                {
                    if (ServerCommon.Instance.IsOnline)
                    {
                        var tmp = InputScreen.GetScreen();
                        WCFService.Instance.Client.PutScreen(tmp);
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
        private void ServerHeartBeat()
        {
            while (true)
            {
                try
                {
                    ServerCommon.Instance.SetOnline(WCFService.Instance.Client.HeartBeat(ServerCommon.Instance.CBServerInfo));
                    this.Invoke(new Action(() => this.lblNowTime.Text = DateTime.Now.ToString()));
                    Thread.Sleep(ServerCommon.Instance.HeartBeatTime);
                }
                catch
                {
                    Thread.Sleep(30000);
                }
            }
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => ServerHeartBeat());
            Task.Factory.StartNew(() => UploadScreen());
            this.btn_Start.Enabled = false;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip.Show(MousePosition.X, MousePosition.Y);
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
