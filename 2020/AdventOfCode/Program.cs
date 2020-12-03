﻿using System;
using System.Collections;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tell me the day!");
            // var day = Console.ReadLine();
            var day = "3";

            if(day == "1")
            {
                var lines = FileReader.ReadFile(@"../../../input.txt");
                var result = ReportRepair.GetExpenseReport(lines.ToDecimals());
                Console.WriteLine(result);
            }
            else if(day == "2")
            {
                var lines = FileReader.ReadFile(@"../../../input2.txt");
                var result = PasswordValidation.GetValidPasswords(lines);
                Console.WriteLine(result);
            }
            else if(day == "3")
            {
                var lines = FileReader.ReadFile(@"../../../input3.txt");
                var result = Toboggan.GetTrees(lines);
                Console.WriteLine(result);
            }
            else 
                Console.WriteLine($"Day '{day}' still not implemented!");
        }
    }
}
