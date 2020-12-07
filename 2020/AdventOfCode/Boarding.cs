using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Boarding 
    {
        public static int GetMySeat(IEnumerable<string> lines)
        {
            var allIds = lines.Select(x => GetId(x));

            for(var i = allIds.Min(); i <= allIds.Max(); i++)
                if(allIds.Contains(i) && !allIds.Contains(i+1) && allIds.Contains(i+2)) return i+1;

            throw new System.Exception($"Seat not found");
        }

        public static int GetMaxId(IEnumerable<string> lines)
        {
            return lines.Select(x => GetId(x)).Max();
        }

        public static int GetId(string boardingPass)
        {
            var row = GetRowFromBinaryRow(boardingPass.Substring(0, 7), 0, 127, 'B', 'F');
            var column = GetRowFromBinaryRow(boardingPass.Substring(7, boardingPass.Length - 7), 0, 7, 'R', 'L');

            return row * 8 + column;
        }

        private static int GetRowFromBinaryRow(string boardingPass, int lowerBound, int upperBound, char lowerLetter, char upperLetter)
        {
            foreach(char c in boardingPass)
            {
                var mean = (upperBound - lowerBound) / 2;

                if (c == lowerLetter)
                    lowerBound = lowerBound + mean + 1;
                else if (c == upperLetter)
                    upperBound = upperBound - mean - 1;
            }

            if (upperBound != lowerBound) throw new System.Exception($"Upperbound: {upperBound}. Lowerbound: {lowerBound}");

            return upperBound;
        }
    }
}