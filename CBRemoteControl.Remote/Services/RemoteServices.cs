using CBRemoteControl.Model;
using CBRemoteControl.Remote.Command;
using CBRemoteControl.Remote.Manager;
using NetMQ;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Remote.Services
{
    class RemoteServices
    {
        #region 字段
        private NetMQContext _Context;
        private NetMQMessage _NextMessage;
        private bool _ContextIsOpend;
        #endregion

        #region 方法
        public void Start()
        {
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            Client(_Context);
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
        private void Client(NetMQContext context)
        {
            using (NetMQSocket clientSocket = context.CreateRequestSocket())
            {
                clientSocket.Connect(ConfigManager.Instance.ServiceBind);
                while (true)
                {
                    NetMQMessage message = CommandManager.Init();
                    try
                    {
                        
                        clientSocket.SendMessage(message);

                        var receive = clientSocket.ReceiveMessage();

                        message = CommandManager.Init(receive);

                        Thread.Sleep(2000);
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
