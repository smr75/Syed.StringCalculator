using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface INumberLinesParser
    {
        IEnumerable<string> GetLines(string source);
    }
}
