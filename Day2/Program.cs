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
            string[] lines = System.IO.File.ReadAllLines(@currentDirectory + "/data");

            decimal result = 0;
            foreach (string line in lines)
            {
                List<decimal> numbers = new List<decimal>();
                line.Split("\t").ToList().ForEach(x => numbers.Add(Decimal.Parse(x)));

                result += numbers.Max() - numbers.Min();                
            }

            Console.Write(result);
        }
    }
}
