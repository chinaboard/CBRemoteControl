﻿using CBRemoteControl.Remote.Services;
using Topshelf;

namespace CBRemoteControl.Remote
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<RemoteServices>(c =>
                {
                    c.ConstructUsing(() => new RemoteServices());
                    c.WhenStarted(d => d.Start());
                    c.WhenStopped(d => d.Stop());
                });

                x.SetDescription("CBRemoteControl被控端");
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
