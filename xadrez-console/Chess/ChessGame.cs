using System.Collections.Generic;
using Board;

namespace Chess
{
    internal class ChessGame
    {
        public ChessBoard Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }

        public ChessGame()
        {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Branca;
            EndGame = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
            Check = false;
        }

        public Piece Moving(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovements();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);

            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void UnMoving(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.DecreaseMovements();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, destiny);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(piece, origin);
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece capturedPiece = Moving(origin, destiny);

            if (IsCheck(CurrentPlayer))
            {
                UnMoving(origin, destiny, capturedPiece);
                throw new BoardException("Você não pode se colocar em Xeque!");
            }
            if (IsCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (IsCheckMate(Adversary(CurrentPlayer)))
            {
                EndGame = true;
            }

            Turn++;
            ChangePlayer();
        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida! (Precione ENTER)");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("A paça de origem escolhida não é sua! (Precione ENTER)");
            }
            if (!Board.Piece(position).ExistsMoves())
            {
                throw new BoardException("Não há movimentos possiveis para a peça de origem escolhida! (Precione ENTER)");
            }
        }
        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida! (Precione ENTER)");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Branca)
            {
                CurrentPlayer = Color.Vermelha;
            }
            else
            {
                CurrentPlayer = Color.Branca;
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Captured)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Adversary(Color color)
        {
            if (color == Color.Branca)
            {
                return Color.Vermelha;
            }
            else
            {
                return Color.Branca;
            }
        }
        private Piece IsKing(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece king = IsKing(color);
            if (king == null)
            {
                throw new BoardException("Não tem rei da cor" + color + " no tabuleiro!");
            }

            foreach (Piece piece in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if (mat[king.Position.Line, king.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsCheckMate(Color color)
        {
            if (!IsCheck(color))
            {
                return false;
            }
            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] mat = piece.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = piece.Position;
                            Position destiny = new Position(i, j);
                            Piece capturedPiece = Moving(origin, destiny);
                            bool checkTest = IsCheck(color);
                            UnMoving(origin, destiny, capturedPiece);
                            if (!checkTest)
                            {
                                return false;
                            }

                        }
                    }
                }

            }
            return true;
        }

        public void PutANewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).toPositon());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutANewPiece('c', 1, new Rook(Board, Color.Branca));
            PutANewPiece('d', 1, new King(Board, Color.Branca));
            PutANewPiece('h', 7, new Rook(Board, Color.Branca));

            PutANewPiece('a', 8, new King(Board, Color.Vermelha));
            PutANewPiece('b', 8, new Rook(Board, Color.Vermelha));
        }

    }
}
