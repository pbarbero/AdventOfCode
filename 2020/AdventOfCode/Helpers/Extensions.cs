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
    }
}
