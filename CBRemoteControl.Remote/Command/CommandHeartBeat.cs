using CBRemoteControl.Model;
using CBRemoteControl.Remote.Manager;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Remote.Command
{
    class CommandHeartBeat
    {
        public static NetMQMessage Init()
        {
            ActionType actionCode = ActionType.SayHeelo;
            var package = new Package(actionCode, ConfigManager.Instance.RemoteData);
            return package.Message;
        }
    }
}
