using ChessMi.Core.Data.Enums;
using ChessMi.Core.Data.Interfaces;

namespace ChessMi.Core.Data.Models
{
    public class Figure : Position, IFigure
    {
        public Figure(int row, int column, Color color)
        {
            Row = row;
            Column = column;
            Color = color;
            Promoted = false;
        }

        public bool Promoted { get; set; }
        public string Name { get; set; } = default!;

        public Color Color { get; set; }
    }
}
