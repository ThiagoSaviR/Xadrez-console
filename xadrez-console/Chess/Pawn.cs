using System;
using Board;


namespace Chess
{
    class Pawn : Piece
    {
        private ChessGame Game;
        public Pawn(ChessBoard board, Color color, ChessGame game) :
            base(board, color)
        {
            Game = game;
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

                // # Jogada especial En Passant

                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistAdversary(left) && Board.Piece(left) == Game.CanEnPassant)
                    {
                        tab[left.Line - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistAdversary(right) && Board.Piece(right) == Game.CanEnPassant)
                    {
                        tab[right.Line - 1, right.Column] = true;
                    }

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

                // # Jogada especial En Passant

                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(left) && ExistAdversary(left) && Board.Piece(left) == Game.CanEnPassant)
                    {
                        tab[left.Line + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(right) && ExistAdversary(right) && Board.Piece(right) == Game.CanEnPassant)
                    {
                        tab[right.Line + 1, right.Column] = true;
                    }

                }

            }
            return tab;

        }
    }
}
