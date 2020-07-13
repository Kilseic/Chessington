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
            LineMovement NewMovement = new LineMovement(board,Player);
            List<Square> availableMoves = NewMovement.DiagonalMovement(board.FindPiece(this));
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}