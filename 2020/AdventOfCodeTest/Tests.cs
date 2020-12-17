using AdventOfCode;
using System;
using System.Collections.Generic;
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
        public void Test5()
        {
            Assert.Equal(567,  Boarding.GetId("BFFFBBFRRR"));
            Assert.Equal(119, Boarding.GetId("FFFBBBFRRR"));
            Assert.Equal(820, Boarding.GetId("BBFFBBFRLL"));
        }

        [Fact]
        public void Test6()
        {
            var lines = new string[]
            {
                "abc",
                Environment.NewLine,
                "a",
                "b",
                "c",
                Environment.NewLine,
                "ab",
                "ac",
                Environment.NewLine,
                "a",
                "a",
                "a",
                "a",
                Environment.NewLine,
                "b",
            };
            var result = Customs.GetSumAnyoneYesAnswers(lines);

            Assert.Equal(11, result);
        }

        [Fact]
        public void Test6_Part2()
        {
            var lines = new string[]
            {
                "abc",
                Environment.NewLine,
                "a",
                "b",
                "c",
                Environment.NewLine,
                "ab",
                "ac",
                Environment.NewLine,
                "a",
                "a",
                "a",
                "a",
                Environment.NewLine,
                "b",
            };
            var result = Customs.GetSumEveryoneYesAnswers(lines);

            Assert.Equal(6, result);
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

        [Fact]
        public void Test8()
        {
            var lines = new string[]{
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            };
            var result = HandheldGameConsole.GetAccumulatorValue(lines);

            Assert.Equal(5, result.Item2);
        }

        [Fact]
        public void Test8_Part2()
        {
            var lines = new string[]{
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6",
            };
            
            var result = HandheldGameConsole.GetFixedAccumulatorValue(lines);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Test9()
        {
            var lines = new string[]
            {
                "35", "20", "15", "25", "47", "40", "62", "55", "65",
                "95", "102","117", "150", "182", "127", "219", "299", "277",
                "309", "576",
            };

            var result = EncodingError.GetError(lines, 5);

            Assert.Equal(127, result);
        }

         [Fact]
        public void Test9_Part2()
        {
            var lines = new string[]
            {
                "35", "20", "15", "25", "47", "40", "62", "55", "65",
                "95", "102","117", "150", "182", "127", "219", "299", "277",
                "309", "576",
            };

            var result = EncodingError.GetEncryptionWeakness(lines, 5);

            Assert.Equal(62, result);
        }

        [Fact]
        public void Test10()
        {
            var lines = new string[]{"16","10","15","5","1","11","7","19","6","12","4"};
            var result = AdapterArray.GetOneDiffAdaptersMultipliedByThreeDiffAdapters(lines);

            Assert.Equal(35, result);
        }

        [Fact]
        public void Test10_2()
        {
            var lines = new string[]{"28","33","18","42","31","14","46","20","48","47","24","23","49","45","19","38","39",
                                    "11","1","32","25","35","8","17","7","9","4","2","34","10","3"};
            var result = AdapterArray.GetOneDiffAdaptersMultipliedByThreeDiffAdapters(lines);

            Assert.Equal(220, result);
        }

        [Fact(Skip="incomplete")]
        public void Test10_Part2()
        {
            var lines = new string[]{"16","10","15","5","1","11","7","19","6","12","4"};
            var result = AdapterArray.GetNumberOfArragements(lines);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Test11()
        {
            var lines = new string[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL",
            };

            var result = SeatingSystem.GetOccupiedSeatsAtTheEnd(lines, false);

            Assert.Equal(37, result);
        }

        [Fact]
        public void Test11_Part2()
        {
            var lines = new string[]
            {
                "L.LL.LL.LL",
                "LLLLLLL.LL",
                "L.L.L..L..",
                "LLLL.LL.LL",
                "L.LL.LL.LL",
                "L.LLLLL.LL",
                "..L.L.....",
                "LLLLLLLLLL",
                "L.LLLLLL.L",
                "L.LLLLL.LL",
            };

            var result = SeatingSystem.GetOccupiedSeatsAtTheEnd(lines, true);

            Assert.Equal(26, result);
        }

        [Fact]
        public void Test12()
        {
            var lines = new string[]{"F10","N3","F7","R90","F11"};
            var result = RainRisk.GetPositionOfBoat(lines, 90);
            Assert.Equal(25, result);
        }

        [Fact]
        public void Test12_Part2()
        {
            var lines = new string[]{"F10","N3","F7","R90","F11"};
            var result = RainRisk.GetPositionOfBoat_WithVector(lines);
            Assert.Equal(286, result);
        }

        [Fact]
        public void Test14()
        {
            var lines = new string[]
            {
                "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
                "mem[8] = 11",
                "mem[7] = 101",
                "mem[8] = 0"
            };
            ulong result = DockingData.GetSum(lines);
            Assert.Equal((ulong)165, result);
        }

        [Fact]
        public void Test14_Part2()
        {
            var lines = new string[]
            {
                "mask = 000000000000000000000000000000X1001X",
                "mem[42] = 100",
                "mask = 00000000000000000000000000000000X0XX",
                "mem[26] = 1"
            };
            ulong result = DockingData.GetSum(lines, true);
            Assert.Equal((ulong)208, result);
        }

        [Theory]
        [MemberData(nameof(Test15_Data))]
        public void Test15(int expected, params int[] numbers)
        {
            Assert.Equal(expected, SpeakingGame.GetPosition(numbers, 2020));
        }

        [Theory]
        [MemberData(nameof(Test15_Part2_Data))]
        public void Test15_Part2(int expected, params int[] numbers)
        {
            Assert.Equal(expected, SpeakingGame.GetPosition(numbers, 30000000));
        }

        public static IEnumerable<object[]> Test15_Data() {
            yield return new object[] { 436,0,3,6 };
            yield return new object[] { 1,1,3,2 };
            yield return new object[] { 10,2,1,3 };
            yield return new object[] { 27,1,2,3 };
            yield return new object[] { 78,2,3,1 };
            yield return new object[] { 438,3,2,1 };
            yield return new object[] { 1836,3,1,2};
        }

        public static IEnumerable<object[]> Test15_Part2_Data() {
            yield return new object[] { 175594,0,3,6 };
            yield return new object[] { 2578,1,3,2 };
            yield return new object[] { 3544142,2,1,3 };
            yield return new object[] { 261214,1,2,3 };
            yield return new object[] { 6895259,2,3,1 };
            yield return new object[] { 18,3,2,1};
            yield return new object[] { 362,3,1,2};
        }

        [Fact]
        public void Test16()
        {
            var lines = new string[]
            {
                "class: 1-3 or 5-7",
                "row: 6-11 or 33-44",
                "seat: 13-40 or 45-50",
                Environment.NewLine,
                "your ticket:",
                "7,1,14",
                Environment.NewLine,
                "nearby tickets:",
                "7,3,47",
                "40,4,50",
                "55,2,20",
                "38,6,12",
            };
            
            Assert.Equal(71, TicketTranslation.GetScanningErrorRate(lines));
        }

        [Fact]
        public void Test16_Part2()
        {
            
            var lines = new string[]
            {
                "class: 0-1 or 4-19",
                "row: 0-5 or 8-19",
                "seat: 0-13 or 16-19",
                Environment.NewLine,
                "your ticket:",
                "11,12,13",
                Environment.NewLine,
                "nearby tickets:",
                "3,9,18",
                "15,1,5",
                "5,14,9",
            };
            
            var result = TicketTranslation.GetFieldPositions(lines);

            Assert.Equal("seat", result[0].Field);
            Assert.Equal("class", result[1].Field);
            Assert.Equal("row", result[2].Field);

            Assert.Equal(2, result[0].PossiblePositions[0]);
            Assert.Equal(1, result[1].PossiblePositions[0]);
            Assert.Equal(0, result[2].PossiblePositions[0]);
        }
    }
}
