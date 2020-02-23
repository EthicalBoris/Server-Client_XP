using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GriffBallServer
{
    class GriffBall
    {
        private static Dictionary<int, Player> players = new Dictionary<int, Player>();
        private static readonly object sync = new object(); // Used to create synchronized methods

        public void addPlayer(int playerId, string name)
        {
            Player player = new Player(playerId, name);
            players.Add(playerId, player);

            if (players.Count == 1)
            {
                giveBall(playerId);
            }
        }

        public void removePlayer(int playerId)
        {
            players.Remove(playerId);
        }

        public void giveBall(int playerId)
        {
            string outputBuilder = "";
            string secondPlayer = "";

            foreach (Player player in players.Values)
            {
                if (player.hasBall)
                    outputBuilder += "Player_" + player.id + "(" + player.name + ") has thrown the ball to ";

                if (player.id != playerId)
                {
                    player.hasBall = false;
                }
                else
                {
                    player.hasBall = true;
                    secondPlayer = "Player_" + player.id + "(" + player.name + ")";
                }
            }

            outputBuilder = outputBuilder + secondPlayer;

            Console.WriteLine(outputBuilder);
            Console.WriteLine("Player " + playerId + " Has the ball");
        }

        public void checkCorrectState()
        {
            lock (sync)
            {
                int ballCount = 0;

                foreach (Player player in players.Values)
                {
                    if (player.hasBall) { ballCount++; }
                }
                if (ballCount != 1)
                {
                    Console.WriteLine("Ball Exploded!");
                    foreach (Player player in players.Values)
                    {
                        giveBall(player.id);
                        break;
                    }
                }
            }
        }

        public String whoHasBall()
        {
            lock (sync)
            {
                String result = "";
                checkCorrectState();

                foreach (Player player in players.Values)
                {
                    if (player.hasBall)
                    {
                        result = "Player_" + player.id + "(" + player.name + ") " + player.id;
                        break;
                    }
                }

                return result;
            }
        }

        public string getPlayersString()
        {
            string stringBuilder = "";

            foreach (Player player in players.Values)
            {
                stringBuilder += "Player_" + player.id + "(" + player.name + ") ";
            }
            stringBuilder = stringBuilder.Trim();

            return stringBuilder;
        }

        public void printPlayers()
        {
            String stringBuilder = ">Players:" + players.Count;

            foreach (Player player in players.Values)
            {
                stringBuilder += "\n" + player.id + ":" + player.name;
            }

            Console.WriteLine(stringBuilder);
        }
    }
}
