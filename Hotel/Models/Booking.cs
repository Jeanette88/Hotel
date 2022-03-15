using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public int StatusId { get; set; }
        public int? BillId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestAmount { get; set; }

        public virtual Bill? Bill { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection<Message> Messages { get; set; }
    }
}
