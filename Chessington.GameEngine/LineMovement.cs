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
            bool dir1 = true;
            bool dir2 = true;
            bool dir3 = true;
            bool dir4 = true;
            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                if (Board.InRange(Square.At(location.Row, location.Col+i))&dir1)
                {
                    if (Board.SquareOpen(MyBoard, Square.At(location.Row, location.Col+i))) 
                        currMoveList.Add(Square.At(location.Row, location.Col+i));
                    else if (Board.SquareLoyalty(MyBoard, Square.At(location.Row, location.Col+i)) == MyPlayer)
                        dir1 = false;
                    else
                    { currMoveList.Add(Square.At(location.Row, location.Col+i)); dir1=false; }
                }

                if (Board.InRange(Square.At(location.Row, location.Col-i))&dir2)
                {
                    if (Board.SquareOpen(MyBoard, Square.At(location.Row, location.Col-i))) 
                        currMoveList.Add(Square.At(location.Row, location.Col-i));
                    else if (Board.SquareLoyalty(MyBoard, Square.At(location.Row, location.Col-i)) == MyPlayer)
                        dir2 = false;
                    else
                    { currMoveList.Add(Square.At(location.Row, location.Col-i)); dir2=false; }
                }

                if (Board.InRange(Square.At(location.Row+i, location.Col))&dir3)
                {
                    if (Board.SquareOpen(MyBoard, Square.At(location.Row+i, location.Col))) 
                        currMoveList.Add(Square.At(location.Row+i, location.Col));
                    else if (Board.SquareLoyalty(MyBoard, Square.At(location.Row+i, location.Col)) == MyPlayer)
                        dir3 = false;
                    else
                    { currMoveList.Add(Square.At(location.Row+i, location.Col)); dir3=false; }
                }

                if (Board.InRange(Square.At(location.Row-i, location.Col))&dir4)
                {
                    if (Board.SquareOpen(MyBoard, Square.At(location.Row-i, location.Col))) 
                        currMoveList.Add(Square.At(location.Row-i, location.Col));
                    else if (Board.SquareLoyalty(MyBoard, Square.At(location.Row-i, location.Col)) == MyPlayer)
                        dir4 = false;
                    else
                    { currMoveList.Add(Square.At(location.Row-i, location.Col)); dir4=false; }
                }
            }
            currMoveList.RemoveAll(s => s == Square.At(location.Row, location.Col));
            //var outputMoves = currMoveList.Where(Board.InRange).ToList();
            return currMoveList;
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