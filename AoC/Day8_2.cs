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
            AddCoords(trees);
            var sum = _trees.Select(x => x.Calc());
        }


        //private static void Cols(List<List<int>> trees)
        //{
        //    for (int j = 0; j < trees[0].Count; j++)
        //    {
        //        for (int i = 0; i < trees.Count; i++)
        //        {
        //            AddTree(j, i + 1, trees[i][j]);
        //        }
        //    }
        //}

        private static void AddCoords(List<List<int>> trees)
        {
            for (int row = 0; row < trees.Count; row++)
            {
                for (int col = 0; col < trees.Count; col++)
                {
                    int viewRight = CalcRightView(col, trees[row][col], trees[row]);
                    int viewLeft = CalcLeftView(col, trees[row][col], trees[row]);
                    int viewDown = 1;//CalcDownView(col, trees[row][col], trees);
                   
                    int viewUp = 1;// CalcUpView(col, trees[row][col], trees);
                    _trees.Add(new Tree(viewRight, viewLeft, viewDown, viewUp, trees[row][col]));
                }
            }
        }

        public static int CalcUpView(int col, int current, List<List<int>> trees)
        {
            int count = 0;

            for (int i = trees.Count - 1 - col; i > 0; i--)
            {
                if (current >= trees[i][col])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }

            return count;
        }

        private static int CalcDownView(int col, int current, List<List<int>> trees)
        {
            int count = 0;

            for (int i = 0; i < trees.Count; i++)
            {
                if (current >= trees[i][col])
                {
                    count++;
                }
                else
                {
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
           
            }

            return count;
        }

        private static int CalcLeftView(int col, int current, List<int> row)
        {
            int count = 0;

            for (int i = col; i > 0; i--)
            {
             
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
