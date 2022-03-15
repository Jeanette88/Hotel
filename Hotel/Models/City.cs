using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class City
    {
        public City()
        {
            Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Location> Locations { get; set; }
    }
}
