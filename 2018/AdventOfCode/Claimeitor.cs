using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Utils;

namespace AdventOfCode
{
    public static class Claimeitor
    {
        public static int GetNumberOverlappedClaims(List<Claim> claims)
        {
            var fabric = CreateFabric();

            foreach (var claim in claims)
            {
                for (int i = claim.MarginTop; i < claim.MarginTop + claim.Height; i++)
                {
                    for (int j = claim.MarginLeft; j < claim.MarginLeft + claim.Width; j++)
                    {
                        fabric[i][j] = fabric[i][j] + 1;
                    }
                }
            }

            return CountBigger2(fabric);
        }

        public static string GetIsolatedClaim(List<Claim> claims)
        {
            var dictfabric = CreateDetailedFabric(claims);
            var claimsIds = claims.Select(x => x.Id);
            var overLappedIds = new List<string>();
            var overLappedInches = dictfabric.Where(x => x.Value.Count() > 1);

            foreach(var inch in overLappedInches)
            {
                overLappedIds.AddRange(dictfabric[inch.Key]);
            }
            
            var except = claimsIds.Except(overLappedIds.Distinct());

            return except.First();
        }

        private static Dictionary<string, List<string>> CreateDetailedFabric(List<Claim> claims)
        {
            var fabric = new Dictionary<string, List<string>>();

            foreach (var claim in claims)
            {
                for (int i = claim.MarginTop; i < claim.MarginTop + claim.Height; i++)
                {
                    for (int j = claim.MarginLeft; j < claim.MarginLeft + claim.Width; j++)
                    {
                        var key = i + "," + j;
                        if(fabric.ContainsKey(key))
                        {
                            fabric[key].Add(claim.Id);
                        }
                        else
                        {
                            fabric.Add(key, new List<string>(){ claim.Id });
                        }
                    }
                }
            }

            return fabric;
        }

        private static int[][] CreateFabric()
        {
            var fabric = new int[1000][];

            for (int i = 0; i < 1000; i++)
            {
                int[] row = new int[1000];

                for (int j = 0; j < 1000; j++)
                {
                    row[j] = 0;
                }

                fabric[i] = row;
            }

            return fabric;
        }

        private static int CountBigger2(int[][] matrix)
        {
            var count = 0;

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
