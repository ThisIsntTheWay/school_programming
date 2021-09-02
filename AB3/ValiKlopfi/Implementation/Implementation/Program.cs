using System;
using ValiKlopfi.Lotto;

namespace Implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("let's get this bread!");

            int[] myNums = new int[] { 1, 2, 3, 4, 5, 6 };

            Lotto.StoreUserInput(myNums);
            Lotto.GenerateNumbers();
            Lotto.MatchNumbers(true);
        }
    }
}
