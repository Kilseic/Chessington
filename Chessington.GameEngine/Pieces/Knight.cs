using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square location = board.FindPiece(this);
            List<Square> availableMoves = AddKnightMoves(location).ToList();
            var outputMoves = availableMoves.Where(Board.InRange);
            return outputMoves;
        }

        private List<Square> AddKnightMoves(Square location)
        {
            List<Square> moveOutput = new List<Square>();
            moveOutput.Add(Square.At(location.Row+2, location.Col+1));
            moveOutput.Add(Square.At(location.Row+2, location.Col-1));
            moveOutput.Add(Square.At(location.Row-2, location.Col+1));
            moveOutput.Add(Square.At(location.Row-2, location.Col-1));
            moveOutput.Add(Square.At(location.Row+1, location.Col+2));
            moveOutput.Add(Square.At(location.Row+1, location.Col-2));
            moveOutput.Add(Square.At(location.Row-1, location.Col+2));
            moveOutput.Add(Square.At(location.Row-1, location.Col-2));
            return moveOutput;
        }
    }
}