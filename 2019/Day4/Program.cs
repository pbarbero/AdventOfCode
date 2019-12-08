using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day4");

            var sw = new Stopwatch();
            sw.Start();

            var start = 156218;
            var stop = 652527;
            var digits = new int[10]{0,1,2,3,4,5,6,7,8,9};
            var numbers = new HashSet<double>();

            foreach(var n5 in digits)
            {
                foreach(var n4 in digits)
                {
                    foreach(var n3 in digits)
                    {
                        foreach(var n2 in digits)
                        {
                            foreach(var n1 in digits)
                            {
                                foreach(var n0 in digits)
                                {
                                    if(Rule(n5,n4,n3,n2,n1,n0))
                                    {
                                        var number = Build6DigitsNumber(n5,n4,n3,n2,n1,n0);
                                        if(start <= number && number <= stop)
                                            numbers.Add(number);                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(numbers.Count());
        }

        private static bool Rule(int n5, int n4, int n3, int n2, int n1, int n0)
        {
            if(!IncreaseRule(n5, n4, n3, n2, n1, n0))
                return false;

            if (n5 == n4 && n4 != n3)
                return true;

            if (n4 == n3 &&  n4 != n5 && n3 != n2)
                return true;

            if (n3 == n2 && n3 != n4 && n2 != n1)
                return true;
            
            if (n2 == n1 && n2 != n3 && n1 != n0)
                return true;

            if (n1 == n0 && n1 != n2)
                return true;

            return false;
        }

        private static bool IncreaseRule(int n5, int n4, int n3, int n2, int n1, int n0)
        {
            return n5 <= n4 && n4 <= n3 && n3 <= n2 && n2 <= n1 && n1 <= n0;
        }

        private static double Build6DigitsNumber(int n1, int n2, int n3, int n4, int n5, int n6)
        {
            return n1*Math.Pow(10, 5) 
            + n2*Math.Pow(10, 4)
            + n3*Math.Pow(10, 3)
            + n4*Math.Pow(10, 2)
            + n5*Math.Pow(10, 1)
            + n6*Math.Pow(10, 0);
        }
                
        private static IEnumerable<string> ReadFile(string filePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
