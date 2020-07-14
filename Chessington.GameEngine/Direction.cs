namespace Chessington.GameEngine
{
    public class Direction
    {
        public int changeInRow;
        public int changeInCol;

        public Direction(int rowChange, int colChange)
        {
            changeInCol = colChange;
            changeInRow = rowChange;
        }
    }
}