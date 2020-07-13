using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square location = board.FindPiece(this);
            List<Square> availableMoves = new List<Square>();
            if (Player == Player.White)
            {
                Square move = new Square(location.Row-1,location.Col);
                availableMoves.Add(move);
            }
            else
            {
                Square move = new Square(location.Row+1,location.Col);
                availableMoves.Add(move);
            }

            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}