import javax.swing.*;
import java.io.*;
import java.net.Socket;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Client implements AutoCloseable {
    final int port = 1337;

    private final Scanner reader;
    private final PrintWriter writer;

    private String name;
    private int id;
    boolean hasBall;

    public Client(String name) throws Exception {
        // attempting to connect to server with selected ID
        Socket socket = new Socket("92.56.235.161", port);
        reader = new Scanner(socket.getInputStream());
        writer = new PrintWriter(socket.getOutputStream(), true);

        //Sending player name
        writer.println(name);

        //if server returns success then request is accepted and player is in game
        String[] response = reader.nextLine().split(" ");
        if (response[0].compareToIgnoreCase("success") != 0) {
            throw new Exception();
        } else {
            this.name = name;
            this.id = Integer.parseInt(response[1]);
            this.hasBall = false;
        }
    }

    public synchronized void throwToPlayer(String player) {
        String outputBuilder = "throw ";

        Matcher m = Pattern.compile("\\d+").matcher(player);

        while (m.find()) {
            outputBuilder += m.group();
            break;
        }

        writer.println(outputBuilder);
    }

    public synchronized String[] getPlayers() {
        writer.println("players");
        String playersString = reader.nextLine();
        String[] playersArray = playersString.split(" ");
        return playersArray;
    }

    public synchronized String[] whoIsBall() {
        writer.println("ball");
        String[] player = reader.nextLine().split(" ");
        return player;
    }

    public int generateId() {
        //TODO finish generate ID method
        // sending command to server to recieve new ID
        writer.println("IDPLEASE");
        String idString = reader.nextLine();
        int id = Integer.parseInt(idString);

        return id;
    }


    public int getId() {
        return this.id;
    }

    public String getName() {
        return this.name;
    }

    @Override
    public void close() throws Exception {
        reader.close();
        writer.close();
    }
}
