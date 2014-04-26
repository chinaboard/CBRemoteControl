using CBRemoteControl.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Service.Manager
{
    class CacheManager
    {
        #region 字段
        private ConcurrentDictionary<string, ServerData> _ServerInfoCache;
        #endregion

        #region 属性
        public static CacheManager Instance;
        #endregion

        #region 构造方法
        static CacheManager()
        {
            Instance = new CacheManager();
        }
        CacheManager()
        {
            _ServerInfoCache = new ConcurrentDictionary<string, ServerData>();
            Task.Factory.StartNew(()=>GuardCache());
        }
        #endregion

        #region 方法
        public bool AddOrUpdateServerInfo(ServerData serverInfo)
        {
            if(serverInfo == null)
            {
                return false;
            }
            serverInfo.SetAliveTime();
            _ServerInfoCache[serverInfo.MachineGuid] = serverInfo;
            return true;
        }
        public List<ServerData> GetServerList()
        {
            return _ServerInfoCache.Values.ToList();
        }
        public ServerData GetServerInfo(string serverGuid)
        {
            ServerData value;
            _ServerInfoCache.TryGetValue(serverGuid, out value);
            return value;
        }
        #endregion

        #region 私有方法
        private void GuardCache()
        {
            while(true)
            {
                var list = _ServerInfoCache.Values.ToList();
                foreach(var sinfo in list)
                {
                    if (DateTime.Now.Subtract(sinfo.AliveTime).TotalMinutes > 1)
                    {
                        ServerData temp;
                        _ServerInfoCache.TryRemove(sinfo.MachineGuid, out temp);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
