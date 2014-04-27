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
            this.splitContainer.SplitterDistance = 190;
            this.splitListContainer.SplitterDistance = 52;
            this.splitInfoContainer.SplitterDistance = 52;
            MonitorServices.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteList).Message);
            var xlist = JsonSerialization.Json2Object(xx.Last.ConvertToString(), typeof(List<RemoteInfo>)) as List<RemoteInfo>;
            if(xlist!=null && xlist.Count > 0)    
            {
                this.listView.Items.Clear();
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

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count == 0)
            {
                return;
            }
            try
            {
                var info = this.listView.SelectedItems[0].Tag as RemoteInfo;
                var receive = MonitorServices.Send(new Package(ActionType.GetRemoteInfo, info).Message);
                info = new Package(receive).RemoteData;
                SetRemoteInfo(info);
            }
            catch 
            { 
            }
        }

        private void SetRemoteInfo(RemoteInfo remoteData)
        {
            this.groupPicBox.Text = "Alive Time : " + remoteData.AliveTime.ToString();
            this.labGuid.Text = remoteData.MachineGuid;
            this.labName.Text = remoteData.MachineName;
            SetPictureBox(remoteData.ScreenData);
        }
        private void SetPictureBox(byte[] bitmapData)
        {
            if (bitmapData == null)
                return;
            var bmp = BitmapCommon.Byte2Bitmap(bitmapData);
            this.pictureBox.Image = bmp;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            this.splitContainer.SplitterDistance = 190;
            this.splitListContainer.SplitterDistance = 52;
            this.splitInfoContainer.SplitterDistance = 52;
        }
    }
}
