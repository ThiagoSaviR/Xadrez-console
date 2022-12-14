using System;
using Board;


namespace Chess
{
    internal class Pawn : Piece
    {
        public Pawn(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistAdversary(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }
        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
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

            if (Color == Color.Branca)
            {
                position.SetValue(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && MoveQtt == 0)
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistAdversary(position))
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistAdversary(position))
                {
                    tab[position.Line, position.Column] = true;
                }

            } else
            {
                position.SetValue(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position) && Free(position))
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(position) && Free(position) && MoveQtt == 0)
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(position) && ExistAdversary(position))
                {
                    tab[position.Line, position.Column] = true;
                }
                position.SetValue(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(position) && ExistAdversary(position))
                {
                    tab[position.Line, position.Column] = true;
                }
            }
            return tab;

        }
    }
}
