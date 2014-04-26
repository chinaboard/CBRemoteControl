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
        private ConcurrentDictionary<string, ServerData> _cache;
        public static CacheManager Instance;
        static CacheManager()
        {
            Instance = new CacheManager();
        }
        CacheManager()
        {
            _cache = new ConcurrentDictionary<string, ServerData>();
            Task.Factory.StartNew(()=>GuardCache());
        }
        public bool AddOrUpdateServerInfo(ServerData serverInfo)
        {
            if(serverInfo == null)
            {
                return false;
            }
            serverInfo.SetAliveTime();
            _cache[serverInfo.MachineGuid] = serverInfo;
            return true;
        }
        public List<ServerData> GetServerList()
        {
            return _cache.Values.ToList();
        }
        public ServerData GetServerInfo(string serverGuid)
        {
            ServerData value;
            _cache.TryGetValue(serverGuid, out value);
            return value;
        }

        private void GuardCache()
        {
            while(true)
            {
                var list = _cache.Values.ToList();
                foreach(var sinfo in list)
                {
                    if (DateTime.Now.Subtract(sinfo.AliveTime).TotalMinutes > 1)
                    {
                        ServerData temp;
                        _cache.TryRemove(sinfo.MachineGuid, out temp);
                    }
                }
                Thread.Sleep(1000);
            }
        }


    }
}
