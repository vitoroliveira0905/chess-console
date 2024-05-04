﻿using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
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
        public bool Check { get; private set; }
        public HashSet<Piece> Pieces;
        public HashSet<Piece> Captured;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PlacePieces();
        }

        public Piece DoMove(Position origin, Position destination)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseAmountOfMovements();
            Piece capturedPiece = Board.RemovePiece(destination);
            Board.PlacePiece(piece, destination);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UndoMove(Position origin, Position destination, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destination);
            piece.DecreaseAmountOfMovements();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destination);
                Captured.Remove(capturedPiece);
            }
            Board.PlacePiece(piece, origin);
        }

        public void MakePlay(Position origin, Position destination)
        {
            Piece capturedPiece = DoMove(origin, destination);
            if (IsInCheck(CurrentPlayer))
            {
                UndoMove(origin, destination, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if(TestCheckmate(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }
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
            if (!Board.Piece(origin).PossibleMovement(destination))
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

        private Color Opponent(Color color)
        {
            if(color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece King(Color color)
        {
            foreach(Piece x in PiecesInGame(color))
            {
                if(x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece king = King(color);
            if(king == null)
            {
                throw new BoardException("There is no " + color + " king on the board!");
            }
            foreach(Piece x in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = x.PossibleMovements();
                if (mat[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckmate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach(Piece x in PiecesInGame(Opponent(CurrentPlayer)))
            {
                bool[,] mat = x.PossibleMovements();
                for(int i = 0; i < Board.Row; i++)
                {
                    for (int j = 0; j < Board.Column; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = DoMove(origin, destination);
                            bool isInCheck = IsInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!isInCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceNewPiece(char rank, int file, Piece piece)
        {
            Board.PlacePiece(piece, new PositionChess(rank, file).ToPosition());
            Pieces.Add(piece);
        }

        public void PlacePieces()
        {
            PlaceNewPiece('b', 8, new Rook(Color.Black, Board));
            PlaceNewPiece('h', 8, new Rook(Color.Black, Board));
            PlaceNewPiece('a', 8, new King(Color.Black, Board));
            PlaceNewPiece('b', 1, new Rook(Color.White, Board));
            PlaceNewPiece('h', 7, new Rook(Color.White, Board));
            PlaceNewPiece('e', 1, new King(Color.White, Board));
        }
    }
}
