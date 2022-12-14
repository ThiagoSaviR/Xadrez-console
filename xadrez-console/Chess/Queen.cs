using Board;

namespace Chess
{
    internal class Queen : Piece
    {
        public Queen(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "D";
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

            // acima
            position.SetValue(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line - 1, position.Column);
            }

            // abaixo

            position.SetValue(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line + 1, position.Column);
            }

            // direita

            position.SetValue(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line, position.Column + 1);
            }

            // esquerda

            position.SetValue(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }
                position.SetValue(position.Line, position.Column - 1);
            }

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
