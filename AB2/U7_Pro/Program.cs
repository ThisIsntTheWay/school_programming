using System;
using System.IO;

namespace U7_Pro
{
    class Program
    {
        // Using a '@' here to circumvent escape characters

        static void Main(string[] args)
        {
            string path = @"C:\temp";
            string recPath = @"";
            string rec2Path = @"";

            Console.WriteLine("Spamming " + path);

            if (Directory.Exists(path)) {
                for (int i = 0; i < 11; ++i) {
                    path = @"C:\temp\Wowee" + i;
                    Console.WriteLine(path);

                    if (!Directory.Exists(path)) {
                        DirectoryInfo info = Directory.CreateDirectory(path);
                        //Console.WriteLine("> Dir created!");

                        // Recursion hell
                        for (int a = 0; a < i; ++a) {
                            recPath = path + @"\MoreWowee" + (a + 1);
                            Console.WriteLine("Wowee recursion #" + a + " = " + recPath);

                            if (!Directory.Exists(recPath)) {
                                Directory.CreateDirectory(recPath);
                            }
                            
                            for (int b = 0; b < a + 2; ++b) {
                                rec2Path = recPath + @"\EvenMoreWowee" + (b + 1);
                                Console.WriteLine("Wowee SECOND recursion #" + b + " = " + rec2Path);

                                if (!Directory.Exists(rec2Path)) {
                                    Directory.CreateDirectory(rec2Path);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
