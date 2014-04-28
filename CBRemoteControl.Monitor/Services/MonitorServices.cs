using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Manager;
using CBRemoteControl.Utility;
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
        private static NetMQSocket _MonitorSocket;
        #endregion

        #region 方法
        public static void Start()
        {
            LogFormat.Write("Monitor", "Start");
            _Context = NetMQContext.Create();
        }


        public static NetMQMessage Send(NetMQMessage outMessage)
        {
            using (var _MonitorSocket = _Context.CreateRequestSocket())
            {
                _MonitorSocket.Connect(ConfigManager.Instance.ServiceBind);
                NetMQMessage message = outMessage;
                _MonitorSocket.SendMessage(message);
                return _MonitorSocket.ReceiveMessage();
            }
        }
        #endregion
    }
}
