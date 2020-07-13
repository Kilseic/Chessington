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
                if (HasEverMoved == false)
                {
                    Square move2 = new Square(location.Row-2,location.Col);
                    availableMoves.Add(move2);
                }
            }
            else
            {
                Square move = new Square(location.Row+1,location.Col);
                availableMoves.Add(move);
                if (HasEverMoved == false)
                {
                    Square move2 = new Square(location.Row+2,location.Col);
                    availableMoves.Add(move2);
                }
            }

            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}