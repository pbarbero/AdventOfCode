using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode
{
    public static class SpeakingGame
    {
        public static int GetPosition(int[] numbers, int MAX_NUMBER_SPOKEN)
        {
            var dictIndexes = new Dictionary<int, List<int>>();

            var newNumbersList = new int[MAX_NUMBER_SPOKEN];

            for(var i = 0; i < numbers.Length; i++) 
            {
                newNumbersList[i] = numbers[i];
                dictIndexes.Add(numbers[i], new List<int>{i});
            }

            var sw = new Stopwatch();

            for(int index = numbers.Length; index < MAX_NUMBER_SPOKEN; index++)
            {
                var number = newNumbersList[index-1];
                if(index % 1000 == 0) sw.Start();

                if(dictIndexes.ContainsKey(number))
                    dictIndexes[number].Add(index-1);
                else
                    dictIndexes.Add(number, new List<int>{index-1});

                if(dictIndexes[number].Count() == 1) 
                    newNumbersList[index] = 0;
                else 
                    newNumbersList[index] = dictIndexes[number][dictIndexes[number].Count() - 1] - dictIndexes[number][dictIndexes[number].Count() - 2];

                if(index % 1000 == 0)
                {
                    sw.Stop();
                    Console.WriteLine($"Ellapsed time for iteration {index}: {sw.ElapsedMilliseconds} ms");
                }
            }

            return newNumbersList[MAX_NUMBER_SPOKEN - 1];
        }
    }
}