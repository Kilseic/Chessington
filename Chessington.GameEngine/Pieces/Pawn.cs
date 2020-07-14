using System.Collections.Generic;
using System.ComponentModel;
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
            JumpMovement doMoves = new JumpMovement(board,Player);
            if (Player == Player.White)
            {
                TryAddMove(location.Row - 1, location.Row - 2);
            }
            else
            {
                TryAddMove(location.Row + 1, location.Row + 2);
            }
            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;

            void TryAddMove(int row1, int row2)
            {
                Square frontByOne = Square.At(row1, location.Col);
                if (doMoves.TryAddMove(frontByOne, false))
                {
                    availableMoves.Add(frontByOne);
                }
                if ((HasEverMoved == false) & doMoves.TryAddMove(frontByOne, false))
                {
                    Square frontByTwo = Square.At(row2, location.Col);
                    if (doMoves.TryAddMove(frontByTwo, false))
                    {
                        availableMoves.Add(frontByTwo);
                    };
                }
            }
        }
    }
}