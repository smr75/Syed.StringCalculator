using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class HeaderDelimiterParserTests
    {
        const string DELIMITER1 = ";";
        const string DELIMITER2 = "*";
        const string DELIMITER3 = ",";

        [TestMethod]
        public void Does_Return_Default_Delimiter_When_Empty_Delimiter_Line()
        {
            //Arrange 
            var parser = new HeaderDelimiterParser();
            var testString = $"{DELIMITER1}{Environment.NewLine}1{DELIMITER1}2";

            //Act
            var result = parser.Parse(testString);

            //Act
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(HeaderDelimiterParser.DEFAULT_DELIMITER, result[0]);
        }

        [TestMethod]
        public void Does_Return_Default_Delimiter_When_Invalid_Prefix()
        {
            //Arrange 
            var parser = new HeaderDelimiterParser();
            var testString = $"&&{DELIMITER1}{Environment.NewLine}1{DELIMITER1}2";

            //Act
            var result = parser.Parse(testString);

            //Act
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(HeaderDelimiterParser.DEFAULT_DELIMITER, result[0]);
        }

        [TestMethod]
        public void Does_Parse_Single_Delimiter()
        {
            //Arrange 
            var parser = new HeaderDelimiterParser();
            var testString = $"//{DELIMITER1}{Environment.NewLine}1{DELIMITER1}2";

            //Act
            var result = parser.Parse(testString);

            //Act
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(DELIMITER1, result[0]);
        }

        [TestMethod]
        public void Does_Parse_Multiple_Delimiters()
        {
            //Arrange 
            var parser = new HeaderDelimiterParser();
            var testString = $"//{DELIMITER1}{DELIMITER2}{DELIMITER3}{Environment.NewLine}1{DELIMITER1}2{DELIMITER2}7{DELIMITER1}";

            //Act
            var result = parser.Parse(testString);

            //Act
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(DELIMITER1, result[0]);
            Assert.AreEqual(DELIMITER2, result[1]);
            Assert.AreEqual(DELIMITER3, result[2]);
        }

        [TestMethod]
        public void Does_Detect_Header_Present()
        {
            //Arrange
            var testString = $"//;{Environment.NewLine}1;2";
            var parser = new HeaderDelimiterParser();

            //Act
            var hasHeader = parser.HasHeader(testString);

            //Assert
            Assert.IsTrue(hasHeader);
        }

        [TestMethod]
        public void Does_Detect_Header_Not_Present()
        {
            //Arrange
            var testString = $"1,2";
            var parser = new HeaderDelimiterParser();

            //Act
            var hasHeader = parser.HasHeader(testString);

            //Assert
            Assert.IsFalse(hasHeader);
        }
    }
}
