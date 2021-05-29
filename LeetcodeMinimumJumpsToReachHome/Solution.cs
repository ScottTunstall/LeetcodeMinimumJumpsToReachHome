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
        private int _minXPos;
        private int _maxXPos;
        private int _jumpForward;
        private int _jumpBackward;
        private int _targetXPos;
        private int _minForbidden;
        private int _maxForbidden;

        // https://leetcode.com/problems/minimum-jumps-to-reach-home/
        public int MinimumJumps(int[] forbidden, int a, int b, int x)
        {
            if (x == 0)
                return 0;

            // Order the forbidden items so that we can binary search through them.
            _forbidden = forbidden.OrderBy(num => num).ToList();

            // The first jump has to be forward. The spec states you can't jump [backward] into a negative value.
            // Is the first jump onto a forbidden space?
            if (_forbidden.BinarySearch(a) > -1)
                return -1;

            // Record the min and max values in _forbidden. This is so that we can skip
            // looking through the _forbidden array for a value we know is outside the bounds.
            // A nice wee optimisation that should hopefully shave millisecs off the main algorithm. 
            _minForbidden = _forbidden.First();
            _maxForbidden = _forbidden.Last();

            _minXPos = 0;

            _jumpForward = a;
            _jumpBackward = b;
            _targetXPos = x;

            // This is allocating WAY more than is actually needed
            _maxXPos = _targetXPos + ((a + b)*3);

            _numberOfJumps = new int?[_maxXPos + 1];
            _hasJumpedForwardToReachThisSpot = new bool?[_maxXPos + 1];

            // The first space we jump to requires a forward jump.
            // As it's the first jump we make, we record a value of 1.
            // The next jump we make will have a value of 2, and so on.
            _numberOfJumps[a] = 1;
            _hasJumpedForwardToReachThisSpot[a] = true;

            RecurseJump(a);

            if (_numberOfJumps[_targetXPos] ==null)
                return -1;

            return _numberOfJumps[_targetXPos].Value;
        }

        private void RecurseJump(int currentXPos)
        {
            // If we hit the target, jump no more!
            if (currentXPos == _targetXPos)
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

            if (newXPos < _minXPos)
            {
                Log($"Jump fails: {newXPos} less than {_minXPos}");
                return false;
            }

            if (newXPos > _maxXPos)
            {
                Log($"Jump fails: {newXPos} more than {_maxXPos }");
                return false;
            }
            
            if ((newXPos>=_minForbidden && newXPos<= _maxForbidden) && _forbidden.BinarySearch(newXPos)>-1)
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

            var currentCost = _numberOfJumps[currentXPos]+1 ;
            var destinationCost = _numberOfJumps[newXPos];
            var isLessCost = (currentCost < destinationCost);

            Log($"Cost of jumping from {currentXPos} ({currentCost}) to {newXPos} ({destinationCost}) : {isLessCost}");

            return isLessCost;
        }


        [Conditional("LOG")]
        void Log(string text)
        {
            Console.WriteLine(text);
        }

    }
}
