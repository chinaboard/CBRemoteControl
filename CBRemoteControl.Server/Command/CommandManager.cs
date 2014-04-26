using CBRemoteControl.Model;
using CBRemoteControl.Server.Manager;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandManager
    {
        public static byte[] HeartBeat()
        {
            ActionType actionCode = ActionType.SayHeelo;
            var package = new Package(actionCode, ConfigManager.Instance.HeartBeat, ConfigManager.Instance.ServerInfo);
            var jsonStr = JsonSerialization.Object2Json(package);
            var packet = new Packet(actionCode, jsonStr);
            return packet.PacketData;
        }
    }
}
