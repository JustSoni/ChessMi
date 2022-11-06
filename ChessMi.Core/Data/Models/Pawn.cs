using ChessMi.Core.Data.Enums;
using ChessMi.Core.Services;

namespace ChessMi.Core.Data.Models
{
    public class Pawn : Figure
    {
        public Pawn(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Pawn";
            HaveMoved = false;
            DoubleMove = false;
            MovesSinceDoubleMove = 0;
        }

        public bool HaveMoved { get; set; }
        public bool DoubleMove { get; set; }
        public int MovesSinceDoubleMove { get; set; }

        internal MoveInfo CheckLegalMove(Tile[,] board, Pawn pawn, Figure endPoint)
        {
            if (MoveService.ColorMatches(pawn, endPoint))
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
                        MoveService.IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        return move;

                    }
                    //If the move is diagonal in order to take a figure
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !MoveService.IsEmpty(endPoint) &&
                        !MoveService.ColorMatches(pawn, endPoint))
                    {
                        move.IsAllowed = true;
                        move.FigureTaken = true;
                        return move;
                    }
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !MoveService.IsEmpty(board[endPoint.Row + 1, endPoint.Column].Figure) && //Checks if the tile below has a Pawn.
                        !MoveService.ColorMatches(pawn, endPoint))
                    {
                        if (board[endPoint.Row + 1, endPoint.Column].Figure.Name == "Pawn")
                        {
                            Pawn takenPawn = (Pawn)board[endPoint.Row + 1, endPoint.Column].Figure;
                            if (takenPawn.DoubleMove && takenPawn.MovesSinceDoubleMove == 1)
                            {
                                move.IsAllowed = true;
                                move.FigureTaken = true;
                                move.IsEnPassant = true;
                                return move;
                            }
                        }
                    }

                }
                if (pawn.HaveMoved)
                {
                    return new MoveInfo(false);
                }
                if (pawn.Row - endPoint.Row == 2)
                {
                    if (pawn.Column == endPoint.Column &&
                        MoveService.IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        pawn.HaveMoved = true;
                        pawn.DoubleMove = true;
                        return move;
                    }
                }
            }

            if (pawn.Color == Color.Black)
            {
                //One tile move downwards
                if (pawn.Row - endPoint.Row == -1)
                {
                    //If the move is vertical
                    if (pawn.Column == endPoint.Column &&
                        MoveService.IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        return move;
                    }
                    //If the move is diagonal in order to take a figure
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !MoveService.IsEmpty(endPoint) &&
                        !MoveService.ColorMatches(pawn, endPoint))
                    {
                        move.IsAllowed = true;
                        move.FigureTaken = true;
                        return move;
                    }
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !MoveService.IsEmpty(board[endPoint.Row - 1, endPoint.Column].Figure) && //Checks if the tile below has a Pawn.
                        !MoveService.ColorMatches(pawn, endPoint))
                    {
                        if (board[endPoint.Row - 1, endPoint.Column].Figure.Name == "Pawn")
                        {
                            Pawn takenPawn = (Pawn)board[endPoint.Row - 1, endPoint.Column].Figure;
                            if (takenPawn.DoubleMove && takenPawn.MovesSinceDoubleMove == 1)
                            {
                                move.IsAllowed = true;
                                move.FigureTaken = true;
                                move.IsEnPassant = true;
                                return move;
                            }
                        }
                    }
                }
                if (pawn.HaveMoved)
                {
                    return new MoveInfo(false);
                }
                if (pawn.Row - endPoint.Row == -2)
                {
                    if (pawn.Column == endPoint.Column &&
                        MoveService.IsEmpty(endPoint))
                    {
                        move.IsAllowed = true;
                        pawn.HaveMoved = true;
                        pawn.DoubleMove = true;
                        return move;
                    }
                }
            }

            return new MoveInfo(false);


        }
    }
}