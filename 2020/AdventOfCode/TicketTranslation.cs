using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class TicketTranslation
    {
        private const string RegexRule = @"^([a-z ]*): (\d+)-(\d+) or (\d+)-(\d+)$";

        public static int GetScanningErrorRate(string[] lines)
        {
            var rules = GetRules(lines);
            var nearbyTickets = GetNearbyTickets(lines);

            var sum = 0;
            foreach (var nearbyTicket in nearbyTickets)
                sum += nearbyTicket.Where(x => !x.SatisfySomeRule(rules)).Sum();

            return sum;
        }

        public static long GetMultiplied6Values(string[] lines)
        {
            var myTicket = GetMyTicket(lines);
            var orderedRules = GetFieldPositions(lines);
            
            var departurePositions = orderedRules.Where(x => x.Field.StartsWith("departure")).SelectMany(x => x.PossiblePositions);

            if(departurePositions.Count() != 6) throw new Exception("La cagaste Pili");

            var result = (long)1;
            foreach (var position in departurePositions)
                result = result * myTicket[position];

            return result;
        }

        public static List<Rule> GetFieldPositions(string[] lines)
        {
            var rules = GetRules(lines);
            var nearbyTickets = GetNearbyTickets(lines);
            var validTickets = nearbyTickets.Where(x => x.AllSatisfySomeRule(rules)).ToList();

            foreach (var rule in rules)
            {
                for (var position = 0; position < rules.Count(); position++)
                    if (!rule.IsRuleInPosition(position, validTickets))
                        rule.PossiblePositions.Remove(position);
            }

            var orderedRules = ExcludePositionsBetweenRules(rules);
            orderedRules.ForEach(x => Console.WriteLine($"Rule '{x.Field}', has position {string.Join(",", x.PossiblePositions)}'"));

            return orderedRules;
        }

        private static List<Rule> ExcludePositionsBetweenRules(IEnumerable<Rule> rules)
        {
            var orderedRules = rules.OrderBy(x => x.PossiblePositions.Count()).ToList();

            for (var i = 0; i < orderedRules.Count(); i++)
            {
                var rule = orderedRules[i];

                if (rule.PossiblePositions.Count() == 1)
                {
                    var positionToRemove = rule.PossiblePositions[0];

                    foreach (var otherRule in orderedRules)
                        if (otherRule.PossiblePositions.Contains(positionToRemove) && otherRule.Field != rule.Field)
                            otherRule.PossiblePositions.Remove(positionToRemove);
                }
                else
                    throw new Exception($"Rule {rule.Field} is cursed");
            }
            
            if (orderedRules.Any(x => x.PossiblePositions.Count() > 1)) throw new Exception("La cagaste Pili");

            return orderedRules;
        }
        private static bool IsRuleInPosition(this Rule rule, int position, List<List<int>> validTickets)
        {
            return validTickets.All(t => t[position].SatisfyRule(rule));
        }

        private static bool SatisfySomeRule(this int number, IEnumerable<Rule> rules)
        {
            return rules.Any(rule => number.SatisfyRule(rule));
        }

        private static bool SatisfyRule(this int number, Rule rule)
        {
            return (rule.Range1 <= number && number <= rule.Range2) || (rule.Range3 <= number && number <= rule.Range4);
        }

        private static bool AllSatisfySomeRule(this List<int> numbers, IEnumerable<Rule> rules)
        {
            return numbers.All(n => n.SatisfySomeRule(rules));
        }

        private static List<List<int>> GetNearbyTickets(string[] lines)
        {
            var indexOfNearbyStarts = Array.IndexOf(lines, lines.First(x => x.StartsWith("nearby tickets:")));
            var nearbyTickets = new List<List<int>>();

            for(var i = indexOfNearbyStarts + 1; i < lines.Length; i++)
                nearbyTickets.Add(lines[i].Split(",").ToInt().ToList());

            return nearbyTickets;
        }

        private static List<int> GetMyTicket(string[] lines)
        {
            var indexOfYourTicket = Array.IndexOf(lines, lines.First(x => x.StartsWith("your ticket:")));

            return lines[indexOfYourTicket+1].Split(",").ToInt().ToList();
        }


        private static IEnumerable<Rule> GetRules(string[] lines)
        {
            var regex = new Regex(RegexRule);

            var rules = new List<Rule>();
            var length = lines.Where(x => regex.IsMatch(x)).Count();

            foreach(var line in lines)
            {
                if(regex.IsMatch(line))
                {
                    var match = regex.Match(line);

                    rules.Add(new Rule(length)
                    {
                        Field = match.Groups[1].Value,
                        Range1 = match.Groups[2].Value.ToInt(),
                        Range2 = match.Groups[3].Value.ToInt(),
                        Range3 = match.Groups[4].Value.ToInt(),
                        Range4 = match.Groups[5].Value.ToInt(),
                    });
                }                
                else 
                    break;
            }

            return rules;
        }
    }

    public class Rule
    {
        public Rule(int lengthPositions)
        {
            PossiblePositions = new List<int>();

            for(var i = 0; i < lengthPositions; i++)
                PossiblePositions.Add(i);
        }

        public string Field { get; set; }
        
        public int Range1 {get;set;}
        public int Range2 {get;set;}
        public int Range3 {get;set;}
        public int Range4 {get;set;}

        public List<int> PossiblePositions { get; set;}
    }
}