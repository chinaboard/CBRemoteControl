﻿using CBRemoteControl.Model;
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
        private static NetMQSocket _MonitorSocket;
        #endregion

        #region 方法
        public static void Start()
        {
            _Context = NetMQContext.Create();
            _MonitorSocket = _Context.CreateRequestSocket();
            _MonitorSocket.Connect(ConfigManager.Instance.ServiceBind);
        }


        public static NetMQMessage Send(NetMQMessage outMessage)
        {
            _MonitorSocket.Connect(ConfigManager.Instance.ServiceBind);
            NetMQMessage message = outMessage;
            _MonitorSocket.SendMessage(message);
            return _MonitorSocket.ReceiveMessage();
        }
        #endregion
    }
}
