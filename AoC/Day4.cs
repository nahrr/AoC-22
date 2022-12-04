using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day4
    {
        public static void Solve(List<string> input)
        {
            int tot = 0;
            int tot2 = 0;
            foreach (var row in input)
            {
                var pairs = row.Split(",");
                var pairOne = pairs[0].Split("-");
                var pairTwo = pairs[1].Split("-");

                var pairOneLow = int.Parse(pairOne[0]);
                var pairOneHigh = int.Parse(pairOne[1]);

                var pairTwoLow = int.Parse(pairTwo[0]);
                var pairTwoHigh = int.Parse(pairTwo[1]);

                if ((pairOneLow <= pairTwoLow && pairOneHigh >= pairTwoHigh) || (pairTwoLow <= pairOneLow && pairOneHigh <= pairTwoHigh))
                    tot++;

                var one = Enumerable.Range(pairOneLow, pairOneHigh - pairOneLow + 1).ToList();
                var two = Enumerable.Range(pairTwoLow, pairTwoHigh - pairTwoLow + 1).ToList();

                two.ForEach(e => one.Add(e));
                if(one.Count != one.Distinct().Count())
                {
                    tot2++;
                }
            }

            Console.WriteLine($"Solution one {tot}");
            Console.WriteLine($"Solution two {tot2}");
        }
    }
}
