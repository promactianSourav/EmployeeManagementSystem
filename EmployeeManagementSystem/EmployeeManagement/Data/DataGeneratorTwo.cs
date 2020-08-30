using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Data
{
    public class DataGeneratorTwo
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
           
            using (var context = new DataContextTwo(
               serviceProvider.GetRequiredService<DbContextOptions<DataContextTwo>>()))
            {
                // Look for any department.
                if (context.Employees.Any())
                {
                    return;   // Data was already seeded
                }

                var depcon = new DataContext(
                 serviceProvider.GetRequiredService<DbContextOptions<DataContext>>());
                context.Employees.AddRange(
                    new Employee
                    {
                        Id = 1,
                        Name = "firstEmployee",
                        Surname = "Kumar",
                        Address = "first, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = "1234567890",
                        DepartmentId = 1

                    },
                    new Employee
                    {
                        Id = 2,
                        Name = "secondEmployee",
                        Surname = "Kumar",
                        Address = "second, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = "1234567890",
                        DepartmentId = 2
                    },
                    new Employee
                    {
                        Id = 3,
                        Name = "thirdEmployee",
                        Surname = "Kumar",
                        Address = "third, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = "1234567890",
                        DepartmentId = 3
                    },
                    new Employee
                    {
                        Id = 4,
                        Name = "fourthEmployee",
                        Surname = "Kumar",
                        Address = "fourth, gujarat, 1234",
                        Qualification = "B.Tech",
                        ContactNumber = "1234567890",
                        DepartmentId = 2
                    }) ;


               

                context.SaveChanges();
            }
        }
    }
}