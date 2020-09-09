using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        [Required]
        public string DeptId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}