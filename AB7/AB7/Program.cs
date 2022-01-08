using System;

namespace AB7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxFuelCapacity = 5000;
            Spaceship ship1 = new Spaceship(5, 10, maxFuelCapacity, 50000, 50);

            Console.WriteLine("* .  *  . * .  *  . * .  *  . * .  *  . *");
            Console.WriteLine("             Hello Space!");
            Console.WriteLine("* .  *  . * .  *  . * .  *  . * .  *  . *");
            Console.WriteLine(" ");

            // HR demo
            Console.WriteLine("Our HR is hiring! Max occupancy: {0}.", ship1.MaxOccupancy);
            if (ship1.AddCrew(5)) {
                Console.WriteLine("> We hired two people and now have {0} staff members!", ship1.CurrentOccupancy);
            }

            if (!ship1.AddCrew(10)) {
                Console.WriteLine("> We couldn't hire 10 more people and thus remain with {0} staff members!", ship1.CurrentOccupancy);
            }

            int maxStaffForHire = ship1.MaxOccupancy - ship1.CurrentOccupancy;
            if (ship1.AddCrew(maxStaffForHire)) {
                Console.WriteLine("> HR filled the crew to capacity with {0} new people! We now have {1} staff members.", maxStaffForHire, ship1.CurrentOccupancy);
            }

            Console.WriteLine("Uh oh, market instability and uncertainty has forced our HR to lay off portions of our crew!");
            if (ship1.RemoveCrew(1)) {
                Console.WriteLine("> HR fired 1 person! We now have {0} staff members.", ship1.CurrentOccupancy);
            }

            int maxStaffToFire = ship1.CurrentOccupancy - ship1.MinOccupancy;
            if (ship1.RemoveCrew(maxStaffToFire)) {
                Console.WriteLine("> HR had to fire {0} more people, bringing our staff down to {1} members.", maxStaffToFire, ship1.CurrentOccupancy);
            }

            Console.WriteLine();
            
            // Flight demo
            Console.WriteLine("Time for some flights, but we need to fuel up first!");
            int howMuchFuelToRefuel = maxFuelCapacity - ship1.CurrentFuel;
            if (ship1.Refuel(howMuchFuelToRefuel)) {
                Console.WriteLine("> Fueled ship up by {0} units.", howMuchFuelToRefuel);
            }

            int tripDistance = 500; int tripVelocity = 500;
            if (ship1.Fly(tripDistance, tripVelocity)) {
                Console.WriteLine("> We have travelled a distance of {0} using a velocity of {1}!", tripDistance, tripVelocity);
                Console.WriteLine("  > Fuel remaining: {0}.", ship1.CurrentFuel);
            }

            tripDistance = 600; tripVelocity = 2300;
            if (ship1.Fly(tripDistance, tripVelocity)) {
                Console.WriteLine("> We have travelled a new distance of {0} using a velocity of {1}!", tripDistance, tripVelocity);
                Console.WriteLine("  > Fuel remaining: {0}.", ship1.CurrentFuel);
            }

            howMuchFuelToRefuel = maxFuelCapacity - ship1.CurrentFuel;
            Console.WriteLine("Time to refuel! Our tank needs {0} units to refuel to capacity.", howMuchFuelToRefuel);

            Console.WriteLine();

            // Container demo
            Console.WriteLine("We will add some containers to our ship!");
            for (int i = 1; i <= 10; i++) {
                int capacity = i * 10;
                Console.WriteLine("> Adding a container ({0}) with a capacity of {1}.", i, capacity);
                ship1.AddContainer(capacity, i);
            }

            Console.WriteLine();
            Console.WriteLine("This ships cargo is now using {0} out of {1} available space.", ship1.CurrentLoad, ship1.MaxLoadCapacity);
            Console.WriteLine("We will now unload all of these containers...");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write("> Removing a container ({0})...", i);
                if (ship1.RemoveContainer(i)) {
                    Console.WriteLine(" > OK!");
                } else {
                    Console.WriteLine(" > NOK!");
                }

            }
        }
    }
}
