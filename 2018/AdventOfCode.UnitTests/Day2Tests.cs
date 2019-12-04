using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.UnitTests
{
    public class Day2Tests
    {
        [Fact]
        [Trait("Category", "Day2")]
        public void Test1()
        {
            var boxes = new List<string>()
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            };

            Assert.True(12 == Checksumeitor.GetChecksum(boxes));
        }

        [Fact]
        [Trait("Category", "Day2")]
        public void Test2()
        {
            var box = "bababc";
            Assert.True(Checksumeitor.HasTwoRepetitions(box));
        }

        [Fact]
        [Trait("Category", "Day2")]
        public void Test3()
        {
            var box = "bababc";
            Assert.True(Checksumeitor.HasThreeRepetitions(box));
        }

        [Fact]
        [Trait("Category", "Day2")]
        public void Test4()
        {
            var boxes = new List<string>()
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz",
            };

            Assert.True("fgij" == Checksumeitor.GetCommonLetters(boxes));
        }

        [Fact]
        [Trait("Category", "Day2")]
        public void Test5()
        {
            Assert.True(Checksumeitor.AreEqualByOneChar("fghij", "fguij"));
        }


        [Fact]
        [Trait("Category", "Day2")]
        public void Test6()
        {
            Assert.False(Checksumeitor.AreEqualByOneChar("abcde", "fghij"));
        }

        [Fact]
        [Trait("Category", "Day2")]
        public void Test7()
        {
            Assert.True("fgij" == Checksumeitor.GetEqualChars("fghij", "fguij"));
        }
    }
}
