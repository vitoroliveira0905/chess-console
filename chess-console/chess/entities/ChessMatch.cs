using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int _turn;
        private Color _currentPlayer {  get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            _turn = 1;
            _currentPlayer = Color.White;
            PlacePieces();
            Finished = false;
        }
        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            //piece.IncreaseAmountOfMovements();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
        }
        public void PlacePieces()
        {
            Board.PlacePiece(new Rook(Color.Black, Board), new PositionChess('a', 8).ToPosition());
            Board.PlacePiece(new Rook(Color.Black, Board), new PositionChess('h', 8).ToPosition());
            Board.PlacePiece(new King(Color.Black, Board), new PositionChess('e', 8).ToPosition());
            Board.PlacePiece(new Rook(Color.White, Board), new PositionChess('a', 1).ToPosition());
            Board.PlacePiece(new Rook(Color.White, Board), new PositionChess('h', 1).ToPosition());
            Board.PlacePiece(new King(Color.White, Board), new PositionChess('e', 1).ToPosition());
        }
    }
}
