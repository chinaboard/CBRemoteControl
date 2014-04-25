using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Model
{
    /// <summary>
    /// 动作指令
    /// </summary>
    public enum ActionType : int
    {
        SayHeelo = 0x00000000,
        TransPic = 0x10000000
    }
}
