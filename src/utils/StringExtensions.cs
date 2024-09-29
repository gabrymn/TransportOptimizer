using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportOptimizer.src.utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether the specified string can be parsed as an integer.
        /// </summary>
        /// <param name="str">The string to check.</param>
        /// <returns>True if the string can be parsed as an integer; otherwise, false.</returns>
        public static bool IsInteger(this string str) 
        {
            return int.TryParse(str, out _);
        }

        /// <summary>
        /// Checks if the specified string, when parsed as an integer, is less than 1.
        /// </summary>
        /// <param name="str">The string to evaluate.</param>
        /// <returns>True if the integer value is less than 1; otherwise, false.</returns>
        public static bool LessThan1(this string str)
        {
            if (int.TryParse(str, out _))
            {
                int value = int.Parse(str);
                return value < 1;
            }
            return false;
        }

        /// <summary>
        /// Extracts all numeric characters from the specified string and returns them as a concatenated string.
        /// Leading zeros are ignored.
        /// </summary>
        /// <param name="str">The string from which to extract digits.</param>
        /// <returns>A string containing all numeric characters found in the original string.</returns>
        public static string ExtractDigits(this string str)
        {
            string s = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 && str[0] == '0')
                    continue;

                if (str[i].ToString().IsInteger())
                    s += str[i].ToString();
            }

            return s;
        }

        /// <summary>
        ///  Equals Ignore Case
        /// </summary>
        public static bool EqualsICase(this string str, string arg)
        {
            if (arg == null)
                return false;

            bool equals = string.Equals(str, arg, StringComparison.OrdinalIgnoreCase);
            return equals;
        }
    }
}
