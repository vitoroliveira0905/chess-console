using chess_console.board.entities;
using chess_console.board.entities.enums;
using chess_console.board.entities.exceptions;

namespace chess_console.chess.entities
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
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
        public void MakePlay(Position origin, Position destination)
        {
            MovePiece(origin, destination);
            Turn++;
            ChangePlayer();
        }
        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!");
            }
            if(Board.Piece(origin).Color != CurrentPlayer)
            {
                throw new BoardException("The chosen piece is not yours!");
            }
            if (!Board.Piece(origin).ThereArePossibleMovements())
            {
                throw new BoardException("There are no possible movements for the chosen piece!");
            }
        }
        public void ValidateDestinationPosition(Position origin ,Position destination)
        {
            if (!Board.Piece(origin).CanMoveTo(destination))
            {
                throw new BoardException("Invalid destinaton position!");
            }
        }
        private void ChangePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
