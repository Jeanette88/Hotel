using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public int EmployeeRoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? PhoneNr { get; set; }
        public string Email { get; set; } = null!;
        public DateTime? StartDate { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
    }
}
