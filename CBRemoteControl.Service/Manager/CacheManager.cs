using CBRemoteControl.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }
        public bool AddOrUpdateServer(ServerData serverInfo)
        {
            if(serverInfo == null)
            {
                return false;
            }
            this._cache[serverInfo.MachineGuid] = serverInfo;
            return true;
        }
        public List<ServerData> GetServerList()
        {
            return this._cache.Values.ToList();
        }
    }
}
