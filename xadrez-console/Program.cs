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
                board.PutPiece(new Rook(board, Color.Black), new Position(1, 9));
                board.PutPiece(new King(board, Color.Black), new Position(0, 2));

                Screen.BoardPrinter(board);
            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
