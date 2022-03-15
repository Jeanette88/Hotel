using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int SizeM2 { get; set; }
        public int NumberOfBeds { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
