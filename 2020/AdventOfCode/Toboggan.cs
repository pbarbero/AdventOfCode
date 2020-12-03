using System.Collections.Generic;
using System.Linq;

namespace  AdventOfCode
{
    public static class Toboggan
    {
        private static char TREE = '#';
        public static decimal GetTrees(IEnumerable<string> lines)
        {
            var forest = lines.ToArray();

            return GetNTrees(forest, 1, 1)
            * GetNTrees(forest, 3, 1)
            * GetNTrees(forest, 5, 1)
            * GetNTrees(forest, 7, 1)
            * GetNTrees(forest, 1, 2);
        }

        private static decimal GetNTrees(string[] forest, int right, int down)
        {
            var row = 0;
            var column = 0;
            var width = forest[0].Length;
            var nTress = 0;

            while (column < width && row < forest.Length)
            {
                if (forest[row][column] == TREE) nTress++;

                column = column + right;

                if (column >= width) column = column - width;
                row = row + down;
            }

            return nTress;
        }
    }
}