using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            Square location = board.FindPiece(this);
            List<Square> availableMoves = AddKnightMoves(location, board).ToList();
            var outputMoves = availableMoves.Where(Board.InRange);
            return outputMoves;
        }

        private List<Square> AddKnightMoves(Square location, Board board)
        {
            List<Square> moveOutput = new List<Square>();
            TryAddMove(Square.At(location.Row + 2, location.Col + 1));
            TryAddMove(Square.At(location.Row+2, location.Col-1));
            TryAddMove(Square.At(location.Row-2, location.Col+1));
            TryAddMove(Square.At(location.Row-2, location.Col-1));
            TryAddMove(Square.At(location.Row+1, location.Col+2));
            TryAddMove(Square.At(location.Row+1, location.Col-2));
            TryAddMove(Square.At(location.Row-1, location.Col+2));
            TryAddMove(Square.At(location.Row-1, location.Col-2));
            return moveOutput;

            void TryAddMove(Square inputSquare)
            {
                if (Board.InRange(inputSquare))
                {
                    if (Board.SquareOpen(board, inputSquare))
                    {
                        moveOutput.Add(inputSquare);
                    }
                    else if (Board.SquareLoyalty(board, inputSquare) != Player)
                    {
                        moveOutput.Add(inputSquare);
                    }
                }
            }
        }
    }
}