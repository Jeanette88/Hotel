using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class CardInfo
    {
        public CardInfo()
        {
            CardInfoCustomers = new HashSet<CardInfoCustomer>();
        }

        public int Id { get; set; }
        public string CardNumber { get; set; } = null!;
        public DateTime Date { get; set; }
        public int _3digits { get; set; }

        public virtual ICollection<CardInfoCustomer> CardInfoCustomers { get; set; }
    }
}
