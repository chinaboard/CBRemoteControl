using CBRemoteControl.WinFormClient.ClientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.WinFormClient.Service
{
    public class WCFService
    {
        public ClientServiceClient Client { get; private set; }
        public static WCFService Instance { get; private set; }
        static WCFService()
        {
            Instance = new WCFService();
        }
        WCFService()
        {
            this.Client = new ClientServiceClient();
        }
    }
}
