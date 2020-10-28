using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class NumberAdderTests
    {
        [TestMethod]
        public void Does_Add_Numbers()
        {
            //Arrange
            var numbers = new int[][] { new []{ 1, 4, 6, 0 } };
            var adder = new NumberAdder();

            //Act
            var total = adder.Add(numbers);

            //Assert
            Assert.AreEqual(11, total);
        }
    }
}
