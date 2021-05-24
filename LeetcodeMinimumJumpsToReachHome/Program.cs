using System;

namespace LeetcodeMinimumJumpsToReachHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            var forbidden = new int[] {1,6,2,14,5,17,4};
            int a = 16;
            int b = 9;
            int x = 7;

            sol.MinimumJumps(forbidden, a, b, x);

        }
    }
}
