using CBRemoteControl.Remote.Command;
using CBRemoteControl.Remote.Manager;
using NetMQ;
using System;
using System.Threading;

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
            Console.WriteLine(ConfigManager.Instance.MachineGuid);
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            //Client(_Context);
            HeartBeat(_Context);
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
                if (String.IsNullOrWhiteSpace(ConfigManager.Instance.ServiceBind))
                {
                    return;
                }

                clientSocket.Connect(ConfigManager.Instance.ServiceBind);
                _NextMessage = CommandManager.Init();

                while (true)
                {
                    clientSocket.SendMessage(_NextMessage);
                    string answer = clientSocket.ReceiveString();
                    Console.WriteLine("Answer from server: {0}", answer);
                    Thread.Sleep(5000);

                    //如果拿到的指令无效，就发心跳
                    if (_NextMessage == null || _NextMessage.IsEmpty)
                    {
                        _NextMessage = CommandManager.Init();
                    }
                }
            }
        }

        private void HeartBeat(NetMQContext context)
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

                        CacheManager.Instance.AddCommand(receive);

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
