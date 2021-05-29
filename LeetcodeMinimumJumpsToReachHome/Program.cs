using System;
using System.Diagnostics;

namespace LeetcodeMinimumJumpsToReachHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            var forbidden = new int[] {14, 4, 18, 1, 15};
            int a = 3, b = 15, x = 9;

            Debug.Assert(sol.MinimumJumps(forbidden, a, b, x) == 3);

            forbidden = new int[] { 1, 6, 2, 14, 5, 17, 4 };
            a = 16;
            b = 9;
            x = 7;

            Debug.Assert(sol.MinimumJumps(forbidden, a, b, x) == 2);

            forbidden = new int[] { 18, 13, 3, 9, 8, 14 };
            a = 3;
            b = 8;
            x = 6;

            Debug.Assert(sol.MinimumJumps(forbidden, a, b, x) == -1);


            forbidden = new int[]
            {
                162, 118, 178, 152, 167, 100, 40, 74, 199, 186, 26, 73, 200, 127,
                30, 124, 193, 84, 184, 36, 103, 149, 153, 9, 54, 154, 133, 95,
                45, 198, 79, 157, 64, 122, 59, 71, 48, 177, 82, 35, 14, 176, 16,
                108, 111, 6, 168, 31, 134, 164, 136, 72, 98
            };

            a = 29;
            b = 98;
            x = 80;

            Debug.Assert(sol.MinimumJumps(forbidden, a, b, x) == 121);
        }
    }
}
