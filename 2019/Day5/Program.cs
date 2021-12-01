using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day5");
            var lines = ReadFile(@"../../../input.txt");

            var steps = GetSteps(lines);            
            Try(steps);
        }

        private static void Try(int[] steps)
        {
            var pointer = 0;

            while(pointer != -1)
            {
                var instruction = InstructionFactory.Create(pointer, steps);
                instruction.Execute();
                pointer = instruction.GetStepNextInstruction();
            }
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
