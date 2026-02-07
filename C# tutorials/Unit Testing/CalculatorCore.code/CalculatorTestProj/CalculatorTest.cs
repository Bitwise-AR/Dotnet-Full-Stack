using System;
using System.Collections.Generic;
using System.Text;
using Calculatorcode.Feature;

namespace CalculatorTestProj
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_GivenTwoNum_ResultInt()
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            int result = calculator.Add(6, 2);
            // Assert
            Assert.AreEqual(result, 8);
        }

        [TestMethod]
        [DataRow(2, 1, 3)]
        [DataRow(11, 1, 12)]
        [DataRow(5, 5, 10)]
        [DataRow(-1, 1, 0)]
        public void Add_Parameterized(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();
            // Act
            int result = calculator.Add(a, b);
            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
