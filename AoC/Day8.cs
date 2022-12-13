using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC
{
    internal class Day8
    {
        private static List<Tree> _trees = new();
        public static void Solve(List<string> input)
        {
            var trees = ParseTrees(input);
            CalcRows(trees, false);
            CalcRows(trees, true);
            CalcCols(trees);
            CalcColsRev(trees);
           
            Console.WriteLine($"Solution one {_trees.Count()}");
        }

        private static void AddTree(int x, int y, int height)
        {
            if (!_trees.Where(t => t.X == x && t.Y == y).Any())
            {
                _trees.Add(new Tree(x, y, height));
            }
        }
        private static void CalcCols(List<List<int>> trees)
        {
            for (int j = 0; j < trees[0].Count; j++)
            {
                int treeHeight = 0;
                for (int i = 0; i < trees.Count; i++)
                {
                    if (i == 0)
                        treeHeight = trees[i][j];

                    if ((j == 0 || j == trees.Count - 1) && i < trees.Count)
                    {
                        AddTree(j, i, trees[i][j]);
                        continue;
                    }

                    if (trees[i][j] > treeHeight)
                        treeHeight = trees[i][j];

                    if (i + 1 == trees.Count)
                        break;

                    if (trees[i + 1][j] == treeHeight) { continue; }
                    if (trees[i + 1][j] > treeHeight || j == 0)
                    {
                        AddTree(j, i + 1, trees[i + 1][j]);
                    }
                }
            }
        }

        private static void CalcColsRev(List<List<int>> trees)
        {
            for (int j = trees[0].Count - 1; j >= 0; j--)
            {
                int treeHeight = 0;
                for (int i = trees.Count - 1; i >= 0; i--)
                {
                    if (i == trees.Count - 1)
                        treeHeight = trees[i][j];

                    if ((j == trees[0].Count - 1 || j == 0))
                    {
                        AddTree(j, i, trees[i][j]);
                        continue;
                    }

                    if (trees[i][j] > treeHeight)
                        treeHeight = trees[i][j];

                    if (i == 0)
                        break;

                    if (trees[i - 1][j] == treeHeight) { continue; }

                    if (trees[i - 1][j] > treeHeight || j == trees[0].Count - 1)
                    {
                        AddTree(j, i - 1, trees[i - 1][j]);
                    }
                }
            }
        }

        private static void CalcRows(List<List<int>> trees, bool reverse)
        {
            int y = 0;
            foreach (var row in trees)
            {
                if (reverse)
                    row.Reverse();

                int treeHeight = -1;
                for (int i = 0; i < row.Count; i++)
                {
                    if ((y == 0 || y == row.Count - 1) && i < row.Count)
                    {
                        if (reverse)
                        {
                            AddTree(row.Count - 1 - i, y, row[i]);
                        }
                        else
                        {
                            AddTree(i, y, row[i]);
                        }
                        continue;
                    }

                    if (row[i] > treeHeight)
                        treeHeight = row[i];

                    if (i == row.Count - 1)
                        break;

                    if (row[i + 1] == treeHeight) { continue; }
                    if (row[i + 1] > treeHeight)
                    {
                        if (reverse)
                        {
                            AddTree(row.Count - 2 - i, y, row[i + 1]);
                        }
                        else
                        {
                            AddTree(i + 1, y, row[i + 1]);
                        }
                    }
                }
                y++;
                if (reverse)
                    row.Reverse();
            }
        }

        private protected static List<List<int>> ParseTrees(List<string> input)
        {
            List<List<int>> trees = new();
            foreach (string row in input)
            {
                List<int> treesRow = new();
                foreach (char c in row)
                {
                    treesRow.Add(int.Parse(c.ToString()));
                }
                trees.Add(treesRow);
            }
            return trees;
        }

        private class Tree
        {
            public Tree(int x, int y, int height)
            {
                X = x;
                Y = y;
                Height = height;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Height { get; set; }
        }
    }
}
