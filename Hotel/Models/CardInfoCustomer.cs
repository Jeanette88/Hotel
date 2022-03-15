using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class CardInfoCustomer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CardInfoId { get; set; }

        public virtual CardInfo CardInfo { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
