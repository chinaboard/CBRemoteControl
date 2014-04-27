using CBRemoteControl.Server.Services;
using Topshelf;

namespace CBRemoteControl.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ServerServices>(c =>
                {
                    c.ConstructUsing(() => new ServerServices());
                    c.WhenStarted(d => d.Start());
                    c.WhenStopped(d => d.Stop());
                });

                x.SetDescription("CBRemoteControl服务器端");
                x.SetDisplayName("CBRemoteControl.Server");
                x.SetServiceName("CBRemoteControl.Server");

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
