using chess_console.board.entities;

namespace chess_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for(int i = 0; i < board.Row; i++)
            {
                for(int j = 0; j < board.Column;  j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(board.Piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
