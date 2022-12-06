using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day5
    {
        public static void Solve(List<string> input)
        {
            List<Stack<string>> stacks = new();
            List<Stack<string>> stacks2 = new();
            var colLines = input.Where(x => x.Contains("1")).FirstOrDefault();
            var stackCount = int.Parse(colLines!.ToArray().Select(x => x).Where(x => x != ' ').LastOrDefault().ToString());
            for (int i = 1; i <= stackCount; i++)
            {
                stacks.Add(new Stack<string>());
                stacks2.Add(new Stack<string>());
            }
            input.Reverse();
            foreach (var row in input)
            {
                for (int i = 0; i < stackCount; i++)
                {
                    if (!row.Contains("move") && !string.IsNullOrEmpty(row))
                    {
                        var l = row.Length;
                        var item = row.Substring(i * 4, 3);
                        if (item.Contains("["))
                        {
                            stacks[i].Push(item);
                            stacks2[i].Push(item);
                        }
                    }
                }
            }
            input.Reverse();
            //TODO: tried to implement a stack for my first time, but had to go this ugly way :)
            foreach (var row in input)
            {
                if (row.Contains("move"))
                {
                    var moves = row.Split(' ').Where(x => !char.IsLetter(x.ToCharArray()[0])).ToArray();
                    var y = row;
                    var quantity = int.Parse(moves[0]);
                    var from = int.Parse(moves[1]) - 1;
                    var to = int.Parse(moves[2]) - 1;
                    //Do some moves
                    List<string> tmp = new();
                    for (int j = 1; j <= quantity; j++)
                    {
                        var get = stacks[from].Pop();
                        var get2 = stacks2[from].Pop();
                        tmp.Add(get2);
                        stacks[to].Push(get);
                    }
                    tmp.Reverse();
                    foreach (var t in tmp)
                    {
                        stacks2[to].Push(t);
                    }
                    tmp.Clear();
                }
            }

            var res = "";
            foreach (var col in stacks)
                res += col.First();

            Console.WriteLine($"Solution one {res}");

            var res2 = "";
            foreach (var col in stacks2)
                res2 += col.First();

            Console.WriteLine($"Solution two {res2}");
        }
    }
}

