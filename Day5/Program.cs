using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            List<int> numbers  = new List<int>();
            System.IO.File.ReadAllLines(@currentDirectory + "/data").ToList().ForEach(x => numbers.Add(Int32.Parse(x)));

            int steps = 0;            
            int i = 0;
            int increment = 0;
            
            while(0 <= i && i < numbers.Count())
            {
                increment = numbers[i];
                numbers[i]++;
                i += increment;
                steps++;
            }

            Console.Write(steps);
        }
    }
}
