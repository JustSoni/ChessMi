using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Rook : Figure
    {
        public Rook(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Rook";
        }
    }
}
