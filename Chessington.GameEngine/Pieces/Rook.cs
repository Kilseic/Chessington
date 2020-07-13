using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = LineMovement.LateralMovement(board.FindPiece(this));
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}