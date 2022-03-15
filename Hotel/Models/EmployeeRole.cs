﻿using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class EmployeeRole
    {
        public EmployeeRole()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
