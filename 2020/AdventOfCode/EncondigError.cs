using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class EncodingError
    {
        public static long GetEncryptionWeakness(string[] lines, int preamble)
        {
            var error = GetError(lines, preamble);
            var sumRange = GetSumRange(lines, error);

            return sumRange.Max() + sumRange.Min();
        }

        public static long GetError(string[] lines, int preamble)
        {
            for(var i = preamble; i < lines.Count(); i++)
            {
                var preambleSet = GetPreamble(lines, i - preamble, preamble);
                if(!lines[i].ToLong().IsSumInPreamble(preambleSet)) return lines[i].ToLong();
            }

            throw new System.Exception($"Error not found");
        }

        private static List<long> GetSumRange(string[] lines, long error)
        {
            var sumRange = new List<long>();
            var numbers = lines.ToLong();
            var sum = (long)0;

            for(var i = 0; i < numbers.Count(); i++)
            {
                sumRange = new List<long>{ numbers[i] };
                sum = numbers[i];

                for(var j = i +1; j < numbers.Count(); j++)
                {
                    sumRange.Add(numbers[j]);

                    if(sum + numbers[j] > error)
                        break;
                    else if(sum + numbers[j] < error)
                        sum = sum + numbers[j];
                    else 
                        return sumRange;
                }
            }

            throw new System.Exception($"Sum range not found for {error}");
        }

        private static HashSet<long> GetPreamble(string[] lines, int initPreamble, int preamble)
        {
            var preambleSet = new HashSet<long>();
            for(var i = initPreamble; i < initPreamble + preamble; i++)
                preambleSet.Add(lines[i].ToLong());

            return preambleSet;
        }

        private static bool IsSumInPreamble(this long self, HashSet<long> preambleSet)
        {
            foreach(var number in preambleSet)
                if(preambleSet.Any(number2 => number2 != number && number2 + number == self)) return true;

            return false;
        }

        private static long[] ToLong(this string[] self)
        {
            return self.Select(x => x.ToLong()).ToArray();
        }

        private static long ToLong(this string self)
        {
            var result = (long)0;
            if(!long.TryParse(self, out result)) 
                throw new System.Exception($"Number {self} is bad");
            return result;
        }
    }
}