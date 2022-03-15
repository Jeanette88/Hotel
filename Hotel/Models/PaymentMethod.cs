using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
