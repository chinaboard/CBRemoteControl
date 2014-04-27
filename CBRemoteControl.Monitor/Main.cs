using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Common;
using CBRemoteControl.Monitor.Services;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CBRemoteControl.Monitor
{
    public partial class Main : Form
    {
        private static string test;
        public Main()
        {
            InitializeComponent();
            MonitorServices.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteList).Message);
            var xlist = JsonSerialization.Json2Object(xx.Last.ConvertToString(), typeof(List<RemoteInfo>)) as List<RemoteInfo>;
            foreach (var x in xlist)
            {
                this.textBox1.Text += x.MachineGuid + Environment.NewLine;
                test = x.MachineGuid;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteInfo, new RemoteInfo("xxx", test)).Message);

            var x = BitmapCommon.Byte2Bitmap(new Package(xx).RemoteData.ScreenData);
            if (x != null)
                this.pictureBox1.Image = x;
        }
    }
}
