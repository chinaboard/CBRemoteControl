using CBRemoteControl.Model;
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
                    try
                    {
                        var receive = serverSocket.ReceiveMessage();
                        foreach (var x in receive)
                        {
                            Console.WriteLine(x.ConvertToString());
                        }
                        var message = new Package(ActionType.SayHeelo).Message;
                        serverSocket.SendMessage(message);
                    }
                    catch
                    {
                        if(!_ContextIsOpend)
                            return;
                    }
                }
            }
        }
        #endregion
    }
}
