using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Repository
{
    public class NotificationRepository 
    {
        public DataContextAll _context { get; }
        public RoleManager<Userroles> roleManager { get; }
        public UserManager<Employee> userManager { get; }
        public SignInManager<Employee> signInManager { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        public NotificationRepository(DataContextAll dataContextAll, RoleManager<Userroles> _roleManager, UserManager<Employee> _userManager,
            SignInManager<Employee> _signInManage,IHttpContextAccessor httpContextAccessor)
        {
            _context = dataContextAll;
            roleManager = _roleManager;
            userManager = _userManager;
            signInManager = _signInManage;
            HttpContextAccessor = httpContextAccessor;
        }

        public NotificationRepository(DataContextAll dataContextAll)
        {
            _context = dataContextAll;
        }

        public void Create(Notification notification)
        {
            
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            //if (signInManager.IsSignedIn(HttpContextAccessor.HttpContext.User) || true)
            //{
                //How we know the new User is created by Admin or HR
                //string currentEmp =HttpContextAccessor.HttpContext.User.Identity.Name;

                var lists = _context.Employees.ToList();

                foreach (var emp in lists)
                {
                    var userNotification = new NotificationUser();
                    userNotification.EmployeeUserId = emp.Id;
                    userNotification.NotificationId = notification.Id;

                    _context.UserNotifications.Add(userNotification);
                    _context.SaveChanges();
                }
            //}
            

        }
        public List<Notification> GetNotificationUsers(string userId)
        {
            //.Where(q => q.EmployeeUserId.Equals(userId))
            return _context.Notifications
                .Where(n => n.IsRead==false)
                .ToList();

            //return _context.UserNotifications
            //    .Include(n => n.Notification)
            //    .ToList();
        }

        public void ReadNotification(string Id)
        {
            var notification = _context.Notifications.FirstOrDefault(n => n.Id == Id);
            notification.IsRead = true;
            _context.Notifications.Update(notification);
            _context.SaveChanges();
        }

    }
}
