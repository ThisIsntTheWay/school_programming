using System;

namespace U6
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Write("Please provide an E-Mail address: ");
                string input = Console.ReadLine();

                bool inputValid = true;
                string errMsg = "Error: ";

                // Check for a @
                if (!(input.Contains('@'))) { inputValid = false; errMsg += "No @ detected."; }
                
                // Segregate string as it must have a '@'
                if (inputValid) {
                    string recipient = input.Split('@')[0];
                    string domain = input.Split('@')[1];
                    
                    if (recipient.Length < 1 && inputValid) { inputValid = false; errMsg += "No recipient detected."; }
                    if (domain.Length <= 0 && inputValid) { inputValid = false; errMsg += "No domain detected."; }

                    // Check if domain is valid
                    // We're not using split() here as a domain could have more than one dots.
                    if (domain.Contains('.') && inputValid) {
                        string tld = domain.Substring(domain.IndexOf('.') + 1);
                        if (!(tld.Length > 0)) { inputValid = false; errMsg += "TLD is not valid."; }
                    } else {
                        inputValid = false;
                        errMsg += "TLD is missing.";
                    }   
                }

                if (!inputValid) {
                    Console.WriteLine(errMsg);
                } else {
                    Console.WriteLine("OK: Address is valid.");
                }
            }
        }
    }
}
