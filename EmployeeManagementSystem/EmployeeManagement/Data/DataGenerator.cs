using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
            {
                // Look for any department.
                if (context.Departments.Any())
                {
                    return;   // Data was already seeded
                }

                context.Departments.AddRange(
                    new Department
                    {
                        DeptId = 1,
                        DepartmentName = "HR"
                    },
                    new Department
                    {
                        DeptId = 2,
                        DepartmentName = "IT"
                    },
                    new Department
                    {
                        DeptId = 3,
                        DepartmentName = "Developer"
                    },
                    new Department
                    {
                        DeptId = 4,
                        DepartmentName = "Marketing"
                    }, new Department
                    {
                        DeptId = 5,
                        DepartmentName = "Ad"
                    });

               

                context.SaveChanges();
            }


            
        }
    }
}