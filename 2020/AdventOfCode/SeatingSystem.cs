using System;
using System.Linq;

namespace AdventOfCode
{
    public static class SeatingSystem
    {
        public static int GetOccupiedSeatsAtTheEnd(string[] lines, bool partTwo)
        {
            var seatingPlan = lines.ToList().Select(x => x.ToArray()).ToArray();
            var newSeatingPlan = new char[seatingPlan[0].Length][];
            
            // Print(seatingPlan);
            var seatinPlansAreEqual = false;

            while(!seatinPlansAreEqual)
            {
                newSeatingPlan = seatingPlan.GetNextIteration(partTwo);
                // Print(newSeatingPlan);
                seatinPlansAreEqual = CompareSeatingPlans(seatingPlan, newSeatingPlan);

                seatingPlan = newSeatingPlan;
            }

            return newSeatingPlan.Select(x => x.Count(y => y == '#')).Sum();
        }

        private static void Print(char[][] foo)
        {
            for(var i = 0; i< foo.Length; i++)
            {
                for(var j = 0; j < foo[i].Length; j++)
                    Console.Write(foo[i][j]);
                Console.WriteLine();
            }
        }

        private static bool CompareSeatingPlans(char[][] foo, char[][] bar)
        {
            for(var i = 0; i < foo.Length; i++)
                for(var j = 0; j < foo[i].Length; j++)
                    if(foo[i][j] != bar[i][j]) return false;

            return true;
        }

        private static char[][] GetNextIteration(this char[][] seats, bool partTwo)
        {
            var FUCKING_CONSTANT = partTwo ? 5 : 4;
            var nextSeatingPlan = new char[seats.Length][];

            for(var row = 0; row < seats.Length; row++)
            {
                nextSeatingPlan[row] = new char[seats[row].Length];

                for(var column = 0; column < seats[row].Length; column++)
                {
                    var currentChar = seats.GetChar(row, column);
                    int occupiedSeats;
                    if(partTwo)
                        occupiedSeats = seats.GetOccupiedSeatsAroundPlus(row, column);
                    else
                        occupiedSeats = seats.GetOccupiedSeatsAround(row, column);

                    //If a seat is empty (L) and there are no occupied seats adjacent to it, the seat becomes occupied
                    if(occupiedSeats == 0 && currentChar == 'L')
                        nextSeatingPlan[row][column] = '#';
                    else if(occupiedSeats >= FUCKING_CONSTANT && currentChar == '#')  //If a seat is occupied (#) and four or more seats adjacent to it are also occupied, the seat becomes empty.
                        nextSeatingPlan[row][column] = 'L';
                    else
                        nextSeatingPlan[row][column] = seats[row][column];
                }
            }

            return nextSeatingPlan;
        }

        private static int GetOccupiedSeatsAround(this char[][] seats, int row, int column)
        {
            var occupied = 0;
            for(var i = row - 1; i <= row + 1; i++)
            {
                for(var j = column - 1; j <= column + 1; j++)
                    if(seats.GetChar(i, j) == '#' && !(i == row && j == column)) occupied++;
            }

            return occupied;
        }

        private static int GetOccupiedSeatsAroundPlus(this char[][] seats, int row, int column)
        {
            var occupied = 0;

            if(GetTopRight(seats, row, column)) occupied++;
            if(GetTopLeft(seats, row, column)) occupied++;
            if(GetDownLeft(seats, row, column)) occupied++;
            if(GetDownRight(seats, row, column)) occupied++;

            if(GetTop(seats, row, column)) occupied++;
            if(GetRight(seats, row, column)) occupied++;
            if(GetLeft(seats, row, column)) occupied++;
            if(GetDown(seats, row, column)) occupied++;

            return occupied;
        }

        private static bool GetTop(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= row)
            {
                if (seats.GetChar(row - n, column) == '#') return true;
                if (seats.GetChar(row - n, column) == 'L') return false;
                n++;
            }

            return false;
        }
        private static bool GetDown(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= seats.Length - row)
            {
                if (seats.GetChar(row + n, column) == '#') return true;
                if (seats.GetChar(row + n, column) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetRight(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= seats[row].Length - column)
            {
                if (seats.GetChar(row, column + n) == '#') return true;
                if (seats.GetChar(row, column + n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetLeft(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= column)
            {
                if (seats.GetChar(row, column - n) == '#') return true;
                if (seats.GetChar(row, column - n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetTopRight(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= Math.Min(row, seats[row].Length - column))
            {
                if (seats.GetChar(row - n, column + n) == '#') return true;
                if (seats.GetChar(row - n, column + n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetDownLeft(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= Math.Min(seats.Length - row , column ))
            {
                if (seats.GetChar(row + n, column - n) == '#') return true;
                if (seats.GetChar(row + n, column - n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetDownRight(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= Math.Min(seats.Length - row, seats[row].Length - column ))
            {
                if (seats.GetChar(row + n, column + n) == '#') return true;
                if (seats.GetChar(row + n, column + n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static bool GetTopLeft(char[][] seats, int row, int column)
        {
            var n = 1;
            while (n <= Math.Min(row ,column ))
            {
                if (seats.GetChar(row - n, column - n) == '#') return true;
                if (seats.GetChar(row - n, column - n) == 'L') return false;
                n++;
            }

            return false;
        }

        private static char GetChar(this char[][] seats, int row, int column)
        {
            if(row < 0  || row >= seats.Length || column < 0 || column >= seats[row].Length)
                return '.';
            
            return seats[row][column];
        }
    }
}