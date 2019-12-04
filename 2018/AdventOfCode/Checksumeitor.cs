using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Checksumeitor
    {
        public static int GetChecksum(List<string> boxes)
        {
            var howMany2 = boxes.Where(x => HasTwoRepetitions(x)).Count();
            var howMany3 = boxes.Where(x => HasThreeRepetitions(x)).Count();

            return howMany2 * howMany3;
        }

        public static bool HasTwoRepetitions(string box)
        {
            var dictionary = box.GroupBy(c => c)
                                .Select(g => new { Letter = g.Key, Count = g.Count() });

            return dictionary.Where(x => x.Count == 2).Any();
        }

        public static bool HasThreeRepetitions(string box)
        {
            var dictionary = box.GroupBy(c => c)
                                .Select(g => new { Letter = g.Key, Count = g.Count() });

            return dictionary.Where(x => x.Count == 3).Any();
        }

        public static string GetCommonLetters(List<string> boxes)
        {
            for (int i = 0; i < boxes.Count(); i++)
            {
                for (int j = i + 1; j < boxes.Count(); j++)
                {
                    if (AreEqualByOneChar(boxes[i], boxes[j]))
                    {
                        return GetEqualChars(boxes[i], boxes[j]);
                    }
                }
            }

            return "foo";
        }

        public static bool AreEqualByOneChar(string box1, string box2)
        {
            int howManyDistincts = 0;

            for (int i = 0; i < box1.Length; i++)
            {
                howManyDistincts = box1[i] != box2[i] ? howManyDistincts + 1 : howManyDistincts;
            }

            return howManyDistincts == 1;
        }

        public static string GetEqualChars(string box1, string box2)
        {
            var indexesDistinct = new List<int>();

            for (int i = 0; i < box1.Length; i++)
            {
                if (box1[i] != box2[i])
                {
                    indexesDistinct.Add(i);
                }
            }

            var result = string.Empty;

            for (int i = 0; i < box1.Length; i++)
            {
                if (!indexesDistinct.Contains(i))
                {
                    result += box1[i];
                }
            }

            return result;
        }
    }
}
