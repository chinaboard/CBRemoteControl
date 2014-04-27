using CBRemoteControl.Model;
using CBRemoteControl.Server.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandHeartBeat
    {
        public static void Init(Package package)
        {
            CacheManager.Instance.AddOrUpdateRemoteInfo(package.RemoteData);
        }
    }
}
