using System;
using System.Net.NetworkInformation;
using Board;

namespace Chess
{
    internal class ChessGame
    {
        public ChessBoard Board { get; private set; }
        private int turn;
        private Color CurrentPlayer;
        public bool EndGame { get; private set; }


        public ChessGame() 
        {
            Board = new ChessBoard(8, 8);
            turn = 1;
            CurrentPlayer = Color.White;
            EndGame = false;
            PutPieces();
        }

        public void Moving(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.increaseMovements();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PutPiece(piece, destiny);

        }

        private void PutPieces()
        {
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 1).toPositon());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('c', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('d', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 2).toPositon());
            Board.PutPiece(new Rook(Board, Color.White), new ChessPosition('e', 1).toPositon());
            Board.PutPiece(new King(Board, Color.White), new ChessPosition('d', 1).toPositon());

            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('c', 8).toPositon());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('d', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 7).toPositon());
            Board.PutPiece(new Rook(Board, Color.Black), new ChessPosition('e', 8).toPositon());
            Board.PutPiece(new King(Board, Color.Black), new ChessPosition('d', 8).toPositon());
        }
        
    }
}
