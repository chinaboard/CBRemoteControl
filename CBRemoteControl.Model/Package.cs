using CBRemoteControl.Utility;
using NetMQ;
using System;

namespace CBRemoteControl.Model
{
    public class Package
    {
        #region 字段
        private NetMQMessage _Message;
        #endregion
        #region 属性
        public ActionType ActionCode { get; private set; }
        public RemoteInfo RemoteData { get; private set; }
        public NetMQMessage Message { get { return _Message; } }
        #endregion

        #region 构造方法

        public Package(NetMQMessage message)
        {
            if (message == null)
                return;
            _Message = message;
            ActionCode = (ActionType)Enum.Parse(typeof(ActionType), message.First.ConvertToString());
            if(message.FrameCount > 1)
                RemoteData = JsonSerialization.Json2Object(message[1].ConvertToString(), typeof(RemoteInfo)) as RemoteInfo;
        }
        public Package(ActionType actionCode, RemoteInfo remoteData = null)
        {
            ActionCode = actionCode;
            RemoteData = remoteData;

            _Message = new NetMQMessage();
            _Message.Append(Enum.GetName(typeof(ActionType), ActionCode));
            if (RemoteData != null)
                _Message.Append(RemoteData.ToString());
        }
        #endregion
    }
}
