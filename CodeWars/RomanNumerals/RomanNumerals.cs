using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class RomanNumerals
    {

        private static readonly IReadOnlyDictionary<int, string> Numerals =
            new SortedDictionary<int, string>
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
                { 1000, "M" },
            };
            
        private static readonly IReadOnlyDictionary<int, string> SpecialNumerals =
            new SortedDictionary<int, string>
            {
                { 4, "IV" },
                { 9, "IX" },
                { 40, "XL" },
                { 90, "XC" },
                { 400, "CD" },
                { 900, "CM" },
            };

        public static string ToRoman(in int n)
        {
            var currNumber = n;
            return Numerals
                .OrderByDescending(x => x.Key)
                .Aggregate(seed: string.Empty, (prev, acc) =>
                {
                    var (key, value) = acc;
                    if (TryToDivideBy(currNumber, key, out var times))
                    {
                        currNumber -= key * times;
                        return prev + string.Concat(Enumerable.Repeat(value, times));
                    }

                    return prev;
                });
        }

        public static int FromRoman(in string romanNumeral)
        {
            var currRomanNumeral = romanNumeral;
            var sum = 0;
            foreach (var (key, value) in SpecialNumerals)
            {
                if (romanNumeral.Contains(value))
                {
                    sum += key;
                    currRomanNumeral = currRomanNumeral.Replace(value, string.Empty);
                }
            }

            foreach (var (key, value) in Numerals.Except(SpecialNumerals))
            {
                var times = currRomanNumeral.Split(value).Length - 1;
                if (times > 0)
                {
                    sum += key * times;
                    currRomanNumeral = currRomanNumeral.Replace(value, string.Empty);
                }
            }
            return sum;
        }

        private static bool TryToDivideBy(int value, int divider, out int times)
        {
            times = value / divider;
            return times > 0;
        }
    }
}