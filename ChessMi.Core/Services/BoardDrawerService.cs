using ChessMi.Core.Data.Enums;
using ChessMi.Core.Data.Models;
using static ChessMi.Core.Common.GlobalConstants;

namespace ChessMi.Core.Services
{
    public class BoardDrawerService
    {
        private static readonly string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H" };

        public static void DrawBoard(Tile[,] board)
        {
            int rowCount = 8;

            const string top = " -----------------";
            for (int i = 0; i < BoardRows; i++)
            {
                for (int k = 0; k < BoardColumns; k++)
                {
                    Console.Write("|      ");
                }

                Console.WriteLine("|");

                for (int j = 0; j < BoardColumns; j++)
                {

                    if (board[i, j].Figure.Name == "Rook")
                    {
                        Console.Write("| ");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Rook ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (board[i, j].Figure.Name == "Knight")
                    {
                        Console.Write("|");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Knight");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (board[i, j].Figure.Name == "Bishop")
                    {
                        Console.Write("|");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Bishop");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (board[i, j].Figure.Name == "Queen")
                    {
                        Console.Write("| ");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Queen");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (board[i, j].Figure.Name == "King")
                    {
                        Console.Write("|");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" King ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (board[i, j].Figure.Name == "Pawn")
                    {
                        Console.Write("|");
                        if (board[i, j].Figure.Color == Color.White)
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" Pawn ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("|      ");
                    }
                }
                Console.Write($"| {rowCount--}");
                Console.WriteLine();
                for (int k = 0; k < BoardColumns; k++)
                {
                    Console.Write("|______");
                }

                Console.WriteLine("|");
            }
            Console.Write("   ");
            for (int i = 0; i < BoardColumns; i++)
            {
                Console.Write($"{letters[i]}      ");
            }
            Console.WriteLine();
        }
    }
}
