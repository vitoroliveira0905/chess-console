using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class King : Piece
    {
        private ChessMatch _chessMatch;

        public King(Color color, Board board, ChessMatch chessMatch) : base(color, board)
        {
            _chessMatch = chessMatch;
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
            return false;
        }

        private bool RookValidForCastling(Position position)
        {
            if(Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                if (piece != null && piece is Rook && piece.Color == Color && piece.AmountOfMovements == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool TestKingInCheck(Position destination)
        {
            Position origin = new Position(Position.Row, Position.Column);
            Piece capturedPiece = _chessMatch.DoMove(origin, destination);
            if (_chessMatch.IsInCheck(Color))
            {
                _chessMatch.UndoMove(origin, destination, capturedPiece);
                return true;
            }
            _chessMatch.UndoMove(origin, destination, capturedPiece);
            return false;
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

            // #specialMove  Castling
            if (AmountOfMovements == 0 && !_chessMatch.Check)
            {
                //KingsideCastling
                Position kRookPosition = new Position(Position.Row, Position.Column + 3);
                if (RookValidForCastling(kRookPosition))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if(Board.Piece(p1) == null && Board.Piece(p2) == null && !TestKingInCheck(p1))
                    {
                        mat[p2.Row, p2.Column] = true;
                    }
                }
                //QueensideCastling
                Position qRookPosition = new Position(Position.Row, Position.Column - 4);
                if (RookValidForCastling(qRookPosition))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null && !TestKingInCheck(p1))
                    {
                        mat[p2.Row, p2.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
