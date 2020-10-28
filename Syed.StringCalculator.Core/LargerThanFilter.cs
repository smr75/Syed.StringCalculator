using Syed.StringCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Removes large numbers from the input. The threshold is determined by an input parameter.
    /// </summary>
    public class LargerThanFilter : INumberFilter
    {
        private readonly int _maxSize;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="maxSize">Any numbers greater than this value will be considered as too large.</param>
        public LargerThanFilter(int maxSize)
        {
            _maxSize = maxSize;
        }

        /// <summary>
        /// Filters out numbers deemed too large.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IEnumerable<int> Filter(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n <= _maxSize);
        }
    }
}
