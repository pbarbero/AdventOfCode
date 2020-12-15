using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode 
{
    public static class DockingData
    {
        private const int LENGTH = 36;
        private const string RegexMem = @"^mem\[(\d+)\] = (\d+)$";
        private const string RegexMask = @"^mask = ([0-1X]+)$$";

        public static ulong GetSum(string[] lines, bool partTwo = false)
        {
            var maskInstructions = GetMaskInstructions(lines);
            var memory = new Dictionary<ulong, ulong>();

            foreach (var maskInstruction in maskInstructions)
            {
                foreach (var mem in maskInstruction.Mems)
                {
                    if(partTwo)
                    {
                        var getMems = GetPossibleMems(mem.Item1, maskInstruction.Mask);
                        foreach(var mem2 in getMems)
                        {
                            if(memory.ContainsKey(mem2))
                                memory[mem2] = mem.Item2;
                            else
                                memory.Add(mem2, mem.Item2);
                        }
                    }
                    else
                    {
                        var value = ApplyMask(mem.Item2, maskInstruction.Mask);
                        if(memory.ContainsKey(mem.Item1))
                            memory[mem.Item1] = value;
                        else
                            memory.Add(mem.Item1, value);
                    }
                }
            }

            return GetSumOfMemory(memory);
        }

        private static IEnumerable<ulong> GetPossibleMems(uint number, string mask)
        {
            var bnNumber = Convert.ToString(number, 2).PadLeft(LENGTH, '0');
            
            var result = new char[LENGTH];

            //Change 0's and 1's
            for(var i = 0; i < LENGTH; i++)
            {
                if(mask[i] == 'X')   
                    result[i] = 'X';
                else if(mask[i] == '1')
                    result[i] = '1';
                else if(mask[i] == '0')
                    result[i] = bnNumber[i];
            }

            //Combinations
            return Combinations(new string(result)).Select(x => new string(x).ToDecimal());
        }

        private static IEnumerable<string> Combinations(string input)
        {
            int firstX = input.IndexOf('X');   

            if (firstX == -1)      
                return new string[] { input };

            string prefix = input.Substring(0, firstX);    
            string suffix = input.Substring(firstX + 1);   
            var recursiveCombinations = Combinations(suffix);

            return 
                from chr in new [] { '1', '0' }  
                from recSuffix in recursiveCombinations
                select prefix + chr + recSuffix;                                    
        }

        private static ulong GetSumOfMemory(Dictionary<ulong,ulong> memory)
        {
            var result = (ulong)0;

            foreach(var key in memory.Keys)
                result += memory[key];
            return result;
        }

        private static ulong ApplyMask(uint number, string mask)
        {
            var bnNumber = Convert.ToString(number, 2).PadLeft(LENGTH, '0');
            var result = new char[LENGTH];

            for(var i = 0; i < LENGTH; i++)
            {
                if(mask[i] == 'X')   
                    result[i] = bnNumber[i];
                else if(mask[i] == '1')
                    result[i] = '1';
                else if(mask[i] == '0')
                    result[i] = '0';
            }

            return new string(result).ToDecimal();
        }

        private static ulong ToDecimal(this string result)
        {
            return Convert.ToUInt64(new string(result), 2);
        }

        private static List<MaskInstructions> GetMaskInstructions(string[] lines)
        {
            var regexMem = new Regex(RegexMem);
            var regexMask = new Regex(RegexMask);

            var maskInstructions = new List<MaskInstructions>();
            MaskInstructions maskInstruction = null;

            foreach(var line in lines)
            {
                if(regexMask.IsMatch(line))
                {
                    if(maskInstruction != null) maskInstructions.Add(maskInstruction);

                    var match = regexMask.Match(line);
                    maskInstruction = new MaskInstructions
                    {
                        Mask = match.Groups[1].Value
                    };
                }
                else if(regexMem.IsMatch(line))
                {
                    var match = regexMem.Match(line);
                    maskInstruction.Mems.Add(new Tuple<uint, uint>(match.Groups[1].Value.ToUint(), match.Groups[2].Value.ToUint()));
                }
            }
            
            maskInstructions.Add(maskInstruction);

            return maskInstructions;
        }
    }

    internal class MaskInstructions
    {
        internal string Mask{get;set;}
        internal List<Tuple<uint, uint>> Mems {get;set;}

        public MaskInstructions()
        {
            Mems = new List<Tuple<uint, uint>>();
        }
    }
}