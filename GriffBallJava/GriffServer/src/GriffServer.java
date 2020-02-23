import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class GriffServer {
    private final static int port = 8080;
    private static GriffBall griff = new GriffBall();

    public static void main(String[] args) {
        RunServer();
    }

    private static void RunServer() {
        ServerSocket serverSocket = null;
        try {
            serverSocket = new ServerSocket(port);
            System.out.println("Awaiting Players...");
            while (true) {
                Socket socket = serverSocket.accept();
                new Thread(new ClientHandler(socket, griff)).start();
            }
        } catch (IOException e) {
            System.out.println(e);
        }

    }

}
