using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Supercomputer fätzecompi = new Supercomputer();

            // Uncomment to throw exception
            //supercomputer.Name = "awdawuidzawiudawiudzawiuzdawiuzdiuawzda";
            fätzecompi.Name = "IBM Summit";
            fätzecompi.CpuCount = 9216;
            fätzecompi.CoresPerCpu = 22;
            fätzecompi.Petaflops = 200;
            fätzecompi.Country = new Country() {
                Name = "United States",
                ISO3 = "USA",
                Population = 328200000,
                Capital = "Washington, D.C."
            };
            fätzecompi.Location = "Oak Ridge, U.S.";

            Console.WriteLine("Fätzecompi \"{0}\":", fätzecompi.Name);
            Console.WriteLine("> CPUs: {0}", fätzecompi.CpuCount);
            Console.WriteLine("> Cores per CPU: {0}", fätzecompi.CoresPerCpu);
            Console.WriteLine("  > Cores total: {0}", fätzecompi.Cores);
            Console.WriteLine("> PetaFlops: {0}", fätzecompi.Petaflops);
            Console.WriteLine("  > TeraFLOPS per core: {0}", fätzecompi.FlopsPerCore);
            Console.WriteLine("> Country: {0} / {1}", fätzecompi.Country.Name, fätzecompi.Country.ISO3);
            Console.WriteLine("> Location: {0}", fätzecompi.Location);
        }
    }
}
