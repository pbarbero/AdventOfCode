using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.UnitTests
{
    public class Day6Tests
    {
        [Fact]
        [Trait("Category", "Day6")]
        public void Test1()
        {
            var coordinates = BuildCoordinates();
            var result = Coordinator.GetLargestArea(coordinates);
            Assert.True(17 == result);
        }

        [Fact]
        [Trait("Category", "Day6")]
        public void Test2()
        {
            var result = Coordinator.GetTaxicabDistance(2, 1, 2, 0);
            Assert.True(3 == result);
        }

        [Fact]
        [Trait("Category", "Day6")]
        public void Test3()
        {
            var mainCoordinates = BuildMainCoordinates();
            var coordinate = BuildCoordinate();
            var result = Coordinator.GetClosestCoordinate(coordinate, mainCoordinates);
            Assert.True("1" == result);
        }

        [Fact]
        [Trait("Category", "Day6")]
        public void Test4()
        {
            var coordinates = BuildCoordinates();
            Assert.True(16 == Coordinator.GetSizeOfAreaClosestToAllCoordinates(coordinates, 32));
        }

        [Fact]
        [Trait("Category", "Day6")]
        public void Test5()
        {
            var mainCoordinates = BuildMainCoordinatesSecondPart();
            Assert.True(Coordinator.IsInArea(3, 3, mainCoordinates, 32));
        }

        [Fact]
        [Trait("Category", "Day6")]
        public void Test6()
        {
            var mainCoordinates = BuildMainCoordinatesSecondPart();
            Assert.False(Coordinator.IsInArea(0, 0, mainCoordinates, 32));
        }

        private List<string> BuildCoordinates()
        {
            return new List<string>()
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9",
            };
        }

        private List<Tuple<int, int, string>> BuildMainCoordinates()
        {
            return new List<Tuple<int, int, string>>()
            {
                new Tuple<int, int, string>(1,1, "1"),
                new Tuple<int, int, string>(1,6, "2"),
            };
        }

        private List<Tuple<int, int, string>> BuildMainCoordinatesSecondPart()
        {
            return new List<Tuple<int, int, string>>()
            {
                new Tuple<int, int, string>(1,1, "1"),
                new Tuple<int, int, string>(1,6, "2"),
                new Tuple<int, int, string>(8,3, "2"),
                new Tuple<int, int, string>(3,4, "2"),
                new Tuple<int, int, string>(5,5, "2"),
                new Tuple<int, int, string>(8,9, "2"),
            };
        }

        private Tuple<int, int> BuildCoordinate()
        {
            return new Tuple<int, int>(0, 0);
        }
    }
}
