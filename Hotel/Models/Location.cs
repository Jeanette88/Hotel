using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Location
    {
        public Location()
        {
            Customers = new HashSet<Customer>();
            Hotels = new HashSet<Hotel>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }
    }
}
