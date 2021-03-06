﻿using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Common;
using CBRemoteControl.Monitor.Manager;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBRemoteControl.Monitor
{
    public partial class Main : Form
    {
        #region 字段
        public static RemoteInfo _NowSelected;
        #endregion
        public Main()
        {
            InitializeComponent();
            Task.Factory.StartNew(() => AutoRefresh());
        }
        #region 事件
        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => RefreshList());
        }
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView.SelectedItems.Count == 0)
                return;
            var info = this.listView.SelectedItems[0].Tag as RemoteInfo;
            SetRemoteInfo(info);

        }
        private void Main_Resize(object sender, EventArgs e)
        {
            this.splitContainer.SplitterDistance = 190;
            this.splitListContainer.SplitterDistance = 52;
            this.splitInfoContainer.SplitterDistance = 52;
        }

        #endregion

        #region 私有方法

        private void AutoRefresh()
        {
            while (true)
            {
                RefreshList();
                RefreshScreen();
                Thread.Sleep(ConfigManager.Instance.HeartBeat);
            }
        }
        private void RefreshList()
        {
            var remoteInfoList = RemoteCommon.Instance.RemoteInfoList;
            this.Invoke(new Action(() =>
            {
                if (this.listView.SelectedItems.Count != 0)
                    _NowSelected = this.listView.SelectedItems[0].Tag as RemoteInfo;
                this.listView.Items.Clear();
            }));
            if (remoteInfoList != null && remoteInfoList.Count > 0)
            {
                Dictionary<string, int> machineNameDict = new Dictionary<string, int>();
                foreach (var remoteInfo in remoteInfoList)
                {
                    if (!machineNameDict.ContainsKey(remoteInfo.MachineName))
                        machineNameDict[remoteInfo.MachineName] = -1;
                    if ((from p in remoteInfoList where p.MachineName.Equals(remoteInfo.MachineName) select p.MachineName).ToList().Count > 1)
                        machineNameDict[remoteInfo.MachineName]++;
                    ListViewItem lvi = new ListViewItem();
                    var tmp = new RemoteInfo(remoteInfo.MachineGuid, remoteInfo.MachineName);
                    tmp.MachineName = remoteInfo.MachineName + (machineNameDict[remoteInfo.MachineName] > 0 ? "(" + machineNameDict[remoteInfo.MachineName] + ")" : String.Empty);
                    lvi.SubItems[0].Text = tmp.MachineName;
                    lvi.Tag = tmp;
                    if (_NowSelected != null && tmp.MachineGuid.Equals(_NowSelected.MachineGuid))
                        lvi.Selected = true;
                    this.Invoke(new Action(() => this.listView.Items.Add(lvi)));
                }
            }
        }
        private void RefreshScreen()
        {
            if (_NowSelected != null)
            {
                SetRemoteInfo(_NowSelected);
            }
        }
        private void SetRemoteInfo(RemoteInfo remoteData)
        {
            remoteData = RemoteCommon.Instance.GetRemoteInfo(remoteData);
            if (remoteData == null)
                return;
            this.Invoke(new Action(() =>
                {
                    this.groupPicBox.Text = "Alive Time : " + remoteData.AliveTime.ToString();
                    this.labGuid.Text = remoteData.MachineGuid;
                    this.labName.Text = remoteData.MachineName;
                    SetPictureBox(remoteData.ScreenData);
                }));
        }
        private void SetPictureBox(byte[] bitmapData)
        {
            if (bitmapData == null)
                return;
            this.pictureBox.Image = BitmapCommon.Byte2Bitmap(bitmapData);
        }
        #endregion
    }
}
