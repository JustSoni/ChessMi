using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Tile : Position
    {
        public Tile(int row, int column, Color color, Figure figure)
        {
            Row = row;
            Column = column;
            Color = color;
            Figure = figure;
        }
        public Color Color { get; set; }

        public Figure? Figure { get; set; }
    }
}
