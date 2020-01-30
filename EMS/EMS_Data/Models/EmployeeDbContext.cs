using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS_Data.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext()
        {

        }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add some seed values
            modelBuilder.Entity<Department>().HasData(
                new Department() { 
                    Id=1,
                    Name="Training",
                    Phone="7894561230"
                },
                new Department()
                {
                    Id=2,
                    Name="HR",
                    Phone="9876543210"
                }
                );
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Age = 35,
                    Deptid = 1,
                    Fname = "Fred",
                    Lname = "Belotte",
                    Salary = 11000.00M,
                    Ssn = "789kl45",
                    Startdate = DateTime.Now
                },
                new Employee()
                {
                    Id = 2,
                    Age = 25,
                    Deptid = 2,
                    Fname = "Cameron",
                    Lname = "Coley",
                    Salary = 5000.00M,
                    Ssn = "745kl65",
                    Startdate = DateTime.Now
                }
                );
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
