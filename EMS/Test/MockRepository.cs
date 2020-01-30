using System;
using System.Collections.Generic;
using System.Text;
using EmployeeLib;
using EmployeeLib.Abstractions;
using System.Linq;

namespace Test
{
    public class MockRepository : IRepositoryEmployee<EmployeeLib.Employee>
    {
        static IEnumerable<EmployeeLib.Employee> employees = new List<EmployeeLib.Employee>() { 
            new Employee(){ 
            Id=1,
            Age=32,
            Deptid=1,
            Fname="Carol",
            Lname="Baxtor",
            Salary=7000,
            Ssn="123456789",
            Startdate=new DateTime(2002,01,02)
            },
            new Employee(){
            Id=2,
            Age=22,
            Deptid=2,
            Fname="Ashley",
            Lname="Damminger",
            Salary=5000,
            Ssn="154456789",
            Startdate=new DateTime(2012,07,02)
            }

        };
        public void AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employees;
        }

        public void ModifyEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
