namespace AoC
{
    public class Day1
    {
        public static void Solve(List<string> input)
        {
            List<int> calsPerElfList = new();
            int calsPerElf = 0;

            foreach (var elfItem in input)
            {
                if (!string.IsNullOrEmpty(elfItem))
                {
                    calsPerElf += int.Parse(elfItem);
                    continue;
                }
                calsPerElfList.Add(calsPerElf);
                calsPerElf = 0;
            }

            var topOne = calsPerElfList.OrderByDescending(x => x).Take(1).Sum();
            var topThree = calsPerElfList.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine($"Part one: {topOne}");
            Console.WriteLine($"Part two: {topThree}");
        }
    }
}