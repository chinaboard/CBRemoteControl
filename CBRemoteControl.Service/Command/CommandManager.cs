using CBRemoteControl.Model;
using CBRemoteControl.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Service.Command
{
    class CommandManager
    {
        public static void Init(Package package)
        {
            if(package == null)
            {
                return;
            }
            switch(package.ActionCode)
            {
                case ActionType.SayHeelo: CommandHeartBeat.Init(package); break;
            }
        }
    }
}
