using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class DiscountLevel
    {
        public DiscountLevel()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Discount { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
