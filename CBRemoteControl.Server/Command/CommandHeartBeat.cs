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
        public static NetMQMessage Init(Package package,bool offline = false)
        {
            if(offline)
            {
                if (CacheManager.Instance.RemoveRemote(package.RemoteData))
                {
                    Console.WriteLine(String.Format("{0} : Say Bye {1}", DateTime.Now, package.RemoteData.MachineName));
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
