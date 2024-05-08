using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class Knight : Piece
    {
        public Knight(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "N";
        }
        private bool CanMove(Position position)
        {
            if (Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                return piece == null || piece.Color != Color;
            }
            return false;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];

            Position position = new Position(0, 0);

            //north
            position.SetValues(Position.Row - 2, Position.Column - 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            position.SetValues(Position.Row - 2, Position.Column + 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //east
            position.SetValues(Position.Row - 1, Position.Column + 2);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            position.SetValues(Position.Row + 1, Position.Column + 2);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //south
            position.SetValues(Position.Row + 2, Position.Column + 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            position.SetValues(Position.Row + 2, Position.Column - 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //west
            position.SetValues(Position.Row + 1, Position.Column - 2);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            position.SetValues(Position.Row - 1, Position.Column - 2);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            return mat;
        }
    }
}
