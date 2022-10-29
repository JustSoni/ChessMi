using ChessMi.Core.Data.Models;
using ChessMi.Core.Services;
using System.Text.RegularExpressions;

Tile[,] board = BoardGeneratorService.Generate();

BoardDrawerService.DrawBoard(board);//TODO: Implement it.

MoveService service = new MoveService();

MoveInfo move = new MoveInfo(false);

MoveInterpreterService interpreter = new MoveInterpreterService();

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

    int[] translatedMove = interpreter.Translate(moveInput);

    Console.WriteLine(String.Join(' ', translatedMove.Select(x => x.ToString()).ToArray())); // Too see the coordinates

    if (!service.MovesInBoard(translatedMove))
    {
        Console.WriteLine("Invlaid move! There is no such tile!");
        continue;
    }

    int row1 = translatedMove[1];
    int col1 = translatedMove[0];

    int row2 = translatedMove[3];
    int col2 = translatedMove[2];

    Figure source = board[row1, col1].Figure;
    Figure destination = board[row2, col2].Figure;

    move = service.CheckLegalMove(board, source, destination);

    if (move.IsAllowed)
    {
        service.MakeMove(board, source, destination, move); // TODO: NOT ADDED YET.
        BoardDrawerService.DrawBoard(board); // ALSO NOT ADDED YET >.<
    }
    else
    {
        Console.WriteLine("Invalid move! The piece can't move there.");
    }
}