using System;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class RainRisk
    {
        private const string RegexInstruction = @"^(\w)([0-9]+)$";
        public static int GetManhattanDistance(string[] lines, int START_DIRECTION)
        {
            var direction = START_DIRECTION;
            var regex = new Regex(RegexInstruction);
            var position = new Position(0,0);

            foreach(var line in lines)
            {
                var instruction = GetInstruction(line, regex);

                switch(instruction.InstructionType)
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

            return Math.Abs(position.X) + Math.Abs(position.Y);
        }

        private static Position GetForward(Position position, Instruction instruction, int direction)
        {
            if(direction == 0 || direction == 180)
                position.Y += direction == 0 ? instruction.Value : (-1)*instruction.Value;
            else if(direction == 90 ||direction == 270)
                position.X += direction == 90 ? instruction.Value : (-1)*instruction.Value;
            else    
                throw new Exception($"Invalid direction: {direction}");
            
            return position;
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
    }

    internal class Instruction
    {
        public char InstructionType { get; set; }
        public int Value { get; set; }
    }
    
    internal class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}