using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CBRemoteControl.Service
{
    [ServiceContract]

    public interface IClientService
    {
        [OperationContract]
        Command PutCommand(ServerInfo clientInfo);
        [OperationContract]
        ScreenPackage GetScreen(string clientID);
        [OperationContract]
        List<ServerInfo> GetServerList();
        [OperationContract]
        int GetCacheCount();
    }
}
