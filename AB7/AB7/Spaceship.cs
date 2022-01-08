using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB7
{
    internal class Spaceship
    {
        private int currentOccupancy;
        private int currentLoad;
        private int currentFuel;
        private int totalFlightDistance;
        private int lastRevision;
        private int maxOccupancy;
        private int maxLoadCapacity;
        private int maxFuelCapacity;
        private int minOccupancy;
        private int revisionInterval;
        private List<Container> containers;

        public int CurrentOccupancy
        {
            get { return currentOccupancy; }
            set { currentOccupancy = value; }
        }
        public int CurrentLoad
        {
            get { return currentLoad; }
            set { currentLoad = value; }
        }
        public int CurrentFuel
        {
            get { return currentFuel; }
        }
        public int TotalFlightDistance
        {
            get { return totalFlightDistance; }
        }
        public int LastRevision
        {
            get { return lastRevision; }
        }
        public int NextRevision
        {
            get
            {
                return (int)(lastRevision + revisionInterval - totalFlightDistance);
            }
        }
        public int RevisionInterval
        {
            get { return revisionInterval; }
            set { revisionInterval = value; }
        }
        public int MaxOccupancy {
            get { return maxOccupancy; }
        }
        public int MinOccupancy {
            get { return minOccupancy; }
        }
        public int MaxLoadCapacity {
            get { return maxLoadCapacity; }
        }

        public Spaceship(int minOcc, int maxOcc, int maxFuel, int maxLoadCap, int revInterval)
        {
            this.minOccupancy = minOcc;
            this.maxOccupancy = maxOcc;
            this.maxFuelCapacity = maxFuel;
            this.maxLoadCapacity = maxLoadCap;
            this.revisionInterval = revInterval;

            containers = new List<Container>();
        }

        /// <summary>Calculates fuel consumption of a planned trip.</summary>
        /// <param name="distance">Planned distance for the trip.</param>
        /// <param name="velocity">Planned velocity of ship for the trip.</param>
        /// <returns>Fuel to be consumed.</returns>
        private int calculateFuelConsumption(int distance, int velocity)
        {
            if (velocity <= 1000)
            {
                return 2 * distance;
            }
            else
            {
                return (((velocity - 1000) * (13 / 9000)) + 2) * distance;
            }
        }

        /// <summary>Commits flight.</summary>
        /// <param name="distance">Planned distance for the trip.</param>
        /// <param name="velocity">Planned velocity of ship for the trip.</param>
        /// <returns>TRUE if flight is possible.</returns>
        public bool Fly(int distance, int velocity)
        {
            // Sanity checks
            if (distance == 0 || velocity == 0)
            {
                return false;
            }

            if (!this.FuelSufficientForTrip(distance, velocity))
            {
                return false;
            }

            int fuelToBeConsumed = this.calculateFuelConsumption(distance, velocity);
            this.currentFuel -= fuelToBeConsumed;
            this.totalFlightDistance += distance;

            if (this.NextRevision <= 0)
            {
                this.Revise();
            }

            return true;
        }

        /// <summary>Calculates if the current fuel is sufficent for the planned trip.</summary>
        /// <param name="distance">Planned distance for the trip.</param>
        /// <param name="velocity">Planned velocity of ship for the trip.</param>
        /// <returns>TRUE if fuel is sufficient.</returns>
        public bool FuelSufficientForTrip(int distance, int velocity)
        {
            int fuelToBeConsumed = this.calculateFuelConsumption(distance, velocity);
            if (fuelToBeConsumed > this.currentFuel)
            {
                return false;
            }

            return true;
        }

        /// <summary>Executes a revision.</summary>
        public void Revise()
        {
            this.lastRevision = TotalFlightDistance;
        }

        /// <summary>Refuels the spaceship by X amount.</summary>
        /// <param name="capacity">Fuel to load.</param>
        /// <returns>TRUE if successfully refueled.</returns>
        public bool Refuel(int fuel)
        {
            if (fuel <= 0)
            {
                return false;
            }

            int newFueltankLoad = fuel + this.currentFuel;
            if (newFueltankLoad > this.maxFuelCapacity)
            {
                return false;
            }
            else
            {
                this.currentFuel = newFueltankLoad;
                return true;
            }
        }

        /// <summary>Loads a specified container onto the spaceship.</summary>
        /// <param name="capacity">Capacity of container.</param>
        /// <param name="id">ID of container.</param>
        /// <returns>TRUE if container was added, FALSE if load capacity exceeded or container is a duplicate.</returns>
        public bool AddContainer(int capacity, int id)
        {
            int newCapacity = capacity + this.CurrentLoad;

            if (capacity <= 0 || newCapacity > this.maxLoadCapacity) {
                return false;
            } else {
                Container container = containers.Find(c => c.ContainerId == id);
                if (container == null) {
                    this.containers.Add(new Container(capacity, id));
                    this.CurrentLoad = newCapacity;
                    return true;
                } else {
                    return false;
                } 
            }
        }

        /// <summary>Removes a specified container from the ship.</summary>
        /// <param name="id">ID of container.</param>
        /// <returns>TRUE if container was removed.</returns>
        public bool RemoveContainer(int id)
        {
            Container container = containers.Find(c => c.ContainerId == id);
            if (container != null) {
                containers.Remove(container);
                this.currentLoad -= container.ContainerCapacity;
                return true;
            } else {
                return false;
            }
        }

        /// <summary>Adds personnel to the spaceship.</summary>
        /// <param name="people">Amount of staff to add.</param>
        /// <returns>TRUE if recruitment was successfull, FALSE if ship is at capacity.</returns>
        public bool AddCrew(int people) {
            int newOccupancy = people + this.currentOccupancy;
            if (people <= 0 || newOccupancy > this.maxOccupancy || newOccupancy < this.minOccupancy) {
                return false;
            }

            this.currentOccupancy = newOccupancy;

            return true;
        }

        /// <summary>Lays off personnel from the spaceship.</summary>
        /// <param name="people">Amount of staff to retire.</param>
        /// <returns>TRUE if layoff was successful, FALSE if ship would become understaffed as a result.</returns>
        public bool RemoveCrew(int people) {
            int newOccupancy = this.currentOccupancy - people;
            if (people < 0 || newOccupancy < this.minOccupancy) {
                return false;
            } else {
                this.currentOccupancy = newOccupancy;
                return true;
            }
        }
    }
}