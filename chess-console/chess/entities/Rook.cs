using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
        private bool CanMove(Position position)
        {
            if (Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                return piece == null || piece.Color != Color;
            }
            else { return false; }
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];

            Position position = new Position(0, 0);

            //north
            position.SetValues(Position.Row - 1, Position.Column);
            while (CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                    break;
                position.SetValues(position.Row - 1, position.Column);
            }

            //east
            position.SetValues(Position.Row, Position.Column + 1);
            while (CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                    break;
                position.SetValues(position.Row, position.Column + 1);
            }

            //south
            position.SetValues(Position.Row + 1, Position.Column);
            while (CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                    break;
                position.SetValues(position.Row + 1, position.Column);
            }

            //weast
            position.SetValues(Position.Row, Position.Column - 1);
            while (CanMove(position))
            {
                mat[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                    break;
                position.SetValues(position.Row, position.Column - 1);
            }

            return mat;
        }
    }
}
