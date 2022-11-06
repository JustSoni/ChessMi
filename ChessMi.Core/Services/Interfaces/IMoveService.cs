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
        MoveInfo CheckLegalMove(Tile[,] board, Figure figure, Figure endPoint);
        public bool MovesInBoard(int[] moves);
        public void MakeMove(Tile[,] board, Figure figure, Figure endPoint, MoveInfo move);
    }
}