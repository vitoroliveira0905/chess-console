using chess_console.board.entities.exceptions;

namespace chess_console.board.entities
{
    internal class Board
    {
        public int Rank { get; set; }
        public int File { get; set; }
        private Piece[,] Pieces;

        public Board(int rank, int file)
        {
            Rank = rank;
            File = file;
            Pieces = new Piece[rank, file];
        }
        public Piece Piece(int rank, int file)
        {
            return Pieces[rank, file];
        }
        public Piece Piece(Position position)
        {
            return Pieces[position.Rank, position.File];
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
            Pieces[position.Rank, position.File] = piece;
            piece.Position = position;
        }
        public bool ValidPosition(Position position)
        {
            if(position.Rank < 0 || position.Rank >= Rank || position.File < 0 || position.File >= File)
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
