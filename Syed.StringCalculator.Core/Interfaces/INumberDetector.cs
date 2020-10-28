using System;
using System.Collections.Generic;
using System.Text;

namespace Syed.StringCalculator.Core.Interfaces
{
    public interface INumberDetector
    {
        IEnumerable<int> Detect(IEnumerable<int> numbers);
    }
}
