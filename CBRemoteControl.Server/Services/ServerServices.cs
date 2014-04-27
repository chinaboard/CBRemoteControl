using CBRemoteControl.Server.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CBRemoteControl.Server.Services
{
    class ServerServices
    {
        #region 字段
        private NetMQContext _Context;
        private bool _ContextIsOpend;
        #endregion

        #region 方法
        public void Start()
        {
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            Server(_Context);
        }
        public void Stop()
        {
            if (_Context != null)
            {
                _ContextIsOpend = false;
                _Context.Terminate();
            }
        }
        #endregion

        #region 私有方法
        private void Server(NetMQContext context)
        {
            using (NetMQSocket serverSocket = context.CreateResponseSocket())
            {
                serverSocket.Bind(ConfigManager.Instance.LocalBind);

                while (true)
                {
                    if(!_ContextIsOpend)
                    {
                        return;
                    }
                    var message = serverSocket.ReceiveMessage();
                    foreach (var x in message)
                    {
                        Console.WriteLine(x.ConvertToString());
                    }

                    serverSocket.SendMessage(message);


                    //var message = serverSocket.Receive();
                    //var packet = new Packet(message);
                    //Console.WriteLine("Receive message {0}", packet.JsonStr);
                    //Package package  = new Package();
                    //package = Utility.JsonSerialization.Json2Object(packet.JsonStr,package.GetType()) as Package;
                    //CommandManager.Init(package);
                    //serverSocket.Send(String.Format("you are {0}",package.RemoteData.MachineName));

                }
            }
        }
        #endregion
    }
}
