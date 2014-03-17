using CBRemoteControl.Server.ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Service
{
    public class WCFService
    {
        public ServerServiceClient Client { get; private set; }
        public static WCFService Instance { get; private set; }
        static WCFService()
        {
            Instance = new WCFService();
        }
        WCFService()
        {
            this.Client = new ServerServiceClient();
        }
    }
}
