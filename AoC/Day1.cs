namespace AoC
{
    public class Day1
    {
        public static void Solve(List<string> input)
        {
            var elfs = input;
            List<int> list = new();
            int calsPerElf = 0;

            foreach (var elf in elfs)
            {
                if (!string.IsNullOrEmpty(elf))
                {
                    calsPerElf += int.Parse(elf);
                    continue;
                }
                list.Add(calsPerElf);
                calsPerElf = 0;
            }

            var topOne = list.OrderByDescending(x => x).Take(1).Sum();
            var topThree = list.OrderByDescending(x => x).Take(3).Sum();

            Console.WriteLine($"Part one: {topOne}");
            Console.WriteLine($"Part two: {topThree}");
        }
    }
}