using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS_Data.Models
{
    [Table("employee", Schema ="Revature")]// this annotation withh generate a table <e>mployee and it will be tied to a schema (if its not present it will generate schema as well) Revature
    public class Employee
    {
        /*
         DataAnnotations are used for 2 major purpose
            1. to add constraints and create table as per the requirement
            2. to validate the data passed as model to the DB
             */
        [Key]// verbose way to declare a PK
        [Column("id")] // this annotation will generate the column of name id in the DB
        public int Id { get; set; } // DB will automatically create as a Primary Key
        //public int EmployeeId { get; set; } will be considered as Primary Key
        [Column("age")]
        public int? Age { get; set; }
        [Column("startdate")]
        public DateTime? Startdate { get; set; }
        [Column("salary")]
        public decimal? Salary { get; set; }
        [Column("ssn")]
        //[Required]
        public string Ssn { get; set; }      
        public int? Deptid { get; set; }
        [Required(ErrorMessage ="First name cannot be Empty"),StringLength(30)]
        public string Fname { get; set; }
        [Required]
        [StringLength(30)]
        public string Lname { get; set; }
        [StringLength(30)]
        public string Mname { get; set; }
        [NotMapped]// this annotation will not let create a column in the DB
        public string FullName { get {
                if (Mname != null)
                    return $"{Fname} {Mname} {Lname}";
                else
                    return $"{Fname} {Lname}";
            }
        }

        // 1 to 1 relationship
        //[ForeignKey("reference")]
        // virtual means this table will be lazily loaded
        public virtual Department Dept { get; set; }
    }
}
