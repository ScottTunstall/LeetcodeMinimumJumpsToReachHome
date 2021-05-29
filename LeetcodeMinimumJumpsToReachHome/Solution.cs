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
        private int _x;

        // https://leetcode.com/problems/minimum-jumps-to-reach-home/
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            if (x == 0)
                return 0;

            // The first jump has to be forward.
            // Can we make the first jump?
            if (forbidden.Contains(a))
                return -1;

            _min = 0;

            // Pre sort the forbidden list so we can use a binary search to
            // speed up lookups.
            _forbidden = forbidden.OrderBy(num=>num).ToList();
            
            _jumpForward= a;
            _jumpBackward = b;
            _x = x;

            // This is a test value allocating WAY more than is actually needed
            _max = _x + ((a + b)*5);

            _numberOfJumps = new int?[_max+1];
            _hasJumpedForwardToReachThisSpot = new bool?[_max+1];

            _numberOfJumps[a] = 1;
            _hasJumpedForwardToReachThisSpot[a] = true;

            RecurseJump(a);

            if (_numberOfJumps[_x]==null)
                return -1;

            return _numberOfJumps[_x].Value;
        }

        private void RecurseJump(int currentXPos)
        {
            if (currentXPos == _x)
                return;

            if (CanJumpBackwardFrom(currentXPos))
            {
                var newX = JumpBackward(currentXPos);
                RecurseJump(newX);
            }

            if (CanJumpForwardFrom(currentXPos))
            {
                var newX = JumpForward(currentXPos);
                RecurseJump(newX);
            }
        }


        // Aha! It appears I'm not considering the COST of the jump

        private bool CanJumpForwardFrom(int i)
        {
            var newX = i + _jumpForward;
            return CanJumpTo(i,newX);
        }

        
        private int JumpForward(int fromPos)
        {

            var newXPos = fromPos + _jumpForward;

            Log($"Jumping forward from {fromPos} to {newXPos}");

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

            _numberOfJumps[newXPos] = _numberOfJumps[fromPos] + 1;
            _hasJumpedForwardToReachThisSpot[newXPos] = false;
            return newXPos;
        }


        private bool CanJumpTo(int currentXPos, int newXPos)
        {
            Log($"Considering a jump from {currentXPos} to {newXPos}");

            if (newXPos < _min)
            {
                Log($"Jump fails: {newXPos} less than {_min}");
                return false;
            }

            if (newXPos > _max)
            {
                Log($"Jump fails: {newXPos} more than {_max}");
                return false;
            }
            
            if (_forbidden.BinarySearch(newXPos)>-1)
            {
                Log($"Can't jump from {currentXPos} to {newXPos} as its forbidden.");
                return false;
            }

            var haveJumpedHereAlready = (_numberOfJumps[newXPos] != null);
            if (!haveJumpedHereAlready)
            {
                Log($"OK to jump from {currentXPos} to {newXPos} as not jumped here already.");
                return true;
            }

            // The DJikstra code I wrote gave me this idea. Let's hope it works.
            var currentCost = _numberOfJumps[currentXPos] ;
            var destinationCost = _numberOfJumps[newXPos];
            var isLessCost = (currentCost+1 < destinationCost);

            Log($"Cost of jumping from {currentXPos} ({currentCost}) to {newXPos} ({destinationCost}) : {isLessCost}");

            return isLessCost;
        }


        [Conditional("DEBUG")]
        void Log(string text)
        {
            Console.WriteLine(text);
        }

    }
}
