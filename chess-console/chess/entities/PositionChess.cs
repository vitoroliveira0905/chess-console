using chess_console.board.entities;

namespace chess_console.chess.entities
{
    internal class PositionChess
    {
        public char File { get; set; }
        public int Rank { get; set; }

        public PositionChess(char file, int rank)
        {
            File = file;
            Rank = rank;
        }
        public Position ToPosition()
        {
            return new Position(8 - Rank, File - 'a');
        }
        public override string ToString()
        {
            return "" + File + Rank;
        }
    }
}
