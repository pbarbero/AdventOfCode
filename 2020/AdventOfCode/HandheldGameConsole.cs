using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class HandheldGameConsole
    {
        public static int GetFixedAccumulatorValue(string[] game)
        {
            var modifiedGames = GetModifiedGames(game);

            foreach(var modifiedGame in modifiedGames)
            {
                var result = GetAccumulatorValue(modifiedGame);
                if(result.Item1) return result.Item2;
            }

            throw new Exception($"Good game not found");
        }

        public static Tuple<bool,int> GetAccumulatorValue(string[] lines)
        {
            var allAlreadyAccesedIndexes = new HashSet<int>();
            var acc = 0;
            var i = 0;

            while(i < lines.Count())
            {
                if(allAlreadyAccesedIndexes.Contains(i))
                    return new Tuple<bool, int>(false, acc);
                else 
                    allAlreadyAccesedIndexes.Add(i);

                var splitted = lines[i].Split(" ");

                if(splitted.Length != 2) throw new System.Exception($"Bad line {lines[i]}");

                var operation = splitted[0];
                var argument = int.Parse(splitted[1]);
                
                if(operation == "nop")
                    i++;
                else if(operation == "acc") 
                {
                    acc = acc + argument;
                    i++;
                }
                else if(operation == "jmp")
                    i = i + argument;
            }

            return new Tuple<bool, int>(true, acc);
        }

        private static IEnumerable<string[]> GetModifiedGames(string[] game)
        {
            var modifiedGames = new List<string[]>();
            var indexesWhereJmpOrNop = GetIndexWhereJumpOrNop(game);

            foreach(var index in indexesWhereJmpOrNop)
            {
                var modifiedGame = (string[])game.Clone();
                modifiedGame[index] = game[index].ChangeInstruction(); 

                modifiedGames.Add(modifiedGame);
            }

            return modifiedGames;
        }

        private static IEnumerable<int> GetIndexWhereJumpOrNop(string[] game)
        {
            var indexes = new List<int>();

            for(var i = 0; i< game.Count(); i++)
                if(game[i].IsJmpOrNop()) indexes.Add(i);

            return indexes;
        }

        private static bool IsJmpOrNop(this string self)
        {
            var splitted = self.Split(" ");
            return splitted[0] == "nop" || splitted[0] == "jmp";
        }

        private static string ChangeInstruction(this string self)
        {
            var splitted = self.Split(" ");
            var operation = splitted[0];
            var argument = splitted[1];

            if(operation == "jmp")
                return $"nop {argument}";
            else if(operation == "nop")
                return $"jmp {argument}";
            
            throw new System.Exception($"Cannot change instruction in {self}");
        }
    }
}