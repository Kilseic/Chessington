using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = LineMovement.DiagonalMovement(board.FindPiece(this));
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}