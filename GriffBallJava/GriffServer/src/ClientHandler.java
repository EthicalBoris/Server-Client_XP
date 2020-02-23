import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class ClientHandler implements Runnable {
    private final Socket socket;
    private GriffBall griff;
    public static int idGenerator = 1;

    public ClientHandler(Socket socket, GriffBall griff) {
        this.socket = socket;
        this.griff = griff;
    }

    @Override
    public void run() {
        int playerId = idGenerator++;
        try (Scanner reader = new Scanner(socket.getInputStream());
             PrintWriter writer = new PrintWriter(socket.getOutputStream(), true)) {
            try {
                String playerName = reader.nextLine();
                griff.addPlayer(playerId, playerName);
                System.out.println("Player_" + playerId + "(" + playerName + ") has joined the game");
                griff.printPlayers();
                writer.println("success " + playerId);

                while (true) {
                    String line = reader.nextLine();
                    String[] substrings = line.split(" ");
                    griff.checkCorrectState();
                    switch (substrings[0].toLowerCase()) {
                        case "ball":
                            String playerHasBall = griff.whoHasBall().trim();
                            writer.println(playerHasBall);
                            break;
                        case "throw":
                            int toPlayerId = Integer.parseInt(substrings[1]);
                            griff.giveBall(toPlayerId);
                            break;
                        case "players":
                            String playerString = griff.getPlayersString();
                            writer.println(playerString);
                            break;
                        default:
                            throw new Exception("Unknown command: " + substrings[0]);

                    }
                    // griff.checkCorrectState();
                }

            } catch (Exception e) {
                writer.println("ERROR" + e.getMessage());
            }
        } catch (Exception e) {
        } finally {
            System.out.println("Player " + playerId + " has left the game");
            griff.removePlayer(playerId);
            griff.printPlayers();
        }
    }
}
