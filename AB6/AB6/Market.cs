using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB6
{
    internal class Market
    {
        private int fixedCosts;
        private int soldArticles;

        public string Name;
        public List<Product> Products;
        public List<Sales> Sales;

        public int SoldArticels { get { return soldArticles; } }
        public int FixedCosts { get { return fixedCosts; } }

        public Market(int initialFixedCosts, string Name) {
            this.fixedCosts = initialFixedCosts;
            this.Name = Name;
        }

        public void AddToSales(Product what, DateTime when) {
            Sales.Add(new Sales(what, when));
            this.soldArticles++;
        }

        public int ReturnSales() {
            return soldArticles;
        }

        public int ReturnGrossRevenue()
        {
            return 0;
        }

        public int ReturnNetRevenue()
        {
            return 0;
        }
    }

    internal class Sales
    {
        private Product productReference;
        private DateTime timeSold;

        public Product ProductReference { get { return productReference; } }

        public DateTime TimeSold { get { return timeSold; } }

        public Sales(Product what, DateTime when) {
            this.productReference = what;
            this.timeSold = when;
        }
    }
}
