using Syed.StringCalculator.Core.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Parses the first line in a string for delimiter characters.
    /// </summary>
    public class HeaderDelimiterParser : IDelimiterParser
    {
        /// <summary>
        /// the prefix used to mnark the start of a line containing custom delimiters.
        /// </summary>
        public static readonly string PREFIX = "//";

        /// <summary>
        /// Default delimiter in the absence of custom delimiters.
        /// </summary>
        public static readonly string DEFAULT_DELIMITER = ",";

        /// <summary>
        /// Parses the input string for delimiter characters.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public List<string> Parse(string source)
        {
            if (string.IsNullOrWhiteSpace(source) || !HasHeader(source))
                return new List<string>() { DEFAULT_DELIMITER };

            var firstLine = source.Substring(0, source.IndexOf(Environment.NewLine));

            if(firstLine.Length < 3)
                throw new Exception("First line must be at least 3 characters in length");

            return firstLine.Skip(2).Select(c => c.ToString()).ToList();
        }

        /// <summary>
        /// Returns true if the input string contains a delimiter line.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool HasHeader(string source)
        {
            return !(string.IsNullOrWhiteSpace(source) || !source.StartsWith(PREFIX));
        }
    }
}
