using System;
using System.Collections.Generic;

namespace EMS_Data.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        // 1 to many relationships
        public string Head { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
