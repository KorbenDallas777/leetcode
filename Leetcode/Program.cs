using System;
using Leetcode.Tasks;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            // #1 Check brackets
            var isCorrect = Brackets.IsCorrectString("([](<>[]))()");
            Console.WriteLine(isCorrect);

            Console.ReadKey();

        }
    }
}
