using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day1!");
            var lines = ReadFile(@"../../../input.txt");

            int total = 0;
            foreach(var line in lines)
                total += CalculateModule(line.ToDecimal());

            Console.WriteLine(total);
        }

        private static int CalculateModule(decimal mass)
        {
            var module = (int)(mass / 3) - 2;

            if(module > 0)
                module += CalculateModule(module);
            else
                return 0;

            return module;
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
