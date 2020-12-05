using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe
{
    public class Helpers
    {
        public static string CalculateWinner(List<string> squares)
        {
            var lines = new[]
            {
                new[] { 0, 1, 2 },
                new[] { 3, 4, 5 },
                new[] { 6, 7, 8 },
                new[] { 0, 3, 6 },
                new[] { 1, 4, 7 },
                new[] { 2, 5, 8 },
                new[] { 0, 4, 8 },
                new[] { 2, 4, 6 },
            };

            foreach (var line in lines)
            {
                var a = line[0];
                var b = line[1];
                var c = line[2];

                if (!string.IsNullOrEmpty(squares[a]) && squares[a] == squares[b] && squares[a] == squares[c])
                {
                    return squares[a];
                }
            }

            return null;
        }
    }
}