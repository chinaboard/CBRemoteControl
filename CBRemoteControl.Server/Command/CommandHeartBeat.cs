using CBRemoteControl.Model;
using CBRemoteControl.Server.Manager;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandHeartBeat
    {
        public static NetMQMessage Init(Package package,bool offline = false)
        {
            if(offline)
            {
                if (CacheManager.Instance.RemoveRemote(package.RemoteData))
                {
                    LogFormat.WriteLine(package.RemoteData.MachineGuid, "Offline");
                    return new Package(ActionType.ServerSayBye).Message;
                }
                return new Package(ActionType.Reject).Message;
            }

            if(CacheManager.Instance.AddOrUpdateRemoteInfo(package.RemoteData))
                return new Package(ActionType.TransPic).Message;

            return new Package(ActionType.Reject).Message;
            
        }
    }
}
