using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Sleightor
    {
        private static List<Tuple<char, char>> Requisites;
        private static HashSet<char> Steps;

        public static string GetOrderToBuildSleight(List<string> lines)
        {
            ParseData(lines);
            var orderedLetters = GetSteps();
            return string.Join(string.Empty, orderedLetters);
        }

        public static List<char> GetSteps()
        {
            var result = new List<char>();
            var step = Requisites[0].Item1;
            result.Add(step);
            
            while (Steps.Count > 0)
            {
                var possibleNextSteps = GetPossibleNextSteps(step);
                step = possibleNextSteps.Where(x => ArePrerequisitesComplete(x, result)).FirstOrDefault();
                result.Add(step);
                Steps.Remove(step);
            }

            return result;
        }

        private static List<char> GetPossibleNextSteps(char c)
        {
            return Requisites.Where(x => x.Item1 == c).Select(x => x.Item2).OrderBy(z => z).ToList();
        }

        private static bool ArePrerequisitesComplete(char c, List<char> result)
        {
            var prerequisitesForChar = Requisites.Where(x => x.Item2 == c).Select(x => x.Item1);
            return prerequisitesForChar.All(x => result.Contains(x));
        }

        private static void ParseData(List<string> lines)
        {
            Requisites = new List<Tuple<char, char>>();
            Steps = new HashSet<char>();

            foreach (var line in lines)
            {
                var upperChars = line.ToList().Where(x => char.IsUpper(x)).ToArray();
                var step = new Tuple<char, char>
                (
                    upperChars[1],
                    upperChars[2]
                );
                Requisites.Add(step);
                Steps.Add(upperChars[1]);
                Steps.Add(upperChars[2]);
            }
        }
    }
}
