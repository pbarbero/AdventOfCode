using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AdventOfCode.Utils;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Write day to execute..");
            var day = Console.ReadLine();

            var correctDay = true;

            while (correctDay)
            {
                switch (day)
                {
                    case "1":
                        correctDay = false;
                        Day1();
                        break;
                    case "2":
                        correctDay = false;
                        Day2();
                        break;
                    case "3":
                        correctDay = false;
                        Day3();
                        break;
                    case "4":
                        correctDay = false;
                        Day4();
                        break;
                    case "5":
                        correctDay = false;
                        Day5();
                        break;
                    case "6":
                        correctDay = false;
                        Day6();
                        break;
                    case "7":
                        correctDay = false;
                        Day7();
                        break;
                    default:
                        Console.WriteLine($"Fuck u, insert me a correct day");
                        day = Console.ReadLine();
                        break;
                };
            }


        }

        private static void Day1()
        {
            var frequencies = new List<int>();
            var lines = ReadFile(@"../../../input1.txt");

            foreach (var line in lines)
            {
                var frequency = Int32.Parse(line);
                frequencies.Add(frequency);
            }

            var result = Frequenceitor.GetResultingFrequency(frequencies);

            Console.WriteLine($"Result is: {result}");
            Console.ReadKey();

            var resultTwice = Frequenceitor.GetFrequencyReachesTwice(frequencies);

            Console.WriteLine($"Result device reaches twice is: {resultTwice}");
            Console.ReadKey();
        }

        private static void Day2()
        {
            var boxes = new List<string>();
            var lines = ReadFile(@"../../../Data/input2.txt");

            foreach (var line in lines)
            {
                boxes.Add(line.Trim());
            }

            var result = Checksumeitor.GetChecksum(boxes);

            Console.WriteLine($"Result is: {result}");
            Console.ReadKey();

            var resultLetters = Checksumeitor.GetCommonLetters(boxes);

            Console.WriteLine($"Result second part is: {resultLetters}");
            Console.ReadKey();
        }

        private static void Day3()
        {
            var claims = new List<Claim>();
            var lines = ReadFile(@"../../../Data/input3.txt");

            foreach (var line in lines)
            {
                var atSplit = line.Split('@');
                var marginSizeSplit = atSplit[1].Split(':');
                var margins = marginSizeSplit[0].Trim().Split(',');
                var sizes = marginSizeSplit[1].Trim().Split('x');

                claims.Add(
                    new Claim()
                    {
                        Id = atSplit[0].Trim(),
                        MarginLeft = int.Parse(margins[0]),
                        MarginTop = int.Parse(margins[1]),
                        Width = int.Parse(sizes[0]),
                        Height = int.Parse(sizes[1]),
                    }
                );
            }

            var result = Claimeitor.GetNumberOverlappedClaims(claims);

            Console.WriteLine($"Result is: {result}");

            var result2 = Claimeitor.GetIsolatedClaim(claims);

            Console.WriteLine($"Result second part is: {result2}");
            Console.ReadKey();
        }

        private static void Day4()
        {
            var claims = new List<Tuple<DateTime, string>>();
            var lines = ReadFile(@"../../../Data/input4.txt");

            var idGuard = Asleepeitor.GetIdGuardMostAsleep(lines.ToList());
            var minute = Asleepeitor.GetMinuteMostAsleep("#" + idGuard);
            var result = int.Parse(idGuard) * minute;

            Console.WriteLine($"Result is: {result}");
            Console.ReadKey();
            
            var result2 = Asleepeitor.GetMinuteMostAsleepForGuard();

            Console.WriteLine($"Result is: {result2}");
            Console.ReadKey();
        }

        private static void Day5()
        {
            var lines = ReadFile(@"../../../Data/input5.txt");

            var result = Polarizeitor.Scan(lines.First());

            Console.WriteLine($"Result is: {result}");
            
            var result2 = Polarizeitor.BestScan(lines.First());

            Console.WriteLine($"Result is: {result2}");
            Console.ReadKey();
        }

        private static void Day6()
        {
            var lines = ReadFile(@"../../../Data/input6.txt");

            var result = Coordinator.GetLargestArea(lines.ToList());

            Console.WriteLine($"Result is: {result}");
            Console.ReadKey();

            var result2 = Coordinator.GetSizeOfAreaClosestToAllCoordinates(lines.ToList(), 10000);

            Console.WriteLine($"Result part two is: {result2}");
            Console.ReadKey();
        }

        private static void Day7()
        {
            var lines = ReadFile(@"../../../Data/input7.txt");

            var result = Sleightor.GetOrderToBuildSleight(lines.ToList());

            Console.WriteLine($"Result is: {result}");
            Console.ReadKey();

            //var result2 = Coordinator.GetSizeOfAreaClosestToAllCoordinates(lines.ToList(), 10000);

            //Console.WriteLine($"Result part two is: {result2}");
            //Console.ReadKey();
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
