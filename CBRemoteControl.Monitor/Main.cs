using CBRemoteControl.Model;
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
        public Main()
        {
            InitializeComponent();
            MonitorServices.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xx = MonitorServices.Send(new Package(ActionType.GetRemoteList).Message);
            var xlist = JsonSerialization.Json2Object(xx.Last.ConvertToString(), typeof(List<RemoteInfo>)) as List<RemoteInfo>;
            foreach(var x in xlist)
            {
                this.textBox1.Text += x.MachineGuid + Environment.NewLine;
            }
        }
    }
}
