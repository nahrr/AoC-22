using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day8_2 : Day8
    {
        private static List<Tree> _trees = new();
        public static void Solve2(List<string> input)
        {
            var trees = ParseTrees(input);
            CalcScenicScore(trees);
            Console.WriteLine($"Soluton 2 {_trees.Select(x => x.Calc()).Max()}");

        }
        private static void CalcScenicScore(List<List<int>> trees)
        {
            for (int row = 0; row < trees.Count; row++)
            {
                for (int col = 0; col < trees.Count; col++)
                {
                    int viewRight = CalcRightView(col, trees[row][col], trees[row]);
                    int viewLeft = CalcLeftView(col, trees[row][col], trees[row]);
                    int viewDown = CalcDownView(col, trees[row][col], trees, row);
                    int viewUp = CalcUpView(col, trees[row][col], trees, row);
                    _trees.Add(new Tree(viewRight, viewLeft, viewDown, viewUp, trees[row][col]));
                }
            }
        }

        public static int CalcUpView(int col, int current, List<List<int>> trees, int row)
        {
            int count = 0;

            for (int i = row - 1; i >= 0; i--)
            {
                if (current > trees[i][col])
                {
                    count++;
                }
                else
                {
                    count++;
                    break;
                }
            }

            return count;
        }

        private static int CalcDownView(int col, int current, List<List<int>> trees, int row)
        {
            if (row + 1 == trees.Count)
                return 0;

            int count = 0;

            for (int i = row + 1; i < trees.Count; i++)
            {
                if (current > trees[i][col])
                {
                    count++;
                }
                else
                {
                    count++;
                    break;
                }
            }

            return count;
        }

        private static int CalcRightView(int col, int current, List<int> row)
        {
            int count = 0;

            for (int i = col + 1; i < row.Count; i++)
            {
                if (current > row[i])
                {
                    count++;
                }
                else
                {
                    count++;
                    break;
                }
            }

            return count;
        }

        private static int CalcLeftView(int col, int current, List<int> row)
        {
            int count = 0;

            for (int i = col - 1; i >= 0; i--)
            {
                if (current > row[i])
                    count++;
                else
                {
                    count++;
                    break;
                }
            }

            return count;
        }

        private class Tree
        {
            public Tree(int viewRight, int viewLeft, int viewDown, int viewUp, int height)
            {
                ViewRight = viewRight;
                ViewLeft = viewLeft;
                ViewDown = viewDown;
                ViewUp = viewUp;
                Height = height;
            }

            public int ViewRight { get; set; }
            public int ViewLeft { get; set; }
            public int ViewDown { get; set; }
            public int ViewUp { get; set; }
            public int Height { get; set; }

            public int Calc()
            {
                return ViewRight * ViewLeft * ViewDown * ViewUp;
            }
        }
    }
}
