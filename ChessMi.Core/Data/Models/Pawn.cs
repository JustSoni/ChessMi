using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Pawn : Figure
    {
        public Pawn(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "Pawn";
        }
    }
}
