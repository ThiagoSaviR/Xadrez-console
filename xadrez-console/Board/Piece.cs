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

        public void DecreaseMovements()
        {
            MoveQtt--;
        }

        public bool ExistsMoves()
        {
            bool[,] tab = PossibleMoves();

            for (int i = 0; i < Board.Lines; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (tab[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public  bool PossibleMove(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves();
    }

}
