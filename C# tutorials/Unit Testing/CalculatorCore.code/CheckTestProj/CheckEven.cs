using System;
using System.Collections.Generic;
using System.Text;

namespace CheckTestProj
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
    }
}
