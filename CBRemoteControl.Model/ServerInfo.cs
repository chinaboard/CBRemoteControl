using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CBRemoteControl.Model
{
    public class ServerData
    {
        public string MachineName { get; set; }
        public string MachineGuid { get; set; }
        public byte[] ScreenData { get; private set; }
        public DateTime AliveTime { get; private set; }
        public ServerData(string machineName,string machineGuid)
        {
            MachineName = machineName;
            MachineGuid = machineGuid;
        }
        public void SetScreen(byte[] screenData)
        {
            ScreenData = screenData;
        }
        public void SetAliveTime()
        {
            AliveTime = DateTime.Now;
        }
    }
}
