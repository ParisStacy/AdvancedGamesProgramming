public static class Board {

    public static Piece[] myBoard = new Piece[63];

    public static void getMoves(Piece piece) {

        if (!piece.active) return;

        

    }
}

public class PieceBehavior {

    public delegate void pieceFunction(Piece p);

    public void rookMoves(Piece p) {

    }
    public void BishopMoves(Piece p) {

    }
    public void KnightMoves(Piece p) {

    }
    public void QueenMoves(Piece p) {

    }
    public void KingMoves(Piece p) {

    }
    public void PawnMoves(Piece p) {

    }

}