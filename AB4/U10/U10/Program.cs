using System;
using System.Collections.Generic;
using System.Globalization;
using Tsbe.Raumfahrt;

namespace U10
{
    class Program
    {
        private static List<Raumschiff> Shuttles = new List<Raumschiff>();
        private static List<Land> Countries = new List<Land>();

        static void Main(string[] args)
        {
            // Add countries
            Countries.Add(new Land() { Name = "Sobvjetunion", ISO3 = "USSR", Einwohner = 286730819, Hauptstadt = "Moskau" });
            Countries.Add(new Land() { Name = "Vereinigte Staten", ISO3 = "USA", Einwohner = 328200000, Hauptstadt = "Washington, D.C." });
            Countries.Add(new Land() { Name = "China", ISO3 = "CHN", Einwohner = 1398000000, Hauptstadt = "Beijing" });

            // Add shuttles
            Shuttles.Add(new Raumschiff() {
                Programm = "Sputnik  1",
                EinsatzVon = 19571004,
                EinsatzBis = 19571026,
                Land = Countries.Find(t => t.ISO3 == "USSR"),
                Traegerrakete = "Vostok-3KA No.3"
            });

            Shuttles.Add(new Raumschiff()
            {
                Programm = "Schenzhou 2",
                EinsatzVon = 20010109,
                EinsatzBis = 20010116,
                Land = Countries.Find(t => t.ISO3 == "CHN"),
                Traegerrakete = "Long March 2F"
            });

            Shuttles.Add(new Raumschiff()
            {
                Programm = "Rosetta",
                EinsatzVon = 20040302,
                EinsatzBis = 20160930,
                Land = Countries.Find(t => t.ISO3 == "USA"),
                Traegerrakete = "Airane 5G+ V-158"
            });

            // Prompt to console
            foreach (var shuttle in Shuttles) {
                // This could be heaviliy shortened if the OS culture accepts 'yyyyMMdd' as a standard time format - which mine does not >:(
                DateTime einsatzVon; DateTime.TryParseExact((shuttle.EinsatzVon).ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out einsatzVon);
                DateTime einsatzBis; DateTime.TryParseExact((shuttle.EinsatzBis).ToString(), "yyyyMMdd", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out einsatzBis);
                var zeitspanne = (einsatzBis - einsatzVon).TotalDays;

                Console.WriteLine("Programm: {0}", shuttle.Programm);
                Console.WriteLine("Land: {0}", shuttle.Land.Name);
                Console.WriteLine("Einsatz von: {0}", einsatzVon);
                Console.WriteLine("Einsatz bis: {0}", einsatzBis);
                Console.WriteLine("Einsatzdauer (d): {0}", zeitspanne);
                Console.WriteLine("============================");
            }
        }
    }
}
