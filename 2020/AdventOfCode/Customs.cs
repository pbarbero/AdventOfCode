using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Customs
    {
        public static int GetSumAnyoneYesAnswers(IEnumerable<string> lines)
        {
            return GetGroupAnswers(lines).Sum(x => x.Count());
        }

        public static int GetSumEveryoneYesAnswers(IEnumerable<string> lines)
        {
            return GetGroupAnswersByPerson(lines).Sum(x => IntersectMany(x).Count());
        }

        private static HashSet<char> IntersectMany(List<HashSet<char>> sets)
        {
            var interSet = sets.FirstOrDefault();

            foreach(var set in sets.Skip(1))
                interSet = set.Intersect(interSet).ToHashSet();

            return interSet;
        }

        private static List<HashSet<char>> GetGroupAnswers(IEnumerable<string> lines)
        {
            var groupAnswers = new List<HashSet<char>>();
            var currentGroup = new HashSet<char>();

            foreach (var line in lines)
            {
                if (line.IsEmptyLine())
                {
                    groupAnswers.Add(currentGroup);
                    currentGroup = new HashSet<char>();
                }
                else
                    line.ToList().ForEach(x => currentGroup.Add(x));
            }

            groupAnswers.Add(currentGroup);

            return groupAnswers;
        }
        
        private static List<List<HashSet<char>>> GetGroupAnswersByPerson(IEnumerable<string> lines)
        {
            var groupAnswersByPerson = new List<List<HashSet<char>>>();
            var currentGroup = new List<HashSet<char>>();

            foreach(var line in lines)
            {
                if(line.IsEmptyLine())
                {
                    groupAnswersByPerson.Add(currentGroup);
                    currentGroup = new List<HashSet<char>>();
                }
                else
                    currentGroup.Add(line.ToHashSet());
            }

            groupAnswersByPerson.Add(currentGroup);

            return groupAnswersByPerson;
        }

        private static bool IsEmptyLine(this string line)
        {
            return line == Environment.NewLine || line == "\r\n" || line == "";
        }
    }
}