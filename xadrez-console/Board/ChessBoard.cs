using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public ChessBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }
        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
        }
        public bool ExistPiece(Position position)
        {
            PositionValidation(position);
            return Piece(position) != null;
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (ExistPiece(position))
            {
                throw new BoardException("Já existe uma peça nessa posição");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
        public Piece RemovePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Line, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Lines || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void PositionValidation(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Posição Inválida!");
            }
        }

    }
}
