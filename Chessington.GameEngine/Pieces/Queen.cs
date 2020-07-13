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
            LineMovement NewMovement = new LineMovement(board,Player);
            Square location = board.FindPiece(this);
            List<Square> availableMoves = NewMovement.DiagonalMovement(location);
            List<Square> availableMoves2 = NewMovement.LateralMovement(location);
            List<Square> allMoves = availableMoves.Concat(availableMoves2).ToList();
            IEnumerable<Square> listOfMoves = allMoves;
            return listOfMoves;
        }
    }
}