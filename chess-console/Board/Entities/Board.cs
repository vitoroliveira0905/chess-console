namespace chess_console.board.entities
{
    internal class Board
    {
        public int Rank { get; set; }
        public int File { get; set; }
        public Piece[,] Pieces;

        public Board(int rank, int file)
        {
            Rank = rank;
            File = file;
            Pieces = new Piece[rank, file];
        }
    }
}
