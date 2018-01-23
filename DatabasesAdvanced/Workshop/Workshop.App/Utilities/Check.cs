using System;

namespace Workshop.App.Utilities
{
    public static class Check
    {
        public static void CheckLength(int expectedLength, string[] array)
        {
            if(expectedLength != array.Length)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount)
            }
        }
    }
}
