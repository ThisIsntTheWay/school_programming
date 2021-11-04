using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Supercomputer
    {
        private int maxNameLength = 30;

        private long cores;
        private int cpuCount;
        private double coresPerCpu;
        private Country country;
        private string name;
        private double petaflops;
        private string location;
        private DateTime lastModification;

        public int CpuCount {
            get { return cpuCount; }
            set { cpuCount = value; }
        }

        public double CoresPerCpu {
            get { return coresPerCpu; }
            set { coresPerCpu = value; }
        }

        public double FlopsPerCore {
            get { return petaflops / cores; }
        }

        public long Cores { 
            get { return Convert.ToInt64(CpuCount * CoresPerCpu); }
            set { cores = value; } 
        }

        public Country Country {
            set { country = value; }
            get { return country; }
        }

        public string Name {
            get {
                return name;
            } set {
                if (value.Length <= 30) {
                    name = value;
                } else {
                    throw new ArgumentException(String.Format("Name exceeds max permissible length of {0}.", this.maxNameLength));
                }
            }
        }

        public double Petaflops { 
            get { return petaflops; }
            set { petaflops = value; }
        }

        public string Location {
            set { location = value; }
            get { return location; }
        }
    }
}
