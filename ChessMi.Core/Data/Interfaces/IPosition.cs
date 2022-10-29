using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMi.Core.Data.Interfaces
{
    public interface IPosition
    {
        public int Row { get; set; }

        public int Column { get; set; }
    }
}
