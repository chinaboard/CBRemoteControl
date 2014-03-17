using CBRemoteControl.Model;
using CBRemoteControl.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;


namespace CBRemoteControl.Service
{
    public class ClientService : IClientService
    {
        public Command PutCommand(ServerInfo serverInfo)
        {
            return Command.SayHeelo;
        }

        public ScreenPackage GetScreen(string serverID)
        {
            var sp = Common.Caching.Instance.GetServerScreen(serverID);
            return sp;
        }

        public List<ServerInfo> GetServerList()
        {
            var list = Common.Caching.Instance.GetServerList();
            return list;
        }

        public int GetCacheCount()
        {
            return Common.Caching.Instance.GetServerCount();
        }
    }
}
