﻿using CBRemoteControl.Remote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace CBRemoteControl.Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<LocalServices>(c =>
                {
                    c.ConstructUsing(() => new LocalServices());
                    c.WhenStarted(d => d.Start());
                    c.WhenStopped(d => d.Stop());
                });

                x.SetDescription("CBRemoteControl被控服务器端");
                x.SetDisplayName("CBRemoteControl.Remote");
                x.SetServiceName("CBRemoteControl.Remote");

                x.RunAsLocalSystem();
                x.EnableShutdown();
                x.EnableServiceRecovery(rc =>
                {
                    rc.RestartService(1);
                });

            });
        }
    }
}