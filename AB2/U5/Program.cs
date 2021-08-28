using System;

namespace AB2_U5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.Write("Please provide a number: ");
                int i = Convert.ToInt32(Console.ReadLine());

                String output = String.Format("{0:0.00}", Math.Sqrt(i));
                Console.WriteLine("The root of this number is: " + output);
            }
        }
    }
}
