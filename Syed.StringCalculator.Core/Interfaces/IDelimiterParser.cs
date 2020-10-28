using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface IDelimiterParser
    {
        List<string> Parse(string source);

        bool HasHeader(string source);
    }
}
