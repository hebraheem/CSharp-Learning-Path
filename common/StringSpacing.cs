using System;

namespace common
{
    public static class StringSpacing
    {
        //Insert spaces before each capital letter in a string
        public static string FormatProductname(this string source)
        {
            var result = string.Empty;
            if (!string.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if (char.IsUpper(letter))
                    {
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }

            return result.Trim();
        }
    }
}
