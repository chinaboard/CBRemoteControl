using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CBRemoteControl.Monitor.Services
{
    class MonitorServices
    {
        #region 字段
        private static NetMQContext _Context;
        #endregion

        #region 方法
        public static void Start()
        {
            _Context = NetMQContext.Create();
        }


        public static NetMQMessage Send(NetMQMessage outMessage)
        {
            using (NetMQSocket clientSocket = _Context.CreateRequestSocket())
            {
                clientSocket.Connect(ConfigManager.Instance.ServiceBind);

                NetMQMessage message = outMessage;
                clientSocket.SendMessage(message);

                var receive = clientSocket.ReceiveMessage();

                return receive;
            }
        }
        #endregion
    }
}
