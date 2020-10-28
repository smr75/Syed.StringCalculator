using System;
using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Exceptions
{
    /// <summary>
    /// Exception thrown to indicate presence of invalid numbers.
    /// </summary>
    public class InvalidNumbersException : Exception
    {
        public InvalidNumbersException(string message, IEnumerable<int> invalidNumbers) : base($"{message} - {string.Join(",", invalidNumbers)}")
        {
            InvalidNumbers = invalidNumbers;
        }

        public IEnumerable<int> InvalidNumbers { get; private set; }
    }
}
