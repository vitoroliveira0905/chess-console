using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board)
        {
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
            }

            return mat;
        }
    }
}

