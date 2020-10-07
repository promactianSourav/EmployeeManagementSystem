using System;     
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Intrastructure;
using EmployeeManagement.Models;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace EmployeeManagement.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        public DataContextAll _context { get; }
        public RoleManager<Userroles> roleManager { get; }
        public UserManager<Employee> userManager { get; }
        public SignInManager<Employee> signInManager { get; }
        public IHttpContextAccessor HttpContextAccessor { get; }

        private IHubContext<SignalServer> _hubContext { get; }
        public NotificationRepository(DataContextAll dataContextAll, RoleManager<Userroles> _roleManager, UserManager<Employee> _userManager,
            SignInManager<Employee> _signInManage,IHttpContextAccessor httpContextAccessor,IHubContext<SignalServer> hubContext)
        {
            _context = dataContextAll;
            roleManager = _roleManager;
            userManager = _userManager;
            signInManager = _signInManage;
            HttpContextAccessor = httpContextAccessor;
            _hubContext = hubContext;
        }

        //public NotificationRepository(DataContextAll dataContextAll,IHubContext<SignalServer> hubContext)
        //{
        //    _context = dataContextAll;
        //    _hubContext = hubContext;
        //}

        public void CreateDepartNoti(Notification notification,string changer, string changeObjectId)
        {

            _context.Notifications.Add(notification);
            _context.SaveChanges();
            
            var changeObjectDepartment = _context.Departments.FirstOrDefault(a => a.DeptId == changeObjectId);

            if (changeObjectDepartment != null)
            {
                var listOfHR = _context.UserRoles.Where(a => a.RoleId == "2");
                //var lists = _context.Employees.Where(a => { listOfHR.Contains(a.Id) });
                foreach (var emp in listOfHR)
                {
                    var userNotification = new NotificationUser();
                    userNotification.EmployeeUserId = emp.UserId;
                    userNotification.NotificationId = notification.Id;
                    userNotification.Notification = notification;

                    _context.UserNotifications.Add(userNotification);

                }
                _context.SaveChanges();
            }
            _hubContext.Clients.All.SendAsync("displayNotification", "");

        }

        public void Create(Notification notification,string changer,string changeObjectId)
        {
            
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            var changeObjectDepartment = _context.Departments.FirstOrDefault(a => a.DeptId == changeObjectId);

            

            if ((changer == "Admin" || changer == "HR"))
            {
                var lists = _context.Employees.Where(a => a.DepartmentId == changeObjectId);
                foreach (var emp in lists)
                {
                    var userNotification = new NotificationUser();
                    userNotification.EmployeeUserId = emp.Id;
                    userNotification.NotificationId = notification.Id;

                    _context.UserNotifications.Add(userNotification);
                    
                }
                _context.SaveChanges();

            }

            if (changer == "")
            {
                var listOfAdmin = _context.UserRoles.Where(a => a.RoleId == "1");
                foreach (var emp in listOfAdmin)
                {
                    var userNotification = new NotificationUser();
                    userNotification.EmployeeUserId = emp.UserId;
                    userNotification.NotificationId = notification.Id;

                    _context.UserNotifications.Add(userNotification);
                    
                }
                _context.SaveChanges();

                var listOfHR = _context.UserRoles.Where(a => a.RoleId == "2");
                foreach (var emp in listOfHR)
                {
                    var userNotification = new NotificationUser();
                    userNotification.EmployeeUserId = emp.UserId;
                    userNotification.NotificationId = notification.Id;

                    _context.UserNotifications.Add(userNotification);
                  
                }
                _context.SaveChanges();
            }

            //if (signInManager.IsSignedIn(HttpContextAccessor.HttpContext.User) || true)
            //{
            //How we know the new User is created by Admin or HR
            //string currentEmp =HttpContextAccessor.HttpContext.User.Identity.Name;

            //var lists = _context.Employees.ToList();

            //foreach (var emp in lists)
            //{
            //    var userNotification = new NotificationUser();
            //    userNotification.EmployeeUserId = emp.Id;
            //    userNotification.NotificationId = notification.Id;

            //    _context.UserNotifications.Add(userNotification);
            //    _context.SaveChanges();
            //}
            //}
            _hubContext.Clients.All.SendAsync("displayNotification", "");

        }
        public List<Notification> GetNotificationUsers(string userId)
        {
            //.Where(q => q.EmployeeUserId.Equals(userId))
            var listNotificationIds = _context.UserNotifications.Where(a => a.EmployeeUserId == userId && a.IsRead==false).ToList();
            //List<Notification> listNotifications = _context.Notifications.Where(n => listNotificationIds.All(i => i.NotificationId == n.Id)).ToList();
            List<Notification> list1 = _context.Notifications.ToList();
            List<Notification> list2 = (from one in list1
                                       join two in listNotificationIds
                                       on one.Id equals two.NotificationId
                                       select one).ToList();
            // Console.WriteLine(list2);
            return list2;

            //return _context.UserNotifications
            //    .Include(n => n.Notification)
            //    .ToList();
        }

        //public void ReadNotification(string Id, string userId)
        //{
        //    NotificationUser notificationUser = new NotificationUser();
        //    notificationUser = (NotificationUser)_context.UserNotifications.FirstOrDefault(n => n.NotificationId == Id && n.EmployeeUserId == userId);
        //    notificationUser.IsRead = true;
        //    _context.UserNotifications.Update(notificationUser);
        //    _context.SaveChanges();
        //}

        public List<NotificationUser> GetNotificationUsersSecond(string userId)
        {
            throw new NotImplementedException();
        }

        public void ReadNotification(string Id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
