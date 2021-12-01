using System;

namespace Day5
{
    internal static class InstructionFactory
    {
        internal static Instruction Create(int i, int[] steps)
        {
            var instruction = steps[i] % 100;
            
            switch(instruction)
            {
                case 1:
                    return new Sum(steps, i);
                case 2:
                    return new Multiply(steps, i);
                case 3:
                    return new Input(steps, i);
                case 4:
                    return new Output(steps, i);
                case 5:
                    return new JumpTrue(steps, i);
                case 6:
                    return new JumpFalse(steps, i);
                case 7:
                    return new LessComparison(steps, i);
                case 8:
                    return new EqualsComparison(steps, i);
                case 99:
                    return new Break(steps, i);
                default:
                    throw new Exception($"Instruction {instruction} is not OK");
            }
        }
    }
}