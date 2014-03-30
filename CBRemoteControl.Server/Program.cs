using CBRemoteControl.Server.Common;
using CBRemoteControl.Server.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Topshelf;

namespace CBRemoteControl.Server
{
    static class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.Service<CBRCServerService>(c =>
                {
                    c.ConstructUsing(() => new CBRCServerService());
                    c.WhenStarted(d => d.Start());
                    c.WhenStopped(d => d.Stop());
                });

                x.SetDescription("CBRemoteControl被控服务器端");
                x.SetDisplayName("CBRemoteControl.Server");
                x.SetServiceName("CBRemoteControl.Server");

                x.RunAsLocalSystem();
                x.EnableShutdown();
                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                });

            });

            Console.ReadKey();
        }
    }
}
