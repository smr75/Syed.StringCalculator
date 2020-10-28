using Syed.StringCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Returns all lines fom the input string containing delimited numbers. If the input string contains a header line containing custom delimiters, this line is not returned.
    /// </summary>
    public class NumberLinesParser : INumberLinesParser
    {
        private readonly IDelimiterParser _delimiterParser;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delimiterParser"></param>
        public NumberLinesParser(IDelimiterParser delimiterParser)
        {
            if (delimiterParser == null)
                throw new ArgumentNullException(nameof(delimiterParser));

            _delimiterParser = delimiterParser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<string> GetLines(string source)
        {
            var lines = source.Split(Environment.NewLine);

            if (_delimiterParser.HasHeader(source))
                return lines.Skip(1);

            return lines;
        }
    }
}
