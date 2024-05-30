using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class Pawn : Piece
    {
        private ChessMatch _chessMatch;

        public Pawn(Color color, Board board, ChessMatch chessMatch) : base(color, board)
        {
            _chessMatch = chessMatch;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool CanMove(Position position)
        {
            if (Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                return piece == null;
            }
            return false;
        }
        public override bool[,] PossibleMovements()
        {
            bool[,] mat = new bool[Board.Row, Board.Column];

            Position position = new Position(0, 0);

            if (Color == Color.White)
            {
                //walk
                position.SetValues(Position.Row - 1, Position.Column);
                if (CanMove(position))
                    mat[position.Row, position.Column] = true;

                if (AmountOfMovements == 0)
                {
                    if(!Board.ThereIsPiece(position))
                    {
                        position.SetValues(Position.Row - 2, Position.Column);
                        if (CanMove(position))
                            mat[position.Row, position.Column] = true;
                    }
                }

                //capture
                position.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.ValidPosition(position))
                {
                    Piece piece = Board.Piece(position);
                    if (piece != null)
                    {
                        if (piece.Color != Color)
                        {
                            mat[position.Row, position.Column] = true;
                        }
                    }
                }

                position.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.ValidPosition(position))
                {
                    Piece piece = Board.Piece(position);
                    if (piece != null)
                    {
                        if (piece.Color != Color)
                        {
                            mat[position.Row, position.Column] = true;
                        }
                    }
                }

                // #specialMove  EnPassant
                if (Position.Row == 3)
                {
                    position.SetValues(Position.Row, Position.Column - 1);
                    if (Board.ThereIsPiece(position) && Board.Piece(position).Color != Color && Board.Piece(position) == _chessMatch.VulnerableEnPassant)
                    {
                        mat[position.Row - 1, position.Column] = true;
                    }
                    position.SetValues(Position.Row, Position.Column + 1);
                    if (Board.ThereIsPiece(position) && Board.Piece(position).Color != Color && Board.Piece(position) == _chessMatch.VulnerableEnPassant)
                    {
                        mat[position.Row - 1, position.Column] = true;
                    }
                }
            }

            if (Color == Color.Black)
            {
                //walk
                position.SetValues(Position.Row + 1, Position.Column);
                if (CanMove(position))
                    mat[position.Row, position.Column] = true;

                if (AmountOfMovements == 0)
                {
                    if (!Board.ThereIsPiece(position))
                    {
                        position.SetValues(Position.Row + 2, Position.Column);
                        if (CanMove(position))
                            mat[position.Row, position.Column] = true;
                    }
                }

                //capture
                position.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.ValidPosition(position))
                {
                    Piece piece = Board.Piece(position);
                    if (piece != null)
                    {
                        if (piece.Color != Color)
                        {
                            mat[position.Row, position.Column] = true;
                        }
                    }
                }

                position.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.ValidPosition(position))
                {
                    Piece piece = Board.Piece(position);
                    if (piece != null)
                    {
                        if (piece.Color != Color)
                        {
                            mat[position.Row, position.Column] = true;
                        }
                    }
                }

                // #specialMove  EnPassant
                if (Position.Row == 4)
                {
                    position.SetValues(Position.Row, Position.Column - 1);
                    if (Board.ThereIsPiece(position) && Board.Piece(position).Color != Color && Board.Piece(position) == _chessMatch.VulnerableEnPassant)
                    {
                        mat[position.Row + 1, position.Column] = true;
                    }
                    position.SetValues(Position.Row, Position.Column + 1);
                    if (Board.ThereIsPiece(position) && Board.Piece(position).Color != Color && Board.Piece(position) == _chessMatch.VulnerableEnPassant)
                    {
                        mat[position.Row + 1, position.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}

