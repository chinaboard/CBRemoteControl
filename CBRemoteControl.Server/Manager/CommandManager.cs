using CBRemoteControl.Model;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Manager
{
    class CommandManager
    {
        public static byte[] HeartBeat()
        {
            ActionType actionCode = ActionType.SayHeelo;
            var serverInfo = new ServerData(ConfigManager.Instance.MachineName, ConfigManager.Instance.MachineGuid);
            var package = new Package(actionCode, ConfigManager.Instance.HeartBeat, serverInfo);
            var jsonStr = JsonSerialization.Object2Json(package);
            var packet = new Packet(actionCode, jsonStr);
            return packet.GetPacketData();
        }
    }
}
