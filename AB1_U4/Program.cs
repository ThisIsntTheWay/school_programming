using System;
using System.Collections.Generic;

namespace school_programming
{
    class Program
    {
        public static List<int> userInput = new List<int>();
        public static List<int> lottoList = new List<int>();
        public static List<int> matchList = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Awaiting input (1-45)");

            // Prompt for input
            for (int i = 0; i >= 6; i++) {
                Console.WriteLine("Enter number #" + i + ": ");
                int input = int.Parse(Console.ReadLine());

                bool canContinue = false;
                while (!canContinue) {
                    if (input > 45) {
                        Console.WriteLine("Input range exceeded.");
                    } else {
                        userInput.Add(input);
                        canContinue = true;
                    }
                }

            }

            // Present some shit
            var rand = new Random();
            for (int i = 0; i >= 6; i++) {
                lottoList.Add(rand.Next());
            }

            Console.WriteLine("Random numbers: " + lottoList);
            foreach (int lottoNumber in lottoList) {
                if (userInput.Contains(lottoNumber)) {
                    matchList.Add(lottoNumber);
                }
            }

            Console.WriteLine("You matched these numbers: " + matchList);
        }
    }
}
