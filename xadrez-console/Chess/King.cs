using Board;

namespace Chess
{
    class King : Piece
    {
        private ChessGame ChessGame;
        public King(ChessBoard board, Color color, ChessGame chessGame) :
            base(board, color)
        {
            ChessGame = chessGame;
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

        private bool RookforCastleTester(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.MoveQtt == 0;
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

            // # jogada especial roque
            if (MoveQtt == 0 && !ChessGame.Check)
            {
                // # roque pequeno
                Position rookPosition1 = new Position(Position.Line, Position.Column + 3);
                if (RookforCastleTester(rookPosition1))
                {
                    Position position1 = new Position(Position.Line, Position.Column + 1);
                    Position position2 = new Position(Position.Line, Position.Column + 2);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null)
                    {
                        tab[Position.Line, Position.Column + 2] = true;
                    }
                }
                // # roque grande
                Position rookPosition2 = new Position(Position.Line, Position.Column - 4);
                if (RookforCastleTester(rookPosition2))
                {
                    Position position1 = new Position(Position.Line, Position.Column - 1);
                    Position position2 = new Position(Position.Line, Position.Column - 2);
                    Position position3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(position1) == null && Board.Piece(position2) == null && Board.Piece(position3) == null)
                    {
                        tab[Position.Line, Position.Column - 2] = true;
                    }
                }
            }

            return tab;
        }
    }
}
