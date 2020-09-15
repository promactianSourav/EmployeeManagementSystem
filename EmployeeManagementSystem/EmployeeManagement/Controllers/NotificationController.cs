using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Data;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Data.Entity;
using EmployeeManagement.Repository;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        //We inject the DBContext into the controller...
        private DataContextAll _context;
        private readonly RoleManager<Userroles> roleManager;
        private readonly UserManager<Employee> userManager;
        private readonly SignInManager<Employee> signInManager;

        public IHttpContextAccessor HttpContextAccessor { get; }

        //public NotificationRepository NotificationRepository { get; }
        NotificationRepository notificationRepository;
        public NotificationController(DataContextAll context, RoleManager<Userroles> roleManager,UserManager<Employee> userManager,
            SignInManager<Employee> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
            HttpContextAccessor = httpContextAccessor;
            notificationRepository = new NotificationRepository(_context, roleManager, userManager, signInManager, HttpContextAccessor);

            //NotificationRepository = notificationRepository;
        }

        public IActionResult GetNotification()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            var notification = notificationRepository.GetNotificationUsers(userId);
            return Ok( new { NotificationUser = notification, count = notification.Count});
        }

        public IActionResult ReadNotification(string NotificationId)
        {
            notificationRepository.ReadNotification(NotificationId);
            return Ok();
        }
    }
}