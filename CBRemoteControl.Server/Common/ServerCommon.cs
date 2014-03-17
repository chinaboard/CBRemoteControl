using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Common
{
    public class ServerCommon
    {
        public int TimeSlice { get; private set; }
        public int HeartBeatTime { get; private set; }
        public string ServerName { get; private set; }
        public string ServerIP { get; private set; }
        public string ServerID { get; private set; }
        public bool IsOnline { get; private set; }
        public bool AutoStart { get; private set; }
        public ServerInfo CBServerInfo { get { return new ServerInfo(this.ServerName, this.ServerID); } }
        public static ServerCommon Instance { get; private set; }
        static ServerCommon()
        {
            Instance = new ServerCommon();
        }
        public void SetOnline(bool flag)
        {
            this.IsOnline = flag;
        }
        ServerCommon()
        {
            this.IsOnline = false;
            this.ServerName = System.Environment.MachineName;
            this.ServerIP = String.Empty;
            this.ServerID = ServerOpenID.getMNum();
            this.TimeSlice = 300 * 1000;
            this.HeartBeatTime = 5 * 1000;
        }
    }
}
