using CBRemoteControl.Server.ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Service
{
    public class CBRCWCFService
    {
        public ServerServiceClient Client { get; private set; }
        public static CBRCWCFService Instance { get; private set; }
        static CBRCWCFService()
        {
            Instance = new CBRCWCFService();
        }
        CBRCWCFService()
        {
            this.Client = new ServerServiceClient();
        }
    }
}
