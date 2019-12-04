using System.Collections.Generic;

namespace AdventOfCode
{
    public static class Frequenceitor
    {
        public static int GetResultingFrequency(List<int> frequencyChanges)
        {
            var start = 0;

            foreach (var item in frequencyChanges)
            {
                start += item;
            }

            return start;
        }

        public static int GetFrequencyReachesTwice(List<int> frequencyChanges)
        {
            var start = frequencyChanges[0];
            var calculatedFrequencies = new List<int>();

            for (int i = 1; i <= frequencyChanges.Count; i++)
            {
                i = i == frequencyChanges.Count ? 0 : i;
                start += frequencyChanges[i];

                if (calculatedFrequencies.Contains(start))
                {
                    break;
                }
                else
                {
                    calculatedFrequencies.Add(start);
                }
            }

            return start;
        }
    }
}
