using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace GriffBallClient
{
    class Client : IDisposable
    {
        const int port = 8888;

        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public string name { get; }
        public int id { get; }
        public Boolean hasBall;

        private static readonly object sync = new object(); // Used to create synchronized methods

        public Client(string name)
        {
            TcpClient tcpClient = new TcpClient("localhost", port);
            NetworkStream stream = tcpClient.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);

            writer.WriteLine(name);
            writer.Flush();

            string[] response = reader.ReadLine().Split(' ');
            if (response[0].Trim().ToLower() != "success")
            {
                throw new Exception("ERROR: " + response.ToString());
            }
            else
            {
                this.name = name;
                this.id = Convert.ToInt32(response[1]);
                this.hasBall = false;
            }
        }

        public void throwToPlayer(string player)
        {
            lock (sync)
            {
                string outputBuilder = "throw ";

                string regex = "\\d+";
                MatchCollection matches = Regex.Matches(player, @regex);
                outputBuilder += matches[0];

                writer.WriteLine(outputBuilder);
                writer.Flush();
            }
        }

        public string[] getPlayers()
        {
            lock (sync)
            {
                writer.WriteLine("players");
                writer.Flush();
                string playerString = reader.ReadLine();
                string[] playersArray = playerString.Split(' ');
                return playersArray;
            }
        }

        public string[] whoIsBall()
        {
            writer.WriteLine("ball");
            writer.Flush();
            String[] player = reader.ReadLine().Split(' ');
            
            return player;
        }

        public void Dispose()
        {
            reader.Close();
            writer.Close();
        }
    }
}
