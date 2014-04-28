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
        public static NetMQMessage Init(NetMQMessage inMessage)
        {
            if (inMessage == null || inMessage.IsEmpty)
            {
                return new Package(ActionType.ServerSayHello).Message;
            }
            var package = new Package(inMessage, false);
            //心跳
            if (Rule.Compare((int)package.ActionCode, (int)ActionType.SayHello))
            {
                return CommandHeartBeat.Init(package);
            }

            //要求被控端更新截屏
            //if ((package.ActionCode & ActionType.TransScreen) == ActionType.TransScreen)
            //{
            //    return CommandHeartBeat.Init(package);
            //}

            if (Rule.Compare((int)package.ActionCode, (int)ActionType.SayBye))
            {
                return CommandHeartBeat.Init(package, true);
            }

            //有关远程机器
            if (Rule.Compare((int)package.ActionCode, (int)ActionType.GetRemote))
            {
                return CommandRemoteInfo.Init(package);
            }

            return new Package(ActionType.ServerSayHello).Message;
        }
    }
}
