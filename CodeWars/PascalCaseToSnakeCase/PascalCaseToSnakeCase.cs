using System.Text.RegularExpressions;

namespace CodeWars
{
    public class PascalCaseToSnakeCase
    {
        private const string RegexPattern = "([a-z0-9])([A-Z])";
        private const string Replacement = "$1_$2";

        public static string ToUnderscore(int str)
        {
            return str.ToString();
        }

        public static string ToUnderscore(string str)
        {
            return Regex.Replace(str, RegexPattern, Replacement).ToLowerInvariant();
        }
    }
}