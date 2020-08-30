using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class DataContextTwo : DbContext
    {
        public DataContextTwo(DbContextOptions<DataContextTwo> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
       
    }
}