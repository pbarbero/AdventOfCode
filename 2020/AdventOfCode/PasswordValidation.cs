using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class PasswordValidation
    {
        public static decimal GetValidPasswords(IEnumerable<string> lines)
        {
            var nValidPasswords = 0;

            foreach(var line in lines)
            {
                var passwordCondition = GetPasswordCondition(line);
                // if (SatisfiesOcurrenceCondition(passwordCondition)) nValidPasswords++;
                if (SatisfiesPositionCondition(passwordCondition)) nValidPasswords++;
            }

            return nValidPasswords;
        }

        private static bool SatisfiesOcurrenceCondition(PasswordCondition passwordCondition)
        {
            var ocurrences = passwordCondition.password.Count(x => x == passwordCondition.letter);
            return passwordCondition.minCondition <= ocurrences && ocurrences <= passwordCondition.maxCondition;
        }

        private static bool SatisfiesPositionCondition(PasswordCondition passwordCondition)
        {
            return (passwordCondition.GetCharMinPosition() == passwordCondition.letter
            || passwordCondition.GetCharMaxPosition() == passwordCondition.letter)
            && !(passwordCondition.GetCharMinPosition() == passwordCondition.letter
            && passwordCondition.GetCharMaxPosition() == passwordCondition.letter);
        }

        private static char GetChar(string password, int position)
        {
            position++;
            if(position < 0 || position > password.Length -1)
                throw new System.ArgumentOutOfRangeException();   
            
            return password[position];
        }

        private static PasswordCondition GetPasswordCondition(string line)
        {
            var splittedLine = line.Split(" ");

            if (splittedLine.Length < 3) throw new System.Exception($"Condition '{line}' is not valid");

            var minMaxCondition = splittedLine[0];
            var letterCondition = splittedLine[1];
            var splittedMinMaxCondition = minMaxCondition.Split("-");

            if (splittedMinMaxCondition.Length < 2) throw new System.Exception($"Condition '{line}' is not valid");

            return new PasswordCondition
            {
                minCondition = int.Parse(splittedMinMaxCondition[0]),
                maxCondition = int.Parse(splittedMinMaxCondition[1]),
                letter = letterCondition[0],
                password = splittedLine[2]
            };
        }
    }

    class PasswordCondition
    {
        internal int minCondition {get;set;}
        internal int maxCondition{get;set;}
        internal char letter{get;set;}
        internal string password{get;set;}

        internal char GetCharMinPosition()
        {
            var position = minCondition - 1;
            if(position < 0 || position >= password.Length)
                throw new System.ArgumentOutOfRangeException();   
            
            return password[position];
        }

        internal char GetCharMaxPosition()
        {
            var position = maxCondition - 1;
            if(position < 0 || position >= password.Length)
                throw new System.ArgumentOutOfRangeException();   
            
            return password[position];
        }
    }
}