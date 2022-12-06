using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day6
    {
        public static void Solve(List<string> input)
        {
            Console.WriteLine($"Solution 1 {TuningTrouble(input, 4)}");
            Console.WriteLine($"Solution 2 {TuningTrouble(input, 14)}");
        }

        private static int TuningTrouble(List<string> input, int take)
        {
            var chars = new List<char>();
            int i = 1;
            foreach (var c in input.First())
            {
                chars.Add(c);
                if (i >= take)
                {
                    chars.Reverse();
                    var last4 = chars.Take(take);
                    if (last4.Distinct().Count() == last4.Count())
                        break;
                   
                    chars.Reverse();
                }
                i++;
            }
            return i;
        }
    }
}
