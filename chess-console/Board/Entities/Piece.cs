using chess_console.board.entities.enums;

namespace chess_console.board.entities
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public Board Board { get; protected set; }
        public int AmountOfMovements { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            AmountOfMovements = 0;
        }
        public abstract bool[,] PossibleMovements();
    }
}
