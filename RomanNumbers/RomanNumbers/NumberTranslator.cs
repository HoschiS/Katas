using System;
using System.Collections.Generic;

namespace RomanNumbers
{
    public class NumberTranslator
    {
        private static readonly Dictionary<int, string> ValueStrings;

        static NumberTranslator()
        {
            ValueStrings = new Dictionary<int, string>
                               {
                                   {1000, "M"},
                                   {900, "CM"},
                                   {500, "D"},
                                   {400, "CD"},
                                   {100, "C"},
                                   {90, "XC"},
                                   {50, "L"},
                                   {40, "XL"},
                                   {10, "X"},
                                   {9, "IX"},
                                   {5, "V"},
                                   {4, "IV"},
                                   {1, "I"}
                               };
        }

        public static string FromArabic(string query)
        {
            var result = "";
            if (string.IsNullOrEmpty(query))
                return result;
            int number;
            if (!Int32.TryParse(query, out number))
                throw new ArgumentException("Query '" + query + "' could not be translated");
            if (number <= 0)
                throw new ArgumentOutOfRangeException("query", "Only positive numbers greater zero can be translated : '" + query + "'");
            var workNumber = number;
            while (workNumber > 0)
            {
                foreach (var pair in ValueStrings)
                {
                    if (workNumber >= pair.Key)
                    {
                        result = result + pair.Value;
                        workNumber -= pair.Key;
                        break;
                    }
                }
            }
            return result;
        }

        public static int FromRoman(string query)
        {
            string workingString = query;
            int result = 0;
            while (!string.IsNullOrEmpty(workingString))
            {
                bool found = false;
                foreach (var pair in ValueStrings)
                {
                    if (workingString.StartsWith(pair.Value))
                    {
                        workingString = workingString.Substring(pair.Value.Length);
                        result += pair.Key;
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new ArgumentOutOfRangeException("The query '" + query + "' contains invalid letters.");
                }
            }
            return result;
        }
    }
}
