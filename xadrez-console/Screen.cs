using System;
using System.Collections.Generic;
using Board;
using Chess;

namespace xadrez_console
{
    class Screen
    {
        public static void PrintGame(ChessGame game)
        {
            BoardPrinter(game.Board);
            Console.WriteLine();
            CapturedPiecesPrinter(game);
            Console.WriteLine();
            Console.WriteLine("Turno: " + game.Turn);
            Console.WriteLine("Aguardando jogada: " + game.CurrentPlayer);
        }

        public static void CapturedPiecesPrinter(ChessGame game)
        {
            Console.WriteLine("Pecas Capturadas: ");
            Console.Write("Brancas: ");
            GroupPrinter(game.CapturedPieces(Color.Branca));
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Vermalhas: ");
            GroupPrinter(game.CapturedPieces(Color.Vermelha));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void GroupPrinter(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach(Piece piece in group)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }
        public static void BoardPrinter(ChessBoard board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void BoardPrinter(ChessBoard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor newBackground = ConsoleColor.Blue;


            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = newBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);

        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.Branca)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");

            }
        }


    }
}
