public class Team {

    public bool white;

    public Piece[] myPieces;

    public Tile[] AvailableMoves;
    public Tile[] CheckTiles;

    public void updateAvailableMoves() {
        //Look at each piece, calculate all possible moves
        foreach (Piece p in myPieces) {
            Board.getMoves(p);
        }
    }

    public void updateAvailableAttacks() {

    }

    public void updateCheckTiles() {

    }

}