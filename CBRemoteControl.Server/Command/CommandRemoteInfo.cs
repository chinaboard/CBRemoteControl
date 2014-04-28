using CBRemoteControl.Model;
using CBRemoteControl.Server.Manager;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandRemoteInfo
    {
        public static NetMQMessage Init(Package package)
        {
            var outMessage = new Package(ActionType.Reject).Message;

            switch (package.ActionCode)
            {
                case ActionType.GetRemoteInfo:
                    RemoteInfo remoteInfo;
                    if (CacheManager.Instance.GetRemoteInfo(package.RemoteData.MachineGuid, out remoteInfo))
                    {
                        outMessage = new Package(ActionType.GetRemoteInfo, remoteInfo).Message;
                        LogFormat.WriteLine("GetRemoteInfo : " + remoteInfo.MachineGuid, "Monitor");
                    }
                    break;
                case ActionType.GetRemoteList:
                    outMessage = new NetMQMessage();
                    outMessage.Append(Enum.GetName(typeof(ActionType), ActionType.GetRemoteList));
                    outMessage.Append(JsonSerialization.Object2Json(CacheManager.Instance.GetRemoteList()));
                    LogFormat.WriteLine("GetRemoteList", "Monitor");
                    break;
            }
            return outMessage;
        }
    }
}
