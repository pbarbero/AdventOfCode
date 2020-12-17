using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class HelperExtensions
    {
        internal static int[] ToInt(this string[] self)
        {
            return self.Select(x => x.ToInt()).ToArray();
        }

        internal static int ToInt(this string self)
        {
            var result = 0;
            if(!int.TryParse(self, out result)) 
                throw new System.Exception($"Number {self} is bad");
            return result;
        }

        internal static uint ToUint(this string self)
        {
            var result = (uint)0;
            if(!uint.TryParse(self, out result)) 
                throw new System.Exception($"Number {self} is bad");
            return result;
        }

        internal static ulong ToUlong(this string self)
        {
            var result = (ulong)0;
            if(!ulong.TryParse(self, out result)) 
                throw new System.Exception($"Number {self} is bad");
            return result;
        }

        internal static long[] ToLong(this string[] self)
        {
            return self.Select(x => x.ToLong()).ToArray();
        }

        internal static long ToLong(this string self)
        {
            var result = (long)0;
            if(!long.TryParse(self, out result)) 
                throw new System.Exception($"Number {self} is bad");
            return result;
        }

        internal static int Multiply(this IEnumerable<int> self)
        {
            var result = 1;
            foreach(var x in self)
                result = result * x;

            return result;
        }
    }
}
