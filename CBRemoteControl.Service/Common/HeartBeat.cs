using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBRemoteControl.Service.Common
{
    public static class HeartBeat
    {
        public static bool ServerInit(ServerInfo serverInfo)
        {
            if (serverInfo == null)
            {
                return false;
            }
            serverInfo.SetServerIP(ServiceCommon.GetServerIP());
            try
            {
                Caching.Instance.SetServerInfo(serverInfo);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}