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
    class CommandManager
    {
        public static NetMQMessage Init(NetMQMessage message = null)
        {
            if (message == null || message.IsEmpty)
            {
                return CommandHeartBeat.Init();
            }
            var package = new Package(message);
            switch (package.ActionCode)
            {
                case ActionType.SayHeelo: return CommandHeartBeat.Init();
            }
            return CommandHeartBeat.Init();
        }

    }
}
