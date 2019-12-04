using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public static class Asleepeitor
    {
        private static Dictionary<string, Dictionary<string, int[]>> data;

        public static string GetIdGuardMostAsleep(List<string> lines)
        {
            var orderedLines = OrderLines(lines);
            data = ParseData(orderedLines);
            var maxMinutesAsleep = 0;
            var bestGuard = string.Empty;

            foreach (var guard in data.Keys)
            {
                var minutesAsleepForGuard = data[guard].Sum(x => x.Value.Sum());

                if (minutesAsleepForGuard > maxMinutesAsleep)
                {
                    maxMinutesAsleep = minutesAsleepForGuard;
                    bestGuard = guard;
                }
            }

            return bestGuard.Substring(1, bestGuard.Length - 1);
        }

        public static int GetMinuteMostAsleep(string idGuard)
        {
            var minutesForDays = data[idGuard];
            var accumulate = new int[60];

            foreach (var day in minutesForDays.Keys)
            {
                accumulate = SumTwoArrays(minutesForDays[day], accumulate);
            }

            int maxValue = accumulate.Max();

            return accumulate.ToList().IndexOf(maxValue);
        }

        public static int GetMinuteMostAsleepForGuard()
        {
            var foo = 0;
            var guardId = string.Empty;
            var result = 0;

            foreach (var guard in data.Keys)
            {
                var accumulated = new int[60];
                var daysForGuard = data[guard];

                foreach (var day in daysForGuard)
                {
                    accumulated = SumTwoArrays(accumulated, day.Value);
                }

                var max = accumulated.Max();
                if (foo < max)
                {
                    foo = max;
                    result = accumulated.ToList().IndexOf(max);
                    guardId = guard;
                }
            }

            return Convert.ToInt32(guardId.Substring(1, guardId.Length - 1)) * result;
        }

        private static int[] SumTwoArrays(int[] one, int[] two)
        {
            return one.Zip(two, (x, y) => x + y).ToArray();
        }

        private static List<Tuple<DateTime, string>> OrderLines(List<string> lines)
        {
            var tuplesLines = new List<Tuple<DateTime, string>>();

            foreach (var line in lines)
            {
                var date = Convert.ToDateTime(line.Substring(1, 16).Trim());
                var record = line.Substring(19, line.Length - 19).Trim();

                var tupleLine = new Tuple<DateTime, string>(date, record);

                tuplesLines.Add(tupleLine);
            }

            tuplesLines.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            return tuplesLines;
        }


        private static Dictionary<string, Dictionary<string, int[]>> ParseData(List<Tuple<DateTime, string>> lines)
        {
            var dictionaryByGuard = new Dictionary<string, Dictionary<string, int[]>>();

            var i = 0;
            var guardId = string.Empty;

            while (i < lines.Count)
            {
                var action = lines[i].Item2;

                if (action.StartsWith("Guard"))
                {
                    guardId = GetGuardId(action);

                    if (!dictionaryByGuard.ContainsKey(guardId))
                    { 
                        dictionaryByGuard.Add(guardId, new Dictionary<string, int[]>());
                    }
                    i = i + 1;
                }
                else
                {
                    if (dictionaryByGuard.ContainsKey(guardId))
                    {
                        var startAction = lines[i].Item1;
                        var endAction = lines[i + 1].Item1;
                        var day = startAction.ToString("ddMM");

                        if (dictionaryByGuard[guardId].ContainsKey(day))
                        {
                            var minutesByDay = dictionaryByGuard[guardId][day];
                            FillMinutesSleeping(lines[i].Item1, lines[i + 1].Item1, minutesByDay);
                            dictionaryByGuard[guardId][day] = minutesByDay;
                        }   
                        else
                        {
                            var minutesByDay = Enumerable.Repeat(0, 60).ToArray();
                            FillMinutesSleeping(lines[i].Item1, lines[i + 1].Item1, minutesByDay);
                            dictionaryByGuard[guardId].Add(day, minutesByDay);
                        }

                        i = i + 2;
                    }
                }                
            }

            return dictionaryByGuard;
        }

        private static string GetGuardId(string record)
        {
            var splited = record.Split(' ');
            return splited[1];
        }

        private static void FillMinutesSleeping(DateTime startDate, DateTime endDate, int[] minutesByDay)
        {
            for (var i = startDate.Minute; i < endDate.Minute; i++)
            {
                minutesByDay[i] = 1;//sleep
            }
        }
    }
}
