namespace Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveQtt { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(ChessBoard board, Color color)
        {
            Position = null;
            Board = board;
            Color = color;
            MoveQtt = 0;
        }

        public void IncreaseMovements()
        {
            MoveQtt++;
        }

        public abstract bool[,] PossibleMoves();
    }

}
