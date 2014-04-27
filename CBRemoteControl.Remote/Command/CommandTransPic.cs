using CBRemoteControl.Model;
using CBRemoteControl.Remote.Common;
using CBRemoteControl.Remote.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Remote.Command
{
    class CommandTransPic
    {
        public static NetMQMessage Init()
        {
            ActionType actionCode = ActionType.RemoteSayHeelo;
            var remoteData = ConfigManager.Instance.RemoteData;
            remoteData.SetScreen(ScreenCommon.GetScreen());
            var package = new Package(actionCode, remoteData);
            return package.Message;
        }
    }
}
