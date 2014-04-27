using CBRemoteControl.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Server.Manager
{
    class CacheManager
    {
        #region 字段
        private ConcurrentDictionary<string, RemoteInfo> _RemoteInfoCache;
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
            _RemoteInfoCache = new ConcurrentDictionary<string, RemoteInfo>();
            Task.Factory.StartNew(()=>GuardCache());
        }
        #endregion

        #region 方法
        public bool AddOrUpdateRemoteInfo(RemoteInfo remoteData)
        {
            if(remoteData == null)
            {
                return false;
            }
            remoteData.SetAliveTime();
            if (!_RemoteInfoCache.ContainsKey(remoteData.MachineGuid))
                Console.WriteLine(String.Format("{0} : New Remote {1}", DateTime.Now, remoteData.MachineName));
            else
                Console.WriteLine(String.Format("{0} : Old Remote {1}", DateTime.Now, remoteData.MachineName));
            _RemoteInfoCache[remoteData.MachineGuid] = remoteData;
            return true;
        }
        public List<RemoteInfo> GetServerList()
        {
            return _RemoteInfoCache.Values.ToList();
        }
        public RemoteInfo GetServerInfo(string remoteGuid)
        {
            RemoteInfo value;
            _RemoteInfoCache.TryGetValue(remoteGuid, out value);
            return value;
        }
        #endregion

        #region 私有方法
        private void GuardCache()
        {
            while(true)
            {
                var list = _RemoteInfoCache.Values.ToList();
                foreach(var rData in list)
                {
                    if (DateTime.Now.Subtract(rData.AliveTime).TotalMinutes > 1)
                    {
                        RemoteInfo temp;
                        _RemoteInfoCache.TryRemove(rData.MachineGuid, out temp);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
