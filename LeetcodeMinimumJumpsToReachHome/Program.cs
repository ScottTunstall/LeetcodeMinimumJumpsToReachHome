using System;

namespace LeetcodeMinimumJumpsToReachHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();

            //var forbidden = new int[] { 18, 13, 3, 9, 8, 14 };
            //int a = 3;
            //int b = 8;
            //int x = 6;


            var forbidden = new int[] {128, 178, 147, 165, 63, 11, 150, 20, 158, 144, 136};
            int a = 61;
            int b = 170;
            int x = 135;
            
            sol.MinimumJumps(forbidden, a, b, x);

        }
    }
}
