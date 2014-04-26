using CBRemoteControl.Remote.Command;
using CBRemoteControl.Remote.Common;
using CBRemoteControl.Remote.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Remote.Services
{
    class LocalServices
    {
        #region 字段
        private NetMQContext _Context;
        private byte[] _NextPecketData;
        #endregion

        #region 方法
        public void Start()
        {
            Console.WriteLine(ConfigManager.Instance.MachineGuid);
            _Context = NetMQContext.Create();
            Client(_Context);
        }
        public void Stop()
        {
            if (_Context != null)
            {
                _Context.Dispose();
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
                _NextPecketData = CommandManager.Init();
                while (true)
                {
                    clientSocket.Send(_NextPecketData);
                    string answer = clientSocket.ReceiveString();
                    Console.WriteLine("Answer from server: {0}", answer);
                    Thread.Sleep(5000);

                    //如果拿到的指令无效，就发心跳
                    if (_NextPecketData == null || _NextPecketData.Length == 0)
                    {
                        HeartBeat(clientSocket);
                    }
                }
            }
        }

        private void HeartBeat(NetMQSocket clientSocket)
        {
            while (true)
            {
                clientSocket.Send(CommandManager.Init());
                string answer = clientSocket.ReceiveString();
                Console.WriteLine("Answer from server: {0}", answer);
                Thread.Sleep(5000);
            }
        }
        #endregion
    }
}
