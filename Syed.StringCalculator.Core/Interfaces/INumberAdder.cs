using System.Collections.Generic;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface INumberAdder
    {
        int Add(IEnumerable<IEnumerable<int>> numbers);
    }
}
