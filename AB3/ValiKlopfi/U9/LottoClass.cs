using System;
using System.Linq;
using System.Collections.Generic;

namespace ValiKlopfi.Lotto
{
    /// <summary>
    ///  Class to store, generate and match lotto numbers,
    /// </summary>
    public static class Lotto
    {
        private static List<int> userLottoNumbers = new List<int>();
        private static List<int> systemLottoNumbers = new List<int>();
        private static List<int> matchedLottoNumbers = new List<int>();

        private static int numberLimit = 42;
        private static int lottoNumbers = 6;

        /// <summary>
        /// Stores user numbers.
        /// </summary>
        /// <param name="ingress">Array of numbers as input.</param>
        public static void StoreUserInput(int[] ingress)
        {
            userLottoNumbers.Clear();

            // Exception handling
            if (ingress.Length < lottoNumbers) {
                Console.WriteLine("[Error] Too few user numbers. Expected {0}, got {1}", lottoNumbers, ingress.Length);
                return;
            } else {
                for (int i = 0; i <= lottoNumbers - 1; i++) {
                    if (ingress[i] > numberLimit)
                    {
                        Console.WriteLine("[Info]  Number ({0}) at array index {1} higher than the limit of {2}.", ingress[i], i, numberLimit);
                        return;
                    }
                }
            }

            userLottoNumbers.AddRange(ingress);
            return;
        }

        /// <summary>
        /// Generates x amount of lotto numbers and stores them in a private list.
        /// Also returns said list.
        /// </summary>
        public static List<int> GenerateNumbers() {
            systemLottoNumbers.Clear();

            var rand = new Random();
            for (int i = 1; i <= lottoNumbers; i++) {
                systemLottoNumbers.Add(rand.Next(numberLimit));
            }

            return systemLottoNumbers;
        }

        /// <summary>
        /// Matches user input with system numbers.
        /// Returns the amount of numbers that have been matched.
        /// </summary>
        /// <param name="output">Whether to print matches to console.</param>
        public static int MatchNumbers(bool output)
        {
            Console.WriteLine("[Info] Matching numbers...");

            if (userLottoNumbers.Count > 0 && systemLottoNumbers.Count > 0)
            {
                matchedLottoNumbers.Clear();

                foreach (int lottoNumber in systemLottoNumbers)
                {
                    if (userLottoNumbers.Contains(lottoNumber))
                    {
                        matchedLottoNumbers.Add(lottoNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("[Error] Lotto lists have bad length.\n > User numbers: {0}\n > System numbers: {1}", userLottoNumbers.Count, systemLottoNumbers.Count);
                return 0;
            }

            if (output)
            {
                if (matchedLottoNumbers.Count > 0)
                {
                    Console.Write("[Result] Matched {0} number(s): ", matchedLottoNumbers.Count);
                        returnList(matchedLottoNumbers);
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("[Result] No numbers have been matched.");
                }

                Console.Write("[Info] The system numbers were: ");
                    returnList(systemLottoNumbers);
                Console.WriteLine("");
            }

            return matchedLottoNumbers.Count();
        }


        /// <summary>
        /// Returns a list to console on one line, each entry seperated using a space.
        /// </summary>
        /// <param name="target">Input list.</param>
        private static void returnList(List<int> target)
        {
            foreach (Object obj in target)
                Console.Write("{0} ", obj);
        }
    }
}
