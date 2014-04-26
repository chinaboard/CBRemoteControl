using CBRemoteControl.Model;
using CBRemoteControl.Service.Command;
using CBRemoteControl.Service.Manager;
using NetMQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

                X509Certificate2 certificate = new X509Certificate2("NetMQ.Testing.pfx", "1");
                while (true)
                {
                    var message = serverSocket.Receive();
                    var packet = new Packet(message);
                    Console.WriteLine("Receive message {0}", packet.JsonStr);
                    Package package  = new Package();
                    package = Utility.JsonSerialization.Json2Object(packet.JsonStr,package.GetType()) as Package;
                    CommandManager.Init(package);
                    serverSocket.Send(String.Format("you are {0}",package.RemoteData.MachineName));
                }
            }
        }
    }
}
