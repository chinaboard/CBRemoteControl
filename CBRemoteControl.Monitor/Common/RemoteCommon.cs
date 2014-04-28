using CBRemoteControl.Model;
using CBRemoteControl.Monitor.Services;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Monitor.Common
{
    class RemoteCommon
    {
        #region 属性
        public List<RemoteInfo> RemoteInfoList { get { return GetRemoteInfoList(); } }
        public static RemoteCommon Instance;
        #endregion

        #region 构造方法
        static RemoteCommon()
        {
            Instance = new RemoteCommon();
        }
        #endregion

        #region 方法
        public RemoteInfo GetRemoteInfo(RemoteInfo remoteData)
        {
            if (remoteData == null)
                return null;
            var receive = MonitorServices.Send(new Package(ActionType.GetRemoteInfo, remoteData).Message);
            return new Package(receive, false).RemoteData;
        }
        public RemoteInfo GetRemoteInfo(string machineGuid,bool hasScreen)
        {
            if (String.IsNullOrWhiteSpace(machineGuid))
                return null;
            var remoteData = RemoteInfoList.Where(p => p.MachineGuid == machineGuid).First();
            if (!hasScreen)
                return remoteData;
            var receive = MonitorServices.Send(new Package(ActionType.GetRemoteInfo, remoteData).Message);
            return new Package(receive, true).RemoteData;
        }
        #endregion

        #region 私有方法
        private List<RemoteInfo> GetRemoteInfoList()
        {
            var inMessage = MonitorServices.Send(new Package(ActionType.GetRemoteList).Message);
            return JsonSerialization.Json2Object(inMessage.Last.ConvertToString(), typeof(List<RemoteInfo>)) as List<RemoteInfo>;
        }
        #endregion
    }
}
