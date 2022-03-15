using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class ContactPerson
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNr { get; set; } = null!;
        public string? Email { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
