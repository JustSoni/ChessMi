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
        MoveInfo CheckLegalMove(Tile[,] board, Pawn pawn, Figure endPoint);

        MoveInfo CheckLegalMove(Tile[,] board, Knight knight, Figure endPoint);

        MoveInfo CheckLegalMove(Tile[,] board, Bishop bishop, Figure endPoint);

        MoveInfo CheckLegalMove(Tile[,] board, Rook rook, Figure endPoint);

        MoveInfo CheckLegalMove(Tile[,] board, King king, Figure endPoint);

        MoveInfo CheckLegalMove(Tile[,] board, Figure figure, Figure endPoint);
    }
}