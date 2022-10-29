﻿using ChessMi.Core.Data.Enums;
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
                        move.FigureTaken = true;
                        return move;
                    }
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !IsEmpty(board[endPoint.Row + 1, endPoint.Column].Figure) && //Checks if the tile below has a Pawn.
                        !ColorMatches(pawn, endPoint))
                    {
                        if(board[endPoint.Row + 1, endPoint.Column].Figure.Name=="Pawn")
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
                        IsEmpty(endPoint))
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
                        move.FigureTaken = true;
                        return move;
                    }
                    if (Math.Abs(endPoint.Column - pawn.Column) == 1 &&
                        !IsEmpty(board[endPoint.Row - 1, endPoint.Column].Figure) && //Checks if the tile below has a Pawn.
                        !ColorMatches(pawn, endPoint))
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
                        IsEmpty(endPoint))
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

        public MoveInfo CheckLegalMove(Tile[,] board, Knight knight, Figure endPoint)
        {
            if (this.ColorMatches(knight, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);

            if (IsEmpty(endPoint)) // This code will run if the knight won't take a figure.
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

        public MoveInfo CheckLegalMove(Tile[,] board, Bishop bishop, Figure endPoint)
        {
            if (this.ColorMatches(bishop, endPoint))
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

            if (!IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            if (deltaRow > 0 && deltaColumn > 0) // UP-LEFT
            {
                for (int i = bishop.Row - 1, j = bishop.Column - 1; i != endPoint.Row; i--, j--)
                {
                    if (!IsEmpty(board[i, j].Figure))
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
                    if (!IsEmpty(board[i, j].Figure))
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
                    if (!IsEmpty(board[i, j].Figure))
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
                    if (!IsEmpty(board[i, j].Figure))
                    {
                        return new MoveInfo(false);
                    }
                }

                move.IsAllowed = true;
                return move;
            }


            return new MoveInfo(false);
        }

        public MoveInfo CheckLegalMove(Tile[,] board, Rook rook, Figure endPoint)
        {
            if (this.ColorMatches(rook, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);


            if (!IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
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

                    if (!IsEmpty(board[i, rook.Column].Figure))
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

                    if (!IsEmpty(board[rook.Row, i].Figure))
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
        public MoveInfo CheckLegalMove(Tile[,] board, Queen queen, Figure endPoint)
        {
            if (this.ColorMatches(queen, endPoint))
            {
                return new MoveInfo(false);
            }

            MoveInfo move = new MoveInfo(false);

            if (!IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
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

                        if (!IsEmpty(board[i, queen.Column].Figure))
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

                        if (!IsEmpty(board[queen.Row, i].Figure))
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
                        if (!IsEmpty(board[i, j].Figure))
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
                        if (!IsEmpty(board[i, j].Figure))
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
                        if (!IsEmpty(board[i, j].Figure))
                        {
                            return new MoveInfo(false);
                        }
                    }

                    move.IsAllowed = true;
                    return move;
                }

                if (deltaRow < 0 && deltaColumn < 0) // DOWN-RIGHT
                {
                    for (int i = queen.Row + 1, j = queen.Column + 1; i != endPoint.Row; i++, j++)
                    {
                        if (!IsEmpty(board[i, j].Figure))
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

        public MoveInfo CheckLegalMove(Tile[,] board, King king, Figure endPoint)
        {
            MoveInfo move = new MoveInfo(false);

            if (this.ColorMatches(king, endPoint) && endPoint.Name == "Rook")
            {
                king.HaveMoved = true;
                Rook rook = (Rook)endPoint;
                rook.HaveMoved = true;

                move.IsAllowed = true;
                return move;
            }

            if (this.ColorMatches(king, endPoint))
            {
                return new MoveInfo(false);
            }


            if (!IsEmpty(endPoint)) // No matter what if there is a figure at the given position it will take it only if the move is valid.
            {
                move.FigureTaken = true;
            }

            int deltaRow = king.Row - endPoint.Row;
            int deltaColumn = king.Column - endPoint.Column;

            if (deltaRow == 0 && deltaColumn == 0)//If source == destination
            {
                return new MoveInfo(false);
            }

            //TODO: Consider adding here if the move might be in check.


            if (Math.Abs(deltaRow) < 2 && Math.Abs(deltaColumn) < 2)
            {
                move.IsAllowed = true;
                king.HaveMoved = true;
                return move;
            }

            return new MoveInfo(false);
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
            if (figure.Name == "King" && endPoint.Name == "Rook")
            {
                board = Castle(board, figure, endPoint);
                return;
            }

            if (move.FigureTaken)
            {
                board[figure.Row, figure.Column].Figure = new Empty(figure.Row, figure.Column);
            }
            else
            {
                board[figure.Row, figure.Column].Figure = endPoint;
            }

            board[endPoint.Row, endPoint.Column].Figure = figure;

            int tempRow = figure.Row;
            int tempColumn = figure.Column;

            figure.Row = endPoint.Row;
            figure.Column = endPoint.Column;


            endPoint.Row = tempRow;
            endPoint.Column = tempColumn;

            foreach (var tile in board)
            {
                if (tile.Figure?.Name == "Pawn")
                {
                    Pawn pawn = (Pawn)tile.Figure;
                    if(pawn.DoubleMove)
                    {
                        pawn.MovesSinceDoubleMove++;
                    }
                }
            }

            if (move.IsEnPassant)
            {
                int color = figure.Color == Color.White ? 1 : -1;
                board[figure.Row + color, figure.Column].Figure = new Empty(endPoint.Row, endPoint.Column);
            }

            if(figure.Name=="Pawn" && (figure.Row==0 || figure.Row==7))
            {
                board = Promotion(board, figure);
            }


        }

        public bool MovesInBoard(int[] moves)
        {
            if (moves.Any(m => m > 7) || moves.Any(m => m < 0))
            {
                return false;
            }
            return true;
        }

        private bool IsEmpty(Figure figure)
        {
            return figure.Name == "Empty";
        }

        private bool ColorMatches(Figure a, Figure b)
        {
            return a.Color == b.Color;
        }

        private Tile[,] Promotion(Tile[,] board, Figure figure)
        {
            Console.WriteLine("Please pick to what figure to promote the pawn: [Queen, Knight, Rook, Bishop]");
            string title = Console.ReadLine();
            title.ToLower();

            while(true)
            {
                if (title == "queen")
                {
                    board[figure.Row, figure.Column].Figure = new Queen(figure.Row, figure.Column, figure.Color);
                    break;
                }
                if (title == "knight")
                {
                    board[figure.Row, figure.Column].Figure = new Knight(figure.Row, figure.Column, figure.Color);
                    break;
                }
                if (title == "rook")
                {
                    board[figure.Row, figure.Column].Figure = new Rook(figure.Row, figure.Column, figure.Color);
                    break;
                }
                if (title == "bishop")
                {
                    board[figure.Row, figure.Column].Figure = new Bishop(figure.Row, figure.Column, figure.Color);
                    break;
                }
            }

            return board;
        }
        private Tile[,] Castle(Tile[,] board, Figure figure, Figure endPoint)
        {
            King king = (King)figure;
            Rook rook = (Rook)endPoint;

            if (king.HaveMoved || rook.HaveMoved)
            {


                board[king.Row, king.Column].Figure = new Empty(king.Row, king.Column);
                board[rook.Row, rook.Column].Figure = new Empty(rook.Row, rook.Column);
                if (king.Column > rook.Column)
                {

                    board[king.Row, king.Column - 2].Figure = new King(king.Row, king.Column, king.Color);
                    board[king.Row, king.Column - 1].Figure = new Rook(rook.Row, rook.Column, rook.Color);
                }
                else
                {

                    board[king.Row, king.Column + 2].Figure = new King(king.Row, king.Column, king.Color);
                    board[king.Row, king.Column + 1].Figure = new Rook(rook.Row, rook.Column, rook.Color);
                }
                return board;
            }

            return board;
        }
    }
}
