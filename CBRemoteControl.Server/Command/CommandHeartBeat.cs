using CBRemoteControl.Model;
using CBRemoteControl.Server.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandHeartBeat
    {
        public static NetMQMessage Init(Package package)
        {
            CacheManager.Instance.AddOrUpdateRemoteInfo(package.RemoteData);
            return new Package(ActionType.TransPic).Message;
        }
    }
}
