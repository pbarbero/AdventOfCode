using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.UnitTests
{
    public class Day7Tests
    {
        [Fact]
        [Trait("Category", "Day7")]
        public void Test1()
        {
            var lines = BuildLines();
            Assert.True("CABDFE" == Sleightor.GetOrderToBuildSleight(lines));
        }

        private List<string> BuildLines()
        {
            return new List<string>()
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin."
            };
        }
    }
}
