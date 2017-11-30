namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Store
    {
        public Store(string name)
        {
            this.Name = name;
            this.Sales = new List<Sale>();
        }

        public Store(string name, ICollection<Sale> sales)
            : this(name)
        {
            this.Sales = sales;
        }

        public int StoreId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ICollection<Sale> Sales
        {
            get;
            set;
        }
    }
}