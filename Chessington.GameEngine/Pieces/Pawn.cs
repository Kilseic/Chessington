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
                if (CheckSquareMove(frontByOne))
                {
                    availableMoves.Add(frontByOne);
                }
                if ((HasEverMoved == false) & CheckSquareMove(frontByOne))
                {
                    Square frontByTwo = Square.At(row2, location.Col);
                    if (CheckSquareMove(frontByTwo))
                    {
                        availableMoves.Add(frontByTwo);
                    };
                }
            }

            bool CheckSquareMove(Square inputSquare)
            {
                if (Board.InRange(inputSquare))
                {
                    if (Board.SquareOpen(board,inputSquare))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}