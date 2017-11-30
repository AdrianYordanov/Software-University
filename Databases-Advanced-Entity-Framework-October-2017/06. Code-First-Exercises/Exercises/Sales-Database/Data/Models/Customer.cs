namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Customer
    {
        public Customer(string name, string email, string creditCardNumber)
        {
            this.Name = name;
            this.Email = email;
            this.CreditCardNumber = creditCardNumber;
            this.Sales = new List<Sale>();
        }

        public Customer(string name, string email, string creditCardNumber, ICollection<Sale> sales)
            : this(name, email, creditCardNumber)
        {
            this.Sales = sales;
        }

        public int CustomerId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string CreditCardNumber
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