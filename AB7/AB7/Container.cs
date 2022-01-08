using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB7
{
    internal class Container
    {
        private int containerCapacity;
        private int containerId;

        public int ContainerCapacity
        {
            get { return containerCapacity; }
            set { containerCapacity = value; }
        }
        public int ContainerId
        {
            get { return containerId; }
            set { containerId = value; }
        }

        public Container(int capacity, int id) {
            this.containerCapacity = capacity;
            this.containerId = id;
        }
    }
}
