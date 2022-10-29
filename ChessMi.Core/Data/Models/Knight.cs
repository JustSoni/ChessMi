using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Knight : Figure
    {
        public Knight(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Knight";
        }
    }
}
