using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class LargerThanFilterTests
    {
        public void Does_Filter_Number() {

            //Arrange
            const int max = 1000;
            var numbers = new []{ 1, 500, 1000, 1001, 1003, 7, 1001, 999 };
            var filter = new LargerThanFilter(max);

            //Act
            var result = filter.Filter(numbers);

            //Assert
            Assert.AreEqual(5, result.Count());
            Assert.AreEqual(numbers[0], result.First());
            Assert.AreEqual(numbers[3], result.Skip(2).First());
            Assert.AreEqual(numbers.Last(), result.Last());
        }
    }
}
