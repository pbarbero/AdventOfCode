namespace Day1
{
    internal static class StringExtensions
    {
        internal static decimal ToDecimal(this string self)    
        {
            decimal value = 0;

            if(decimal.TryParse(self, out value))   
                return value;
                
            return value;
        }
    }
}