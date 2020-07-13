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
            List<Square> availableMoves = new List<Square>();
            Square location = board.FindPiece(this);
            for (int i = 1; i < 8; i++)
            {
                IEnumerable<int> onBoardCheck = Enumerable.Range(0, 8);
                if (onBoardCheck.Contains(location.Row + i))
                {
                    if (onBoardCheck.Contains(location.Col + i))
                    {
                        availableMoves.Add(Square.At(location.Row+i,location.Col+i));
                    }

                    if (onBoardCheck.Contains(location.Col - i))
                    {
                        availableMoves.Add(Square.At(location.Row+i,location.Col-i));
                    }
                }
                if (onBoardCheck.Contains(location.Row - i))
                {
                    if (onBoardCheck.Contains(location.Col - i))
                    {
                        availableMoves.Add(Square.At(location.Row-i,location.Col-i));
                    }

                    if (onBoardCheck.Contains(location.Col + i))
                    {
                        availableMoves.Add(Square.At(location.Row-i,location.Col+i));
                    }
                }
            }

            IEnumerable<Square> listOfMoves = availableMoves;
            return listOfMoves;
        }
    }
}