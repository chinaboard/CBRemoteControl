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
                return CommandHeartBeat.Init();
            }

            CacheManager.Instance.AddCommand(inMessage);

            var package = new Package(inMessage, true);

            //心跳
            if (Rule.Compare((int)package.ActionCode, (int)ActionType.SayHello))
            {
                return CommandHeartBeat.Init();
            }

            //扔截屏
            if (Rule.Compare((int)package.ActionCode, (int)ActionType.TransScreen))
            {
                return CommandTransScreen.Init();
            }

            //无动于衷
            return CommandHeartBeat.Init();
        }

    }
}
