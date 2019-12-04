using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day2");
            var lines = ReadFile(@"../../../input.txt");

            var steps = GetSteps(lines);
            var noun = 0;
            var verb = 0;

            for(int i = 0; i < 100; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    steps = GetSteps(lines);
                    var result = Try(steps, i, j);

                    if(19690720 == result)
                    {
                        noun = i;
                        verb = j;
                        break;
                    }
                }
            }

            Console.WriteLine(100*noun + verb);
        }

        private static int Try(int[] steps, int noun, int verb)
        {
            steps[1] = noun;
            steps[2] = verb;

            for (int i = 0; i < steps.Count(); i = i + 4)
            {
                var item = steps[i];

                if (item == 1)
                    steps[steps[i + 3]] = steps[steps[i + 1]] + steps[steps[i + 2]];
                else if (item == 2)
                    steps[steps[i + 3]] = steps[steps[i + 1]] * steps[steps[i + 2]];
                else if (item == 99)
                    break;
            }

            return steps[0];
        }

        private static int[] GetSteps(IEnumerable<string> lines)
        {
            return lines.First().Split(',').Select(x => x.ToInt()).ToArray();
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
