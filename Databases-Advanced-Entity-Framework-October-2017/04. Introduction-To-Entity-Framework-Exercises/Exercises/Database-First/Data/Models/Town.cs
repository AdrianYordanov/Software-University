// Rename namespace to "P02_DatabaseFirst.Data.Models" in judge
namespace Database_First.Data.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
            this.Addresses = new HashSet<Address>();
        }

        public int TownId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public ICollection<Address> Addresses
        {
            get;
            set;
        }
    }
}