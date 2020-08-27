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
                        Id = 1,
                        DepartmentName = "HR"
                    },
                    new Department
                    {
                        Id = 2,
                        DepartmentName = "Engineer"
                    },
                    new Department
                    {
                        Id = 3,
                        DepartmentName = "Developer"
                    },
                    new Department
                    {
                        Id = 4,
                        DepartmentName = "Marketing"
                    });

                context.Employees.AddRange(
                    new Employee
                    {
                        Id = 1,
                        Name = "firstEmployee",
                        Surname = "Kumar",
                        Address = "first, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = 1234567890,
                        Department = "HR"
                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "secondEmployee",
                        Surname = "Kumar",
                        Address = "second, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = 1234567890,
                        Department = "Engineer"
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "thirdEmployee",
                        Surname = "Kumar",
                        Address = "third, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = 1234567890,
                        Department = "Developer"
                    },
                    new Employee
                    {
                        Id = 4,
                        Name = "fourthEmployee",
                        Surname = "Kumar",
                        Address = "fourth, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = 1234567890,
                        Department = "Marketing"
                    });

                context.SaveChanges();
            }
        }
    }
}