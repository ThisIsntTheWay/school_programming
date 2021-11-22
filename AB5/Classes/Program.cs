using System;
using System.Collections.Generic;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Country> CountryList = new List<Country>();
            List<Supercomputer> ComputerList = new List<Supercomputer>();

            CountryList.Add(new Country { Name = "United States", ISO3 = "USA", Population = 328200000, Capital = "Washington, D.C." });
            CountryList.Add(new Country { Name = "Japan", ISO3 = "JP", Population = 125800000, Capital = "Tokyo" });

            ComputerList.Add(new Supercomputer {
                Name = "IBM Summit",
                CpuCount = 9216,
                CoresPerCpu = 22,
                Petaflops = 200,
                Country = CountryList.Find(c => c.ISO3 == "USA"),
                Location = "Oak Ridge, U.S."
            });
            ComputerList.Add(new Supercomputer {
                Name = "Fugaku",
                CpuCount = 158976,
                CoresPerCpu = 52,
                Petaflops = 442,
                Country = CountryList.Find(c => c.ISO3 == "JP"),
                Location = "Riken Center, Kobe"
            });

            // Uncomment to throw exception
            //supercomputer.Name = "awdawuidzawiudawiudzawiuzdawiuzdiuawzda";
            foreach (var Computer in ComputerList)  {
                Console.WriteLine("Computer \"{0}\":", Computer.Name);
                Console.WriteLine("> CPUs: {0}", Computer.CpuCount);
                Console.WriteLine("> Cores per CPU: {0}", Computer.CoresPerCpu);
                Console.WriteLine("  > Cores total: {0}", Computer.Cores);
                Console.WriteLine("> PetaFlops: {0}", Computer.Petaflops);
                Console.WriteLine("  > TeraFLOPS per core: {0}", Computer.FlopsPerCore);
                Console.WriteLine("> Country: {0} / {1}", Computer.Country.Name, Computer.Country.ISO3);
                Console.WriteLine("  > Location: {0}", Computer.Location);
                Console.WriteLine(" ");
            }
        }
    }
}
