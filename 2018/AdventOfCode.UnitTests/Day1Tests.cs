using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.UnitTests
{
    public class Day1Tests
    {
        [Fact]
        [Trait("Category", "Day1")]
        public void Test1()
        {
            var frequencyChanges = new List<int>() { 1, 1, 1 };

            Assert.True(3 == GetResultingFrequency(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test2()
        {
            var frequencyChanges = new List<int>() { 1, 1, -2 };

            Assert.True(0 == GetResultingFrequency(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test3()
        {
            var frequencyChanges = new List<int>() { -1, -2, -3 };

            Assert.True(-6 == GetResultingFrequency(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test4()
        {
            var frequencyChanges = new List<int>() { 1, -1 };

            Assert.True(0 == GetFrequencyReachesTwice(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test5()
        {
            var frequencyChanges = new List<int>() { +3, +3, +4, -2, -4 };

            Assert.True(10 == GetFrequencyReachesTwice(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test6()
        {
            var frequencyChanges = new List<int>() { -6, +3, +8, +5, -6 };

            Assert.True(5 == GetFrequencyReachesTwice(frequencyChanges));
        }

        [Fact]
        [Trait("Category", "Day1")]
        public void Test7()
        {
            var frequencyChanges = new List<int>() { +7, +7, -2, -7, -4 };

            Assert.True(14 == GetFrequencyReachesTwice(frequencyChanges));
        }

        private int GetResultingFrequency(List<int> frequencyChanges)
        {
            return Frequenceitor.GetResultingFrequency(frequencyChanges);
        }

        private int GetFrequencyReachesTwice(List<int> frequencyChanges)
        {
            return Frequenceitor.GetFrequencyReachesTwice(frequencyChanges);
        }
    }
}
