using System;

namespace Day5
{
    internal abstract class Instruction
    {
        protected int[] Steps;
        protected int Pointer;        

        protected int Value0
        {
            get 
            { 
                return GetValue(Param0 == 0, 1);
            }
        }

        protected int Value1
        {
            get { return  GetValue(Param1 == 0, 2); }
        }

        protected int Param0
        {
            get { return (InstructionId / 100) % 10;}
        }

        protected int Param1
        {
            get { return InstructionId / 1000;}
        }

        private int InstructionId 
        {
            get
            {
                return Steps[Pointer];
            }
        }

        protected Instruction(int[] steps, int pointer)
        {
            Steps = steps;
            Pointer = pointer;
        }

        internal abstract void Execute();

        internal abstract int GetStepNextInstruction();

        private int GetValue(bool fromAddress, int position)
        {
            return fromAddress ? Steps[Steps[Pointer + position]] : Steps[Pointer+position];
        }
    }

    internal class Sum : Instruction
    {
        internal Sum(int[] steps, int pointer) : base(steps, pointer)
        {
            
        }

        internal override void Execute()
        {
            Steps[Steps[Pointer + 3]] = Value0 + Value1;
        }

        internal override int GetStepNextInstruction()
        {
            return Pointer + 4;
        }
    }

    internal class Multiply : Instruction
    {
        internal Multiply(int[] steps, int pointer) : base(steps, pointer)
        {
            
        }

        internal override void Execute()
        {
             Steps[Steps[Pointer + 3]] =  Value0 * Value1;
        }

        internal override int GetStepNextInstruction()
        {
            return Pointer + 4;
        }
    }

    internal class Input : Instruction
    {
        internal Input(int[] steps, int pointer) : base(steps, pointer)
        {
            
        }

        internal override void Execute()
        {
            Console.WriteLine("Give me the system ID");
            // Steps[Steps[Pointer+1]] = (int)Console.Read();
            Steps[Steps[Pointer+1]] = 5;
        }

        internal override int GetStepNextInstruction()
        {
            return Pointer + 2;
        }
    }

    internal class Output : Instruction
    {
        internal Output(int[] steps, int pointer) : base(steps, pointer)
        {
            
        }
        
        internal override void Execute()
        {
            Console.WriteLine(Value0);
        }

        internal override int GetStepNextInstruction()
        {
            return Pointer + 2;
        }
    }

    internal class Break: Instruction
    {
        internal Break(int[] steps, int pointer) : base(steps, pointer)
        {
            
        }

        internal override void Execute()
        {
        }

        internal override int GetStepNextInstruction()
        {
            return -1;
        }
    }

    internal abstract class Jump: Instruction
    {
        protected bool JumpCondition;

        internal Jump(int[] steps, int pointer): base(steps, pointer)
        {
            
        }

        internal override void Execute()
        {
        }

        internal override int GetStepNextInstruction()
        {
            return JumpCondition ? Steps[Param1] : Pointer + 2;
        }
    }

    internal class JumpTrue: Jump
    {
        internal JumpTrue(int[] steps, int pointer): base(steps, pointer)
        {
            base.JumpCondition = Param0 != 0;
        }
    }

    internal class JumpFalse : Jump
    {
        internal JumpFalse(int[] steps, int pointer): base(steps, pointer)
        {
            base.JumpCondition = Param0 == 0;
        }
    }

    internal abstract class Comparison : Instruction
    {
        protected bool ComparisonCondition;
        
        internal Comparison(int[] steps, int pointer): base(steps, pointer)
        {

        }

        internal override void Execute()
        {
            Steps[Steps[Pointer + 3]] = 1;
        }

        internal override int GetStepNextInstruction()
        {
            return Pointer + 4;
        }
    }

    internal class LessComparison : Comparison
    {
        internal LessComparison(int[] steps, int pointer): base(steps, pointer)
        {
            base.ComparisonCondition = Param0 < Param1;
        }
    }

    internal class EqualsComparison: Comparison
    {
        internal EqualsComparison(int[] steps, int pointer): base(steps, pointer)
        {
            base.ComparisonCondition = Param0 == Param1;
        }
    }
}