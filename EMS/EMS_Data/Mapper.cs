using EmployeeLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeDataAccess
{
    class Mapper
    {
        public static EmployeeLib.Employee Map(EMS_Data.Models.Employee employee)
        {
            return new EmployeeLib.Employee()
            {
                Id = employee.Id,
                Age=employee.Age,
                Deptid=employee.Deptid,
                Fname=employee.Fname,
                Lname=employee.Lname,
                Mname=employee.Mname,
                Salary=employee.Salary,
                Ssn=employee.Ssn,
                Startdate=employee.Startdate,
                department=Mapper.Map(employee.Dept)
            };
        }
        public static EMS_Data.Models.Employee Map(EmployeeLib.Employee employee)
        {
            return new EMS_Data.Models.Employee()
            {
                Id = employee.Id,
                Age = employee.Age,
                Deptid = employee.Deptid,
                Fname = employee.Fname,
                Lname = employee.Lname,
                Mname = employee.Mname,
                Salary = employee.Salary,
                Ssn = employee.Ssn,
                Startdate = employee.Startdate
            };
        }

        public static EmployeeLib.Department Map(EMS_Data.Models.Department department)
        {
            return new EmployeeLib.Department()
            {
                Id = department.Id,
                Name = department.Name,
                Phone = department.Phone
            };
        }
        public static EMS_Data.Models.Department Map(EmployeeLib.Department department)
        {
            return new EMS_Data.Models.Department()
            {
                Id = department.Id,
                Name = department.Name,
                Phone = department.Phone
            };
        }
    }
}
