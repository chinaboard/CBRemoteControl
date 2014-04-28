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
        private ConcurrentDictionary<string, RemoteStatus> _RemoteInfoCache;
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
            _RemoteInfoCache = new ConcurrentDictionary<string, RemoteStatus>();
            Task.Factory.StartNew(() => GuardCache());
        }
        #endregion

        #region 方法
        public bool AddOrUpdateRemoteInfo(RemoteInfo remoteData ,out ActionType actionCode)
        {
            actionCode = ActionType.ServerSayHello;
            if (remoteData == null)
            {
                actionCode = ActionType.Reject;
                return false;
            }

            if (!_RemoteInfoCache.ContainsKey(remoteData.MachineGuid))
            {
                LogFormat.Write("Online", remoteData.MachineGuid);
                _RemoteInfoCache[remoteData.MachineGuid] = new RemoteStatus(remoteData);
            }

            if (_RemoteInfoCache[remoteData.MachineGuid].Status == StatusType.TransScreen)
                actionCode = ActionType.TransScreen;
            _RemoteInfoCache[remoteData.MachineGuid].SetRemoteData(remoteData);

            _RemoteInfoCache[remoteData.MachineGuid].RemoteData.SetAliveTime();

            return true;
        }

        public bool RemoveRemote(RemoteInfo remoteData)
        {
            RemoteStatus temp;
            return _RemoteInfoCache.TryRemove(remoteData.MachineGuid, out temp);
        }

        public List<RemoteInfo> GetRemoteList()
        {
            var list = new List<RemoteInfo>();
            foreach(var rData in _RemoteInfoCache.Values.ToList())
            {
                list.Add(rData.RemoteData);
            }
            return list;
        }
        public bool GetRemoteInfo(string remoteGuid, out RemoteInfo value)
        {
            RemoteStatus rData;
            value = null;
            if (_RemoteInfoCache.TryGetValue(remoteGuid, out rData))
            {
                value = rData.RemoteData;
                LogFormat.Write(Enum.GetName(typeof(StatusType), StatusType.TransScreen), rData.RemoteData.MachineGuid);
                _RemoteInfoCache[rData.RemoteData.MachineGuid].SetStatus(StatusType.TransScreen);
                return true;
            }
            return false;
        }
        #endregion

        #region 私有方法
        private void GuardCache()
        {
            while (true)
            {
                var list = _RemoteInfoCache.Values.ToList();
                foreach (var rData in list)
                {

                    if (DateTime.Now.Subtract(rData.ActionTime).Seconds > 20)
                    {
                        LogFormat.Write(Enum.GetName(typeof(StatusType),StatusType.HeartBeat), rData.RemoteData.MachineGuid);
                        _RemoteInfoCache[rData.RemoteData.MachineGuid].SetStatus();
                    }

                    if (DateTime.Now.Subtract(rData.RemoteData.AliveTime).TotalMinutes > 1)
                    {
                        RemoteStatus temp;
                        LogFormat.Write("Offline", rData.RemoteData.MachineGuid);
                        _RemoteInfoCache.TryRemove(rData.RemoteData.MachineGuid, out temp);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        #endregion
    }
}
