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
        private bool _hitTheTarget;

        // https://leetcode.com/problems/minimum-jumps-to-reach-home/
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
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
            _hitTheTarget = false;

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
            if (_hitTheTarget)
                return;

            // If we hit the target, we need to stop any further jumping. A flag will suffice.
            if (currentXPos == _x)
            {
                _hitTheTarget = true;
                return;
            }

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

            var haveNotJumpedHereAlready = (_numberOfJumps[newXPos] == null);
            
            Log($"{newXPos} OK to jump to: {haveNotJumpedHereAlready}");
            return haveNotJumpedHereAlready;
        }


        [Conditional("DEBUG")]
        void Log(string text)
        {
            Console.WriteLine(text);
        }

    }
}
