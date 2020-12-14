using System;
using System.Linq;

namespace AdventOfCode
{
    public static class SeatingSystem
    {
        public static int GetOccupiedSeatsAtTheEnd(string[] lines)
        {
            var seatingPlan = lines.ToList().Select(x => x.ToArray()).ToArray();
            var newSeatingPlan = new char[seatingPlan[0].Length][];
            
            Print(seatingPlan);
            var seatinPlansAreEqual = false;

            while(!seatinPlansAreEqual)
            {
                newSeatingPlan = ApplyRules(seatingPlan);
                Print(newSeatingPlan);
                seatinPlansAreEqual = CompareSeatingPlans(seatingPlan, newSeatingPlan);

                seatingPlan = newSeatingPlan;
            }

            return newSeatingPlan.GetOccupiedSeats();
        }

        private static void Print(char[][] foo)
        {
            for(var i = 0; i< foo.Length; i++)
            {
                for(var j = 0; j < foo[i].Length; j++)
                    Console.Write(foo[i][j]);
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------");
            // Console.Read();
        }

        private static int GetOccupiedSeats(this char[][] seats)
        {
            return seats.Select(x => x.Count(y => y == '#')).Sum();
        }

        private static bool CompareSeatingPlans(char[][] foo, char[][] bar)
        {
            for(var i = 0; i < foo.Length; i++)
                for(var j = 0; j < foo[i].Length; j++)
                    if(foo[i][j] != bar[i][j]) 
                        return false;

            return true;
        }

        private static char[][] ApplyRules(char[][] seats)
        {
            var nextSeatingPlan = new char[seats.Length][];

            for(var row = 0; row < seats.Length; row++)
            {
                nextSeatingPlan[row] = new char[seats[0].Length];

                for(var column = 0; column < seats[row].Length; column++)
                {
                    if(FirstRule(seats, row, column))
                        nextSeatingPlan[row][column] = '#';
                    else if(SecondRule(seats, row, column))
                        nextSeatingPlan[row][column] = 'L';
                    else
                        nextSeatingPlan[row][column] = seats[row][column];
                }
            }

            return nextSeatingPlan;
        }

        //If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied
        private static bool FirstRule(char[][] seats, int row, int column)
        {
            return seats[row][column] == 'L' 
            && seats.GetChar(row - 1, column - 1).IsEmpty()
            && seats.GetChar(row - 1, column).IsEmpty()
            && seats.GetChar(row - 1, column + 1).IsEmpty()
            && seats.GetChar(row, column - 1 ).IsEmpty()
            && seats.GetChar(row, column + 1 ).IsEmpty()
            && seats.GetChar(row + 1, column - 1).IsEmpty()
            && seats.GetChar(row + 1, column).IsEmpty()
            && seats.GetChar(row + 1, column + 1).IsEmpty();
        }

        private static char GetChar(this char[][] seats, int row, int column)
        {
            if(row < 0  || row >= seats.Length || column < 0 || column >= seats[0].Length)
                return '.';
            
            return seats[row][column];
        }

        private static bool IsEmpty(this char c)
        {
            return c == '.' || c == 'L';
        }

        //If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
        private static bool SecondRule(char[][] seats, int row, int column)
        {
            if(seats.GetChar(row, column) != '#') return false;

            var occupied = 0;
            for(var i = row - 1; i <= row + 1; i++)
            {
                for(var j = column - 1; j <= column + 1; j++)
                {
                    if(seats.GetChar(i, j) == '#' && !(i == row && j == column)) 
                        occupied++;
                    if(occupied == 4) 
                        return true;
                }
            }

            return false;
        }
    }
}