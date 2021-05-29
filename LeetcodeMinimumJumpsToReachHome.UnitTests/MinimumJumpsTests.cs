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


        [TestMethod]
        public void MinimumJumps_Returns_3998()
        {
            var forbidden = new int[]
            {
                1998
            };

            int a = 1999;
            int b = 2000;
            int x = 2000;

            Assert.AreEqual(3998, _solution.MinimumJumps(forbidden, a, b, x));
        }


        [TestMethod]
        public void MinimumJumps_Returns_1036()
        {
            var forbidden = new int[]
            {
                1362, 873, 1879, 725, 305, 794, 1135, 1358, 1717, 159, 1370, 1861, 583, 1193, 1921, 778, 1263, 239,
                1224, 1925, 1505, 566, 5, 15
            };

            int a = 560;
            int b = 573;
            int x = 64;

            Assert.AreEqual(1036, _solution.MinimumJumps(forbidden, a, b, x));
        }

        [TestMethod]
        public void MinimumJumps_Returns_120()
        {
            var forbidden = new int[]
            {
                1401, 832, 1344, 173, 1529, 1905, 1732, 277, 1490, 650, 1577, 1886, 185, 1728, 1827, 1924,
                1723, 1034, 1839, 1722, 1673, 1198, 1667, 538, 911, 1221, 1201, 1313, 251, 752, 40, 1378,
                1515, 1789, 1580, 1422, 907, 1536, 294, 1677, 1807, 1419, 1893, 654, 1176, 812, 1094, 1942,
                876, 777, 1850, 1382, 760, 347, 112, 1510, 1278, 1607, 1491, 429, 1902, 1891, 647, 1560,
                1569, 196, 539, 836, 290, 1348, 479, 90, 1922, 111, 1411, 1286, 1362, 36, 293, 1349, 667,
                430, 96, 1038, 793, 1339, 792, 1512, 822, 269, 1535, 1052, 233, 1835, 1603, 577, 936, 1684,
                1402, 1739, 865, 1664, 295, 977, 1265, 535, 1803, 713, 1298, 1537, 135, 1370, 748, 448, 254,
                1798, 66, 1915, 439, 883, 1606, 796
            };

            int a = 19;
            int b = 18;
            int x = 1540;

            Assert.AreEqual(120, _solution.MinimumJumps(forbidden, a, b, x));
        }


    }
}