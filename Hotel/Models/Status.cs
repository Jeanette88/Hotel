using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Status
    {
        public Status()
        {
            Bills = new HashSet<Bill>();
            Bookings = new HashSet<Booking>();
            Employees = new HashSet<Employee>();
            StatusLogs = new HashSet<StatusLog>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<StatusLog> StatusLogs { get; set; }
    }
}
