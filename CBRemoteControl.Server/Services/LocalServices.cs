using CBRemoteControl.Server.Common;
using CBRemoteControl.Server.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBRemoteControl.Server.Services
{
    class LocalServices
    {
        public void Start()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(ConfigManager.Instance.MachineGuid);

                using (NetMQContext context = NetMQContext.Create())
                {
                    Client(context);
                }
            });
        }
        private void Client(NetMQContext context)
        {
            using (NetMQSocket clientSocket = context.CreateRequestSocket())
            {
                clientSocket.Connect(ConfigManager.Instance.ServerBind);

                while (true)
                {
                    clientSocket.Send(CommandManager.HeartBeat());
                    string answer = clientSocket.ReceiveString();
                    Console.WriteLine("Answer from server: {0}", answer);
                    Thread.Sleep(5000);
                }
            }
        }
        public void Stop()
        {

        }
    }
}
