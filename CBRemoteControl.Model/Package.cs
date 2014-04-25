using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class Package
    {
        public ActionType ActionCode { get; private set; }
        public string MachineName { get; private set; }
        public int HeartBeat { get; private set; }
        public string ServerDomain { get; private set; }
        public string ServerPort { get; private set; }
        public string MachineGuid { get; private set; }

        public Package()
        {

        }
    }
}
