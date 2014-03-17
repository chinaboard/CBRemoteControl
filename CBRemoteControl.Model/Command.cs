using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CBRemoteControl.Model
{
    [DataContract]
    public enum Command : byte
    {
        SayHeelo = 0x00000000,
    }
}
