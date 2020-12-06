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

            return forest.GetNTreesInPath(1, 1)
            * forest.GetNTreesInPath(3, 1)
            * forest.GetNTreesInPath(5, 1)
            * forest.GetNTreesInPath(7, 1)
            * forest.GetNTreesInPath(1, 2);
        }

        private static decimal GetNTreesInPath(this string[] forest, int right, int down)
        {
            var row = 0;
            var column = 0;
            var width = forest[0].Length;
            var nTress = 0;

            while (column < width && row < forest.Length)
            {
                if (forest[row][column] == TREE) nTress++;

                column = (column + right >= width) ? column = column + right - width : column + right;
                row = row + down;
            }

            return nTress;
        }
    }
}