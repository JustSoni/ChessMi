using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Empty : Figure
    {
        public Empty(int row, int column)
           : base(row, column, Color.NoColor)
        {
            this.Name = "Empty";
        }
    }
}
