using ChessMi.Core.Data.Interfaces;

namespace ChessMi.Core.Data.Models
{
    public class Position : IPosition
    {
        public int Row { get; set; }

        public int Column { get; set; }
    }
}