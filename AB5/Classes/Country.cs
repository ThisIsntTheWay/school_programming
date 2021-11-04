using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Country
    {
        private int population;
        private string capital;
        private string iso3;
        private string name;

        private DateTime lastModification;

        public int Population {
            get { return population; }
            set {
                this.lastModification = DateTime.Now;
                population = value;
            }
        }

        public string Capital {
            get { return capital; }
            set {
                this.lastModification = DateTime.Now; 
                capital = value;
            }
        }

        public string ISO3 {
            get { return iso3; }
            set {
                this.lastModification = DateTime.Now;

                if (value.Length <= 3) {
                    iso3 = value;
                } else {
                    throw new ArgumentException("ISO3 designation exceeds 3 characters.");
                }
            }
        }

        public string Name {
            get {
                this.lastModification = DateTime.Now;
                return name;
            }
            set { name = value; }
        }
    }
}
