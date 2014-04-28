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
            var actionCode = ActionType.Reject;

            if(offline)
            {
                if (CacheManager.Instance.RemoveRemote(package.RemoteData))
                {
                    LogFormat.WriteLine("Offline", package.RemoteData.MachineGuid);
                    actionCode = ActionType.ServerSayBye;
                }
                return new Package(actionCode).Message;
            }

            CacheManager.Instance.AddOrUpdateRemoteInfo(package.RemoteData, out actionCode);

            return new Package(actionCode).Message;
            
        }
    }
}
