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
            Direction direction1 = new Direction(0,+1);
            Direction direction2 = new Direction(0,-1);
            Direction direction3 = new Direction(+1,0);
            Direction direction4 = new Direction(-1,0);
            IEnumerable<Square> currMoveList = GoInDirection(location, direction1);
            currMoveList = currMoveList.Concat(GoInDirection(location, direction2));
            currMoveList = currMoveList.Concat(GoInDirection(location, direction3));
            currMoveList = currMoveList.Concat(GoInDirection(location, direction4));
            return currMoveList;
        }

        public IEnumerable<Square> DiagonalMovement(Square location)
        {
            Direction direction1 = new Direction(+1,+1);
            Direction direction2 = new Direction(-1,-1);
            Direction direction3 = new Direction(+1,-1);
            Direction direction4 = new Direction(-1,+1);
            IEnumerable<Square> currMoveList = GoInDirection(location, direction1);
            currMoveList = currMoveList.Concat(GoInDirection(location, direction2));
            currMoveList = currMoveList.Concat(GoInDirection(location, direction3));
            currMoveList = currMoveList.Concat(GoInDirection(location, direction4));
            return currMoveList;
        }

        private IEnumerable<Square> GoInDirection(Square location, Direction direction)
        {
            List<Square> currMoveList = new List<Square>();
            DirectionIndicators indicators = new DirectionIndicators(true,false, MyBoard,MyPlayer);
            int i = 1;
            while (indicators.KeepGoing)
            {
                indicators.SetDirectionIndicator(location.Row + i*direction.changeInRow,
                    location.Col + i*direction.changeInCol);
                if (indicators.Add)
                {
                    currMoveList.Add(Square.At(location.Row + i * direction.changeInRow,
                        location.Col + i * direction.changeInCol));
                }
                i++;
            }

            return currMoveList;
        }
    }
}