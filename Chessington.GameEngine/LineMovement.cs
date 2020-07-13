using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class LineMovement
    {
        public static List<Square> LateralMovement(List<Square> currMoveList, Square location)
        {
            for (var i = 0; i < 8; i++)
            {
                currMoveList.Add(Square.At(location.Row, i));
                currMoveList.Add(Square.At(i, location.Col));
            }
            currMoveList.RemoveAll(s => s == Square.At(location.Row, location.Col));
            return currMoveList;
        }

        public static List<Square> DiagonalMovement(List<Square> currMoveList, Square location)
        {
            IEnumerable<int> boardBoundaries = Enumerable.Range(0, 8);
            for (int i = 1; i < 8; i++)
            {
                if (boardBoundaries.Contains(location.Row + i))
                {
                    if (boardBoundaries.Contains(location.Col + i))
                    {
                        currMoveList.Add(Square.At(location.Row+i,location.Col+i));
                    }

                    if (boardBoundaries.Contains(location.Col - i))
                    {
                        currMoveList.Add(Square.At(location.Row+i,location.Col-i));
                    }
                }
                if (boardBoundaries.Contains(location.Row - i))
                {
                    if (boardBoundaries.Contains(location.Col - i))
                    {
                        currMoveList.Add(Square.At(location.Row-i,location.Col-i));
                    }

                    if (boardBoundaries.Contains(location.Col + i))
                    {
                        currMoveList.Add(Square.At(location.Row-i,location.Col+i));
                    }
                }
            }

            return currMoveList;
        }
    }
}