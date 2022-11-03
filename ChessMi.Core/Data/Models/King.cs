using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class King : Figure
    {
        public King(int row, int column, Color color)
            : base(row, column, color)
        {
            Name = "King";
            HaveMoved = false;
            IsCastling = false;
        }
        public bool HaveMoved { get; set; }
        public bool IsCastling { get; set; }
    }
}
