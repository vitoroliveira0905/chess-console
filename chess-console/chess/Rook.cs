using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
