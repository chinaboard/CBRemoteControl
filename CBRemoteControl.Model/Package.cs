using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class Package
    {
        public ActionType ActionCode { get; set; }
        public int HeartBeat { get; set; }
        public ServerData ServerInfo { get; set; }
        public Package()
        { 
        }
        public Package(ActionType actionCode,int heartBeat,ServerData serverInfo = null)
        {
            this.ActionCode = actionCode;
            this.HeartBeat = heartBeat;
            this.ServerInfo = serverInfo;
        }
    }
}
