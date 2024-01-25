using chess_console.board.entities.enums;
using chess_console.board.entities;
using chess_console.chess.entities;
using chess_console.board.entities.exceptions;

namespace chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('b', 6);
            Console.WriteLine(pos);
            Console.WriteLine(pos.ToPosition());
        }
    }
}