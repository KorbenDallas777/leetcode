using System;
using System.Collections.Generic;

namespace Leetcode.Tasks
{
    public class Brackets
    {
        private static readonly Dictionary<Char, (BracketType, BracketState)> _bracketsList;

        static Brackets()
        {
            _bracketsList = new Dictionary<char, (BracketType, BracketState)>()
            {
                {'(', (BracketType.Circle, BracketState.Open)},
                {')', (BracketType.Circle, BracketState.Close)},
                {'<', (BracketType.Tag, BracketState.Open)},
                {'>', (BracketType.Tag, BracketState.Close)},
                {'[', (BracketType.Square, BracketState.Open)},
                {']', (BracketType.Square, BracketState.Close)},
            };
        }

        public static bool IsCorrectString(string input)
        {
            var resultList = new Stack<BracketType>();
            var isOnlyClosedBrackets = true;

            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            foreach (var bracket in input)
            {
                if (!_bracketsList.TryGetValue(bracket, out var value))
                {
                    return false;
                }

                BracketState state = value.Item2;
                BracketType type = value.Item1;

                if (state == BracketState.Open)
                {
                    isOnlyClosedBrackets = false;
                    resultList.Push(value.Item1);
                }
                else if (resultList.Count > 0 && resultList.Peek() == type)
                {
                    resultList.Pop();
                }
                else
                {
                    return false;
                }
            }

            return resultList.Count == 0 && !isOnlyClosedBrackets;
        }

    }

    public enum BracketState
    {
        Close = 0,
        Open = 1
    }

    public enum BracketType
    {
        Circle = 0,
        Tag = 1,
        Square = 2
    }
}