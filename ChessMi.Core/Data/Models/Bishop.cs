using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Bishop : Figure
    {
        public Bishop(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Bishop";
        }
    }
}
