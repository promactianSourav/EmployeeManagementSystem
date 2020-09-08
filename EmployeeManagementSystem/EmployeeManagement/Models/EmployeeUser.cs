using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    //[Table("Employee")]
    public class EmployeeUser:IdentityUser
    {
       
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        [Required(ErrorMessage ="Please fill the contact number.")]
        [RegularExpression(@"^([0-9]{10})$",ErrorMessage ="Not a valid Phone number")]
        public string ContactNumber { get; set; }
        [ForeignKey("DeptId")]
        public int DepartmentId { get; set; }
        public string RoleUser { get; set; }

        //public virtual ICollection<Department> DepartmentList { get; set; }

        //public Employee()
        //{
        //    this.DepartmentList = new List<Department>();
        //    //Department d = new Department();
        //    //d.DeptId = 1;
        //    //d.DepartmentName = "HR";
        //    //this.DepartmentList.Add(d);
        //}
    }
}