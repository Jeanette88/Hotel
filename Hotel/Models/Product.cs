using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsBills = new HashSet<ProductsBill>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }

        public virtual ICollection<ProductsBill> ProductsBills { get; set; }
    }
}
