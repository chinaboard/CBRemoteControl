using CBRemoteControl.Model;
using CBRemoteControl.Utility;
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
                LogFormat.WriteLine(remoteData.MachineGuid, "Online");
            _RemoteInfoCache[remoteData.MachineGuid] = remoteData;
            return true;
        }

        public bool RemoveRemote(RemoteInfo remoteData)
        {
            RemoteInfo temp;
            return _RemoteInfoCache.TryRemove(remoteData.MachineGuid, out temp);
        }

        public List<RemoteInfo> GetRemoteList()
        {
            return _RemoteInfoCache.Values.ToList();
        }
        public bool GetRemoteInfo(string remoteGuid, out RemoteInfo value)
        {
            Console.WriteLine(String.Format("{0} : GetRemoteInfo {1}", DateTime.Now, remoteGuid));
            return _RemoteInfoCache.TryGetValue(remoteGuid, out value);
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
                        LogFormat.WriteLine(rData.MachineGuid, "Offline");
                        _RemoteInfoCache.TryRemove(rData.MachineGuid, out temp);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
