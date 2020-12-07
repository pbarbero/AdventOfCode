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

        [Fact]
        public void Test4_Invalid()
        {
            
            var lines = new string[]
            {
                "eyr:1972 cid:100",
                "hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926",
                Environment.NewLine,
                "iyr:2019",
                "hcl:#602927 eyr:1967 hgt:170cm",
                "ecl:grn pid:012533040 byr:1946",
                Environment.NewLine,
                "hcl:dab227 iyr:2012",
                "ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277",
                Environment.NewLine,
                "hgt:59cm ecl:zzz",
                "eyr:2038 hcl:74454a iyr:2023",
                "pid:3556412378 byr:2007",
            };

            var valids = PasswordValidator.GetNumberOfValids(lines);

            Assert.True(0 == valids, $"Expected: 0. Actual: {valids}");
        }

        [Fact]
        public void Test4_Valid()
        {
            var lines = new string[]
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f",
                Environment.NewLine,
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                Environment.NewLine,
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022",
                Environment.NewLine,
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719",
            };

            var valids = PasswordValidator.GetNumberOfValids(lines);

            Assert.True(4 == valids, $"Expected: 4. Actual: {valids}");
        }

        [Fact]
        public void Test7()
        {
            var lines = new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };
            var nBags = Haversacks.GetOuterNumberBags(lines);
            Assert.True(4 == nBags, $"Expected: 4. Actual: {nBags}");
        }

        [Fact]
        public void Test7_Part2()
        {
            var lines = new string[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags.",
            };
            
            var nBags = Haversacks.GetInnerNumberBags(lines);
            Assert.True(126 == nBags, $"Expected: 126. Actual: {nBags}");
        }
    }
}
