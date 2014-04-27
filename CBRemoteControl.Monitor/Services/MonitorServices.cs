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
        private static bool _ContextIsOpend;
        #endregion

        #region 属性
        public static NetMQSocket MonitorSocket;
        #endregion

        #region 方法
        public static void Start()
        {
            _Context = NetMQContext.Create();
            _ContextIsOpend = true;
            Server(_Context);
        }
        #endregion

        #region 私有方法
        private static void Server(NetMQContext context)
        {
            MonitorSocket = context.CreateResponseSocket();
            MonitorSocket.Bind(ConfigManager.Instance.ServiceBind);
        }
        #endregion
    }
}
