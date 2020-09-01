﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
    }
}