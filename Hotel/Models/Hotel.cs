using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            CustomerReviews = new HashSet<CustomerReview>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public int LocationId { get; set; }
        public string HotelName { get; set; } = null!;
        public string PhoneNr { get; set; } = null!;

        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<CustomerReview> CustomerReviews { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
