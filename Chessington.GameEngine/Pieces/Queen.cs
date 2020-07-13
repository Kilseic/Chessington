using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square location = board.FindPiece(this);
            List<Square> availableMoves = LineMovement.DiagonalMovement(new List<Square>(),
                location);
            availableMoves = LineMovement.LateralMovement(availableMoves, location);
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}