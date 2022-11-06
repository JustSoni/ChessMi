using ChessMi.Core.Data.Enums;
using ChessMi.Core.Data.Models;
using ChessMi.Core.Services.Interfaces;

namespace ChessMi.Core.Services
{
    public class MoveService : IMoveService
    {

        public MoveInfo CheckLegalMove(Tile[,] board, Figure figure, Figure endPoint)
        {
            if (figure.Name == "Pawn")
            {
                Pawn pawn = (Pawn)figure;
                return pawn.CheckLegalMove(board, pawn, endPoint);
            }
            else if (figure.Name == "Knight")
            {
                Knight knight = (Knight)figure;
                return knight.CheckLegalMove(board, knight, endPoint);
            }
            else if (figure.Name == "Bishop")
            {
                Bishop bishop = (Bishop)figure;
                return bishop.CheckLegalMove(board, bishop, endPoint);
            }
            else if (figure.Name == "Rook")
            {
                Rook rook = (Rook)figure;
                return rook.CheckLegalMove(board, rook, endPoint);
            }
            else if (figure.Name == "Queen")
            {
                Queen queen = (Queen)figure;
                return queen.CheckLegalMove(board, queen, endPoint);
            }
            else if (figure.Name == "King")
            {
                King king = (King)figure;
                return king.CheckLegalMove(board, king, endPoint);
            }


            return new MoveInfo(false);
        }

        public void MakeMove(Tile[,] board, Figure figure, Figure endPoint, MoveInfo move)
        {
            if (move.IsCastling)
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

        public static bool IsEmpty(Figure figure)
        {
            return figure.Name == "Empty";
        }

        public static bool ColorMatches(Figure a, Figure b)
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


                if (king.Column > rook.Column)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (board[king.Row, i].Figure.Name != "Empty")
                        {
                            return board;
                        }
                    }
                    board[king.Row, king.Column - 2].Figure = new King(king.Row, king.Column, king.Color);
                    board[king.Row, king.Column - 1].Figure = new Rook(rook.Row, rook.Column, rook.Color);

                    board[king.Row, king.Column].Figure = new Empty(king.Row, king.Column);
                    board[rook.Row, rook.Column].Figure = new Empty(rook.Row, rook.Column);
                }
                else
                {
                    for (int i = 1; i < 3; i++)
                    {
                        if (board[king.Row, i].Figure.Name != "Empty")
                        {

                        }
                    }
                    board[king.Row, king.Column + 2].Figure = new King(king.Row, king.Column, king.Color);
                    board[king.Row, king.Column + 1].Figure = new Rook(rook.Row, rook.Column, rook.Color);

                    board[king.Row, king.Column].Figure = new Empty(king.Row, king.Column);
                    board[rook.Row, rook.Column].Figure = new Empty(rook.Row, rook.Column);
                }
                return board;
            }

            return board;
        }
    }
}
