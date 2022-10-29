using ChessMi.Core.Data.Models;
using ChessMi.Core.Services;
using System.Text.RegularExpressions;

Tile[,] board = BoardGeneratorService.Generate();

BoardDrawerService.DrawBoard(board);//TODO: Implement it.

MoveService service = new MoveService();

MoveInfo move = new MoveInfo(false);

string moveInput = String.Empty;

while (true)
{
    moveInput = Console.ReadLine();

    if (!Regex.IsMatch(moveInput, "^[a-h][1-8][-][a-h][1-8]$"))
    {
        Console.WriteLine("Invalid input format! Try again.");
        continue;
    }

    if (moveInput == "0")
    {
        break;
    }
}