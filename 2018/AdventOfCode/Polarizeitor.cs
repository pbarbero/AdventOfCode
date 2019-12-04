using System.Linq;

namespace AdventOfCode
{
    public static class Polarizeitor
    {
        public static int Scan(string polymer)
        {
            var continueProcess = true;

            while (continueProcess)
            {
                var indexToRemove = React(polymer);
                continueProcess = indexToRemove != -1;

                if (continueProcess)
                {
                    polymer = polymer.Remove(indexToRemove, 2);
                }

            }

            return polymer.Length;
        }

        public static int BestScan(string polymer)
        {
            var distinctLetters = polymer.ToLower().ToList().Distinct();   
            var minimum = polymer.Length;

            foreach(var letter in distinctLetters)
            {
                var polymerWithoutLetter = RemoveLetter(polymer, letter);
                var length = Scan(polymerWithoutLetter);

                if(minimum > length)
                {
                    minimum = length;
                }
            }

            return minimum;
        }

        public static bool Polarize(char unit0, char unit1)
        {
            return unit0.ToString().ToUpper() == unit1.ToString().ToUpper()
            && ( (char.IsLower(unit0) && char.IsUpper(unit1) )
              || (char.IsLower(unit1) && char.IsUpper(unit0)));
        }

        public static string RemoveLetter(string polymer, char letter)
        {
            var upperLetter = char.ToUpper(letter);
            var lowerLetter = char.ToLower(letter);
            
            return new string(polymer.Where(c => c != upperLetter && c != lowerLetter).ToArray());
        }

        private static int React(string polymer)
        {
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                var toBePolarized = Polarize(polymer[i], polymer[i + 1]);

                if (toBePolarized)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
