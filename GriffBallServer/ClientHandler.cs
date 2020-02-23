using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace GriffBallServer
{
    class ClientHandler
    {
        private TcpClient tcpClient;
        private GriffBall griff;
        public static int idGenerator = 1;

        public ClientHandler(TcpClient tcpClient, GriffBall griff)
        {
            this.tcpClient = tcpClient;
            this.griff = griff;
            this.run();
        }

        public void run()
        {
            using (NetworkStream stream = tcpClient.GetStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                StreamReader reader = new StreamReader(stream);
                int playerId = idGenerator++;
                try
                {
                    string playerName = reader.ReadLine();
                    griff.addPlayer(playerId, playerName);                    
                    Console.WriteLine("Player_" + playerId + "(" + playerName + ") has joined the game");
                    griff.printPlayers();
                    writer.WriteLine("success " + playerId);
                    writer.Flush();

                    while (true)
                    {
                        string line = reader.ReadLine();
                        string[] substrings = line.Split(' ');
                        griff.checkCorrectState();
                        switch (substrings[0].ToLower())
                        {
                            case "ball":
                                string playerHasBall = griff.whoHasBall().Trim();
                                writer.WriteLine(playerHasBall);
                                writer.Flush();
                                break;

                            case "throw":
                                int toPlayerId = Convert.ToInt32(substrings[1]);
                                griff.giveBall(toPlayerId);
                                break;

                            case "players":
                                string playerString = griff.getPlayersString();
                                writer.WriteLine(playerString);
                                writer.Flush();
                                break;

                            default:
                                throw new Exception($"Unknown command: {substrings[0]}.");
                        }
                    }
                }
                catch (Exception e)
                {
                    writer.WriteLine("ERROR" + e.Message);
                }
                finally
                {
                    try
                    {
                        griff.removePlayer(playerId);
                        writer.Flush();
                        tcpClient.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERROR CLOSING:" + e.Message);
                    }

                    Console.WriteLine($"Player_{playerId} has left the game");
                    griff.printPlayers();
                }
            }
        }
    }
}
