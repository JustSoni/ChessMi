using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class Knight : Figure
    {
        public Knight(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Knight";
        }

        internal MoveInfo CheckLegalMove(Tile[,] board, Knight knight, Figure endPoint)
        {
            if (MoveService.ColorMatches(knight, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);

            if (MoveService.IsEmpty(endPoint)) // This code will run if the knight won't take a figure.
            {
                //Vertical move
                if (Math.Abs(knight.Row - endPoint.Row) == 2 &&
                    Math.Abs(knight.Column - endPoint.Column) == 1)
                {
                    move.IsAllowed = true;
                    return move;
                }

                //Horizontal move
                if (Math.Abs(knight.Row - endPoint.Row) == 1 &&
                    Math.Abs(knight.Column - endPoint.Column) == 2)
                {
                    move.IsAllowed = true;
                    return move;
                }
            }
            else // This code will run if the knight will take a figure.
            {
                //Vertical move
                if (Math.Abs(knight.Row - endPoint.Row) == 2 &&
                    Math.Abs(knight.Column - endPoint.Column) == 1)
                {
                    move.FigureTaken = true;
                    move.IsAllowed = true;
                    return move;
                }

                //Horizontal move
                if (Math.Abs(knight.Row - endPoint.Row) == 1 &&
                    Math.Abs(knight.Column - endPoint.Column) == 2)
                {
                    move.FigureTaken = true;
                    move.IsAllowed = true;
                    return move;
                }
            }

            return new MoveInfo(false);
        }
    }
}
