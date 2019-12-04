using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Coordinator
    {
        public static int GetLargestArea(List<string> coordinates)
        {
            var mainCoordinates = ParseData(coordinates);
            var grid = BuildGrid(mainCoordinates);
            var centralKeys = SelectCentralCoordinates(grid);
            return grid.Where(x => centralKeys.Contains(x.Key)).Select(x => x.Value.Count()).Max();
        }

        public static int GetSizeOfAreaClosestToAllCoordinates(List<string> coordinates, int threshold)
        {
            var mainCoordinates = ParseData(coordinates);
            var areaLength = 0;

            for (int j = 0; j <= mainCoordinates.Select(x => x.Item2).Max(); j++)
            {
                for (int i = 0; i <= mainCoordinates.Select(x => x.Item1).Max(); i++)
                {
                    areaLength = IsInArea(i, j, mainCoordinates, threshold) ? areaLength + 1 : areaLength;
                }
            }
            
            return areaLength;
        }

        public static bool IsInArea(int X, int Y, List<Tuple<int, int, string>> mainCoordinates, int range)
        {
            var sumDistances = 0;

            foreach (var mainCoordinate in mainCoordinates)
            {
                sumDistances += GetTaxicabDistance(X, mainCoordinate.Item1, Y, mainCoordinate.Item2);
            }

            return sumDistances < range;
        }

        public static string GetClosestCoordinate(Tuple<int, int> coordinate, List<Tuple<int, int, string>> mainCoordinates)
        {
            var distances = new List<Tuple<string, int>>();

            foreach (var mainCoordinate in mainCoordinates)
            {
                var distance = GetTaxicabDistance(mainCoordinate.Item1, coordinate.Item1, mainCoordinate.Item2, coordinate.Item2);

                distances.Add(new Tuple<string, int>(mainCoordinate.Item3, distance));
            }

            var minDistance = distances.Select(x => x.Item2).Min();

            var distanceCoordinates = distances.Where(x => x.Item2 == minDistance);

            if (distanceCoordinates.Count() == 1)
            {
                return distanceCoordinates.First().Item1;
            }
            else
            {
                return string.Empty;
            }
        }

        public static int GetTaxicabDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private static List<Tuple<int, int, string>> ParseData(List<string> lines)
        {
            var coordinates = new List<Tuple<int, int, string>>();
            var name = 1;

            foreach (var line in lines)
            {
                var splited = line.Split(',');
                var tuple = new Tuple<int, int, string>(
                    int.Parse(splited[0].Trim()),
                    int.Parse(splited[1].Trim()),
                    name.ToString()
                    );

                coordinates.Add(tuple);
                name++;
            }

            return coordinates;
        }

        private static Dictionary<string, List<Tuple<int, int>>> BuildGrid(List<Tuple<int, int, string>> mainCoordinates)
        {
            var dictionary = new Dictionary<string, List<Tuple<int, int>>>();

            for (int j = 0; j <= mainCoordinates.Select(x => x.Item2).Max(); j++)
            {
                for (int i = 0; i <= mainCoordinates.Select(x => x.Item1).Max(); i++)
                {
                    var coordinate = new Tuple<int, int>(i, j);
                    var closestCoordinate = GetClosestCoordinate(coordinate, mainCoordinates);

                    if (dictionary.ContainsKey(closestCoordinate))
                    {
                        dictionary[closestCoordinate].Add(coordinate);
                    }
                    else
                    {
                        dictionary.Add(closestCoordinate, new List<Tuple<int, int>>() { coordinate });
                    }
                }
            }

            return dictionary;
        }

        private static List<string> SelectCentralCoordinates(Dictionary<string, List<Tuple<int, int>>> grid)
        {
            var centrals = new List<string>() { string.Empty };

            foreach (var key in grid.Keys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    var pointsForArea = grid[key];
                    var hasPointsInRight = IsSurroundedOnTheRight(pointsForArea, grid);
                    var hasPointsInLeft = IsSurroundedOnTheLeft(pointsForArea, grid);
                    var hasPointsInTop = IsSurroundedOnTheTop(pointsForArea, grid);
                    var hastPointsInBottom = IsSurroundedOnTheBottom(pointsForArea, grid);

                    if (hasPointsInRight && hasPointsInLeft && hasPointsInTop && hastPointsInBottom)
                    {
                        centrals.Add(key);
                    }
                }
            }

            return centrals;
        }

        private static bool IsSurroundedOnTheRight(List<Tuple<int, int>> pointsInArea, Dictionary<string, List<Tuple<int, int>>> grid)
        {
            var maxX = pointsInArea.Select(x => x.Item1).Max();
            var pointsInTheRight = pointsInArea.Where(x => x.Item1 == maxX);

            return pointsInTheRight.All(x => grid.Any(area => area.Value.Select(y => y.Item1).Any(z => z > x.Item1)));
        }

        private static bool IsSurroundedOnTheLeft(List<Tuple<int, int>> pointsInArea, Dictionary<string, List<Tuple<int, int>>> grid)
        {
            var minX = pointsInArea.Select(x => x.Item1).Min();
            var pointsInTheLeft = pointsInArea.Where(x => x.Item1 == minX);

            return pointsInTheLeft.All(x => grid.Any(area => area.Value.Select(y => y.Item1).Any(z => z < x.Item1)));
        }

        private static bool IsSurroundedOnTheTop(List<Tuple<int, int>> pointsInArea, Dictionary<string, List<Tuple<int, int>>> grid)
        {
            var minY = pointsInArea.Select(x => x.Item2).Min();
            var pointsInTheTop = pointsInArea.Where(x => x.Item2 == minY);

            return pointsInTheTop.All(x => grid.Any(area => area.Value.Select(y => y.Item2).Any(z => z < x.Item2)));
        }

        private static bool IsSurroundedOnTheBottom(List<Tuple<int, int>> pointsInArea, Dictionary<string, List<Tuple<int, int>>> grid)
        {
            var maxY = pointsInArea.Select(x => x.Item2).Max();
            var pointsInTheBottom = pointsInArea.Where(x => x.Item2 == maxY);

            return pointsInTheBottom.All(x => grid.Any(area => area.Value.Select(y => y.Item2).Any(z => z > x.Item2)));
        }
    }
}
