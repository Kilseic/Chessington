﻿using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            LineMovement NewMovement = new LineMovement(board,Player);
            return NewMovement.LateralMovement(board.FindPiece(this));;
        }
    }
}