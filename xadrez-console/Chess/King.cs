using System;
using Board;


namespace Chess
{
    internal class King : Piece
    {
        public King(ChessBoard board, Color color) :
            base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
