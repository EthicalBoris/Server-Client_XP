public class Player {
    private int id;
    private String name;
    boolean hasBall = false;

    Player(int id, String name) {
        this.id = id;
        this.name = name;
    }

    int getId(){
       return this.id;
    }

    String getName(){
        return this.name;
    }
}
