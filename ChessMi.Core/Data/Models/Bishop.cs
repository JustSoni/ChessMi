using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class Bishop : Figure
    {
        public Bishop(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Bishop";
        }

        internal MoveInfo CheckLegalMove(Tile[,] board, Bishop bishop, Figure endPoint)
        {
            if (MoveService.ColorMatches(bishop, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);

            int deltaRow = bishop.Row - endPoint.Row;
            int deltaColumn = bishop.Column - endPoint.Column;


            if (Math.Abs(deltaRow) != Math.Abs(deltaColumn))
            {
                return new MoveInfo(false);
            }

            if (!MoveService.IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            if (deltaRow > 0 && deltaColumn > 0) // UP-LEFT
            {
                for (int i = bishop.Row - 1, j = bishop.Column - 1; i != endPoint.Row; i--, j--)
                {
                    if (!MoveService.IsEmpty(board[i, j].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow > 0 && deltaColumn < 0) // UP-RIGHT
            {
                for (int i = bishop.Row - 1, j = bishop.Column + 1; i != endPoint.Row; i--, j++)
                {
                    if (!MoveService.IsEmpty(board[i, j].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow < 0 && deltaColumn > 0) // DOWN-LEFT
            {
                for (int i = bishop.Row + 1, j = bishop.Column - 1; i != endPoint.Row; i++, j--)
                {
                    if (!MoveService.IsEmpty(board[i, j].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }

            if (deltaRow < 0 && deltaColumn < 0) // DOWN-RIGHT
            {
                for (int i = bishop.Row + 1, j = bishop.Column + 1; i != endPoint.Row; i++, j++)
                {
                    if (!MoveService.IsEmpty(board[i, j].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }


            return new MoveInfo(false);
        }
    }
}
