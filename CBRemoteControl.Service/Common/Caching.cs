using CBRemoteControl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;
using System.Threading;

namespace CBRemoteControl.Service.Common
{
    public class Caching
    {
        private ConcurrentDictionary<string, ServerInfo> serverInfoCache;
        private ConcurrentDictionary<string, ScreenPackage> serverScreenCache;
        public static Caching Instance { get; private set; }
        static Caching()
        {
            Instance = new Caching();
        }
        Caching()
        {
            this.serverInfoCache = new ConcurrentDictionary<string, ServerInfo>();
            this.serverScreenCache = new ConcurrentDictionary<string, ScreenPackage>();
        }

        #region ServerInfoCache
        public int GetServerCount()
        {
            return this.serverInfoCache.Count;
        }
        public List<ServerInfo> GetServerList()
        {
            var list = this.serverInfoCache.Values.ToList<ServerInfo>();
            return list;
        }
        public void SetServerInfo(ServerInfo obj)
        {
            if (obj == null)
            {
                return;
            }
            this.serverInfoCache[obj.ServerID] = obj;
        }
        public ServerInfo GetServerInfo(string serverID)
        {
            ServerInfo si = null;
            if (this.serverInfoCache.TryGetValue(serverID, out si))
            {
                return si;
            }
            return null;
        }
        #endregion

        #region ServerScreenCache
        public void SetServerScreen(ScreenPackage obj)
        {
            if (obj == null)
            {
                return;
            }
            this.serverScreenCache[obj.ServerID] = obj;
        }
        public ScreenPackage GetServerScreen(string serverID)
        {
            ScreenPackage sp = null;
            if (this.serverScreenCache.TryGetValue(serverID, out sp))
            {
                return sp;
            }
            return null;
        }
        #endregion

        #region CacheManage
        public void CacheTimeOut()
        {
            while (true)
            {
                Thread.Sleep(30000);
                this.serverInfoCache.Clear();
                int nowtime = DateTime.Now.Minute;
                if (nowtime > 45 && nowtime < 50)
                {
                    this.serverScreenCache.Clear();
                }
            }
        }
        #endregion

    }
}