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
                    try
                    {
                        Console.Clear();
                        Screen.PrintGame(game);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.ReadChessPosition().toPositon();
                        game.OriginPositionValidation(origin);

                        bool[,] possiblePositions = game.Board.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.BoardPrinter(game.Board, possiblePositions);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + game.Turn);
                        Console.WriteLine("Aguardando jogada: " + game.CurrentPlayer);


                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.ReadChessPosition().toPositon();
                        game.DestinyPositionValidation(origin, destiny);

                        game.PerformMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
