using Syed.StringCalculator.Core.Exceptions;
using Syed.StringCalculator.Core.Interfaces;
using System;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Simple string calculator that takes one or more lines of delimited numbers and returns the sum.
    /// </summary>
    public class BasicStringCalculator : IStringCalculator
    {
        private readonly IDelimiterParser _delimiterParser;
        private readonly INumberLinesParser _numberLinesParser;
        private readonly INumbersParser _numbersParser;
        private readonly INumberFilter _numberFilter;
        private readonly INumberDetector _numberDetector;
        private readonly INumberAdder _numberAdder;

        /// <summary>
        /// In the absence of an IoC container, use the default constructor to built a default implementation of the StringCalculator.
        /// This should be removed once an IoC is in place.
        /// </summary>
        public BasicStringCalculator() 
            : this(
                  new HeaderDelimiterParser(), 
                  new NumberLinesParser(new HeaderDelimiterParser()), 
                  new NumbersParser(), 
                  new LargerThanFilter(1000), 
                  new NegativeNumberDetector(), 
                  new NumberAdder())
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="delimiterParser">An object to parse delimiters.</param>
        /// <param name="numberLinesParser">An object to parse lines of delimited numbers</param>
        /// <param name="numbersParser">An object to parse numbers from a line</param>
        /// <param name="numberFilter">An object used to filter out unwanted numbers</param>
        /// <param name="numberDetector">An object used to detect invalid numbers</param>
        /// <param name="numberAdder">An object used to sum a list of numbers</param>
        public BasicStringCalculator(IDelimiterParser delimiterParser, INumberLinesParser numberLinesParser, INumbersParser numbersParser, INumberFilter numberFilter, INumberDetector numberDetector, INumberAdder numberAdder)
        {
            if (delimiterParser == null)
                throw new ArgumentNullException(nameof(delimiterParser));

            if(numberLinesParser == null)
                throw new ArgumentNullException(nameof(numberLinesParser));

            if (numbersParser == null)
                throw new ArgumentNullException(nameof(numbersParser));

            if (numberFilter == null)
                throw new ArgumentNullException(nameof(numberFilter));

            if (numberDetector == null)
                throw new ArgumentNullException(nameof(numberDetector));

            if (numberAdder == null)
                throw new ArgumentNullException(nameof(numberAdder));

            _delimiterParser = delimiterParser;
            _numberLinesParser = numberLinesParser;
            _numbersParser = numbersParser;
            _numberFilter = numberFilter;
            _numberDetector = numberDetector;
            _numberAdder = numberAdder;
        }

        /// <summary>
        /// Returns the sum of a set of delimited numbers.
        /// </summary>
        /// <param name="numbers">A string containing delimited numbers. This should contain one or more lines.</param>
        /// <returns>The sum.</returns>
        public int Add(string numbers)
        {
            var delimiters = _delimiterParser.Parse(numbers);

            var lines = _numberLinesParser.GetLines(numbers);

            var linesOfNumbers = lines.Select(line => _numbersParser.Parse(line, delimiters));

            var filteredNumbers = linesOfNumbers.Select(line => _numberFilter.Filter(line));

            var detectedNumbers = filteredNumbers.Select(nums => _numberDetector.Detect(nums)).SelectMany(arr => arr);

            if (detectedNumbers.Any())
                throw new InvalidNumbersException($"Invalid numbers encountered", detectedNumbers);

            return _numberAdder.Add(filteredNumbers);
        }
    }
}
