using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int MoveQtt { get; protected set; }
        public ChessBoard Board { get; protected set; }

        public Piece(Position position, Color color, ChessBoard board)
        {
            Position = position;
            Color = color;
            MoveQtt = 0;
            Board = board;
        }
    }

}
