using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    /// <summary>
    /// 动作指令
    /// </summary>
    public enum ActionType : byte
    {
        SayHeelo = 0x00,
        TransPic = 0x10
    }
}
