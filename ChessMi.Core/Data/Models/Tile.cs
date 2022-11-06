using ChessMi.Core.Data.Enums;

namespace ChessMi.Core.Data.Models
{
    public class Tile
    {
        public Tile(Figure figure)
        {
            Figure = figure;
        }

        public Figure? Figure { get; set; }
    }
}
