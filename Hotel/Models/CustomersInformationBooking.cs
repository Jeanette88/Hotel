using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class CustomersInformationBooking
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfGuests { get; set; }
        public int RoomSize { get; set; }
        public int NumberOfBeds { get; set; }
        public decimal Price { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime CheckOut { get; set; }
        public string Status { get; set; } = null!;
    }
}
