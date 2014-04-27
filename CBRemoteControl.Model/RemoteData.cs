using CBRemoteControl.Utility;
using System;

namespace CBRemoteControl.Model
{
    public class RemoteInfo
    {
        #region 属性
        public string MachineName { get; set; }
        public string MachineGuid { get; set; }
        public byte[] ScreenData { get; private set; }
        public DateTime AliveTime { get; private set; }
        #endregion

        #region 构造方法
        public RemoteInfo(string machineName,string machineGuid)
        {
            MachineName = machineName;
            MachineGuid = machineGuid;
        }
        #endregion

        #region 方法
        public void SetScreen(byte[] screenData)
        {
            ScreenData = screenData;
        }
        public void SetAliveTime()
        {
            AliveTime = DateTime.Now;
        }
        public override string ToString()
        {
            return JsonSerialization.Object2Json(this);
        }
        #endregion
    }
}
