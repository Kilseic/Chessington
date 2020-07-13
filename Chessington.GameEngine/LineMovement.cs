using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class LineMovement
    {
        public static List<Square> LateralMovement(Square location)
        {
            List<Square> currMoveList = new List<Square>();
            for (var i = 0; i < GameSettings.BoardSize; i++)
            {
                currMoveList.Add(Square.At(location.Row, i));
                currMoveList.Add(Square.At(i, location.Col));
            }
            currMoveList.RemoveAll(s => s == Square.At(location.Row, location.Col));
            return currMoveList;
        }

        public static List<Square> DiagonalMovement(Square location)
        {
            List<Square> availableMoves = new List<Square>();
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(location.Row+i,location.Col+i));
                availableMoves.Add(Square.At(location.Row+i,location.Col-i));
                availableMoves.Add(Square.At(location.Row-i,location.Col-i));
                availableMoves.Add(Square.At(location.Row-i,location.Col+i));
            }
            var outputMoves = availableMoves.Where(Board.InRange);
            return outputMoves.ToList();
        }
    }
}