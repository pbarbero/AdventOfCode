namespace Day8
{
    internal static class StringExtensions
    {
        internal static int ToInt(this string self)    
        {
            int value = 0;

            if(int.TryParse(self, out value))   
                return value;
                
            return value;
        }
    }
}