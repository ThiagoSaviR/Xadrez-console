﻿using System.Collections.Generic;
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

        public ChessGame()
        {
            Board = new ChessBoard(8, 8);
            Turn = 1;
            CurrentPlayer = Color.Branca;
            EndGame = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPieces();
        }

        public void Moving(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovements();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);

            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Moving(origin, destiny);
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

        public void PutANewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).toPositon());
            Pieces.Add(piece);
        }

        private void PutPieces()
        {
            PutANewPiece('c', 1, new Rook(Board, Color.Branca));
            PutANewPiece('c', 2, new Rook(Board, Color.Branca));
            PutANewPiece('d', 2, new Rook(Board, Color.Branca));
            PutANewPiece('e', 2, new Rook(Board, Color.Branca));
            PutANewPiece('e', 1, new Rook(Board, Color.Branca));
            PutANewPiece('d', 1, new King(Board, Color.Branca));

            PutANewPiece('c', 7, new Rook(Board, Color.Vermelha));
            PutANewPiece('c', 8, new Rook(Board, Color.Vermelha));
            PutANewPiece('d', 7, new Rook(Board, Color.Vermelha));
            PutANewPiece('e', 7, new Rook(Board, Color.Vermelha));
            PutANewPiece('e', 8, new Rook(Board, Color.Vermelha));
            PutANewPiece('d', 8, new King(Board, Color.Vermelha));
        }

    }
}
