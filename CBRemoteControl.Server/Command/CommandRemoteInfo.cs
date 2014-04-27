using CBRemoteControl.Model;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Server.Command
{
    class CommandRemoteInfo
    {
        public static NetMQMessage Init(Package package)
        {
            switch(package.ActionCode)
            {
                case ActionType.GetRemoteInfo:
                    return null;
                case ActionType.GetRemoteList:
                    return null;
            }
            return null;
        }
    }
}
