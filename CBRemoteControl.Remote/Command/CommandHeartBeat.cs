using CBRemoteControl.Model;
using CBRemoteControl.Remote.Manager;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Remote.Command
{
    class CommandHeartBeat
    {
        public static byte[] Init()
        {
            ActionType actionCode = ActionType.SayHeelo;
            var package = new Package(actionCode, ConfigManager.Instance.HeartBeat, ConfigManager.Instance.RemoteData);
            var jsonStr = JsonSerialization.Object2Json(package);
            var packet = new Packet(actionCode, jsonStr);
            return packet.PacketData;
        }
    }
}
