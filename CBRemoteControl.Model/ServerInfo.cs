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
        public ServerData(string machineName,string machineGuid)
        {
            this.MachineName = machineName;
            this.MachineGuid = machineGuid;
        }
        public void SetScreen(byte[] screenData)
        {
            this.ScreenData = screenData;
        }
    }
}
