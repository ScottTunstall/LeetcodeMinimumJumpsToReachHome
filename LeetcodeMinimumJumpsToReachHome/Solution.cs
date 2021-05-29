using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetcodeMinimumJumpsToReachHome
{
    public class Solution
    {
        private int?[] _numberOfJumps;
        private bool?[] _hasJumpedForwardToReachThisSpot;
        private List<int> _forbidden;
        private int _min;
        private int _max;
        private int _jumpForward;
        private int _jumpBackward;

        // https://leetcode.com/problems/minimum-jumps-to-reach-home/
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            // The first jump has to be forward.
            // Can we make the first jump?
            if (forbidden.Contains(a))
                return -1;

            _min = 0;
            _forbidden = forbidden.OrderBy(num=>num).ToList();
            _jumpForward= a;
            _jumpBackward = b;

            // This is a test value allocating WAY more than is actually needed
            _max = 3999;

            _numberOfJumps = new int?[4000];
            _hasJumpedForwardToReachThisSpot = new bool?[4000];

            _numberOfJumps[a] = 1;
            _hasJumpedForwardToReachThisSpot[a] = true;

            RecurseJump(a);

            if (_numberOfJumps[x]==null)
                return -1;

            return _numberOfJumps[x].Value;
        }

        private void RecurseJump(int i)
        {
            if (CanJumpBackwardFrom(i))
            {
                var newX = JumpBackward(i);
                RecurseJump(newX);
            }

            if (CanJumpForwardFrom(i))
            {
                var newX = JumpForward(i);
                RecurseJump(newX);
            }
        }


        private bool CanJumpForwardFrom(int i)
        {
            var newX = i + _jumpForward;
            return CanJumpTo(i,newX);
        }

        
        private int JumpForward(int fromPos)
        {

            var newXPos = fromPos + _jumpForward;

            Log($"Jumping forward from {fromPos} to {newXPos}");
            
            Debug.Assert(_numberOfJumps[fromPos] != null);
            Debug.Assert(_numberOfJumps[newXPos] == null);

            _numberOfJumps[newXPos] = _numberOfJumps[fromPos] + 1;
            _hasJumpedForwardToReachThisSpot[newXPos] = true;

            return newXPos;
        }

        private bool CanJumpBackwardFrom(int i)
        {
            var newX = i - _jumpBackward;
            if (!CanJumpTo(i, newX))
                return false;

            // You can't jump backward twice.
            return (_hasJumpedForwardToReachThisSpot[i] == true);
        }
        
        private int JumpBackward(int fromPos)
        {
            var newXPos = fromPos - _jumpBackward;

            Log($"Jumping backward from {fromPos} to {newXPos}");

            Debug.Assert(_numberOfJumps[fromPos] != null);
            Debug.Assert(_numberOfJumps[newXPos] ==null);

            _numberOfJumps[newXPos] = _numberOfJumps[fromPos] + 1;
            _hasJumpedForwardToReachThisSpot[newXPos] = false;
            return newXPos;
        }


        private bool CanJumpTo(int currentXpos, int newXpos)
        {
            Log($"Considering a jump from {currentXpos} to {newXpos}");

            if (newXpos < _min)
            {
                Log($"Jump fails: {newXpos} less than {_min}");
                return false;
            }

            if (newXpos > _max)
            {
                Log($"Jump fails: {newXpos} more than {_max}");
                return false;
            }
            
            if (_forbidden.Contains(newXpos))
            {
                Log($"Can't jump from {currentXpos} to {newXpos} as its forbidden.");
                return false;
            }

            var haveNotJumpedHereAlready = (_numberOfJumps[newXpos] == null);
            
            Log($"{newXpos} OK to jump to: {haveNotJumpedHereAlready}");
            return haveNotJumpedHereAlready;
        }


        [Conditional("DEBUG")]
        void Log(string text)
        {
            Console.WriteLine(text);
        }

    }
}
