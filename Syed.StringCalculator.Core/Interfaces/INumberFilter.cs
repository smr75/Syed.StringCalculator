using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface INumberFilter
    {
        IEnumerable<int> Filter(IEnumerable<int> numbers);
    }
}
