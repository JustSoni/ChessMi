using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class Rook : Figure
    {
        public Rook(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Rook";
            HaveMoved = false;
        }
        public bool HaveMoved { get; set; }

        internal MoveInfo CheckLegalMove(Tile[,] board, Rook rook, Figure endPoint)
        {
            if (MoveService.ColorMatches(rook, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);


            if (!MoveService.IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            // Vertically
            if (rook.Column == endPoint.Column)
            {
                for (int i = rook.Row; i != endPoint.Row;
                    i += (rook.Row > endPoint.Row ? -1 : 1)) //if Row Rook's row > than the it means that the rook is moving upwards so it's -1 if not it goes down and it is +1
                {
                    if (i == rook.Row)
                    {
                        continue;
                    }

                    if (!MoveService.IsEmpty(board[i, rook.Column].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                rook.HaveMoved = true;
                return move;
            }

            // Horizontally
            if (rook.Row == endPoint.Row)
            {
                for (
                    int i = rook.Column + 1; i != endPoint.Column;
                    i += (rook.Column > endPoint.Column ? -1 : 1)) // Same logic with the horizontal move. <->
                {
                    if (i == rook.Column)
                    {
                        continue;
                    }

                    if (!MoveService.IsEmpty(board[rook.Row, i].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                rook.HaveMoved = true;
                return move;
            }

            return new MoveInfo(false);
        }
    }
}