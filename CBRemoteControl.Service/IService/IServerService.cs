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

    public interface IServerService
    {

        [OperationContract]
        Command GetCommand(ServerInfo clientInfo);

        [OperationContract]
        void PutScreen(ScreenPackage sp);

        [OperationContract]
        bool HeartBeat(ServerInfo clientInfo);
    }
}
