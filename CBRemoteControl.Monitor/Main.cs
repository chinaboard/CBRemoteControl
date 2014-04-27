using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Services;
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
            MonitorServices.MonitorSocket.SendMessage(new Package(ActionType.GetRemoteList).Message);
            var xx = MonitorServices.MonitorSocket.ReceiveMessage();
            MessageBox.Show(new Package(xx).ActionCode.ToString());
        }
    }
}
