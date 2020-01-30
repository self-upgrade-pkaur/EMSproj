using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS_Web.Models
{
    public class EmployeeDepartmentViewModel
    {
        [Display(Name ="Employee Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
