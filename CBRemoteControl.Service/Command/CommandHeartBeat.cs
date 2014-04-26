using CBRemoteControl.Model;
using CBRemoteControl.Service.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Service.Command
{
    class CommandHeartBeat
    {
        public static void Init(Package package)
        {
            CacheManager.Instance.AddOrUpdateRemoteInfo(package.RemoteData);
        }
    }
}
