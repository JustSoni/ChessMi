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
                    if (board[i,j].Figure.Name!="Empty")
                    {
                        DrawFigure(board[i, j].Figure.Name, board[i, j].Figure.Color);
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

        private static void DrawFigure(string name, Color color)
        {
            Console.Write("|");
            if (color == Color.White)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;
            
            switch (name.Length)
            {
                case 4:
                    Console.Write($" {name} ");
                    break;
                case 5:
                    Console.Write($" {name}");
                    break;
                case 6:
                    Console.Write(name);
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
