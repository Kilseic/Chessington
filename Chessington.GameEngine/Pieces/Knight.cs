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
            List<Square> availableMoves = new List<Square>();
            availableMoves = availableMoves.Concat(FindKnightMoves(location)).ToList();
            var outputMoves = from move in availableMoves where InRange(move) select move;
            return outputMoves;
        }

        public bool InRange(Square inputSquare)
        {
            IEnumerable<int> boardBoundaries = Enumerable.Range(0, GameSettings.BoardSize);
            if (boardBoundaries.Contains(inputSquare.Col))
            {
                if (boardBoundaries.Contains(inputSquare.Row))
                {
                    return true;
                }
            }
            return false;
        }

        private List<Square> FindKnightMoves(Square location)
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