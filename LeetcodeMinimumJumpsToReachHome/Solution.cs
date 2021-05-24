using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeMinimumJumpsToReachHome
{
    public class Solution
    {
        private Dictionary<int, string> _numberToJumpsMap;


        // https://leetcode.com/problems/minimum-jumps-to-reach-home/
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            if (x % a == 0)
                return x / a;

            _numberToJumpsMap = new();

            _numberToJumpsMap[a] = "F";

            for (int i = a; i <= x+a; i++)
            {
                if (!forbidden.Contains(i))
                    memoize(i, a, b);
            }

            return 0;
        }



        private void memoize(int i, int jumpForward, int jumpBackward)
        {
            if (!_numberToJumpsMap.ContainsKey(i))
            {
                if (_numberToJumpsMap.ContainsKey(i - jumpForward))
                {
                    _numberToJumpsMap[i] = _numberToJumpsMap[i-jumpForward] + 'F';
                }
            }

            if (_numberToJumpsMap.ContainsKey(i) && !_numberToJumpsMap.ContainsKey(i - jumpBackward) && (!_numberToJumpsMap[i].EndsWith("B")))
            {
                _numberToJumpsMap[i-jumpBackward] = _numberToJumpsMap[i] + "B";
            }
        }
    }
}
