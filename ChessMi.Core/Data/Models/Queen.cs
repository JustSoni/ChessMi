using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class Queen : Figure
    {
        public Queen(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Queen";
        }


        internal MoveInfo CheckLegalMove(Tile[,] board, Queen queen, Figure endPoint)
        {
            if (MoveService.ColorMatches(queen, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);

            if (!MoveService.IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            if (queen.Row == endPoint.Row || queen.Column == endPoint.Column)
            {
                // Vertically
                if (queen.Column == endPoint.Column)
                {
                    for (int i = queen.Row; i != endPoint.Row;
                        i += (queen.Row > endPoint.Row ? -1 : 1))
                    {
                        if (i == queen.Row) //TODO : Remove
                        {
                            continue;
                        }

                        if (!MoveService.IsEmpty(board[i, queen.Column].Figure))
                        {
                            return new MoveInfo(false);
                        }
                    }



                    move.IsAllowed = true;
                    return move;
                }

                // Horizontally
                if (queen.Row == endPoint.Row)
                {
                    for (int i = queen.Column + 1; i != endPoint.Column;
                        i += (queen.Column > endPoint.Column ? -1 : 1))
                    {
                        if (i == queen.Column) //TODO : Remove
                        {
                            continue;
                        }

                        if (!MoveService.IsEmpty(board[queen.Row, i].Figure))
                        {
                            return new MoveInfo(false);
                        }
                    }

                    move.IsAllowed = true;
                    return move;
                }
            }
            else
            {
                int deltaRow = queen.Row - endPoint.Row;
                int deltaColumn = queen.Column - endPoint.Column;


                if (Math.Abs(deltaRow) != Math.Abs(deltaColumn))
                {
                    return new MoveInfo(false);
                }

                if (deltaRow > 0 && deltaColumn > 0) // UP-LEFT
                {
                    for (int i = queen.Row - 1, j = queen.Column - 1; i != endPoint.Row; i--, j--)
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
                    for (int i = queen.Row - 1, j = queen.Column + 1; i != endPoint.Row; i--, j++)
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
                    for (int i = queen.Row + 1, j = queen.Column - 1; i != endPoint.Row; i++, j--)
                    {
                        if (MoveService.IsEmpty(board[i, j].Figure))
                        {
                            continue;
                        }
                        return new MoveInfo(false);
                    }

                    move.IsAllowed = true;
                    return move;
                }

                if (deltaRow < 0 && deltaColumn < 0) // DOWN-RIGHT
                {
                    for (int i = queen.Row + 1, j = queen.Column + 1; i != endPoint.Row; i++, j++)
                    {
                        if (!MoveService.IsEmpty(board[i, j].Figure))
                        {
                            return new MoveInfo(false);
                        }
                    }

                    move.IsAllowed = true;
                    return move;
                }
            }

            return new MoveInfo(false);
        }
    }
}
