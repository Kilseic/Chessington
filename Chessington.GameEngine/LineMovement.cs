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
                if (Board.InRange(Square.At(location.Row, location.Col+i))&dir1)
                {
                    dir1 = AddPossMove(location.Row, location.Col + i);
                }

                if (Board.InRange(Square.At(location.Row, location.Col-i))&dir2)
                {
                    dir2 = AddPossMove(location.Row, location.Col - i);
                }

                if (Board.InRange(Square.At(location.Row+i, location.Col))&dir3)
                {
                    dir3 = AddPossMove(location.Row+i, location.Col);
                }

                if (Board.InRange(Square.At(location.Row-i, location.Col))&dir4)
                {
                    dir4 = AddPossMove(location.Row-i, location.Col);
                }
            }
            return currMoveList;
            
            bool AddPossMove(int row, int col)
            {
                if (Board.SquareOpen(MyBoard, Square.At(row, col))) 
                    currMoveList.Add(Square.At(row, col));
                else if (Board.SquareLoyalty(MyBoard, Square.At(row, col)) == MyPlayer)
                    return false;
                else
                {
                    currMoveList.Add(Square.At(row, col));
                    return false;
                }

                return true;
            }
        }

        

        public List<Square> DiagonalMovement(Square location)
        {
            List<Square> availableMoves = new List<Square>();
            for (int i = 1; i < GameSettings.BoardSize; i++)
            {
                availableMoves.Add(Square.At(location.Row+i,location.Col+i));
                availableMoves.Add(Square.At(location.Row+i,location.Col-i));
                availableMoves.Add(Square.At(location.Row-i,location.Col-i));
                availableMoves.Add(Square.At(location.Row-i,location.Col+i));
            }
            var outputMoves = availableMoves.Where(Board.InRange).ToList();
            return outputMoves.ToList();
        }
    }
}