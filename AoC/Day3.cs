namespace AoC
{
    internal class Day3
    {
        private readonly static List<char> chars = "@abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();
        public static void Solve(List<string> input)
        {
            int sum = 0;
            foreach (var line in input)
            {
                var comparments = line.Chunk(line.Length / 2).ToList();
                sum += chars.IndexOf(comparments[0].Where(comparments[1].Contains).FirstOrDefault());
            }
            Console.WriteLine($"Part one {sum}");
        }

        public static void Solve2(List<string> input)
        {
            int sum = 0;
            var groupsOfThree = input.Chunk(3);
            foreach (var group in groupsOfThree)
            {
               sum += chars.IndexOf(group[0].Where(group[1].Contains).Where(group[2].Contains).FirstOrDefault());
            }
            Console.WriteLine($"Part two {sum}");
        }
    }
}
