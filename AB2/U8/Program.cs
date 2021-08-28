using System;
using Tsbe.CodeCracker; // <- Class 'MD5Hash'

namespace U8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isLooping = true;

            while (isLooping) {
                Console.Write("Please input a password: ");
                string input = Console.ReadLine();
                String pwHash = MD5Hash.GeneratePassword(input);

                Console.WriteLine("Generated MD5 hash: {0}", pwHash);
                Console.WriteLine("");

                Console.Write("Attempt to crack? (y/n): ");
                if (Console.ReadLine() == "y") {
                    Console.Write("Specify password length: ");
                    int pwLength = int.Parse(Console.ReadLine());

                    Console.Write("Impose a character restriction? (y/n): ");
                    if (Console.ReadLine() == "y") {
                        Console.WriteLine("");
                        Console.WriteLine("Please specify characters to use during cracking.");
                        Console.WriteLine("NOTE: Do not use delimiters, all chars will be isolated anyway!");
                        Console.Write("> ");

                        string charInput = Console.ReadLine();
                        MD5Hash.CrackPassword(pwHash, pwLength, charInput.ToCharArray());                     
                    } else {
                        MD5Hash.CrackPassword(pwHash, pwLength);
                    }
                } else {
                    isLooping = false;
                }

                Console.WriteLine();
            }
        }
    }
}
