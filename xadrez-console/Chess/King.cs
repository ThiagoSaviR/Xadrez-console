using Board;

namespace Chess
{
    internal class King : Piece
    {
        public King(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
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
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            //ne
            position.SetValue(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // direita
            position.SetValue(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // se
            position.SetValue(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // abaixo
            position.SetValue(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // so
            position.SetValue(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // esquerda
            position.SetValue(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            // no
            position.SetValue(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            return tab;
        }
    }
}
