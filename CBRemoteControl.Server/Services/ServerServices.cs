using CBRemoteControl.Model;
using CBRemoteControl.Server.Command;
using CBRemoteControl.Server.Manager;
using CBRemoteControl.Utility;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            LogFormat.Write("Server", "Start");
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            Task.Factory.StartNew(() => Server());
        }
        public void Stop()
        {
            if (_Context != null)
            {
                LogFormat.Write("Server", "Stop");
                _ContextIsOpend = false;
                _Context.Terminate();
            }
        }
        #endregion

        #region 私有方法
        private void Server()
        {
            using (NetMQSocket serverSocket = _Context.CreateResponseSocket())
            {
                serverSocket.Bind(ConfigManager.Instance.LocalBind);

                while (true)
                {
                    try
                    {
                        var receive = serverSocket.ReceiveMessage();

                        var message = CommandManager.Init(receive);
                        serverSocket.SendMessage(message);
                    }
                    catch
                    {
                        if (!_ContextIsOpend)
                            return;
                    }
                }
            }
        }
        #endregion
    }
}
