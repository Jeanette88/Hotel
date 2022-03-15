using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class ProductsBill
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int BillId { get; set; }
        public int Amount { get; set; }

        public virtual Bill Bill { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
