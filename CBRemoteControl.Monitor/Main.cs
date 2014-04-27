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
            if(xlist!=null && xlist.Count > 0)    
            {
                foreach (var x in xlist)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems[0].Text = x.MachineName;
                    lvi.Tag = x;
                    this.listView.Items.Add(lvi);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteInfo, new RemoteInfo(test, "xxx")).Message);

            var x = BitmapCommon.Byte2Bitmap(new Package(xx).RemoteData.ScreenData);
            if (x != null)
                this.pictureBox.Image = x;
        }
    }
}
