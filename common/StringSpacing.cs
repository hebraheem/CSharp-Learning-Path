using System;

namespace common
{
    public static class StringSpacing
    {
        public static string FormatProductname(string source)
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
