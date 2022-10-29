using ChessMi.Core.Data.Models;
using ChessMi.Core.Services.Interfaces;

namespace ChessMi.Core.Services
{
    public class MoveService : IMoveService
    {
        public MoveInfo CheckLegalMove(Tile[,] board, Pawn pawn, Figure endPoint)
        {
            throw new NotImplementedException();
        }

        public MoveInfo CheckLegalMove(Tile[,] board, Knight knight, Figure endPoint)
        {
            throw new NotImplementedException();
        }

        public MoveInfo CheckLegalMove(Tile[,] board, Bishop bishop, Figure endPoint)
        {
            throw new NotImplementedException();
        }

        public MoveInfo CheckLegalMove(Tile[,] board, Rook rook, Figure endPoint)
        {
            throw new NotImplementedException();
        }

        public MoveInfo CheckLegalMove(Tile[,] board, King king, Figure endPoint)
        {
            throw new NotImplementedException();
        }

        public MoveInfo CheckLegalMove(Tile[,] board, Figure figure, Figure endPoint)
        {
            if (figure.Name == "Pawn")
            {
                Pawn pawn = (Pawn)figure;
                return CheckLegalMove(board, pawn, endPoint);
            }
            else if (figure.Name == "Knight")
            {
                Knight knight = (Knight)figure;
                return CheckLegalMove(board, knight, endPoint);
            }
            else if (figure.Name == "Bishop")
            {
                Bishop bishop = (Bishop)figure;
                return CheckLegalMove(board, bishop, endPoint);
            }
            else if (figure.Name == "Rook")
            {
                Rook rook = (Rook)figure;
                return CheckLegalMove(board, rook, endPoint);
            }
            else if (figure.Name == "Queen")
            {
                Queen queen = (Queen)figure;
                return CheckLegalMove(board, queen, endPoint);
            }
            else if (figure.Name == "King")
            {
                King king = (King)figure;
                return CheckLegalMove(board, king, endPoint);
            }


            return new MoveInfo(false);
        }

        public void MakeMove(Tile[,] board, Figure figure, Figure endPoint, MoveInfo move)
        {
            throw new NotImplementedException();
        }

        public bool MovesInBoard(int[] moves)
        {
            throw new NotImplementedException();
        }
    }
}
