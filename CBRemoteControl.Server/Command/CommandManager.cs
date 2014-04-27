using CBRemoteControl.Model;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandManager
    {
        public static NetMQMessage Init(NetMQMessage message)
        {
            if (message == null || message.IsEmpty)
            {
                return new Package(ActionType.SayHeelo).Message;
            }
            var package = new Package(message);
            switch(package.ActionCode)
            {
                case ActionType.SayHeelo: 
                    CommandHeartBeat.Init(package);
                    return new Package(ActionType.SayHeelo).Message;
            }
            return new Package(ActionType.SayHeelo).Message;
        }
    }
}
