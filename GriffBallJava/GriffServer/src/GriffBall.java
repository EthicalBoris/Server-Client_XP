import java.net.Socket;
import java.util.Map;
import java.util.TreeMap;

public class GriffBall {
    private static Map<Integer, Player> players = new TreeMap<>();

    public void addPlayer(int playerId, String name) {
        Player player = new Player(playerId, name);
        players.put(playerId, player);

        if (players.size() == 1) {
            giveBall(playerId);
        }
    }

    public void removePlayer(int playerid) {
        players.remove(playerid);
    }

    public void giveBall(int playerId) {
        //checkCorrectState();
        String outputBuilder = "";
        String secondPlayer = "";

        for (Player player : players.values()) {
            if (player.hasBall)
                outputBuilder += "Player_" + player.getId() + "(" + player.getName() + ") Has thrown the ball to ";
            if (player.getId() != playerId) {
                player.hasBall = false;
            } else {
                player.hasBall = true;
                secondPlayer = "Player_" + player.getId() + "(" + player.getName() + ")";
            }
        }

        outputBuilder = outputBuilder + secondPlayer;

        System.out.println(outputBuilder);
        System.out.println("Player " + playerId + " Has the ball");
    }

    public synchronized void checkCorrectState() {
        // This function checks that the game state is correct and fixes the game if it is not
        int ballCount = 0;
        for (Player player : players.values()) {
            if (player.hasBall) {
                ballCount++;
            }
        }
        if (ballCount != 1) {
            System.out.println("Ball Exploded!");
            for (Player player : players.values()) {
                giveBall(player.getId());
                break;
            }
        }
    }

    public synchronized String whoHasBall() {
        String result = "";  // [Player_id(name) id]
        checkCorrectState();

        for (Player player : players.values()) {
            if (player.hasBall) {
                result = "Player_" + player.getId() + "(" + player.getName() + ") " + player.getId();
                break;
            }
        }

        return result;
    }

    public String getPlayersString() {
        String stringBuilder = "";

        for (Player player : players.values()) {
            stringBuilder += "Player_" + player.getId() + "(" + player.getName() + ") ";
        }
        stringBuilder = stringBuilder.trim();

        return stringBuilder;
    }

    public void printPlayers() {
        String stringBuilder = ">Players:" + players.size();

        for (Player player : players.values()) {
            stringBuilder += "\n" + player.getId() + ":" + player.getName();
        }

        System.out.println(stringBuilder);
    }
}
