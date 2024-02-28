using chess_console.board.entities;
using chess_console.board.entities.enums;
using chess_console.chess.entities;

namespace chess_console
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {
            for(int i = 0; i < board.Row; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Column;  j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.Piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static PositionChess ReadPositionChess()
        {
            string position = Console.ReadLine();
            char file = position[0];
            int rank = int.Parse(position[1] + "");
            return new PositionChess(file, rank);
        }

        public static void PrintPiece(Piece piece)
        {
            if(piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
