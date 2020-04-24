using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class Helpers
    {
        public static string CalculateWinner(string[] squares)
        {
            var lines = new List<(int, int, int)>
            {
                (0, 1, 2),
                (3, 4, 5),
                (6, 7, 8),
                (0, 3, 6),
                (1, 4, 7),
                (2, 5, 8),
                (0, 4, 8),
                (2, 4, 6)
            };

            foreach (var line in lines)
            {
                var (a, b, c) = line;
                if (squares[a] != null && squares[a] == squares[b] &&
                    squares[a] == squares[c])
                {
                    return squares[a];
                }
            }

            return null;
        }
    }
}