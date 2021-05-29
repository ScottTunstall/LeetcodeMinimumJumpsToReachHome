using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetcodeMinimumJumpsToReachHome.UnitTests
{
    [TestClass]
    public class MinimumJumpsTests
    {
        private Solution _solution;

        [TestInitialize]
        public void Setup()
        {
            _solution = new Solution();
        }

        [TestMethod]
        public void MinimumJumps_Returns_3()
        {
            var forbidden = new int[] {14, 4, 18, 1, 15};
            int a = 3, b = 15, x = 9;

            Assert.AreEqual(3, _solution.MinimumJumps(forbidden, a, b, x));
        }


        [TestMethod]
        public void MinimumJumps_Returns_2()
        {
            var forbidden = new int[] {1, 6, 2, 14, 5, 17, 4};
            int a = 16, b = 9, x = 7;

            Assert.AreEqual(2, _solution.MinimumJumps(forbidden, a, b, x));
        }


        [TestMethod]
        public void MinimumJumps_Returns_Negative_1()
        {
            var forbidden = new int[] {18, 13, 3, 9, 8, 14};
            int a = 3, b = 8, x = 6;

            Assert.AreEqual(-1, _solution.MinimumJumps(forbidden, a, b, x));
        }


        [TestMethod]
        public void MinimumJumps_Returns_121()
        {
            var forbidden = new int[]
            {
                162, 118, 178, 152, 167, 100, 40, 74, 199, 186, 26, 73, 200, 127,
                30, 124, 193, 84, 184, 36, 103, 149, 153, 9, 54, 154, 133, 95,
                45, 198, 79, 157, 64, 122, 59, 71, 48, 177, 82, 35, 14, 176, 16,
                108, 111, 6, 168, 31, 134, 164, 136, 72, 98
            };

            int a = 29;
            int b = 98;
            int x = 80;

            Assert.AreEqual(121, _solution.MinimumJumps(forbidden, a, b, x));
        }
    }
}