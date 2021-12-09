using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB6
{
    internal class Product
    {
        private int id;
        private string name;
        private int price;
        private int margin;
        private int soldCount;

        public int Id { get { return id; }}
        public int Price { get { return price; } set { price = value; } }
        public int Margin { get { return margin; } set { margin = value; } }
        public int SoldCount { get { return soldCount; }}
        public string Name { get { return name; }}

        public Product(int Id, int Price, int Margin, string Name) {
            this.price = Price;
            this.margin = Margin;
            this.name = Name;
            this.id = Id;
        }

        public bool Sell() {
            this.soldCount++;
        }
    }
}
