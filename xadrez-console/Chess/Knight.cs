using Board;

namespace Chess
{
    internal class Knight : Piece
    {
        public Knight(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
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

            position.SetValue(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }

            position.SetValue(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }

            position.SetValue(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }

            position.SetValue(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
           
            position.SetValue(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            
            position.SetValue(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
        
            position.SetValue(Position.Line + 2, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }

            position.SetValue(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                tab[position.Line, position.Column] = true;
            }
            return tab;
        }
    }
}
