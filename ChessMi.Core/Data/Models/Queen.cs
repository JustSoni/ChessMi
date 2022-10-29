using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Queen : Figure
    {
        public Queen(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Queen";
        }
    }
}
