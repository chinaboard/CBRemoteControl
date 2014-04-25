using CBRemoteControl.Service.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            using (NetMQContext context = NetMQContext.Create())
            {
                Server(context);
            }
            Console.Read();
        }

        static void Server(NetMQContext context)
        {
            using (NetMQSocket serverSocket = context.CreateResponseSocket())
            {
                serverSocket.Bind(ConfigManager.Instance.LocalBind);

                while (true)
                {
                    string message = serverSocket.ReceiveString();

                    Console.WriteLine("Receive message {0}", message);

                    serverSocket.Send("World");

                    if (message == "exit")
                    {
                        break;
                    }
                }
            }
        }
    }
}
