using Syed.StringCalculator.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core
{
    /// <summary>
    /// Detects negative numbers.
    /// </summary>
    public class NegativeNumberDetector : INumberDetector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public IEnumerable<int> Detect(IEnumerable<int> numbers)
        {
            return numbers.Where(n => n < 0);
        }
    }
}
