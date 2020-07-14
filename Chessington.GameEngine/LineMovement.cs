using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class LineMovement
    {
        private readonly Board MyBoard;
        private readonly  Player MyPlayer;
        public LineMovement(Board board,Player player)
        {
            MyBoard = board;
            MyPlayer = player;
        }
        public IEnumerable<Square> LateralMovement(Square location)
        {
            IEnumerable<Square> moveList = GoInDirection(location, new Direction(0,+1));
            moveList = moveList.Concat(GoInDirection(location, new Direction(0,-1)));
            moveList = moveList.Concat(GoInDirection(location, new Direction(+1,0)));
            moveList = moveList.Concat(GoInDirection(location, new Direction(-1,0)));
            return moveList;
        }

        public IEnumerable<Square> DiagonalMovement(Square location)
        {
            IEnumerable<Square> moveList = GoInDirection(location, new Direction(+1,+1));
            moveList = moveList.Concat(GoInDirection(location, new Direction(-1,-1)));
            moveList = moveList.Concat(GoInDirection(location, new Direction(+1,-1)));
            moveList = moveList.Concat(GoInDirection(location, new Direction(-1,+1)));
            return moveList;
        }

        private IEnumerable<Square> GoInDirection(Square location, Direction direction)
        {
            List<Square> moveList = new List<Square>();
            DirectionIndicators indicators = new DirectionIndicators(true,false, MyBoard,MyPlayer);
            int i = 1;
            while (indicators.KeepGoing)
            {
                indicators.SetDirectionIndicator(location.Row + i*direction.changeInRow,
                    location.Col + i*direction.changeInCol);
                if (indicators.Add)
                {
                    moveList.Add(Square.At(location.Row + i * direction.changeInRow,
                        location.Col + i * direction.changeInCol));
                }
                i++;
            }

            return moveList;
        }
    }
}