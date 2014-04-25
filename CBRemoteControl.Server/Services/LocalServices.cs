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
                while(true)
                {
                    ScreenCommon.GetScreen();
                    Console.WriteLine(ConfigManager.Instance.MachineGuid);

                    Thread.Sleep(5000);
                    using (NetMQContext context = NetMQContext.Create())
                    {
                        Client(context);
                    }
                }
                
            });
        }
        static void Client(NetMQContext context)
        {
            using (NetMQSocket clientSocket = context.CreateRequestSocket())
            {
                clientSocket.Connect(ConfigManager.Instance.ServerBind);

                while (true)
                {
                    Console.WriteLine("Please enter your message:");
                    string message = "yoooooo" + DateTime.Now;
                    clientSocket.Send(message);

                    string answer = clientSocket.ReceiveString();

                    Console.WriteLine("Answer from server: {0}", answer);

                    if (message == "exit")
                    {
                        break;
                    }
                }
            }
        }
        public void Stop()
        {

        }
    }
}
