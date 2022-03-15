using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int HotelId { get; set; }

        public virtual Hotel Hotel { get; set; } = null!;
        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
