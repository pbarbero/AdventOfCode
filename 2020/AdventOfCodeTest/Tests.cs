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

        [Fact]
        public void Test4()
        {
            var lines = new string[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm",
                Environment.NewLine,
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929",
                Environment.NewLine,
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm",
                Environment.NewLine,
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in",
            };

            var valids = PasswordValidator.GetNumberOfValids(lines);

            Assert.True(2 == valids, $"Expected: 2. Actual: {valids}");
        }
    }
}
