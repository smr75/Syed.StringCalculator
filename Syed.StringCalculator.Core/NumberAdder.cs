using Syed.StringCalculator.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Returns the sum of a set of numbers.
    /// </summary>
    public class NumberAdder : INumberAdder
    {
        public int Add(IEnumerable<IEnumerable<int>> numbers)
        {
            return numbers.Select(nums => nums.Sum()).Sum();
        }
    }
}
