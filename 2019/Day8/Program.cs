using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Day8!");

            var lines = ReadFile(@"../../../input.txt");
            var nWide = 25;
            var nTall = 6;

            var points = lines.First().ToCharArray().Select(x => x.ToString().ToInt());
            var numberOfItems = nWide*nTall;
            var howManyLayers = points.Count() / (numberOfItems);

            var layers = new List<List<int>>();
            for(var i = 0; i < howManyLayers; i++)
                layers.Add(points.Skip(i*numberOfItems).Take(numberOfItems).ToList());

            var image = new List<bool>();

            for(var pixel = 0; pixel < nTall * nWide; pixel++)
            {
                foreach(var layer in layers)
                {
                    var color = layer[pixel];
                    if(color != 2)
                    {
                        image.Add(color == 0);                        
                        break;
                    }
                }
            }

            for(var i = 0; i < image.Count(); i++)
            {
                if(i % nWide == 0)
                    Console.WriteLine();
                Console.Write(image[i] ? " ": "X");
            }
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
