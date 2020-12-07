using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Haversacks
    {
        private const string RegexOuterBag = @"^(.*) (bags|bag)$";
        private const string RegexInnerBag = @"^[0-9]+ (.*) (bags|bag)$";
        private const string RegexInnerBagWithNumber = @"^([0-9]+) (.*) (bags|bag)$";
        public static int GetOuterNumberBags(IEnumerable<string> lines)
        {
            var keyBag = "shiny gold";
            var containerBags = GetContainers(lines);

            return GetOuterBags(containerBags, keyBag).Count();
        }

        public static int GetInnerNumberBags(IEnumerable<string> lines)
        {
            var bags = GetBags(lines);
            var keyBag = "shiny gold";

            return GetInnerBags(bags, keyBag).Count();
        }

        private static IEnumerable<string> GetInnerBags(Dictionary<string,IEnumerable<string>> bags, string keyBag)
        {
            var innerBags = new List<string>();

            if(bags.ContainsKey(keyBag))
            {
                foreach(var innerBag in bags[keyBag])
                {
                    innerBags.Add(innerBag);
                    GetInnerBags(bags, innerBag).ToList().ForEach(x => innerBags.Add(x));
                }
            }

            return innerBags;
        }

        private static HashSet<string> GetOuterBags(Dictionary<string,HashSet<string>> bags, string keyBag)
        {
            var outerBags = new HashSet<string>();

            if(bags.ContainsKey(keyBag))
            {
                foreach(var outerBag in bags[keyBag])
                {
                    outerBags.Add(outerBag);
                    GetOuterBags(bags, outerBag).ToList().ForEach(x => outerBags.Add(x));
                }
            }

            return outerBags;
        }

        private static Dictionary<string, IEnumerable<string>> GetBags(IEnumerable<string> lines)
        {
            var bags = new Dictionary<string,IEnumerable<string>>();

            foreach(var line in lines)
            {
                var itemscontained = line.Substring(0, line.Length - 1).Split(" contain ");
                var outerBagName = GetOuterBagName(itemscontained[0].Trim());

                if(itemscontained[1] == "no other bags")
                    continue;

                var innerBags = itemscontained[1].Split(",")
                                .SelectMany(y => GetInnerBags(y.Trim()));

                bags.Add(outerBagName, innerBags);
            }

            return bags;
        }

        private static Dictionary<string,HashSet<string>> GetContainers(IEnumerable<string> lines)
        {
            var bags = new Dictionary<string,HashSet<string>>();

            foreach(var line in lines)
            {
                var itemscontained = line.Substring(0, line.Length - 1).Split(" contain ");
                var outerBagName = GetOuterBagName(itemscontained[0].Trim());

                if(itemscontained[1] == "no other bags")
                    continue;

                var innerBags = itemscontained[1].Split(",")
                                .Select(x => GetInnerBagName(x.Trim()));

                foreach(var innerBagName in innerBags)
                {
                    if(bags.ContainsKey(innerBagName))
                        bags[innerBagName].Add(outerBagName);
                    else
                        bags.Add(innerBagName, new HashSet<string>{ outerBagName });
                }
            }

            return bags;
        }

        private static string GetOuterBagName(string bagsString)
        {
            return GetName(bagsString, RegexOuterBag);
        }

        private static string GetInnerBagName(string bagsString)
        {
            return GetName(bagsString, RegexInnerBag);
        }

        private static IEnumerable<string> GetInnerBags(string bagsString)
        {
            var regex = new Regex(RegexInnerBagWithNumber);

            if (regex.IsMatch(bagsString))
            {
                var result = new List<string>();
                var nOfBags = int.Parse(regex.Match(bagsString).Groups[1].Value);

                for(var i = 0; i< nOfBags; i++)
                    result.Add(regex.Match(bagsString).Groups[2].Value);

                return result;
            }

            throw new System.Exception($"{bagsString} does not match regex");
        }

        private static string GetName(string bagsString, string regexStr)
        {
            var regex = new Regex(regexStr);

            if (regex.IsMatch(bagsString))
                return regex.Match(bagsString).Groups[1].Value;

            throw new System.Exception($"{bagsString} does not match regex");
        }
    }
}