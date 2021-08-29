using System;
using System.Collections.Generic;

namespace ValiKlopfi.Lotto
{
    public static class Lotto
    {
        private static List<int> userLottoNumbers = new List<int>();
        private static List<int> systemLottoNumbers = new List<int>();
        private static List<int> matchedLottoNumbers = new List<int>();

        private static int numberLimit = 45;

        public static void StoreUserInput(int input, int amount) {
            userLottoNumbers.Clear();

            for (int i = 0; i <= amount; i++) {
                while (!canContinue) {
                    Console.Write("Enter number #" + (i+1) + ": ");
                    var e = Console.ReadLine();
                    int input = int.Parse(e);

                    // Verify input
                    if (input > numberLimit) {
                        Console.WriteLine("Input range exceeded.");
                    } else {
                        userLottoNumbers.Add(input);
                        canContinue = true;
                    }
                }
            }

            return;
        }

        public static void GenerateNumbers() {
            systemLottoNumbers.Clear();

            var rand = new Random();
            for (int i = 0; i <= userLottoNumbers.Count; i++) {
                Console.WriteLine("Iteration: {0}", i);
                systemLottoNumbers.Add(rand.Next(numberLimit));
            }

            return;
        }

        public static void MatchNumbers(bool output) {
            if (userLottoNumbers.count > 0 && systemLottoNumbers.count > 0) {
                matchedLottoNumbers.Clear();

                foreach (int lottoNumber in systemLottoNumbers) {
                    if (userLottoNumbers.Contains(lottoNumber)) {
                        matchedLottoNumbers.Add(lottoNumber);
                    }
                }
            } else {
                Console.WriteLine("[Error] Lotto lists have bad length.\nUser numbers: {0}\nSystem numbers: {1}", userLottoNumbers.count, systemLottoNumbers.count);
                return;
            }

            if (output) {
                if (matchedLottoNumbers.count > 0) {
                    Console.Write("Matched numbers: ");
                    returnList(matchedLottoNumbers);
                } else {
                    Console.WriteLine("No numbers have been matched.");
                    Console.Write("The system numbers were: ");
                    returnList(systemLottoNumbers);
                }
            }
        }

        private static void returnList( List<int> myCol )  {
            foreach ( Object obj in myCol )
                Console.Write( "{0} ", obj );
        }        
    }
}
