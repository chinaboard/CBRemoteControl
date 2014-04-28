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
            //心跳
            if ((package.ActionCode & ActionType.SayHello) == ActionType.SayHello)
            {
                return CommandHeartBeat.Init(new Package(inMessage));
            }

            //要求被控端更新截屏
            //if ((package.ActionCode & ActionType.TransPic) == ActionType.TransPic)
            //{
            //    return CommandHeartBeat.Init(package);
            //}

            if ((package.ActionCode & ActionType.SayBye) == ActionType.SayBye)
            {
                return CommandHeartBeat.Init(new Package(inMessage), true);
            }

            //有关远程机器
            if ((package.ActionCode & ActionType.GetRemote) == ActionType.GetRemote)
            {
                return CommandRemoteInfo.Init(new Package(inMessage));
            }

            return new Package(ActionType.ServerSayHello).Message;
        }
    }
}
