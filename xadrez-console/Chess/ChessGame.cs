using System;
using System.Net.NetworkInformation;
using Board;

namespace Chess
{
    internal class ChessGame
    {
        public ChessBoard Board { get; private set; }
        public int turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndGame { get; private set; }


        public ChessGame() 
        {
            Board = new ChessBoard(8, 8);
            turn = 1;
            CurrentPlayer = Color.Branca;
            EndGame = false;
            PutPieces();
        }

        public void Moving(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovements();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);

        }

        public void PerformMove(Position origin, Position destiny)
        {
            Moving(origin, destiny);
            turn++;
            ChangePlayer();

        }

        public void OriginPositionValidation(Position position)
        {
            if (Board.Piece(position) == null)
            {
                throw new BoardException("Não existe peça na posição de origem escolhida! (Tecle ENTER)");
            }
            if (CurrentPlayer != Board.Piece(position).Color)
            {
                throw new BoardException("A paça de origem escolhida não é sua! (Tecle ENTER)");
            }
            if (!Board.Piece(position).ExistsMoves())
            {
                throw new BoardException("Não há movimentos possiveis para a peça de origem escolhida! (Tecle ENTER)");
            }
        }
        public void DestinyPositionValidation(Position origin, Position destiny)
        {
            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida! (Tecle ENTER)");
            }
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.Branca)
            {
                CurrentPlayer = Color.Vermelha;
            } else
            {
                CurrentPlayer = Color.Branca;
            }
        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.Branca), new ChessPosition('c', 1).toPositon());
            Board.PutPiece(new Rook(Board, Color.Branca), new ChessPosition('c', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.Branca), new ChessPosition('d', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.Branca), new ChessPosition('e', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.Branca), new ChessPosition('e', 1).toPositon());
            Board.PutPiece(new King(Board, Color.Branca), new ChessPosition('d', 1).toPositon());

            Board.PutPiece(new Rook(Board, Color.Vermelha), new ChessPosition('c', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Vermelha), new ChessPosition('c', 8).toPositon());
            Board.PutPiece(new Rook(Board, Color.Vermelha), new ChessPosition('d', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Vermelha), new ChessPosition('e', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Vermelha), new ChessPosition('e', 8).toPositon());
            Board.PutPiece(new King(Board, Color.Vermelha), new ChessPosition('d', 8).toPositon());
        }
        
    }
}
