using chess_console.board.entities;
using chess_console.board.entities.enums;

namespace chess_console.chess.entities
{
    internal class King : Piece
    {
        public King(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
