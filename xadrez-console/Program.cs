using System;
using Board;
using Chess;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessBoard board = new ChessBoard(8, 8);

                board.PutPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                board.PutPiece(new Rook(board, Color.White), new Position(3, 5));

                Screen.BoardPrinter(board);
            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
