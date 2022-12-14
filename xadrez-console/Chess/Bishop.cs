using Board;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] tab = new bool[Board.Lines, Board.Columns];

            Position position = new Position(0, 0);

            // NO
            position.SetValue(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line - 1, position.Column - 1);
            }

            // NE

            position.SetValue(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line - 1, position.Column + 1);
            }

            // SE

            position.SetValue(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line + 1, position.Column + 1);
            }

            // SO

            position.SetValue(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line + 1, position.Column - 1);
            }
            return tab;
        }
    }
}
