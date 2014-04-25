﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CBRemoteControl.Model
{
    public class ServerInfo
    {
        public string ServerName { get; private set; }
        public string ServerIP { get; private set; }
        public string ServerID { get; private set; }
        public void SetServerIP(string serverIP)
        {
            this.ServerIP = serverIP;
        }

        public ServerInfo(string serverName, string serverID)
        {
            this.ServerName = serverName;
            this.ServerIP = String.Empty;
            this.ServerID = serverID;
        }
    }
}
