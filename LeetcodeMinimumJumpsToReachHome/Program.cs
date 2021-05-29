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
                1998
            };

            int a = 1999;
            int b = 2000;
            int x = 2000;

            var sol = new Solution();
            var jumps = sol.MinimumJumps(forbidden, a, b, x);
        }
    }
}
