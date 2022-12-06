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
                ChessGame game = new ChessGame();

                while (!game.EndGame)
                {
                    Console.Clear();
                    Screen.BoardPrinter(game.Board);
                    Console.WriteLine();

                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().toPositon();

                    bool[,] possiblePositions = game.Board.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.BoardPrinter(game.Board, possiblePositions);


                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPosition().toPositon();

                    game.Moving(origin, destiny);

                }

    
            } catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
