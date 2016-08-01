using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PCLAppConfig.Extensions
{
    /// <summary>
    /// Credits to the Excellent Humanizer Library
    /// https://www.nuget.org/packages/Humanizer
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// By default, pascalize converts strings to UpperCamelCase also removing underscores
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Pascalize(this string input)
        {
            return Regex.Replace(input, "(?:^|_)(.)", (MatchEvaluator)(match => match.Groups[1].Value.ToUpper()));
        }

        /// <summary>
        /// Same as Pascalize except that the first character is lower case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Camelize(this string input)
        {
            string str = input.Pascalize();
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }
    }
}
