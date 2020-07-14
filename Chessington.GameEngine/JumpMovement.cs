using System.Collections.Generic;

namespace Chessington.GameEngine
{
    public class JumpMovement
    {
        public Board MyBoard;
        public Player MyPlayer;
        public JumpMovement(Board board,Player player)
        {
            MyBoard = board;
            MyPlayer = player;
        }
        public bool TryAddMove(Square inputSquare, bool canTake = true, bool onlyMoveOnTake = false)
        {
            if (Board.InRange(inputSquare))
            {
                if (Board.SquareOpen(MyBoard, inputSquare))
                {
                    if (onlyMoveOnTake)
                        return false;
                    return true;
                }
                if ((Board.SquareLoyalty(MyBoard, inputSquare) != MyPlayer)&canTake)
                    return true;
            }
            return false;
        }
    }
}