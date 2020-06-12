using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RightslineSampleLambdaDotNet.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            var result = String.Empty;
            var newWord = true;

            foreach (char c in input)
            {
                if (newWord)
                {
                    result += Char.ToUpper(c);
                    newWord = false;
                }
                else
                {
                    result += Char.ToLower(c);
                }

                if (c == ' ')
                {
                    newWord = true;
                }
            }

            return result;
        }

        public static int GetIdFromUrl(this string url)
        {
            int pos = url.LastIndexOf("/") + 1;
            return int.Parse(url.Substring(pos, url.Length - pos));
        }
    }
}
