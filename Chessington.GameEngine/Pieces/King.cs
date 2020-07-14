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
            List<Square> availableMoves = GetSurrounding(location, board);
            return availableMoves;
        }

        private List<Square> GetSurrounding(Square location, Board board)
        {
            List<Square> outputMoves = new List<Square>();
            TryAddMove(Square.At(location.Row+1,location.Col+1));
            TryAddMove(Square.At(location.Row+1,location.Col));
            TryAddMove(Square.At(location.Row+1,location.Col-1));
            TryAddMove(Square.At(location.Row,location.Col+1));
            TryAddMove(Square.At(location.Row,location.Col-1));
            TryAddMove(Square.At(location.Row-1,location.Col+1));
            TryAddMove(Square.At(location.Row-1,location.Col));
            TryAddMove(Square.At(location.Row-1,location.Col-1));
            return outputMoves;
            
            void TryAddMove(Square inputSquare)
            {
                if (Board.InRange(inputSquare))
                {
                    if (Board.SquareOpen(board, inputSquare))
                    {
                        outputMoves.Add(inputSquare);
                    }
                    else if (Board.SquareLoyalty(board, inputSquare) != Player)
                    {
                        outputMoves.Add(inputSquare);
                    }
                }
            }
        }
    }
}