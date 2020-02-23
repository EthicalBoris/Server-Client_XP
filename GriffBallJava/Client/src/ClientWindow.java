import javax.swing.*;
import java.awt.*;
import java.awt.event.*;
import java.util.Arrays;

public class ClientWindow extends JFrame {

    private Client client;
    private ClientWindow frame;
    private Thread updateThread;
    private  int oldPlayerNum = 0;

    private JPanel main;

    private JPanel loginScreen;
    private JButton loginButton;
    private JLabel loginLabel;
    private JProgressBar loginBar;
    private JTextField loginNameBox;

    private JPanel menuScreen;
    private JButton menuThrowButton;
    private JLabel hasBallLabel;
    private JPanel menuHasBallLabel;
    private JScrollPane playersListScrollPane;

    private JComboBox menuPlayersComboBox;
    private JButton menuRefreshButton;
    private DefaultComboBoxModel<String> playersComboBoxModel;
    private JList menuPlayersList;
    private DefaultListModel<String> playersListModel;

    ClientWindow(String title) {

        // Preparing the JFrame
        this.setTitle(title);
        this.setContentPane(main);
        this.setTitle("GriffBall");

        this.loginScreen.setVisible(true);
        this.menuScreen.setVisible(false);
        // menuPlayersBox.setVisible(false);
        // menuThrowButton.setVisible(false);
        menuPlayersComboBox.setEnabled(false);
        menuThrowButton.setEnabled(false);
        menuRefreshButton.setEnabled(false);

        this.setDefaultCloseOperation(ClientWindow.EXIT_ON_CLOSE);
        this.setPreferredSize(new Dimension(400, 300));
        this.pack();
        this.addListeners();
        this.setVisible(true);

        // Making the players list scrollable (Much more code than I anticipated)
        menuPlayersList = new JList<String>();  // declare Jlist
        menuPlayersList.setVisibleRowCount(4);

        playersListModel = new DefaultListModel<>(); // Jlist needs model to display info
        playersComboBoxModel = new DefaultComboBoxModel<>();

        menuPlayersList.setModel(playersListModel);
        menuPlayersComboBox.setModel(playersComboBoxModel);
        //menuPlayersBox.setPopupVisible(true);

        playersListScrollPane.setViewportView(menuPlayersList);

        // setting a dynamic variable frame so the frame can refer to itself
        // it's possible to use 'this' but this is personal preference.
        frame = this;
    }

    ClientWindow() {
        this("");
    }


    void updateState() {
        //TODO complete method to update game state

        // FIRST get players and update the players list
        String[] players = client.getPlayers();
        System.out.println(Arrays.toString(players));

        if(oldPlayerNum != players.length){
            oldPlayerNum = players.length;
            updateComboBox();
        }

        playersListModel.clear();

        for (int i = 0; i < players.length; i++) {
            playersListModel.add(i, players[i]);
        }

        // SECOND check if player holding the ball / update GUI accordingly
        String[] playerBall = client.whoIsBall();
        boolean serverSideBall = Integer.parseInt(playerBall[1]) == client.getId();

        if (client.hasBall != serverSideBall) { // If the server says something different
            client.hasBall = serverSideBall;
            ballState(serverSideBall, playerBall[0]);
        }
        // THIRD if you are holding the ball update gui so that ball is throwable

    }

    void ballState(boolean hasBall, String ballPlayer) {
        // Updates the state of the GUI so that the player can or cannot throw ball
        if (hasBall) {
            hasBallLabel.setText("You have the ball");
            hasBallLabel.setForeground(Color.RED);
            updateComboBox();
        } else {
            hasBallLabel.setText(ballPlayer + " has the ball");
            hasBallLabel.setForeground(Color.BLACK);
        }
        menuPlayersComboBox.setEnabled(hasBall);
        menuThrowButton.setEnabled(hasBall);
        menuRefreshButton.setEnabled(hasBall);
    }

    void updateComboBox() {
        String[] players = client.getPlayers();
        playersComboBoxModel.removeAllElements();
        for (int i = 0; i < players.length; i++) {
            playersComboBoxModel.addElement(players[i]);
        }
    }

    void addListeners() {
        // this method adds the listeners for all the buttons in the client application

        loginButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // TODO add loading bar
                String name = loginNameBox.getText();

                if (name.contains("Enter")) {
                    name = "n00b";
                }

                if(name.contains(" ")){
                    name = name.replace(' ','_');
                }
                try {
                    loginBar.setVisible(true);
                    //TODO add loading thread

                    client = new Client(name);

                    frame.setTitle("Player " + client.getId() + ": (" + client.getName() + ")");
                    frame.loginScreen.setVisible(false);
                    frame.menuScreen.setVisible(true);

                    updateThread = new Thread(new Runnable() {  // TODO thread to update game state
                        @Override
                        public void run() {
                            try {
                                while (true) {
                                    frame.updateState();
                                    Thread.sleep(1000);
                                }
                            } catch (Exception e) {
                                // e.printStackTrace();
                            }
                        }
                    });

                    String[] playerBall = client.whoIsBall();
                    frame.ballState(false, playerBall[0]);
                    updateThread.start();
                } catch (Exception error) {
                    JOptionPane.showMessageDialog(null, error.getMessage());
                }

            }
        });

        loginNameBox.addKeyListener(new KeyAdapter() {
            @Override
            public void keyPressed(KeyEvent k) {
                if (loginNameBox.getText().contains("Enter")) {
                    loginNameBox.setText("");
                }
            }
        });

        menuThrowButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                client.throwToPlayer(menuPlayersComboBox.getSelectedItem().toString());
            }
        });

        menuRefreshButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                updateComboBox();
            }

        });

        this.addWindowListener(new WindowAdapter() { // Executes when window is closed
            public void windowClosing(WindowEvent e) {
                // closes client connection if window closed
                try {
                    if (updateThread.isAlive()) {
                        updateThread.interrupt();
                    }
                } catch (Exception ex) {
                }

                try {
                    client.close();
                } catch (Exception ex) {
                }

                System.out.println("Goodbye");
            }
        });
    }
}
