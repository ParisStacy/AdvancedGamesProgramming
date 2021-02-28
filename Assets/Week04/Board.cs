public static class Board {

    public static Piece[] myBoard = new Piece[63];

    public static int[] border = { 0, 1, 2, 3, 4, 5, 6, 7, 8,
                                  15, 16, 23, 24, 31, 32, 39,
                                  40, 47, 48, 55, 56, 57, 58,
                                  59, 60, 61, 62, 63 };

    public static void getMoves(Piece piece) {

        if (!piece.active) return;

        piece.checkMoves();

    }

    public static void CheckTile(int offset, Piece p) {

    }
}

