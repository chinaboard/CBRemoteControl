using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    public class RemoteStatus
    {
        #region 属性
        public RemoteInfo RemoteData { get; private set; }
        public StatusType Status { get; private set; }
        public DateTime ActionTime { get; private set; }
        #endregion

        #region 构造方法
        public RemoteStatus(RemoteInfo remoteData,StatusType status = StatusType.HeartBeat)
        {
            RemoteData = remoteData;
            Status = status;
            ActionTime = remoteData.AliveTime;
        }
        #endregion

        #region 方法
        public void SetActionTime()
        {
            ActionTime = DateTime.Now;
        }
        public void SetRemoteData(RemoteInfo remoteData)
        {
            RemoteData = remoteData;
            RemoteData.SetAliveTime();
        }
        public void SetStatus(StatusType status = StatusType.HeartBeat)
        {
            Status = status;
            SetActionTime();
        }
        #endregion
    }
}
