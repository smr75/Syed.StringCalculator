using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class NumbersParserTests
    {
        [TestMethod]
        public void Does_Parse_Numbers()
        {
            //Arrange
            var parser = new NumbersParser();
            var delimiters = new List<string>() { ";", "$", "#" };
            const string testString = "1;2$5#6";

            //Act
            var numbers = parser.Parse(testString, delimiters);

            //Assert
            Assert.AreEqual(4, numbers.Count());
            Assert.AreEqual(1, numbers.First());
            Assert.AreEqual(6, numbers.Last());
        }
    }
}
