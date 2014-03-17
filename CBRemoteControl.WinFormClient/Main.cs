using CBRemoteControl.WinFormClient.Service;
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

namespace CBRemoteControl.WinFormClient
{
    public partial class Main : Form
    {
        private string nowServerID;
        public Main()
        {
            InitializeComponent();
            Task.Factory.StartNew(() => GetServerList());
            Task.Factory.StartNew(() => RefreshScreen());
        }

        private void GetServerList()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        var xx = WCFService.Instance.Client.GetCacheCount();
                        var sp = WCFService.Instance.Client.GetServerList();
                        this.Invoke(new Action(() =>
                        {
                            this.lbCount.Text = xx.ToString();
                            this.listViewMain.Items.Clear();
                            if (sp != null && sp.Count > 0)
                            {
                                foreach (var x in sp)
                                {
                                    ListViewItem lvi = new ListViewItem();
                                    lvi.SubItems[0].Text = x.ServerName;
                                    lvi.SubItems.Add(x.ServerIP);
                                    lvi.SubItems.Add(x.ServerID);
                                    this.listViewMain.Items.Add(lvi);
                                }
                            }
                        }));
                    }
                    catch { }
                    Thread.Sleep(30000);
                }
            });
        }

        private void RefreshScreen()
        {
            while (true)
            {
                if (!String.IsNullOrWhiteSpace(nowServerID))
                {
                    GetScreen(this.nowServerID);
                }
                Thread.Sleep(30000);
            }
        }

        private void GetScreen(string serverID)
        {
            Task.Factory.StartNew(() =>
             {
                 try
                 {
                     var tmp = WCFService.Instance.Client.GetScreen(serverID);
                     this.Invoke(new Action(() =>
                     {
                         this.pictureBox.Image = Common.OutputScreen.OutScreen(tmp);
                     }));
                 }
                 catch { }
             });
        }

        private void listViewMain_DoubleClick(object sender, EventArgs e)
        {
            if(this.listViewMain.Items.Count == 0)
            {
                return;
            }
            try
            {
                int index = this.listViewMain.SelectedItems[0].SubItems.Count - 1;
                string serverID = this.listViewMain.SelectedItems[0].SubItems[index].Text;
                this.nowServerID = serverID;
                Task.Factory.StartNew(() => GetScreen(serverID));
            }
            catch { }
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => GetServerList());
        }
    }
}
