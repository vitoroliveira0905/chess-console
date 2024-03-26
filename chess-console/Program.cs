using chess_console.board.entities;
using chess_console.chess.entities;
using chess_console.board.entities.exceptions;

namespace chess_console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();
                while (!chessMatch.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessMatch.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Clear();
                    bool[,] possiblePositions = chessMatch.Board.Piece(origin).PossibleMovements();
                    Screen.PrintBoard(chessMatch.Board, possiblePositions);
                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadPositionChess().ToPosition();
                    chessMatch.MovePiece(origin, destination);
                }
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}