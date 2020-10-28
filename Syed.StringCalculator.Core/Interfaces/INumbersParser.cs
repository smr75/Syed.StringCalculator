using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface INumbersParser
    {
        IEnumerable<int> Parse(string numbers, IEnumerable<string> delimiters);
    }
}
