using ChessMi.Core.Data.Enums;
using ChessMi.Core.Data.Models;
using ChessMi.Core.Services.Interfaces;

namespace ChessMi.Core.Services
{
    public class MoveService : IMoveService
    {
        public MoveInfo CheckLegalMove(Tile[,] board, Pawn pawn, Figure endPoint)
        {
            if (this.ColorMatches(pawn, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);
            if (pawn.Color == Color.White)
            {
                //One tile move upwards
                if (pawn.Row - endPoint.Row == 1)
                {
                    //If the move is vertical
                    if (pawn.Column == endPoint.Column &&
                        IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        return move;

                    }
                    //If the move is diagonal in order to take a figure
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !IsEmpty(endPoint) &&
                        !ColorMatches(pawn, endPoint))
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                }
                if (pawn.Row - endPoint.Row == 2)
                {
                    if (pawn.Column == endPoint.Column &&
                        IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                }
            }

            return new MoveInfo(false);

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

        private bool IsEmpty(Figure figure)
        {
            return figure.Name == "Empty";
        }

        private bool ColorMatches(Figure a, Figure b)
        {
            return a.Color == b.Color;
        }
    }
}
