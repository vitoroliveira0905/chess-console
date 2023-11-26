using chess_console.board.entities.enums;
using chess_console.board.entities;
using chess_console.chess;

namespace chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);
            board.PlacePiece(new Rook(Color.Black, board), new Position(0, 0));
            board.PlacePiece(new Rook(Color.Black, board), new Position(0, 7));
            board.PlacePiece(new King(Color.Black, board), new Position(0, 4));
            board.PlacePiece(new Rook(Color.White, board), new Position(7, 0));
            board.PlacePiece(new Rook(Color.White, board), new Position(7, 7));
            board.PlacePiece(new King(Color.White, board), new Position(7, 4));
            Screen.PrintBoard(board);
        }
    }
}