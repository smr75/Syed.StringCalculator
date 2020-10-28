using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Linq;
using Syed.StringCalculator.Core.Interfaces;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class NumberLinesParserTests
    {
        private readonly Mock<IDelimiterParser> _delimiterParserMock = new Mock<IDelimiterParser>();

        [TestMethod]
        public void Does_Parse_Single_Line_When_Header_Not_Present() {

            //Arrange
            _delimiterParserMock.Setup(d => d.HasHeader(It.IsAny<string>())).Returns(false);
            const string line1 = "1,2,3";
            var testString = $"{line1}";
            
            //Act
            var parser = new NumberLinesParser(_delimiterParserMock.Object);
            var result = parser.GetLines(testString);

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.Take(1).First(), line1);
        }

        [TestMethod]
        public void Does_Parse_Single_Line_When_Header_Present()
        {

            //Arrange
            _delimiterParserMock.Setup(d => d.HasHeader(It.IsAny<string>())).Returns(true);
            const string line1 = "1;2;3";
            var testString = $"//;{Environment.NewLine}{line1}";

            //Act
            var parser = new NumberLinesParser(_delimiterParserMock.Object);
            var result = parser.GetLines(testString);

            //Assert
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(result.Take(1).First(), line1);
        }

        [TestMethod]
        public void Does_Parse_Multiple_Lines()
        {
            //Arrange
            _delimiterParserMock.Setup(d => d.HasHeader(It.IsAny<string>())).Returns(false);
            const string line1 = "1,2,3";
            const string line2 = "4,5";
            const string line3 = "2";
            var testString = $"{line1}{Environment.NewLine}{line2}{Environment.NewLine}{line3}";

            //Act
            var parser = new NumberLinesParser(_delimiterParserMock.Object);
            var result = parser.GetLines(testString);

            //Assert
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(result.Take(1).First(), line1);
            Assert.AreEqual(result.Skip(1).Take(1).First(), line2);
            Assert.AreEqual(result.Skip(2).Take(1).First(), line3);
        }
    }
}
