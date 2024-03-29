﻿using System;
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
            bool gameActive = true;
            while (gameActive) {
                for (int i = 0; i <= 5; i++) {
                    bool canContinue = false;
                    while (!canContinue) {
                        Console.Write("Enter number #" + (i+1) + ": ");
                        var e = Console.ReadLine();
                        int input = int.Parse(e);

                        // Verify input
                        if (input > 45) {
                            Console.WriteLine("Input range exceeded.");
                        } else {
                            userInput.Add(input);
                            canContinue = true;
                        }
                    }
                }

                // Generate random numbers
                var rand = new Random();
                for (int i = 0; i <= 6; i++) {
                    lottoList.Add(rand.Next(45));
                }

                Console.Write("Random numbers: ");
                returnList(lottoList);
                Console.WriteLine();

                // Compare random numbers with user input
                foreach (int lottoNumber in lottoList) {
                    if (userInput.Contains(lottoNumber)) {
                        matchList.Add(lottoNumber);
                    }
                }

                // Inform player
                if (matchList.Count > 0) {
                    Console.Write("You matched these numbers: ");
                    returnList(matchList);
                } else {
                    Console.WriteLine("Matched no numbers!");
                }

                Console.WriteLine();
                Console.WriteLine();

                // Prompt for retry
                Console.Write("Retry? (y/n): ");
                if (Console.ReadLine() != "y") {
                    gameActive = false;
                } else {
                    userInput.Clear();
                    lottoList.Clear();
                    matchList.Clear();
                }
            }
        }

        public static void returnList( List<int> myCol )  {
            foreach ( Object obj in myCol )
                Console.Write( "{0} ", obj );
        }
    }
}
