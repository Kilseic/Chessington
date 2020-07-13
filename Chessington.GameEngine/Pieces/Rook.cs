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
            Square location = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            for (var i = 0; i < 8; i++)
            {
                availableMoves.Add(Square.At(location.Row, i));
                availableMoves.Add(Square.At(i, location.Col));
            }

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == Square.At(location.Row, location.Col));
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}