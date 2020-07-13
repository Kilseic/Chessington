using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square location = board.FindPiece(this);
            List<Square> availableMoves = GetSurrounding(location);
            return availableMoves.Where(Board.InRange);
        }

        private List<Square> GetSurrounding(Square location)
        {
            List<Square> outputMoves = new List<Square>();
            outputMoves.Add(Square.At(location.Row+1,location.Col+1));
            outputMoves.Add(Square.At(location.Row+1,location.Col));
            outputMoves.Add(Square.At(location.Row+1,location.Col-1));
            outputMoves.Add(Square.At(location.Row,location.Col+1));
            outputMoves.Add(Square.At(location.Row,location.Col-1));
            outputMoves.Add(Square.At(location.Row-1,location.Col+1));
            outputMoves.Add(Square.At(location.Row-1,location.Col));
            outputMoves.Add(Square.At(location.Row-1,location.Col-1));
            return outputMoves;
        }
    }
}