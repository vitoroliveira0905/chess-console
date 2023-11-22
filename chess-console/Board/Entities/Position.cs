﻿namespace chess_console.Board.Entities
{
    internal class Position
    {
        public int Rank { get; set; }
        public int File { get; set; }

        public Position(int rank, int file)
        {
            Rank = rank;
            File = file;
        }
        public override string ToString()
        {
            return Rank + ", " + File;
        }
    }
}
