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
            availableMoves = availableMoves.Concat(FindKnightMoves(-2, 1, location)).ToList();
            availableMoves = availableMoves.Concat(FindKnightMoves(2, 1, location)).ToList();
            availableMoves = availableMoves.Concat(FindKnightMoves(-1, 2, location)).ToList();
            availableMoves = availableMoves.Concat(FindKnightMoves(1, 2, location)).ToList();
            return availableMoves;
        }

        private List<Square> FindKnightMoves(int rowChange, int colChange, Square location)
        {
            IEnumerable<int> boardBoundaries = Enumerable.Range(0, GameSettings.BoardSize);
            List<Square> moveOutput = new List<Square>();
            if (boardBoundaries.Contains(location.Row + rowChange))
            {
                if (boardBoundaries.Contains(location.Col + colChange))
                {
                    moveOutput.Add(Square.At(location.Row+rowChange, location.Col+colChange));
                }
                if (boardBoundaries.Contains(location.Col - colChange))
                {
                    moveOutput.Add(Square.At(location.Row+rowChange, location.Col-colChange));
                }
            }

            return moveOutput;
        }
    }
}