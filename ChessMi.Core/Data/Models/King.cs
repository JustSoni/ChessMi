using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class King : Figure
    {
        public King(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "King";
            HaveMoved = false;
        }
        public bool HaveMoved { get; set; }


        internal MoveInfo CheckLegalMove(Tile[,] board, King king, Figure endPoint)
        {
            MoveInfo move = new MoveInfo(false);

            if (MoveService.ColorMatches(king, endPoint) && endPoint.Name == "Rook")
            {
                king.HaveMoved = true;
                Rook rook = (Rook)endPoint;
                rook.HaveMoved = true;

                move.IsCastling = true;
                move.IsAllowed = true;
                if (king.Column > rook.Column)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (board[king.Row, i].Figure.Name != "Empty")
                        {
                            move.IsAllowed = false;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (board[king.Row, i].Figure.Name != "Empty")
                        {
                            move.IsAllowed = false;
                            break;
                        }
                    }
                }
                return move;
            }

            if (MoveService.ColorMatches(king, endPoint))
            {
                return new MoveInfo(false);
            }


            if (!MoveService.IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            int deltaRow = king.Row - endPoint.Row;
            int deltaColumn = king.Column - endPoint.Column;

            if (deltaRow == 0 && deltaColumn == 0)//If source == destination
            {
                return new MoveInfo(false);
            }

            //TODO: Add Check.


            if (Math.Abs(deltaRow) < 2 && Math.Abs(deltaColumn) < 2)
            {
                move.IsAllowed = true;
                king.HaveMoved = true;
                return move;
            }

            return new MoveInfo(false);
        }
    }
}
