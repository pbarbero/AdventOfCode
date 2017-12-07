using System;
using System.Threading;
using System.Collections.Generic;

namespace tennis
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get names
            Console.Write("Gimme the number: ");
            string strNumber = Console.ReadLine();

            decimal result = ManhattanDistance(strNumber);
            Console.Write(string.Format("Result: {0}", result.ToString()));
        }

        static decimal ManhattanDistance(string strNumber)
        {
            decimal number = Decimal.Parse(strNumber);

            if(number == 1)
            {
                return 0;
            }

            decimal result = 0;

            //One distance
            decimal begin = 2; 
            decimal end = 0;
            for(int i = 3; i < number*2; i = i + 2)
            {
                result++;
                end = (decimal)Math.Pow(i, 2);
                if(begin <= number && number <= end)
                {
                    break;
                }
                else
                {
                    begin = end + 1;
                }
            }

            //Second distance
            int step = Decimal.ToInt32((end - begin) / 4);             

            for(int i = 0; i < 4; i++)
            {
                end = begin + step;
                if(begin <= number && number <= end)
                {
                    int middle = (int)Math.Floor((begin + end) / 2);
                    result += Math.Abs(number - middle);
                    break;
                }
                else
                {
                    begin = end + 1;
                }
            }


            return result;
        }

        
    }
    
}
