using Microsoft.VisualStudio.TestTools.UnitTesting;
using Syed.StringCalculator.Core;
using System.IO;
using System;
using System.Linq;
using Syed.StringCalculator.Core.Exceptions;

namespace Syed.StringCalculator.AcceptanceTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Does_Add_Single_Line_Comma_Delimited()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = File.ReadAllText(@".\Samples\SingleLineCommaSeparated.txt");

            //Act
            var result = calculator.Add(inputString);

            //Assert
            Assert.AreEqual(18, result);
        }

        [TestMethod]
        public void Does_Return_Zero_When_Empty_String()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = "";

            //Act
            var result = calculator.Add(inputString);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Does_Add_Multi_Line_Comma_Delimited()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = File.ReadAllText(@".\Samples\MultiLineCommaSeparated.txt");

            //Act
            var result = calculator.Add(inputString);

            //Assert
            Assert.AreEqual(51, result);
        }

        [TestMethod]
        public void Does_Add_Multi_Line_With_Multiple_Custom_Delimiters()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = File.ReadAllText(@".\Samples\MultiDelimiterMultiLine.txt");

            //Act
            var result = calculator.Add(inputString);

            //Assert
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Does_Add_Multi_Line_Comma_Delimited_And_Ignores_Too_Large_Numbers()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = File.ReadAllText(@".\Samples\MultiLineCommaSeparatedWithIgnoredNumbers.txt");

            //Act
            var result = calculator.Add(inputString);

            //Assert
            Assert.AreEqual(41, result);
        }

        [TestMethod]
        public void Does_Throw_Error_When_Negative_Numbers_Found()
        {
            //Arrange
            var calculator = new BasicStringCalculator();
            var inputString = File.ReadAllText(@".\Samples\MultiLineCommaSeparatedWithNegativeNumbers.txt");
            var expectedNegativeNumbers = new[] { -1, -2, -3, -4 };
            Exception ex = null;

            //Act
            try
            {
                var result = calculator.Add(inputString);
            } catch(Exception nex)
            {
                ex = nex;
            }

            //Assert
            Assert.IsInstanceOfType(ex, typeof(InvalidNumbersException));
            var invalidNumbers = ((InvalidNumbersException)ex).InvalidNumbers;
            Assert.AreEqual(4, invalidNumbers.Count());
            Assert.AreEqual(4, invalidNumbers.Intersect(expectedNegativeNumbers).Count());
        }
    }
}