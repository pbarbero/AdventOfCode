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
            // var day = Console.ReadLine();
            var day = "12.2";

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
            else if(day == "10")
            {
                var lines = FileReader.ReadFile(@"../../../input10.txt").ToArray();
                var  result = AdapterArray.GetOneDiffAdaptersMultipliedByThreeDiffAdapters(lines);
                Console.WriteLine(result);
            }
            else if(day == "10.2")
            {
                var lines = FileReader.ReadFile(@"../../../input10.txt").ToArray();
                var  result = AdapterArray.GetNumberOfArragements(lines);
                Console.WriteLine(result);
            }
            else if(day == "11")
            {
                var lines = FileReader.ReadFile(@"../../../input11.txt").ToArray();
                var  result = SeatingSystem.GetOccupiedSeatsAtTheEnd(lines, false);
                Console.WriteLine(result);
            }
            else if(day == "11.2")
            {
                var lines = FileReader.ReadFile(@"../../../input11.txt").ToArray();
                var  result = SeatingSystem.GetOccupiedSeatsAtTheEnd(lines, true);
                Console.WriteLine(result);
            }
            else if(day == "12")
            {
                var lines = FileReader.ReadFile(@"../../../input12.txt").ToArray();
                var  result = RainRisk.GetPositionOfBoat(lines, 90);
                Console.WriteLine(result);
            }
            else if(day == "12.2")
            {
                var lines = FileReader.ReadFile(@"../../../input12.txt").ToArray();
                var  result = RainRisk.GetPositionOfBoat_WithVector(lines);
                Console.WriteLine(result);
            }
            else if(day == "14")
            {
                var lines = FileReader.ReadFile(@"../../../input14.txt").ToArray();
                var  result = DockingData.GetSum(lines);
                Console.WriteLine(result);
            }
            else if(day == "14.2")
            {
                var lines = FileReader.ReadFile(@"../../../input14.txt").ToArray();
                var  result = DockingData.GetSum(lines, true);
                Console.WriteLine(result);
            }
            else if(day == "15")
            {
                var numbers = new int[]{0,1,5,10,3,12,19};
                var  result = SpeakingGame.GetPosition(numbers, 2020);
                Console.WriteLine(result);
            }
            else if(day == "15.2")
            {
                var numbers = new int[]{0,1,5,10,3,12,19};
                var  result = SpeakingGame.GetPosition(numbers, 30000000);
                Console.WriteLine(result);
            }
            else if(day == "16")
            {
                var lines = FileReader.ReadFile(@"../../../input16.txt").ToArray();
                var result = TicketTranslation.GetScanningErrorRate(lines);
                Console.WriteLine(result);
            }
            else if(day == "16.2")
            {
                var lines = FileReader.ReadFile(@"../../../input16.txt").ToArray();
                var result = TicketTranslation.GetMultiplied6Values(lines);
                Console.WriteLine(result);
            }
            else 
                Console.WriteLine($"Day '{day}' still not implemented!");
        }
    }
}
