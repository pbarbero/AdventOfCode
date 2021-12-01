using System;
using System.Linq;

namespace AdventOfCode
{
    public static class ShuttleSearch
    {
        public static int GetMultipliedWaitingTimeById(string[] lines)
        {
            var timestamp = lines[0].ToInt();
            var busesIds = lines[1].Split(",").ToList().Where(x => x != "x").ToArray().ToInt();

            var waitingTime = 0;
            var busId = 0;

            while(busId == 0)
            {
                waitingTime++;
                busId = busesIds.FirstOrDefault(b => (timestamp + waitingTime) % b == 0);

                Console.WriteLine($"Time {timestamp + waitingTime}");
            }

            return busId * waitingTime;
        }
    }
}