using CBRemoteControl.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Server.Service
{
    public class CBRCServerService
    {
        public void Start()
        {
            Task.Factory.StartNew(() => ScreenCommon.ServerHeartBeat());
            Task.Factory.StartNew(() => ScreenCommon.UploadScreen());
        }

        public void Stop()
        {

        }

    }
}
