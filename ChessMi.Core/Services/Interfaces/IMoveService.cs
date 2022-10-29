using ChessMi.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMi.Core.Services.Interfaces
{
    public interface IMoveService
    {
        MoveInfo CheckLegalMove(Tile[,] board, Pawn start, Figure end);

        MoveInfo CheckLegalMove(Tile[,] board, Knight start, Figure end);

        MoveInfo CheckLegalMove(Tile[,] board, Bishop start, Figure end);

        MoveInfo CheckLegalMove(Tile[,] board, Rook start, Figure end);

        MoveInfo CheckLegalMove(Tile[,] board, King start, Figure end);

        MoveInfo CheckLegalMove(Tile[,] board, Figure start, Figure end);
    }
}