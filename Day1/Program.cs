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

            int result = CalculateTheStuff(strNumber);            

            Console.WriteLine(string.Format("Result is: {0}", result.ToString()));
        }

        static int CalculateTheStuff(string strNumber)
        {
            int result = 0;
            char[] digits = strNumber.ToCharArray();
            int length = digits.Length;

            for(int i = 0; i < length - 1; i++)
            {       
                if(digits[i] == digits[i+1])
                {
                    result += (int)Char.GetNumericValue(digits[i]);
                }
            }

            if(digits[length - 1] == digits[0])
            {
                result += (int)Char.GetNumericValue(digits[0]);
            }

            return result;
        }
    }
    
}
