using NetMQ;

namespace CBRemoteControl.Model
{
    public class Package
    {
        #region 属性
        public ActionType ActionCode { get; private set; }
        public RemoteInfo RemoteData { get; private set; }
        public NetMQMessage Message { get { return GetMessage(); } }
        #endregion

        #region 构造方法
        public Package(ActionType actionCode, RemoteInfo remoteData = null)
        {
            ActionCode = actionCode;
            RemoteData = remoteData;
        }
        #endregion

        #region 私有方法
        private NetMQMessage GetMessage()
        {
            var message = new NetMQMessage();
            message.Append(ActionCode.ToString());
            if (RemoteData != null)
                message.Append(RemoteData.ToString());
            return message;
        }
        #endregion
    }
}
