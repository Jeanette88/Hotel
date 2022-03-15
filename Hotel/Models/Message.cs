using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookingId { get; set; }
        public string? Message1 { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
