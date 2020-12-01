using AdventOfCode;
using System;
using Xunit;

namespace AdventOfCodeTest
{
    public class Day1
    {
        [Fact]
        public void Test1()
        {
            var numbers = new decimal[]{1721, 979, 366, 299, 675, 1456};

            var expenseReport = ReportRepair.GetExpenseReport(numbers);

            Assert.True(241861950 == expenseReport);
        }
    }
}
