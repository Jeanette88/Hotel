using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class StatusLog
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public DateTime ChangedDate { get; set; }

        public virtual Status Status { get; set; } = null!;
    }
}
