using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Syed.StringCalculator.Core.Tests
{
    [TestClass]
    public class NegativeNumberDetectorTests
    {
        [TestMethod]
        public void Does_Detect_Negative_Numbers()
        {
            //Arrange
            var numbers = new[] { 1, -1, -2, 5000 };
            var detector = new NegativeNumberDetector();

            //Act
            var detectedNumbers = detector.Detect(numbers);

            //Assert
            Assert.AreEqual(2, detectedNumbers.Count());
            Assert.AreEqual(numbers[1], detectedNumbers.First());
            Assert.AreEqual(numbers[2], detectedNumbers.Skip(1).First());
        }
    }
}
