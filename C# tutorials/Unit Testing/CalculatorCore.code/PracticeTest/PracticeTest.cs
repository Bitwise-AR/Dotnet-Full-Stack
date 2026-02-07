
using Practice.Feature;

namespace PracticeTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestSumN()
        {
            var sum= new SumOfNumbers();
            int result = sum.SumOfN(5);
            Assert.AreEqual(15, result);
        }

        [TestMethod]

        [DataRow(1, 1)]
        [DataRow(5, 15)]
        [DataRow(10, 15)] // wrong
        public void TestSumParameterized(int n, int expected)
        {
            var sum = new SumOfNumbers();
            int result = sum.SumOfN(n);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestReverse()
        {
            var reversed = new ReverseString();
            string result = reversed.Reverse("hello");
            Assert.AreEqual("olleh", result);
        }

        [TestMethod]
        [DataRow("hello", "olleh")]
        [DataRow("world", "dlrow")]
        [DataRow("CSharp", "prahsc")] // wrong
        public void TestReverseParameterized(string str, string expected)
        {
            var reversed = new ReverseString();
            string result = reversed.Reverse(str);
            Assert.AreEqual(result, expected);
        }
    }
}
