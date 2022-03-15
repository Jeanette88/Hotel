using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Bill
    {
        public Bill()
        {
            Bookings = new HashSet<Booking>();
            ProductsBills = new HashSet<ProductsBill>();
        }

        public int Id { get; set; }
        public int PaymentMethodId { get; set; }
        public int StatusId { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<ProductsBill> ProductsBills { get; set; }
    }
}
