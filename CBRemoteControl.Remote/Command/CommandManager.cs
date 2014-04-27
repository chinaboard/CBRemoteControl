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
        public static NetMQMessage Init(NetMQMessage inMessage = null)
        {
            if (inMessage == null || inMessage.IsEmpty)
            {
                return new Package(ActionType.RemoteSayHeelo).Message;
            }

            var package = new Package(inMessage);

            //心跳
            if ((package.ActionCode & ActionType.SayHello) == ActionType.SayHello)
            {
                return CommandHeartBeat.Init();
            }

            //无动于衷
            CacheManager.Instance.AddCommand(inMessage);
            return CommandHeartBeat.Init();
        }

    }
}
