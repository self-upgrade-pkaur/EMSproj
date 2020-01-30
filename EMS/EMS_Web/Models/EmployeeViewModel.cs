using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMS_Web.Models
{
    public class EmployeeViewModel
    {
        [Display(Name ="First Name"), Required(ErrorMessage ="First Name cannot be empty")]
        public string Fname { get; set; }
        [Display(Name = "Last Name"), Required(ErrorMessage = "Last Name cannot be empty")]
        public string Lname { get; set; }

        [Display(Name = "Middle Name")]
        public string Mname { get; set; }
        [Range(minimum:16,maximum:70, ErrorMessage ="Employees of age between 16 to 70 can apply"), Required(ErrorMessage = "Age cannot be empty")]
        public int Age { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Display(Name ="Social Security Number"),RegularExpression("[0-9]{9}", ErrorMessage ="SSN is a 9 digit number without dashes (-)")]
        public string Ssn { get; set; }
        [Display(Name ="Date of Joining")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; } = DateTime.Now;

        public string Department { get; set; }

    }
}
