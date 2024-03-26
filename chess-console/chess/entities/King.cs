using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "K";
        }
        private bool CanMove(Position position)
        {
            if(Board.ValidPosition(position))
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
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //northeast
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //east
            position.SetValues(Position.Row, Position.Column + 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //southeast
            position.SetValues(Position.Row + 1, Position.Column + 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //south
            position.SetValues(Position.Row + 1, Position.Column);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //southweast
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //weast
            position.SetValues(Position.Row, Position.Column - 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            //northweast
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (CanMove(position))
                mat[position.Row, position.Column] = true;

            return mat;
        }
    }
}
