using CBRemoteControl.Model;
using CBRemoteControl.Remote.Manager;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Remote.Command
{
    class CommandManager
    {
        public static byte[] Init(Package package = null)
        {
            if (package == null)
            {
                return CommandHeartBeat.Init();
            }
            switch (package.ActionCode)
            {
                case ActionType.SayHeelo: return CommandHeartBeat.Init();
            }
            return CommandHeartBeat.Init();
        }

    }
}
