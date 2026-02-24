using System;
using System.Collections.Generic;
using System.Text;
using CheckEvenCode.Feature;

namespace EvenTestproj
{
    [TestClass]
    public class CheckEven
    {
        [TestMethod]
        public void CheckEven_GivenNum_ResultBool()
        {
            // Arrange
            var check = new Check();
            // Act
            bool result = check.CheckEven(6);
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]

        [DataRow(2)]
        [DataRow(3)]
        [DataRow(14)]
        [DataRow(-15)]
        [DataRow(0)]

        public void CheckEven_GivenNum_ResultBool(int a)
        {
            // Arrange
            var check = new Check();
            // Act
            bool result = check.CheckEven(a);
            // Assert
            Assert.IsTrue(result);
        }
    }
}
