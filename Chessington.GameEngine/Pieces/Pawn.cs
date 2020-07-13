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
                if (Board.SquareOpen(board,Square.At(location.Row - 1, location.Col)))
                {
                    availableMoves.Add(Square.At(location.Row - 1, location.Col));
                    if (HasEverMoved == false)
                    {
                        if (Board.SquareOpen(board, Square.At(location.Row - 2, location.Col)))
                            availableMoves.Add(Square.At(location.Row - 2, location.Col));
                    }
                }
            }
            else
            {
                if (Board.SquareOpen(board,Square.At(location.Row + 1, location.Col)))
                {
                    availableMoves.Add(Square.At(location.Row+1,location.Col));
                    if (HasEverMoved == false)
                    {
                        if (Board.SquareOpen(board,Square.At(location.Row+2,location.Col))) 
                            availableMoves.Add(Square.At(location.Row+2,location.Col));
                    }
                }
            }

            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}