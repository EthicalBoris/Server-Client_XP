using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GriffBallClient
{
    public partial class ClientWindow : Form
    {
        private Client client;
        private int oldPlayerNum = 0;

        public ClientWindow()
        {
            InitializeComponent();
            this.Text = "GriffBall";

            menuScreen.Visible = false;
            loginScreen.Visible = true;

        }

        void updateState()
        {

            //FIRST get players and update players list
            string[] players = client.getPlayers();
            Console.WriteLine(players.ToString());

            if (oldPlayerNum != players.Length)
            {
                oldPlayerNum = players.Length;
                updateComboBox();

            }

            menuPlayersList.Items.Clear();

            for (int i = 0; i < players.Length; i++)
            {
                menuPlayersList.Items.Add(players[i]);
            }

            //SECOND check if player holding the ball / update GUI accordigly
            string[] playerBall = client.whoIsBall();
            Boolean serverSideBall = (Convert.ToInt32(playerBall[1]) == client.id);

            if (client.hasBall != serverSideBall)
            {
                client.hasBall = serverSideBall;
                ballState(serverSideBall, playerBall[0]);
            }


        }

        void ballState(Boolean hasBall, string ballPlayer)
        {
            if (hasBall)
            {
                hasBallLabel.Text = "You have the ball";
                hasBallLabel.ForeColor = Color.Red;
            }
            else
            {
                hasBallLabel.Text = ballPlayer + " has the ball";
                hasBallLabel.ForeColor = Color.Black;
            }

            menuPlayersComboBox.Enabled = hasBall;
            menuThrowButton.Enabled = hasBall;
            menuRefreshButton.Enabled = hasBall;
        }

        void updateComboBox()
        {
            string[] players = client.getPlayers();

            menuPlayersComboBox.Items.Clear();
            for (int i = 0; i < players.Length; i++)
            {
                menuPlayersComboBox.Items.Add(players[i]);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string name = loginNameBox.Text;
            name.Trim();

            if (name.Contains("Enter"))
            {
                name = "n00b";
            }
            if (name.Contains(" "))
            {
                name = name.Replace(' ', '_');
            }

            try
            {
                client = new Client(name);
                this.Text = "Player " + client.id + "(" + client.name + ")";
                loginScreen.Visible = false;
                menuScreen.Visible = true;

                updateTimer.Start();

                string[] playerBall = client.whoIsBall();
                ballState(client.hasBall, playerBall[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void loginNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (loginNameBox.Text.Contains("Enter"))
            {
                loginNameBox.Text = ("");

            }
        }

        private void menuThrowButton_Click(object sender, EventArgs e)
        {
            client.throwToPlayer(menuPlayersComboBox.SelectedItem.ToString());
        }

        private void menuRefreshButton_Click(object sender, EventArgs e)
        {
            updateComboBox();
        }

        private void ClientWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (updateTimer.Enabled)
                {
                    updateTimer.Stop();
                }
            }
            catch (Exception ex)
            {
            }

            try
            {
                client.Dispose();
            }
            catch (Exception ex)
            {
            }

            Console.WriteLine("Goodbye");
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            this.updateState();
        }
    }
}
