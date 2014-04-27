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

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteList).Message);
            var xlist = JsonSerialization.Json2Object(xx.Last.ConvertToString(), typeof(List<RemoteInfo>)) as List<RemoteInfo>;
            if (xlist != null && xlist.Count > 0)
            {
                this.listView.Items.Clear();
                Dictionary<string, int> machineNameDict = new Dictionary<string, int>();
                foreach (var x in xlist)
                {
                    if (!machineNameDict.ContainsKey(x.MachineName))
                        machineNameDict[x.MachineName] = -1;
                    var c = (from p in xlist where p.MachineName.Equals(x.MachineName) select p.MachineName).ToList();
                    if (c.Count > 1)
                        machineNameDict[x.MachineName]++;
                    ListViewItem lvi = new ListViewItem();
                    var tmp = new RemoteInfo(x.MachineGuid,x.MachineName);
                    tmp.MachineName = x.MachineName + (machineNameDict[x.MachineName] > 0 ? "(" + machineNameDict[x.MachineName] + ")" : String.Empty);
                    lvi.SubItems[0].Text = tmp.MachineName;
                    lvi.Tag = tmp;
                    this.listView.Items.Add(lvi);
                }
            }
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
