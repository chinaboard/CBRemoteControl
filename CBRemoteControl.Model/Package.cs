using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class Package
    {
        #region 属性
        public ActionType ActionCode { get; set; }
        public int HeartBeat { get; set; }
        public ServerData ServerInfo { get; set; }
        #endregion

        #region 构造方法
        public Package()
        { 
        }
        public Package(ActionType actionCode,int heartBeat,ServerData serverInfo = null)
        {
            ActionCode = actionCode;
            HeartBeat = heartBeat;
            ServerInfo = serverInfo;
        }
        #endregion
    }
}
