using System;
using System.Diagnostics;

namespace LeetcodeMinimumJumpsToReachHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var forbidden = new int[]
            {
                1362, 873, 1879, 725, 305, 794, 1135, 1358, 1717, 159, 1370, 1861, 583, 1193, 1921, 778, 1263, 239,
                1224, 1925, 1505, 566, 5, 15
            };

            int a = 560;
            int b = 573;
            int x = 64;
            
            var sol = new Solution();
            var jumps = sol.MinimumJumps(forbidden, a, b, x);
        }
    }
}
