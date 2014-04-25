using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CBRemoteControl.Model
{
    [DataContract]
    public class CBRCServerInfo
    {
        [DataMember]
        public string ServerName { get; private set; }
        [DataMember]
        public string ServerIP { get; private set; }
        [DataMember]
        public string ServerID { get; private set; }
        public void SetServerIP(string serverIP)
        {
            this.ServerIP = serverIP;
        }

        public CBRCServerInfo(string serverName, string serverID)
        {
            this.ServerName = serverName;
            this.ServerIP = String.Empty;
            this.ServerID = serverID;
        }
    }
}
