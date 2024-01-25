using chess_console.board.entities.exceptions;

namespace chess_console.board.entities
{
    internal class Board
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private Piece[,] Pieces;

        public Board(int row, int column)
        {
            Row = row;
            Column = column;
            Pieces = new Piece[row, column];
        }
        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }
        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }
        public bool ThereIsPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
        public void PlacePiece(Piece piece, Position position)
        {
            if (ThereIsPiece(position))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }
        public bool ValidPosition(Position position)
        {
            if(position.Row < 0 || position.Row >= Row || position.Column < 0 || position.Column >= Column)
            {
                return false;
            }
            return true;
        }
        public void ValidatePosition(Position position)
        {
            if(!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
