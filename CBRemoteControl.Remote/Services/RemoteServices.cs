using CBRemoteControl.Model;
using CBRemoteControl.Remote.Command;
using CBRemoteControl.Remote.Manager;
using CBRemoteControl.Utility;
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
        private NetMQSocket _ClientSocket;
        private bool _ContextIsOpend;
        #endregion

        #region 方法
        public void Start()
        {
            LogFormat.Write("Remote", "Start");
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            Task.Factory.StartNew(() => Client());
        }
        public void Stop()
        {
            if (_Context != null)
            {
                LogFormat.Write("Remote", "Stop");
                _ContextIsOpend = false;
                Send(new Package(ActionType.RemoteSayBye, ConfigManager.Instance.RemoteData).Message);
                _Context.Terminate();
            }
        }
        #endregion

        #region 私有方法
        private void Client()
        {
            NetMQMessage message = CommandManager.Init();
            while (true)
            {
                try
                {
                    message = CommandManager.Init(Send(message));
                    Thread.Sleep(ConfigManager.Instance.HeartBeat);
                }
                catch
                {
                    if (!_ContextIsOpend)
                        return;
                }
            }
        }

        private NetMQMessage Send(NetMQMessage outMessage)
        {
            using (_ClientSocket = _Context.CreateRequestSocket())
            {
                _ClientSocket.Connect(ConfigManager.Instance.ServiceBind);
                NetMQMessage message = outMessage;
                _ClientSocket.SendMessage(message);
                return _ClientSocket.ReceiveMessage();
            }
        }
        #endregion
    }
}
