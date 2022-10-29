using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMi.Core.Services
{
    public class MoveInterpreterService
    {
        public int[] Translate(string input)
        {
            int[] moves = new int[4];

            int index = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '-')
                {
                    //TODO: IMPLEMENT Translation
                    if (input[i] > 96 && input[i] < 123)
                    {
                        moves[index++] = input[i] - 97;//char to number.
                    }
                    else
                    {
                        moves[index++] = Math.Abs((int)input[i] - 49 - 7); // -49 to make it from ascii to int, -7 to reverse the row number.
                    }
                }
            }
            return moves;
        }
    }
}