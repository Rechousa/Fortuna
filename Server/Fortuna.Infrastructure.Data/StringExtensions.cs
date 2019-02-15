using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Fortuna.Infrastructure.Data
{
    public static class StringExtensions
    {
        public static string ToTitleSentence(this string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return $"{text.Substring(0, 1).ToUpper()}{text.Substring(1, text.Length - 1).ToLower()}.";
        }
    }
}
