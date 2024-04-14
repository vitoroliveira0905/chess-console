using System.Collections.Generic;
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
        public HashSet<Piece> Pieces;
        public HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
            Finished = false;
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            //piece.IncreaseAmountOfMovements();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
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

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Pieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void PlaceNewPiece(char rank, int file, Piece piece)
        {
            Board.PlacePiece(piece, new PositionChess(rank, file).ToPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            PlaceNewPiece('a', 8, new Rook(Color.Black, Board));
            PlaceNewPiece('h', 8, new Rook(Color.Black, Board));
            PlaceNewPiece('e', 8, new King(Color.Black, Board));
            PlaceNewPiece('a', 1, new Rook(Color.White, Board));
            PlaceNewPiece('h', 1, new Rook(Color.White, Board));
            PlaceNewPiece('e', 1, new King(Color.White, Board));
        }
    }
}
