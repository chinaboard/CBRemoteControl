﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace CBRemoteControl.Model
{
    [DataContract]
    public class CBRCServerScreen
    {
        [DataMember]
        public byte[] PicData { get; private set; }
        [DataMember]
        public string ServerID { get; private set; }
        public CBRCServerScreen(byte[] picData, string serverID)
        {
            this.PicData = picData;
            this.ServerID = serverID;
        }
    }
}
