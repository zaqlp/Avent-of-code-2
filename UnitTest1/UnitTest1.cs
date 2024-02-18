using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TwoNumbers()
        {
            string input = "12";
            int expected = 12;

            string result = Program.ProcessInput(input);

            Assert.AreEqual(expected, Int32.Parse( result));
        }

        [TestMethod]
        public void TwoNumbers2()
        {
            string input = "123456";
            int expected = 15;

            string result = Program.ProcessInput(input);

            Assert.AreEqual(expected, Int32.Parse(result));
        }
    }
}