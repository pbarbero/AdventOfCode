using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    internal static class Extensions
    {
        internal static decimal[] ToDecimals(this IEnumerable<string> self)
        {
            return self.Select(x => decimal.Parse(x)).ToArray();
        }
    }
}