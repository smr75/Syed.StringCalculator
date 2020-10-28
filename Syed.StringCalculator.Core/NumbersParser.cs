using Syed.StringCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Extracts numbers from the input string based on the supplied set of delimiters.
    /// </summary>
    public class NumbersParser : INumbersParser
    {
        public IEnumerable<int> Parse(string numbers, IEnumerable<string> delimiters)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return new List<int>();

            var numbersOnly =  numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            return numbersOnly.Select(n => int.Parse(n));
        }
    }
}
