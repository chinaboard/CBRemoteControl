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
        public RemoteInfo RemoteData { get; set; }
        #endregion

        #region 构造方法
        public Package()
        { 
        }
        public Package(ActionType actionCode,int heartBeat,RemoteInfo remoteData = null)
        {
            ActionCode = actionCode;
            HeartBeat = heartBeat;
            RemoteData = remoteData;
        }
        #endregion
    }
}
