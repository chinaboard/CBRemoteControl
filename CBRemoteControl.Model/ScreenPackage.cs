using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace CBRemoteControl.Model
{
    [DataContract]
    public class ScreenPackage
    {
        [DataMember]
        public byte[] PicData { get; private set; }
        [DataMember]
        public string ServerID { get; private set; }
        public ScreenPackage(byte[] picData, string serverID)
        {
            this.PicData = picData;
            this.ServerID = serverID;
        }
    }
}
