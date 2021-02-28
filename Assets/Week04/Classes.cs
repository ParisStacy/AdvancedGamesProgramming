using System.Linq;
public abstract class Piece {
    public abstract bool active { get; set; }
    public abstract bool white { get; set; }

    public abstract Tile[] availableMoves { get; set; }

    public abstract void checkMoves();

    public abstract int position { get; set; }
    public abstract string type { get; set; }

}

public class Tile {
    public int id;
    public int pieceId;
}

public class Move {

}


public class Rook : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion

    public override void checkMoves() {

        CheckMovesData d;
        d._i = 1;
        d._break = false;
        d._valid = false;

        //S
        while(!d._break) {

            if (Board.border.Contains(position + d._i * 8)) d._break = true;
            if (Board.myBoard[position + d._i * 8].active == true) d._break = true;

            d._valid = !(Board.myBoard[position + d._i * 8].white == white);

            if (d._valid) {

            }
            
            d._valid = false;
            d._i++;
        }

    }
}

public class Bishop : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

    }
}

public class Knight : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {
        
    }
}

public class Queen : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

    }
}

public class King : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

    }
}

public class Pawn : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override Tile[] availableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

    }
}


public struct CheckMovesData {
    public int _i;
    public bool _break;
    public bool _valid;
}