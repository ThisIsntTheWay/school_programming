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
        /// Enter description here for the second constructor.
        /// </summary>
        /// <param name="ingress">Array of numbers as input.</param>
        public static void StoreUserInput(int[] ingress)
        {
            userLottoNumbers.Clear();

            // Exception handling
            if (ingress.Length < lottoNumbers) {
                Console.WriteLine("Error: Too few numbers. Expected {0}, got {1}", lottoNumbers, ingress.Length);
                return;
            } else {
                for (int i = 0; i <= lottoNumbers; i++) {
                    if (ingress[i] > numberLimit)
                    {
                        Console.WriteLine("Error: Number ({0}) at array index {1} higher than the limit of {2}.", ingress[i], i, numberLimit);
                        return;
                    }
                }
            }

            userLottoNumbers.AddRange(ingress);
            return;
        }

        /**
         * @brief           Generates system lotto numbers and returns as List.
         */
        public static List<int> GenerateNumbers() {
            systemLottoNumbers.Clear();

            var rand = new Random();
            for (int i = 0; i <= lottoNumbers; i++) {
                Console.WriteLine("Iteration: {0}", i);
                systemLottoNumbers.Add(rand.Next(numberLimit));
            }

            return systemLottoNumbers;
        }

        /**
         * @brief           Matches user input with system lotto numbers.
         * @param output    [bool] If true, announce to console.
         */
        public static void MatchNumbers(bool output)
        {
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
                Console.WriteLine("[Error] Lotto lists have bad length.\nUser numbers: {0}\nSystem numbers: {1}", userLottoNumbers.Count, systemLottoNumbers.Count);
                return;
            }

            if (output)
            {
                if (matchedLottoNumbers.Count > 0)
                {
                    Console.Write("Matched numbers: ");
                    returnList(matchedLottoNumbers);
                }
                else
                {
                    Console.WriteLine("No numbers have been matched.");
                    Console.Write("The system numbers were: ");
                    returnList(systemLottoNumbers);
                }
            }
        }

        /**
         * @brief           Prints the contents of a list to console on one line, seperated by a space.
         * @param target    [List] The list to use.
         */
        private static void returnList(List<int> target)
        {
            foreach (Object obj in target)
                Console.Write("{0} ", obj);
        }
    }
}
