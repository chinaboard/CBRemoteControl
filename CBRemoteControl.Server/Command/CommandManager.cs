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
                return new Package(ActionType.ServerSayHell0).Message;
            }
            var package = new Package(inMessage);
            //心跳
            if ((package.ActionCode & ActionType.SayHello) == ActionType.SayHello)
            {
                return CommandHeartBeat.Init(package);
            }

            //要求被控端更新截屏
            //if ((package.ActionCode & ActionType.TransPic) == ActionType.TransPic)
            //{
            //    return CommandHeartBeat.Init(package);
            //}

            //有关远程机器
            if ((package.ActionCode & ActionType.GetRemote) == ActionType.GetRemote)
            {
                return CommandRemoteInfo.Init(package);
            }

            return new Package(ActionType.ServerSayHell0).Message;
        }
    }
}
