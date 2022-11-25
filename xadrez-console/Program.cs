using System;
using Board;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessBoard board = new ChessBoard(8, 8);

            Screen.BoardPrinter(board);
        }
    }
}
