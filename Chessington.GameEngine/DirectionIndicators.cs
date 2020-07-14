namespace Chessington.GameEngine
{
    public class DirectionIndicators
    {
        public bool KeepGoing;
        public bool Add;
        private Board MyBoard;
        private Player MyPlayer;

        public DirectionIndicators(bool keepGoing, bool add, Board board, Player player)
        {
            KeepGoing = keepGoing;
            Add = add;
            MyBoard = board;
            MyPlayer = player;
        }
        
        public void SetDirectionIndicator(int row, int col)
        {
            if (!Board.InRange(Square.At(row, col)))
            {
                KeepGoing = false;
                Add = false;
            }
            else if (Board.SquareOpen(MyBoard, Square.At(row, col)))
            {
                KeepGoing = true;
                Add = true;
            }
            else
            {
                KeepGoing = false;
                Add = Board.SquareLoyalty(MyBoard, Square.At(row, col)) != MyPlayer;
            }
            
        }
    }
}