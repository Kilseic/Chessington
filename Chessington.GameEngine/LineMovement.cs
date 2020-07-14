using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class LineMovement
    {
        public Board MyBoard;
        public Player MyPlayer;
        public LineMovement(Board board,Player player)
        {
            MyBoard = board;
            MyPlayer = player;
        }
        public List<Square> LateralMovement(Square location)
        {
            List<Square> currMoveList = new List<Square>();
            bool dir1 = true,dir2 = true,dir3= true,dir4 = true;
            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                if (dir1)
                {
                    bool[] indicators = AddPossMove(location.Row, location.Col + i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row, location.Col + i));
                    dir1 = indicators[1];
                }
                if (dir2)
                {
                    bool[] indicators = AddPossMove(location.Row, location.Col - i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row, location.Col - i));
                    dir2 = indicators[1];
                }
                if (dir3)
                {
                    bool[] indicators = AddPossMove(location.Row + i, location.Col);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row + i, location.Col));
                    dir3 = indicators[1];
                }
                if (dir4)
                {
                    bool[] indicators = AddPossMove(location.Row - i, location.Col);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row - i, location.Col));
                    dir4 = indicators[1];
                }
            }
            return currMoveList;
        }

        public List<Square> DiagonalMovement(Square location)
        {
            List<Square> currMoveList = new List<Square>();
            bool dir1 = true,dir2 = true,dir3= true,dir4 = true;
            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                if (dir1)
                {
                    bool[] indicators = AddPossMove(location.Row + i, location.Col + i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row + i, location.Col + i));
                    dir1 = indicators[1];
                }
                if (dir2)
                {
                    bool[] indicators = AddPossMove(location.Row - i, location.Col - i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row - i, location.Col - i));
                    dir2 = indicators[1];
                }
                if (dir3)
                {
                    bool[] indicators = AddPossMove(location.Row + i, location.Col - i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row + i, location.Col - i));
                    dir3 = indicators[1];
                }
                if (dir4)
                {
                    bool[] indicators = AddPossMove(location.Row - i, location.Col + i);
                    if (indicators[0])
                        currMoveList.Add(Square.At(location.Row - i, location.Col + i));
                    dir4 = indicators[1];
                }
            }
            return currMoveList;
        }
        private bool[] AddPossMove(int row, int col)
        {
            if (!Board.InRange(Square.At(row, col)))
                return new bool[] {false,false};
            if (Board.SquareOpen(MyBoard, Square.At(row, col))) 
                return new bool[] {true,true};;
            return new bool[] {Board.SquareLoyalty(MyBoard, Square.At(row, col)) != MyPlayer,false};
        }
    }
}