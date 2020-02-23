namespace GriffBallClient
{
    partial class ClientWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loginNameBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.loginScreen = new System.Windows.Forms.Panel();
            this.menuScreen = new System.Windows.Forms.Panel();
            this.menuThrowButton = new System.Windows.Forms.Button();
            this.menuRefreshButton = new System.Windows.Forms.Button();
            this.menuPlayersComboBox = new System.Windows.Forms.ComboBox();
            this.menuPlayersList = new System.Windows.Forms.ListBox();
            this.hasBallLabel = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.loginScreen.SuspendLayout();
            this.menuScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginNameBox
            // 
            this.loginNameBox.Location = new System.Drawing.Point(12, 108);
            this.loginNameBox.Name = "loginNameBox";
            this.loginNameBox.Size = new System.Drawing.Size(360, 20);
            this.loginNameBox.TabIndex = 0;
            this.loginNameBox.Text = "Enter your name here :)";
            this.loginNameBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.loginNameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginNameBox_KeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 134);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(360, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to Griffball, Please Login";
            // 
            // loginScreen
            // 
            this.loginScreen.Controls.Add(this.label1);
            this.loginScreen.Controls.Add(this.loginNameBox);
            this.loginScreen.Controls.Add(this.loginButton);
            this.loginScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginScreen.Location = new System.Drawing.Point(0, 0);
            this.loginScreen.Name = "loginScreen";
            this.loginScreen.Size = new System.Drawing.Size(384, 261);
            this.loginScreen.TabIndex = 3;
            // 
            // menuScreen
            // 
            this.menuScreen.Controls.Add(this.menuThrowButton);
            this.menuScreen.Controls.Add(this.menuRefreshButton);
            this.menuScreen.Controls.Add(this.menuPlayersComboBox);
            this.menuScreen.Controls.Add(this.menuPlayersList);
            this.menuScreen.Controls.Add(this.hasBallLabel);
            this.menuScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuScreen.Location = new System.Drawing.Point(0, 0);
            this.menuScreen.Name = "menuScreen";
            this.menuScreen.Size = new System.Drawing.Size(384, 261);
            this.menuScreen.TabIndex = 4;
            this.menuScreen.Visible = false;
            // 
            // menuThrowButton
            // 
            this.menuThrowButton.Enabled = false;
            this.menuThrowButton.Location = new System.Drawing.Point(200, 197);
            this.menuThrowButton.Name = "menuThrowButton";
            this.menuThrowButton.Size = new System.Drawing.Size(172, 23);
            this.menuThrowButton.TabIndex = 5;
            this.menuThrowButton.Text = "Throw Ball!";
            this.menuThrowButton.UseVisualStyleBackColor = true;
            this.menuThrowButton.Click += new System.EventHandler(this.menuThrowButton_Click);
            // 
            // menuRefreshButton
            // 
            this.menuRefreshButton.Enabled = false;
            this.menuRefreshButton.Location = new System.Drawing.Point(15, 227);
            this.menuRefreshButton.Name = "menuRefreshButton";
            this.menuRefreshButton.Size = new System.Drawing.Size(178, 23);
            this.menuRefreshButton.TabIndex = 4;
            this.menuRefreshButton.Text = "Refresh Selection";
            this.menuRefreshButton.UseVisualStyleBackColor = true;
            this.menuRefreshButton.Click += new System.EventHandler(this.menuRefreshButton_Click);
            // 
            // menuPlayersComboBox
            // 
            this.menuPlayersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.menuPlayersComboBox.Enabled = false;
            this.menuPlayersComboBox.FormattingEnabled = true;
            this.menuPlayersComboBox.Location = new System.Drawing.Point(15, 200);
            this.menuPlayersComboBox.Name = "menuPlayersComboBox";
            this.menuPlayersComboBox.Size = new System.Drawing.Size(178, 21);
            this.menuPlayersComboBox.TabIndex = 3;
            // 
            // menuPlayersList
            // 
            this.menuPlayersList.AccessibleName = "";
            this.menuPlayersList.FormattingEnabled = true;
            this.menuPlayersList.Location = new System.Drawing.Point(15, 33);
            this.menuPlayersList.Name = "menuPlayersList";
            this.menuPlayersList.Size = new System.Drawing.Size(178, 160);
            this.menuPlayersList.TabIndex = 2;
            // 
            // hasBallLabel
            // 
            this.hasBallLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hasBallLabel.AutoSize = true;
            this.hasBallLabel.Location = new System.Drawing.Point(12, 9);
            this.hasBallLabel.Name = "hasBallLabel";
            this.hasBallLabel.Size = new System.Drawing.Size(33, 13);
            this.hasBallLabel.TabIndex = 0;
            this.hasBallLabel.Text = "Label";
            this.hasBallLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 1000;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // ClientWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.menuScreen);
            this.Controls.Add(this.loginScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientWindow";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientWindow_FormClosing);
            this.loginScreen.ResumeLayout(false);
            this.loginScreen.PerformLayout();
            this.menuScreen.ResumeLayout(false);
            this.menuScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginNameBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel loginScreen;
        private System.Windows.Forms.Panel menuScreen;
        private System.Windows.Forms.Label hasBallLabel;
        private System.Windows.Forms.ListBox menuPlayersList;
        private System.Windows.Forms.Button menuThrowButton;
        private System.Windows.Forms.Button menuRefreshButton;
        private System.Windows.Forms.ComboBox menuPlayersComboBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Timer updateTimer;
    }
}

