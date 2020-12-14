using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class AdapterArray
    {
        public static int GetNumberOfArragements(string[] lines)
        {
            var maxShit = lines.ToInt().Max() + 3;
            var adapters = lines.ToInt().Append(0).Append(maxShit).OrderBy(x => x).ToArray();

            var alreadyChecked = new HashSet<int>();
            return GetComination(0, adapters, ref alreadyChecked) + 1;
        }

        private static int GetComination(int indexToCheck, int[] adapters, ref HashSet<int> alreadyChecked)
        {
            Console.WriteLine($"adapterToCheck: {indexToCheck}");
            var combination = 0;

            if(alreadyChecked.Any(x => x == indexToCheck))
                return 0;
            else    
                alreadyChecked.Add(indexToCheck);

            var posibleAdaptersInedx = new HashSet<int>();

            for(var i = indexToCheck + 1 ; i < adapters.Count(); i++)
            {
                if(adapters[i].IsValidAdapterFor(adapters[indexToCheck]))
                {
                    posibleAdaptersInedx.Add(i);
                }
            }

            Console.WriteLine($"posibleAdaptersInedx: {string.Join(",", posibleAdaptersInedx)}");
            if(posibleAdaptersInedx.Any()) combination += (posibleAdaptersInedx.Count()-1);
            
            foreach(var index in posibleAdaptersInedx)
            {
                combination += GetComination(index, adapters, ref alreadyChecked);
            }

            return combination;
        }

        private static bool IsValidAdapterFor(this int adpt, int adapterToCheck)
        {
            return adpt != adapterToCheck && adpt - adapterToCheck < 4 && adpt - adapterToCheck > 0;
        }

        private static int Multiply(this IEnumerable<int> self)
        {
            var result = 1;
            foreach(var x in self)
                result = result * x;

            return result;
        }

        public static int GetOneDiffAdaptersMultipliedByThreeDiffAdapters(string[] lines)
        {
            var oneDiffAdapters = new HashSet<int>();
            var threeDiffAdapters = new HashSet<int>();
            var adapters = lines.ToInt().Append(0).OrderBy(x => x);

            foreach(var adapter in adapters)
            {
                var validAdapters = adapters.Where(adpt => adpt != adapter && adpt - adapter < 4);
                
                var oneDiffAdaptersBy = validAdapters.Where(adpt => adpt - adapter == 1);
                var threeDiffAdaptersBy = validAdapters.Where(adpt => adpt - adapter == 3);

                if(oneDiffAdaptersBy.Any()) oneDiffAdapters.UnionWith(oneDiffAdaptersBy);
                else if(threeDiffAdaptersBy.Any()) threeDiffAdapters.UnionWith(threeDiffAdaptersBy);
            }

            return oneDiffAdapters.Count() * (threeDiffAdapters.Count() + 1);
        }
    }
}