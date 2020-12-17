using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class RainRisk
    {
        private const string RegexInstruction = @"^(\w)([0-9]+)$";

        
        public static int GetPositionOfBoat(string[] lines, int START_DIRECTION)
        {
            var direction = START_DIRECTION;
            var regex = new Regex(RegexInstruction);
            var position = new Coordinate(0, 0);

            foreach (var line in lines)
            {
                var instruction = GetInstruction(line, regex);

                switch (instruction.InstructionType)
                {
                    case 'N':
                        position.Y += instruction.Value;
                        break;
                    case 'S':
                        position.Y -= instruction.Value;
                        break;
                    case 'E':
                        position.X += instruction.Value;
                        break;
                    case 'W':
                        position.X -= instruction.Value;
                        break;
                    case 'L':
                        direction = (direction - instruction.Value + 360) % 360;
                        break;
                    case 'R':
                        direction = (direction + instruction.Value) % 360;
                        break;
                    case 'F':
                        position = GetForward(position, instruction, direction);
                        break;
                }

                Console.WriteLine($"Instruction: {line}. Current position: [{position.X},{position.Y}]");
            }

            return GetManhattanDistance(position);
        }

        public static int GetPositionOfBoat_WithVector(string[] lines)
        {
            var regex = new Regex(RegexInstruction);
            var boatPosition = new Coordinate(0,0);
            var wayPointVector = new Coordinate(10,1);

            foreach (var line in lines)
            {
                var instruction = GetInstruction(line, regex);

                switch (instruction.InstructionType)
                {
                    case 'N':
                        wayPointVector.Y += instruction.Value;
                        break;
                    case 'S':
                        wayPointVector.Y -= instruction.Value;
                        break;
                    case 'E':
                        wayPointVector.X += instruction.Value;
                        break;
                    case 'W':
                        wayPointVector.X -= instruction.Value;
                        break;
                    case 'L':
                        wayPointVector = wayPointVector.MoveDirection(360 - instruction.Value);
                        break;
                    case 'R':
                        wayPointVector = wayPointVector.MoveDirection(instruction.Value);
                        break;
                    case 'F':
                        boatPosition = GetForward(boatPosition, instruction, wayPointVector);
                        break;
                }
            }
            
            return GetManhattanDistance(boatPosition);
        }

        private static Coordinate MoveDirection(this Coordinate direction, int value)
        {
            value = value % 360;

            if(value == 0)
                return direction;
            if(value == 90)
                return new Coordinate(direction.Y, -direction.X);
            if(value == 180)
                return new Coordinate(-direction.X, -direction.Y);
            if(value == 270)
                return new Coordinate(-direction.Y, direction.X);
            else
                throw new Exception($"Instruction value {value} is not valid");
        }

        private static int GetManhattanDistance(Coordinate position)
        {
            return Math.Abs(position.X) + Math.Abs(position.Y);
        }

        private static Coordinate GetForward(Coordinate position, Instruction instruction, int direction)
        {
            if(direction == 0 || direction == 180)
                position.Y += direction == 0 ? instruction.Value : (-1)*instruction.Value;
            else if(direction == 90 ||direction == 270)
                position.X += direction == 90 ? instruction.Value : (-1)*instruction.Value;
            else    
                throw new Exception($"Invalid direction: {direction}");
            
            return position;
        }

        private static Coordinate GetForward(Coordinate boardPosition, Instruction instruction, Coordinate wayPointVector)
        {
            return wayPointVector.MultiplyBy(instruction.Value).Sum(boardPosition);
        }

        private static Instruction GetInstruction(string line, Regex regex)
        {
            if(!regex.IsMatch(line))
                throw new Exception($"Line {line} is bad");

            var match = regex.Match(line);

            return new Instruction
            {
                InstructionType = match.Groups[1].Value[0],
                Value = match.Groups[2].Value.ToInt(),
            };
        }

        private static Coordinate MultiplyBy(this Coordinate coordinate, int multiplicator)
        {
            return new Coordinate(coordinate.X * multiplicator, coordinate.Y * multiplicator);
        }

        private static Coordinate Sum(this Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
        }
    }

    internal class Instruction
    {
        public char InstructionType { get; set; }
        public int Value { get; set; }
    }
    
    internal class Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}