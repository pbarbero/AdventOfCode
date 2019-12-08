using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day3");
            var lines = ReadFile(@"../../../input.txt").ToList();

            var sw = new Stopwatch();
            sw.Start();
            var matrix0 = GetMatrix(lines[0]);
            sw.Stop();
            Console.WriteLine($"Matrix0 {sw.ElapsedMilliseconds}");
            sw.Restart();
            var matrix1 = GetMatrix(lines[1]);
            sw.Stop();
            Console.WriteLine($"Matrix1 {sw.ElapsedMilliseconds}");


            var hashMatrix0 = new HashSet<Tuple<int,int>>(matrix0);
            var hashMatrix1 = new HashSet<Tuple<int,int>>(matrix1);
            var commonPoints = hashMatrix0.Intersect(hashMatrix1);

            // var distance = commonPoints.Min(p => p.Item1 + p.Item2);
            var distance = commonPoints.Min(p => GetDistanceForPoint(p, matrix0) + GetDistanceForPoint(p, matrix1));
            Console.WriteLine(distance);
        }

        private static int GetDistanceForPoint(Tuple<int, int> point, List<Tuple<int, int>> matrix)
        {
            var distance = 0;
            foreach (var item in matrix)
            {
                distance++;

                if (item.Item1 == point.Item1 && item.Item2 == point.Item2)
                    break;
            }

            return distance;
        }

        private static List<Tuple<int,int>> GetMatrix(string line)
        {
            var points = line.Split(',').ToArray();
            var matrix = new List<Tuple<int,int>>();
            int focusX = 0;
            int focusY = 0;            

            for(int i = 0; i < points.Length; i++)
            {
                var point = points[i];

                if(point.StartsWith("R"))
                {
                    var newX = focusX + GetPosition(point);
                    for(var x = focusX + 1; x <= newX; x++)
                        matrix.Add(new Tuple<int,int>(x, focusY));
                    focusX = newX;
                }
                else if(point.StartsWith("L"))
                {
                    var newX = focusX - GetPosition(point);
                    for(var x = focusX - 1; x >= newX; x--)
                        matrix.Add(new Tuple<int,int>(x, focusY));
                    focusX = newX;
                }
                else if(point.StartsWith("D"))
                {
                    var newY = focusY - GetPosition(point);
                    for(var y = focusY - 1; y >= newY; y--)
                        matrix.Add(new Tuple<int,int>(focusX, y));
                    focusY = newY;
                }
                else if(point.StartsWith("U"))
                {
                    var newY = focusY + GetPosition(point);
                    for(var y = focusY + 1; y <= newY; y++)
                        matrix.Add(new Tuple<int,int>(focusX, y));
                    focusY = newY;
                }
            }

            return matrix;
        }

        private static int GetPosition(string instruction)
        {
            return int.Parse(instruction.Substring(1, instruction.Length - 1));
        }
        
        private static IEnumerable<string> ReadFile(string filePath)
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
