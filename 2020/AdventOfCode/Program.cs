using System;
using System.Collections;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tell me the day!");
            var day = Console.ReadLine();
            // var day = "8.2";

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
            else if(day == "4")
            {
                var lines = FileReader.ReadFile(@"../../../input4.txt");
                var valids = PasswordValidator.GetNumberOfValids(lines);
                Console.WriteLine(valids);
            }
            else if(day == "5")
            {
                var lines = FileReader.ReadFile(@"../../../input5.txt");
                var maxId = Boarding.GetMaxId(lines);
                Console.WriteLine(maxId);
            } 
            else if(day == "5.2")
            {
                var lines = FileReader.ReadFile(@"../../../input5.txt");
                var mySeat = Boarding.GetMySeat(lines);
                Console.WriteLine(mySeat);
            } 
            else if(day == "6")
            {
                var lines = FileReader.ReadFile(@"../../../input6.txt");
                var mySeat = Customs.GetSumAnyoneYesAnswers(lines);
                Console.WriteLine(mySeat);
            }
            else if(day == "6.2")
            {
                var lines = FileReader.ReadFile(@"../../../input6.txt");
                var mySeat = Customs.GetSumEveryoneYesAnswers(lines);
                Console.WriteLine(mySeat);
            }
            else if(day == "7")
            {
                var lines = FileReader.ReadFile(@"../../../input7.txt");
                var nBags = Haversacks.GetOuterNumberBags(lines);
                Console.WriteLine(nBags);
            }
            else if(day == "7.2")
            {
                var lines = FileReader.ReadFile(@"../../../input7.txt");
                var nBags = Haversacks.GetInnerNumberBags(lines);
                Console.WriteLine(nBags);
            }
            else if(day == "8")
            {
                var lines = FileReader.ReadFile(@"../../../input8.txt").ToArray();
                var acc = HandheldGameConsole.GetAccumulatorValue(lines).Item2;
                Console.WriteLine(acc);
            }
            else if(day == "8.2")
            {
                var lines = FileReader.ReadFile(@"../../../input8.txt").ToArray();
                var acc = HandheldGameConsole.GetFixedAccumulatorValue(lines);
                Console.WriteLine(acc);
            }
            else if(day == "9")
            {
                var lines = FileReader.ReadFile(@"../../../input9.txt").ToArray();
                var error = EncodingError.GetError(lines.ToArray(), 25);
                Console.WriteLine(error);
            }
            else if(day == "9.2")
            {
                var lines = FileReader.ReadFile(@"../../../input9.txt").ToArray();
                var encryptionweakness = EncodingError.GetEncryptionWeakness(lines.ToArray(), 25);
                Console.WriteLine(encryptionweakness);
            }
            else 
                Console.WriteLine($"Day '{day}' still not implemented!");
        }
    }
}
