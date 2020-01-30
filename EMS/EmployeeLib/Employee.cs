using System;

namespace EmployeeLib
{
    public class Employee
    {
        public int Id { get; set; }
        public int? Age { get; set; }
        public DateTime? Startdate { get; set; }
        public decimal? Salary { get; set; }
        public string Ssn { get; set; }
        public int? Deptid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public string FullName
        {
            get
            {
                if (Mname != null)
                    return $"{Fname} {Mname} {Lname}";
                else
                    return $"{Fname} {Lname}";
            }
        }
        public Department department { get; set; }
    }
}
