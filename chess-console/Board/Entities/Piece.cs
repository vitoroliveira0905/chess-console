using chess_console.board.entities.enums;

namespace chess_console.board.entities
{
    internal class Piece
    {
        public Position Position { get; protected set; }
        public Color Color { get; protected set; }
        public Board Board { get; set; }
        public int AmountOfMovements { get; protected set; }

        public Piece(Position position, Color color, Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            AmountOfMovements = 0;
        }
    }
}
