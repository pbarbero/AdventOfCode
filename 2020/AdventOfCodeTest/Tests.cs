using AdventOfCode;
using System;
using Xunit;

namespace AdventOfCodeTest
{
    public class Tests
    {
        [Fact]
        public void Test1()
        {
            var numbers = new decimal[]{1721, 979, 366, 299, 675, 1456};

            var expenseReport = ReportRepair.GetExpenseReport(numbers);

            Assert.True(241861950 == expenseReport);
        }

        [Fact]
        public void Test2()
        {
            var lines = new string[] {"1-3 a: abcde","1-3 b: cdefg","2-9 c: ccccccccc"};
            var passwordsValid = PasswordValidation.GetValidPasswords(lines);

            // Assert.True(2 == passwordsValid);
            Assert.True(1 == passwordsValid);
        }

        
        [Fact]
        public void Test3()
        {
            var lines = new string[] {
                "..##.........##.........##.........##.........##.........##.......",
                "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..",
                ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.",
                "..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#",
                ".#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.",
                "..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....",
                ".#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#",
                ".#........#.#........#.#........#.#........#.#........#.#........#",
                "#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...",
                "#...##....##...##....##...##....##...##....##...##....##...##....#",
                ".#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#" 
            };
            var trees = Toboggan.GetTrees(lines);

            //Assert.True(7 == trees, $"Expected: 7. Actual: {trees}");
            Assert.True(336 == trees, $"Expected: 336. Actual: {trees}");
        }
    }
}
