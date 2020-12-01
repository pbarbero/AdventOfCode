using System;

namespace AdventOfCode
{
    public static class ReportRepair
    {
        private const decimal year = 2020;

        public static decimal GetExpenseReport(decimal[] values)
        {
            for(var i = 0; i < values.Length; i++)
                for(var j = i +1; j < values.Length; j++)
                    for(var k = j +1; k < values.Length; k++)
                        if(values[i]+values[j]+values[k] == year) return values[i]*values[j]*values[k];

            throw new System.Exception("Expense report not found");
        }
    }  
}