using System.Collections.Generic;
public abstract class Piece {
    public abstract bool active { get; set; }
    public abstract bool white { get; set; }

    public abstract List<Move> AvailableMoves { get; set; }

    public abstract void checkMoves();

    public abstract int position { get; set; }
    public abstract string type { get; set; }

}

public class Tile {
    public int id;
    public int pieceId;
}

public class Move {
    public int startPosition;
    public int endPosition;
    public Piece piece;
}


public class Rook : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override List<Move> AvailableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion

    public override void checkMoves() {

        CheckMovesData CheckMovesData;
        CheckMovesData.i = 1;
        CheckMovesData._break = false;
        CheckMovesData._valid = false;

        int offset;

        //S
        offset = 8;
        while(!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //N
        offset = -8;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //E
        offset = 1;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //W
        offset = -1;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
    }

    public void AddMove(CheckMovesData checkMovesData, int offset) {
        if (!checkMovesData._valid) return;

        Move thisMove = new Move();
        thisMove.startPosition = position;
        thisMove.endPosition = position + checkMovesData.i * offset;
        thisMove.piece = this;

        AvailableMoves.Add(thisMove);
    }
}

public class Bishop : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override List<Move> AvailableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

        CheckMovesData CheckMovesData;
        CheckMovesData.i = 1;
        CheckMovesData._break = false;
        CheckMovesData._valid = false;

        int offset;

        //SE
        offset = 9;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //NE
        offset = -9;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //SW
        offset = 7;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
        //NW
        offset = -7;
        while (!CheckMovesData._break) {
            CheckMovesData = Board.CheckTile(CheckMovesData, offset, this);
            AddMove(CheckMovesData, offset);

            CheckMovesData._valid = false;
            CheckMovesData.i++;
        }
    }

    public void AddMove(CheckMovesData checkMovesData, int offset) {
        if (!checkMovesData._valid) return;

        Move thisMove = new Move();
        thisMove.startPosition = position;
        thisMove.endPosition = position + checkMovesData.i * offset;
        thisMove.piece = this;

        AvailableMoves.Add(thisMove);
    }
}

public class Knight : Piece {
    #region Variables
    public override bool active { get; set; }
    public override bool white { get; set; }

    public override List<Move> AvailableMoves { get; set; }

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

    public override List<Move> AvailableMoves { get; set; }

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

    public override List<Move> AvailableMoves { get; set; }

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

    public override List<Move> AvailableMoves { get; set; }

    public override int position { get; set; }
    public override string type { get; set; }
    #endregion
    public override void checkMoves() {

    }
}

public struct CheckMovesData {
    public int i;
    public bool _break;
    public bool _valid;


}