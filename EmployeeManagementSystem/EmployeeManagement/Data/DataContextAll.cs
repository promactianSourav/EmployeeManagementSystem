using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class DataContextAll : IdentityDbContext
    {
        public DataContextAll(DbContextOptions<DataContextAll> options)
            : base(options) { }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Userroles> UserRolesList { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationUser> UserNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<NotificationUser>()
                   .HasKey(k => new { k.NotificationId, k.EmployeeUserId });
            builder.Entity<Notification>()
                   .Property(e => e.Id)
                   .ValueGeneratedOnAdd();
            base.OnModelCreating(builder);
            
        }
    }
}