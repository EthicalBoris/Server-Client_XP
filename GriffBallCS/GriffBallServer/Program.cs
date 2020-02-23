using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GriffBallServer
{
    class Program
    {
        private const int port = 8888;
        private static GriffBall griff = new GriffBall();

        static void Main(string[] args)
        {
            RunServer();
        }

        private static void RunServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            Console.WriteLine("Awaiting Players");
            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                new Thread(() => new ClientHandler(tcpClient, griff)).Start();
            }

        }
    }
}
