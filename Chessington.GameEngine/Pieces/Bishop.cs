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
            LineMovement newMovement = new LineMovement(board,Player);
            return newMovement.DiagonalMovement(board.FindPiece(this));
        }
    }
}