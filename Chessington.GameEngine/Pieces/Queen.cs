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
            return NewMovement.DiagonalMovement(board.FindPiece(this)).
                Concat(NewMovement.LateralMovement(board.FindPiece(this)));
        }
    }
}